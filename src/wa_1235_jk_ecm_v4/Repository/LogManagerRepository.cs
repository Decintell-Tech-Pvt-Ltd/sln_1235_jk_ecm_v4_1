using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System.Net;
using wa_1235_jk_ecm_v4.Interface;

namespace wa_1235_jk_ecm_v4.Repository
{
    public class LogManagerRepository : ILogServices
    {
        private readonly ILogger<LogManagerRepository> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LogManagerRepository(ILogger<LogManagerRepository> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogInfo(string controller, string method, int userId, int oemId, string methodType, string namespaces)
        {
            try
            {
                var utcTime = DateTime.UtcNow;
                // Retrieve the IP address
                var ipAddress = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "Unknown";
                // Get Device Type
                var deviceType = GetDeviceType(_httpContextAccessor.HttpContext);

                using (LogContext.PushProperty("UserId", userId))
                using (LogContext.PushProperty("OemId", oemId))
                using (LogContext.PushProperty("ControllerName", controller))
                using (LogContext.PushProperty("MethodName", method))
                using (LogContext.PushProperty("MethodType", methodType))
                using (LogContext.PushProperty("UTCTime", utcTime))
                using (LogContext.PushProperty("Namespaces", namespaces))
                using (LogContext.PushProperty("IPAddress", ipAddress))
                using (LogContext.PushProperty("DeviceType", deviceType))
                {
                    _logger.LogInformation("Info logged for Controller: {ControllerName}, Method: {MethodName}", controller, method);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in LogManagerInfo for Controller={ControllerName}, Method={MethodName}", controller, method);
            }

            await Task.CompletedTask;
        }

        public async Task LogWarning(string controller, string method, int userId, int oemId, string methodType, string namespaces)
        {
            try
            {
                var utcTime = DateTime.UtcNow;
                // Retrieve the IP address
                var ipAddress = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "Unknown";
                // Get Device Type
                var deviceType = GetDeviceType(_httpContextAccessor.HttpContext);

                using (LogContext.PushProperty("UserId", userId))
                using (LogContext.PushProperty("OemId", oemId))
                using (LogContext.PushProperty("ControllerName", controller))
                using (LogContext.PushProperty("MethodName", method))
                using (LogContext.PushProperty("MethodType", methodType))
                using (LogContext.PushProperty("UTCTime", utcTime))
                using (LogContext.PushProperty("Namespaces", namespaces))
                using (LogContext.PushProperty("IPAddress", ipAddress))
                using (LogContext.PushProperty("DeviceType", deviceType))
                {
                    _logger.LogWarning("Warning logged for UserId: {UserId} at {UTCTime}", userId, utcTime);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in LogManagerWarning for Controller={ControllerName}, Method={MethodName}", controller, method);
            }

            await Task.CompletedTask;
        }

        public async Task LogError(string controller, string method, int userId, int oemId, string exception, string methodType, string namespaces)
        {
            try
            {
                var utcTime = DateTime.UtcNow;
                // Retrieve the IP address
                var ipAddress = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "Unknown";
                // Get Device Type
                var deviceType = GetDeviceType(_httpContextAccessor.HttpContext);

                using (LogContext.PushProperty("UserId", userId))
                using (LogContext.PushProperty("OemId", oemId))
                using (LogContext.PushProperty("ControllerName", controller))
                using (LogContext.PushProperty("MethodName", method))
                using (LogContext.PushProperty("MethodType", methodType))
                using (LogContext.PushProperty("UTCTime", utcTime))
                using (LogContext.PushProperty("Namespaces", namespaces))
                using (LogContext.PushProperty("IPAddress", ipAddress))
                using (LogContext.PushProperty("DeviceType", deviceType))
                {
                    _logger.LogError(
                        "{Exception}. Details: Namespace={Namespaces}, Controller={ControllerName}, Method={MethodName}, UserId={UserId}, MethodType={MethodType}, UTCTime={UTCTime}",
                        exception, namespaces, controller, method, userId, methodType, utcTime
                    );
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in LogManagerError for Controller={ControllerName}, Method={MethodName}", controller, method);
            }

            await Task.CompletedTask;
        }

        public string GetDeviceType(HttpContext httpContext)
        {
            var userAgent = httpContext.Request.Headers["User-Agent"].ToString().ToLower();

            if (string.IsNullOrEmpty(userAgent))
                return "Unknown";

            if (userAgent.Contains("mobi") || userAgent.Contains("android") || userAgent.Contains("iphone") || userAgent.Contains("ipad"))
                return "Mobile";

            return "Web";
        }


    }
}
