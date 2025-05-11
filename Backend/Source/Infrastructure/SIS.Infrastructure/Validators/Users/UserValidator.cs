using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Domain.Exceptions.Services.User;

namespace SIS.Infrastructure.Validators.Users
{
    /// <summary>
    /// Provides validation methods for user-related data.
    /// </summary>
    public class UserValidator(IUserService userService) : IUserValidator
    {
        private readonly IUserService _userService = userService;

        /// <summary>
        /// Validates the uniqueness and format of a username.
        /// </summary>
        /// <param name="userName">The username to validate.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task ValidateUserNameAsync(string userName)
        {
            var userExists = await _userService.UserNameExistsAsync(userName);
            if (userExists) throw new DuplicateUsernameException(userName);
        }

        /// <summary>
        /// Validates the uniqueness and format of a school email.
        /// </summary>
        /// <param name="email">The school email to validate.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task ValidateSchoolMailAsync(string email)
        {
            var schoolMailExists = await _userService.SchoolMailExistsAsync(email);
            if (schoolMailExists) throw new DuplicateMailException(email);
        }

        /// <summary>
        /// Validates the uniqueness and format of a school email.
        /// </summary>
        /// <param name="email">The school email to validate.</param>
        /// <param name="userId">The unique identifier of the user that is going to be excluded.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task ValidateSchoolMailAsync(string email, string userId)
        {
            var schoolMailExists = await _userService.SchoolMailExistsAsync(email, userId);
            if (schoolMailExists) throw new DuplicateMailException(email);
        }
    }
}