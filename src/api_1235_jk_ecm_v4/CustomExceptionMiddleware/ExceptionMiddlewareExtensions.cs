using api_1235_jk_ecm_v4.CustomExceptionMiddleware;

namespace api_1235_jk_ecm_v4.CustomExceptionMiddleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
