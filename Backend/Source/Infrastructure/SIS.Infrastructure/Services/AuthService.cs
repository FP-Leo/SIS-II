using SIS.Application.DTOs.AuthDTOs;
using SIS.Application.Interfaces.Services;
using SIS.Application.Mappers;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Database;

namespace SIS.Infrastructure.Services
{
    /// <summary>
    /// Provides methods for authentication and authorization services.
    /// </summary>
    /// <param name="userService">The user service for managing user-related operations.</param>
    /// <param name="tokenService">The token service for generating authentication tokens.</param>
    public class AuthService(IUserService userService, ITokenService tokenService) : IAuthService
    {
        private readonly IUserService _userService = userService;
        private readonly ITokenService _tokenService = tokenService;

        /// <summary>
        /// Authenticates a user based on login credentials.
        /// </summary>
        /// <param name="loginDto">The login data transfer object containing username and password.</param>
        /// <returns>A <see cref="SuccessfulLoginDto"/> if authentication is successful; otherwise, null.</returns>
        public async Task<SuccessfulLoginDto?> AuthenticateAsync(LoginDto loginDto)
        {
            User? user = await _userService.GetUserByUsernameAsync(loginDto.Username);
            // Don't throw an exception if the user is not found or password is not correct, just return null. Avoids leaking information about whether the user exists.
            if (user == null) return null;

            bool isValidPassword = await _userService.CheckPasswordAsync(user, loginDto.Password);
            if (!isValidPassword) return null;

            IList<string> userRoles = await _userService.GetUserRolesAsync(user);

            string? token = await _tokenService.CreateToken(user);

            return new SuccessfulLoginDto
            {
                UserData = user.ToUserGetDto(),
                Role = userRoles,
                Token = token
            };
        }

        /// <summary>
        /// Checks if a password matches the user's current password by user ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="password">The password to check.</param>
        /// <returns>True if the password matches; otherwise, false.</returns>
        public async Task<bool> CheckPasswordByIdAsync(string userId, string password)
        {
            User? user = await _userService.GetUserByIdAsync(userId);
            if (user == null) return false;

            bool result = await _userService.CheckPasswordAsync(user, password);
            return result;
        }

        /// <summary>
        /// Resets a user's password.
        /// </summary>
        /// <param name="resetPasswordDto">The reset password data transfer object containing user ID and new password details.</param>
        /// <returns>True if the password reset is successful; otherwise, false.</returns>
        /// <exception cref="EntityNotFoundException">Thrown when the user is not found.</exception>
        public async Task<bool> ResetPasswordAsync(ResetPassword resetPasswordDto)
        {
            User user = await _userService.GetUserByIdAsync(resetPasswordDto.UserId) ?? throw new EntityNotFoundException("User", $"Id: {resetPasswordDto.UserId}");
            bool result = await _userService.ResetPasswordAsync(user, resetPasswordDto.PasswordDto.NewPassword);

            return result;
        }

        /// <summary>
        /// Retrieves a password reset token for a user.
        /// </summary>
        /// <param name="schoolMail">The school mail of the user.</param>
        /// <returns>The password reset token.</returns>
        /// <exception cref="EntityNotFoundException">Thrown when the user is not found.</exception>
        public async Task<string> GetResetTokenAsync(string schoolMail)
        {
            User user = await _userService.GetUserBySchoolMailAsync(schoolMail) ?? throw new EntityNotFoundException("User", $"School Mail: {schoolMail}");
            string token = await _userService.GeneratePasswordResetTokenAsync(user);
 
            return token;
        }
    }
}
