namespace SIS.Domain.Exceptions.Database
{
    /// <summary>
    /// Represents an exception that is thrown when no changes are saved to the database for a specific action.
    /// </summary>
    public class DbNoChangeSavedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbNoChangeSavedException"/> class with a specified action and entity name.
        /// </summary>
        /// <param name="action">The action that was attempted.</param>
        /// <param name="entityName">The name of the entity for which no changes were saved.</param>
        public DbNoChangeSavedException(string action, string entityName)
            : base($"No changes were saved to the database for action '{action}' on entity '{entityName}'.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbNoChangeSavedException"/> class with a specified action, entity name, and a reference to the inner exception.
        /// </summary>
        /// <param name="action">The action that was attempted.</param>
        /// <param name="entityName">The name of the entity for which no changes were saved.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public DbNoChangeSavedException(string action, string entityName, Exception innerException)
            : base($"No changes were saved to the database for action '{action}' on entity '{entityName}'.", innerException)
        {
        }
    }
}
