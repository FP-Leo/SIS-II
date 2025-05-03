using FluentValidation;
using SIS.Application.DTOs.AuthDTOs;

namespace SIS.Infrastructure.Validators.Auth
{
    public class SchoolEmailValidator : AbstractValidator<SchoolMailDto>
    {
        public SchoolEmailValidator()
        {
            RuleFor(x => x.SchoolMail)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .Must(email => email.EndsWith("@comu.edu.tr"))
                .WithMessage("Email must be a school domain email.");
        }
    }
}

