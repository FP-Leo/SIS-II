using FluentValidation;
using SIS.Application.DTOs.StudentProfileDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.StudentProfile
{
    /// <summary>
    /// Validator for the <see cref="StudentProfileCreateDto"/> class.
    /// Ensures that the data provided for creating a Student profile meets the required rules and constraints.
    /// </summary>
    public class StudentCreateDtoValidator: AbstractValidator<StudentProfileCreateDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentCreateDtoValidator"/> class.
        /// </summary>
        /// <param name="studentProfileValidator">An instance of <see cref="IStudentProfileValidator"/> to perform custom validation logic.</param>
        public StudentCreateDtoValidator(IStudentProfileValidator studentProfileValidator)
        {
            RuleFor(sp => sp.UserId)
                .NotNull().WithMessage("User ID is required.")
                .NotEmpty().WithMessage("User ID is required.")
                .Length(36, 450).WithMessage("User Id must be a valid GUID.")
                .MustAsync(studentProfileValidator.IsUniqueProfile)
                .MustAsync(studentProfileValidator.IsValidStudent);
        }
    }
}
