namespace SIS.Domain.Exceptions.Common
{
    /// <summary>
    /// Represents an exception that is thrown when a duplicate abbreviation is encountered.
    /// </summary>
    public class DuplicateAbbreviationException : DuplicateDataException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateAbbreviationException"/> class.
        /// </summary>
        public DuplicateAbbreviationException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateAbbreviationException"/> class with a specified entity name.
        /// </summary>
        /// <param name="entityName">The name of the entity with the duplicate abbreviation.</param>
        public DuplicateAbbreviationException(string entityName) : base($"{entityName} abbreviation already exists.") { }
    }
}
