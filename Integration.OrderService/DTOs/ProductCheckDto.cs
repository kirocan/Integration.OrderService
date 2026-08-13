namespace Integration.OrderService.DTOs
{
    /// <summary>
    /// Результат проверки товара в Product Service.
    /// </summary>
    public class ProductCheckDto
    {
        /// <summary>
        /// Публичный идентификатор товара.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Название товара.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Цена за единицу.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Остаток на складе.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Доступен ли товар в запрошенном количестве.
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}
