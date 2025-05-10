using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Provides methods for managing university data in the repository.
    /// </summary>
    public interface IUniversityRepository
    {
        //// API methods
        
        /// <summary>
        /// Retrieves all universities asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A collection of universities.</returns>
        Task<IEnumerable<University>> GetAllUniversitiesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a university by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the university.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>The university if found; otherwise, null.</returns>
        Task<University?> GetUniversityByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new university asynchronously.
        /// </summary>
        /// <param name="university">The university to create.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>The created university.</returns>
        Task<University> CreateUniversityAsync(University university, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing university asynchronously.
        /// </summary>
        /// <param name="university">The university to update.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        Task UpdateUniversityAsync(University university, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a university by its ID asynchronously.
        /// </summary>
        /// <param name="university">The university to delete.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        Task DeleteUniversityByIdAsync(University university, CancellationToken cancellationToken);

        //// Validation methods

        /// <summary>
        /// Checks if a university exists by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the university.</param>
        /// <param name="cancellationToken"> A token to cancel the operation.</param>
        Task<bool> UniversityExistsByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a university exists by its name asynchronously.
        /// </summary>
        /// <param name="name">The name of the university.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>True if the university exists; otherwise, false.</returns>
        Task<bool> UniversityExistsByNameAsync(string name, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a university exists by its name asynchronously.
        /// </summary>
        /// <param name="name">The name of the university.</param>
        /// <param name="uniId">The ID of the university to exclude.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>True if the university exists; otherwise, false.</returns>
        Task<bool> UniversityExistsByNameAsync(string name, int uniId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a university exists by its abbreviation asynchronously.
        /// </summary>
        /// <param name="abbreviation">The abbreviation of the university.</param>
        /// <param name="uniId">The ID of the university to exclude.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>True if the university exists; otherwise, false.</returns>
        Task<bool> UniversityExistsByAbbreviationAsync(string abbreviation, int uniId, CancellationToken cancellationToken);
        /// <summary>
        /// Checks if a university exists by its abbreviation asynchronously.
        /// </summary>
        /// <param name="abbreviation">The abbreviation of the university.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>True if the university exists; otherwise, false.</returns>
        Task<bool> UniversityExistsByAbbreviationAsync(string abbreviation, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a rector exists asynchronously.
        /// </summary>
        /// <param name="rectorId">The ID of the rector.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>True if the rector exists; otherwise, false.</returns>
        Task<bool> RectorExistsAsync(string rectorId, CancellationToken cancellationToken);
        
        /// <summary>
        /// Checks if a rector exists asynchronously.
        /// </summary>
        /// <param name="rectorId">The ID of the rector.</param>
        /// <param name="uniId">The ID of the university to exclude.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>True if the rector exists; otherwise, false.</returns>
        Task<bool> RectorExistsAsync(string rectorId, int uniId, CancellationToken cancellationToken);
    }
}