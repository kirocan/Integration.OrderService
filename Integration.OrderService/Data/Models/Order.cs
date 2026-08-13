using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration.OrderService.Data.Models
{
    /// <summary>
    /// Заказ (сущность базы данных).
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Внутренний идентификатор (первичный ключ в БД).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Публичный идентификатор заказа (Guid). Используется в API.
        /// </summary>
        public Guid OrderId { get; set; } = Guid.NewGuid();

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
        /// Цена за единицу на момент создания заказа.
        /// </summary>
        [Column(TypeName = "numeric(18,2)")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Итоговая сумма заказа.
        /// </summary>
        [Column(TypeName = "numeric(18,2)")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Статус заказа (например: Created, AwaitingPayment).
        /// </summary>
        [Required]
        [MaxLength(64)]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Дата и время создания заказа (UTC).
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
