using Integration.OrderService.DTOs;
using Integration.OrderService.Services.Interfaces;

namespace Integration.OrderService.Services.Impl
{
    /// <inheritdoc />
    public class AnalyticsPublisher : IAnalyticsPublisher
    {
        private readonly IConfiguration _configuration;

        public AnalyticsPublisher(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc />
        public Task PublishOrderCreatedAsync(OrderCreatedEventDto eventDto)
        {
            // TODO (студенты): реализовать публикацию события в Kafka.
            // Значение: сериализовать OrderCreatedEventDto в JSON.
            var bootstrap = _configuration["Kafka:BootstrapServers"] ?? "localhost:9092";
            var topic = _configuration["Kafka:OrderEventsTopic"] ?? "order-events";
            throw new NotImplementedException($"Kafka Analytics ещё не реализован. BootstrapServers={bootstrap}, Topic={topic}");
        }
    }
}
