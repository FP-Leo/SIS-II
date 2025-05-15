using FluentValidation;
using SIS.Application.DTOs.StudentProfileDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.StudentProfile
{
    /// <summary>
    /// Validator for the <see cref="StudentProfilePatchDto"/> class.
    /// Ensures that the data provided for updating a Student profile meets the required rules and constraints.
    /// </summary>
    public class StudentPatchDtoValidator: AbstractValidator<StudentProfilePatchDto>
    {
        private readonly IStudentProfileValidator _studentProfileValidator;
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentPatchDtoValidator"/> class.
        /// </summary>
        /// <param name="studentProfileValidator">An instance of <see cref="IStudentProfileValidator"/> to perform custom validation logic.</param>
        public StudentPatchDtoValidator(IStudentProfileValidator studentProfileValidator) {
            _studentProfileValidator = studentProfileValidator;

            RuleFor(sp => sp.Id)
                .NotNull().WithMessage("Profile Id is required.")
                .NotEmpty().WithMessage("Profile Id is required.")
                .GreaterThan(0).WithMessage("Profile Id must be greater than 0.")
                .MustAsync(studentProfileValidator.IsValidProfile);

            RuleFor(sp => sp.DefaultProgramId)
                .MustAsync(studentProfileValidator.IsValidProgram)
                .MustAsync(BeEnrolled)
                .When(sp => sp.DefaultProgramId != null, ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> BeEnrolled(StudentProfilePatchDto studentProfile, int? programId, CancellationToken cancellationToken)
        {
            return await _studentProfileValidator.IsInProgram(studentProfile.Id, programId, cancellationToken);
        }
    }
}
