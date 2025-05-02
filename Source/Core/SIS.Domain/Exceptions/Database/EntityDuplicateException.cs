using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Database
{
    public class EntityDuplicateException : DuplicateDataException
    {
        public EntityDuplicateException()
            : base("Data duplication detected. Please check the data and try again.")
        {
        }
        public EntityDuplicateException(string entityName)
            : base($"Data duplication detected when submitting entity: {entityName}. Please check the data and try again.")
        {
        }

        public EntityDuplicateException(string entityName, Exception innerException)
            : base($"Data duplication detected when submitting entity: {entityName}. Please check the data and try again.", innerException)
        {
        }
    }
}