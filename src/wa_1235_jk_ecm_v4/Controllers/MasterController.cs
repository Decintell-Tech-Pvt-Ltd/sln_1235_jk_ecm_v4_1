using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.VisualBasic.FileIO;
using Serilog.Sinks.File;
using System.Collections;
using System.Text.Json;
using wa_1235_jk_ecm_v4.Interface;
using wa_1235_jk_ecm_v4.Models;
using wa_1235_jk_ecm_v4.Models.DecintellCommon;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static wa_1235_jk_ecm_v4.Models.Master;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.SignalR;
using System.Text;





namespace wa_1235_jk_ecm_v4.Controllers
{
    public class MasterController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IGenericMethods _iGenericMethods;
        private readonly IAppSettingsService _appSettingsService;
        public static DecintellSettings? appSettings;
        public static int GlobalLookupTypeID;
        public static string GlobalLookupTypeName;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MasterController(IGenericMethods iGenericMethods, IAppSettingsService appSettingsService, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _iGenericMethods = iGenericMethods;
            _appSettingsService = appSettingsService;
            appSettings = _appSettingsService.GetAppSettings();
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }
        private string JwtToken => _httpContextAccessor.HttpContext.Request.Cookies["1231_AccessToken"];

        public class CsvData
        {
            public int ParameterCategorySequence { get; set; }
            public string ParameterCategory { get; set; }
            public string ParameterName { get; set; }
            public string ParameterCode { get; set; }
            public string ParameterPresentOnReport { get; set; }
            public string InputType { get; set; }
            public string UOM { get; set; }
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CustomerList()
        {
            Master objList = new Master();
            string apiEndPoint = "Masters/GetCustomerList";
            objList.CustomerList = JsonSerializer.Deserialize<Customer[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }
        public IActionResult AddCustomer(string CustomerId)
        {
            ViewBag.CustomerId = CustomerId;
            return View();
        }
        public async Task<ActionResult> EditStampMaster(int Id)
        {
            try
            {
                ViewBag.JWTToken = JwtToken;
                ViewBag.ApiUrl = appSettings?.API_blob_1231;
                ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;

                Master objList = new Master();
                string apiEndPoint = "Masters/GetStampById";
                var JsonData = new
                {
                    Id = Id
                };
                string BrandIdJson = JsonSerializer.Serialize(JsonData);

                //selected data for CustomerId
                objList.ddBrandList = JsonSerializer.Deserialize<ddBrandList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, BrandIdJson));

                int? BrandId = objList.ddBrandList.FirstOrDefault()?.BrandId;

                string? BrandName = objList.ddBrandList.FirstOrDefault()?.BrandName;
                string? StampChartNo = objList.ddBrandList.FirstOrDefault()?.StampChartNo;
                string? StampChartImage = objList.ddBrandList.FirstOrDefault()?.StampChartImage;

                ViewBag.BrandId = BrandId;
                ViewBag.BrandName = BrandName;
                ViewBag.StampChartNo = StampChartNo;
                ViewBag.StampChartImage = StampChartImage;

                return View(objList);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home"); // Redirect to an error page
            }
        }


        public async Task<ActionResult> EditHandle(int HandleId)
        {
            //-------------------------GetParameterById
            Master objList = new Master();
            string apiEndPoint = "Masters/GetHandleListById";
            var JsonData = new
            {

                Id = HandleId

            };
            string HandleTypeJson = JsonSerializer.Serialize(JsonData);
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            //selected data for CustomerId

            objList.EditHandleList = JsonSerializer.Deserialize<EditHandle_List[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, HandleTypeJson));

            int? Id = objList.EditHandleList.FirstOrDefault()?.Id;

            string? HandleType = objList.EditHandleList.FirstOrDefault()?.HandleType;
            string? HandleChartNo = objList.EditHandleList.FirstOrDefault()?.HandleChartNo;
            string? handleChart = objList.EditHandleList.FirstOrDefault()?.handleChart;

            string? InsertType = objList.EditHandleList.FirstOrDefault()?.InsertType;
            string? insertChartNo = objList.EditHandleList.FirstOrDefault()?.insertChartNo;
            string? insertChart = objList.EditHandleList.FirstOrDefault()?.insertChart;

