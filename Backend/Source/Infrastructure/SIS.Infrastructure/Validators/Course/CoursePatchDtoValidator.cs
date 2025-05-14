using FluentValidation;
using SIS.Application.DTOs.CourseDTOs;
using SIS.Application.Interfaces.Validators;
using SIS.Domain.Exceptions.Common;

namespace SIS.Infrastructure.Validators.Course
{
    /// <summary>
    /// Validator for the <see cref="CoursePatchDto"/> class.
    /// Ensures that the data provided for creating a department meets the required rules and constraints.
    /// </summary>
    public class CoursePatchDtoValidator : AbstractValidator<CoursePatchDto>
    {
        private readonly ICourseValidator _courseValidator;
        /// <summary>
        /// Initializes a new instance of the <see cref="CoursePatchDtoValidator"/> class.
        /// </summary>
        /// <param name="courseValidator">An instance of <see cref="ICourseValidator"/> to perform custom validation logic.</param>
        public CoursePatchDtoValidator(ICourseValidator courseValidator)
        {
            _courseValidator = courseValidator;

            RuleFor(c => c.Id)
                .NotNull().WithMessage("Course ID is required to patch.")
                .NotEmpty().WithMessage("Course ID is required to patch.")
                .GreaterThan(0).WithMessage("Course ID must be greater than 0.")
                .MustAsync(_courseValidator.IsValidCourse);

            RuleFor(c => c.DepartmentId)
                .NotNull().WithMessage("Department ID is required to patch itself or any of the following fields: Name, Prerequisite Courses.")
                .NotEmpty().WithMessage("Department ID is required to patch itself or any of the following fields: Name, Prerequisite Courses.")
                .GreaterThan(0).WithMessage("Department ID must be greater than 0. It is required to patch itself or any of the following fields: Name, Prerequisite Courses.")
                .MustAsync(_courseValidator.DepartmentExists).WithMessage("Department ID doesn't exist. ")
                .When(c => c.DepartmentId != null || !string.IsNullOrEmpty(c.Code) || c.PrerequisiteCourseIds != null, ApplyConditionTo.CurrentValidator)
                .DependentRules(() =>
                {
                    RuleFor(c => c.Code)
                        .NotEmpty().WithMessage("Course code is required.")
                        .Matches(@"^[A-Z]{3}-\d{4}$").WithMessage("Course code must be in the format 'XXX-0000'.")
                        .MustAsync(BeUniqueCourseCode).WithMessage("Course code already exists in this department.")
                        .When(c => !string.IsNullOrEmpty(c.Code), ApplyConditionTo.CurrentValidator);

                    RuleFor(c => c.PrerequisiteCourseIds)
                        .MustAsync(BeValidCourses!)
                        .When(c => c.PrerequisiteCourseIds != null, ApplyConditionTo.CurrentValidator);
                });

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Course name is required.")
                .Length(3, 100).WithMessage("Course name must be between 3 and 100 characters.")
                .Matches(@"^[A-Za-z0-9\s]+$").WithMessage("Course name can only contain letters, numbers, and spaces.")
                .When(c => !string.IsNullOrEmpty(c.Name), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.Type)
                .IsInEnum().WithMessage("Course type must be a valid enum value.")
                .When(c => c.Type != null, ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(5, 500).WithMessage("Description must be between 5 and 500 characters.")
                .When(c => !string.IsNullOrEmpty(c.Description), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.Level)
                .IsInEnum().WithMessage("Level must be a valid enum value.")
                .When(c => c.Level != null, ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.IsActive)
                .NotNull().WithMessage("IsActive is required.")
                .NotEmpty().WithMessage("IsActive is required.")
                .Must(x => x == true || x == false).WithMessage("IsActive must be a boolean value.")
                .When(c => c.IsActive != null, ApplyConditionTo.CurrentValidator);

            RuleFor(x => x.Credits)
                .NotEmpty().WithMessage("Credits are required.")
                .InclusiveBetween(0, 6).WithMessage("Credits must be between 0 and 10.")
                .When(c => c.Credits != null, ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> BeUniqueCourseCode(CoursePatchDto course, string name, CancellationToken cancellationToken)
        {
            return await _courseValidator.IsUniqueCourse(course.Id, name, course.DepartmentId!.Value, cancellationToken);
        }

        private async Task<bool> BeValidCourses(CoursePatchDto course, List<int> courses, CancellationToken cancellationToken)
        {
            if (courses.Count == 0) return true;

            if (courses.Contains(course.Id)) throw new InvalidInputException("Course cannot be its own prerequisite.");

            return await _courseValidator.AreValidCourses(courses, course.DepartmentId!.Value, cancellationToken);
        }
    }
}
