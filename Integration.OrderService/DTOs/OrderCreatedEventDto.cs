namespace Integration.OrderService.DTOs
{
    /// <summary>
    /// Событие создания заказа (Kafka → Analytics Service).
    /// </summary>
    public class OrderCreatedEventDto
    {
        /// <summary>
        /// Тип события.
        /// </summary>
        public string EventType { get; set; } = "order_created";

        /// <summary>
        /// Публичный идентификатор заказа.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Публичный идентификатор клиента.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Публичный идентификатор товара.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Количество единиц товара.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Итоговая сумма заказа.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Момент события (UTC).
        /// </summary>
        public DateTime OccurredAt { get; set; }
    }
}
