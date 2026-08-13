using Integration.OrderService.DTOs;
using Integration.OrderService.Services.Interfaces;

namespace Integration.OrderService.Services.Impl
{
    /// <inheritdoc />
    public class ProductClient : IProductClient
    {
        private readonly IConfiguration _configuration;

        public ProductClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc />
        public Task<ProductCheckDto?> CheckProductAsync(Guid productId, int quantity)
        {
            // TODO (студенты): реализовать gRPC-вызов к Product Service.
            // Контракт: Protos/product.proto (метод CheckProduct).
            // Сгенерированный клиент: ProductService.ProductServiceClient.
            var address = _configuration["Services:ProductGrpc"] ?? "http://localhost:5003";
            throw new NotImplementedException($"gRPC Product Service ещё не реализован. Адрес: {address}");
        }
    }
}
