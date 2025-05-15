using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Application.Interfaces.Repositories;
using SIS.Common;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Context;

namespace SIS.Persistence.Repositories
{
    /// <summary>
    /// Provides repository operations for managing <see cref="StudentProfile"/> entities in the database.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="logger">Logger for logging operations.</param>
    public class StudentProfileRepository(ApplicationDbContext context, ILogger<StudentProfileRepository> logger) : IStudentProfileRepository
    {
        private readonly ApplicationDbContext _dbContext = context;
        private readonly ILogger<StudentProfileRepository> _logger = logger;

        /// <inheritdoc/>
        public async Task<StudentProfile> CreateStudentProfileAsync(StudentProfile student, CancellationToken cancellationToken)
        {
            await _dbContext.StudentProfiles.AddAsync(student, cancellationToken);
            int result = await _dbContext.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Create", nameof(StudentProfile), _logger);

            return student;
        }

        /// <inheritdoc/>
        public async Task UpdateStudentProfileAsync(StudentProfile Student, CancellationToken cancellationToken)
        {
            _dbContext.StudentProfiles.Update(Student);
            int result = await _dbContext.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Update", nameof(StudentProfile), _logger);
        }

        /// <inheritdoc/>
        public async Task DeleteStudentProfileAsync(StudentProfile student, CancellationToken cancellationToken)
        {
            _dbContext.StudentProfiles.Remove(student);
            int result = await _dbContext.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Delete", nameof(StudentProfile), _logger);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<StudentProfile>> GetAllStudentProfiles(CancellationToken cancellationToken)
        {
            List<StudentProfile> profiles = await _dbContext.StudentProfiles.ToListAsync(cancellationToken);
            return profiles;
        }

        /// <inheritdoc/>
        public async Task<StudentProfile?> GetStudentProfileByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(StudentProfile));

            StudentProfile? profile = await _dbContext.StudentProfiles.FindAsync([id], cancellationToken);

            return profile;
        }

        /// <inheritdoc/>
        public async Task<bool> ProfileExistsAsync(string userId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureGUIDIsValid(userId, nameof(userId), _logger);

            bool exists = await _dbContext.StudentProfiles.AnyAsync(p => p.UserId == userId, cancellationToken);
            return exists;
        }

        /// <inheritdoc/>
        public async Task<bool> ProfileExistsByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(StudentProfile));
            bool exists = await _dbContext.StudentProfiles.AnyAsync(p => p.Id == id, cancellationToken);
            return exists;
        }
    }
}