            ViewBag.Id = Id;
            ViewBag.HandleType = HandleType;
            ViewBag.HandleChartNo = HandleChartNo;
            ViewBag.handleChart = handleChart;
            ViewBag.handleDrawingNo = InsertType;
            ViewBag.insertChartNo = insertChartNo;
            ViewBag.insertChart = insertChart;
            return View(objList);
        }

        public async Task<ActionResult> EditCustomer(int CustomerId)
        {
            //-------------------------GetParameterById
            Master objList = new Master();
            string apiEndPoint = "Masters/GetCustomerById";
            var JsonData = new
            {

                CustomerId = CustomerId

            };
            string CustomerIdJson = JsonSerializer.Serialize(JsonData);

            //selected data for CustomerId
            objList.CustomerList = JsonSerializer.Deserialize<Customer[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, CustomerIdJson));

            int? customerId = objList.CustomerList.FirstOrDefault()?.CustomerId;

            string? customerName = objList.CustomerList.FirstOrDefault()?.CustomerName;
            string? CustomerCode = objList.CustomerList.FirstOrDefault()?.CustomerCode;
            decimal CustomerRejectionPercentage = Convert.ToDecimal(objList.CustomerList.FirstOrDefault()?.CustomerPct);
            int? PackingDays = objList.CustomerList.FirstOrDefault()?.PackingDays;

            ViewBag.CustomerId = customerId;
            ViewBag.CustomerName = customerName;
            ViewBag.CustomerCode = CustomerCode;
            ViewBag.CustomerRejectionPercentage = CustomerRejectionPercentage;
            ViewBag.PackingDays = PackingDays;
            return View(objList);
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomerData(string JsonData)
        {
            string apiEndPoint = "Masters/AddCustomer";


            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        public async Task<IActionResult> RawMaterialList()
        {
            Master objList = new Master();
            string apiEndPoint = "Masters/GetRawMaterialList";
            objList.RawMaterialList = JsonSerializer.Deserialize<RawMaterial[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }

        public async Task<ActionResult> LookupMasters()
        {

            Master objList = new Master();
            string apiEndPoint = "Masters/GetLookupMaster";
            objList.LookupTypes_List = JsonSerializer.Deserialize<LookupTypes[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);


        }

        [HttpPost]
        public async Task<ActionResult> AddLookupData(string JsonData)
        {
            string apiEndPoint = "Masters/AddLookupData";


            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
        [HttpPost]
        public async Task<ActionResult> DeleteLookupData(string JsonData)
        {
            string apiEndPoint = "Masters/DeleteLookupData";


            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        //DeleteLookupData
        [HttpPost]
        public async Task<ActionResult> SetLookupType(string LookupType, int LookupTypeID)
        {
            TempData["LookupType"] = LookupType;
            GlobalLookupTypeName = LookupType;
            GlobalLookupTypeID = LookupTypeID;
            return Json(new { success = true });
        }
        public async Task<ActionResult> AddLookupMaster()
        {


            TempData["LookupType"] = GlobalLookupTypeName;
            ViewBag.ModeOfTravelLookupType = GlobalLookupTypeName;

            Master MasterData = new Master();

            string JsonData = "{\"LookupTypeName\":\"" + GlobalLookupTypeName + "\"}";
            string apiEndPoint = "Masters/GetLookupData";

            MasterData.Lookup_Lists = JsonSerializer.Deserialize<LookupList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));



            return View(MasterData);

        }


        public async Task<ActionResult> EditRawMaterial(int RawMaterialId)
        {
            //-------------------------GetRawMaterialById
            Master objList = new Master();
            string apiEndPoint = "Masters/GetRawMaterialById";
            var JsonData = new
            {

                RawMaterialId = RawMaterialId

            };
            string RawMaterialIdJson = JsonSerializer.Serialize(JsonData);

            //selected data for RawMaterial
            objList.RawMaterialList = JsonSerializer.Deserialize<RawMaterial[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, RawMaterialIdJson));

            string? RawMaterialCode = objList.RawMaterialList.FirstOrDefault()?.RawMaterialCode;
            string? RawMaterialDescription = objList.RawMaterialList.FirstOrDefault()?.RawMaterialDescription;

            ViewBag.RawMaterialId = RawMaterialId;
            ViewBag.RawMaterialCode = RawMaterialCode;
            ViewBag.RawMaterialDescription = RawMaterialDescription;
            return View(objList);
        }
        public IActionResult AddRawMaterial()
        {
            return View();
        }
        public async Task<ActionResult> Labellayout()
        {
            Master objList = new Master();


            string apiEndPoint = "Masters/GridLabelLayoutRequestList";
            objList.SubmittedRequest_List = JsonSerializer.Deserialize<SubmittedRequestList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            return View(objList);
        }

        public async Task<ActionResult> LabellayoutForWorkFlow()
        {
            Master objList = new Master();


            string apiEndPoint = "Masters/GridLabelLayoutRequestList";
            objList.SubmittedRequest_List = JsonSerializer.Deserialize<SubmittedRequestList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            return View(objList);
        }

        public IActionResult Packingattributes()
        {
            return View();
        }
        public IActionResult AddPackingattributes()
        {
            return View();
        }
        public IActionResult EditPackingattributes()
        {
            return View();
        }
        public async Task<IActionResult> Handlemaster()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            Master objList = new Master();
            string apiEndPoint = "Masters/GetHandleList";
            objList.Handle_List = JsonSerializer.Deserialize<Handle[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            //apiEndPoint = "Masters/GetStampRequestApprovalList";
            //objList.StampRequestApproval_List = JsonSerializer.Deserialize<Stamp[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            //apiEndPoint = "Masters/GetStampRequestApprovedList";
            //objList.StampRequestApproved_List = JsonSerializer.Deserialize<Stamp[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }

        public async Task<IActionResult> HandlemasterWorkFlow()
        {
            // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
            string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

            // Deserialize JSON string into a list of MenuItem objects
            List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

            ViewBag.btnAddHandle = "";
            foreach (MenuDataModel pageAccess in menuItems)
            {

                if (pageAccess.label == "btnAddHandle")
                {
                    ViewBag.btnAddHandle = "btnAddHandle";
                }
            }

            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            Master objList = new Master();
            string apiEndPoint = "Masters/GetHandleList";
            objList.Handle_List = JsonSerializer.Deserialize<Handle[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            //apiEndPoint = "Masters/GetStampRequestApprovalList";
            //objList.StampRequestApproval_List = JsonSerializer.Deserialize<Stamp[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            //apiEndPoint = "Masters/GetStampRequestApprovedList";
            //objList.StampRequestApproved_List = JsonSerializer.Deserialize<Stamp[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }
        public async Task<IActionResult> StampMaster()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            Master objList = new Master();
            string apiEndPoint = "Masters/GetStampList";
            objList.Stamp_List = JsonSerializer.Deserialize<Stamp[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            apiEndPoint = "Masters/GetStampRequestApprovalList";
            objList.StampRequestApproval_List = JsonSerializer.Deserialize<Stamp[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            apiEndPoint = "Masters/GetStampRequestApprovedList";
            objList.StampRequestApproved_List = JsonSerializer.Deserialize<Stamp[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }

        public async Task<IActionResult> StampMasterWorkFlow()
        {

            // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
            string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

            // Deserialize JSON string into a list of MenuItem objects
            List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

            ViewBag.btnAddStamp = "";
            foreach (MenuDataModel pageAccess in menuItems)
            {

                if (pageAccess.label == "btnAddStamp")
                {
                    ViewBag.btnAddStamp = "btnAddStamp";
                }
            }

            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            Master objList = new Master();
            string apiEndPoint = "Masters/GetStampList";
            objList.Stamp_List = JsonSerializer.Deserialize<Stamp[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            apiEndPoint = "Masters/GetStampRequestApprovalList";
            objList.StampRequestApproval_List = JsonSerializer.Deserialize<Stamp[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            apiEndPoint = "Masters/GetStampRequestApprovedList";
            objList.StampRequestApproved_List = JsonSerializer.Deserialize<Stamp[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }

        public async Task<IActionResult> AddStampMaster()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            Master objList = new Master();
            string apiEndPoint = "Masters/GetBrandNameList";
            objList.Brand_List = JsonSerializer.Deserialize<Brand[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }

        public async Task<IActionResult> DrawingMaster()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.API_ECM_1231 = appSettings?.API_ECM_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ViewBag.ReportBasePath = appSettings?.ReportBasePath;

            Master objList = new Master();
            string apiEndPointSize = "Masters/GetDrawingList";
            objList.Drawing_List = JsonSerializer.Deserialize<Drawing[]>(await _iGenericMethods.GetDataEcm(apiEndPointSize));

            return View(objList);
        }

        public async Task<IActionResult> DrawingMasterWorkFlow()
        {
            // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
            string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

            // Deserialize JSON string into a list of MenuItem objects
            List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

            ViewBag.btnAddCutSpecification = "";
            foreach (MenuDataModel pageAccess in menuItems)
            {

                if (pageAccess.label == "btnAddCutSpecification")
                {
                    ViewBag.btnAddCutSpecification = "btnAddCutSpecification";
                }
            }

            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ViewBag.ReportBasePath = appSettings.ReportBasePath;

            Master objList = new Master();
            string apiEndPointSize = "Masters/GetDrawingList";
            objList.Drawing_List = JsonSerializer.Deserialize<Drawing[]>(await _iGenericMethods.GetDataEcm(apiEndPointSize));

            return View(objList);
        }

        public async Task<ActionResult> Cutspecification()
        {
            Master objList = new Master();
            string apiEndPointSize = "Masters/GetCutSpecificationsList";
            objList.CutSpecificationsLists = JsonSerializer.Deserialize<CutSpecificationsList[]>(await _iGenericMethods.GetDataEcm(apiEndPointSize));

            return View(objList);
        }

        public async Task<ActionResult> CutspecificationWorkFlow()
        {
            // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
            string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

            // Deserialize JSON string into a list of MenuItem objects
            List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

            ViewBag.btnAddCutSpecification = "";
            foreach (MenuDataModel pageAccess in menuItems)
            {

                if (pageAccess.label == "btnAddCutSpecification")
                {
                    ViewBag.btnAddCutSpecification = "btnAddCutSpecification";
                }
            }
            Master objList = new Master();
            string apiEndPointSize = "Masters/GetCutSpecificationsList";
            objList.CutSpecificationsLists = JsonSerializer.Deserialize<CutSpecificationsList[]>(await _iGenericMethods.GetDataEcm(apiEndPointSize));

            return View(objList);
        }

        //cut-specification-edit
        public async Task<ActionResult> CutSpecificationedit(int id)
        {
            Master objList = new Master();

            string JsonData = "{\"ID\":\"" + id + "\"}";
            string apiEndPoint = "Masters/GetCutSpecificationData";
            objList.CutSpecificationEdit_List = JsonSerializer.Deserialize<CutSpecificationEdit[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            apiEndPoint = "Masters/GetCutSpecificationEdit";
            objList.CutSpecificationEditData = JsonSerializer.Deserialize<CutSpecificationEdit[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            ViewBag.ID = objList.CutSpecificationEditData[0].Id;
            ViewBag.RequestNo = objList.CutSpecificationEditData[0].RequestNo;
            ViewBag.FileSize = objList.CutSpecificationEditData[0].FileSizeCode;
            ViewBag.FileTypeCode = objList.CutSpecificationEditData[0].FileTypeCode;
            ViewBag.CutType = objList.CutSpecificationEditData[0].CutType;
             
            ViewBag.CutSpecName = objList.CutSpecificationEditData[0].CutSpecName;
            ViewBag.CutSpecCode = objList.CutSpecificationEditData[0].CutSpecCode;



            return View(objList);
        }

        public async Task<ActionResult> Cutspecificationmaster(int id)
        {
            Master objList = new Master();
            string JsonData = "{\"ID\":\"" + id + "\"}";

            string apiEndPoint = "Masters/GetCutSpecificationEdit";
            objList.CutSpecificationEditData = JsonSerializer.Deserialize<CutSpecificationEdit[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            ViewBag.CutSpecificationID = objList.CutSpecificationEditData[0].Id;
            ViewBag.RequestNo = objList.CutSpecificationEditData[0].RequestNo;
            ViewBag.FileSize = objList.CutSpecificationEditData[0].FileSizeCode;
            ViewBag.FileTypeCode = objList.CutSpecificationEditData[0].FileTypeCode;
            ViewBag.CutType = objList.CutSpecificationEditData[0].CutType;
            //ViewBag.Remark = objList.CutSpecificationEditData[0].Remark;
            ViewBag.CutSpecName = objList.CutSpecificationEditData[0].CutSpecName;
            ViewBag.CutSpecCode = objList.CutSpecificationEditData[0].CutSpecCode;

            apiEndPoint = "Masters/GetCutSpecificationData";
            objList.CutSpecificationEdit_List = JsonSerializer.Deserialize<CutSpecificationEdit[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return View(objList);
        }

        public async Task<ActionResult> Runimpactanalysis()
        {
            //Master objList = new Master();
            //string JsonData = "{\"ID\":\"" + id + "\"}";

            //string apiEndPoint = "Masters/GetCutSpecificationEdit";
            //objList.CutSpecificationEditData = JsonSerializer.Deserialize<CutSpecificationEdit[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            //ViewBag.CutSpecificationID = objList.CutSpecificationEditData[0].Id;
            //ViewBag.RequestNo = objList.CutSpecificationEditData[0].RequestNo;
            //ViewBag.FileSize = objList.CutSpecificationEditData[0].FileSizeCode;
            //ViewBag.FileTypeCode = objList.CutSpecificationEditData[0].FileTypeCode;
            //ViewBag.CutType = objList.CutSpecificationEditData[0].CutType;
            //ViewBag.Remark = objList.CutSpecificationEditData[0].Remark;
            //ViewBag.CutSpecName = objList.CutSpecificationEditData[0].CutSpecName;
            //ViewBag.CutSpecCode = objList.CutSpecificationEditData[0].CutSpecCode;

            //apiEndPoint = "Masters/GetCutSpecificationData";
            //objList.CutSpecificationEdit_List = JsonSerializer.Deserialize<CutSpecificationEdit[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return View();
        }




        [HttpPost]
        public async Task<ActionResult> AddRawMaterial(string JsonData)
        {
            string apiEndPoint = "Masters/AddRawMaterial";


            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }


        [HttpPost]
        public async Task<ActionResult> EditCutSpecification(string JsonData)
        {
            string apiEndPoint = "Masters/EditCutSpecification";


            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<ActionResult> NewCutSpecificationAdd(string JsonData)
        {
            string apiEndPoint = "Masters/NewCutSpecificationAdd";


            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<ActionResult> ApproveCutSpecification(string JsonData)
        {
            string apiEndPoint = "Masters/ApproveCutSpecification";


            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        public async Task<IActionResult> BrandList()
        {
            Master objList = new Master();
            string apiEndPoint = "Masters/GetBrandList";
            objList.Brand_List = JsonSerializer.Deserialize<Brand[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }

        public IActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBrand(string JsonData)
        {
            string apiEndPoint = "Masters/AddBrand";


            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        public async Task<IActionResult> EditFileType(int Id)
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            Master objList = new Master();
            string apiEndPointSize = "Masters/GetSizeMinMax";
            objList.FileSizes_List = JsonSerializer.Deserialize<FileSizes[]>(await _iGenericMethods.GetDataEcm(apiEndPointSize));

            //valueStream Data
            apiEndPointSize = "Masters/GetValuestream";
            objList.Valuestream_List = JsonSerializer.Deserialize<Valuestream[]>(await _iGenericMethods.GetDataEcm(apiEndPointSize));

            string apiEndPointCutSides = "Masters/GetCutsides";
            objList.Cutsides_List = JsonSerializer.Deserialize<CutsidesList[]>(await _iGenericMethods.GetDataEcm(apiEndPointCutSides));

            string apiEndPointCutOnsides = "Masters/GetCutOnsides";
            objList.CutOnSides_List = JsonSerializer.Deserialize<CutOnSidesList[]>(await _iGenericMethods.GetDataEcm(apiEndPointCutOnsides));


            string apiEndPoint = "Masters/GetEditFileType";
            var JsonData = new { Id = Id };
            string FileTypeNameJson = JsonSerializer.Serialize(JsonData);

            //selected data for CustomerId
            objList.EditFileType_List = JsonSerializer.Deserialize<EditFileTypeList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, FileTypeNameJson));

            string apiEndPointOperation = "Masters/GetEditFileTypeOperation";
            objList.EditOperation_List = JsonSerializer.Deserialize<EditOperationList[]>(await _iGenericMethods.PostDataEcm(apiEndPointOperation, FileTypeNameJson));

            apiEndPoint = "Masters/GetFileTypes";
            objList.FileTypeMasters = JsonSerializer.Deserialize<FileTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            apiEndPoint = "Masters/GetFileTypeList";
            objList.FileType_List = JsonSerializer.Deserialize<FileType[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));


            string? FileTypeName = objList.EditFileType_List.FirstOrDefault()?.FileTypeName;
            string? FileTypeCode = objList.EditFileType_List.FirstOrDefault()?.FileTypeCode;

            string? fileTypeProfileImage = objList.EditFileType_List.FirstOrDefault()?.fileTypeProfileImage;
            string? fileName = objList.EditFileType_List.FirstOrDefault()?.fileName;

            string? valueStreamCode = objList.EditFileType_List.FirstOrDefault()?.valueStreamCode;
            string? fileSizeMin = objList.EditFileType_List.FirstOrDefault()?.fileSizeMin;

            string? fileSizeMax = objList.EditFileType_List.FirstOrDefault()?.fileSizeMax;
            int? SeqNo = objList.EditFileType_List.FirstOrDefault()?.SeqNo;
            string? Operation_id = objList.EditFileType_List.FirstOrDefault()?.Operation_id;
            string? opr_operation_name = objList.EditFileType_List.FirstOrDefault()?.opr_operation_name;

            ViewBag.FileTypeName = FileTypeName;

            object? CutSide = objList.EditFileType_List.FirstOrDefault()?.CutSide;
            if (CutSide != null)
            {
                string CutSideString = CutSide.ToString()
                    .Trim('[', ']')
                    .Replace("\"", "")
                    .Replace(", ", ",");

                ViewBag.CutSide = CutSideString;
            }

            object? Cutonnsides = objList.EditFileType_List.FirstOrDefault()?.Cutonnsides;
            if (Cutonnsides != null)
            {
                string CutonnsidesString = Cutonnsides.ToString()
                    .Trim('[', ']')
                    .Replace("\"", "")
                    .Replace(", ", ",");

                ViewBag.Cutonnsides = CutonnsidesString;
            }

            ViewBag.FileTypeCode = FileTypeCode;
            ViewBag.fileTypeProfileImage = fileTypeProfileImage;
            ViewBag.fileName = fileName;
            ViewBag.valueStreamCode = valueStreamCode;
            ViewBag.fileSizeMin = fileSizeMin;
            ViewBag.fileSizeMax = fileSizeMax;
            ViewBag.SeqNo = SeqNo;
            ViewBag.Operation_id = Operation_id;
            ViewBag.opr_operation_name = opr_operation_name;


            return View(objList);
        }
        public async Task<IActionResult> EditBrand(int BrandId)
        {
            Master objList = new Master();
            string apiEndPoint = "Masters/GetBrandById";
            var JsonData = new
            {

                BrandId = BrandId

            };
            string BrandIdJson = JsonSerializer.Serialize(JsonData);

            //selected data for CustomerId
            objList.Brand_List = JsonSerializer.Deserialize<Brand[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, BrandIdJson));

            int? brandId = objList.Brand_List.FirstOrDefault()?.BrandId;

            string? brandName = objList.Brand_List.FirstOrDefault()?.BrandName;
            string? BrandCode = objList.Brand_List.FirstOrDefault()?.BrandCode;

            ViewBag.BrandId = brandId;
            ViewBag.BrandName = brandName;
            ViewBag.BrandCode = BrandCode;

            return View(objList);
        }
        public async Task<IActionResult> FileSize()
        {

            Master objList = new Master();
            string apiEndPoint = "Masters/GetFileSizeList";
            objList.FileSize_List = JsonSerializer.Deserialize<FileSize[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }
        public IActionResult AddFileSize()
        {
            return View();
        }

        public async Task<IActionResult> FileSizeWorkFlow()
        {
            // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
            string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

            // Deserialize JSON string into a list of MenuItem objects
            List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

            ViewBag.btnAddFileSize = "";
            foreach (MenuDataModel pageAccess in menuItems)
            {

                if (pageAccess.label == "btnAddFileSize")
                {
                    ViewBag.btnAddFileSize = "btnAddFileSize";
                }
            }

            Master objList = new Master();
            string apiEndPoint = "Masters/GetFileSizeList";
            objList.FileSize_List = JsonSerializer.Deserialize<FileSize[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }

        public IActionResult EditFileSize(int fileid, decimal fileSizeInch, string fileSizeCode, string NewOrExisting, string Remarks)
        {
            FileSizes objList = new FileSizes();
            objList.Id = fileid;

            objList.FileSizeInch = fileSizeInch;
            objList.FileSizeCode = fileSizeCode;
            objList.NewOrExisting = NewOrExisting;
            objList.Remarks = Remarks;
            ViewBag.NewOrExisting = NewOrExisting;
            return View(objList);
        }

        public async Task<IActionResult> AddFiletype()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            Master objList = new Master();
            string apiEndPoint = "Masters/GetSizeMinMax";
            objList.FileSizes_List = JsonSerializer.Deserialize<FileSizes[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            //valueStream Data
            apiEndPoint = "Masters/GetValuestream";
            objList.Valuestream_List = JsonSerializer.Deserialize<Valuestream[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            //FileType Data
            apiEndPoint = "Masters/GetFileTypes";
            objList.FileTypeMasters = JsonSerializer.Deserialize<FileTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            apiEndPoint = "Masters/GetCutsides";
            objList.Cutsides_List = JsonSerializer.Deserialize<CutsidesList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            apiEndPoint = "Masters/GetCutOnsides";
            objList.CutOnSides_List = JsonSerializer.Deserialize<CutOnSidesList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            return View(objList);
        }

        public async Task<IActionResult> AddHandleMaster()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            Master objList = new Master();
            //string apiEndPoint = "Masters/GetSizeMinMax";
            //objList.FileSizes_List = JsonSerializer.Deserialize<FileSizes[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            ////valueStream Data
            //apiEndPoint = "Masters/GetValuestream";
            //objList.Valuestream_List = JsonSerializer.Deserialize<Valuestream[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            ////FileType Data
            //apiEndPoint = "Masters/GetFileTypes";
            //objList.FileTypeMasters = JsonSerializer.Deserialize<FileTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }

        //file-type-add
        [HttpPost]
        public async Task<IActionResult> AddFileSize(string JsonData)
        {
            string apiEndPoint = "Masters/AddFileSize";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitFileSizeTrigger(string JsonData, string FileSizeCode,string FileSizeInch)
        {
            string apiEndPoint = "Masters/SubmitFileSizeTrigger";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            string resultMessage = "", UserEmailID = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
                UserEmailID = updateResponses[0].UserEmailID;

                // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
                string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

                // Deserialize JSON string into a list of MenuItem objects
                List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

                DateTime TodaysDate = DateTime.UtcNow;
                string dtCreatedOn = TodaysDate.ToString("F");
                string CreatedBy = HttpContext.Session.GetString("FullName");

                string labelToSearch = "btnAddFileSize";
                int? pageId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.PageId;
                int? moduleId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.ModuleId;

                var json = new
                {
                    oemId = HttpContext.Session.GetInt32("iOemId") ?? 0,
                    pageId = pageId,
                    moduleId = moduleId,
                    tagToCcValuesJson = new
                    {
                        to = new[] { new { salutation = "Sir/Madam", name = (string)null, email = UserEmailID } },
                        cc = (string)null
                    },
                    tagOtherValuesJson = new
                    {
                        subject = "File Size Code #" + FileSizeCode + " is Submitted for Approval",
                        headerLine1 = "File Size Code #" + FileSizeCode + " is Submitted for Approval",
                        subHeaderLine1 = (string)null,
                        message = (string)null,
                        disclaimerText = (string)null,
                    },

                    tagTableValuesJson = new
                    {
                        File_Size_Code = FileSizeCode,
                        File_Size_Inch= FileSizeInch,
                        Date = TodaysDate.Date,
                        Created_By = CreatedBy
                    }
                };

                // Serialize the dynamic structure to JSON using System.Text.Json
                string jsonemail = System.Text.Json.JsonSerializer.Serialize(json);
                //string JsonData = JsonSerializer.Serialize(jsonemail);
                apiEndPoint = "Email/SendEmail";
                var mail = System.Text.Json.JsonSerializer.Deserialize<dynamic>(await _iGenericMethods.PostDataLogin(apiEndPoint, jsonemail));

            }
            return Json(new { response = resultMessage });
        }


        [HttpPost]
        public async Task<IActionResult> SubmitFileTypeTrigger(string JsonData, string FileTypeName,string FileTypeCode)
        {
            string apiEndPoint = "Masters/SubmitFileTypeTrigger";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            string resultMessage = "", UserEmailID = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
                UserEmailID = updateResponses[0].UserEmailID;

                // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
                string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

                // Deserialize JSON string into a list of MenuItem objects
                List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

                DateTime TodaysDate = DateTime.UtcNow;
                string dtCreatedOn = TodaysDate.ToString("F");
                string CreatedBy = HttpContext.Session.GetString("FullName");

                string labelToSearch = "btnAddFileType";
                int? pageId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.PageId;
                int? moduleId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.ModuleId;

                var json = new
                {
                    oemId = HttpContext.Session.GetInt32("iOemId") ?? 0,
                    pageId = pageId,
                    moduleId = moduleId,
                    tagToCcValuesJson = new
                    {
                        to = new[] { new { salutation = "Sir/Madam", name = (string)null, email = UserEmailID } },
                        cc = (string)null
                    },
                    tagOtherValuesJson = new
                    {
                        subject = "File Type Code #" + FileTypeCode + " is Submitted for Approval",
                        headerLine1 = "File Type Code  #" + FileTypeCode + " is Submitted for Approval",
                        subHeaderLine1 = (string)null,
                        message = (string)null,
                        disclaimerText = (string)null,
                    },

                    tagTableValuesJson = new
                    {
                        File_Type_Name=FileTypeName,
                        FileTypeCode = FileTypeCode,
                        Date = TodaysDate.Date,
                        Created_By = CreatedBy
                    }
                };

                // Serialize the dynamic structure to JSON using System.Text.Json
                string jsonemail = System.Text.Json.JsonSerializer.Serialize(json);
                //string JsonData = JsonSerializer.Serialize(jsonemail);
                apiEndPoint = "Email/SendEmail";
                var mail = System.Text.Json.JsonSerializer.Deserialize<dynamic>(await _iGenericMethods.PostDataLogin(apiEndPoint, jsonemail));

            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitFileSubTypeTrigger(string JsonData, string SubType,string FileSubtypeCode)
        {
            string apiEndPoint = "Masters/SubmitFileSubTypeTrigger";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            string resultMessage = "", UserEmailID = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
                UserEmailID = updateResponses[0].UserEmailID;

                // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
                string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

                // Deserialize JSON string into a list of MenuItem objects
                List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

                DateTime TodaysDate = DateTime.UtcNow;
                string dtCreatedOn = TodaysDate.ToString("F");
                string CreatedBy = HttpContext.Session.GetString("FullName");

                string labelToSearch = "btnAddFileSubType";
                int? pageId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.PageId;
                int? moduleId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.ModuleId;

                var json = new
                {
                    oemId = HttpContext.Session.GetInt32("iOemId") ?? 0,
                    pageId = pageId,
                    moduleId = moduleId,
                    tagToCcValuesJson = new
                    {
                        to = new[] { new { salutation = "Sir/Madam", name = (string)null, email = UserEmailID } },
                        cc = (string)null
                    },
                    tagOtherValuesJson = new
                    {
                        subject = "File Sub Type Code #" + FileSubtypeCode + " is Submitted for Approval",
                        headerLine1 = "File Sub Type Code  #" + FileSubtypeCode + " is Submitted for Approval",
                        subHeaderLine1 = (string)null,
                        message = (string)null,
                        disclaimerText = (string)null,
                    },

                    tagTableValuesJson = new
                    {
                        File_SubType=SubType,
                        File_Sub_Type_Code = FileSubtypeCode,
                        Date = TodaysDate.Date,
                        Created_By = CreatedBy
                    }
                };

                // Serialize the dynamic structure to JSON using System.Text.Json
                string jsonemail = System.Text.Json.JsonSerializer.Serialize(json);
                //string JsonData = JsonSerializer.Serialize(jsonemail);
                apiEndPoint = "Email/SendEmail";
                var mail = System.Text.Json.JsonSerializer.Deserialize<dynamic>(await _iGenericMethods.PostDataLogin(apiEndPoint, jsonemail));

            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitCutSpecificationTrigger(string JsonData, string CutType,string CutSpecCode)
        {
            string apiEndPoint = "Masters/SubmitCutSpecificationTrigger";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            string resultMessage = "", UserEmailID = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
                UserEmailID = updateResponses[0].UserEmailID;

                // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
                string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

                // Deserialize JSON string into a list of MenuItem objects
                List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

                DateTime TodaysDate = DateTime.UtcNow;
                string dtCreatedOn = TodaysDate.ToString("F");
                string CreatedBy = HttpContext.Session.GetString("FullName");

                string labelToSearch = "btnAddCutSpecification";
                int? pageId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.PageId;
                int? moduleId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.ModuleId;

                var json = new
                {
                    oemId = HttpContext.Session.GetInt32("iOemId") ?? 0,
                    pageId = pageId,
                    moduleId = moduleId,
                    tagToCcValuesJson = new
                    {
                        to = new[] { new { salutation = "Sir/Madam", name = (string)null, email = UserEmailID } },
                        cc = (string)null
                    },
                    tagOtherValuesJson = new
                    {
                        subject = "Cut Specification Type Code #" + CutSpecCode + " is Submitted for Approval",
                        headerLine1 = "Cute Specification Type Code  #" + CutSpecCode + " is Submitted for Approval",
                        subHeaderLine1 = (string)null,
                        message = (string)null,
                        disclaimerText = (string)null,
                    },

                    tagTableValuesJson = new
                    {
                        Cut_Type= CutType,
                        Cut_Specification = CutSpecCode,
                        Date = TodaysDate.Date,
                        Created_By = CreatedBy
                    }
                };

                // Serialize the dynamic structure to JSON using System.Text.Json
                string jsonemail = System.Text.Json.JsonSerializer.Serialize(json);
                //string JsonData = JsonSerializer.Serialize(jsonemail);
                apiEndPoint = "Email/SendEmail";
                var mail = System.Text.Json.JsonSerializer.Deserialize<dynamic>(await _iGenericMethods.PostDataLogin(apiEndPoint, jsonemail));

            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitDrawingTrigger(string JsonData, string SKUKey,string RequestNo)
        {
            string apiEndPoint = "Masters/SubmitDrawingTrigger";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            string resultMessage = "", UserEmailID = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
                UserEmailID = updateResponses[0].UserEmailID;

                // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
                string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

                // Deserialize JSON string into a list of MenuItem objects
                List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

                DateTime TodaysDate = DateTime.UtcNow;
                string dtCreatedOn = TodaysDate.ToString("F");
                string CreatedBy = HttpContext.Session.GetString("FullName");

                string labelToSearch = "brnAddDrawing";
                int? pageId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.PageId;
                int? moduleId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.ModuleId;

                var json = new
                {
                    oemId = HttpContext.Session.GetInt32("iOemId") ?? 0,
                    pageId = pageId,
                    moduleId = moduleId,
                    tagToCcValuesJson = new
                    {
                        to = new[] { new { salutation = "Sir/Madam", name = (string)null, email = UserEmailID } },
                        cc = (string)null
                    },
                    tagOtherValuesJson = new
                    {
                        subject = "Production SKU #" + SKUKey + " is Submitted for Approval",
                        headerLine1 = "Production SKU  #" + SKUKey + " is Submitted for Approval",
                        subHeaderLine1 = (string)null,
                        message = (string)null,
                        disclaimerText = (string)null,
                    },

                    tagTableValuesJson = new
                    {
                        Production_SKU = SKUKey,
                        Request_No = RequestNo,
                        Date = TodaysDate.Date,
                        Created_By = CreatedBy
                    }
                };

                // Serialize the dynamic structure to JSON using System.Text.Json
                string jsonemail = System.Text.Json.JsonSerializer.Serialize(json);
                //string JsonData = JsonSerializer.Serialize(jsonemail);
                apiEndPoint = "Email/SendEmail";
                var mail = System.Text.Json.JsonSerializer.Deserialize<dynamic>(await _iGenericMethods.PostDataLogin(apiEndPoint, jsonemail));

            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitStampTrigger(string JsonData, string BrandName,string StampChartNo)
        {
            string apiEndPoint = "Masters/SubmitStampTrigger";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            string resultMessage = "", UserEmailID = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
                UserEmailID = updateResponses[0].UserEmailID;

                // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
                string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

                // Deserialize JSON string into a list of MenuItem objects
                List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

                DateTime TodaysDate = DateTime.UtcNow;
                string dtCreatedOn = TodaysDate.ToString("F");
                string CreatedBy = HttpContext.Session.GetString("FullName");

                string labelToSearch = "btnAddStamp";
                int? pageId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.PageId;
                int? moduleId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.ModuleId;

                var json = new
                {
                    oemId = HttpContext.Session.GetInt32("iOemId") ?? 0,
                    pageId = pageId,
                    moduleId = moduleId,
                    tagToCcValuesJson = new
                    {
                        to = new[] { new { salutation = "Sir/Madam", name = (string)null, email = UserEmailID } },
                        cc = (string)null
                    },
                    tagOtherValuesJson = new
                    {
                        subject = "Stamp Chart No #" + StampChartNo + " is Submitted for Approval",
                        headerLine1 = "Stamp Chart No #" + StampChartNo + " is Submitted for Approval",
                        subHeaderLine1 = (string)null,
                        message = (string)null,
                        disclaimerText = (string)null,
                    },

                    tagTableValuesJson = new
                    {
                        Stamp_Chart_No = StampChartNo,
                        BrandName=BrandName,
                        Date = TodaysDate.Date,
                        Created_By = CreatedBy
                    }
                };

                // Serialize the dynamic structure to JSON using System.Text.Json
                string jsonemail = System.Text.Json.JsonSerializer.Serialize(json);
                //string JsonData = JsonSerializer.Serialize(jsonemail);
                apiEndPoint = "Email/SendEmail";
                var mail = System.Text.Json.JsonSerializer.Deserialize<dynamic>(await _iGenericMethods.PostDataLogin(apiEndPoint, jsonemail));

            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitHandleTrigger(string JsonData, string HandleChartNo,string HandleType)
        {
            string apiEndPoint = "Masters/SubmitHandleTrigger";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            string resultMessage = "", UserEmailID = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
                UserEmailID = updateResponses[0].UserEmailID;

                // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
                string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

                // Deserialize JSON string into a list of MenuItem objects
                List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

                DateTime TodaysDate = DateTime.UtcNow;
                string dtCreatedOn = TodaysDate.ToString("F");
                string CreatedBy = HttpContext.Session.GetString("FullName");

                string labelToSearch = "btnAddHandle";
                int? pageId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.PageId;
                int? moduleId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.ModuleId;

                var json = new
                {
                    oemId = HttpContext.Session.GetInt32("iOemId") ?? 0,
                    pageId = pageId,
                    moduleId = moduleId,
                    tagToCcValuesJson = new
                    {
                        to = new[] { new { salutation = "Sir/Madam", name = (string)null, email = UserEmailID } },
                        cc = (string)null
                    },
                    tagOtherValuesJson = new
                    {
                        subject = "Handle Type #" + HandleType + " is Submitted for Approval",
                        headerLine1 = "Handle Type  #" + HandleType + " is Submitted for Approval",
                        subHeaderLine1 = (string)null,
                        message = (string)null,
                        disclaimerText = (string)null,
                    },

                    tagTableValuesJson = new
                    {
                        Handle_Type = HandleType,
                        Handle_Chart_No= HandleChartNo,
                        Date = TodaysDate.Date,
                        Created_By = CreatedBy
                    }
                };

                // Serialize the dynamic structure to JSON using System.Text.Json
                string jsonemail = System.Text.Json.JsonSerializer.Serialize(json);
                //string JsonData = JsonSerializer.Serialize(jsonemail);
                apiEndPoint = "Email/SendEmail";
                var mail = System.Text.Json.JsonSerializer.Deserialize<dynamic>(await _iGenericMethods.PostDataLogin(apiEndPoint, jsonemail));

            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<IActionResult> EditFileSize(string JsonData)
        {
            string apiEndPoint = "Masters/EditFileSize";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<IActionResult> valustreamOprationData(string JsonData)
        {
            string apiEndPoint = "Masters/valustreamOprationData";
            var result = JsonSerializer.Deserialize<List<valuestreamoperations>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return Json(new { result });
        }

        [HttpPost]
        public async Task<IActionResult> GetOperationList(string JsonData)
        {
            string apiEndPoint = "Masters/GetOperationList";
            var OperationList = JsonSerializer.Deserialize<List<OperationList>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return Json(new { OperationList });

        }
        [HttpPost]
        public async Task<IActionResult> GetParametersList(string JsonData)
        {
            Master objList = new Master();
            string apiEndPoint = "Masters/GetParametersList";
            objList.ParametersLists = JsonSerializer.Deserialize<ParametersList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            //apiEndPoint = "Masters/GetCutSides";
            //objList.cutSidesarr_list =  JsonSerializer.Deserialize<cutSidesarr[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));


            return Json(new { objList.ParametersLists });

        }

        public async Task<IActionResult> GetCutSpecification(string JsonData)
        {
            Master objList = new Master();
            string apiEndPoint = "Masters/GetCutSpecificationData";
            objList.CutSpecificationEdit_List = JsonSerializer.Deserialize<CutSpecificationEdit[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return Json(new { objList });

        }


        [HttpPost]
        public async Task<IActionResult> GetFileSubTypeParameters(string JsonData)
        {
            Master objList = new Master();
            string apiEndPoint = "Masters/GetFileSubTypeParameters";
            var GetFileSubTypeParametersList = JsonSerializer.Deserialize<List<GetFileSubTypeParametersList>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            //string? Remark = objList.GetFileSubTypeParametersList.FirstOrDefault()?.Remark;

            //ViewBag.Remark = Remark;
            return Json(new { GetFileSubTypeParametersList });

        }

        public IActionResult AddFileSubType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ApproveFileSize(string JsonData)
        {
            string apiEndPoint = "Masters/ApproveFileSize";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<IActionResult> ApproveFileType(string JsonData)
        {
            string apiEndPoint = "Masters/ApproveFileType";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
        public async Task<IActionResult> FileType()
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            Master objList = new Master();
            string apiEndPoint = "Masters/GetFileTypes";
            objList.FileTypeMasters = JsonSerializer.Deserialize<FileTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            apiEndPoint = "Masters/GetFileTypeList";
            objList.FileType_List = JsonSerializer.Deserialize<FileType[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            string? Remark = objList.FileType_List.FirstOrDefault()?.Remark;

            ViewBag.Remark = Remark;
            return View(objList);
        }

        public async Task<IActionResult> FileTypeWorkFlow()
        {
            // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
            string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

            // Deserialize JSON string into a list of MenuItem objects
            List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

            ViewBag.btnAddFileType = "";
            foreach (MenuDataModel pageAccess in menuItems)
            {

                if (pageAccess.label == "btnAddFileType")
                {
                    ViewBag.btnAddFileType = "btnAddFileType";
                }
            }

            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            Master objList = new Master();
            string apiEndPoint = "Masters/GetFileTypes";
            objList.FileTypeMasters = JsonSerializer.Deserialize<FileTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            apiEndPoint = "Masters/GetFileTypeList";
            objList.FileType_List = JsonSerializer.Deserialize<FileType[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            string? Remark = objList.FileType_List.FirstOrDefault()?.Remark;

            ViewBag.Remark = Remark;
            return View(objList);
        }
        public async Task<IActionResult> FileSubType(int Id, string fileSizeInch, string fileSizeCode, string remarks)
        {

            Master objList = new Master();
            string apiEndPoint = "Masters/GetSubFileTypes";
            objList.FileSubType_List = JsonSerializer.Deserialize<FileSubTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }

        public async Task<IActionResult> FileSubTypeWorkFlow(int Id, string fileSizeInch, string fileSizeCode, string remarks)
        {
            // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
            string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

            // Deserialize JSON string into a list of MenuItem objects
            List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

            ViewBag.btnAddFileSubType = "";
            foreach (MenuDataModel pageAccess in menuItems)
            {

                if (pageAccess.label == "btnAddFileSubType")
                {
                    ViewBag.btnAddFileSubType = "btnAddFileSubType";
                }
            }

            Master objList = new Master();
            string apiEndPoint = "Masters/GetSubFileTypes";
            objList.FileSubType_List = JsonSerializer.Deserialize<FileSubTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }

        public async Task<IActionResult> EditFileSubType(int Id, string RequestNo, string FileSize, string FileType, string SubType, string SubTypeCode)
        {
            ViewBag.RequestNo = RequestNo;
            ViewBag.FileSize = FileSize;
            ViewBag.FileType = FileType;
            ViewBag.SubType = SubType;
            ViewBag.SubTypeCode = SubTypeCode;
            ViewBag.Id = Id;
            Master objList = new Master();
            string apiEndPoint = "Masters/GetFileSubTypeSizeAndCode";
            objList.FileSubType_List = JsonSerializer.Deserialize<FileSubTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            var JsonData = new
            {

                Id = Id

            };
            string FileSubTypeJson = JsonSerializer.Serialize(JsonData);
            string apiEndPoint1 = "Masters/EditFileSubTypeList";
            objList.EditFileSubType_List = JsonSerializer.Deserialize<EditFileSubTypeMaster[]>(await _iGenericMethods.PostDataEcm(apiEndPoint1, FileSubTypeJson));
             
            return View(objList);
        }
        public async Task<IActionResult> GetCustomerCodeList(string term)
        {
            //Note : you can bind same list from database
            Master objList = new Master();
            string apiEndPoint = "Masters/GetCustomerCodeList";
            objList.CustomerList = JsonSerializer.Deserialize<Customer[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            var filteredData = objList.CustomerList
                        .Where(x => x.CustomerCode.ToUpper() == term.ToUpper())
                        .Select(x => new { label = x.CustomerCode })
                        .ToList();
            return Json(filteredData);
        }

        public async Task<IActionResult> GetBrandCodeList(string term)
        {
            //Note : you can bind same list from database
            Master objList = new Master();
            string apiEndPoint = "Masters/GetBrandCodeList";
            objList.BrandCodeList = JsonSerializer.Deserialize<BrandList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            var filteredData = objList.BrandCodeList
                        .Where(x => x.BrandId.ToUpper() == term.ToUpper())
                        .Select(x => new { label = x.BrandId })
                        .ToList();
            return Json(filteredData);
        }
        public async Task<IActionResult> GetExistingRawMaterialList(string term)
        {
            //Note : you can bind same list from database
            Master objList = new Master();
            string apiEndPoint = "Masters/GetRawMaterialList";
            objList.RawMaterialList = JsonSerializer.Deserialize<RawMaterial[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            var filteredData = objList.RawMaterialList
                        .Where(x => x.RawMaterialCode.ToUpper() == term.ToUpper())
                        .Select(x => new { label = x.RawMaterialCode })
                        .ToList();
            return Json(filteredData);
        }

        public async Task<IActionResult> GetExistingBrandList(string term)
        {
            //Note : you can bind same list from database
            Master objList = new Master();
            string apiEndPoint = "Masters/GetBrandList";
            objList.Brand_List = JsonSerializer.Deserialize<Brand[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            var filteredData = objList.Brand_List
                        .Where(x => x.BrandCode.ToUpper() == term.ToUpper())
                        .Select(x => new { label = x.BrandCode })
                        .ToList();
            return Json(filteredData);
        }

        [HttpPost]
        public async Task<IActionResult> SaveFileSubType(string JsonData)
        {
            try
            {
                string apiEndPoint = "Masters/SaveFileSubType";
                ViewBag.JWTToken = JwtToken;
                ViewBag.ApiUrl = appSettings?.API_blob_1231;
                ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
                var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
                string resultMessage = "";
                if (updateResponses != null && updateResponses.Count > 0)
                {
                    resultMessage = updateResponses[0].Result;
                }
                return Json(new { response = resultMessage });
            }
            catch (Exception ex)
            {
                return Content($"An error occurred: {ex.Message}");
            }
            //try
            //{
            //    string directoryPath = _env.ContentRootPath;
            //    using (JsonDocument document = JsonDocument.Parse(JsonData))
            //    {
            //        JsonElement root = document.RootElement;

            //        if (root.TryGetProperty("FileSubTypeDetailsJobj", out JsonElement FileTypeJobj))
            //        {
            //            if (FileTypeJobj.TryGetProperty("formData", out JsonElement fileDataElement))
            //            {
            //                if (fileDataElement.TryGetProperty("csvFileName", out JsonElement fileNameElement))
            //                {
            //                    string fileNameWithPath = fileNameElement.ToString();

            //                    string fileName = Path.GetFileName(fileNameWithPath);

            //                    string filePath = Path.Combine(fileName);

            //                    if (!System.IO.File.Exists(filePath))
            //                    {
            //                        return Content($"File '{fileName}' not found.");
            //                    }

            //                    string fileContent = System.IO.File.ReadAllText(filePath);

            //                    var jsonObject = new
            //                    {
            //                        fileContent = fileContent
            //                    };

            //                    DataTable dataTable = new DataTable();
            //                    using (StreamReader sr = new StreamReader(filePath))
            //                    {
            //                        string[] headers = sr.ReadLine().Split(',');
            //                        foreach (string header in headers)
            //                        {
            //                            dataTable.Columns.Add(header);
            //                        }

            //                        while (!sr.EndOfStream)
            //                        {
            //                            string[] rows = sr.ReadLine().Split(',');
            //                            DataRow dataRow = dataTable.NewRow();
            //                            for (int i = 0; i < headers.Length; i++)
            //                            {
            //                                dataRow[i] = rows[i];
            //                            }
            //                            dataTable.Rows.Add(dataRow);
            //                        }
            //                    }

            //                    List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            //                    foreach (DataRow row in dataTable.Rows)
            //                    {
            //                        Dictionary<string, object> rowData = new Dictionary<string, object>();
            //                        foreach (DataColumn col in dataTable.Columns)
            //                        {
            //                            rowData.Add(col.ColumnName, row[col]);
            //                        }
            //                        data.Add(rowData);
            //                    }

            //                    string jsonResult = JsonSerializer.Serialize(data);

            //                    var combinedData = await AppendJsonArraysFileSubType(JsonData, jsonResult);

            //                    return Json(new { success = true, Message = "File uploaded and processed successfully." });
            //                }
            //            }
            //        }
            //    }

            //    return Json(new { success = false, Message = "Invalid JSON format." });
            //}
            //catch (Exception e)
            //{
            //    return Json(new { success = false, Message = $"An error occurred: {e.Message}" });
            //}
        }
        public async Task<ActionResult> AppendJsonArraysFileSubType(string existingJson, string newArrayJson)
        {
            try
            {
                var fileParameter = JsonSerializer.Deserialize<Rootobject>(existingJson);

                var parametersList = JsonSerializer.Deserialize<SubTypeParameters[]>(newArrayJson);

                Dictionary<string, object> combinedData = new Dictionary<string, object>();

                combinedData["FileParameter"] = fileParameter;
                combinedData["ParametersList"] = parametersList;

                string combinedJson = JsonSerializer.Serialize(combinedData);

                string apiEndPoint = "Masters/SaveFileSubType";
                var updateResponses = await _iGenericMethods.PostDataEcm(apiEndPoint, combinedJson);

                var updateResponsesList = JsonSerializer.Deserialize<List<UpdateResponse>>(updateResponses);

                string resultMessage = "";
                if (updateResponsesList != null && updateResponsesList.Count > 0)
                {
                    resultMessage = updateResponsesList[0].Result;
                }

                return Json(new { response = resultMessage });
            }
            catch (Exception ex)
            {
                return Content($"An error occurred: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> SaveFileType(string JsonData)
        {
            try
            {
                string apiEndPoint = "Masters/SaveFileType";
                ViewBag.JWTToken = JwtToken;
                ViewBag.ApiUrl = appSettings?.API_blob_1231;
                ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
                var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
                string resultMessage = "";
                if (updateResponses != null && updateResponses.Count > 0)
                {
                    resultMessage = updateResponses[0].Result;
                }
                return Json(new { response = resultMessage });
            }
            catch (Exception ex)
            {
                return Content($"An error occurred: {ex.Message}");
            }
            //try
            //{
            //string directoryPath = _env.ContentRootPath;
            //using (JsonDocument document = JsonDocument.Parse(JsonData))
            //{
            //    JsonElement root = document.RootElement;

            //    if (root.TryGetProperty("FileTypeJobj", out JsonElement FileTypeJobj))
            //    {
            //        if (FileTypeJobj.TryGetProperty("formData", out JsonElement fileDataElement))
            //        {
            //            if (fileDataElement.TryGetProperty("csvFileName", out JsonElement fileNameElement))
            //            {
            //                string fileNameWithPath = fileNameElement.ToString();

            //                string fileName = Path.GetFileName(fileNameWithPath);

            //                string filePath = Path.Combine(fileName);

            //                if (!System.IO.File.Exists(filePath))
            //                {
            //                    return Content($"File '{fileName}' not found.");
            //                }

            //                string fileContent = System.IO.File.ReadAllText(filePath);

            //                var jsonObject = new
            //                {
            //                    fileContent = fileContent
            //                };

            //                DataTable dataTable = new DataTable();
            //                using (StreamReader sr = new StreamReader(filePath))
            //                {
            //                    string[] headers = sr.ReadLine().Split(',');
            //                    foreach (string header in headers)
            //                    {
            //                        dataTable.Columns.Add(header);
            //                    }

            //                    while (!sr.EndOfStream)
            //                    {
            //                        string[] rows = sr.ReadLine().Split(',');
            //                        DataRow dataRow = dataTable.NewRow();
            //                        for (int i = 0; i < headers.Length; i++)
            //                        {
            //                            dataRow[i] = rows[i];
            //                        }
            //                        dataTable.Rows.Add(dataRow);
            //                    }
            //                }

            //                List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            //                foreach (DataRow row in dataTable.Rows)
            //                {
            //                    Dictionary<string, object> rowData = new Dictionary<string, object>();
            //                    foreach (DataColumn col in dataTable.Columns)
            //                    {
            //                        rowData.Add(col.ColumnName, row[col]);
            //                    }
            //                    data.Add(rowData);
            //                }

            //                string jsonResult = JsonSerializer.Serialize(data);

            //                var combinedData = await AppendJsonArrays(JsonData, jsonResult);

            //                    return Json(new { success = true, Message = "File uploaded and processed successfully." });
            //                }
            //            }
            //        }
            //    }

            //    return Json(new { success = false, Message = "Invalid JSON format." });
            //}
            //catch (Exception e)
            //{
            //    return Json(new { success = false, Message = $"An error occurred: {e.Message}" });
            //}
        }

        [HttpPost]
        public async Task<IActionResult> EditSaveFileType(string JsonData)
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            string apiEndPoint = "Masters/EditSaveFileType";

            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        public async Task<ActionResult> AppendJsonArrays(string existingJson, string newArrayJson)
        {
            try
            {
                var fileParameter = JsonSerializer.Deserialize<FileParemeter>(existingJson);

                var parametersList = JsonSerializer.Deserialize<Parameters[]>(newArrayJson);

                Dictionary<string, object> combinedData = new Dictionary<string, object>();

                combinedData["FileParameter"] = fileParameter;
                combinedData["ParametersList"] = parametersList;

                string combinedJson = JsonSerializer.Serialize(combinedData);

                string apiEndPoint = "Masters/SaveFileType";
                var updateResponses = await _iGenericMethods.PostDataEcm(apiEndPoint, combinedJson);

                var updateResponsesList = JsonSerializer.Deserialize<List<UpdateResponse>>(updateResponses);

                string resultMessage = "";
                if (updateResponsesList != null && updateResponsesList.Count > 0)
                {
                    resultMessage = updateResponsesList[0].Result;
                }

                return Json(new { response = resultMessage });
            }
            catch (Exception ex)
            {
                return Content($"An error occurred: {ex.Message}");
            }
        }

        //public ActionResult AppendJsonArrays(string existingJson, string newArrayJson)
        //{
        //    try
        //    {
        //        // Deserialize existing JSON array
        //         dynamic FileParemeter_List = JsonSerializer.Deserialize<FileParemeter>(existingJson);
        //        Master obj = new Master();
        //        // Deserialize new JSON array
        //         dynamic Parameters_LIst= JsonSerializer.Deserialize<Parameters[]>(newArrayJson);

        //        // Append the new array to the existing array
        //        Dictionary<string, object> combinedData = new Dictionary<string, object>();

        //        // Add the existing data to the combined dictionary
        //        foreach (var kvp in FileParemeter_List)
        //        {
        //            combinedData[kvp.Key] = kvp.Value;
        //        }

        //        // Add the new data to the combined dictionary
        //        foreach (var kvp in Parameters_LIst)
        //        {
        //            combinedData[kvp.Key] = kvp.Value;
        //        }

        //        // Serialize the combined wrapper back to JSON
        //        string combinedJson = JsonSerializer.Serialize(combinedData);

        //        // Now you can use combinedJson as needed
        //        return Content(combinedJson, "application/json");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any errors
        //        return Content($"An error occurred: {ex.Message}");
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> UploadCsv(IFormFile csvFile)
        {
            try
            {
                if (csvFile == null || csvFile.Length == 0)
                {
                    return Json(new { response = "Error: No file uploaded." });
                }

                using (var memoryStream = new MemoryStream())
                {
                    csvFile.CopyTo(memoryStream);
                    memoryStream.Position = 0;

                    using (var reader = new StreamReader(memoryStream))
                    {
                        List<Dictionary<string, string>> records = new List<Dictionary<string, string>>();
                        string[] headers = reader.ReadLine()?.Split(',');

                        while (!reader.EndOfStream)
                        {
                            string[] data = reader.ReadLine()?.Split(',');
                            if (data?.Length == headers?.Length)
                            {
                                var record = new Dictionary<string, string>();
                                for (int i = 0; i < headers.Length; i++)
                                {
                                    record[headers[i]] = data[i];
                                }
                                records.Add(record);
                            }
                        }

                        var iLoggedInUserID = HttpContext.Session.GetInt32("CreatedBy");

                        var additionalData = new
                        {
                            CreatedBy = iLoggedInUserID,
                            CreatedDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
                        };

                        // Merge the additionalData with records
                        var mergedData = new
                        {
                            Records = records,
                            ParameterDetailsJobj = additionalData
                        };

                        string jsonData = JsonSerializer.Serialize(mergedData);


                        string apiEndPoint = "Masters/AddProfileParameterType";
                        var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));
                        string resultMessage = "";
                        if (updateResponses != null && updateResponses.Count > 0)
                        {
                            resultMessage = updateResponses[0].Result;
                        }

                        return Json(new { response = resultMessage });

                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { response = "Error uploading CSV file: " + ex.Message });
            }
        }

        //GetProfileParameter
        //public async Task<IActionResult> GetProfileParameter(string JsonData)
        //{
        //    string apiEndPoint = "Masters/GetProfileParameter";
        //    var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
        //    string resultMessage = "";
        //    if (updateResponses != null && updateResponses.Count > 0)
        //    {
        //        resultMessage = updateResponses[0].Result;
        //    }
        //    return Json(new { response = resultMessage });
        //}
        [HttpPost]
        public async Task<IActionResult> GetProfileParameter(string JsonData)
        {
            string apiEndPoint = "Masters/GetProfileParameter";
            var ProfileParameterData_List = JsonSerializer.Deserialize<List<ProfileParameterData_List>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return Json(new { ProfileParameterData_List });

        }
        [HttpPost]
        public async Task<IActionResult> SaveStamp(string JsonData)
        {
            try
            {
                ViewBag.JWTToken = JwtToken;
                ViewBag.ApiUrl = appSettings?.API_blob_1231;
                ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
                string apiEndPoint = "Masters/SaveStamp";
                var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
                string resultMessage = "";
                if (updateResponses != null && updateResponses.Count > 0)
                {
                    resultMessage = updateResponses[0].Result;
                }

                return Json(new { response = resultMessage });
            }
            catch (Exception e)
            {
                return Json(new { success = false, Message = "File upload." });
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteStamp(string JsonData)
        {
            string apiEndPoint = "Masters/DeleteStamp";


            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<ActionResult> DeleteHandle(string JsonData)
        {
            string apiEndPoint = "Masters/DeleteHandle";


            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
        [HttpPost]
        public async Task<IActionResult> ApprovalStamp(string JsonData)
        {
            try
            {
                string apiEndPoint = "Masters/ApprovalStamp";
                var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
                string resultMessage = "";
                if (updateResponses != null && updateResponses.Count > 0)
                {
                    resultMessage = updateResponses[0].Result;
                }

                return Json(new { response = resultMessage });
            }
            catch (Exception e)
            {
                return Json(new { success = false, Message = "File upload." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ApprovedStamp(string JsonData)
        {
            try
            {
                string apiEndPoint = "Masters/ApprovedStamp";
                var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
                string resultMessage = "";
                if (updateResponses != null && updateResponses.Count > 0)
                {
                    resultMessage = updateResponses[0].Result;
                }

                return Json(new { response = resultMessage });
            }
            catch (Exception e)
            {
                return Json(new { success = false, Message = "File upload." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveHandle(string JsonData)
        {
            try
            {
                ViewBag.JWTToken = JwtToken;
                ViewBag.ApiUrl = appSettings?.API_blob_1231;
                ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
                string apiEndPoint = "Masters/SaveHandle";
                var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
                string resultMessage = "";
                if (updateResponses != null && updateResponses.Count > 0)
                {
                    resultMessage = updateResponses[0].Result;
                }

                return Json(new { response = resultMessage });
            }
            catch (Exception e)
            {
                return Json(new { success = false, Message = "File upload." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ApprovalHandle(string JsonData)
        {
            try
            {
                string apiEndPoint = "Masters/ApprovalHandle";
                var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
                string resultMessage = "";
                if (updateResponses != null && updateResponses.Count > 0)
                {
                    resultMessage = updateResponses[0].Result;
                }

                return Json(new { response = resultMessage });
            }
            catch (Exception e)
            {
                return Json(new { success = false, Message = "File upload." });
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> ApprovedHandle(string JsonData)
        //{
        //    try
        //    {
        //        string apiEndPoint = "Masters/ApprovedHandle";
        //        var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
        //        string resultMessage = "";
        //        if (updateResponses != null && updateResponses.Count > 0)
        //        {
        //            resultMessage = updateResponses[0].Result;
        //        }

        //        return Json(new { response = resultMessage });
        //    }
        //    catch (Exception e)
        //    {
        //        return Json(new { success = false, Message = "File upload." });
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> GetFileSubTypeDataForCSV(string JsonData)
        {
            string apiEndPoint = "Masters/GetFileSubTypeDataForCSV";


            var FileSubTypeList = JsonSerializer.Deserialize<dynamic[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return Json(new { response = FileSubTypeList });
        }
        [HttpPost]
        public async Task<IActionResult> ApproveSubFileType(string JsonData)
        {
            try
            {
                string apiEndPoint = "Masters/ApproveFileSubType";
                var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
                string resultMessage = "";
                if (updateResponses != null && updateResponses.Count > 0)
                {
                    resultMessage = updateResponses[0].Result;
                }

                return Json(new { response = resultMessage });
            }
            catch (Exception e)
            {
                return Json(new { success = false, Message = "File upload." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ApprovedSubFileType(string JsonData)
        {
            try
            {
                string apiEndPoint = "Masters/ApprovedFileSubType";
                var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
                string resultMessage = "";
                if (updateResponses != null && updateResponses.Count > 0)
                {
                    resultMessage = updateResponses[0].Result;
                }

                return Json(new { response = resultMessage });
            }
            catch (Exception e)
            {
                return Json(new { success = false, Message = "File upload." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RejectFileSubType(string JsonData)
        {
            try
            {
                string apiEndPoint = "Masters/RejectFileSubType";
                var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
                string resultMessage = "";
                if (updateResponses != null && updateResponses.Count > 0)
                {
                    resultMessage = updateResponses[0].Result;
                }

                return Json(new { response = resultMessage });
            }
            catch (Exception e)
            {
                return Json(new { success = false, Message = "File upload." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditFileSubType(string JsonData)
        {
            try
            {
                string apiEndPoint = "Masters/EditFileSubType";
                var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
                string resultMessage = "";
                if (updateResponses != null && updateResponses.Count > 0)
                {
                    resultMessage = updateResponses[0].Result;
                }

                return Json(new { response = resultMessage });
            }
            catch (Exception e)
            {
                return Json(new { success = false, Message = "File upload." });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SubmitSKU(string JsonData)
        {
            string apiEndPoint = "Masters/SubmitSKU";


            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDrawingStatus(string JsonData)
        {
            string apiEndPoint = "Masters/UpdateDrawingStatus";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }


        public IActionResult GanttChart()
        {
            return View();
        }

        public IActionResult TreeAddNewNode()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveTreeData(string JsonData)
        {
            string apiEndPoint = "Masters/SaveTreeData";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }


        [HttpPost]
        public async Task<ActionResult> UpdateWorkFlowApprovalStatus(string JsonData, string TransactionId, string Type, string Status, string EventName)
        {
            string apiEndPoint = "changeNote/UpdateWorkFlowApprovalStatus";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "", UserEmailID = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;

                UserEmailID = updateResponses[0].UserEmailID;

                if (UserEmailID != null)
                {
                    // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
                    string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

                    // Deserialize JSON string into a list of MenuItem objects
                    List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

                    DateTime TodaysDate = DateTime.UtcNow;
                    string dtCreatedOn = TodaysDate.ToString("F");
                    string CreatedBy = HttpContext.Session.GetString("FullName");

                    string labelToSearch = EventName;
                    int? pageId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.PageId;
                    int? moduleId = menuItems.FirstOrDefault(item => item.label.Trim() == labelToSearch.Trim())?.ModuleId;

                    var json = new
                    {
                        oemId = HttpContext.Session.GetInt32("iOemId") ?? 0,
                        pageId = pageId,
                        moduleId = moduleId,
                        tagToCcValuesJson = new
                        {
                            to = new[] { new { salutation = "Sir/Madam", name = (string)null, email = UserEmailID } },
                            cc = (string)null
                        },
                        tagOtherValuesJson = new
                        {
                            subject = Type + " #" + TransactionId + " is Submitted for Approval",
                            headerLine1 = Type + " #" + TransactionId + " is Submitted for Approval",
                            subHeaderLine1 = (string)null,
                            message = (string)null,
                            disclaimerText = (string)null,
                        },

                        tagTableValuesJson = new
                        {
                            Type = TransactionId,
                            Date = TodaysDate.Date,
                            Created_By = CreatedBy
                        }
                    };

                    // Serialize the dynamic structure to JSON using System.Text.Json
                    string jsonemail = System.Text.Json.JsonSerializer.Serialize(json);
                    //string JsonData = JsonSerializer.Serialize(jsonemail);
                    apiEndPoint = "Email/SendEmail";
                    var mail = System.Text.Json.JsonSerializer.Deserialize<dynamic>(await _iGenericMethods.PostDataLogin(apiEndPoint, jsonemail));
                }
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public IActionResult UploadCSV(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    var fileContent = reader.ReadToEnd();
                    return Json(new { success = true, data = fileContent });
                }
            }
            return Json(new { success = false, message = "Invalid file." });
        }


        [HttpPost]
        public async Task<ActionResult> CheckStampExist(string JsonData)
        {
            string apiEndPoint = "Masters/CheckStampExist";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }



        [HttpPost]
        public async Task<ActionResult> DownloadExcel(string JsonData)
        {
            // Deserialize JSON string into a dynamic object
            var jsonObject = JsonSerializer.Deserialize<Dictionary<string, List<Dictionary<string, object>>>>(JsonData);
            var data = jsonObject["JsonData"];

            // Create a StringBuilder for CSV content
            var csv = new StringBuilder();

            // Extract headers from the first item in the data list
            if (data.Count > 0)
            {
                var headers = data[0].Keys;
                csv.AppendLine(string.Join(",", headers));

                // Add rows
                foreach (var row in data)
                {
                    csv.AppendLine(string.Join(",", row.Values.Select(value => value?.ToString() ?? "")));
                }
            }

            // Convert the CSV content to a byte array
            var content = Encoding.UTF8.GetBytes(csv.ToString());

            // Return the CSV as a file download
            return File(content, "text/csv", "data.csv");
        }



        public IActionResult ValueStream()
        {
            return View();
        }
        
        public IActionResult AddValueStream()
        {
            return View();
        }
        public IActionResult ViewValueStream()
        {
            return View();
        }
        public IActionResult Operations()
        {
            return View();
        }
        public IActionResult AddOperations()
        {
            return View();
        }
    }



}
