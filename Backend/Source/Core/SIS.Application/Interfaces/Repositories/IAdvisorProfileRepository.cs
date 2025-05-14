using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for the Advisor profile repository.
    /// </summary>
    public interface IAdvisorProfileRepository
    {
        //// API Methods
        /// <summary>
        /// Retrieves all Advisor profiles.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>A list of Advisor profiles.</returns>
        Task<IEnumerable<AdvisorProfile>> GetAllAdvisorProfiles(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves an Advisor profile by its unique identifier.
        /// </summary>
        /// <param name="id">The profile's unique identifier.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>An Advisor profile if found; otherwise, null.</returns>
        Task<AdvisorProfile?> GetAdvisorProfileByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new Advisor profile to the database.
        /// </summary>
        /// <param name="admin">The Advisor profile to be added.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>The created Advisor profile.</returns>
        Task<AdvisorProfile> CreateAdvisorProfileAsync(AdvisorProfile admin, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing Advisor profile in the database.
        /// </summary>
        /// <param name="admin">The Advisor profile to be updated.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task UpdateAdvisorProfileAsync(AdvisorProfile admin, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes an Advisor profile from the database.
        /// </summary>
        /// <param name="admin">The unique identifier of the Advisor profile to be deleted.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task DeleteAdvisorProfileAsync(AdvisorProfile admin, CancellationToken cancellationToken);

        //// Validation methods
        
        /// <summary>
        /// Checks if an Advisor profile with the specified unique identifier exists.
        /// </summary>
        /// <param name="id">the unique identifier of the Advisor profile.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the profile exists; otherwise, false.</returns>
        Task<bool> ProfileExistsByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if an Advisor profile with the user id of the specified profile exists in the given department.
        /// </summary>
        /// <param name="profileId">The unique identifier of the Advisor profile.</param>
        /// <param name="depId"> The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the profile exists; otherwise, false.</returns>
        Task<bool> ProfileExistsAsync(int profileId, int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if an Advisor profile with the specified unique identifier exists in the given department.
        /// </summary>
        /// <param name="departmentId">The unique identifier of the department.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the profile exists; otherwise, false.</returns>
        Task<bool> ProfileExistsAsync(int departmentId, string userId, CancellationToken cancellationToken);
    }
}
