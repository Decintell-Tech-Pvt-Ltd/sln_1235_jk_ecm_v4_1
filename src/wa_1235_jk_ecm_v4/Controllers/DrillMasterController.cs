using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using wa_1235_jk_ecm_v4.Interface;
using wa_1235_jk_ecm_v4.Models;
using wa_1235_jk_ecm_v4.Models.DecintellCommon;
using static wa_1235_jk_ecm_v4.Models.DrillMaster;
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


        public async Task<IActionResult> DrillSize()
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetDroFileSizeList";
            objList.FileSize_List = JsonSerializer.Deserialize<DrillFileSize[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
           
        }
        public async Task<IActionResult> DrillAddSize()
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetDroProdLine";
            objList.ProdLine_List = JsonSerializer.Deserialize<ProdLineList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            string JsonData = "{\"LookupTypeName\":\"Dimension Type\"}";
             apiEndPoint = "Masters/GetLookupData";

            objList.LookupValues_List = JsonSerializer.Deserialize<LookupValues[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
             JsonData = "{\"LookupTypeName\":\"Standard\"}";
            apiEndPoint = "Masters/GetLookupData";

            objList.LookupStandard_List = JsonSerializer.Deserialize<LookupValues[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return View(objList);
        }
        public IActionResult DrillType()
        {
            return View();
        }
        public IActionResult DrillAddType()
        {
            return View();
        }
        public IActionResult DrillSubType()
        {
            return View();
        }
        public IActionResult DrillAddSubType()
        {
            return View();
        }
        public IActionResult DrillDrawingMaster()
        {
            return View();
        }
        public IActionResult DrillStamp()
        {
            return View();
        }
        public IActionResult DrillAddStamp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DroAddFileType(string JsonData)
        {
            
            string apiEndPoint = "DrillMaster/DroAddFileType";

            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
        [HttpPost]
        public async Task<IActionResult> DroApproveFileSize(string JsonData)
        {
            string apiEndPoint = "DrillMaster/DroApproveFileSize";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpGet]
        public async Task<IActionResult> GetDroProdLine(string JsonData)
        {
            string apiEndPoint = "DrillMaster/GetDroProdLine";
            var ProdLineList = JsonSerializer.Deserialize<dynamic>(await _iGenericMethods.GetDataEcm(apiEndPoint));           
            return Json(new { response = ProdLineList });
        }

    }
}