using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Services.User
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid email is provided.
    /// </summary>
    public class InvalidMailException : InvalidInputException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMailException"/> class with a default message.
        /// </summary>
        public InvalidMailException() : base("Invalid email provided.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMailException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidMailException(string message) : base(message) { }
    }
}
