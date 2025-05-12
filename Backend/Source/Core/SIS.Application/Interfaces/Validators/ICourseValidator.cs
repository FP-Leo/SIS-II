namespace SIS.Application.Interfaces.Validators
{
    public interface ICourseValidator
    {
        /// <summary>
        /// Check if the course is valid, i.e. exists.
        /// </summary>
        /// <param name="id"> The unique identifier of the course.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the course is valid; otherwise throws error.</returns>
        /// <exception cref="InvalidInputException">Thrown if the course is not valid.</exception>
        Task<bool> IsValidCourse(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Check if the courses are valid, i.e. exists and are in the same department as specified.
        /// </summary>
        /// <param name="ids">The unique identifiers of the courses.</param>
        /// <param name="depId"> The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the courses valid; otherwise throws error.</returns>
        /// <exception cref="InvalidInputException">Thrown if any of the courses is not valid.</exception>
        Task<bool> AreValidCourses(List<int> ids, int depId, CancellationToken cancellationToken);

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
        /// Checks if department exists.
        /// </summary>
        /// <param name="depId">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns></returns>
        Task<bool> DepartmentExists(int depId, CancellationToken cancellationToken);
        Task<bool> DepartmentExists(int? depId, CancellationToken cancellationToken);
    }
}
