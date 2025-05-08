namespace SIS.Domain.Exceptions.Services.Token
{
    /// <summary>
    /// Represents an exception that is thrown when the token service fails to initialize.
    /// </summary>
    public class TokenServiceInitializationFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenServiceInitializationFailedException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TokenServiceInitializationFailedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenServiceInitializationFailedException"/> class with a specified error message and a reference to the inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public TokenServiceInitializationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
