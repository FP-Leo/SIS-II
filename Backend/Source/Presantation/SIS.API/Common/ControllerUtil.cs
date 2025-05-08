using Microsoft.AspNetCore.Mvc;

namespace SIS.API.Common
{
    /// <summary>
    /// Provides utility methods for use in controllers.
    /// </summary>
    public static class ControllerUtil
    {
        /// <summary>
        /// Creates a <see cref="ValidationProblemDetails"/> object from a FluentValidation validation result.
        /// </summary>
        /// <param name="validationResult">The validation result containing the errors.</param>
        /// <param name="instance">The instance path or identifier related to the validation error.</param>
        /// <returns>A <see cref="ValidationProblemDetails"/> object representing the validation errors.</returns>
        public static ValidationProblemDetails CreateValidationProblemDetails(FluentValidation.Results.ValidationResult validationResult, string instance)
        {
            return new ValidationProblemDetails(validationResult.ToDictionary())
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation Error",
                Detail = "One or more validation errors occurred.",
                Instance = instance
            };
        }
    }
}