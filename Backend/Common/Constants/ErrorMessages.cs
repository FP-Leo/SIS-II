namespace SIS.Common.Constants
{
    /// <summary>
    /// Provides a collection of error message constants used throughout the application.
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        /// Error message for internal server errors.
        /// </summary>
        public const string ServerError = "An internal error occurred while processing your request";

        /// <summary>
        /// Error message for unauthorized actions.
        /// </summary>
        public const string UnAuthorized = "You are not authorized to perform this action";

        // User-related error messages

        /// <summary>
        /// Error message when a user is not found.
        /// </summary>
        public const string UserNotFound = "User not found";

        /// <summary>
        /// Error message when a user already exists.
        /// </summary>
        public const string UserAlreadyExists = "User already exists";

        // University-related error messages

        /// <summary>
        /// Error message when no universities are found.
        /// </summary>
        public const string UniversitiesNotFound = "No universities found";

        /// <summary>
        /// Error message when no university matches the search criteria.
        /// </summary>
        public const string UniversityNotFound = "No university found matching the search criteria.";

        /// <summary>
        /// Error message when a rector is not found.
        /// </summary>
        public const string RectorNotFound = "Rector not found. Please check the ID and try again.";

        /// <summary>
        /// Error message for invalid university IDs.
        /// </summary>
        public const string InvalidUniversityId = "Invalid university ID. Please check the ID and try again.";
    }
}