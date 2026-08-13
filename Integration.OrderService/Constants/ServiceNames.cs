namespace Integration.OrderService.Constants
{
    /// <summary>
    /// Имена внешних сервисов (для клиентов/логирования и т.п.).
    /// </summary>
    public static class ServiceNames
    {
        /// <summary>
        /// Сервис товаров (gRPC).
        /// </summary>
        public const string Product = "Product";

        /// <summary>
        /// Сервис оплаты (RabbitMQ).
        /// </summary>
        public const string Payment = "Payment";

        /// <summary>
        /// Сервис аналитики (Kafka).
        /// </summary>
        public const string Analytics = "Analytics";
    }
}
