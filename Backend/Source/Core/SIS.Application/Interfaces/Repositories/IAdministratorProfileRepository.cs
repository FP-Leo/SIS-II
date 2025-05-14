using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for the administrator profile repository.
    /// </summary>
    public interface IAdministratorProfileRepository
    {
        //// API Methods
        /// <summary>
        /// Retrieves all administrator profiles.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>A list of administrator profiles.</returns>
        Task<IEnumerable<AdministratorProfile>> GetAllAdministratorProfiles(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves an administrator profile by its unique identifier.
        /// </summary>
        /// <param name="id">The profile's unique identifier.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>An administrator profile if found; otherwise, null.</returns>
        Task<AdministratorProfile?> GetAdministratorProfileByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new administrator profile to the database.
        /// </summary>
        /// <param name="admin">The administrator profile to be added.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>The created administrator profile.</returns>
        Task<AdministratorProfile> CreateAdministratorProfileAsync(AdministratorProfile admin, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing administrator profile in the database.
        /// </summary>
        /// <param name="admin">The administrator profile to be updated.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task UpdateAdministratorProfileAsync(AdministratorProfile admin, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes an administrator profile from the database.
        /// </summary>
        /// <param name="admin">The unique identifier of the administrator profile to be deleted.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task DeleteAdministratorProfileAsync(AdministratorProfile admin, CancellationToken cancellationToken);

        //// Validation methods
        
        /// <summary>
        /// Checks if an administrator profile with the specified unique identifier exists.
        /// </summary>
        /// <param name="id">the unique identifier of the administrator profile.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the profile exists; otherwise, false.</returns>
        Task<bool> ProfileExistsByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if an administrator profile with the user id of the specified profile exists in the given department.
        /// </summary>
        /// <param name="profileId">The unique identifier of the administrator profile.</param>
        /// <param name="depId"> The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the profile exists; otherwise, false.</returns>
        Task<bool> ProfileExistsAsync(int profileId, int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if an administrator profile with the specified unique identifier exists in the given department.
        /// </summary>
        /// <param name="departmentId">The unique identifier of the department.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the profile exists; otherwise, false.</returns>
        Task<bool> ProfileExistsAsync(int departmentId, string userId, CancellationToken cancellationToken);
    }
}
