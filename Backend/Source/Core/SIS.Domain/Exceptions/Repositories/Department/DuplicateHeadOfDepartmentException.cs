using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Repositories.Department
{
    /// <summary>
    /// Represents an exception that is thrown when a duplicate HoD is detected.
    /// </summary>
    public class DuplicateHoDException : DuplicateDataException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateHoDException"/> class with a default message.
        /// </summary>
        public DuplicateHoDException() : base("The specified Head of Department already exists.") { }
    }
}
