using FluentValidation;
using SIS.Application.DTOs.LecturerProfileDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.LecturerProfile
{
    /// <summary>
    /// Validator for the <see cref="LecturerProfileCreateDto"/> class.
    /// Ensures that the data provided for creating a lecturer profile meets the required rules and constraints.
    /// </summary>
    public class LecturerCreateDtoValidator: AbstractValidator<LecturerProfileCreateDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LecturerCreateDtoValidator"/> class.
        /// </summary>
        /// <param name="lecturerProfileValidator">An instance of <see cref="ILecturerProfileValidator"/> to perform custom validation logic.</param>
        public LecturerCreateDtoValidator(ILecturerProfileValidator lecturerProfileValidator)
        {
            RuleFor(lp => lp.UserId)
                .NotNull().WithMessage("User ID is required.")
                .NotEmpty().WithMessage("User ID is required.")
                .Length(36, 450).WithMessage("User Id must be a valid GUID.")
                .MustAsync(lecturerProfileValidator.IsUniqueProfile)
                .MustAsync(lecturerProfileValidator.IsValidLecturer);

            RuleFor(lp => lp.Title)
                .NotNull().WithMessage("Title is required.")
                .IsInEnum().WithMessage("Title must be a valid lecturer title.");
        }
    }
}
