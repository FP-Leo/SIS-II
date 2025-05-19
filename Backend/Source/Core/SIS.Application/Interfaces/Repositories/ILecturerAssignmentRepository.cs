using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for the lecturer assignment repository.
    /// </summary>
    public interface ILecturerAssignmentRepository
    {
        /// <summary>
        /// Retrieves all lecturer assignments for a specific lecturer.
        /// </summary>
        /// <param name="lecturerId">The unique identifier of the lecturer.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>List of lecturer assignments for the specified lecturer.</returns>
        Task<IEnumerable<LecturerAssignment>> GetAllLecturerAssignmentsAsync(int lecturerId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves all active lecturer assignments for a specific lecturer.
        /// </summary>
        /// <param name="lecturerId">The unique identifier of the lecturer.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>List of active lecturer assignments for the specified lecturer.</returns>
        Task<IEnumerable<LecturerAssignment>> GetLecturersActiveAssignmentsAsync(int lecturerId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves all lecturer assignments for a specific department.
        /// </summary>
        /// <param name="depId">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>List of lecturer assignments for the specified department.</returns>
        Task<IEnumerable<LecturerAssignment>> GetDepsAllLecturerAssignmentsAsync(int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves all active lecturer assignments for a specific department.
        /// </summary>
        /// <param name="depId">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>The list of active lecturer assignments for the specified department.</returns>
        Task<IEnumerable<LecturerAssignment>> GetDepsAllActiveLecturerAssignmentsAsync(int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a specific active lecturer assignment by its unique identifier.
        /// </summary>
        /// <param name="lecId">The unique identifier of the lecturer.</param>
        /// <param name="depId">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>Lecturer assignment if found; otherwise, null.</returns>
        Task<LecturerAssignment?> GetActiveLecturerAssignmentsInDepAsync(int lecId, int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new lecturer assignment in the database.
        /// </summary>
        /// <param name="lecturerAssignment">The lecturer assignment to be created.</param>
        /// <param name="cancellationToken"><Token to cancel operations.</param>
        /// <returns>Lecturer assignment if created successfully; otherwise, null.</returns>
        Task<LecturerAssignment> CreateLecturerAssignmentAsync(LecturerAssignment lecturerAssignment, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing lecturer assignment in the database.
        /// </summary>
        /// <param name="lecturerAssignment">The lecturer assignment to be updated.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task UpdateLecturerAssignmentAsync(LecturerAssignment lecturerAssignment, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a lecturer assignment from the database.
        /// </summary>
        /// <param name="lecturerAssignment">Lecturer assignment to be deleted.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task DeleteLecturerAssignmentAsync(LecturerAssignment lecturerAssignment, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a lecturer assignment with the specified unique identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier of the lecturer assignment.</param>
        /// <param name="departmentId">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the lecturer assignment exists; otherwise, false.</returns>
        Task<bool> ActiveLecturerAssignmentExistsAsync(int id, int departmentId, CancellationToken cancellationToken);
    }
}
