namespace SIS.Domain.Exceptions.Common
{
    /// <summary>
    /// Represents an exception that is thrown when invalid input is encountered.
    /// </summary>
    public class InvalidInputException : Exception
    {
        /// <summary>
        /// Gets the subject associated with the invalid input.
        /// </summary>
        public string Subject { get; } = "InvalidInput";

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidInputException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidInputException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidInputException"/> class with a specified error message and subject.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="subject">The subject associated with the invalid input.</param>
        public InvalidInputException(string message, string subject) : base(message)
        {
            Subject = subject;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidInputException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidInputException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidInputException"/> class with a specified error message, subject, and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="subject">The subject associated with the invalid input.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidInputException(string message, string subject, Exception innerException) : base(message, innerException)
        {
            Subject = subject;
        }
    }
}
