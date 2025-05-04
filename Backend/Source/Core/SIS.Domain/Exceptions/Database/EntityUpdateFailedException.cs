namespace SIS.Domain.Exceptions.Database
{
    /// <summary>
    /// Represents an exception that is thrown when an entity fails to be updated.
    /// </summary>
    public class EntityUpdateFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityUpdateFailedException"/> class with a default message.
        /// </summary>
        public EntityUpdateFailedException()
            : base("Failed to update entity.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityUpdateFailedException"/> class with a specified entity name.
        /// </summary>
        /// <param name="entityName">The name of the entity that failed to be updated.</param>
        public EntityUpdateFailedException(string entityName)
            : base($"Failed to update entity: {entityName}.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityUpdateFailedException"/> class with a specified entity name and a reference to the inner exception.
        /// </summary>
        /// <param name="entityName">The name of the entity that failed to be updated.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public EntityUpdateFailedException(string entityName, Exception innerException)
            : base($"Failed to update entity: {entityName}.", innerException)
        {
        }
    }
}
