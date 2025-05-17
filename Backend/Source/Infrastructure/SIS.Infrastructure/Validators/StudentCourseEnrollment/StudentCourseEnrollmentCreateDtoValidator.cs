using FluentValidation;
using SIS.Application.DTOs.StudentCourseEnrollmentDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.StudentCourseEnrollment
{
    /// <summary>
    /// Validator for the <see cref="StudentCourseEnrollmentCreateDto"/> class.
    /// Ensures that the data provided for creating a Student Course Enrollment meets the required rules and constraints.
    /// </summary>
    public class StudentCourseEnrollmentCreateDtoValidator: AbstractValidator<StudentCourseEnrollmentCreateDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentCourseEnrollmentCreateDtoValidator"/> class.
        /// </summary>
        /// <param name="validator">An instance of <see cref="IStudentCourseEnrollmentValidator"/> to perform custom validation logic.</param>
        public StudentCourseEnrollmentCreateDtoValidator(IStudentCourseEnrollmentValidator validator)
        {
            RuleFor(sce => sce.CourseInstanceId)
                .NotNull().WithMessage("Course Instance ID is required.")
                .NotEmpty().WithMessage("Course Instance ID is required.")
                .GreaterThan(0).WithMessage("Course Instance ID must be greater than 0.")
                .MustAsync(validator.BeValidCourseInstance);
            RuleFor(sce => sce.ProgramEnrollmentId)
                .NotNull().WithMessage("Program Enrollment ID is required.")
                .NotEmpty().WithMessage("Program Enrollment ID is required.")
                .GreaterThan(0).WithMessage("Program Enrollment ID must be greater than 0.")
                .MustAsync(validator.IsValidProgramEnrollment);
        }
    }
}
