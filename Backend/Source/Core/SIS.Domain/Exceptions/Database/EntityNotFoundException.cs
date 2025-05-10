using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Database
{
    /// <summary>
    /// Represents an exception that is thrown when an entity is not found in the database.
    /// </summary>
    public class EntityNotFoundException : InvalidInputException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class with a default message.
        /// </summary>
        public EntityNotFoundException()
            : base("The entity was not found.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class with a message.
        /// </summary>
        /// /// <param name="message">The message to be passed to the exception.</param>
        public EntityNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class with a specified entity name and value.
        /// </summary>
        /// <param name="entityName">The name of the entity that was not found.</param>
        /// <param name="value">The value associated with the entity that was not found.</param>
        public EntityNotFoundException(string entityName, string value)
            : base($"The entity \"{entityName}\" with \"{value}\" was not found.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class with a specified entity name, value, and a reference to the inner exception.
        /// </summary>
        /// <param name="entityName">The name of the entity that was not found.</param>
        /// <param name="value">The value associated with the entity that was not found.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public EntityNotFoundException(string entityName, string value, Exception innerException)
            : base($"The entity \"{entityName}\" with \"{value}\" was not found.", innerException)
        {
        }
    }
}