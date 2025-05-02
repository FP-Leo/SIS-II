using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Domain.Exceptions.Services.User;

namespace SIS.Infrastructure.Validators.Users
{
    public class UserValidator(IUserService userService) : IUserValidator
    {
        private readonly IUserService _userService = userService;

        public async Task ValidateUserNameAsync(string userName)
        {
            var userExists = await _userService.GetUserByUsernameAsync(userName);
            if (userExists != null) throw new DuplicateUsernameException(userName);
        }
        public async Task ValidateSchoolMailAsync(string email)
        {
            var schoolMailExists = await _userService.GetUserBySchoolMailAsync(email);
            if (schoolMailExists != null) throw new DuplicateMailException(email);
        }
    }
}