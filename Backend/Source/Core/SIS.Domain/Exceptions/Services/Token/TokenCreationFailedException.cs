namespace SIS.Domain.Exceptions.Services.Token
{
    public class TokenCreationFailedException: Exception
    {
        public TokenCreationFailedException() : base("Failed to create token.")
        {
        }
        public TokenCreationFailedException(string message) : base(message)
        {
        }
        public TokenCreationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
