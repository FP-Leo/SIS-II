using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Application.Interfaces.Repositories;
using SIS.Common;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Context;

namespace SIS.Persistence.Repositories
{
    /// <summary>
    /// Provides repository operations for managing <see cref="AdministratorProfile"/> entities in the database.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="logger">Logger for logging operations.</param>
    public class AdministratorProfileRepository(ApplicationDbContext context, ILogger<AdministratorProfileRepository> logger) : IAdministratorProfileRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ILogger<AdministratorProfileRepository> _logger = logger;

        /// <inheritdoc/>
        public async Task<AdministratorProfile?> GetAdministratorProfileByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(AdministratorProfile));

            AdministratorProfile? profile = await _context.AdministratorProfiles.FindAsync( [id] , cancellationToken);

            return profile;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AdministratorProfile>> GetAllAdministratorProfiles(CancellationToken cancellationToken)
        {
            List<AdministratorProfile> profiles = await _context.AdministratorProfiles.ToListAsync(cancellationToken);
            return profiles;
        }

        /// <inheritdoc/>
        public async Task<AdministratorProfile> CreateAdministratorProfileAsync(AdministratorProfile admin, CancellationToken cancellationToken)
        {
            await _context.AdministratorProfiles.AddAsync(admin, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Create", nameof(AdministratorProfile), _logger);

            return admin;
        }

        /// <inheritdoc/>
        public async Task UpdateAdministratorProfileAsync(AdministratorProfile admin, CancellationToken cancellationToken)
        {
            _context.AdministratorProfiles.Update(admin);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Update", nameof(AdministratorProfile), _logger);
        }

        /// <inheritdoc/>
        public async Task DeleteAdministratorProfileAsync(AdministratorProfile admin, CancellationToken cancellationToken)
        {
            _context.AdministratorProfiles.Remove(admin);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Delete", nameof(AdministratorProfile), _logger);
        }

        /// <inheritdoc/>
        public async Task<bool> ProfileExistsAsync(int profileId, int depId, CancellationToken cancellationToken)
        {
            bool exists = await _context.AdministratorProfiles.AnyAsync(p => p.Id == profileId && p.DepartmentId == depId, cancellationToken);
            return exists;
        }

        /// <inheritdoc/>
        public async Task<bool> ProfileExistsAsync(int departmentId, string userId, CancellationToken cancellationToken)
        {
            bool exists = await _context.AdministratorProfiles.AnyAsync(p => p.DepartmentId == departmentId && p.UserId == userId, cancellationToken);
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<bool> ProfileExistsByIdAsync(int id, CancellationToken cancellationToken)
        {
            bool exists = await _context.AdministratorProfiles.AnyAsync(p => p.Id == id, cancellationToken: cancellationToken);
            return exists;
        }
    }
}
