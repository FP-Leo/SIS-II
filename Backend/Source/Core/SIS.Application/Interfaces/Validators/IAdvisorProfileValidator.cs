namespace SIS.Application.Interfaces.Validators
{
    public interface IAdvisorProfileValidator
    {
        public Task<bool> IsValidProfile(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the user is a valid Advisor, i.e. exists and has the role of Advisor.
        /// </summary>
        /// <param name="userId">The unique identifier of the Advisor.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the user is a valid Advisor; false otherwise.</returns>
        public Task<bool> IsValidAdvisor(string userId, CancellationToken cancellationToken);

        /// <summary>
        /// Check if the profile is unique, i.e. doesn't already exist in the given department.
        /// </summary>
        /// <param name="userId">The unique identifier of the Advisor.</param>
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
