namespace Integration.OrderService.Constants
{
    /// <summary>
    /// Статусы заказа.
    /// </summary>
    public static class OrderStatuses
    {
        /// <summary>
        /// Заказ создан и сохранён в БД.
        /// </summary>
        public const string Created = "Created";

        /// <summary>
        /// Запрос на оплату отправлен в Payment Service.
        /// </summary>
        public const string AwaitingPayment = "AwaitingPayment";
    }
}
