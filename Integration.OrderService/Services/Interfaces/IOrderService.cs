using Integration.OrderService.DTOs;

namespace Integration.OrderService.Services.Interfaces
{
    /// <summary>
    /// Сервис для создания и получения заказов.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Создаёт заказ: проверяет товар, сохраняет в БД, инициирует оплату и аналитику.
        /// </summary>
        /// <param name="request">Данные для создания заказа.</param>
        /// <returns>Созданный заказ в виде DTO.</returns>
        Task<OrderDto> CreateAsync(CreateOrderRequestDto request);

        /// <summary>
        /// Возвращает заказ по публичному идентификатору.
        /// </summary>
        /// <param name="orderId">Публичный идентификатор заказа (Guid).</param>
        /// <returns>Заказ в виде DTO.</returns>
        Task<OrderDto> GetByOrderIdAsync(Guid orderId);
    }
}
