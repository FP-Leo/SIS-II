using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for the Student Program Enrollment repository.
    /// </summary>
    public interface IStudentProgramEnrollmentRepository
    {
        //// API Methods

        /// <summary>
        /// Retrieves all Student Program Enrollments.
        /// </summary>
        /// <param name="studentProfileId">The unique identifier of the Student profile.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>List of Student Program Enrollments.</returns>
        Task<IEnumerable<StudentProgramEnrollment>> GetAllStudentProgramEnrollments(int studentProfileId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a Student Program Enrollment by its unique identifier.
        /// </summary>
        /// <param name="id">The Program Enrollment's unique identifier.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>Student Program Enrollment if found; otherwise, null.</returns>
        Task<StudentProgramEnrollment?> GetStudentProgramEnrollmentByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new Student Program Enrollment to the database.
        /// </summary>
        /// <param name="Student">The Student Program Enrollment to be added.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>The created Student Program Enrollment.</returns>
        Task<StudentProgramEnrollment> CreateStudentProgramEnrollmentAsync(StudentProgramEnrollment Student, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing Student Program Enrollment in the database.
        /// </summary>
        /// <param name="Student">The Student Program Enrollment to be updated.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task UpdateStudentProgramEnrollmentAsync(StudentProgramEnrollment Student, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a Student Program Enrollment from the database.
        /// </summary>
        /// <param name="Student">The Student Program Enrollment to be deleted.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task DeleteStudentProgramEnrollmentAsync(StudentProgramEnrollment Student, CancellationToken cancellationToken);

        //// Validation methods
        /// <summary>
        /// Checks if a Student Program Enrollment with the specified unique identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier of the Student Program Enrollment.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the Program Enrollment exists; otherwise, false.</returns>
        Task<bool> ProgramEnrollmentExistsByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a Student Program Enrollment with the specified user ID exists.
        /// </summary>
        /// <param name="profileId">The Profile Id of the Student to check.</param>
        /// <param name="programId">The unique identifier of the Program to check.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the Program Enrollment exists; otherwise, false.</returns>
        Task<bool> ProgramEnrollmentExistsAsync(int profileId, int programId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a Student Program Enrollment with the specified user ID exists.
        /// </summary>
        /// <param name="id"> The unique identifier of the Student Program Enrollment to ignore.</param>
        /// <param name="profileId">The Profile Id of the Student to check.</param>
        /// <param name="programId">The unique identifier of the Program to check.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the Program Enrollment exists; otherwise, false.</returns>
        Task<bool> ProgramEnrollmentExistsAsync(int id, int profileId, int programId, CancellationToken cancellationToken);
    }
}
