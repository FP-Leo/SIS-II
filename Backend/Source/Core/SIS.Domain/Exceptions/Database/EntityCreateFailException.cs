namespace SIS.Domain.Exceptions.Database
{
    public class EntityCreateFailException: Exception
    {
        public EntityCreateFailException()
            : base("Failed to create entity.")
        {
        }
        public EntityCreateFailException(string entityName)
            : base($"Failed to create {entityName}.")
        {
        }
        public EntityCreateFailException(string errorMessage, Exception innerException)
            : base(errorMessage, innerException)
        {
        }
    }
}
