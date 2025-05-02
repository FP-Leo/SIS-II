using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Common;
using SIS.Domain.Exceptions.University;
using System.Threading;

namespace SIS.Infrastructure.Validators
{
    public class UniversityValidator(IUniversityRepository universityRepository, IUserService userService): IUniversityValidator
    {
        private readonly IUniversityRepository _universityRepo = universityRepository;
        private readonly IUserService userService = userService;

        public async Task ValidateUniversityNameExistsAsync(string universityName, CancellationToken cancellationToken)
        {
            bool nameAlreadyExists = await _universityRepo.UniversityExistsByNameAsync(universityName, cancellationToken);
            if (nameAlreadyExists) throw new DuplicateNameException("University");
        }

        public async Task ValidateUniversityAbbreviationExistsAsync(string universityAbbreviation, CancellationToken cancellationToken)
        {
            bool abbreviationAlreadyExists = await _universityRepo.UniversityExistsByAbbreviationAsync(universityAbbreviation, cancellationToken);
            if (abbreviationAlreadyExists) throw new DuplicateAbbreviationException("University");
        }

        public async Task ValidateRectorExistsAsync(string rectorId, CancellationToken cancellationToken)
        {
            bool rectorAlreadyExists = await _universityRepo.RectorExistsAsync(rectorId, cancellationToken);
            if (rectorAlreadyExists) throw new DuplicateRectorException();
        }

        public async Task ValidateUniversityAsync(University university, CancellationToken cancellationToken)
        {
            await ValidateUniversityNameExistsAsync(university.Name, cancellationToken);
            await ValidateUniversityAbbreviationExistsAsync(university.Abbreviation, cancellationToken);
            await ValidateRectorExistsAsync(university.RectorId, cancellationToken);
        }
    }
}
