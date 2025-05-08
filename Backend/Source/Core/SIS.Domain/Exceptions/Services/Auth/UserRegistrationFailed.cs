namespace SIS.Domain.Exceptions.Services.Auth
{
    /// <summary>
    /// Represents an exception that is thrown when user registration fails.
    /// </summary>
    public class UserRegistrationFailed : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegistrationFailed"/> class.
        /// </summary>
        public UserRegistrationFailed() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegistrationFailed"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public UserRegistrationFailed(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegistrationFailed"/> class with a specified error message and a reference to the inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public UserRegistrationFailed(string message, Exception innerException) : base(message, innerException) { }
    }
}
