namespace SIS.Domain.Exceptions.Services.Auth
{
    public class UserRegistrationFailed: Exception
    {
        public UserRegistrationFailed() { }
        public UserRegistrationFailed(string message) : base(message) { }
        public UserRegistrationFailed(string message, Exception innerException) : base(message, innerException) { }
    }
}
