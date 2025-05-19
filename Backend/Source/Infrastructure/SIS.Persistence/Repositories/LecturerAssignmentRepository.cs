using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Application.Interfaces.Repositories;
using SIS.Common;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Context;

namespace SIS.Persistence.Repositories
{
    /// <summary>
    /// Provides repository operations for managing <see cref="LecturerAssignment"/> entities in the database.
    /// </summary>
    /// <param name="context"> The database context.</param>
    /// <param name="logger"> Logger for logging operations.</param>
    public class LecturerAssignmentRepository(ApplicationDbContext context, ILogger<LecturerAssignmentRepository> logger) : ILecturerAssignmentRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ILogger<LecturerAssignmentRepository> _logger = logger;

        /// <inheritdoc/>
        public async Task<bool> ActiveLecturerAssignmentExistsAsync(int id, int departmentId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(LecturerAssignment));
            CommonUtils.EnsureIdIsValid(departmentId, nameof(Department));

            return await _context.LecturerAssignments
                .AnyAsync(x => x.Id == id && x.DepartmentId == departmentId && x.EndDate == null, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<LecturerAssignment> CreateLecturerAssignmentAsync(LecturerAssignment lecturerAssignment, CancellationToken cancellationToken)
        {
            await _context.LecturerAssignments.AddAsync(lecturerAssignment, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Create", nameof(LecturerAssignment), _logger);

            return lecturerAssignment;
        }

        /// <inheritdoc/>
        public async Task DeleteLecturerAssignmentAsync(LecturerAssignment lecturerAssignment, CancellationToken cancellationToken)
        {
            _context.LecturerAssignments.Remove(lecturerAssignment);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Delete", nameof(LecturerAssignment), _logger);
        }

        /// <inheritdoc/>
        public Task<LecturerAssignment?> GetActiveLecturerAssignmentsInDepAsync(int lecId, int depId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(lecId, nameof(LecturerAssignment));
            CommonUtils.EnsureIdIsValid(depId, nameof(Department));
            return _context.LecturerAssignments
                .FirstOrDefaultAsync(x => x.LecturerProfileId == lecId && x.DepartmentId == depId && x.EndDate == null, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LecturerAssignment>> GetAllLecturerAssignmentsAsync(int lecturerId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(lecturerId, nameof(LecturerAssignment));
            return await _context.LecturerAssignments
                .Where(x => x.LecturerProfileId == lecturerId)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LecturerAssignment>> GetDepsAllActiveLecturerAssignmentsAsync(int depId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(depId, nameof(Department));
            return await _context.LecturerAssignments
                .Where(x => x.DepartmentId == depId && x.EndDate == null)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LecturerAssignment>> GetDepsAllLecturerAssignmentsAsync(int depId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(depId, nameof(Department));
            return await _context.LecturerAssignments
                .Where(x => x.DepartmentId == depId)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LecturerAssignment>> GetLecturersActiveAssignmentsAsync(int lecturerId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(lecturerId, nameof(LecturerAssignment));
            return await _context.LecturerAssignments
                .Where(x => x.LecturerProfileId == lecturerId && x.EndDate == null)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task UpdateLecturerAssignmentAsync(LecturerAssignment lecturerAssignment, CancellationToken cancellationToken)
        {
            _context.LecturerAssignments.Update(lecturerAssignment);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Update", nameof(LecturerAssignment), _logger);
        }
    }
}
