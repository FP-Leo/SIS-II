using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for the Academic Program repository.
    /// </summary>
    public interface IAcademicProgramRepository
    {
        //// API Methods

        /// <summary>
        /// Retrieves all Academic Programs of department.
        /// </summary>
        /// <param name="depId">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>List of Academic Programs.</returns>
        Task<IEnumerable<AcademicProgram>> GetAllAcademicProgramsOfDepartmentAsync(int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a Academic Program by its unique identifier.
        /// </summary>
        /// <param name="id">The Academic Program's unique identifier.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>Academic Program if found; otherwise, null.</returns>
        Task<AcademicProgram?> GetAcademicProgramByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new Academic Program to the database.
        /// </summary>
        /// <param name="academicProgram">The Academic Program to be added.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>The created Academic Program.</returns>
        Task<AcademicProgram> CreateAcademicProgramAsync(AcademicProgram academicProgram, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing Academic Program in the database.
        /// </summary>
        /// <param name="academicProgram">The Academic Program to be updated.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task UpdateAcademicProgramAsync(AcademicProgram academicProgram, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a Academic Program from the database.
        /// </summary>
        /// <param name="Student">The Academic Program to be deleted.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task DeleteAcademicProgramAsync(AcademicProgram academicProgram, CancellationToken cancellationToken);

        //// Validation methods
        /// <summary>
        /// Checks if a Academic Program with the specified unique identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier of the Academic Program.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the Program Enrollment exists; otherwise, false.</returns>
        Task<bool> AcademicProgramExistsByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a Academic Program with the specified user ID exists.
        /// </summary>
        /// <param name="name">The name of the Academic Program to check.</param>
        /// <param name="depId"> The unique identifier of the department to check.</param>
        /// <returns>True if the Program Enrollment exists; otherwise, false.</returns>
        Task<bool> AcademicProgramExistsAsync(string name, int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a Academic Program with the specified user ID exists.
        /// </summary>
        /// <param name="id"> The unique identifier of the Academic Program to ignore.</param>
        /// <param name="name">The name of the Academic Program to check.</param>
        /// <param name="depId"> The unique identifier of the department to check.</param>
        /// <returns>True if the Program Enrollment exists; otherwise, false.</returns>
        Task<bool> AcademicProgramExistsAsync(int id, string name, int depId, CancellationToken cancellationToken);
    }
}
