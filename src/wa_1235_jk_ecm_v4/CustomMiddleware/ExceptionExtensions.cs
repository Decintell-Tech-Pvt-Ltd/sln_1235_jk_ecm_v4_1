using wa_1235_jk_ecm_v4.CustomExceptionMiddleware;

namespace wa_1235_jk_ecm_v4.CustomExceptionMiddleware
{
    public static class ExceptionExtensions
    {

        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

    }
}
