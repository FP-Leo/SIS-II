namespace SIS.Domain.Exceptions.Database
{
    public class DbNoChangeSavedException : Exception
    {
        public DbNoChangeSavedException(string action, string entityName)
            : base($"No changes were saved to the database for action '{action}' on entity '{entityName}'.")
        {
        }
        public DbNoChangeSavedException(string action, string entityName, Exception innerException)
            : base($"No changes were saved to the database for action '{action}' on entity '{entityName}'.", innerException)
        {
        }
    }
}
