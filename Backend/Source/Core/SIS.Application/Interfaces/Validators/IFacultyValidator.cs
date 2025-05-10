namespace SIS.Application.Interfaces.Validators
{
    public interface IFacultyValidator
    /// <summary>
    /// Interface for validating faculty-related data.
    /// Provides methods to ensure the uniqueness and existence of faculty attributes.
    /// </summary>

    {
        /// <summary>
        /// Validates whether the faculty name is unique within a university.
        /// </summary>
        /// <param name="uniId">The unique identifier of the university.</param>
        /// <param name="name">The name of the faculty to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the name is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueFacultyName(int uniId, string name, CancellationToken cancellationToken);
        /// <summary>
        /// Validates whether the faculty name is unique within a university.
        /// </summary>
        /// <param name="uniId">The unique identifier of the university.</param>
        /// <param name="facultyId"> The unique identifier of the faculty to exclude.</param>
        /// <param name="name">The name of the faculty to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the name is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueFacultyName(int uniId, int facultyId, string name, CancellationToken cancellationToken);

        /// <summary>
        /// Validates whether the faculty code is unique within a university.
        /// </summary>
        /// <param name="uniId">The unique identifier of the university.</param>
        /// <param name="code">The code of the faculty to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the code is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueFacultyCode(int uniId, string code, CancellationToken cancellationToken);
        /// <summary>
        /// Validates whether the faculty code is unique within a university.
        /// </summary>
        /// <param name="uniId">The unique identifier of the university.</param>
        /// <param name="facultyId"> The unique identifier of the faculty to exclude.</param>
        /// <param name="code">The code of the faculty to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the code is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueFacultyCode(int uniId, int facultyId, string code, CancellationToken cancellationToken);

        /// <summary>
        /// Validates whether the faculty phone number is unique.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the faculty to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the phone number is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueFacultyPhoneNumber(string phoneNumber, CancellationToken cancellationToken);
        /// <summary>
        /// Validates whether the faculty phone number is unique.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the faculty to validate.</param>
        /// <param name="facultyId">The unique identifier of the faculty to exclude.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the phone number is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueFacultyPhoneNumber(string phoneNumber, int facultyId, CancellationToken cancellationToken);

        /// <summary>
        /// Validates whether the dean ID is unique within a university.
        /// </summary>
        /// <param name="deanId">The unique identifier of the dean to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the dean ID is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueDeanId(string deanId, CancellationToken cancellationToken);
        /// <summary>
        /// Validates whether the dean ID is unique within a university.
        /// </summary>
        /// <param name="deanId">The unique identifier of the dean to validate.</param>
        /// <param name="facultyId"> The unique identifier of the faculty to exclude.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the dean ID is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueDeanId(string deanId, int facultyId,CancellationToken cancellationToken);

        /// <summary>
        /// Validates whether a university exists for the given university ID.
        /// </summary>
        /// <param name="uniId">The unique identifier of the university to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the university exists; otherwise, <c>false</c>.</returns>
        Task<bool> UniversityExistsAsync(int? uniId, CancellationToken cancellationToken);

        Task<bool> UniversityExistsAsync(int uniId, CancellationToken cancellationToken);
    }
}
