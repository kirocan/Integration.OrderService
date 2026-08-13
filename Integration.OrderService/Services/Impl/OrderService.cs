using AutoMapper;
using Integration.OrderService.Constants;
using Integration.OrderService.Data.Models;
using Integration.OrderService.DTOs;
using Integration.OrderService.Errors;
using Integration.OrderService.Repositories.Interfaces;
using Integration.OrderService.Services.Interfaces;

namespace Integration.OrderService.Services.Impl
{
    /// <inheritdoc />
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductClient _productClient;
        private readonly IPaymentPublisher _paymentPublisher;
        private readonly IAnalyticsPublisher _analyticsPublisher;
        private readonly IMapper _mapper;

        public OrderService(
            IOrderRepository orderRepository,
            IProductClient productClient,
            IPaymentPublisher paymentPublisher,
            IAnalyticsPublisher analyticsPublisher,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productClient = productClient;
            _paymentPublisher = paymentPublisher;
            _analyticsPublisher = analyticsPublisher;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<OrderDto> CreateAsync(CreateOrderRequestDto request)
        {
            if (request.CustomerId == Guid.Empty)
                throw new BusinessException("invalid_customer", "Не указан идентификатор клиента");

            if (request.ProductId == Guid.Empty)
                throw new BusinessException("invalid_product", "Не указан идентификатор товара");

            if (request.Quantity <= 0)
                throw new BusinessException("invalid_quantity", "Количество должно быть больше нуля");

            // Интеграция 1: Product Service (gRPC) — проверка товара/цены/остатка.
            var product = await _productClient.CheckProductAsync(request.ProductId, request.Quantity);
            if (product == null)
                throw new NotFoundException("product_not_found", "Товар не найден");

            if (!product.IsAvailable || product.Stock < request.Quantity)
                throw new BusinessException("product_unavailable", "Товар недоступен или недостаточно остатка");

            var order = new Order
            {
                CustomerId = request.CustomerId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = product.Price,
                TotalAmount = product.Price * request.Quantity,
                Status = OrderStatuses.Created,
                CreatedAt = DateTime.UtcNow
            };

            order = await _orderRepository.CreateAsync(order);

            // Интеграция 2: Payment Service (RabbitMQ) — запрос на оплату.
            await _paymentPublisher.PublishPaymentRequestedAsync(new PaymentRequestedMessageDto
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                Amount = order.TotalAmount,
                Currency = "RUB"
            });

            order.Status = OrderStatuses.AwaitingPayment;
            order = await _orderRepository.UpdateAsync(order);

            // Интеграция 3: Analytics Service (Kafka) — событие создания заказа.
            await _analyticsPublisher.PublishOrderCreatedAsync(new OrderCreatedEventDto
            {
                EventType = "order_created",
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                TotalAmount = order.TotalAmount,
                OccurredAt = order.CreatedAt
            });

            return _mapper.Map<OrderDto>(order);
        }

        /// <inheritdoc />
        public async Task<OrderDto> GetByOrderIdAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByOrderIdAsync(orderId);
            if (order == null)
                throw new NotFoundException("order_not_found", "Заказ не найден");

            return _mapper.Map<OrderDto>(order);
        }
    }
}
