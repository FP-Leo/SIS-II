using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Validators
{
    public interface IUserValidator
    {
        // It will use UserManager to validate the user so no CancellationToken is needed
        Task ValidateUserNameAsync(string userName);
        Task ValidateSchoolMailAsync(string email);
    }
}