using FluentValidation;
using SIS.Application.DTOs.AuthDTOs;

namespace SIS.Infrastructure.Validators.Auth
{
    public class SelfResetValidator: AbstractValidator<SelfResetPasswordDto>
    {
        public SelfResetValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(x => x.PasswordDto)
                .SetValidator(new PasswordValidator());

            RuleFor(x => x.PasswordDto.NewPassword)
                .NotEqual(x => x.CurrentPassword).WithMessage("The new password cannot be the same as the old one.");
        }
    }
}
