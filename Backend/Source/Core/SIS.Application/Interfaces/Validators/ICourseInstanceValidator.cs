namespace SIS.Application.Interfaces.Validators
{
    public interface ICourseInstanceValidator
    {
        /// <summary>
        /// Check if the course instance is valid, i.e. exists.
        /// </summary>
        /// <param name="id">The unique identifier of the course instance.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns></returns>
        Task<bool> BeValidCourseInstance(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Check if the course instance is valid, i.e. exists.
        /// </summary>
        /// <param name="id">The unique identifier of the course instance.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the course instance is valid; otherwise throws error.</returns>
        Task<bool> IsValidCourse(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Check if the admin profile is valid, i.e. exists and is in the same department as the specified course.
        /// </summary>
        /// <param name="id">The unique identifier of the admin profile.</param>
        /// <param name="courseId">The unique identifier of the course.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the admin profile is valid; otherwise throws error.</returns>
        Task<bool> IsValidAdminByCourse(int id, int courseId,CancellationToken cancellationToken);

        /// <summary>
        /// Check if the lecturer assignment is valid, i.e. exists and is in the same department as the specified course.
        /// </summary>
        /// <param name="id">The unique identifier of the lecturer assignment.</param>
        /// <param name="courseId">The unique identifier of the course.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the lecturer assignment is valid; otherwise throws error.</returns>
        Task<bool> IsValidLecturerByCourse(int id, int courseId, CancellationToken cancellationToken);

        /// <summary>
        /// Check if the lecturer assignment is valid, i.e. exists and is in the same department as the specified course instance.
        /// </summary>
        /// <param name="id">The unique identifier of the lecturer assignment.</param>
        /// <param name="courseInstanceId">The unique identifier of the course instance.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the lecturer assignment is valid; otherwise throws error.</returns>
        Task<bool> IsValidLecturerByCourseInstance(int id, int courseInstanceId, CancellationToken cancellationToken);

        /// <summary>
        /// Check if the program semester is valid, i.e. exists and is in the same department as the specified course.
        /// </summary>
        /// <param name="id">The unique identifier of the program semester.</param>
        /// <param name="courseId">The unique identifier of the course.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the program semester is valid; otherwise throws error.</returns>
        Task<bool> BeValidProgramSemesterByCourse(int id, int courseId, CancellationToken cancellationToken);

        /// <summary>
        /// Check if the program semester is valid, i.e. exists and is in the same department as the specified instance.
        /// </summary>
        /// <param name="id">The unique identifier of the program semester.</param>
        /// <param name="instanceId">The unique identifier of the instance.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the program semester is valid; otherwise throws error.</returns>
        Task<bool> BeValidProgramSemesterByInstance(int id, int instanceId, CancellationToken cancellationToken);

        /// <summary>
        /// Check if the course instance is unique in the given program semester.
        /// </summary>
        /// <param name="courseId">The unique identifier of the course.</param>
        /// <param name="programSemesterId">The unique identifier of the program semester.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the course instance is unique; otherwise throws error.</returns>
        Task<bool> IsUniqueCourseInstance(int courseId, int programSemesterId, CancellationToken cancellationToken);

        /// <summary>
        /// Check if the course instance is unique in the given program semester, excluding the course instance with the specified ID.
        /// </summary>
        /// <param name="courseId">The unique identifier of the course.</param>
        /// <param name="programSemesterId">The unique identifier of the program semester.</param>
        /// <param name="courseInstanceId">The unique identifier of the course instance to be excluded.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the course instance is unique; otherwise throws error.</returns>
        Task<bool> IsUniqueCourseInstance(int courseId, int programSemesterId, int courseInstanceId, CancellationToken cancellationToken);
    }
}
