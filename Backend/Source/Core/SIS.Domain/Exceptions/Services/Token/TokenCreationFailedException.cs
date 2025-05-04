namespace SIS.Domain.Exceptions.Services.Token
{
    /// <summary>
    /// Represents an exception that is thrown when token creation fails.
    /// </summary>
    public class TokenCreationFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenCreationFailedException"/> class with a default message.
        /// </summary>
        public TokenCreationFailedException() : base("Failed to create token.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenCreationFailedException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TokenCreationFailedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenCreationFailedException"/> class with a specified error message and a reference to the inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public TokenCreationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
