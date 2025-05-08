using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Domain.Exceptions.Common;
using SIS.Domain.Exceptions.Database;
using SIS.Domain.Exceptions.Repositories.University;
using SIS.Domain.Exceptions.Services.User;

namespace SIS.Infrastructure.Validators.Universities
{
    /// <summary>
    /// Provides validation methods for university-related data.
    /// </summary>
    /// <param name="universityRepository">The repository for managing university data.</param>
    /// <param name="userService">The service for managing user-related operations.</param>
    public class UniversityValidator(IUniversityRepository universityRepository, IUserService userService) : IUniversityValidator
    {
        private readonly IUniversityRepository _universityRepo = universityRepository;
        private readonly IUserService _userService = userService;

        /// <summary>
        /// Validates the uniqueness of a university name asynchronously.
        /// </summary>
        /// <param name="universityName">The name of the university to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>True if the university name is unique; otherwise, throws an exception.</returns>
        /// <exception cref="DuplicateNameException">Thrown when the university name already exists.</exception>
        public async Task<bool> BeUniqueUniversityNameAsync(string universityName, CancellationToken cancellationToken)
        {
            bool nameAlreadyExists = await _universityRepo.UniversityExistsByNameAsync(universityName, cancellationToken);
            if (nameAlreadyExists) throw new DuplicateNameException("University");

            return true;
        }

        /// <summary>
        /// Validates the uniqueness of a university abbreviation asynchronously.
        /// </summary>
        /// <param name="universityAbbreviation">The abbreviation of the university to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>True if the university abbreviation is unique; otherwise, throws an exception.</returns>
        /// <exception cref="DuplicateAbbreviationException">Thrown when the university abbreviation already exists.</exception>
        public async Task<bool> BeUniqueUniversityAbbreviationAsync(string universityAbbreviation, CancellationToken cancellationToken)
        {
            bool abbreviationAlreadyExists = await _universityRepo.UniversityExistsByAbbreviationAsync(universityAbbreviation, cancellationToken);
            if (abbreviationAlreadyExists) throw new DuplicateAbbreviationException("University");

            return true;
        }

        /// <summary>
        /// Validates the existence and role of a rector asynchronously.
        /// </summary>
        /// <param name="rectorId">The ID of the rector to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>True if the rector is valid; otherwise, throws an exception.</returns>
        /// <exception cref="DuplicateRectorException">Thrown when the rector already exists.</exception>
        /// <exception cref="EntityNotFoundException">Thrown when the rector user is not found.</exception>
        /// <exception cref="InvalidRoleException">Thrown when the rector user has no roles or an invalid role.</exception>
        public async Task<bool> BeValidRectorAsync(string rectorId, CancellationToken cancellationToken)
        {
            bool rectorAlreadyExists = await _universityRepo.RectorExistsAsync(rectorId, cancellationToken);
            if (rectorAlreadyExists) throw new DuplicateRectorException();

            var user = await _userService.GetUserByIdAsync(rectorId);
            if (user == null) throw new EntityNotFoundException("User", rectorId);

            var roles = await _userService.GetUserRolesAsync(user);
            if (roles == null || !roles.Any()) throw new InvalidRoleException("The provided user doesn't have any roles associated with it.");

            return roles.Contains("Rector");
        }
    }
}
