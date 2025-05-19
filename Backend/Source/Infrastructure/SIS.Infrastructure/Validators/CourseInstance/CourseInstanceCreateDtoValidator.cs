using FluentValidation;
using SIS.Application.DTOs.CourseInstanceDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.CourseInstance
{
    /// <summary>
    /// Validator for the <see cref="CourseInstanceCreateDto"/> class.
    /// Ensures that the data provided for creating a course instance meets the required rules and constraints.
    /// </summary>
    public class CourseInstanceCreateDtoValidator : AbstractValidator<CourseInstanceCreateDto>
    {
        private readonly ICourseInstanceValidator _validator;
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseInstanceCreateDtoValidator"/> class.
        /// </summary>
        public CourseInstanceCreateDtoValidator(ICourseInstanceValidator validator)
        {
            _validator = validator;

            RuleFor(c => c.CourseId)
                .NotEmpty().WithMessage("Course ID is required.")
                .GreaterThan(0).WithMessage("Course ID must be greater than 0.")
                .MustAsync(validator.BeValidCourseInstance);

            RuleFor(c => c.ProgramSemesterId)
                .NotEmpty().WithMessage("Program Semester ID is required.")
                .GreaterThan(0).WithMessage("Program Semester ID must be greater than 0.")
                .MustAsync(BeValidProgramSemester);

            RuleFor(c => c)
                .MustAsync(BeUniqueCourseInstance)
                .WithMessage("The course instance already exists in the specified program semester.");

            RuleFor(c => c.LecturerAssignmentId)
                .NotEmpty().WithMessage("Lecturer Assignment ID is required.")
                .GreaterThan(0).WithMessage("Lecturer Assignment ID must be greater than 0.")
                .MustAsync(BeValidLecturerAssignment);

            RuleFor(c => c.AdminProfileId)
                .NotEmpty().WithMessage("Admin Profile ID is required.")
                .GreaterThan(0).WithMessage("Admin Profile ID must be greater than 0.")
                .MustAsync(BeValidAdmin);

            RuleFor(c => c.EnrollmentLimit)
                .NotEmpty().WithMessage("Enrollment limit must be a valid value.")
                .GreaterThan(0).WithMessage("Enrollment limit must be greater than 0.")
                .When(c => c.EnrollmentLimit.HasValue, ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.AttendancePercentage)
                .NotNull().WithMessage("Attendance percentage is required.")
                .NotEmpty().WithMessage("Attendance percentage is required.")
                .InclusiveBetween(0, 100).WithMessage("Attendance percentage must be between 0 and 100.");

            RuleFor(c => c.DeliveryMethod)
                .NotNull().WithMessage("Delivery method is required.")
                .IsInEnum().WithMessage("Delivery method must be a valid enum value.");
        }

        private async Task<bool> BeValidLecturerAssignment(CourseInstanceCreateDto courseInstance, int id, CancellationToken cancellationToken)
        {
            return await _validator.IsValidLecturerByCourse(id, courseInstance.CourseId, cancellationToken);
        }

        private async Task<bool> BeValidAdmin(CourseInstanceCreateDto courseInstance, int id, CancellationToken cancellationToken)
        {
            return await _validator.IsValidAdminByCourse(id, courseInstance.CourseId, cancellationToken);
        }

        private async Task<bool> BeUniqueCourseInstance(CourseInstanceCreateDto courseInstance, CancellationToken cancellationToken)
        {
            return await _validator.IsUniqueCourseInstance(courseInstance.CourseId, courseInstance.ProgramSemesterId, cancellationToken);
        }

        private async Task<bool> BeValidProgramSemester(CourseInstanceCreateDto courseInstance, int id, CancellationToken cancellationToken)
        {
            return await _validator.BeValidProgramSemesterByCourse(id, courseInstance.CourseId, cancellationToken);
        }
    }
}
