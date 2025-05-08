using FluentValidation;
using SIS.Application.DTOs.AuthDTOs;

namespace SIS.Infrastructure.Validators.Auth
{
    /// <summary>
    /// Validates the school mail for user-related operations.
    /// </summary>
    public class SchoolMailValidator : AbstractValidator<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolMailValidator"/> class.
        /// </summary>
        public SchoolMailValidator()
        {
            /// <summary>
            /// Ensures that the school mail is not empty and matches a valid email format.
            /// </summary>
            RuleFor(x => x)
                .NotEmpty().WithMessage("School mail is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}

