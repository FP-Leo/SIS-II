using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface IUniversityRepository
    {
        Task<IEnumerable<University>> GetAllUniversitiesAsync(CancellationToken cancellationToken);
        Task<University?> GetUniversityByIdAsync(int id, CancellationToken cancellationToken);
        Task<University> CreateUniversityAsync(University university, CancellationToken cancellationToken);
        Task UpdateUniversityAsync(University university, CancellationToken cancellationToken);
        Task DeleteUniversityByIdAsync(University university, CancellationToken cancellationToken);
        Task<bool> UniversityExistsByNameAsync(string name, CancellationToken cancellationToken);
        Task<bool> UniversityExistsByAbbreviationAsync(string abbreviation, CancellationToken cancellationToken);
        Task<bool> RectorExistsAsync(string rectorId, CancellationToken cancellationToken);
    }
}