using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Services.User
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid role is provided.
    /// </summary>
    public class InvalidRoleException : InvalidInputException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRoleException"/> class with a default message.
        /// </summary>
        public InvalidRoleException() : base("Invalid role provided.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRoleException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidRoleException(string message) : base(message) { }
    }
}
