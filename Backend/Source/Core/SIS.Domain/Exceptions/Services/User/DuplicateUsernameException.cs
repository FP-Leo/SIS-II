using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Services.User
{
    /// <summary>
    /// Represents an exception that is thrown when a duplicate username is detected.
    /// </summary>
    public class DuplicateUsernameException : DuplicateDataException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateUsernameException"/> class with a default message.
        /// </summary>
        public DuplicateUsernameException()
            : base("The username is already taken. Please choose a different one.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateUsernameException"/> class with a specified username.
        /// </summary>
        /// <param name="username">The username that caused the duplication.</param>
        public DuplicateUsernameException(string username)
            : base($"The username '{username}' is already taken. Please choose a different one.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateUsernameException"/> class with a specified username and a reference to the inner exception.
        /// </summary>
        /// <param name="username">The username that caused the duplication.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public DuplicateUsernameException(string username, Exception innerException)
            : base($"The username '{username}' is already taken. Please choose a different one.", innerException)
        {
        }
    }
}
