using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for the Student profile repository.
    /// </summary>
    public interface IStudentProfileRepository
    {
        //// API Methods

        /// <summary>
        /// Retrieves all Student profiles.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>List of Student profiles.</returns>
        Task<IEnumerable<StudentProfile>> GetAllStudentProfiles(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a Student profile by its unique identifier.
        /// </summary>
        /// <param name="id">The profile's unique identifier.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>Student profile if found; otherwise, null.</returns>
        Task<StudentProfile?> GetStudentProfileByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new Student profile to the database.
        /// </summary>
        /// <param name="Student">The Student profile to be added.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>The created Student profile.</returns>
        Task<StudentProfile> CreateStudentProfileAsync(StudentProfile Student, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing Student profile in the database.
        /// </summary>
        /// <param name="Student">The Student profile to be updated.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task UpdateStudentProfileAsync(StudentProfile Student, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a Student profile from the database.
        /// </summary>
        /// <param name="Student">The Student profile to be deleted.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task DeleteStudentProfileAsync(StudentProfile Student, CancellationToken cancellationToken);

        //// Validation methods
        /// <summary>
        /// Checks if a Student profile with the specified unique identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier of the Student profile.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the profile exists; otherwise, false.</returns>
        Task<bool> ProfileExistsByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a Student profile with the specified user ID exists.
        /// </summary>
        /// <param name="userId">The user ID of the Student to check.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the profile exists; otherwise, false.</returns>
        Task<bool> ProfileExistsAsync(string userId, CancellationToken cancellationToken);
    }
}
