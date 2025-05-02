namespace SIS.Common.Constants
{
    public static class ErrorMessages
    {
        public const string ServerError = "An internal error occurred while processing your request";

        // User-related error messages
        public const string UserNotFound = "User not found";
        public const string UserAlreadyExists = "User already exists";

        // University-related error messages
        public const string UniversitiesNotFound = "No universities found";
        public const string UniversityNotFound = "No university found matching the search criteria.";
        public const string RectorNotFound = "Rector not found. Please check the ID and try again.";
        public const string InvalidUniversityId = "Invalid university ID. Please check the ID and try again.";
    }
}