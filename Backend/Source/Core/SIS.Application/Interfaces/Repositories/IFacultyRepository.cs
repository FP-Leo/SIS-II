using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for repository operations related to the Faculty entity.
    /// </summary>
    public interface IFacultyRepository
    {
        /// <summary>
        /// Retrieves all faculties asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A collection of all faculties.</returns>
        Task<IEnumerable<Faculty>> GetAllFacultiesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a faculty by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the faculty.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The faculty if found; otherwise, null.</returns>
        Task<Faculty?> GetFacultyByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new faculty asynchronously.
        /// </summary>
        /// <param name="faculty">The faculty entity to create.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The created faculty entity.</returns>
        Task<Faculty> CreateFacultyAsync(Faculty faculty, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing faculty asynchronously.
        /// </summary>
        /// <param name="faculty">The faculty entity to update.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        Task UpdateFacultyAsync(Faculty faculty, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a faculty by its entity asynchronously.
        /// </summary>
        /// <param name="faculty">The faculty entity to delete.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        Task DeleteFacultyByIdAsync(Faculty faculty, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a faculty with the specified name exists in a university asynchronously.
        /// </summary>
        /// <param name="name">The name of the faculty.</param>
        /// <param name="uniId">The unique identifier of the university.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the faculty exists; otherwise, false.</returns>
        Task<bool> FacultyExistsInUniAsync(string name, int uniId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a faculty with the specified code exists in a university asynchronously.
        /// </summary>
        /// <param name="code">The code of the faculty.</param>
        /// <param name="uniId">The unique identifier of the university.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the code exists; otherwise, false.</returns>
        Task<bool> CodeExistsInUniAsync(string code, int uniId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a faculty with the specified id exists asynchronously.
        /// </summary>
        /// <param name="phoneNumber">The unique identifier of the faculty.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if faculty exists; otherwise, false.</returns>
        Task<bool> FacultyExistsByIdAsync(int facultyId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a faculty with the specified phone number exists asynchronously.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the faculty.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the phone number exists; otherwise, false.</returns>
        Task<bool> FacultyExistsByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a faculty with the specified dean ID exists asynchronously.
        /// </summary>
        /// <param name="deanId">The unique identifier of the dean.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the dean ID exists; otherwise, false.</returns>
        Task<bool> FacultyExistsByDeanIdAsync(string deanId, CancellationToken cancellationToken);
    }
}
