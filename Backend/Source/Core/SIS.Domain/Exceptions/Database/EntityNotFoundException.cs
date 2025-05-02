using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Database
{
    public class EntityNotFoundException : InvalidInputException
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