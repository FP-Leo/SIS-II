using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Application.Interfaces.Repositories;
using SIS.Common;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Context;

namespace SIS.Persistence.Repositories
{
    /// <summary>
    /// Provides repository operations for managing <see cref="ProgramSemester"/> entities in the database.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="logger">The logger for logging operations.</param>
    public class ProgramSemesterRepository(ApplicationDbContext context, ILogger<ProgramSemesterRepository> logger): IProgramSemesterRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ILogger<ProgramSemesterRepository> _logger = logger;

        /// <inheritdoc/>
        public async Task<bool> ProgramSemesterExistsAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(ProgramSemester));
            return await _context.ProgramSemesters.AnyAsync(x => x.Id == id, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProgramSemester>> GetAllProgramSemestersAsync(CancellationToken cancellationToken)
        {
            return await _context.ProgramSemesters
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ProgramSemester?> GetProgramSemesterByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(ProgramSemester));

            return await _context.ProgramSemesters.FindAsync([id], cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ProgramSemester> CreateProgramSemesterAsync(ProgramSemester programSemester, CancellationToken cancellationToken)
        {
            _context.ProgramSemesters.Add(programSemester);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Create", nameof(ProgramSemester), _logger);

            return programSemester;
        }

        /// <inheritdoc/>
        public async Task DeleteProgramSemesterAsync(ProgramSemester programSemester, CancellationToken cancellationToken)
        {
            _context.ProgramSemesters.Remove(programSemester);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Delete", nameof(ProgramSemester), _logger);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProgramSemester>> GetProgramsAllSemesters(int progId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(progId, nameof(ProgramSemester));

            return await _context.ProgramSemesters
                .Where(x => x.ProgramId == progId)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProgramSemester>> GetSemestersAllPrograms(int semId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(semId, nameof(ProgramSemester));

            return await _context.ProgramSemesters
                .Where(x => x.SemesterId == semId)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task UpdateProgramSemesterAsync(ProgramSemester programSemester, CancellationToken cancellationToken)
        {
            _context.ProgramSemesters.Update(programSemester);
            int result = await _context.SaveChangesAsync(cancellationToken);

            CommonUtils.EnsureDbSaveSucceeded(result, "Update", nameof(ProgramSemester), _logger);
        }

        /// <inheritdoc/>
        public Task<bool> ProgramSemesterExistsByIdAsync(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(ProgramSemester));
            return _context.ProgramSemesters.AnyAsync(x => x.Id == id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<bool> ProgramSemesterExistsAsync(int progId, int semId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(progId, nameof(ProgramSemester));
            CommonUtils.EnsureIdIsValid(semId, nameof(ProgramSemester));

            return _context.ProgramSemesters.AnyAsync(x => x.ProgramId == progId && x.SemesterId == semId, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<bool> ProgramSemesterExistsAsync(int id, int progId, int semId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(ProgramSemester));
            CommonUtils.EnsureIdIsValid(progId, nameof(ProgramSemester));
            CommonUtils.EnsureIdIsValid(semId, nameof(ProgramSemester));

            return _context.ProgramSemesters.AnyAsync(x => x.Id != id && x.ProgramId == progId && x.SemesterId == semId, cancellationToken);
        }

        public async Task<int?> GetDepIdOfProgramSemester(int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, nameof(ProgramSemester));

            return await _context.ProgramSemesters
                .Where(x => x.Id == id && x.Program != null)
                .Select(x => x.Program!.DepartmentId)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
