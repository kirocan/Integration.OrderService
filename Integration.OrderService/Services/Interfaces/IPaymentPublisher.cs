using Integration.OrderService.DTOs;

namespace Integration.OrderService.Services.Interfaces
{
    /// <summary>
    /// Публикатор сообщений в RabbitMQ для Payment Service.
    /// </summary>
    public interface IPaymentPublisher
    {
        /// <summary>
        /// Отправляет запрос на оплату заказа.
        /// </summary>
        /// <param name="message">Данные для оплаты.</param>
        Task PublishPaymentRequestedAsync(PaymentRequestedMessageDto message);
    }
}
