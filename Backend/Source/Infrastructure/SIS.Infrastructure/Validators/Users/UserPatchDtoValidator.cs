using FluentValidation;
using SIS.Application.DTOs.UserDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.Users
{
    /// <summary>
    /// Validates the <see cref="UserPatchDto"/> for partial user updates.
    /// Ensures that the first name, last name, school mail, mail, and phone number meet specific criteria.
    /// </summary>
    public class UserPatchDtoValidator : AbstractValidator<UserPatchDto>
    {
        private readonly IUserValidator userValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserPatchDtoValidator"/> class.
        /// </summary>
        /// <param name="userValidator">The validator for user-related operations.</param>
        public UserPatchDtoValidator(IUserValidator userValidator)
        {
            this.userValidator = userValidator;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User ID is required.")
                .Length(36, 450).WithMessage("User ID must be a valid GUID.");

            /// <summary>
            /// Ensures that the first name contains only letters and is between 2 and 50 characters.
            /// </summary>
            RuleFor(u => u.FirstName)
                .Matches(@"^[a-zA-Z]+$").WithMessage("First name must contain only letters.")
                .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.FirstName), ApplyConditionTo.CurrentValidator);

            /// <summary>
            /// Ensures that the last name contains only letters and is between 2 and 50 characters.
            /// </summary>
            RuleFor(u => u.LastName)
                .Matches(@"^[a-zA-Z]+$").WithMessage("Last name must contain only letters.")
                .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.LastName), ApplyConditionTo.CurrentValidator);

            /// <summary>
            /// Ensures that the school mail is a valid email format and unique.
            /// </summary>
            RuleFor(u => u.SchoolMail)
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(ValidateSchoolMailIsUnique)
                .When(x => !string.IsNullOrEmpty(x.SchoolMail), ApplyConditionTo.CurrentValidator);

            /// <summary>
            /// Ensures that the mail is a valid email format.
            /// </summary>
            RuleFor(u => u.Mail)
                .EmailAddress().WithMessage("Invalid email format.")
                .When(x => !string.IsNullOrEmpty(x.Mail), ApplyConditionTo.CurrentValidator);

            /// <summary>
            /// Ensures that the phone number is 10 digits long.
            /// </summary>
            RuleFor(u => u.PhoneNumber)
                .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits long.")
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber), ApplyConditionTo.CurrentValidator);
        }

        /// <summary>
        /// Validates the uniqueness of the school mail asynchronously.
        /// </summary>
        /// <param name="email">The school mail to validate.</param>
        /// <param name="ct">A token to monitor for cancellation requests.</param>
        /// <returns>True if the school mail is unique; otherwise, throws an exception.</returns>
        private async Task<bool> ValidateSchoolMailIsUnique(UserPatchDto user, string email, CancellationToken ct)
        {
            await userValidator.ValidateSchoolMailAsync(email, user.Id);
            return true; // Never reached if validation fails.
        }
    }
}
