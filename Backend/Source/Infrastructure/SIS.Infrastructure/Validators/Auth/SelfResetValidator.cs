using FluentValidation;
using SIS.Application.DTOs.AuthDTOs;

namespace SIS.Infrastructure.Validators.Auth
{
    /// <summary>
    /// Validates the <see cref="SelfResetPasswordDto"/> for self password reset operations.
    /// </summary>
    public class SelfResetValidator : AbstractValidator<SelfResetPasswordDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelfResetValidator"/> class.
        /// </summary>
        public SelfResetValidator()
        {
            /// <summary>
            /// Ensures that the UserId is not empty.
            /// </summary>
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");

            /// <summary>
            /// Validates the PasswordDto using the <see cref="PasswordValidator"/>.
            /// </summary>
            RuleFor(x => x.PasswordDto)
                .SetValidator(new PasswordValidator());

            /// <summary>
            /// Ensures that the new password is not the same as the current password.
            /// </summary>
            RuleFor(x => x.PasswordDto.NewPassword)
                .NotEqual(x => x.CurrentPassword).WithMessage("The new password cannot be the same as the old one.");
        }
    }
}
