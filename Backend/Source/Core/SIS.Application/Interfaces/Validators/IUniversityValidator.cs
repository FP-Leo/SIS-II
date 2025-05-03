using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Validators
{
    public interface IUniversityValidator
    {
        Task<bool> BeUniqueUniversityNameAsync(string universityName, CancellationToken cancellationToken);
        Task<bool> BeUniqueUniversityAbbreviationAsync(string universityAbbreviation, CancellationToken cancellationToken);
        Task<bool> BeValidRectorAsync(string rectorId, CancellationToken cancellationToken);
    }
}
