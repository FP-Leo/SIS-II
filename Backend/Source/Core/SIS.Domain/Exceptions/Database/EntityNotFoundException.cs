namespace SIS.Domain.Exceptions.Database
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
            : base("The entity was not found.")
        {
        }
        public EntityNotFoundException(string entityName)
            : base($"The entity \"{entityName}\" was not found.")
        {
        }
        public EntityNotFoundException(string entityName, Exception innerException)
            : base($"The entity \"{entityName}\" was not found.", innerException)
        {
        }
    }
}