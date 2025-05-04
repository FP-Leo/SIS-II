using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.Domain.Exceptions.Common;

namespace SIS.Infrastructure.ExceptionHandlers
{
    /// <summary>
    /// Handles exceptions related to invalid input.
    /// </summary>
    /// <param name="logger">The logger used to log exception details.</param>
    public class InvalidInputExceptionHandler(ILogger<InvalidInputExceptionHandler> logger) : IExceptionHandler
    {
        private readonly ILogger<InvalidInputExceptionHandler> _logger = logger;

        /// <summary>
        /// Attempts to handle an <see cref="InvalidInputException"/> and generate an appropriate HTTP response.
        /// </summary>
        /// <param name="httpContext">The HTTP context for the current request.</param>
        /// <param name="exception">The exception to handle.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="ValueTask{TResult}"/> containing a boolean value indicating whether the exception was handled.
        /// </returns>
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
