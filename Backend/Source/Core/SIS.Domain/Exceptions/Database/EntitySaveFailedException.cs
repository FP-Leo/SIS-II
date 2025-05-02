namespace SIS.Domain.Exceptions.Database
{
    public class EntitySaveFailedException : Exception
    {
        public EntitySaveFailedException()
            : base("Failed to save the entity to the database.")
        {
        }

        public EntitySaveFailedException(string entityName)
            : base($"Failed to save the {entityName} to the database.")
        {
        }
        public EntitySaveFailedException(string entityName, Exception innerException)
            : base($"Failed to save the {entityName} to the database.", innerException)
        {
        }
    }
}
