namespace SIS.Domain.Exceptions.Services.Auth
{
    /// <summary>
    /// Represents an exception that is thrown when a password reset operation fails.
    /// </summary>
    public class PasswordResetFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordResetFailedException"/> class with a default message.
        /// </summary>
        public PasswordResetFailedException() : base("Password reset failed.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordResetFailedException"/> class with a specified user ID.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the password reset failed.</param>
        public PasswordResetFailedException(string userId) : base($"Password reset failed for user with ID {userId}.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordResetFailedException"/> class with a specified user ID and error message.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the password reset failed.</param>
        /// <param name="message">The message that describes the error.</param>
        public PasswordResetFailedException(string userId, string message) : base($"Password reset failed for user with ID {userId}: {message}")
        {
        }
    }
}