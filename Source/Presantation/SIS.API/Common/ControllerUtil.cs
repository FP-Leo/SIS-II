using Microsoft.AspNetCore.Mvc;

namespace SIS.API.Common
{
    public static class ControllerUtil
    {
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