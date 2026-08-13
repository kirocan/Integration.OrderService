using Integration.OrderService.Data.Models;

namespace Integration.OrderService.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий для работы с заказами в базе данных.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Создаёт новый заказ.
        /// </summary>
        /// <param name="order">Заказ (модель базы данных).</param>
        /// <returns>Созданный заказ.</returns>
        Task<Order> CreateAsync(Order order);

        /// <summary>
        /// Возвращает заказ по публичному идентификатору (Guid).
        /// </summary>
        /// <param name="orderId">Публичный идентификатор заказа (Guid).</param>
        /// <returns>Заказ или <see langword="null"/>, если не найден.</returns>
        Task<Order?> GetByOrderIdAsync(Guid orderId);

        /// <summary>
        /// Обновляет заказ.
        /// </summary>
        /// <param name="order">Заказ с новыми данными.</param>
        /// <returns>Обновлённый заказ.</returns>
        Task<Order> UpdateAsync(Order order);
    }
}
