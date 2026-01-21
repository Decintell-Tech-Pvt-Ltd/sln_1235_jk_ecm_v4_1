using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using wa_1235_jk_ecm_v4.Interface;
using wa_1235_jk_ecm_v4.Models;
using wa_1235_jk_ecm_v4.Models.DecintellCommon;
using static wa_1235_jk_ecm_v4.Models.Master;


namespace wa_1235_jk_ecm_v4.Controllers
{
    public class ChangeNotesController : Controller
    {
        private readonly IGenericMethods _iGenericMethods;
        private readonly IAppSettingsService _appSettingsService;
        public static DecintellSettings? appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ChangeNotesController(IGenericMethods iGenericMethods, IAppSettingsService appSettingsService, IHttpContextAccessor httpContextAccessor)
        {
            _iGenericMethods = iGenericMethods;
            _appSettingsService = appSettingsService;
            appSettings = _appSettingsService.GetAppSettings();
            _httpContextAccessor = httpContextAccessor;

        }
        private string JwtToken => _httpContextAccessor.HttpContext.Request.Cookies["1231_AccessToken"];
        public async Task<IActionResult> ChangeNote()
        {
            ChangeNote objList = new ChangeNote();
            string apiEndPoint = "changeNote/GetChangeNoteList";
            objList.ChangeNote_List = JsonSerializer.Deserialize<ChangeNoteList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint)).OrderByDescending(r => r.Id).ToArray();
            return View(objList);
        }

        public async Task<IActionResult> ChangeNoteWorkFlow()
        {
            // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
            string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

            // Deserialize JSON string into a list of MenuItem objects
            List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

            ViewBag.btnsubmitrequestforapproval = "";
            ViewBag.Approval1 = ""; ViewBag.Approval2 = ""; ViewBag.Approval3 = "";
            ViewBag.Approval4 = ""; ViewBag.Approval5 = ""; ViewBag.Approval6 = "";
            foreach (MenuDataModel pageAccess in menuItems)
            {

                if (pageAccess.label == "btnsubmitrequestforapproval")
                {
                    ViewBag.btnsubmitrequestforapproval = "Add";
                }
                if (pageAccess.label == "Approval1")
                {
                    ViewBag.Approval1 = "1";
                }
                if (pageAccess.label == "Approval2")
                {
                    ViewBag.Approval2 = "2";
                }
                if (pageAccess.label == "Approval3")
                {
                    ViewBag.Approval3 = "3";
                }
                if (pageAccess.label == "Approval4")
                {
                    ViewBag.Approval4 = "4";
                }
                if (pageAccess.label == "Approval5")
                {
                    ViewBag.Approval5 = "5";
                }
                if (pageAccess.label == "Approval6")
                {
                    ViewBag.Approval6 = "6";
                }
            }

            ChangeNote objList = new ChangeNote();
            string apiEndPoint = "changeNote/GetChangeNoteWorkFlowList";
            objList.ChangeNote_List = JsonSerializer.Deserialize<ChangeNoteList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint)).OrderByDescending(r => r.Id).ToArray();
            return View(objList);
        }

        public IActionResult ChangenoteIndex()
        {
            return View();
        }
        public async Task<IActionResult> Changenoteapprovals()
        {
            ChangeNote objList = new ChangeNote();
            string apiEndPoint = "changeNote/GetChangenoteapprovals";
            objList.ChangeNoteApproval_List = JsonSerializer.Deserialize<ChangeNoteApproval[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }

        /// <summary>
        /// For Workflow Test
        /// </summary>
        /// <returns></returns>
        #region
        public async Task<IActionResult> Changenoteapprovalsworkflow()
        {
            // Assuming _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage") returns JSON string
            string menulistAllPageJson = _httpContextAccessor.HttpContext.Session.GetString("menuDataAllPage");

            // Deserialize JSON string into a list of MenuItem objects
            List<MenuDataModel> menuItems = System.Text.Json.JsonSerializer.Deserialize<List<MenuDataModel>>(menulistAllPageJson);

            ViewBag.btnsubmitrequestforapproval = "";
            ViewBag.Approval1 = ""; ViewBag.Approval2 = ""; ViewBag.Approval3 = "";
            ViewBag.Approval4 = ""; ViewBag.Approval5 = ""; ViewBag.Approval6 = "";
            foreach (MenuDataModel pageAccess in menuItems)
            {

                if (pageAccess.label == "btnsubmitrequestforapproval")
                {
                    ViewBag.btnsubmitrequestforapproval = "Add";
                }
                if (pageAccess.label == "Approval1")
                {
                    ViewBag.Approval1 = "1";
                }
                if (pageAccess.label == "Approval2")
                {
                    ViewBag.Approval2 = "2";
                }
                if (pageAccess.label == "Approval3")
                {
                    ViewBag.Approval3 = "3";
                }
                if (pageAccess.label == "Approval4")
                {
                    ViewBag.Approval4 = "4";
                }
                if (pageAccess.label == "Approval5")
                {
                    ViewBag.Approval5 = "5";
                }
                if (pageAccess.label == "Approval6")
                {
                    ViewBag.Approval6 = "6";
                }
            }
            FinalApproval objList = new FinalApproval();
            string apiEndPoint = "changeNote/GetFinalApprovalList";
            objList.FinalApprovallist = JsonSerializer.Deserialize<FinalApprovallist[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));
            return View(objList);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateApprovalStatus(string JsonData,string RequestId)
        {
            string apiEndPoint = "changeNote/UpdateWorkFlowApprovalStatus";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "", UserEmailID="";
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

                string labelToSearch = "btnsubmitrequestforapproval";
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
                        subject = "Request #" + RequestId + " is Submitted for Approval",
                        headerLine1 = "Request #" + RequestId + " is Submitted for Approval",
                        subHeaderLine1 = (string)null,
                        message = (string)null,
                        disclaimerText = (string)null,
                    },

                    tagTableValuesJson = new
                    {
                        RequestId = RequestId,
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

        #endregion

        public async Task<IActionResult> Changenoteproductiondetails(int ReqValue)
        {

            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.API_ECM_1231 = appSettings?.API_ECM_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ViewBag.ReqValue = ReqValue;
            ItemMaster objList = new ItemMaster();
            var ProdJson = new { RequestNo = ReqValue };
            string jsonData = JsonSerializer.Serialize(ProdJson);
            string apiEndPoint = "changeNote/GetProductionDetailsFromReqNo";
            objList.ProductionDetails_List = JsonSerializer.Deserialize<ProductionDetails>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));

            if (objList.ProductionDetails_List.ReqType == "S" || objList.ProductionDetails_List.ReqType == "R")
            {
                apiEndPoint = "ItemMaster/GetDetailsForSKUSet";
                objList.SKUSetList = JsonSerializer.Deserialize<SKUSet[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));

            }
            return View(objList);
        }
        public async Task<IActionResult> Changenotedispatchdetails(int ReqValue)
        {
            ViewBag.NewReqNo = ReqValue;
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ViewBag.ReqValue = ReqValue;
            ItemMaster objList = new ItemMaster();

            string apiEndPointCustomer = "ItemMaster/GetStampMaster";
            objList.StampMaster_List = JsonSerializer.Deserialize<StampMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPointCustomer)).OrderBy(b => b.BrandName).ToArray();

            var ProdJson = new { RequestNo = ReqValue };
            string jsonData = JsonSerializer.Serialize(ProdJson);
            string apiEndPoint = "changeNote/GetProductionDetailsFromReqNo";
            objList.ProductionDetails_List = JsonSerializer.Deserialize<ProductionDetails>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));


            var json = new { RequestNo = ReqValue, TabName = "Stamp" };
            jsonData = JsonSerializer.Serialize(json);
            apiEndPoint = "changeNote/GetDispatchDetailsFromReqNo";
            objList.StampMasterDispatchDetails = JsonSerializer.Deserialize<StampMaster>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));


            return View(objList);
        }
        public async Task<IActionResult> Changenotehandle(int ReqValue)
        {
            ViewBag.NewReqNo = ReqValue;
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;

            ViewBag.ReqValue = ReqValue;
            ItemMaster objList = new ItemMaster();

            var ProdJson = new { RequestNo = ReqValue };
            string jsonData = JsonSerializer.Serialize(ProdJson);
            string apiEndPoint = "changeNote/GetProductionDetailsFromReqNo";
            objList.ProductionDetails_List = JsonSerializer.Deserialize<ProductionDetails>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));


            var json = new { RequestNo = ReqValue, TabName = "Handle" };
            jsonData = JsonSerializer.Serialize(json);
            apiEndPoint = "changeNote/GetDispatchDetailsFromReqNo";
            objList.HandleMasterForEditDetails = JsonSerializer.Deserialize<HandleMasterForEdit>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));


            return View(objList);
        }
        //change-note-label-details
        public IActionResult Changenotepackingmaterialdetails()
        {
            return View();
        }
        public IActionResult Changenotelabeldetails()
        {
            return View();
        }
        //change-note-other-packing-details.html
        public async Task<IActionResult> Changenoteotherpackingdetails(int ReqValue)
        {
            ViewBag.NewReqNo = ReqValue;
            ItemMaster ItemMasters = new ItemMaster();
            string apiEndPointCustomer = "ItemMaster/GetLookupData";
            ItemMasters.LookupTypes_List = JsonSerializer.Deserialize<LookupTypes[]>(await _iGenericMethods.GetDataEcm(apiEndPointCustomer));

            ItemMasters.TangTempering_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Tang Tempering").OrderBy(lookup => lookup.LookupValue).ToArray();

            ItemMasters.TangColor_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Tang Color").OrderBy(lookup => lookup.LookupValue).ToArray();

            ItemMasters.Blackodising_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Blackodising").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.QualitySeal_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Quality Seal").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.LineNo_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Line No").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.Hologram_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Hologram").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.PriceSticker_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Price Sticker").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.MadeInIndia_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Made In India").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.PolytheneBag_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Polythene Bag").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.SilicaGel_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Silica Gel").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.Fumigation_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Fumigation").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.PromotionalItem_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Promotional Item").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.Strap_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Strap").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.CelloTape_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Cello Tape").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.ShrinkWrap_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Shrink Wrap").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.Paperwool_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Paperwool").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.PONO_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "PO NO").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.PreInspection_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Pre Inspection").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.Stencil_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Stencil").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.InsertQualityCard_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Insert Quality Card").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.BarCodeWrapper1_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Bar Code Wrapper 1").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.BarCodeWrapper2_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Bar Code Wrapper 2").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.BarCodeInner_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Bar Code Inner").OrderBy(lookup => lookup.LookupValue).ToArray();
            ItemMasters.BarCodeOuter_List = ItemMasters.LookupTypes_List.Where(lookup => lookup.LookupType == "Bar Code Outer").OrderBy(lookup => lookup.LookupValue).ToArray();

            string jsonData;
            string apiEndPoint;

            if (ReqValue > 0)
            {
                var ProdJson = new { RequestNo = ReqValue };
                jsonData = JsonSerializer.Serialize(ProdJson);
                apiEndPoint = "changeNote/GetProductionDetailsFromReqNo";
                ItemMasters.ProductionDetails_List = JsonSerializer.Deserialize<ProductionDetails>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));
            }


            var json = new { RequestNo = ReqValue, TabName = "OtherPacking" };
            jsonData = JsonSerializer.Serialize(json);
            apiEndPoint = "changeNote/GetDispatchDetailsFromReqNo";
            ItemMasters.OtherPackingForEditDetails = JsonSerializer.Deserialize<OtherPackingForEdit>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));

            return View(ItemMasters);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateSKURequestApprovalStatus(string JsonData)
        {
            string apiEndPoint = "changeNote/UpdateSKURequestApprovalStatus";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<ActionResult> UpdateSKUStatusOnChangeNote(string JsonData)
        {
            string apiEndPoint = "changeNote/UpdateSKUStatusOnChangeNote";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        
        [HttpPost]
        public async Task<ActionResult> GetRequestApprovalList(string JsonData)
        {
            string apiEndPoint = "changeNote/GetRequestApprovalList";
            var ApprovalList = JsonSerializer.Deserialize<ApprovalList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { ApprovalList });
        }


        [HttpPost]
        public async Task<ActionResult> SubmitRequestTrigger(string JsonData,string RequestId)
        {
            string apiEndPoint = "changeNote/SubmitRequestTrigger";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "", UserEmailID="";
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

                string labelToSearch = "btnsubmitrequestforapproval";
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
                        subject = "Request #" + RequestId + " is Submitted for Approval",
                        headerLine1 = "Request #" + RequestId + " is Submitted for Approval",
                        subHeaderLine1 = (string)null,
                        message = (string)null,
                        disclaimerText = (string)null,
                    },

                    tagTableValuesJson = new
                    {
                        RequestId = RequestId,
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
    }
}
