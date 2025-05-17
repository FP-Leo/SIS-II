using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for the Course Instance repository.
    /// </summary>
    public interface ICourseInstanceRepository
    {
        //// API Methods

        /// <summary>
        /// Retrieves all Course Instances for a specific Course.
        /// </summary>
        /// <param name="courseId">The unique identifier of the Course.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>List of Course Instances.</returns>
        Task<IEnumerable<CourseInstance>> GetAllInstancesOfCourseAsync(int courseId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves all Course Instances for a specific Semester.
        /// </summary>
        /// <param name="semesterId">The unique identifier of the Semester.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>List of Course Instances.</returns>
        Task<IEnumerable<CourseInstance>> GetAllCourseInstancesOfSemesterAsync(int semesterId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a Course Instance by its unique identifier.
        /// </summary>
        /// <param name="id">The Course Instance's unique identifier.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>Course Instance if found; otherwise, null.</returns>
        Task<CourseInstance?> GetCourseInstanceByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new Course Instance to the database.
        /// </summary>
        /// <param name="courseInstance">The Course Instance to be added.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>The created Course Instance.</returns>
        Task<CourseInstance> CreateCourseInstanceAsync(CourseInstance courseInstance, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing Course Instance in the database.
        /// </summary>
        /// <param name="courseInstance">The Course Instance to be updated.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task UpdateCourseInstanceAsync(CourseInstance courseInstance, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a Course Instance from the database.
        /// </summary>
        /// <param name="courseInstance">The Course Instance to be deleted.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task DeleteCourseInstanceAsync(CourseInstance courseInstance, CancellationToken cancellationToken);

        //// Validation methods

        /// <summary>
        /// Checks if a Course Instance exists by its unique identifier.
        /// </summary>
        /// <param name="id">The Course Instance's unique identifier.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if exists; otherwise, false.</returns>
        Task<bool> CourseInstanceExistsByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a Course Instance exists by its Course ID and Semester ID.
        /// </summary>
        /// <param name="courseId">The unique identifier of the Course.</param>
        /// <param name="semesterId">The unique identifier of the Semester.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if exists; otherwise, false.</returns>
        Task<bool> CourseInstanceExistsIdAsync(int courseId, int semesterId, CancellationToken cancellationToken);
       
    }
}
