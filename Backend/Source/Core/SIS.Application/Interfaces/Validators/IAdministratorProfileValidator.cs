namespace SIS.Application.Interfaces.Validators
{
    public interface IAdministratorProfileValidator
    {
        public Task<bool> IsValidProfile(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the user is a valid administrator, i.e. exists and has the role of administrator.
        /// </summary>
        /// <param name="userId">The unique identifier of the administrator.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the user is a valid administrator; false otherwise.</returns>
        public Task<bool> IsValidAdministrator(string userId, CancellationToken cancellationToken);

        /// <summary>
        /// Check if the profile is unique, i.e. doesn't already exist in the given department.
        /// </summary>
        /// <param name="userId">The unique identifier of the administrator.</param>
        /// <param name="depId">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the profile is unique; false otherwise.</returns>
        public Task<bool> IsUniqueProfile(string userId, int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Check if the profile is unique, i.e. doesn't already exist in the given department.
        /// </summary>
        /// <param name="profileId">The unique identifier of the profile.</param>
        /// <param name="depId">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the profile is unique; false otherwise.</returns>
        public Task<bool> IsUniqueProfile(int profileId, int depId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if department exists.
        /// </summary>
        /// <param name="depId">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns></returns>
        Task<bool> IsValidDepartment(int depId, CancellationToken cancellationToken);
        Task<bool> IsValidDepartment(int? depId, CancellationToken cancellationToken);
    }
}
