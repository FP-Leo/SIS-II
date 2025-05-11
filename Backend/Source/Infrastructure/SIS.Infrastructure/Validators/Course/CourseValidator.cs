using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Validators;
using SIS.Domain.Exceptions.Common;

namespace SIS.Infrastructure.Validators.Course
{
    /// <summary>
    /// Provides validation logic for course-related operations.
    /// Implements the <see cref="ICourseValidator"/> interface.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="CourseValidator"/> class.
    /// </remarks>
    /// <param name="courseRepository"> The repository for course-related data operations.</param>
    /// <param name="departmentRepository"> The repository for department-related data operations.</param>
    public class CourseValidator(ICourseRepository courseRepository, IDepartmentRepository departmentRepository) : ICourseValidator
    {
        private readonly  ICourseRepository _courseRepository = courseRepository;
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;

        /// <inheritdoc/>
        public async Task<bool> DepartmentExists(int depId, CancellationToken cancellationToken)
        {
            return await _departmentRepository.DepartmentExistsByIdAsync(depId, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<bool> DepartmentExists(int? depId, CancellationToken cancellationToken)
        {
            if (depId == null) throw new InvalidInputException("The specified Department ID is null.");

            return await _departmentRepository.DepartmentExistsByIdAsync(depId.Value, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<bool> IsUniqueCourse(string name, int depId, CancellationToken cancellationToken)
        {
            return await _courseRepository.CourseExistsAsync(name, depId, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<bool> IsUniqueCourse(int courseID, string name, int depId, CancellationToken cancellationToken)
        {
            return await _courseRepository.CourseExistsAsync(name, depId, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<bool> IsValidCourse(int id, CancellationToken cancellationToken)
        {
            return await _courseRepository.CourseExistsByIdAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<bool> IsInDepartment(int courseId, int depId, CancellationToken cancellationToken)
        {
            return await _courseRepository.CourseExistsInDepartmentAsync(courseId, depId, cancellationToken);
        }
    }
}
