namespace SIS.Domain.Exceptions.Common
{
    public class ApiErrorResponse
    {
        public required string Error { get; set; }
        public required string Message { get; set; }
    }
}
