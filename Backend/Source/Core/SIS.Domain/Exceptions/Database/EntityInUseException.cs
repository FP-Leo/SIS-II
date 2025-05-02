namespace SIS.Domain.Exceptions.Database
{
    public class EntityInUseException: Exception
    {
        public EntityInUseException(string entityName)
            : base($"The {entityName} entity is currently in use and cannot be deleted.")
        {
        }
        public EntityInUseException(string entityName, Exception innerException)
            : base($"The {entityName} entity is currently in use and cannot be deleted.", innerException)
        {
        }
    }
}
