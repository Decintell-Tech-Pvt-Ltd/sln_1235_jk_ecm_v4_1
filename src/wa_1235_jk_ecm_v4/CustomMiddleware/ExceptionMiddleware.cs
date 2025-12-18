using System.Text.Json;
using wa_1235_jk_ecm_v4.Interface;

namespace wa_1235_jk_ecm_v4.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogServices _logServices;


        public ExceptionMiddleware(ILogServices logServices, RequestDelegate next)
        {
            _logServices = logServices;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ArgumentException ex)
            {

                // Log specific argument exceptions
                await _logServices.LogError(
                    httpContext.Request?.RouteValues["controller"]?.ToString() ?? "UnknownController",
                    httpContext.Request?.RouteValues["action"]?.ToString() ?? "UnknownAction",
                    httpContext.Session.GetInt32("iUserId") ?? 0,
                    httpContext.Session.GetInt32("iOemId") ?? 0,
                    ex.Message,
                    httpContext.Request?.Method ?? "UnknownMethod",
                    GetType().Namespace ?? "UnknownNamespace"
                );

                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                // Log generic exceptions
                await _logServices.LogError(
                    httpContext.Request?.RouteValues["controller"]?.ToString() ?? "UnknownController",
                    httpContext.Request?.RouteValues["action"]?.ToString() ?? "UnknownAction",
                    httpContext.Session.GetInt32("iUserId") ?? 0,
                    httpContext.Session.GetInt32("iOemId") ?? 0,
                    ex.Message,
                    httpContext.Request?.Method ?? "UnknownMethod",
                    GetType().Namespace ?? "UnknownNamespace"
                );

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            return context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error. Please try again later."
            }.ToString());
        }
        public class ErrorDetails
        {
            public int StatusCode { get; set; }
            public string? Message { get; set; }
            public override string ToString()
            {
                return JsonSerializer.Serialize(this);
            }
        }

    }
}
