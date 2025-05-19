using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for the program semester repository.
    /// </summary>
    public interface IProgramSemesterRepository
    {
        /// <summary>
        /// Retrieves all program semesters associated with a specific program.
        /// </summary>
        /// <param name="progId">The unique identifier for the program.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>List of program semesters.</returns>
        Task<IEnumerable<ProgramSemester>> GetProgramsAllSemesters(int progId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves all program semesters associated with a specific semester.
        /// </summary>
        /// <param name="semId">The unique identifier for the semester.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>List of program semesters.</returns>
        Task<IEnumerable<ProgramSemester>> GetSemestersAllPrograms(int semId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a program semester by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the program semester.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>The program semester if found; otherwise, null.</returns>
        Task<ProgramSemester?> GetProgramSemesterByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves the department ID associated with a program semester by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the program semester.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>Department ID if found; otherwise, null.</returns>
        Task<int?> GetDepIdOfProgramSemester(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new program semester in the database.
        /// </summary>
        /// <param name="programSemester">The program semester to be created.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>The created program semester.</returns>
        Task<ProgramSemester> CreateProgramSemesterAsync(ProgramSemester programSemester, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing program semester in the database.
        /// </summary>
        /// <param name="programSemester">The program semester to be updated.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task UpdateProgramSemesterAsync(ProgramSemester programSemester, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a program semester from the database.
        /// </summary>
        /// <param name="programSemester">The program semester to be deleted.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task DeleteProgramSemesterAsync(ProgramSemester programSemester, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a program semester with the specified unique identifier exists.
        /// </summary>
        /// <param name="progId">The unique identifier for the program.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the program semester exists; otherwise, false.</returns>
        Task<bool> ProgramSemesterExistsByIdAsync(int progId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a program semester with the specified program ID and semester ID exists.
        /// </summary>
        /// <param name="progId">The unique identifier for the program.</param>
        /// <param name="semId">The unique identifier for the semester.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the program semester exists; otherwise, false.</returns>
        Task<bool> ProgramSemesterExistsAsync(int progId, int semId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a program semester with the specified unique program ID, and semester ID exists, excluding the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier for the program semester to exclude.</param>
        /// <param name="progId">The unique identifier for the program.</param>
        /// <param name="semId">The unique identifier for the semester.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the program semester exists; otherwise, false.</returns>
        Task<bool> ProgramSemesterExistsAsync(int id, int progId, int semId, CancellationToken cancellationToken);
    }
}
