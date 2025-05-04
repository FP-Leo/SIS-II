using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Common;
using SIS.Common.Extensions;
using SIS.Domain.Entities;
using SIS.Application.Interfaces.Repositories;
using SIS.Persistence.Databases.Context;

namespace SIS.Persistence.Repositories
{
    /// <summary>
    /// Repository for managing university-related database operations.
    /// </summary>
    public class UniversityRepository(ApplicationDbContext context, ILogger<UniversityRepository> logger) : IUniversityRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ILogger<UniversityRepository> _logger = logger;

        /// <summary>
        /// Retrieves all universities.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>A collection of universities.</returns>
        public async Task<IEnumerable<University>> GetAllUniversitiesAsync(CancellationToken cancellationToken)
        {
            var universities = await _context.Universities.ToListAsync(cancellationToken);
            return universities;
        }

        /// <summary>
        /// Retrieves a university by its ID.
        /// </summary>
        /// <param name="Id">The ID of the university.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>The university with the specified ID, or null if not found.</returns>
        public async Task<University?> GetUniversityByIdAsync(int Id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(Id, nameof(University));

            University? university = await _context.Universities.FindAsync([Id], cancellationToken);

            return university;
        }

        /// <summary>
        /// Creates a new university.
        /// </summary>
        /// <param name="university">The university to create.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>The created university.</returns>
        public async Task<University> CreateUniversityAsync(University university, CancellationToken cancellationToken)
        {
            await _context.Universities.AddAsync(university, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Create", university.Name, _logger);
            return university;
        }

        /// <summary>
        /// Updates an existing university.
        /// </summary>
        /// <param name="university">The university to update.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        public async Task UpdateUniversityAsync(University university, CancellationToken cancellationToken)
        {
            _context.Universities.Update(university);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Update", university.Name, _logger);
        }

        /// <summary>
        /// Deletes a university by its ID.
        /// </summary>
        /// <param name="university">The university to delete.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        public async Task DeleteUniversityByIdAsync(University university, CancellationToken cancellationToken)
        {
            _context.Universities.Remove(university);

            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Delete", university.Name, _logger);
        }

        /// <summary>
        /// Checks if a university exists by its name.
        /// </summary>
        /// <param name="name">The name of the university.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>True if the university exists, otherwise false.</returns>
        public async Task<bool> UniversityExistsByNameAsync(string name, CancellationToken cancellationToken)
        {
            var exists = await _context.Universities.AnyAsync(u => u.Name == name, cancellationToken);
            return exists;
        }

        /// <summary>
        /// Checks if a university exists by its abbreviation.
        /// </summary>
        /// <param name="abbreviation">The abbreviation of the university.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>True if the university exists, otherwise false.</returns>
        public async Task<bool> UniversityExistsByAbbreviationAsync(string abbreviation, CancellationToken cancellationToken)
        {
            var exists = await _context.Universities.AnyAsync(u => u.Abbreviation == abbreviation, cancellationToken);
            return exists;
        }

        /// <summary>
        /// Checks if a rector exists by their ID.
        /// </summary>
        /// <param name="rectorId">The ID of the rector.</param>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>True if the rector exists, otherwise false.</returns>
        public async Task<bool> RectorExistsAsync(string rectorId, CancellationToken cancellationToken)
        {
            var exists = await _context.Universities.AnyAsync(u => u.RectorId == rectorId, cancellationToken);
            return exists;
        }
    }
}