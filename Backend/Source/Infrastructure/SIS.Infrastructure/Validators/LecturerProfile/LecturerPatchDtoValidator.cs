using FluentValidation;
using SIS.Application.DTOs.LecturerProfileDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.LecturerProfile
{
    /// <summary>
    /// Validator for the <see cref="LecturerProfilePatchDto"/> class.
    /// Ensures that the data provided for patching a lecturer profile meets the required rules and constraints.
    /// </summary>
    public class LecturerPatchDtoValidator: AbstractValidator<LecturerProfilePatchDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LecturerPatchDtoValidator"/> class.
        /// </summary>
        /// <param name="lecturerProfileValidator">An instance of <see cref="ILecturerProfileValidator"/> to perform custom validation logic.</param>
        public LecturerPatchDtoValidator(ILecturerProfileValidator lecturerProfileValidator) {
            RuleFor(lp => lp.Id)
                .NotNull().WithMessage("Profile Id is required.")
                .NotEmpty().WithMessage("Profile Id is required.")
                .GreaterThan(0).WithMessage("Profile Id must be greater than 0.")
                .MustAsync(lecturerProfileValidator.IsValidProfile);

            RuleFor(lp => lp.Title)
                .IsInEnum().WithMessage("Title must be a valid lecturer type.")
                .When(lp => lp.Title != null, ApplyConditionTo.CurrentValidator);
        }
    }
}
