namespace SIS.Application.Interfaces.Validators
{
    /// <summary>
    /// Provides methods for validating university-related data.
    /// </summary>
    public interface IUniversityValidator
    {
        /// <summary>
        /// Validates the uniqueness of a university name asynchronously.
        /// </summary>
        /// <param name="universityName">The name of the university to validate.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>True if the university name is unique; otherwise, false.</returns>
        Task<bool> BeUniqueUniversityNameAsync(string universityName, CancellationToken cancellationToken);
        
        /// <summary>
        /// Validates the uniqueness of a university name asynchronously.
        /// </summary>
        /// <param name="universityName">The name of the university to validate.</param>
        /// <param name="uniId">The ID of the university to exclude.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>True if the university name is unique; otherwise, false.</returns>
        Task<bool> BeUniqueUniversityNameAsync(string universityName, int uniId, CancellationToken cancellationToken);

        /// <summary>
        /// Validates the uniqueness of a university abbreviation asynchronously.
        /// </summary>
        /// <param name="universityAbbreviation">The abbreviation of the university to validate.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>True if the university abbreviation is unique; otherwise, false.</returns>
        Task<bool> BeUniqueUniversityAbbreviationAsync(string universityAbbreviation, CancellationToken cancellationToken);
        /// <summary>
        /// Validates the uniqueness of a university abbreviation asynchronously.
        /// </summary>
        /// <param name="universityAbbreviation">The abbreviation of the university to validate.</param>
        /// <param name="unidId">The ID of the university to exclude.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>True if the university abbreviation is unique; otherwise, false.</returns>
        Task<bool> BeUniqueUniversityAbbreviationAsync(string universityAbbreviation, int unidId, CancellationToken cancellationToken);

        /// <summary>
        /// Validates the existence of a rector asynchronously.
        /// </summary>
        /// <param name="rectorId">The ID of the rector to validate.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>True if the rector exists; otherwise, false.</returns>
        Task<bool> BeValidRectorAsync(string rectorId, CancellationToken cancellationToken);

        /// <summary>
        /// Validates the existence of a rector asynchronously.
        /// </summary>
        /// <param name="rectorId">The ID of the rector to validate.</param>
        /// <param name="uniId"> The ID of the university to exclude.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>True if the rector exists; otherwise, false.</returns>
        Task<bool> BeValidRectorAsync(string rectorId, int uniId, CancellationToken cancellationToken);
    }
}
