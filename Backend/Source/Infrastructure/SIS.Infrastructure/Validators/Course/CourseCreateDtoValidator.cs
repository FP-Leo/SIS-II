﻿using FluentValidation;
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
                    RuleFor(c => c.Code)
                        .NotEmpty().WithMessage("Course code is required.")
                        .Matches(@"^[A-Z]{3}-\d{4}$").WithMessage("Course code must be in the format 'XXX-0000'.")
                        .MustAsync(BeUniqueCourseCode).WithMessage("Course code already exists in this department.");

                    RuleFor(c => c.PrerequisiteCourseIds)
                        .MustAsync(BeValidCourses!)
                        .When(c => c.PrerequisiteCourseIds != null);
                });

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Course name is required.")
                .Length(3, 100).WithMessage("Course name must be between 3 and 100 characters.")
                .Matches(@"^[A-Za-z0-9\s]+$").WithMessage("Course name can only contain letters, numbers, and spaces.");

            RuleFor(c => c.Type)
                .NotNull().WithMessage("Course type is required.")
                .IsInEnum().WithMessage("Course type must be a valid enum value.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(5, 500).WithMessage("Description must be between 5 and 500 characters.");

            RuleFor(c => c.Level)
                .IsInEnum().WithMessage("Level must be a valid enum value.");

            RuleFor(c => c.IsActive)
                .NotNull().WithMessage("IsActive is required.")
                .NotEmpty().WithMessage("IsActive is required.")
                .Must(x => x == true || x == false).WithMessage("IsActive must be a boolean value.");

            RuleFor(c => c.Credits)
                .NotEmpty().WithMessage("Credits are required.")
                .InclusiveBetween(0, 6).WithMessage("Credits must be between 0 and 10.");
        }

        private async Task<bool> BeUniqueCourseCode(CourseCreateDto course, string name, CancellationToken cancellationToken)
        {
            return await _courseValidator.IsUniqueCourse(name, course.DepartmentId, cancellationToken);
        }

        private async Task<bool> BeValidCourses(CourseCreateDto course, List<int> courses, CancellationToken cancellationToken)
        {
            if (courses.Count == 0) return true;
            
            return await _courseValidator.AreValidCourses(courses, course.DepartmentId, cancellationToken);
        }
    }
}
