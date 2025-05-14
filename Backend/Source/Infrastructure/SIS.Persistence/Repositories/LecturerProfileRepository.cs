using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Application.Interfaces.Repositories;
using SIS.Common;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Context;

namespace SIS.Persistence.Repositories
{
    /// <summary>
    /// Provides repository operations for managing <see cref="LecturerProfile"/> entities in the database.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="logger">Logger for logging operations.</param>
    public class LecturerProfileRepository(ApplicationDbContext context, ILogger<LecturerProfileRepository> logger) : ILecturerProfileRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ILogger<LecturerProfileRepository> _logger = logger;

        /// <inheritdoc/>
        public async Task<LecturerProfile> CreateLecturerProfileAsync(LecturerProfile lecturer, CancellationToken cancellationToken)
        {
            await _context.LecturerProfiles.AddAsync(lecturer, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Create", nameof(LecturerProfile), _logger);

            return lecturer;
        }

        /// <inheritdoc/>
        public async Task DeleteLecturerProfileAsync(LecturerProfile lecturer, CancellationToken cancellationToken)
        {
            _context.LecturerProfiles.Remove(lecturer);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Delete", nameof(LecturerProfile), _logger);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LecturerProfile>> GetAllLecturerProfiles(CancellationToken cancellationToken)
        {
            List<LecturerProfile> profiles = await _context.LecturerProfiles.ToListAsync(cancellationToken);
            return profiles;
        }

        /// <inheritdoc/>
        public async Task<LecturerProfile?> GetLecturerProfileByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(LecturerProfile));

            LecturerProfile? profile = await _context.LecturerProfiles.FindAsync(id);

            return profile;
        }

        /// <inheritdoc/>
        public async Task<bool> ProfileExistsAsync(string userId, CancellationToken cancellationToken)
        {
            bool exists = await _context.LecturerProfiles.AnyAsync(p => p.UserId == userId, cancellationToken);
            return exists;
        }

        /// <inheritdoc/>
        public async Task<bool> ProfileExistsByIdAsync(int id, CancellationToken cancellationToken)
        {
            bool exists = await _context.LecturerProfiles.AnyAsync(p => p.Id == id, cancellationToken);
            return exists;
        }

        /// <inheritdoc/>
        public async Task UpdateLecturerProfileAsync(LecturerProfile lecturer, CancellationToken cancellationToken)
        {
            _context.LecturerProfiles.Update(lecturer);

            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Update", nameof(LecturerProfile), _logger);
        }
    }
}
