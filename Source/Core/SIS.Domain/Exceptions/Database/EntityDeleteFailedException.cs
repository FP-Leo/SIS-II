namespace SIS.Domain.Exceptions.Database
{
    public class EntityDeleteFailedException: Exception
    {
        public EntityDeleteFailedException()
            : base("Failed to delete the entity from the database.")
        {
        }
        public EntityDeleteFailedException(string entityName)
            : base($"Failed to delete the {entityName} from the database.")
        {
        }
        public EntityDeleteFailedException(string entityName, Exception innerException)
            : base($"Failed to delete the {entityName} from the database.", innerException)
        {
        }

    }
}
