using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS.Application.DTOs.UserDTOs;
using SIS.Application.Interfaces.Services;
using SIS.Application.Mappers;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Database;
using SIS.Domain.Exceptions.Services.Auth;
using SIS.Domain.Exceptions.Services.User;

namespace SIS.Infrastructure.Services
{
    /// <summary>
    /// Provides methods for managing user-related operations.
    /// </summary>
    /// <param name="userManager">The user manager for managing user entities.</param>
    /// <param name="tokenService">The token service for generating authentication tokens.</param>
    public class UserService(UserManager<User> userManager, ITokenService tokenService) : IUserService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;

        /// <summary>
        /// Retrieves a user by their ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user if found; otherwise, null.</returns>
        public async Task<User?> GetUserByIdAsync(string id)
        {
            User? user = await _userManager.FindByIdAsync(id);
            return user;
        }

        /// <summary>
        /// Retrieves a user by their username asynchronously.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <returns>The user if found; otherwise, null.</returns>
        public async Task<User?> GetUserByUserName(string userName)
        {
            User? user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        /// <summary>
        /// Retrieves a user by their School Mail asynchronously.
        /// </summary>
        /// <param name="schoolMail">The school mail of the user.</param>
        /// <returns>The user if it exists; otherwise, null.</returns>
        public async Task<User?> GetUserBySchoolMailAsync(string schoolMail)
        {
            User? user = await _userManager.Users.FirstOrDefaultAsync(u => u.SchoolMail == schoolMail);
            return user;
        }

        /// <summary>
        /// Retrieves a user by their username asynchronously.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <returns>The user if found; otherwise, null.</returns>
        public async Task<bool> UserNameExistsAsync(string userName)
        {
            bool result = await _userManager.FindByNameAsync(userName) != null;
            return result;
        }
        
        /// <summary>
        /// Retrieves a user by their school mail asynchronously.
        /// </summary>
        /// <param name="schoolMail">The school mail of the user.</param>
        /// <returns>The user if found; otherwise, null.</returns>
        public async Task<bool> SchoolMailExistsAsync(string schoolMail)
        {
            bool result = await _userManager.Users.AnyAsync(u => u.SchoolMail == schoolMail);
            return result;
        }

        /// <summary>
        /// Retrieves a user by their school mail asynchronously.
        /// </summary>
        /// <param name="schoolMail">The school mail of the user.</param>
        /// <param name="userId"> The unique identifier of the user that is going to be excluded.</param>
        /// <returns>The user if found; otherwise, null.</returns>
        public async Task<bool> SchoolMailExistsAsync(string schoolMail, string userId)
        {
            bool result = await _userManager.Users.AnyAsync(u => u.Id != userId && u.SchoolMail == schoolMail);
            return result;
        }

        /// <summary>
        /// Registers a new user asynchronously.
        /// </summary>
        /// <param name="request">The user creation data transfer object.</param>
        /// <returns>The authentication token for the registered user.</returns>
        /// <exception cref="UserRegistrationFailed">Thrown when user registration or role assignment fails.</exception>
        public async Task<string> RegisterUserAsync(UserCreateDto request)
        {
            User user = request.ToUser();

            IdentityResult result = await _userManager.CreateAsync(user, request.PasswordDto.NewPassword);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new UserRegistrationFailed($"Failed to register user. Errors: {errors}");
            }

            IdentityResult roleResult = await _userManager.AddToRoleAsync(user, request.Role);
            if (!roleResult.Succeeded)
            {
                await DeleteUserAsync(user);
                var errors = string.Join("; ", roleResult.Errors.Select(e => e.Description));
                throw new UserRegistrationFailed($"Role assignment failed: {errors}, rolling back user registration...");
            }

            string token = await _tokenService.CreateToken(user);

            return token;
        }
        
        /// <summary>
        /// Updates an existing user asynchronously.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <exception cref="EntityUpdateFailedException">Thrown when the user update fails.</exception>
        public async Task UpdateUserAsync(User user)
        {
            IdentityResult result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new EntityUpdateFailedException($"Failed to update user {user.Id}: {errors}");
            }
        }
        
        /// <summary>
        /// Deletes a user asynchronously.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        /// <exception cref="EntityDeleteFailedException">Thrown when the user deletion fails.</exception>
        public async Task DeleteUserAsync(User user)
        {
            IdentityResult result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new EntityDeleteFailedException($"Failed to delete user {user.Id}: {errors}");
            }
        }
        
        /// <summary>
        /// Checks if a password matches the user's current password asynchronously.
        /// </summary>
        /// <param name="user">The user whose password is being checked.</param>
        /// <param name="password">The password to check.</param>
        /// <returns>True if the password matches; otherwise, false.</returns>
        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            bool result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }
        
        /// <summary>
        /// Resets a user's password asynchronously.
        /// </summary>
        /// <param name="user">The user whose password is being reset.</param>
        /// <param name="newPassword">The new password for the user.</param>
        /// <returns>True if the password reset is successful; otherwise, false.</returns>
        /// <exception cref="PasswordResetFailedException">Thrown when the password reset fails.</exception>
        public async Task<bool> ResetPasswordAsync(User user, string newPassword)
        {
            string token = await GeneratePasswordResetTokenAsync(user);

            IdentityResult result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new PasswordResetFailedException(user.Id, $"Password reset failed: {errors}");
            }

            return result.Succeeded;
        }
        
        /// <summary>
        /// Retrieves the roles assigned to a user asynchronously.
        /// </summary>
        /// <param name="user">The user whose roles are being retrieved.</param>
        /// <returns>A list of roles assigned to the user.</returns>
        /// <exception cref="RoleFetchingFailedException">Thrown when the user has no roles assigned.</exception>
        public async Task<IList<string>> GetUserRolesAsync(User user)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            if (roles == null || roles.Count == 0)
            {
                throw new RoleFetchingFailedException("User has no roles assigned.");
            }

            return roles;
        }
        
        /// <summary>
        /// Generates a password reset token for a user asynchronously.
        /// </summary>
        /// <param name="user">The user for whom the token is generated.</param>
        /// <returns>The generated password reset token.</returns>
        /// <exception cref="PasswordResetFailedException">Thrown when the token generation fails.</exception>
        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (string.IsNullOrEmpty(token))
            {
                throw new PasswordResetFailedException(user.Id, "Failed to generate password reset token.");
            }
            return token;
        }
    }
}
