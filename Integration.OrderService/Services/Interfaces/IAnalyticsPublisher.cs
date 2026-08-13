using Integration.OrderService.DTOs;

namespace Integration.OrderService.Services.Interfaces
{
    /// <summary>
    /// Публикатор событий в Kafka для Analytics Service.
    /// </summary>
    public interface IAnalyticsPublisher
    {
        /// <summary>
        /// Отправляет событие «заказ создан».
        /// </summary>
        /// <param name="eventDto">Данные события.</param>
        Task PublishOrderCreatedAsync(OrderCreatedEventDto eventDto);
    }
}
