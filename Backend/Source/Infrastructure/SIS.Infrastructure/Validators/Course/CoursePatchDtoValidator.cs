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
                .When(c => c.DepartmentId != null || !string.IsNullOrEmpty(c.Name) || c.PrerequisiteCourseIds != null)
                .DependentRules(() =>
                {
                    RuleFor(c => c.Name)
                        .NotEmpty().WithMessage("Course name is required.")
                        .Length(2, 50).WithMessage("Course name must be between 2 and 50 characters.")
                        .MustAsync(BeUniqueCourseName).WithMessage("Course name already exists in this department.")
                        .When(c => !string.IsNullOrEmpty(c.Name));

                    RuleFor(c => c.PrerequisiteCourseIds)
                        .MustAsync(BeValidCourses!)
                        .When(c => c.PrerequisiteCourseIds != null);
                });

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(5, 500).WithMessage("Description must be between 5 and 500 characters.")
                .When(c => !string.IsNullOrEmpty(c.Description));

            RuleFor(c => c.Level)
                .IsInEnum().WithMessage("Level must be a valid enum value.")
                .When(c => c.Level != null);


            RuleFor(x => x.Credits)
                .NotEmpty().WithMessage("Credits are required.")
                .InclusiveBetween(0, 6).WithMessage("Credits must be between 0 and 10.")
                .When(c => c.Credits != null);
        }

        private async Task<bool> BeUniqueCourseName(CoursePatchDto course, string name, CancellationToken cancellationToken)
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
