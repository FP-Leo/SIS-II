using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Application.Interfaces.Repositories;
using SIS.Common;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Context;

namespace SIS.Persistence.Repositories
{
    /// <summary>
    /// Provides repository operations for managing <see cref="Faculty"/> entities in the database.
    /// </summary>
    public class FacultyRepository(ApplicationDbContext context, ILogger<FacultyRepository> logger) : IFacultyRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ILogger<FacultyRepository> _logger = logger;

        /// <summary>
        /// Retrieves all faculties from the database asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A collection of all faculties.</returns>
        public async Task<IEnumerable<Faculty>> GetAllFacultiesAsync(CancellationToken cancellationToken)
        {
            List<Faculty> faculties = await _context.Faculties.ToListAsync(cancellationToken);
            return faculties;
        }

        /// <summary>
        /// Retrieves a faculty by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the faculty.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The faculty if found; otherwise, null.</returns>
        public async Task<Faculty?> GetFacultyByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(Faculty));

            Faculty? faculty = await _context.Faculties.FindAsync([id], cancellationToken);

            return faculty;
        }

        /// <summary>
        /// Creates a new faculty in the database asynchronously.
        /// </summary>
        /// <param name="faculty">The faculty entity to create.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The created faculty entity.</returns>
        public async Task<Faculty> CreateFacultyAsync(Faculty faculty, CancellationToken cancellationToken)
        {
            await _context.Faculties.AddAsync(faculty, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Create", faculty.Name, _logger);

            return faculty;
        }

        /// <summary>
        /// Updates an existing faculty in the database asynchronously.
        /// </summary>
        /// <param name="faculty">The faculty entity to update.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        public async Task UpdateFacultyAsync(Faculty faculty, CancellationToken cancellationToken)
        {
            _context.Faculties.Update(faculty);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Update", faculty.Name, _logger);
        }

        /// <summary>
        /// Deletes a faculty from the database asynchronously.
        /// </summary>
        /// <param name="faculty">The faculty entity to delete.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        public async Task DeleteFacultyByIdAsync(Faculty faculty, CancellationToken cancellationToken)
        {
            _context.Faculties.Remove(faculty);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Delete", faculty.Name, _logger);
        }

        /// <summary>
        /// Checks if a faculty with the specified name exists in a university asynchronously.
        /// </summary>
        /// <param name="name">The name of the faculty.</param>
        /// <param name="uniId">The unique identifier of the university.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the faculty exists; otherwise, false.</returns>
        public async Task<bool> FacultyExistsInUniAsync(string name, int uniId, CancellationToken cancellationToken)
        {
            bool exists = await _context.Faculties.AnyAsync(f => f.Name == name && f.UniversityId == uniId, cancellationToken);
            return exists;
        }

        /// <summary>
        /// Checks if a faculty with the specified code exists in a university asynchronously.
        /// </summary>
        /// <param name="code">The code of the faculty.</param>
        /// <param name="uniId">The unique identifier of the university.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the code exists; otherwise, false.</returns>
        public async Task<bool> CodeExistsInUniAsync(string code, int uniId, CancellationToken cancellationToken)
        {
            bool exists = await _context.Faculties.AnyAsync(f => f.Code == code && f.UniversityId == uniId, cancellationToken);
            return exists;
        }

        /// <summary>
        /// Checks if a faculty with the specified ID exists asynchronously.
        /// </summary>
        /// <param name="facultyId">The unique identifier of the faculty.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the faculty exists; otherwise, false.</returns>
        public async Task<bool> FacultyExistsByIdAsync(int facultyId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(facultyId, nameof(Faculty));

            bool exists = await _context.Faculties.AnyAsync(f => f.Id == facultyId, cancellationToken);
            
            return exists;
        }

        /// <summary>
        /// Checks if a faculty with the specified dean ID exists asynchronously.
        /// </summary>
        /// <param name="deanId">The unique identifier of the dean.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the dean ID exists; otherwise, false.</returns>
        public async Task<bool> FacultyExistsByDeanIdAsync(string deanId, CancellationToken cancellationToken)
        {
            bool exists = await _context.Faculties.AnyAsync(f => f.DeanId == deanId, cancellationToken);
            return exists;
        }

        /// <summary>
        /// Checks if a faculty with the specified phone number exists asynchronously.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the faculty.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the phone number exists; otherwise, false.</returns>
        public async Task<bool> FacultyExistsByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken)
        {
            bool exists = await _context.Faculties.AnyAsync(f => f.PhoneNumber == phoneNumber, cancellationToken);
            return exists;
        }
    }
}
