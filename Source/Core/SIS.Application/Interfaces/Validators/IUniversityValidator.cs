using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Validators
{
    public interface IUniversityValidator
    {
        Task ValidateUniversityNameExistsAsync(string universityName, CancellationToken cancellationToken);
        Task ValidateUniversityAbbreviationExistsAsync(string universityAbbreviation, CancellationToken cancellationToken);
        Task ValidateRectorExistsAsync(string rectorId, CancellationToken cancellationToken);
        Task ValidateUniversityAsync(University university, CancellationToken cancellationToken);
    }
}
