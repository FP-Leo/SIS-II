using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Repositories.Faculty
{
    /// <summary>
    /// Represents an exception that is thrown when a duplicate Dean is detected.
    /// </summary>
    public class DuplicateDeanException : DuplicateDataException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateDeanException"/> class with a default message.
        /// </summary>
        public DuplicateDeanException() : base("The specified dean already exists.") { }
    }
}
