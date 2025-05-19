using FluentValidation;
using SIS.Application.DTOs.CourseInstanceDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.CourseInstance
{
    /// <summary>
    /// Validator for the <see cref="CourseInstanceUpdateDto"/> class.
    /// Ensures that the data provided for creating a course instance meets the required rules and constraints.
    /// </summary>
    public class CourseInstanceUpdateDtoValidator : AbstractValidator<CourseInstanceUpdateDto>
    {
        private readonly ICourseInstanceValidator _validator;
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseInstanceUpdateDtoValidator"/> class.
        /// </summary>
        public CourseInstanceUpdateDtoValidator(ICourseInstanceValidator validator)
        {
            _validator = validator;

            RuleFor(c => c.Id)
                .NotNull().WithMessage("Course Instance Id is required")
                .NotEmpty().WithMessage("Course Instance Id is required")
                .GreaterThan(0).WithMessage("Course Instance Id must be greater than 0.")
                .MustAsync(_validator.BeValidCourseInstance).WithMessage("Course Instance Id is not valid.");

            RuleFor(c => c.LecturerAssignmentId)
                .NotEmpty().WithMessage("Lecturer Assignment ID is required.")
                .GreaterThan(0).WithMessage("Lecturer Assignment ID must be greater than 0.")
                .MustAsync(BeValidLecturerAssignment);

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

        private async Task<bool> BeValidLecturerAssignment(CourseInstanceUpdateDto courseInstance, int id, CancellationToken cancellationToken)
        {
            return await _validator.IsValidLecturerByCourseInstance(id, courseInstance.Id, cancellationToken);
        }
    }
}
