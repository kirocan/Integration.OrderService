namespace Integration.OrderService.DTOs
{
    /// <summary>
    /// DTO заказа для ответов API.
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Публичный идентификатор заказа (Guid).
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
        /// Цена за единицу (из Product Service).
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Итоговая сумма заказа.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Статус заказа.
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Дата и время создания заказа (UTC).
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
