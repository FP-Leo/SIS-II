using FluentValidation;
using SIS.Application.DTOs.CourseDTOs;
using SIS.Application.Interfaces.Validators;
using SIS.Domain.Exceptions.Common;

namespace SIS.Infrastructure.Validators.Course
{
    /// <summary>
    /// Validator for the <see cref="CourseCreateDto"/> class.
    /// Ensures that the data provided for creating a department meets the required rules and constraints.
    /// </summary>
    public class CourseCreateDtoValidator: AbstractValidator<CourseCreateDto>
    {
        private readonly ICourseValidator _courseValidator;
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseCreateDtoValidator"/> class.
        /// </summary>
        /// <param name="courseValidator">An instance of <see cref="ICourseValidator"/> to perform custom validation logic.</param>
        public CourseCreateDtoValidator(ICourseValidator courseValidator)
        {
            _courseValidator = courseValidator;

            RuleFor(c => c.DepartmentId)
                .NotEmpty().WithMessage("Department ID is required.")
                .GreaterThan(0).WithMessage("Department ID must be greater than 0.")
                .MustAsync(_courseValidator.DepartmentExists).WithMessage("Department ID doesn't exist.")
                .DependentRules(() =>
                {
                    RuleFor(c => c.Name)
                        .NotEmpty().WithMessage("Course name is required.")
                        .Length(2, 50).WithMessage("Course name must be between 2 and 50 characters.")
                        .MustAsync(BeUniqueCourseName).WithMessage("Course name already exists in this department.");

                    RuleFor(c => c.PrerequisiteCourseIds)
                        .MustAsync(BeValidCourses);

                });

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(5, 500).WithMessage("Description must be between 5 and 500 characters.");

            RuleFor(c => c.Level)
                .NotEmpty().WithMessage("Level is required.")
                .IsInEnum().WithMessage("Level must be a valid enum value.");


            RuleFor(c => c.Credits)
                .NotEmpty().WithMessage("Credits are required.")
                .InclusiveBetween(0, 6).WithMessage("Credits must be between 0 and 10.");
        }

        private async Task<bool> BeUniqueCourseName(CourseCreateDto course, string name, CancellationToken cancellationToken)
        {
            return await _courseValidator.IsUniqueCourse(name, course.DepartmentId, cancellationToken);
        }

        private async Task<bool> BeValidCourses(CourseCreateDto course, List<int> courses, CancellationToken cancellationToken)
        {
            if (courses.Count == 0) return true;
            

            foreach (var courseId in courses)
            {
                if (!await _courseValidator.IsValidCourse(courseId, cancellationToken))
                    throw new InvalidInputException($"An invalid course was found in Prerequisite Courses. Course id: {courseId}");
                
                if (!await _courseValidator.IsInDepartment(courseId, course.DepartmentId, cancellationToken))
                    throw new InvalidInputException($"A course that isn't in the same department was found in Prerequisite Courses. Course id: {courseId}");
            }

            return true;
        }
    }
}
