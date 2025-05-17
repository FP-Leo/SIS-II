namespace SIS.Application.Interfaces.Validators
{
    /// <summary>
    /// Interface for validating Student Course Enrollment-related data.
    /// Provides methods to ensure the uniqueness and existence of Student Course Enrollment attributes.
    /// </summary>
    public interface IStudentCourseEnrollmentValidator
    {
        /// <summary>
        /// Checks if the Student Course Enrollment is valid, i.e. exists and has the status of Enrolled.
        /// </summary>
        /// <param name="id">
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> IsValidCourseEnrollment(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the Course Instance is valid, i.e. exists and has the status of Active.
        /// </summary>
        /// <param name="courseInstanceId">The unique identifier of the Course Instance.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the Course Instance is valid; false otherwise.</returns>
        Task<bool> BeValidCourseInstance(int courseInstanceId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the Program Enrollment is valid, i.e. exists and has the status of Active.
        /// </summary>
        /// <param name="programEnrollmentId">The unique identifier of the Program Enrollment.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the Program Enrollment is valid; false otherwise.</returns>
        Task<bool> IsValidProgramEnrollment(int programEnrollmentId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the Student Course Enrollment is unique for the given Course Instance and Program Enrollment.
        /// </summary>
        /// <param name="programEnrollmentId">The unique identifier of the Program Enrollment.</param>
        /// <param name="courseInstanceId">The unique identifier of the Course Instance.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the Student Course Enrollment is unique; false otherwise.</returns>
        Task<bool> IsUniqueEnrollment(int programEnrollmentId, int courseInstanceId, CancellationToken cancellationToken);
    }
}
