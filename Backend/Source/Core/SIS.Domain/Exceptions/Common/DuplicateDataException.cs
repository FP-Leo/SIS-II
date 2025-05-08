namespace SIS.Domain.Exceptions.Common
{
    /// <summary>
    /// Represents an exception that is thrown when duplicate data is found.
    /// </summary>
    public class DuplicateDataException : InvalidInputException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateDataException"/> class with a default message.
        /// </summary>
        public DuplicateDataException() : base("Duplicate data found.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateDataException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DuplicateDataException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateDataException"/> class with a specified error message and a reference to the inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public DuplicateDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
