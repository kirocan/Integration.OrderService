namespace Integration.OrderService.DTOs
{
    /// <summary>
    /// DTO запроса на создание заказа.
    /// </summary>
    public class CreateOrderRequestDto
    {
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
    }
}
