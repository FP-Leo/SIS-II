namespace SIS.Domain.Exceptions.Common
{
    /// <summary>
    /// Represents an API error response containing error details.
    /// </summary>
    public class ApiErrorResponse
    {
        /// <summary>
        /// Gets or sets the error code or identifier.
        /// </summary>
        public required string Error { get; set; }

        /// <summary>
        /// Gets or sets the error message describing the issue.
        /// </summary>
        public required string Message { get; set; }
    }
}
