namespace SIS.Domain.Exceptions.Database
{
    /// <summary>
    /// Represents an exception that is thrown when an entity fails to be saved to the database.
    /// </summary>
    public class EntitySaveFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntitySaveFailedException"/> class with a default message.
        /// </summary>
        public EntitySaveFailedException()
            : base("Failed to save the entity to the database.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntitySaveFailedException"/> class with a specified entity name.
        /// </summary>
        /// <param name="entityName">The name of the entity that failed to be saved.</param>
        public EntitySaveFailedException(string entityName)
            : base($"Failed to save the {entityName} to the database.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntitySaveFailedException"/> class with a specified entity name and a reference to the inner exception.
        /// </summary>
        /// <param name="entityName">The name of the entity that failed to be saved.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public EntitySaveFailedException(string entityName, Exception innerException)
            : base($"Failed to save the {entityName} to the database.", innerException)
        {
        }
    }
}
