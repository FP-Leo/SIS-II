using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for the lecturer profile repository.
    /// </summary>
    public interface ILecturerProfileRepository
    {
        //// API Methods

        /// <summary>
        /// Retrieves all lecturer profiles.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>List of lecturer profiles.</returns>
        Task<IEnumerable<LecturerProfile>> GetAllLecturerProfiles(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a lecturer profile by its unique identifier.
        /// </summary>
        /// <param name="id">The profile's unique identifier.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>Lecturer profile if found; otherwise, null.</returns>
        Task<LecturerProfile?> GetLecturerProfileByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new lecturer profile to the database.
        /// </summary>
        /// <param name="lecturer">The lecturer profile to be added.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>The created lecturer profile.</returns>
        Task<LecturerProfile> CreateLecturerProfileAsync(LecturerProfile lecturer, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing lecturer profile in the database.
        /// </summary>
        /// <param name="lecturer">The lecturer profile to be updated.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task UpdateLecturerProfileAsync(LecturerProfile lecturer, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a lecturer profile from the database.
        /// </summary>
        /// <param name="lecturer">The lecturer profile to be deleted.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task DeleteLecturerProfileAsync(LecturerProfile lecturer, CancellationToken cancellationToken);

        //// Validation methods
        /// <summary>
        /// Checks if a lecturer profile with the specified unique identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier of the lecturer profile.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the profile exists; otherwise, false.</returns>
        Task<bool> ProfileExistsByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a lecturer profile with the specified user ID exists.
        /// </summary>
        /// <param name="userId">The user ID of the lecturer to check.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the profile exists; otherwise, false.</returns>
        Task<bool> ProfileExistsAsync(string userId, CancellationToken cancellationToken);
    }
}
