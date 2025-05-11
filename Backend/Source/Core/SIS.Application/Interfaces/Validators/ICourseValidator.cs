namespace SIS.Application.Interfaces.Validators
{
    public interface ICourseValidator
    {
        /// <summary>
        /// Check if the course is valid, i.e. exists.
        /// </summary>
        /// <param name="id"> The unique identifier of the course.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the course is valid; false otherwise.</returns>
        Task<bool> IsValidCourse(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Check if the course name is valid in the given department.
        /// </summary>
        /// <param name="name">The name of the course.</param>
        /// <param name="depId">The unique identifier of the department.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if the course is valid; false otherwise.</returns>
        Task<bool> IsUniqueCourse(string name, int depId, CancellationToken cancellationToken);
        
        /// <summary>
        /// Check if the course name is valid in the given department, excluding the course with the specified ID.
        /// </summary>
        /// <param name="courseID">The unique identifier of the course to be excluded.</param>
        /// <param name="name">The name of the course.</param>
        /// <param name="depId">The unique identifier of the department.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if the course is valid; false otherwise.</returns>
        Task<bool> IsUniqueCourse(int courseID, string name, int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the course is in the given department.
        /// </summary>
        /// <param name="courseId"> The unique identifier of the course.</param>
        /// <param name="depId"> The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        Task<bool> IsInDepartment(int courseId, int depId, CancellationToken cancellationToken);
        
        /// <summary>
        /// Checks if department exists.
        /// </summary>
        /// <param name="depId">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns></returns>
        Task<bool> DepartmentExists(int depId, CancellationToken cancellationToken);
        Task<bool> DepartmentExists(int? depId, CancellationToken cancellationToken);
    }
}
