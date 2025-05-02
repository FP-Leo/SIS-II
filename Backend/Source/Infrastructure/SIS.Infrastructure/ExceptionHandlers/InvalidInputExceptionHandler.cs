using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.Domain.Exceptions.Common;

namespace SIS.Infrastructure.ExceptionHandlers
{
    public class InvalidInputExceptionHandler(ILogger<InvalidInputExceptionHandler> logger): IExceptionHandler
    {
        private readonly ILogger<InvalidInputExceptionHandler> _logger = logger;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not InvalidInputException notFoundException)
            {
                return false;
            }

            _logger.LogWarning(exception, "Invalid Input Exception occurred: {Message}", exception.Message);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = notFoundException.Subject,
                Detail = notFoundException.Message
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
