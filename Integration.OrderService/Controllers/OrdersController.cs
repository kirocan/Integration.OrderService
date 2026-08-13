using Integration.OrderService.DTOs;
using Integration.OrderService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integration.OrderService.Controllers
{
    /// <summary>
    /// Контроллер для работы с заказами.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Создаёт заказ.
        /// </summary>
        /// <remarks>
        /// Оркестрация: проверка товара (gRPC) → сохранение в БД → оплата (RabbitMQ) → аналитика (Kafka).
        /// </remarks>
        /// <param name="request">Данные для создания заказа.</param>
        /// <returns>Созданный заказ.</returns>
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create([FromBody] CreateOrderRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _orderService.CreateAsync(request);
            return CreatedAtAction(nameof(Get), new { orderId = created.OrderId }, created);
        }

        /// <summary>
        /// Возвращает заказ по публичному идентификатору.
        /// </summary>
        /// <param name="orderId">Публичный идентификатор заказа (Guid).</param>
        /// <returns>Заказ.</returns>
        [HttpGet("{orderId:guid}")]
        public async Task<ActionResult<OrderDto>> Get(Guid orderId)
        {
            var result = await _orderService.GetByOrderIdAsync(orderId);
            return Ok(result);
        }
    }
}
