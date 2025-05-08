namespace SIS.Domain.Exceptions.Database
{
    /// <summary>
    /// Represents an exception that is thrown when an entity fails to be deleted from the database.
    /// </summary>
    public class EntityDeleteFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDeleteFailedException"/> class with a default message.
        /// </summary>
        public EntityDeleteFailedException()
            : base("Failed to delete the entity from the database.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDeleteFailedException"/> class with a specified entity name.
        /// </summary>
        /// <param name="entityName">The name of the entity that failed to be deleted.</param>
        public EntityDeleteFailedException(string entityName)
            : base($"Failed to delete the {entityName} from the database.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDeleteFailedException"/> class with a specified entity name and a reference to the inner exception.
        /// </summary>
        /// <param name="entityName">The name of the entity that failed to be deleted.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public EntityDeleteFailedException(string entityName, Exception innerException)
            : base($"Failed to delete the {entityName} from the database.", innerException)
        {
        }
    }
}
