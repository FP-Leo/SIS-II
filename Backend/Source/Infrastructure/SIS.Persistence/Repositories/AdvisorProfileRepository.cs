using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Application.Interfaces.Repositories;
using SIS.Common;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Context;

namespace SIS.Persistence.Repositories
{
    /// <summary>
    /// Provides repository operations for managing <see cref="AdvisorProfile"/> entities in the database.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="logger">Logger for logging operations.</param>
    public class AdvisorProfileRepository(ApplicationDbContext context, ILogger<AdvisorProfileRepository> logger) : IAdvisorProfileRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ILogger<AdvisorProfileRepository> _logger = logger;

        /// <inheritdoc/>
        public async Task<AdvisorProfile?> GetAdvisorProfileByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(AdvisorProfile));

            AdvisorProfile? profile = await _context.AdvisorProfiles.FindAsync( [id] , cancellationToken);

            return profile;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AdvisorProfile>> GetAllAdvisorProfiles(CancellationToken cancellationToken)
        {
            List<AdvisorProfile> profiles = await _context.AdvisorProfiles.ToListAsync(cancellationToken);
            return profiles;
        }

        /// <inheritdoc/>
        public async Task<AdvisorProfile> CreateAdvisorProfileAsync(AdvisorProfile admin, CancellationToken cancellationToken)
        {
            await _context.AdvisorProfiles.AddAsync(admin, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Create", nameof(AdvisorProfile), _logger);

            return admin;
        }

        /// <inheritdoc/>
        public async Task UpdateAdvisorProfileAsync(AdvisorProfile admin, CancellationToken cancellationToken)
        {
            _context.AdvisorProfiles.Update(admin);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Update", nameof(AdvisorProfile), _logger);
        }

        /// <inheritdoc/>
        public async Task DeleteAdvisorProfileAsync(AdvisorProfile admin, CancellationToken cancellationToken)
        {
            _context.AdvisorProfiles.Remove(admin);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Delete", nameof(AdvisorProfile), _logger);
        }

        /// <inheritdoc/>
        public async Task<bool> ProfileExistsAsync(int profileId, int depId, CancellationToken cancellationToken)
        {
            bool exists = await _context.AdvisorProfiles.AnyAsync(p => p.Id == profileId && p.DepartmentId == depId, cancellationToken);
            return exists;
        }

        /// <inheritdoc/>
        public async Task<bool> ProfileExistsAsync(int departmentId, string userId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureGUIDIsValid(userId, nameof(User), _logger);

            bool exists = await _context.AdvisorProfiles.AnyAsync(p => p.DepartmentId == departmentId && p.UserId == userId, cancellationToken);
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<bool> ProfileExistsByIdAsync(int id, CancellationToken cancellationToken)
        {
            bool exists = await _context.AdvisorProfiles.AnyAsync(p => p.Id == id, cancellationToken: cancellationToken);
            return exists;
        }
    }
}
