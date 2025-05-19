using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Application.Interfaces.Repositories;
using SIS.Common;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Context;

namespace SIS.Persistence.Repositories
{
    /// <summary>
    /// Provides repository operations for managing <see cref="CourseInstance"/> entities in the database.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="logger">The logger for logging operations.</param>
    public class CourseInstanceRepository(ApplicationDbContext context, ILogger<CourseInstanceRepository> logger) : ICourseInstanceRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ILogger<CourseInstanceRepository> _logger = logger;

        /// <inheritdoc/>
        public Task<bool> CourseInstanceExistsByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(CourseInstance));
            return _context.CourseInstances.AnyAsync(ci => ci.Id == id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<bool> CourseInstanceExistsAsync(int courseId, int semesterId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(courseId, nameof(Course));
            CommonUtils.EnsureIdIsValid(semesterId, nameof(AcademicSemester));

            return _context.CourseInstances.AnyAsync(ci => ci.CourseId == courseId && ci.ProgramSemesterId == semesterId, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<CourseInstance> CreateCourseInstanceAsync(CourseInstance courseInstance, CancellationToken cancellationToken)
        {
            await _context.CourseInstances.AddAsync(courseInstance, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Create", nameof(CourseInstance), _logger);

            return courseInstance;
        }

        /// <inheritdoc/>
        public async Task DeleteCourseInstanceAsync(CourseInstance courseInstance, CancellationToken cancellationToken)
        {
            _context.CourseInstances.Remove(courseInstance);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Delete", nameof(CourseInstance), _logger);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CourseInstance>> GetAllCourseInstancesOfSemesterAsync(int semesterId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(semesterId, nameof(AcademicSemester));
            return await _context.CourseInstances
                .Where(ci => ci.ProgramSemesterId == semesterId)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CourseInstance>> GetAllInstancesOfCourseAsync(int courseId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(courseId, nameof(Course));
            return await _context.CourseInstances
                .Where(ci => ci.CourseId == courseId)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<CourseInstance?> GetCourseInstanceByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(CourseInstance));

            return await _context.CourseInstances.FindAsync([id], cancellationToken);
        }

        /// <inheritdoc/>
        public async Task UpdateCourseInstanceAsync(CourseInstance courseInstance, CancellationToken cancellationToken)
        {
            _context.CourseInstances.Update(courseInstance);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Update", nameof(CourseInstance), _logger);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CourseInstance>> GetLecturersAllCourseInstancesAsync(int lecProfileId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(lecProfileId, nameof(LecturerAssignment));

            return await _context.CourseInstances
                .Where(ci => ci.LecturerAssignmentId == lecProfileId)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CourseInstance>> GetLecturersAllCourseInstancesAsync(int lecProfileId, int progSemesterId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(lecProfileId, nameof(LecturerAssignment));

            return await _context.CourseInstances
                .Where(ci => ci.LecturerAssignmentId == lecProfileId && ci.ProgramSemesterId == progSemesterId)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<int?> GetDepIdOfCourseInstance(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(CourseInstance));
            return await _context.CourseInstances
                .Where(ci => ci.Id == id && ci.Course != null) // Ensure `Course` is not null
                .Select(ci => ci.Course!.DepartmentId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<bool> CourseInstanceExistsAsync(int instanceId, int courseId, int progSemesterId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(instanceId, nameof(CourseInstance));

            return _context.CourseInstances.AnyAsync(ci => ci.Id != instanceId && ci.CourseId == courseId && ci.ProgramSemesterId == progSemesterId, cancellationToken);
        }
    }
}
