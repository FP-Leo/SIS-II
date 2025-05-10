using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for repository operations related to the Department entity.
    /// </summary>
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Retrieves all Departments asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A collection of all Departments.</returns>
        Task<IEnumerable<Department>> GetAllDepartmentsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a Department by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the Department.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The Department if found; otherwise, null.</returns>
        Task<Department?> GetDepartmentByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new Department asynchronously.
        /// </summary>
        /// <param name="Department">The Department entity to create.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The created Department entity.</returns>
        Task<Department> CreateDepartmentAsync(Department Department, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing Department asynchronously.
        /// </summary>
        /// <param name="Department">The Department entity to update.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        Task UpdateDepartmentAsync(Department Department, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a Department by its entity asynchronously.
        /// </summary>
        /// <param name="Department">The Department entity to delete.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        Task DeleteDepartmentByIdAsync(Department Department, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a Department with the specified name exists in a faculty asynchronously.
        /// </summary>
        /// <param name="name">The name of the Department.</param>
        /// <param name="facultyId">The unique identifier of the faculty.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the Department exists; otherwise, false.</returns>
        Task<bool> DepartmentExistsInUniAsync(string name, int facultyId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a Department with the specified code exists in a facultyId asynchronously.
        /// </summary>
        /// <param name="code">The code of the Department.</param>
        /// <param name="facultyId">The unique identifier of the faculty.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the code exists; otherwise, false.</returns>
        Task<bool> CodeExistsInUniAsync(string code, int facultyId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a department with the specified id exists asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the department exists; otherwise, false.</returns>
        Task<bool> DepartmentExistsByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a department with the specified phone number exists asynchronously.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the department.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the phone number exists; otherwise, false.</returns>
        Task<bool> DepartmentExistsByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a Department with the specified dean ID exists asynchronously.
        /// </summary>
        /// <param name="hodId">The unique identifier of the head of the department.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>True if the dean ID exists; otherwise, false.</returns>
        Task<bool> DepartmentExistsByHodIdAsync(string hodId, CancellationToken cancellationToken);
    }
}
