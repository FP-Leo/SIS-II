using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Repositories.University
{
    /// <summary>
    /// Represents an exception that is thrown when a duplicate rector is detected.
    /// </summary>
    public class DuplicateRectorException : DuplicateDataException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateRectorException"/> class with a default message.
        /// </summary>
        public DuplicateRectorException() : base("Rector not found.") { }
    }
}