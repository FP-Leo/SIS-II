using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Validators
{
    /// <summary>
    /// Provides methods for validating user-related data.
    /// </summary>
    public interface IUserValidator
    {
        /// <summary>
        /// Validates the uniqueness and format of a username.
        /// </summary>
        /// <param name="userName">The username to validate.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task ValidateUserNameAsync(string userName);

        /// <summary>
        /// Validates the uniqueness and format of a school email.
        /// </summary>
        /// <param name="email">The school email to validate.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task ValidateSchoolMailAsync(string email);

        /// <summary>
        /// Validates the uniqueness and format of a school email.
        /// </summary>
        /// <param name="email">The school email to validate.</param>
        /// <param name="userId">The unique identifier of the user that is going to be excluded.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task ValidateSchoolMailAsync(string email, string userId);
    }
}