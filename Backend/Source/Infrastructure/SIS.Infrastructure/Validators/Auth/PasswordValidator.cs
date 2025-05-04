using FluentValidation;
using SIS.Application.DTOs.AuthDTOs;

namespace SIS.Infrastructure.Validators.Auth
{
    /// <summary>
    /// Validates the <see cref="NewPasswordDto"/> for password-related operations.
    /// </summary>
    public class PasswordValidator : AbstractValidator<NewPasswordDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordValidator"/> class.
        /// </summary>
        public PasswordValidator()
        {
            /// <summary>
            /// Ensures that the new password is not empty and meets complexity requirements.
            /// </summary>
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

            /// <summary>
            /// Ensures that the confirmation password matches the new password.
            /// </summary>
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword).WithMessage("Passwords do not match.");
        }
    }
}