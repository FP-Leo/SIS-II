namespace SIS.Domain.Exceptions.Common
{
    /// <summary>
    /// Represents an exception that is thrown when a duplicate name is encountered.
    /// </summary>
    public class DuplicateNameException : DuplicateDataException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateNameException"/> class.
        /// </summary>
        public DuplicateNameException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateNameException"/> class with a specified entity name.
        /// </summary>
        /// <param name="entityName">The name of the entity with the duplicate name.</param>
        public DuplicateNameException(string entityName) : base($"{entityName} name already exists.") { }
    }
}