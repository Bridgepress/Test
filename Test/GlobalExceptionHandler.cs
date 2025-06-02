using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using Test.Domain.Exceptions;

namespace Test.API
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {

            logger.LogError(
                exception,
                "Request processing error on {MachineName}. ",
                Environment.MachineName);

            var (statusCode, title, extensions) = MapException(exception);

            await Results
                .Problem(title: title, statusCode: statusCode, extensions: extensions)
                .ExecuteAsync(httpContext);

            return true;
        }

        private static (int StatusCode, string Title, Dictionary<string, object?> extensions) MapException(Exception exception)
        {
            return exception switch
            {
                TestSystemHttpException ex => (ex.Code, ex.Message, new Dictionary<string, object?>()),
                ValidationException ex => (StatusCodes.Status400BadRequest, ex.Message, new Dictionary<string, object?>()),
                _ => (StatusCodes.Status500InternalServerError, exception.Message, new Dictionary<string, object?>())
            };
        }
    }
}
