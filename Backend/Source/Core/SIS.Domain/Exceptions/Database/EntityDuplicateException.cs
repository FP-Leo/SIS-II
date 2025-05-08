using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Database
{
    /// <summary>
    /// Represents an exception that is thrown when a duplicate entity is detected in the database.
    /// </summary>
    public class EntityDuplicateException : DuplicateDataException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDuplicateException"/> class with a default message.
        /// </summary>
        public EntityDuplicateException()
            : base("Data duplication detected. Please check the data and try again.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDuplicateException"/> class with a specified entity name.
        /// </summary>
        /// <param name="entityName">The name of the entity that caused the duplication.</param>
        public EntityDuplicateException(string entityName)
            : base($"Data duplication detected when submitting entity: {entityName}. Please check the data and try again.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDuplicateException"/> class with a specified entity name and a reference to the inner exception.
        /// </summary>
        /// <param name="entityName">The name of the entity that caused the duplication.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public EntityDuplicateException(string entityName, Exception innerException)
            : base($"Data duplication detected when submitting entity: {entityName}. Please check the data and try again.", innerException)
        {
        }
    }
}