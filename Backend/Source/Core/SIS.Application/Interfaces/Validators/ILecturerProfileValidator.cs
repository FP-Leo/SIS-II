namespace SIS.Application.Interfaces.Validators
{
    /// <summary>
    /// Interface for validating lecturer profile-related data.
    /// Provides methods to ensure the uniqueness and existence of lecturer profile attributes.
    /// </summary>
    public interface ILecturerProfileValidator
    {
        /// <summary>
        /// Checks if the lecturer profile is valid, i.e. exists and has the role of lecturer.
        /// </summary>
        /// <param name="id">The unique identifier of the lecturer profile.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the profile is valid; false otherwise.</returns>
        public Task<bool> IsValidProfile(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the user is a valid lecturer, i.e. exists and has the role of lecturer.
        /// </summary>
        /// <param name="userId">The unique identifier of the lecturer.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the user is a valid lecturer; false otherwise.</returns>
        public Task<bool> IsValidLecturer(string userId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the lecturer profile is unique for the given user ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the profile is unique; false otherwise.</returns>
        public Task<bool> IsUniqueProfile(string userId, CancellationToken cancellationToken);
    }
}
