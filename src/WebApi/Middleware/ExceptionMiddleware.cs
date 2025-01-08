
using System.Net;
using System.Text.Json;

namespace BlogDotNet.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, exception.Message);

            var response = context.Response;
            response.ContentType = "application/json";
            //
            // var statusCode = exception switch
            // {
            //     NotFoundException => HttpStatusCode.NotFound,
            //     _ => HttpStatusCode.InternalServerError
            // };
            //
            // response.StatusCode = (int)statusCode;

            var result = JsonSerializer.Serialize(new { message = exception.Message });
            await response.WriteAsync(result);
        }
    }
}