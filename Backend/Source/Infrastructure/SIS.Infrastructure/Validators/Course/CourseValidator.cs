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
        public async Task<bool> IsUniqueCourse(string code, int depId, CancellationToken cancellationToken)
        {
            bool result = await _courseRepository.CourseExistsAsync(code, depId, cancellationToken);
            if (result) throw new InvalidInputException($"Course with name {code} already exists in the specified department.");

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> IsUniqueCourse(int courseID, string code, int depId, CancellationToken cancellationToken)
        {
            bool result = await _courseRepository.CourseExistsAsync(courseID, code, depId, cancellationToken);
            if (result) throw new InvalidInputException($"Course with name {code} already exists in the specified department.");

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> IsValidCourse(int id, CancellationToken cancellationToken)
        {
            bool result = await _courseRepository.CourseExistsByIdAsync(id, cancellationToken);
            if(!result) throw new InvalidInputException("The specified course does not exist.");

            return result;
        }

        /// <inheritdoc/>
        public async Task<bool> AreValidCourses(List<int> ids, int depId, CancellationToken cancellationToken)
        {
            foreach(int id in ids)
            {
                bool exist = await _courseRepository.CourseExistsByIdAsync(id, cancellationToken);
                if(!exist) throw new InvalidInputException($"An invalid course was found in Prerequisite Courses. Course id: {id}");

                bool inDepartment = await _courseRepository.CourseExistsInDepartmentAsync(id, depId, cancellationToken);
                if (!inDepartment) throw new InvalidInputException($"A course that isn't in the same department was found in Prerequisite Courses. Course id: {id}");
            }

            return true;
        }
    }
}
