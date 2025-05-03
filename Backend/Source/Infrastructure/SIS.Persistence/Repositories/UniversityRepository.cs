using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Common;
using SIS.Common.Extensions;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Common;
using SIS.Domain.Exceptions.Database;
using SIS.Application.Interfaces.Repositories;
using SIS.Infrastructure.Constants;
using SIS.Persistence.Databases.Context;
using System.Threading;

namespace SIS.Persistence.Repositories
{
    public class UniversityRepository(ApplicationDbContext context, ILogger<UniversityRepository> logger) : IUniversityRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ILogger<UniversityRepository> _logger = logger;

        public async Task<IEnumerable<University>> GetAllUniversitiesAsync(CancellationToken cancellationToken)
        {
            var universities = await _context.Universities.ToListAsync(cancellationToken);
            return universities;
        }

        public async Task<University?> GetUniversityByIdAsync(int Id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(Id, nameof(University));

            University? university = await _context.Universities.FindAsync([Id], cancellationToken);

            _logger.LogFoundOrNot(university, nameof(University.Id), Id);

            return university;
        }

        public async Task<University> CreateUniversityAsync(University university, CancellationToken cancellationToken)
        {
            await _context.Universities.AddAsync(university, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Create", university.Name, _logger);
            return university;
        }

        public async Task UpdateUniversityAsync(University university, CancellationToken cancellationToken)
        {
            _context.Universities.Update(university);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Update", university.Name, _logger);
        }

        public async Task DeleteUniversityByIdAsync(University university, CancellationToken cancellationToken)
        {
            _context.Universities.Remove(university);

            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Delete", university.Name, _logger);
        }

        public async Task<bool> UniversityExistsByNameAsync(string name, CancellationToken cancellationToken)
        {
            var exists = await _context.Universities.AnyAsync(u => u.Name == name, cancellationToken);
            return exists;
        }

        public async Task<bool> UniversityExistsByAbbreviationAsync(string abbreviation, CancellationToken cancellationToken)
        {
            var exists = await _context.Universities.AnyAsync(u => u.Abbreviation == abbreviation, cancellationToken);
            return exists;
        }

        public async Task<bool> RectorExistsAsync(string rectorId, CancellationToken cancellationToken)
        {
            var exists = await _context.Universities.AnyAsync(u => u.RectorId == rectorId, cancellationToken);
            return exists;
        }
    }
}