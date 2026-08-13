namespace Integration.OrderService.DTOs
{
    /// <summary>
    /// Сообщение в очередь оплаты (RabbitMQ → Payment Service).
    /// </summary>
    public class PaymentRequestedMessageDto
    {
        /// <summary>
        /// Публичный идентификатор заказа.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Публичный идентификатор клиента.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Сумма к оплате.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Валюта (например: RUB).
        /// </summary>
        public string Currency { get; set; } = "RUB";
    }
}
