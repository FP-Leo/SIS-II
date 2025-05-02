namespace SIS.Domain.Exceptions.Database
{
    public class EntityUpdateFailedException: Exception
    {
        public EntityUpdateFailedException()
            : base("Failed to update entity.")
        {
        }
        public EntityUpdateFailedException(string entityName)
            : base($"Failed to update entity: {entityName}.")
        {
        }
        public EntityUpdateFailedException(string entityName, Exception innerException)
            : base($"Failed to update entity: {entityName}.", innerException)
        {
        }
    }
}
