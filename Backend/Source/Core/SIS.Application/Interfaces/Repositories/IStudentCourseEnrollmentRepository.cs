using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for the Student Course Enrollment repository.
    /// </summary>
    public interface IStudentCourseEnrollmentRepository
    {
        //// API Methods

        /// <summary>
        /// Retrieves all Student Course Enrollments.
        /// </summary>
        /// <param name="stdProgId">The unique identifier of the Student Program.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>A list of the Student's Course Enrollments.</returns>
        Task<IEnumerable<StudentCourseEnrollment>> GetStudentsAllCourseEnrollments(int stdProgId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves all Student Course Enrollments for a specific course instance.
        /// </summary>
        /// <param name="courseInstanceId">The unique identifier of the Course Instance.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>A list of the Student's Course Enrollments.</returns>
        Task<IEnumerable<StudentCourseEnrollment>> GetCoursesAllStudentEnrollments(int courseInstanceId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a Student Course Enrollment by its unique identifier.
        /// </summary>
        /// <param name="id">The enrollment's unique identifier.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>Student Course Enrollment if found; otherwise, null.</returns>
        Task<StudentCourseEnrollment?> GetStudentCourseEnrollmentByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new Student Course Enrollment to the database.
        /// </summary>
        /// <param name="studentCourseEnrollment"> The Student Course Enrollment to be added.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>The created Student Course Enrollment.</returns>
        Task<StudentCourseEnrollment> CreateStudentCourseEnrollmentAsync(StudentCourseEnrollment studentCourseEnrollment, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing Student Course Enrollment in the database.
        /// </summary>
        /// <param name="studentCourseEnrollment">The Student Course Enrollment to be updated.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task UpdateStudentCourseEnrollmentAsync(StudentCourseEnrollment studentCourseEnrollment, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a Student Course Enrollment from the database.
        /// </summary>
        /// <param name="studentCourseEnrollment">The Student Course Enrollment to be deleted.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        Task DeleteStudentCourseEnrollmentAsync(StudentCourseEnrollment studentCourseEnrollment, CancellationToken cancellationToken);

        //// Validation methods

        /// <summary>
        /// Checks if a Student Course Enrollment with the specified unique identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier of the Student Course Enrollment.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the enrollment exists; otherwise, false.</returns>
        Task<bool> StudentCourseEnrollmentExistsByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a Student Course Enrollment with the specified user ID exists.
        /// </summary>
        /// <param name="stdProgId">The unique identifier of the Student Program.</param>
        /// <param name="courseInstanceId">The unique identifier of the Course Instance.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>True if the enrollment exists; otherwise, false.</returns>
        Task<bool> StudentCourseEnrollmentExistsAsync(int stdProgId, int courseInstanceId, CancellationToken cancellationToken);
    }
}
