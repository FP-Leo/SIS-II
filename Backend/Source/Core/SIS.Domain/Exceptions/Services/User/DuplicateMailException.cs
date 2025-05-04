using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Services.User
{
    /// <summary>
    /// Represents an exception that is thrown when a duplicate school mail is detected.
    /// </summary>
    public class DuplicateMailException : DuplicateDataException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateMailException"/> class with a specified school mail.
        /// </summary>
        /// <param name="schoolMail">The school mail that caused the duplication.</param>
        public DuplicateMailException(string schoolMail) : base($"The school mail '{schoolMail}' already exists.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateMailException"/> class with a specified school mail and a reference to the inner exception.
        /// </summary>
        /// <param name="schoolMail">The school mail that caused the duplication.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public DuplicateMailException(string schoolMail, Exception innerException) : base($"The school mail '{schoolMail}' already exists.", innerException)
        {
        }
    }
}
