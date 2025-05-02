namespace SIS.Domain.Exceptions.Services.User
{
    public class RoleFetchingFailedException: Exception
    {
        public RoleFetchingFailedException(string message) : base(message)
        {
        }
        public RoleFetchingFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public RoleFetchingFailedException() : base("An error occurred while fetching the role.")
        {
        }
    }
}
