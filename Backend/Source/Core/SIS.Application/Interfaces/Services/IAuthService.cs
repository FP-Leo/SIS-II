using SIS.Application.DTOs.AuthDTOs;

namespace SIS.Application.Interfaces.Services
{
    /// <summary>
    /// Provides methods for authentication and authorization services.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates a user based on login credentials.
        /// </summary>
        /// <param name="loginDto">The login data transfer object.</param>
        /// <returns>A successful login DTO if authentication is successful; otherwise, null.</returns>
        Task<SuccessfulLoginDto?> AuthenticateAsync(LoginDto loginDto);

        /// <summary>
        /// Resets a user's password.
        /// </summary>
        /// <param name="resetPasswordDto">The reset password data transfer object.</param>
        /// <returns>True if the password reset is successful; otherwise, false.</returns>
        Task<bool> ResetPasswordAsync(ResetPassword resetPasswordDto);

        /// <summary>
        /// Retrieves a password reset token for a user.
        /// </summary>
        /// <param name="schoolMail">The school mail of the user.</param>
        /// <returns>The password reset token.</returns>
        Task<string> GetResetTokenAsync(string schoolMail);

        /// <summary>
        /// Checks if a password matches the user's current password by user ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="password">The password to check.</param>
        /// <returns>True if the password matches; otherwise, false.</returns>
        Task<bool> CheckPasswordByIdAsync(string userId, string password);
    }
}
