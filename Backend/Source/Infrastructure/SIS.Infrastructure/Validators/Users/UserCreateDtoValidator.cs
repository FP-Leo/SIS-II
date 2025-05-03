using FluentValidation;
using SIS.Application.DTOs.UserDTOs;
using SIS.Application.Interfaces.Validators;
using SIS.Infrastructure.Validators.Auth;

namespace SIS.Infrastructure.Validators.Users
{
    public class UserCreateDtoValidator: AbstractValidator<UserCreateDto>
    {
        private readonly IUserValidator userValidator;
        private static readonly string[] AllowedRoles = { "Admin", "Student", "Lecturer", "Staff", "Rector", "Dean", "HoD" };

        public UserCreateDtoValidator(IUserValidator userValidator) {
            this.userValidator = userValidator;

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required.")
                .Must(BeValidRole).WithMessage("Role must be either 'Admin', 'Student' or 'Lecturer'.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name is required.")
                .Length(11, 11).WithMessage("User name must be 11 characters long.")
                .Must(userName => userName.All(char.IsDigit)).WithMessage("User name must only contain numbers.")
                .MustAsync(ValidateUserNameIsUnique);

            RuleFor(x => x.PasswordDto)
                .SetValidator(new PasswordValidator());

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Matches(@"^\p{L}+$").WithMessage("First name must contain only letters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Matches(@"^\p{L}+$").WithMessage("Last name must contain only letters.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .Must(date => date <= DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date of birth must be in the past.");

            RuleFor(x => x.SchoolMail)
                .NotEmpty().WithMessage("School mail is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .Must(email => email.EndsWith("@comu.edu.tr"))
                .MustAsync(ValidateSchoolMailIsUnique);
            // .Matches(@"^[a-zA-Z0-9._%+-]+@school\.com$").WithMessage("School mail must end with '@school.com'."); // To be implemented in the future

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits long.");
            // .MustAsync(ValidatePhoneNumberIsUnique); // To be implemented if needed

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format.")
                .When(x => !string.IsNullOrEmpty(x.Email), ApplyConditionTo.CurrentValidator);
            // .MustAsync(ValidateEmailIsUnique); // To be implemented if needed
        }

        private bool BeValidRole(string role)
        {
            return AllowedRoles.Contains(role);
        }

        private async Task<bool> ValidateUserNameIsUnique(string userName, CancellationToken ct)
        {
            await userValidator.ValidateUserNameAsync(userName);
            return true; // Never reached if validation fails.
        }

        private async Task<bool> ValidateSchoolMailIsUnique(string email, CancellationToken ct)
        {
            await userValidator.ValidateSchoolMailAsync(email);
            return true; // Never reached if validation fails.
        }
    }
}
