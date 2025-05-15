using FluentValidation;
using SIS.Application.DTOs.LecturerProfileDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.LecturerProfile
{
    /// <summary>
    /// Validator for updating lecturer profile data transfer objects.
    /// Ensures that the data provided for updating a lecturer profile meets the required rules and constraints.
    /// </summary>
    public class LecturerUpdateDtoValidator: AbstractValidator<LecturerProfileUpdateDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LecturerUpdateDtoValidator"/> class.
        /// </summary>
        /// <param name="lecturerProfileValidator">An instance of <see cref="ILecturerProfileValidator"/> for validating lecturer profiles.</param>
        public LecturerUpdateDtoValidator(ILecturerProfileValidator lecturerProfileValidator)
        {
            RuleFor(lp => lp.Id)
                .NotNull().WithMessage("Profile Id is required.")
                .NotEmpty().WithMessage("Profile Id is required.")
                .GreaterThan(0).WithMessage("Profile Id must be greater than 0.")
                .MustAsync(lecturerProfileValidator.IsValidProfile);

            RuleFor(lp => lp.Title)
                .NotNull().WithMessage("Title is required.")
                .IsInEnum().WithMessage("Title must be a valid lecturer type.");
        }
    }
}
