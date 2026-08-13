using Integration.OrderService.DTOs;

namespace Integration.OrderService.Services.Interfaces
{
    /// <summary>
    /// gRPC-клиент для обращения к Product Service.
    /// </summary>
    public interface IProductClient
    {
        /// <summary>
        /// Проверяет товар, цену и остаток.
        /// </summary>
        /// <param name="productId">Публичный идентификатор товара.</param>
        /// <param name="quantity">Запрашиваемое количество.</param>
        /// <returns>Данные товара или <see langword="null"/>, если товар не найден.</returns>
        Task<ProductCheckDto?> CheckProductAsync(Guid productId, int quantity);
    }
}
