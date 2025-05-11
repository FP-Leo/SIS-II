using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SIS.Infrastructure.ExceptionHandlers
{
    /// <summary>
    /// Handles exceptions related to database updates.
    /// </summary>
    /// <param name="logger">The logger used to log exception details.</param>
    public class DbUpdateExceptionHandler(ILogger<DbUpdateExceptionHandler> logger) : IExceptionHandler
    {
        private readonly ILogger<DbUpdateExceptionHandler> _logger = logger;

        /// <summary>
        /// Attempts to handle a <see cref="DbUpdateException"/> and generate an appropriate HTTP response.
        /// </summary>
        /// <param name="httpContext">The HTTP context for the current request.</param>
        /// <param name="exception">The exception to handle.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="ValueTask{TResult}"/> containing a boolean value indicating whether the exception was handled.
        /// </returns>
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not DbUpdateException notFoundException)
            {
                return false;
            }

            _logger.LogError(exception, "Invalid Input Exception occurred: {Message}", exception.Message);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Database Update Error",
                Detail = notFoundException.Message
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
