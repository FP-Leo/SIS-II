using FluentValidation;
using SIS.Application.DTOs.UserDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.Users
{
    public class UserPatchDtoValidator: AbstractValidator<UserPatchDto>
    {
        private readonly IUserValidator userValidator;
        public UserPatchDtoValidator(IUserValidator userValidator)
        {
            this.userValidator = userValidator;

            RuleFor(x => x.FirstName)
                .Matches(@"^[a-zA-Z]+$").WithMessage("First name must contain only letters.")
                .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.FirstName), ApplyConditionTo.CurrentValidator);

            RuleFor(x => x.LastName)
                .Matches(@"^[a-zA-Z]+$").WithMessage("Last name must contain only letters.")
                .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.LastName), ApplyConditionTo.CurrentValidator);

            RuleFor(x => x.SchoolMail)
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(ValidateSchoolMailIsUnique)
                .When(x => !string.IsNullOrEmpty(x.SchoolMail), ApplyConditionTo.CurrentValidator);

            RuleFor(x => x.Mail)
                .EmailAddress().WithMessage("Invalid email format.")
                .When(x => !string.IsNullOrEmpty(x.Mail), ApplyConditionTo.CurrentValidator);

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits long.")
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> ValidateSchoolMailIsUnique(string email, CancellationToken ct)
        {
            await userValidator.ValidateSchoolMailAsync(email);
            return true; // Never reached if validation fails.
        }
    }
}
