using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Database
{
    public class EntityNotFoundException : InvalidInputException
    {
        public EntityNotFoundException()
            : base("The entity was not found.")
        {
        }

        public EntityNotFoundException(string entityName, string value)
            : base($"The entity \"{entityName}\" with \"{value}\" was not found.")
        {
        }

        public EntityNotFoundException(string entityName, string value, Exception innerException)
            : base($"The entity \"{entityName}\" with \"{value}\" was not found.", innerException)
        {
        }
    }
}