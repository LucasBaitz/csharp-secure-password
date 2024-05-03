using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PasswordValidator.API.Errors
{
    internal sealed class InvalidPasswordExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<InvalidPasswordExceptionHandler> _logger;

        public InvalidPasswordExceptionHandler(ILogger<InvalidPasswordExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError($"Exception occurred: {exception.Message}");

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Bad Request",
                Detail = exception.Message
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }

}
