namespace SIS.Domain.Exceptions.Services.Auth
{
    public class PasswordResetFailedException : Exception
    {
        public PasswordResetFailedException() : base("Password reset failed.")
        {
        }
        public PasswordResetFailedException(string userId) : base($"Password reset failed for user with ID {userId}.")
        {
        }
        public PasswordResetFailedException(string userId, string message) : base($"Password reset failed for user with ID {userId}: {message}")
        {
        }
    }
}