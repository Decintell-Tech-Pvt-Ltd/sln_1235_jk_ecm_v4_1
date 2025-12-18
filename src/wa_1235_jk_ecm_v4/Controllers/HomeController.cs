using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using wa_1235_jk_ecm_v4.Interface;
using wa_1235_jk_ecm_v4.Models;
using wa_1235_jk_ecm_v4.Models.DecintellCommon;

namespace wa_1235_jk_ecm_v4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericMethods _iGenericMethods;
        private readonly IAppSettingsService _appSettingsService;
        public static DecintellSettings? appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public bool IsCookieAcceptedExists = false;
        ResourceManager rm;
        CultureInfo ci;
        private readonly ILogServices _logServices;
        public HomeController(IGenericMethods iGenericMethods, IAppSettingsService appSettingsService, IHttpContextAccessor httpContextAccessor, ILogServices logServices)
        {
            _iGenericMethods = iGenericMethods;
            _httpContextAccessor = httpContextAccessor;
            _appSettingsService = appSettingsService;
            _logServices = logServices;
            appSettings = _appSettingsService.GetAppSettings();
        }




        public async Task<IActionResult> Index(int ModuleId)
        {
            _ = await Dashboard(ModuleId);
            await _logServices.LogWarning(
           _httpContextAccessor.HttpContext.Request?.RouteValues["controller"]?.ToString() ?? "UnknownController",
           _httpContextAccessor.HttpContext.Request?.RouteValues["action"]?.ToString() ?? "UnknownAction",
           _httpContextAccessor.HttpContext.Session.GetInt32("iUserId") ?? 0,
           _httpContextAccessor.HttpContext.Session.GetInt32("iOemId") ?? 0,
           _httpContextAccessor.HttpContext.Request?.Method ?? "UnknownMethod",
            GetType().Namespace ?? "UnknownNamespace");

            return View();
        }

        private async Task<IActionResult> Dashboard(int ModuleId)
        {

            if (ModuleId == 0)
            {
                ModuleId = appSettings.ModuleId;
            }

            string? AccessToken = "";

            //now get access token from cookie
            AccessToken = _httpContextAccessor.HttpContext.Request.Cookies["1231_AccessToken"];
            if (String.IsNullOrEmpty(AccessToken))
            {
                string Type = "Logout";
                var RedirectUrl = appSettings.UserDetailChange;
                var urlLogout = $"{RedirectUrl}{Type}?UserId={HttpContext.Session.GetInt32("CreatedBy")}&OemId={HttpContext.Session.GetInt32("OemId")}";
                // Perform server-side redirect
                Response.Redirect(urlLogout);

                // Return JavaScript to perform client-side redirect (this will not execute if Response.Redirect is called)
                return Content($"<script>window.location.href = '{urlLogout}';</script>", "text/html");
            }
            return Json(new { success = true });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            //var Logout_URL = appSettings.Logout_Url;
            // Clear all variables
            GlobalVariables.Instance.ClearAllVariables();
            _httpContextAccessor.HttpContext.Session.Clear();
            return Json(new { success = true, /*message = Logout_URL*/ });

        }



        [HttpPost]
        public async Task<ActionResult> GetMenuTreeViewAllPageTypeDetailsJson(string JsonData)
        {
            string apiEndPoint = "ModuleMenu/GetMenuTreeViewAllPageTypeDetailsJson";
            var menulist = JsonSerializer.Deserialize<dynamic>(await _iGenericMethods.PostDataLogin(apiEndPoint, JsonData));

            return Json(new { response = menulist });

        }

        [HttpPost]
        public IActionResult UserDetailChange(string Type)
        {
            if (Type == "Logout")
            {
                // Clear all items from the session
                _httpContextAccessor.HttpContext.Session.Clear();
                // Clear specific cookies
                Response.Cookies.Delete("1231_OemId");
                Response.Cookies.Delete("1231_UserId");
                Response.Cookies.Delete("1231_AccessToken");
            }
            var RedirectUrl = appSettings.UserDetailChange;
            return Json(new { success = true, RedirectUrl });
        }

        /// <summary>
        /// Added by:Mayuri
        /// Date:30 May 2024
        /// Purpose: Add Notification feature on Bell icon on dashboard.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetNotification()
        {
            var RedirectUrl = appSettings.UserDetailChange + "Notification";
            return Json(new { success = true, RedirectUrl });
        }

        [HttpPost]
        public async Task<IActionResult> GetNotificationMessage(string JsonData)
        {
            string apiEndPoint = "ModuleMenu/GetNotificationMessage";

            var UserNotification = JsonSerializer.Deserialize<dynamic[]>(await _iGenericMethods.PostDataLogin(apiEndPoint, JsonData));
            return Json(new { success = true, UserNotification });
        }

        [HttpPost]
        public async Task<IActionResult> GetNotification_OemList_Logo(string JsonData)
        {
            var apiEndPoint = "ModuleMenu/GetNotification_OemList_Logo";
            var Notification_OemList_Logo = JsonSerializer.Deserialize<List<Notification_OemList_Logo>>(await _iGenericMethods.PostDataLogin(apiEndPoint, JsonData));
            string notificationListJson = "", notificationcount = "";
            // Assuming Notification_OemList_Logo is a list or array of some type that contains a NotificationList property
            if (Notification_OemList_Logo != null && Notification_OemList_Logo.Count > 0 && Notification_OemList_Logo[0].NotificationList != null)
            {
                // Safe to serialize and count since we've checked it's not null
                notificationListJson = JsonSerializer.Serialize(Notification_OemList_Logo[0].NotificationList);
                notificationcount = JsonSerializer.Serialize(Notification_OemList_Logo[0].NotificationCount[0].Notificationcnt);

            }
            else
            {
                notificationListJson = null;
                notificationcount = null;
            }

            return Json(new { success = true, notificationListJson, notificationcount });
        }



   

    }
}
