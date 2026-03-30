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

        public async Task<IActionResult> DrillSubType()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/CT_GetSubTypeData";
            string JsonData = "{}";
            objList.SubTypeList = JsonSerializer.Deserialize<SubTypeList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            
            return View(objList);
        }
        

        [HttpPost]
        public async Task<IActionResult> CT_GetSubTypeDataById(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/CT_GetSubTypeData";
            objList.SubTypeList = JsonSerializer.Deserialize<SubTypeList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { response = objList.SubTypeList });
        }
        public async Task<IActionResult> DrillAddSubType()
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetDroFileSizeList";
            string JsonData = "{}";
            objList.FileSize_List = JsonSerializer.Deserialize<DrillFileSize[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            apiEndPoint = "DrillMaster/GetDroProdLine";
            objList.ProdLine_List = JsonSerializer.Deserialize<ProdLineList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
           
            apiEndPoint = "DrillMaster/GetSizeDropdown";
            objList.GetSizeList = JsonSerializer.Deserialize<GetSizeList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            apiEndPoint = "DrillMaster/GetSubTypeCSVDropdown";
            objList.CSVSubtype = JsonSerializer.Deserialize<CSVSubtype[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
  
        }
        public async Task<IActionResult> DrillSize()
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetDroFileSizeList";
            string JsonData = "{}";
            objList.FileSize_List = JsonSerializer.Deserialize<DrillFileSize[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            apiEndPoint = "DrillMaster/GetDroProdLine";
            objList.ProdLine_List = JsonSerializer.Deserialize<ProdLineList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
           
        }
        [HttpPost]
        public async Task<IActionResult> GetDroFileSizeList(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetDroFileSizeList";
            objList.DrillFileSize = JsonSerializer.Deserialize<DrillFileSize[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { response = objList.DrillFileSize });
        }
        
        public async Task<IActionResult> DrillAddSize()
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetDroProdLine";
            objList.ProdLine_List = JsonSerializer.Deserialize<ProdLineList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
      

            //apiEndPoint = "DrillMaster/GetCTTypeData";
            //objList.TypeDropdown = JsonSerializer.Deserialize<TypeDropdown[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }
        [HttpPost]
        public async Task<IActionResult> GetDownloadCSVDataForSubtype(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetDownloadCSVDataForSubtype";
            objList.DownloadSubtypeCSV = JsonSerializer.Deserialize<DownloadSubtypeCSV[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { response = objList.DownloadSubtypeCSV });
        }
        
        [HttpPost]
        public async Task<IActionResult> GetCTKeyDimensionsByTypeCode(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetCTKeyDimensionsByTypeCode";
            objList.KeyDimensionList = JsonSerializer.Deserialize<KeyDimensionList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { response = objList.KeyDimensionList });
        }
        [HttpPost]
        public async Task<IActionResult> GetSizeDetailsByTypeAndProductLine(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetSizeDetailsByTypeAndProductLine";
            objList.SizeModalList = JsonSerializer.Deserialize<SizeModalList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { response = objList.SizeModalList });
        }
        
        [HttpPost]
        public async Task<IActionResult> GetSubTypeTableData(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetSubTypeTableData";
            objList.CTSubTypeParameterList = JsonSerializer.Deserialize<CTSubTypeParameterList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { response = objList.CTSubTypeParameterList });
        }
        [HttpPost]
        public async Task<IActionResult> GetCTSizeDetails(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetCTSizeDetails";
            objList.CTTypeSizeTableData = JsonSerializer.Deserialize<CTTypeSizeTableData[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { response = objList.CTTypeSizeTableData });
        }
        

        public async Task<IActionResult> DrillType()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetDroFileTypeList";
            string JsonData = "{}";
            objList.FileType_List = JsonSerializer.Deserialize<TypeList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
          
            return View(objList);
        }
        public async Task<IActionResult> CTSubType()
        {
            return View();
        }
        public async Task<IActionResult> CTAddSubType()
        {
            return View();
        }
        public async Task<IActionResult> CTDrawing()
        {
            return View();
        }
        public async Task<IActionResult> CTAddDrawing()
        {
            return View();
        }
        public async Task<IActionResult> CTStamps()
        {
            return View();
        }
        public async Task<IActionResult> DrillAddType()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetDroFileTypes";
            objList.FileTypeMasters = JsonSerializer.Deserialize<FileTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
             apiEndPoint = "DrillMaster/GetDroProdLine";
            objList.ProdLine_List = JsonSerializer.Deserialize<ProdLineList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
           
        }
     
        public async Task<IActionResult> DrillDrawingMaster()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.API_ECM_1231 = appSettings?.API_ECM_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ViewBag.ReportBasePath = appSettings?.ReportBasePath;
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/CT_GetDrawingList";
            string JsonData = "{}";
            objList.DrawingDetails = JsonSerializer.Deserialize<DrawingDetails[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return View(objList);
        }
        [HttpPost]
        public async Task<IActionResult> CT_GetDrawingListById(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/CT_GetDrawingList";
            objList.DrawingDetails = JsonSerializer.Deserialize<DrawingDetails[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { response = objList.DrawingDetails });
        }
        public async Task<IActionResult> DrillStamp()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/CT_GetStampDetailsList";
            objList.CTStampDetails = JsonSerializer.Deserialize<CTStampDetails[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            return View(objList);
        }

        public async Task<IActionResult> DrillAddStamp()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetDroProdLine";
            objList.ProdLine_List = JsonSerializer.Deserialize<ProdLineList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            //string apiEndPoint1 = "DrillMaster/GetCTTypeData";
            //objList.TypeDropdown = JsonSerializer.Deserialize<TypeDropdown[]>(await _iGenericMethods.GetDataEcm(apiEndPoint1));
            string apiEndPoint2 = "DrillMaster/GetSizeDropdown";
            objList.GetSizeList = JsonSerializer.Deserialize<GetSizeList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint2));
           
            string apiEndPoint4 = "Masters/GetBrandList";
            objList.Brand_List = JsonSerializer.Deserialize<Brand[]>(await _iGenericMethods.GetDataEcm(apiEndPoint4));

            return View(objList);
        }
        [HttpPost]
        public async Task<IActionResult> CTSubTypeDropdown(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint3 = "DrillMaster/CTSubTypeDropdown";
            objList.SubtypeDD = JsonSerializer.Deserialize<SubtypeDD[]>(await _iGenericMethods.PostDataEcm(apiEndPoint3, JsonData));
            return Json(new { response = objList.SubtypeDD });
        }
        public async Task<IActionResult> CTTypeParameter()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetTypeParameterList";
            string JsonData = "{}";
            objList.TypeParameterList = JsonSerializer.Deserialize<TypeParameterList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return View(objList);
        }
        public async Task<IActionResult> AddCTTypeParameter()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetDroFileTypes";
            objList.FileTypeMasters = JsonSerializer.Deserialize<FileTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            apiEndPoint = "DrillMaster/GetDroProdLine";
            objList.ProdLine_List = JsonSerializer.Deserialize<ProdLineList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
         
            return View(objList);
        }
       
        [HttpPost]
        public async Task<IActionResult> GetCTTypeData(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetCTTypeData";
            objList.TypeDropdown = JsonSerializer.Deserialize<TypeDropdown[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
         
            return Json(new { response = objList.TypeDropdown });
        }
        [HttpPost]
        public async Task<IActionResult> AddSubType(string JsonData)
        {

            string apiEndPoint = "DrillMaster/AddSubType";

            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<IActionResult> CT_ApproveStamp(string JsonData)
        {

            string apiEndPoint = "DrillMaster/CT_ApproveStamp";

            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
        
        [HttpPost]
        public async Task<IActionResult> CT_AddStampDetail(string JsonData)
        {

            string apiEndPoint = "DrillMaster/CT_AddStampDetail";

            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
        
        [HttpPost]
        public async Task<IActionResult> CT_ApproveSubType(string JsonData)
        {

            string apiEndPoint = "DrillMaster/CT_ApproveSubType";

            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
        
        [HttpPost]
        public async Task<IActionResult> DroAddFileSize(string JsonData)
        {
            
            string apiEndPoint = "DrillMaster/DroAddFileSize";

            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
        [HttpPost]
        public async Task<IActionResult> AddCTSize(string JsonData)
        {

            string apiEndPoint = "DrillMaster/Add_CT_Size";

            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateTypeDetailsStatus(string JsonData)
        {

            string apiEndPoint = "DrillMaster/UpdateTypeDetailsStatus";

            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
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
        [HttpPost]
        public async Task<IActionResult> GetDroFileSizeListById(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetDroFileSizeList";
            objList.FileSize_List = JsonSerializer.Deserialize<DrillFileSize[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { response = objList.FileSize_List });
        }
        [HttpPost]
        public async Task<IActionResult> CT_GetTypeParametersList(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/CT_GetTypeParametersList";
            objList.CTCSVData = JsonSerializer.Deserialize<CTCSVData[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { response = objList.CTCSVData });
        }
        
        [HttpPost]
        public async Task<IActionResult> GetStampModalList(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetStampModalList";
            objList.CTStampDetails = JsonSerializer.Deserialize<CTStampDetails[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { response = objList.CTStampDetails });
        }
        [HttpPost]
        public async Task<IActionResult> GetDroFileTypeListId(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetDroFileTypeList";
            objList.FileType_List = JsonSerializer.Deserialize<TypeList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { response = objList.FileType_List });
        }
        [HttpPost]
        public async Task<IActionResult> GetTypeParameterListById(string JsonData)
        {
            DrillMaster objList = new DrillMaster();
            string apiEndPoint = "DrillMaster/GetTypeParameterList";
            objList.TypeParamByIDList = JsonSerializer.Deserialize<TypeParamByIDList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { response = objList.TypeParamByIDList });
        }
        [HttpPost]
        public async Task<IActionResult> DroApproveFileType(string JsonData)
        {
            string apiEndPoint = "DrillMaster/CTApproveFileType";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
        [HttpPost]
        public async Task<IActionResult> GetDroOperationList(string JsonData)
        {
            string apiEndPoint = "DrillMaster/GetDroOperationList";
            var OperationList = JsonSerializer.Deserialize<List<OperationList>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return Json(new { OperationList });

        }
        [HttpPost]
        public async Task<IActionResult> GetDroParametersList(string JsonData)
        {
            Master objList = new Master();
            string apiEndPoint = "DrillMaster/GetDroParametersList";
            objList.ParametersLists = JsonSerializer.Deserialize<ParametersList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            //apiEndPoint = "Masters/GetCutSides";
            //objList.cutSidesarr_list =  JsonSerializer.Deserialize<cutSidesarr[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));


            return Json(new { objList.ParametersLists });

        }
        
        [HttpPost]
        public async Task<IActionResult> InsertCSVTypeDetails(string JsonData)
        {
            string apiEndPoint = "DrillMaster/InsertCSVTypeDetails";

            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
        [HttpPost]
        public async Task<IActionResult> EditDroSaveFileType(string JsonData)
        {           
            string apiEndPoint = "DrillMaster/EditDroSaveFileType";

            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
    }
}