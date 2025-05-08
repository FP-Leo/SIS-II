using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Services.User
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid user name format is provided.
    /// </summary>
    public class InvalidUserNameFormatException : InvalidInputException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserNameFormatException"/> class with a default message.
        /// </summary>
        public InvalidUserNameFormatException() : base("Invalid user name format provided.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserNameFormatException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidUserNameFormatException(string message) : base(message)
        {
        }
    }
}