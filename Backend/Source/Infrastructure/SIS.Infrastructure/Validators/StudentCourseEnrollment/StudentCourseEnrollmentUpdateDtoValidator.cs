using FluentValidation;
using SIS.Application.DTOs.StudentCourseEnrollmentDTOs;
using SIS.Application.Interfaces.Validators;
using SIS.Domain.Shared;

namespace SIS.Infrastructure.Validators.StudentCourseEnrollment
{
    /// <summary>
    /// Validator for the <see cref="StudentCourseEnrollmentUpdateDto"/> class.
    /// </summary>
    public class StudentCourseEnrollmentUpdateDtoValidator: AbstractValidator<StudentCourseEnrollmentUpdateDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentCourseEnrollmentUpdateDtoValidator"/> class.
        /// </summary>
        /// <param name="validator">An instance of <see cref="IStudentCourseEnrollmentValidator"/> to perform custom validation logic.</param>
        public StudentCourseEnrollmentUpdateDtoValidator(IStudentCourseEnrollmentValidator validator) { 
            RuleFor(sce => sce.Id)
                .NotNull().WithMessage("Course Instance ID is required.")
                .NotEmpty().WithMessage("Course Instance ID is required.")
                .GreaterThan(0).WithMessage("Course Instance ID must be greater than 0.")
                .MustAsync(validator.BeValidCourseInstance);

            RuleFor(sce => sce.Status)
                .IsInEnum().WithMessage("Status must be a valid EnrollmentStatus enum value.");

            // Later on we can validate it to be after the enrollment date
            RuleFor(sce => sce.CompletionDate)
                .Must((dto, completionDate) => dto.Status == EnrollmentStatus.Completed || completionDate == null)
                .WithMessage("Completion date must be null if the status is not 'Completed'.");

            RuleFor(sce => sce.AttendancePercentage)
                .GreaterThanOrEqualTo(0).WithMessage("Attendance percentage must be greater than or equal to 0.")
                .LessThanOrEqualTo(100).WithMessage("Attendance percentage must be less than or equal to 100.");
        }
    }
}
