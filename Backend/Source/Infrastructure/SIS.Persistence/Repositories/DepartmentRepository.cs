
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Application.Interfaces.Repositories;
using SIS.Common;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Database;
using SIS.Persistence.Databases.Context;

namespace SIS.Persistence.Repositories
{
    /// <summary>
    /// Provides repository operations for managing <see cref="Department"/> entities in the database.
    /// </summary>
    public class DepartmentRepository(ApplicationDbContext context, ILogger<DepartmentRepository> logger) : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ILogger<DepartmentRepository> _logger = logger;

        /// <summary>
        /// Retrieves all Departments from the database asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A collection of all Departments.</returns>
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync(CancellationToken cancellationToken)
        {
            List<Department> Departments = await _context.Departments.ToListAsync(cancellationToken);
            return Departments;
        }

        /// <summary>
        /// Retrieves a Department by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the Department.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The Department if found; otherwise, null.</returns>
        public async Task<Department?> GetDepartmentByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(Department));

            Department? department = await _context.Departments.FindAsync([id], cancellationToken);

            return department;
        }

        /// <summary>
        /// Creates a new Department in the database asynchronously.
        /// </summary>
        /// <param name="department">The Department entity to create.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The created Department entity.</returns>
        public async Task<Department> CreateDepartmentAsync(Department department, CancellationToken cancellationToken)
        {
            await _context.Departments.AddAsync(department, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Create", department.Name, _logger);

            return department;
        }

        /// <summary>
        /// Updates an existing Department in the database asynchronously.
        /// </summary>
        /// <param name="department">The Department entity to update.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        public async Task UpdateDepartmentAsync(Department department, CancellationToken cancellationToken)
        {
            _context.Departments.Update(department);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Update", department.Name, _logger);
        }

        /// <summary>
        /// Deletes a Department from the database asynchronously.
        /// </summary>
        /// <param name="department">The Department entity to delete.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        public async Task DeleteDepartmentByIdAsync(Department department, CancellationToken cancellationToken)
        {
            _context.Departments.Remove(department);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Delete", department.Name, _logger);
        }

        /// <summary>
        /// Checks if a Department with the specified name exists in a university asynchronously.
        /// </summary>
        /// <param name="name">The name of the Department.</param>
        /// <param name="facultyId">The unique identifier of the faculty.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the Department exists; otherwise, false.</returns>
        public async Task<bool> DepartmentExistsInUniAsync(string name, int facultyId, CancellationToken cancellationToken)
        {
            var postFaculty = await _context.Faculties
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == facultyId, cancellationToken) ?? throw new EntityNotFoundException("Faculty entry with the specified Id not found.");
            
            bool exists = await _context.Departments
                .AsNoTracking()
                .AnyAsync(d =>
                    d.Name == name &&
                    _context.Faculties.Any(f => f.Id == d.FacultyId && f.UniversityId == postFaculty.UniversityId),
                    cancellationToken);

            return exists;
        }

        /// <summary>
        /// Checks if a Department with the specified code exists in a university asynchronously.
        /// </summary>
        /// <param name="code">The code of the Department.</param>
        /// <param name="facultyId">The unique identifier of the faculty.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the code exists; otherwise, false.</returns>
        public async Task<bool> CodeExistsInUniAsync(string code, int facultyId, CancellationToken cancellationToken)
        {
            var postFaculty = await _context.Faculties
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == facultyId, cancellationToken) ?? throw new EntityNotFoundException("Faculty entry with the specified Id not found.");

            bool exists = await _context.Departments
                .AsNoTracking()
                .AnyAsync(d =>
                    d.Code == code &&
                    _context.Faculties.Any(f => f.Id == d.FacultyId && f.UniversityId == postFaculty.UniversityId),
                    cancellationToken);

            return exists;
        }

        /// <summary>
        /// Checks if a Department with the specified ID exists asynchronously.
        /// </summary>
        /// <param name="DepartmentId">The unique identifier of the Department.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the Department exists; otherwise, false.</returns>
        public async Task<bool> DepartmentExistsByIdAsync(int DepartmentId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(DepartmentId, nameof(Department));

            bool exists = await _context.Departments.AnyAsync(f => f.Id == DepartmentId, cancellationToken);

            return exists;
        }

        /// <summary>
        /// Checks if a Department with the specified dean ID exists asynchronously.
        /// </summary>
        /// <param name="hodId">The unique identifier of the dean.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the dean ID exists; otherwise, false.</returns>
        public async Task<bool> DepartmentExistsByHodIdAsync(string hodId, CancellationToken cancellationToken)
        {
            bool exists = await _context.Departments.AnyAsync(f => f.HeadOfDepartmentId == hodId, cancellationToken);
            return exists;
        }

        /// <summary>
        /// Checks if a Department with the specified phone number exists asynchronously.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the Department.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the phone number exists; otherwise, false.</returns>
        public async Task<bool> DepartmentExistsByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken)
        {
            bool exists = await _context.Departments.AnyAsync(f => f.PhoneNumber == phoneNumber, cancellationToken);
            return exists;
        }
    }
}
