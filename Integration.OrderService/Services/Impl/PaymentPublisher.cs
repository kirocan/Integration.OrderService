using Integration.OrderService.DTOs;
using Integration.OrderService.Services.Interfaces;

namespace Integration.OrderService.Services.Impl
{
    /// <inheritdoc />
    public class PaymentPublisher : IPaymentPublisher
    {
        private readonly IConfiguration _configuration;

        public PaymentPublisher(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc />
        public Task PublishPaymentRequestedAsync(PaymentRequestedMessageDto message)
        {
            // TODO (студенты): реализовать публикацию сообщения в RabbitMQ.
            // Тело сообщения: сериализовать PaymentRequestedMessageDto в JSON.
            var host = _configuration["RabbitMQ:Host"] ?? "localhost";
            var queue = _configuration["RabbitMQ:PaymentQueue"] ?? "payments";
            throw new NotImplementedException($"RabbitMQ Payment ещё не реализован. Host={host}, Queue={queue}");
        }
    }
}
