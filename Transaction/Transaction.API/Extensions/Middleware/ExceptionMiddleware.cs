using System.Net;
using Newtonsoft.Json;
using Serilog;

namespace Transaction.API.Extensions.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Log.Error($"Something went wrong, error: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
             Log.Error(exception, "Unhandled exception occurred");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            };

            var responseJson = JsonConvert.SerializeObject(errorDetails);
            return  context.Response.WriteAsync(responseJson);
        }
    }
}
