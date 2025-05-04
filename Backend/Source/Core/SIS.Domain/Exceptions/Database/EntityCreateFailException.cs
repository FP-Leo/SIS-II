namespace SIS.Domain.Exceptions.Database
{
    /// <summary>
    /// Represents an exception that is thrown when an entity fails to be created.
    /// </summary>
    public class EntityCreateFailException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCreateFailException"/> class with a default message.
        /// </summary>
        public EntityCreateFailException()
            : base("Failed to create entity.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCreateFailException"/> class with a specified entity name.
        /// </summary>
        /// <param name="entityName">The name of the entity that failed to be created.</param>
        public EntityCreateFailException(string entityName)
            : base($"Failed to create {entityName}.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCreateFailException"/> class with a specified error message and a reference to the inner exception.
        /// </summary>
        /// <param name="errorMessage">The error message describing the failure.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public EntityCreateFailException(string errorMessage, Exception innerException)
            : base(errorMessage, innerException)
        {
        }
    }
}
