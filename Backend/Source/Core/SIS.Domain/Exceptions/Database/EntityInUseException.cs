namespace SIS.Domain.Exceptions.Database
{
    /// <summary>
    /// Represents an exception that is thrown when an entity is in use and cannot be deleted.
    /// </summary>
    public class EntityInUseException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityInUseException"/> class with a specified entity name.
        /// </summary>
        /// <param name="entityName">The name of the entity that is in use.</param>
        public EntityInUseException(string entityName)
            : base($"The {entityName} entity is currently in use and cannot be deleted.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityInUseException"/> class with a specified entity name and a reference to the inner exception.
        /// </summary>
        /// <param name="entityName">The name of the entity that is in use.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public EntityInUseException(string entityName, Exception innerException)
            : base($"The {entityName} entity is currently in use and cannot be deleted.", innerException)
        {
        }
    }
}
