namespace SIS.Application.Interfaces.Validators
{
    /// <summary>
    /// Interface for validating Student profile-related data.
    /// Provides methods to ensure the uniqueness and existence of Student profile attributes.
    /// </summary>
    public interface IStudentProfileValidator
    {
        /// <summary>
        /// Checks if the Student profile is valid, i.e. exists and has the role of Student.
        /// </summary>
        /// <param name="id">The unique identifier of the Student profile.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the profile is valid; false otherwise.</returns>
        public Task<bool> IsValidProfile(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the user is a valid Student, i.e. exists and has the role of Student.
        /// </summary>
        /// <param name="userId">The unique identifier of the Student.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the user is a valid Student; false otherwise.</returns>
        public Task<bool> IsValidStudent(string userId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the Student profile is unique for the given user ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        /// <returns>True if the profile is unique; false otherwise.</returns>
        public Task<bool> IsUniqueProfile(string userId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the Default Program ID is valid for the given Student profile, i.e. student is enrolled in it.
        /// </summary>
        public Task<bool> IsValidProgram(int? programId, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the Student is enrolled in the specified program.
        /// </summary>
        /// <param name="programId">Program ID to check.</param>
        /// <param name="studentProfileId">Student profile ID to check.</param>
        /// <param name="cancellationToken">Token to cancel operation.</param>
        public Task<bool> IsInProgram(int studentProfileId, int? programId, CancellationToken cancellationToken);
    }
}
