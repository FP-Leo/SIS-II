using FluentValidation;
using SIS.Application.DTOs.LecturerProfileDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.LecturerProfile
{
    public class LecturerUpdateDtoValidator: AbstractValidator<LecturerProfileUpdateDto>
    {
        public LecturerUpdateDtoValidator(ILecturerProfileValidator lecturerProfileValidator)
        {
            RuleFor(l => l.Id)
                .NotNull().WithMessage("Profile Id is required.")
                .NotEmpty().WithMessage("Profile Id is required.")
                .GreaterThan(0).WithMessage("Profile Id must be greater than 0.")
                .MustAsync(lecturerProfileValidator.IsValidProfile);

            RuleFor(l => l.Title)
                .NotNull().WithMessage("Title is required.")
                .IsInEnum().WithMessage("Title must be a valid lecturer type.");
        }
    }
}
