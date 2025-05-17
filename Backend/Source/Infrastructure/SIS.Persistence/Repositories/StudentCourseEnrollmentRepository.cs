using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Application.Interfaces.Repositories;
using SIS.Common;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Context;

namespace SIS.Persistence.Repositories
{
    /// <summary>
    /// Provides repository operations for managing <see cref="StudentCourseEnrollment"/> entities in the database.
    /// </summary>
    /// <param name="context"> The database context.</param>
    /// <param name="logger"> Logger for logging operations.</param>
    public class StudentCourseEnrollmentRepository(ApplicationDbContext context, ILogger<StudentCourseEnrollmentRepository> logger): IStudentCourseEnrollmentRepository
    {
        private readonly ApplicationDbContext _dbContext = context;
        private readonly ILogger<StudentCourseEnrollmentRepository> _logger = logger;

        /// <inheritdoc/>
        public async Task<IEnumerable<StudentCourseEnrollment>> GetCoursesAllStudentEnrollments(int courseInstanceId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(courseInstanceId, nameof(StudentCourseEnrollment));

            List<StudentCourseEnrollment> enrollments = await _dbContext.StudentCourseEnrollments
                .Where(e => e.CourseInstanceId == courseInstanceId)
                .ToListAsync(cancellationToken);
            return enrollments;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<StudentCourseEnrollment>> GetStudentsAllCourseEnrollments(int stdProgId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(stdProgId, nameof(StudentCourseEnrollment));

            List<StudentCourseEnrollment> enrollments = await _dbContext.StudentCourseEnrollments
                .Where(e => e.ProgramEnrollmentId == stdProgId)
                .ToListAsync(cancellationToken);
            return enrollments;
        }

        /// <inheritdoc/>
        public async Task<StudentCourseEnrollment?> GetStudentCourseEnrollmentByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(StudentCourseEnrollment));

            StudentCourseEnrollment? enrollment = await _dbContext.StudentCourseEnrollments.FindAsync([id], cancellationToken);

            return enrollment;
        }

        /// <inheritdoc/>
        public async Task<StudentCourseEnrollment> CreateStudentCourseEnrollmentAsync(StudentCourseEnrollment studentCourseEnrollment, CancellationToken cancellationToken)
        {
            await _dbContext.StudentCourseEnrollments.AddAsync(studentCourseEnrollment, cancellationToken);
            int result = await _dbContext.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Create", nameof(StudentCourseEnrollment), _logger);

            return studentCourseEnrollment;
        }

        /// <inheritdoc/>
        public async Task UpdateStudentCourseEnrollmentAsync(StudentCourseEnrollment studentCourseEnrollment, CancellationToken cancellationToken)
        {
            _dbContext.StudentCourseEnrollments.Update(studentCourseEnrollment);
            int result = await _dbContext.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Update", nameof(StudentCourseEnrollment), _logger);
        }

        /// <inheritdoc/>
        public async Task DeleteStudentCourseEnrollmentAsync(StudentCourseEnrollment studentCourseEnrollment, CancellationToken cancellationToken)
        {
            _dbContext.StudentCourseEnrollments.Remove(studentCourseEnrollment);
            int result = await _dbContext.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Delete", nameof(StudentCourseEnrollment), _logger);
        }

        /// <inheritdoc/>
        public Task<bool> StudentCourseEnrollmentExistsByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(StudentCourseEnrollment));

            return _dbContext.StudentCourseEnrollments.AnyAsync(e => e.Id == id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<bool> StudentCourseEnrollmentExistsAsync(int stdProgId, int courseInstanceId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(stdProgId, nameof(StudentCourseEnrollment));
            CommonUtils.EnsureIdIsValid(courseInstanceId, nameof(StudentCourseEnrollment));

            return _dbContext.StudentCourseEnrollments.AnyAsync(e => e.ProgramEnrollmentId == stdProgId && e.CourseInstanceId == courseInstanceId, cancellationToken);
        }
    }
}
