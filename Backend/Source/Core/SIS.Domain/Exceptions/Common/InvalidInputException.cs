namespace SIS.Domain.Exceptions.Common
{
    public class InvalidInputException: Exception
    {
        public string Subject { get; } = "InvalidInput";
        public InvalidInputException(string message) : base(message)
        {
        }
        public InvalidInputException(string message, string subject) : base(message)
        {
            Subject = subject;
        }
        public InvalidInputException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public InvalidInputException(string message, string subject, Exception innerException) : base(message, innerException)
        {
            Subject = subject;
        }
    }
}
