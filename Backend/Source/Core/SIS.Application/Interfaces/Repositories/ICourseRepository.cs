using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        /// <summary>
        /// Gets all courses from the database.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A list of Course entities.</returns>
        Task<IEnumerable<Course>> GetAllCoursesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets a course by its unique identifier.
        /// </summary>
        /// <param name="courseId">The unique identifier of the course.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The Course entity if found; otherwise null.</returns>
        Task<Course?> GetCourseByIdAsync(int courseId, CancellationToken cancellationToken);

        /// <summary>
        /// Gets courses by their department identifier.
        /// </summary>
        /// <param name="departmentId"> The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A list of Course entities.</returns>
        Task<IEnumerable<Course>> GetCoursesByDepartmentIdAsync(int departmentId, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new course to the database.
        /// </summary>
        /// <param name="course">The Course entity to add.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns></returns>
        Task<Course> CreateCourseAsync(Course course, CancellationToken cancellationToken);
        
        /// <summary>
        /// Updates an existing course in the database.
        /// </summary>
        /// <param name="course">The Course entity to update.</param>
        /// <param name="cancellationToken">Token to cancel the operations.</param>
        Task UpdateCourseAsync(Course course, CancellationToken cancellationToken);
        /// <summary>
        /// Deletes a course by its unique identifier.
        /// </summary>
        /// <param name="course">The Course entity to delete.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        Task DeleteCourseAsync(Course course, CancellationToken cancellationToken);

        /// Validation methods

        /// <summary>
        /// Checks if a course with the specified name exists in the given department.
        /// </summary>
        /// <param name="CourseName">The name of the course</param>
        /// <param name="depId">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the course exists; otherwise false.</returns>
        Task<bool> CourseExistsAsync(string CourseName, int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a course with the specified name exists in the given department.
        /// </summary>
        /// <param name="CourseName">The name of the course</param>
        /// <param name="courseId"> The unique identifier of the course to be excluded.</param>
        /// <param name="depId">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the course exists; otherwise false.</returns>
        Task<bool> CourseExistsAsync(int courseId, string CourseName, int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a course with the specified unique identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier of the course.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the course exists; otherwise false.</returns>
        Task<bool> CourseExistsByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a course with the specified unique identifier exists in the given department.
        /// </summary>
        /// <param name="courseId">The unique identifier of the course.</param>
        /// <param name="departmentId"> The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the course exists in the department; otherwise false.</returns>
        Task<bool> CourseExistsInDepartmentAsync(int courseId, int departmentId, CancellationToken cancellationToken);
    }
}
