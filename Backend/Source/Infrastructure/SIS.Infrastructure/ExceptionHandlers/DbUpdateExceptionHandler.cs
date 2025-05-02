using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIS.Domain.Exceptions.Common;

namespace SIS.Infrastructure.ExceptionHandlers
{
    public class DbUpdateExceptionHandler(ILogger<DbUpdateExceptionHandler> logger): IExceptionHandler
    {
        private readonly ILogger<DbUpdateExceptionHandler> _logger = logger;

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
