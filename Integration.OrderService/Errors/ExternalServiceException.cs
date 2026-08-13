namespace Integration.OrderService.Errors
{
    /// <summary>
    /// Ошибка при обращении к внешнему сервису (Product / Payment / Analytics).
    /// </summary>
    public class ExternalServiceException : AppException
    {
        public ExternalServiceException(string code, string message) : base(code, message)
        {
        }
    }
}
