namespace SIS.Domain.Exceptions.Services.User
{
    /// <summary>
    /// Represents an exception that is thrown when an error occurs while fetching a role.
    /// </summary>
    public class RoleFetchingFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleFetchingFailedException"/> class with a default message.
        /// </summary>
        public RoleFetchingFailedException() : base("An error occurred while fetching the role.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleFetchingFailedException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public RoleFetchingFailedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleFetchingFailedException"/> class with a specified error message and a reference to the inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public RoleFetchingFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
