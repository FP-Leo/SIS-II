using SIS.Application.DTOs.UserDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Services
{
    /// <summary>
    /// Provides methods for managing user-related operations.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves a user by their ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user if found; otherwise, null.</returns>
        Task<User?> GetUserByIdAsync(string id);
        /// <summary>
        /// Retrieves a user by their username asynchronously.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <returns>The user if found; otherwise, null.</returns>
        Task<User?> GetUserByUserName(string userName);
        /// <summary>
        /// Retrieves a user by their School Mail asynchronously.
        /// </summary>
        /// <param name="schoolMail">The school mail of the user</param>
        /// <returns>The user if it exists; otherwise, null.</returns>
        Task<User?> GetUserBySchoolMailAsync(string schoolMail);

        /// <summary>
        /// Retrieves a user by their username asynchronously.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <returns>The user if found; otherwise, null.</returns>
        Task<bool> UserNameExistsAsync(string userName);
        /// <summary>
        /// Retrieves a user by their username asynchronously.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <param name="userId"> The unique identifier of the user that is going to be excluded.</param>
        /// <returns>The user if found; otherwise, null.</returns>
        // Task<bool> UserNameExistsAsync(string userName, string userId);

        /// <summary>
        /// Retrieves a user by their school mail asynchronously.
        /// </summary>
        /// <param name="schoolMail">The school mail of the user.</param>
        /// <returns>The user if found; otherwise, null.</returns>
        Task<bool> SchoolMailExistsAsync(string schoolMail);
        /// <summary>
        /// Retrieves a user by their school mail asynchronously.
        /// </summary>
        /// <param name="schoolMail">The school mail of the user.</param>
        /// <param name="userId">The unique identifier of the user that is going to be excluded.</param>
        /// <returns>The user if found; otherwise, null.</returns>
        Task<bool> SchoolMailExistsAsync(string schoolMail, string userId);

        /// <summary>
        /// Registers a new user asynchronously.
        /// </summary>
        /// <param name="user">The user creation data transfer object.</param>
        /// <returns>The ID of the registered user.</returns>
        Task<string> RegisterUserAsync(UserCreateDto user);

        /// <summary>
        /// Updates an existing user asynchronously.
        /// </summary>
        /// <param name="user">The user to update.</param>
        Task UpdateUserAsync(User user);

        /// <summary>
        /// Deletes a user asynchronously.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        Task DeleteUserAsync(User user);

        /// <summary>
        /// Checks if a password matches the user's current password asynchronously.
        /// </summary>
        /// <param name="user">The user whose password is being checked.</param>
        /// <param name="password">The password to check.</param>
        /// <returns>True if the password matches; otherwise, false.</returns>
        Task<bool> CheckPasswordAsync(User user, string password);

        /// <summary>
        /// Resets a user's password asynchronously.
        /// </summary>
        /// <param name="user">The user whose password is being reset.</param>
        /// <param name="newPassword">The new password for the user.</param>
        /// <returns>True if the password reset is successful; otherwise, false.</returns>
        Task<bool> ResetPasswordAsync(User user, string newPassword);

        /// <summary>
        /// Retrieves the roles assigned to a user asynchronously.
        /// </summary>
        /// <param name="user">The user whose roles are being retrieved.</param>
        /// <returns>A list of roles assigned to the user.</returns>
        Task<IList<string>> GetUserRolesAsync(User user);

        /// <summary>
        /// Generates a password reset token for a user asynchronously.
        /// </summary>
        /// <param name="user">The user for whom the token is generated.</param>
        /// <returns>The generated password reset token.</returns>
        Task<string> GeneratePasswordResetTokenAsync(User user);
    }
}
