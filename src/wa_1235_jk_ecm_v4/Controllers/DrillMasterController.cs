using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using wa_1235_jk_ecm_v4.Interface;
using wa_1235_jk_ecm_v4.Models;
using wa_1235_jk_ecm_v4.Models.DecintellCommon;
using static wa_1235_jk_ecm_v4.Models.Master;
namespace wa_1235_jk_ecm_v4.Controllers
{
    public class DrillMasterController : Controller
    {
        private readonly IGenericMethods _iGenericMethods;
        private readonly IAppSettingsService _appSettingsService;
        public static DecintellSettings? appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DrillMasterController(IGenericMethods iGenericMethods, IAppSettingsService appSettingsService, IHttpContextAccessor httpContextAccessor)
        {
            _iGenericMethods = iGenericMethods;
            _appSettingsService = appSettingsService;
            appSettings = _appSettingsService.GetAppSettings();
            _httpContextAccessor = httpContextAccessor;

        }
        private string JwtToken => _httpContextAccessor.HttpContext.Request.Cookies["1231_AccessToken"];



    }
}