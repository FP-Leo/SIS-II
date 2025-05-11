using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Application.Interfaces.Repositories;
using SIS.Common;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Context;

namespace SIS.Persistence.Repositories
{
    public class CourseRepository(ApplicationDbContext context, ILogger<CourseRepository> logger) : ICourseRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ILogger<CourseRepository> _logger = logger;

        /// <inheritdoc/>
        public async Task<IEnumerable<Course>> GetAllCoursesAsync(CancellationToken cancellationToken)
        {
            List<Course> courses = await _context.Courses.ToListAsync(cancellationToken);
            return courses;
        }

        /// <inheritdoc/>
        public async Task<Course?> GetCourseByIdAsync(int courseId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(courseId, nameof(Course));

            Course? course = await _context.Courses.FindAsync([courseId], cancellationToken);

            return course;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Course>> GetCoursesByDepartmentIdAsync(int departmentId, CancellationToken cancellationToken)
        {
            List<Course> courses = await _context.Courses.Where(c => c.DepartmentId == departmentId).ToListAsync(cancellationToken);
            return courses;
        }

        /// <inheritdoc/>
        public async Task<Course> CreateCourseAsync(Course course, CancellationToken cancellationToken)
        {
            await _context.Courses.AddAsync(course, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Create", nameof(Course), _logger);

            return course;
        }

        /// <inheritdoc/>
        public async Task UpdateCourseAsync(Course course, CancellationToken cancellationToken)
        {
            _context.Courses.Update(course);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Update", nameof(Course), _logger);
        }

        /// <inheritdoc/>
        public async Task DeleteCourseAsync(Course course, CancellationToken cancellationToken)
        {
            _context.Courses.Remove(course);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Delete", nameof(Course), _logger);
        }

        /// <inheritdoc/>
        public async Task<bool> CourseExistsByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(Course));

            bool exists = await _context.Courses.AnyAsync(c => c.Id == id, cancellationToken);

            return exists;
        }

        /// <inheritdoc/>
        public async Task<bool> CourseExistsAsync(string CourseName, int depId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(depId, nameof(Department));

            bool exists = await _context.Courses.AnyAsync(c => c.Name == CourseName && c.DepartmentId == depId, cancellationToken);

            return exists;
        }

        /// <inheritdoc/>
        public async Task<bool> CourseExistsInDepartmentAsync(int courseId, int depId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(courseId, nameof(Course));

            CommonUtils.EnsureIdIsValid(depId, nameof(Department));

            bool exists = await _context.Courses.AnyAsync(c => c.Id == courseId && c.DepartmentId == depId, cancellationToken);
            return exists;
        }
    }
}
