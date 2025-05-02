namespace SIS.Domain.Exceptions.Services.Token
{
    public class TokenServiceInitializationFailedException : Exception
    {
        public TokenServiceInitializationFailedException(string message) : base(message)
        {
        }

        public TokenServiceInitializationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
