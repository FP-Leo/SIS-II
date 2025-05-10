using SIS.Domain.Entities;
using System.Xml;

namespace SIS.Application.Interfaces.Validators
{
    /// <summary>
    /// Interface for validating department-related data.
    /// Provides methods to ensure the uniqueness and existence of department attributes.
    /// </summary>
    public interface IDepartmentValidator
    {
        /// <summary>
        /// Validates whether a department exists for the given department ID.
        /// </summary>
        /// <param name="departmentId">The unique identifier of the department to validate.</param>
        /// <param name="cancellationToken"> A token to monitor for cancellation requests.</param>
        Task<bool> ValidateDepartmentId(int departmentId, CancellationToken cancellationToken);

        /// <summary>
        /// Validates whether the department name is unique within a university.
        /// </summary>
        /// <param name="name">The name of the department to validate.</param>
        /// <param name="facultyId">The unique identifier of the university.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        Task<bool> BeUniqueDepartmentName(string name, int facultyId, CancellationToken cancellationToken);
        /// <summary>
        /// Validates whether the department name is unique within a university.
        /// </summary>
        /// <param name="name">The name of the department to validate.</param>
        /// <param name="depId"> The unique identifier of the department to exclude.</param>
        /// <param name="facultyId">The unique identifier of the university.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the name is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueDepartmentName(string name, int depId, int facultyId, CancellationToken cancellationToken);

        /// <summary>
        /// Validates whether the department code is unique within a university.
        /// </summary>
        /// <param name="code">The code of the department to validate.</param>
        /// <param name="facultyId">The unique identifier of the university.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the code is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueDepartmentCode(string code, int facultyId, CancellationToken cancellationToken);
        /// <summary>
        /// Validates whether the department code is unique within a university.
        /// </summary>
        /// <param name="code">The code of the department to validate.</param>
        /// <param name="depId"> The unique identifier of the department to exclude.</param>
        /// <param name="facultyId">The unique identifier of the university.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the code is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueDepartmentCode(string code, int depId, int facultyId, CancellationToken cancellationToken);


        /// <summary>
        /// Validates whether the department phone number is unique.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the department to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the phone number is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueDepartmentPhoneNumber(string phoneNumber, CancellationToken cancellationToken);
        /// <summary>
        /// Validates whether the department phone number is unique.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the department to validate.</param>
        /// <param name = "depId" > The unique identifier of the department to exclude.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the phone number is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueDepartmentPhoneNumber(string phoneNumber, int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Validates whether the head of department ID is unique within a university.
        /// </summary>
        /// <param name="hodId">The unique identifier of the head of department to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the head of department ID is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueHeadOfDepartmentId(string hodId, CancellationToken cancellationToken);
        /// <summary>
        /// Validates whether the head of department ID is unique within a university.
        /// </summary>
        /// <param name="hodId">The unique identifier of the head of department to validate.</param>
        /// <param name="depId"> The unique identifier of the department to exclude.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the head of department ID is unique; otherwise, <c>false</c>.</returns>
        Task<bool> BeUniqueHeadOfDepartmentId(string hodId, int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Validates whether a faculty exists for the given faculty ID.
        /// </summary>
        /// <param name="facultyId">The unique identifier of the faculty to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the faculty exists; otherwise, <c>false</c>.</returns>
        Task<bool> FacultyExistsAsync(int? facultyId, CancellationToken cancellationToken);

        /// <summary>
        /// Validates whether a faculty exists for the given faculty ID.
        /// </summary>
        /// <param name="facultyId">The unique identifier of the faculty to validate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the faculty exists; otherwise, <c>false</c>.</returns>
        Task<bool> FacultyExistsAsync(int facultyId, CancellationToken cancellationToken);
    }
}
