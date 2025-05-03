using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Domain.Exceptions.Common;
using SIS.Domain.Exceptions.Database;
using SIS.Domain.Exceptions.Repositories.University;
using SIS.Domain.Exceptions.Services.User;

namespace SIS.Infrastructure.Validators.Universities
{
    public class UniversityValidator(IUniversityRepository universityRepository, IUserService userService): IUniversityValidator
    {
        private readonly IUniversityRepository _universityRepo = universityRepository;
        private readonly IUserService _userService = userService;

        public async Task<bool> BeUniqueUniversityNameAsync(string universityName, CancellationToken cancellationToken)
        {
            bool nameAlreadyExists = await _universityRepo.UniversityExistsByNameAsync(universityName, cancellationToken);
            if (nameAlreadyExists) throw new DuplicateNameException("University");

            return true;
        }

        public async Task<bool> BeUniqueUniversityAbbreviationAsync(string universityAbbreviation, CancellationToken cancellationToken)
        {
            bool abbreviationAlreadyExists = await _universityRepo.UniversityExistsByAbbreviationAsync(universityAbbreviation, cancellationToken);
            if (abbreviationAlreadyExists) throw new DuplicateAbbreviationException("University");

            return true;
        }

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
