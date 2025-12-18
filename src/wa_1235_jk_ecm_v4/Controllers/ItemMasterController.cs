
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using wa_1235_jk_ecm_v4.Interface;
using wa_1235_jk_ecm_v4.Models;
using wa_1235_jk_ecm_v4.Models.DecintellCommon;
using static wa_1235_jk_ecm_v4.Models.Master;



namespace wa_1235_jk_ecm_v4.Controllers
{
    public class ItemMasterController : Controller
    {

        private readonly IGenericMethods _iGenericMethods;
        private readonly IAppSettingsService _appSettingsService;
        public static DecintellSettings? appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ItemMasterController(IGenericMethods iGenericMethods, IAppSettingsService appSettingsService, IHttpContextAccessor httpContextAccessor)
        {
            _iGenericMethods = iGenericMethods;
            _appSettingsService = appSettingsService;
            appSettings = _appSettingsService.GetAppSettings();
            _httpContextAccessor = httpContextAccessor;
        }


        private string JwtToken => _httpContextAccessor.HttpContext.Request.Cookies["1231_AccessToken"];
        public async Task<IActionResult> PackingMaterialDetails(string Mode, int ReqValue)
        {
            ViewBag.NewReqNo = ReqValue;
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ItemMaster objList = new ItemMaster();
            string apiEndPoint = "ItemMaster/GetCategoryList";
            objList.CategoryList = JsonSerializer.Deserialize<CategoryList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            var json = new { RequestedId = ReqValue };
            string jsonData = JsonSerializer.Serialize(json);
            apiEndPoint = "ItemMaster/GetPackingMaterialList";
            objList.PackingMaterialLists = JsonSerializer.Deserialize<PackingMaterialList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));

            string apiEndPointCustomer = "ItemMaster/GetCustomerMaster";
            objList.ecm_CustomerMaster = JsonSerializer.Deserialize<CustomerMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPointCustomer));

            string apiEndBrandPoint = "ItemMaster/GetBrandMaster";
            objList.ecm_BrandMaster = JsonSerializer.Deserialize<BrandMaster[]>(await _iGenericMethods.GetDataEcm(apiEndBrandPoint));


            if (ReqValue > 0)
            {
                var json1 = new { RequestNo = ReqValue };
                string jsonData1 = JsonSerializer.Serialize(json1);
                apiEndPoint = "changeNote/GetProductionDetailsFromReqNo";
                objList.ProductionDetails_List = JsonSerializer.Deserialize<ProductionDetails>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData1));

            }
            return View(objList);
        }


        public async Task<ActionResult> ItemMasterIndex()
        {
            ItemMaster objMaster = new ItemMaster();
            string apiEndPointCustomer = "ItemMaster/GetItemMasterApprovedSKUList";
            objMaster.ApprovedSKUDetails_List = JsonSerializer.Deserialize<ApprovedSKUDetails[]>(await _iGenericMethods.GetDataEcm(apiEndPointCustomer));
          
            return View(objMaster);
        }
        public async Task<ActionResult> Productiondetails(string Mode, int ReqValue)
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.API_ECM_1231 = appSettings?.API_ECM_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ItemMaster ItemMasters = new ItemMaster();
            string apiEndPointCustomer = "ItemMaster/GetCustomerMaster";
            ItemMasters.ecm_CustomerMaster = JsonSerializer.Deserialize<CustomerMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPointCustomer)).OrderBy(b => b.CustomerName).ToArray();

            string apiEndBrandPoint = "ItemMaster/GetBrandMaster";
            ItemMasters.ecm_BrandMaster = JsonSerializer.Deserialize<BrandMaster[]>(await _iGenericMethods.GetDataEcm(apiEndBrandPoint)).OrderBy(b => b.BrandName).ToArray();

            string apiEndFileType = "ItemMaster/GetFileTypeMaster";
            ItemMasters.FileType_List = JsonSerializer.Deserialize<FileType[]>(await _iGenericMethods.GetDataEcm(apiEndFileType)).OrderBy(b => b.FileTypeName).ToArray();


            var fileType_List = ItemMasters.FileType_List;
            // Add the "Add New" option
            var lstFileType = fileType_List.ToList();
            lstFileType.Insert(0, new FileType { Id = -1, FileTypeName = "Add New" });
            ItemMasters.FileType_List = lstFileType.ToArray(); // Convert List back to array


            string apiEndSubFileType = "Masters/GetSubFileTypes";
            ItemMasters.FileSubType_List = JsonSerializer.Deserialize<FileSubTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndSubFileType));

            string apiEndPointSileSize = "Masters/GetSizeMinMax";
            ItemMasters.FileSizes_List = JsonSerializer.Deserialize<FileSizes[]>(await _iGenericMethods.GetDataEcm(apiEndPointSileSize));

            //var fileSize_List = JsonSerializer.Deserialize<FileSizes[]>(await _iGenericMethods.GetDataEcm(apiEndSubFileType));
            var fileSize_List = ItemMasters.FileSizes_List;
            // Add the "Add New" option
            var lstFileSize = fileSize_List.ToList();
            lstFileSize.Insert(0, new FileSizes { FileSizeCode = "-1", FileSizeInch1 = "Add New" });
            ItemMasters.FileSizes_List = lstFileSize.ToArray(); // Convert List back to array




            string apiEndPointCutStandard = "Masters/GetCutSpecificationsList";
            ItemMasters.CutSpecification_List = JsonSerializer.Deserialize<CutSpecificationsList[]>(await _iGenericMethods.GetDataEcm(apiEndPointCutStandard));

            string apiEndPointShipToCountry = "Masters/GetShipToCountry";
            ItemMasters.ShipToCountry_List = JsonSerializer.Deserialize<ShipToCountryList[]>(await _iGenericMethods.GetDataEcm(apiEndPointShipToCountry));

            string apiEndPointCutType = "Masters/GetCutType";
            ItemMasters.CutTypelist = JsonSerializer.Deserialize<CutType[]>(await _iGenericMethods.GetDataEcm(apiEndPointCutType));

            if (!string.IsNullOrEmpty(Mode))
            {
                var json = new { RequestNo = ReqValue };
                string jsonData = JsonSerializer.Serialize(json);
                string apiEndPoint = "changeNote/GetProductionDetailsFromReqNo";
                ItemMasters.ProductionDetails_List = JsonSerializer.Deserialize<ProductionDetails>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));

                var json1 = new
                {
                    FileSizeCode = ItemMasters.ProductionDetails_List.FileSizeCode,
                    FileTypeCodesRowId = ItemMasters.ProductionDetails_List.FileTypeCodeId,
                    FileSubTypeDetailsRowId = ItemMasters.ProductionDetails_List.FileSubType,
                    CutTypeCodeId = ItemMasters.ProductionDetails_List.CutType,
                    CutSpecDetailsRowId = ItemMasters.ProductionDetails_List.CutStandard
                };
                jsonData = JsonSerializer.Serialize(json1);
                apiEndPoint = "ItemMaster/GetProdSKUKeyFromId";
                var ProdSKU = JsonSerializer.Deserialize<UpdateResponse[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));

                if (ProdSKU != null && ProdSKU.Any())
                {
                    ViewBag.ProdSKU = ProdSKU[0].Result;
                }
                else
                {
                    ViewBag.ProdSKU = "";
                }
            }
            return View(ItemMasters);
        }

       
        public async Task<ActionResult> Dispatchdetails(string Mode, int ReqValue)
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ViewBag.NewReqNo = ReqValue;
            ItemMaster ItemMasters = new ItemMaster();
            string apiEndPointCustomer = "ItemMaster/GetStampMaster";
            ItemMasters.StampMaster_List = JsonSerializer.Deserialize<StampMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPointCustomer)).OrderBy(b => b.BrandName).ToArray();

            string apiEndPointCutType = "Masters/GetStampProcess";
            ItemMasters.StampProcesslist = JsonSerializer.Deserialize<CutType[]>(await _iGenericMethods.GetDataEcm(apiEndPointCutType)).OrderBy(b => b.LookupValue).ToArray();
            string jsonData;
            string apiEndPoint;

            if (ReqValue > 0)
            {
                var ProdJson = new { RequestNo = ReqValue };
                jsonData = JsonSerializer.Serialize(ProdJson);
                apiEndPoint = "changeNote/GetProductionDetailsFromReqNo";
                ItemMasters.ProductionDetails_List = JsonSerializer.Deserialize<ProductionDetails>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));
            }

            if (!string.IsNullOrEmpty(Mode))  //added by mayuri 16 jul 2024
            {

                var json = new { RequestNo = ReqValue, TabName = "Stamp" };
                jsonData = JsonSerializer.Serialize(json);
                apiEndPoint = "changeNote/GetDispatchDetailsFromReqNo";
                ItemMasters.StampMasterDispatchDetails = JsonSerializer.Deserialize<StampMaster>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));


            }
            return View(ItemMasters);
        }


        public async Task<IActionResult> ShowLabelLayout(int ReqValue)
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ViewBag.NewReqNo = ReqValue;

            ItemMaster ItemMasters = new ItemMaster();

            if (ReqValue > 0)  //added by mayuri 16 jul 2024
            {
                var json = new { RequestNo = ReqValue };
                string jsonData = JsonSerializer.Serialize(json);
                string apiEndPoint = "changeNote/GetProductionDetailsFromReqNo";
                ItemMasters.ProductionDetails_List = JsonSerializer.Deserialize<ProductionDetails>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));


                var jsonDispatch = new { RequestNo = ReqValue, TabName = "Stamp" };
                jsonData = JsonSerializer.Serialize(jsonDispatch);

                apiEndPoint = "changeNote/GetDispatchDetailsFromReqNo";
                var stampStream = await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData);

                string stampResponse = "";
                using (var reader = new StreamReader(stampStream))
                {
                    stampResponse = await reader.ReadToEndAsync();
                }

                // 🔥 FIX: handle null, empty, {}, [] safely
                if (string.IsNullOrWhiteSpace(stampResponse) ||
                    stampResponse.Trim() == "{}" ||
                    stampResponse.Trim() == "[]" ||
                    stampResponse.Trim() == "null")
                {
                    ItemMasters.StampMasterDispatchDetails = new StampMaster();
                }
                else
                {
                    ItemMasters.StampMasterDispatchDetails =
                        JsonSerializer.Deserialize<StampMaster>(stampResponse) ?? new StampMaster();
                }
                var jsonDispatchHandle = new { RequestNo = ReqValue, TabName = "Handle" };
                jsonData = JsonSerializer.Serialize(jsonDispatchHandle);

                var handleStream = await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData);

                string handleResponse = "";
                using (var reader = new StreamReader(handleStream))
                {
                    handleResponse = await reader.ReadToEndAsync();
                }

                // 🔥 FIX: handle null, empty, {}, [] safely
                if (string.IsNullOrWhiteSpace(handleResponse) ||
                    handleResponse.Trim() == "{}" ||
                    handleResponse.Trim() == "[]" ||
                    handleResponse.Trim() == "null")
                {
                    ItemMasters.HandleMasterForEditDetails = new HandleMasterForEdit();
                }
                else
                {
                    ItemMasters.HandleMasterForEditDetails =
                        JsonSerializer.Deserialize<HandleMasterForEdit>(handleResponse) ?? new HandleMasterForEdit();
                }


               

                var jsonOtherPacking = new { RequestNo = ReqValue, TabName = "OtherPacking" };
                string jsonOtherPackingData = JsonSerializer.Serialize(jsonOtherPacking);
                apiEndPoint = "changeNote/GetDispatchDetailsFromReqNo";
                ItemMasters.OtherPackingForEditDetails = JsonSerializer.Deserialize<OtherPackingForEdit>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonOtherPackingData));

                var ReqIdJson = new { RequestId = ReqValue, Flag = "Packing" };
                string JsonData = JsonSerializer.Serialize(ReqIdJson);
                apiEndPoint = "ItemMaster/GetPackingDetailsForViewLL";
                ItemMasters.PackingDetailsList = JsonSerializer.Deserialize<PackingDetails[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

                ItemMasters.Wrapper1Details = new WrapperDetails();
                ItemMasters.Wrapper2Details = new WrapperDetails();
                ItemMasters.InnerboxDetails = new WrapperDetails();
                ItemMasters.OuterboxDetails = new WrapperDetails();
                ItemMasters.OuterDetails = new WrapperDetails();
                ItemMasters.PalletDetails = new WrapperDetails();


                if (ItemMasters.PackingDetailsList != null)
                {
                    foreach (var item in ItemMasters.PackingDetailsList)
                    {
                        if (item.CategoryName == "Wrapper1")
                        {
                            ItemMasters.Wrapper1Details.MaterialSampleBox = item.MaterialSampleBox;
                            ItemMasters.Wrapper1Details.MaterialArtwork = item.MaterialArtwork;
                            ItemMasters.Wrapper1Details.QtyOfContains = item.QtyOfContains;
                            ItemMasters.Wrapper1Details.MaterialClassName = item.MaterialClassName;
                            ItemMasters.Wrapper1Details.CustomerCode = item.CustomerCode;
                            ItemMasters.Wrapper1Details.BrandCode = item.BrandCode;
                            ItemMasters.Wrapper1Details.TxnRequestId = item.TxnRequestId;
                            ItemMasters.Wrapper1Details.CategoryName = item.CategoryName;
                            ItemMasters.Wrapper1Details.DimensionList = item.DimensionList;
                            ItemMasters.Wrapper1Details.PackingDrawingImage = item.PackingDrawingImage;
                            ItemMasters.Wrapper1Details.MaterialPantone = item.MaterialPantone;
                        }
                        if (item.CategoryName == "Wrapper2")
                        {
                            ItemMasters.Wrapper2Details.MaterialSampleBox = item.MaterialSampleBox;
                            ItemMasters.Wrapper2Details.MaterialArtwork = item.MaterialArtwork;
                            ItemMasters.Wrapper2Details.QtyOfContains = item.QtyOfContains;
                            ItemMasters.Wrapper2Details.MaterialClassName = item.MaterialClassName;
                            ItemMasters.Wrapper2Details.CustomerCode = item.CustomerCode;
                            ItemMasters.Wrapper2Details.BrandCode = item.BrandCode;
                            ItemMasters.Wrapper2Details.TxnRequestId = item.TxnRequestId;
                            ItemMasters.Wrapper2Details.CategoryName = item.CategoryName;
                            ItemMasters.Wrapper2Details.DimensionList = item.DimensionList;
                            ItemMasters.Wrapper2Details.PackingDrawingImage = item.PackingDrawingImage;
                            ItemMasters.Wrapper2Details.MaterialPantone = item.MaterialPantone;
                        }
                        if (item.CategoryName == "InnerBox")
                        {
                            ItemMasters.InnerboxDetails.MaterialSampleBox = item.MaterialSampleBox;
                            ItemMasters.InnerboxDetails.MaterialArtwork = item.MaterialArtwork;
                            ItemMasters.InnerboxDetails.QtyOfContains = item.QtyOfContains;
                            ItemMasters.InnerboxDetails.MaterialClassName = item.MaterialClassName;
                            ItemMasters.InnerboxDetails.CustomerCode = item.CustomerCode;
                            ItemMasters.InnerboxDetails.BrandCode = item.BrandCode;
                            ItemMasters.InnerboxDetails.TxnRequestId = item.TxnRequestId;
                            ItemMasters.InnerboxDetails.CategoryName = item.CategoryName;
                            ItemMasters.InnerboxDetails.DimensionList = item.DimensionList;
                            ItemMasters.InnerboxDetails.PackingDrawingImage = item.PackingDrawingImage;
                            ItemMasters.InnerboxDetails.MaterialPantone = item.MaterialPantone;
                        }
                        if (item.CategoryName == "OuterBox")
                        {
                            ItemMasters.OuterboxDetails.MaterialSampleBox = item.MaterialSampleBox;
                            ItemMasters.OuterboxDetails.MaterialArtwork = item.MaterialArtwork;
                            ItemMasters.OuterboxDetails.QtyOfContains = item.QtyOfContains;
                            ItemMasters.OuterboxDetails.MaterialClassName = item.MaterialClassName;
                            ItemMasters.OuterboxDetails.CustomerCode = item.CustomerCode;
                            ItemMasters.OuterboxDetails.BrandCode = item.BrandCode;
                            ItemMasters.OuterboxDetails.TxnRequestId = item.TxnRequestId;
                            ItemMasters.OuterboxDetails.CategoryName = item.CategoryName;
                            ItemMasters.OuterboxDetails.DimensionList = item.DimensionList;
                            ItemMasters.OuterboxDetails.PackingDrawingImage = item.PackingDrawingImage;
                            ItemMasters.OuterboxDetails.MaterialPantone = item.MaterialPantone;
                        }
                        if (item.CategoryName == "Outer")
                        {
                            ItemMasters.OuterDetails.MaterialSampleBox = item.MaterialSampleBox;
                            ItemMasters.OuterDetails.MaterialArtwork = item.MaterialArtwork;
                            ItemMasters.OuterDetails.QtyOfContains = item.QtyOfContains;
                            ItemMasters.OuterDetails.MaterialClassName = item.MaterialClassName;
                            ItemMasters.OuterDetails.CustomerCode = item.CustomerCode;
                            ItemMasters.OuterDetails.BrandCode = item.BrandCode;
                            ItemMasters.OuterDetails.TxnRequestId = item.TxnRequestId;
                            ItemMasters.OuterDetails.CategoryName = item.CategoryName;
                            ItemMasters.OuterDetails.DimensionList = item.DimensionList;
                            ItemMasters.OuterDetails.PackingDrawingImage = item.PackingDrawingImage;
                            ItemMasters.OuterDetails.MaterialPantone = item.MaterialPantone;
                        }
                        if (item.CategoryName == "Pallet")
                        {
                            ItemMasters.PalletDetails.MaterialSampleBox = item.MaterialSampleBox;
                            ItemMasters.PalletDetails.MaterialArtwork = item.MaterialArtwork;
                            ItemMasters.PalletDetails.QtyOfContains = item.QtyOfContains;
                            ItemMasters.PalletDetails.MaterialClassName = item.MaterialClassName;
                            ItemMasters.PalletDetails.CustomerCode = item.CustomerCode;
                            ItemMasters.PalletDetails.BrandCode = item.BrandCode;
                            ItemMasters.PalletDetails.TxnRequestId = item.TxnRequestId;
                            ItemMasters.PalletDetails.CategoryName = item.CategoryName;
                            ItemMasters.PalletDetails.DimensionList = item.DimensionList;
                            ItemMasters.PalletDetails.PackingDrawingImage = item.PackingDrawingImage;
                            ItemMasters.PalletDetails.MaterialPantone = item.MaterialPantone;
                        }
                    }
                }


                ReqIdJson = new { RequestId = ReqValue, Flag = "Label" };
                JsonData = JsonSerializer.Serialize(ReqIdJson);
                apiEndPoint = "ItemMaster/GetPackingDetailsForViewLL";
                ItemMasters.LabelDetailsList = JsonSerializer.Deserialize<LabelDetails[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));


                var DimJson = new { RequestId = ReqValue, Flag = "Dimension" };
                 JsonData = JsonSerializer.Serialize(DimJson);
                apiEndPoint = "ItemMaster/GetPackingDetailsForViewLL";
                ItemMasters.MaterialDimensionsList = JsonSerializer.Deserialize<MaterialDimensions[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

                if (ItemMasters.ProductionDetails_List.ReqType == "S" || ItemMasters.ProductionDetails_List.ReqType == "R")
                {
                    apiEndPoint = "ItemMaster/GetDetailsForSKUSet";
                    ItemMasters.SKUSetList = JsonSerializer.Deserialize<SKUSet[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));

                }
            }
            return View(ItemMasters);
        }
        public async Task<IActionResult> ViewLabelLayout(int ReqValue)
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ViewBag.NewReqNo = ReqValue;

            ItemMaster ItemMasters = new ItemMaster();

            if (ReqValue > 0)  //added by mayuri 16 jul 2024
            {
                var json = new { RequestNo = ReqValue };
                string jsonData = JsonSerializer.Serialize(json);
                string apiEndPoint = "changeNote/GetProductionDetailsFromReqNo";
                ItemMasters.ProductionDetails_List = JsonSerializer.Deserialize<ProductionDetails>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));


                //var jsonDispatch = new { RequestNo = ReqValue, TabName = "Stamp" };
                //jsonData = JsonSerializer.Serialize(jsonDispatch);
                //apiEndPoint = "changeNote/GetDispatchDetailsFromReqNo";
                //ItemMasters.StampMasterDispatchDetails = JsonSerializer.Deserialize<StampMaster>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));


                //var jsonDispatchHandle = new { RequestNo = ReqValue, TabName = "Handle" };
                //jsonData = JsonSerializer.Serialize(jsonDispatchHandle);
                //apiEndPoint = "changeNote/GetDispatchDetailsFromReqNo";
                //ItemMasters.HandleMasterForEditDetails = JsonSerializer.Deserialize<HandleMasterForEdit>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));
                var jsonDispatch = new { RequestNo = ReqValue, TabName = "Stamp" };
                jsonData = JsonSerializer.Serialize(jsonDispatch);

                apiEndPoint = "changeNote/GetDispatchDetailsFromReqNo";
                var stampStream = await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData);

                string stampResponse = "";
                using (var reader = new StreamReader(stampStream))
                {
                    stampResponse = await reader.ReadToEndAsync();
                }

                // 🔥 FIX: handle null, empty, {}, [] safely
                if (string.IsNullOrWhiteSpace(stampResponse) ||
                    stampResponse.Trim() == "{}" ||
                    stampResponse.Trim() == "[]" ||
                    stampResponse.Trim() == "null")
                {
                    ItemMasters.StampMasterDispatchDetails = new StampMaster();
                }
                else
                {
                    ItemMasters.StampMasterDispatchDetails =
                        JsonSerializer.Deserialize<StampMaster>(stampResponse) ?? new StampMaster();
                }
                var jsonDispatchHandle = new { RequestNo = ReqValue, TabName = "Handle" };
                jsonData = JsonSerializer.Serialize(jsonDispatchHandle);

                var handleStream = await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData);

                string handleResponse = "";
                using (var reader = new StreamReader(handleStream))
                {
                    handleResponse = await reader.ReadToEndAsync();
                }

                // 🔥 FIX: handle null, empty, {}, [] safely
                if (string.IsNullOrWhiteSpace(handleResponse) ||
                    handleResponse.Trim() == "{}" ||
                    handleResponse.Trim() == "[]" ||
                    handleResponse.Trim() == "null")
                {
                    ItemMasters.HandleMasterForEditDetails = new HandleMasterForEdit();
                }
                else
                {
                    ItemMasters.HandleMasterForEditDetails =
                        JsonSerializer.Deserialize<HandleMasterForEdit>(handleResponse) ?? new HandleMasterForEdit();
                }



                var jsonOtherPacking = new { RequestNo = ReqValue, TabName = "OtherPacking" };
                string jsonOtherPackingData = JsonSerializer.Serialize(jsonOtherPacking);
                apiEndPoint = "changeNote/GetDispatchDetailsFromReqNo";
                ItemMasters.OtherPackingForEditDetails = JsonSerializer.Deserialize<OtherPackingForEdit>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonOtherPackingData));

                var ReqIdJson = new { RequestId = ReqValue, Flag = "Packing" };
                string JsonData = JsonSerializer.Serialize(ReqIdJson);
                apiEndPoint = "ItemMaster/GetPackingDetailsForViewLL";
                ItemMasters.PackingDetailsList = JsonSerializer.Deserialize<PackingDetails[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

                ItemMasters.Wrapper1Details = new WrapperDetails();
                ItemMasters.Wrapper2Details = new WrapperDetails();
                ItemMasters.InnerboxDetails = new WrapperDetails();
                ItemMasters.OuterboxDetails = new WrapperDetails();
                ItemMasters.OuterDetails = new WrapperDetails();
                ItemMasters.PalletDetails = new WrapperDetails();


                if (ItemMasters.PackingDetailsList != null)
                {
                    foreach (var item in ItemMasters.PackingDetailsList)
                    {
                        if (item.CategoryName == "Wrapper1")
                        {
                            ItemMasters.Wrapper1Details.MaterialSampleBox = item.MaterialSampleBox;
                            ItemMasters.Wrapper1Details.MaterialArtwork = item.MaterialArtwork;
                            ItemMasters.Wrapper1Details.QtyOfContains = item.QtyOfContains;
                            ItemMasters.Wrapper1Details.MaterialClassName = item.MaterialClassName;
                            ItemMasters.Wrapper1Details.CustomerCode = item.CustomerCode;
                            ItemMasters.Wrapper1Details.BrandCode = item.BrandCode;
                            ItemMasters.Wrapper1Details.TxnRequestId = item.TxnRequestId;
                            ItemMasters.Wrapper1Details.CategoryName = item.CategoryName;
                            ItemMasters.Wrapper1Details.DimensionList = item.DimensionList;
                            ItemMasters.Wrapper1Details.PackingDrawingImage = item.PackingDrawingImage;
                            ItemMasters.Wrapper1Details.MaterialPantone = item.MaterialPantone;
                        }
                        if (item.CategoryName == "Wrapper2")
                        {
                            ItemMasters.Wrapper2Details.MaterialSampleBox = item.MaterialSampleBox;
                            ItemMasters.Wrapper2Details.MaterialArtwork = item.MaterialArtwork;
                            ItemMasters.Wrapper2Details.QtyOfContains = item.QtyOfContains;
                            ItemMasters.Wrapper2Details.MaterialClassName = item.MaterialClassName;
                            ItemMasters.Wrapper2Details.CustomerCode = item.CustomerCode;
                            ItemMasters.Wrapper2Details.BrandCode = item.BrandCode;
                            ItemMasters.Wrapper2Details.TxnRequestId = item.TxnRequestId;
                            ItemMasters.Wrapper2Details.CategoryName = item.CategoryName;
                            ItemMasters.Wrapper2Details.DimensionList = item.DimensionList;
                            ItemMasters.Wrapper2Details.PackingDrawingImage = item.PackingDrawingImage;
                            ItemMasters.Wrapper2Details.MaterialPantone = item.MaterialPantone;
                        }
                        if (item.CategoryName == "InnerBox")
                        {
                            ItemMasters.InnerboxDetails.MaterialSampleBox = item.MaterialSampleBox;
                            ItemMasters.InnerboxDetails.MaterialArtwork = item.MaterialArtwork;
                            ItemMasters.InnerboxDetails.QtyOfContains = item.QtyOfContains;
                            ItemMasters.InnerboxDetails.MaterialClassName = item.MaterialClassName;
                            ItemMasters.InnerboxDetails.CustomerCode = item.CustomerCode;
                            ItemMasters.InnerboxDetails.BrandCode = item.BrandCode;
                            ItemMasters.InnerboxDetails.TxnRequestId = item.TxnRequestId;
                            ItemMasters.InnerboxDetails.CategoryName = item.CategoryName;
                            ItemMasters.InnerboxDetails.DimensionList = item.DimensionList;
                            ItemMasters.InnerboxDetails.PackingDrawingImage = item.PackingDrawingImage;
                            ItemMasters.InnerboxDetails.MaterialPantone = item.MaterialPantone;
                        }
                        if (item.CategoryName == "OuterBox")
                        {
                            ItemMasters.OuterboxDetails.MaterialSampleBox = item.MaterialSampleBox;
                            ItemMasters.OuterboxDetails.MaterialArtwork = item.MaterialArtwork;
                            ItemMasters.OuterboxDetails.QtyOfContains = item.QtyOfContains;
                            ItemMasters.OuterboxDetails.MaterialClassName = item.MaterialClassName;
                            ItemMasters.OuterboxDetails.CustomerCode = item.CustomerCode;
                            ItemMasters.OuterboxDetails.BrandCode = item.BrandCode;
                            ItemMasters.OuterboxDetails.TxnRequestId = item.TxnRequestId;
                            ItemMasters.OuterboxDetails.CategoryName = item.CategoryName;
                            ItemMasters.OuterboxDetails.DimensionList = item.DimensionList;
                            ItemMasters.OuterboxDetails.PackingDrawingImage = item.PackingDrawingImage;
                            ItemMasters.OuterboxDetails.MaterialPantone = item.MaterialPantone;
                        }
                        if (item.CategoryName == "Outer")
                        {
                            ItemMasters.OuterDetails.MaterialSampleBox = item.MaterialSampleBox;
                            ItemMasters.OuterDetails.MaterialArtwork = item.MaterialArtwork;
                            ItemMasters.OuterDetails.QtyOfContains = item.QtyOfContains;
                            ItemMasters.OuterDetails.MaterialClassName = item.MaterialClassName;
                            ItemMasters.OuterDetails.CustomerCode = item.CustomerCode;
                            ItemMasters.OuterDetails.BrandCode = item.BrandCode;
                            ItemMasters.OuterDetails.TxnRequestId = item.TxnRequestId;
                            ItemMasters.OuterDetails.CategoryName = item.CategoryName;
                            ItemMasters.OuterDetails.DimensionList = item.DimensionList;
                            ItemMasters.OuterDetails.PackingDrawingImage = item.PackingDrawingImage;
                            ItemMasters.OuterDetails.MaterialPantone = item.MaterialPantone;
                        }
                        if (item.CategoryName == "Pallet")
                        {
                            ItemMasters.PalletDetails.MaterialSampleBox = item.MaterialSampleBox;
                            ItemMasters.PalletDetails.MaterialArtwork = item.MaterialArtwork;
                            ItemMasters.PalletDetails.QtyOfContains = item.QtyOfContains;
                            ItemMasters.PalletDetails.MaterialClassName = item.MaterialClassName;
                            ItemMasters.PalletDetails.CustomerCode = item.CustomerCode;
                            ItemMasters.PalletDetails.BrandCode = item.BrandCode;
                            ItemMasters.PalletDetails.TxnRequestId = item.TxnRequestId;
                            ItemMasters.PalletDetails.CategoryName = item.CategoryName;
                            ItemMasters.PalletDetails.DimensionList = item.DimensionList;
                            ItemMasters.PalletDetails.PackingDrawingImage = item.PackingDrawingImage;
                            ItemMasters.PalletDetails.MaterialPantone = item.MaterialPantone;
                        }
                    }
                }


                ReqIdJson = new { RequestId = ReqValue, Flag = "Label" };
                JsonData = JsonSerializer.Serialize(ReqIdJson);
                apiEndPoint = "ItemMaster/GetPackingDetailsForViewLL";
                ItemMasters.LabelDetailsList = JsonSerializer.Deserialize<LabelDetails[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));


                var DimJson = new { RequestId = ReqValue, Flag = "Dimension" };
                 JsonData = JsonSerializer.Serialize(DimJson);
                apiEndPoint = "ItemMaster/GetPackingDetailsForViewLL";
                ItemMasters.MaterialDimensionsList = JsonSerializer.Deserialize<MaterialDimensions[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

                if (ItemMasters.ProductionDetails_List.ReqType == "S"  || ItemMasters.ProductionDetails_List.ReqType == "R")
                {
                    apiEndPoint = "ItemMaster/GetDetailsForSKUSet";
                    ItemMasters.SKUSetList = JsonSerializer.Deserialize<SKUSet[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));

                }
            }
            return View(ItemMasters);
        }



        public async Task<ActionResult> Handle(string Mode, int ReqValue)
        {
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ViewBag.NewReqNo = ReqValue;
            ItemMaster ItemMasters = new ItemMaster();
            string apiEndPointCustomer = "ItemMaster/GetHandleType";
            ItemMasters.HandleTypeList = JsonSerializer.Deserialize<HandleTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPointCustomer));

            string apiEndPointCutType = "Masters/GetHandlePresence";
            ItemMasters.HandlePresencelist = JsonSerializer.Deserialize<CutType[]>(await _iGenericMethods.GetDataEcm(apiEndPointCutType));
            string jsonData;
            string apiEndPoint;

            if (ReqValue > 0)
            {
                var ProdJson = new { RequestNo = ReqValue };
                jsonData = JsonSerializer.Serialize(ProdJson);
                apiEndPoint = "changeNote/GetProductionDetailsFromReqNo";
                ItemMasters.ProductionDetails_List = JsonSerializer.Deserialize<ProductionDetails>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));
            }

            if (!string.IsNullOrEmpty(Mode))  //added by mayuri 16 jul 2024
            {

                var json = new { RequestNo = ReqValue, TabName = "Handle" };
                jsonData = JsonSerializer.Serialize(json);
                apiEndPoint = "changeNote/GetDispatchDetailsFromReqNo";
                ItemMasters.HandleMasterForEditDetails = JsonSerializer.Deserialize<HandleMasterForEdit>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));


            }
            return View(ItemMasters);
        }
     
        [HttpPost]
        public async Task<ActionResult> GetHandleChartData(string JsonData)
        {
            ItemMaster obj = new ItemMaster();
            string apiEndPoint = "ItemMaster/GetHandleChartData";
            obj.HandleTypeList = JsonSerializer.Deserialize<HandleTypeMaster[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return Json(obj);
        }


        [HttpPost]
        public async Task<ActionResult> SaveNewRequest(string JsonData)
        {
            string apiEndPoint = "ItemMaster/SaveNewRequest";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<ActionResult> SaveStampDetails(string JsonData)
        {
            string apiEndPoint = "ItemMaster/SaveStampDetails";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<ActionResult> SaveHandleDetails(string JsonData)
        {
            string apiEndPoint = "ItemMaster/SaveHandleDetails";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }


        [HttpPost]
        public async Task<ActionResult> SaveOtherPackingDetails(string JsonData)
        {
            string apiEndPoint = "ItemMaster/SaveOtherPackingDetails";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }


       
        public IActionResult BulkUpload()
        {

            return View();
        }
        public async Task<ActionResult> Otherpackingdetails(string Mode, int ReqValue)
        {
            ViewBag.NewReqNo = ReqValue;
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;

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

            if (!string.IsNullOrEmpty(Mode))  //added by mayuri 16 jul 2024
            {
                var json = new { RequestNo = ReqValue, TabName = "OtherPacking" };
                jsonData = JsonSerializer.Serialize(json);
                apiEndPoint = "changeNote/GetDispatchDetailsFromReqNo";
                ItemMasters.OtherPackingForEditDetails = JsonSerializer.Deserialize<OtherPackingForEdit>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));


            }

            return View(ItemMasters);
        }
        public IActionResult SKUMastersearch()
        {
            return View();
        }
        //raw-material
        public async Task<ActionResult> comingsoon()
        {
            ItemMaster objMaster = new ItemMaster();
            string apiEndPointCustomer = "ItemMaster/GetComingSoonApprovedSKUList";
            objMaster.ApprovedCommingSKUDetails_List = JsonSerializer.Deserialize<ApprovedCommingSKUDetails[]>(await _iGenericMethods.GetDataEcm(apiEndPointCustomer));

            return View(objMaster);
        }
        public IActionResult Rawmaterial()
        {
            return View();
        }
        public async Task<ActionResult> Requests()
        {
            ItemMaster ItemMasters = new ItemMaster();
            string apiEndPoint = "ItemMaster/GetRecycleBinSKUList";
            ItemMasters.WithdrawnRequestsList = JsonSerializer.Deserialize<WithdrawnRequests[]>(await _iGenericMethods.GetDataEcm(apiEndPoint)).OrderBy(b => b.Id).ToArray();
            return View(ItemMasters);
        }
        public async Task<ActionResult> Newsetproductiondetails(string Mode, int ReqValue)
        {
            ViewBag.NewReqNo = ReqValue;
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ItemMaster ItemMasters = new ItemMaster();
            string apiEndPointCustomer = "ItemMaster/GetCustomerMaster";
            ItemMasters.ecm_CustomerMaster = JsonSerializer.Deserialize<CustomerMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPointCustomer));

            string apiEndBrandPoint = "ItemMaster/GetBrandMaster";
            ItemMasters.ecm_BrandMaster = JsonSerializer.Deserialize<BrandMaster[]>(await _iGenericMethods.GetDataEcm(apiEndBrandPoint));

            string apiEndFileType = "ItemMaster/GetFileTypeMaster";
            ItemMasters.FileType_List = JsonSerializer.Deserialize<FileType[]>(await _iGenericMethods.GetDataEcm(apiEndFileType));

            
            var fileType_List = ItemMasters.FileType_List;
            // Add the "Add New" option
            var lstFileType = fileType_List.ToList();
            lstFileType.Insert(0, new FileType { Id = -1, FileTypeName = "Add New" });
            ItemMasters.FileType_List = lstFileType.ToArray(); // Convert List back to array


            string apiEndSubFileType = "Masters/GetSubFileTypes";
            ItemMasters.FileSubType_List = JsonSerializer.Deserialize<FileSubTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndSubFileType));

            string apiEndPointSileSize = "Masters/GetSizeMinMax";
            ItemMasters.FileSizes_List = JsonSerializer.Deserialize<FileSizes[]>(await _iGenericMethods.GetDataEcm(apiEndPointSileSize));

            //var fileSize_List = JsonSerializer.Deserialize<FileSizes[]>(await _iGenericMethods.GetDataEcm(apiEndSubFileType));
            var fileSize_List = ItemMasters.FileSizes_List;
            // Add the "Add New" option
            var lstFileSize = fileSize_List.ToList();
            lstFileSize.Insert(0, new FileSizes { FileSizeCode = "-1", FileSizeInch1 = "Add New" });
            ItemMasters.FileSizes_List = lstFileSize.ToArray(); // Convert List back to array


           

            string apiEndPointCutStandard = "Masters/GetCutSpecificationsList";
            ItemMasters.CutSpecification_List = JsonSerializer.Deserialize<CutSpecificationsList[]>(await _iGenericMethods.GetDataEcm(apiEndPointCutStandard));

            string apiEndPointShipToCountry = "Masters/GetShipToCountry";
            ItemMasters.ShipToCountry_List = JsonSerializer.Deserialize<ShipToCountryList[]>(await _iGenericMethods.GetDataEcm(apiEndPointShipToCountry));

            string apiEndPointCutType = "Masters/GetCutType";
            ItemMasters.CutTypelist = JsonSerializer.Deserialize<CutType[]>(await _iGenericMethods.GetDataEcm(apiEndPointCutType));

            string apiEndPoint = "ItemMaster/GetDrawingSKU";
            ItemMasters.DrawingNewSetList = JsonSerializer.Deserialize<DrawingNewSet[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            apiEndPoint = "ItemMaster/GetStampMaster";
            ItemMasters.StampMaster_List = JsonSerializer.Deserialize<StampMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            apiEndPoint = "Masters/GetStampProcess";
            ItemMasters.StampProcesslist = JsonSerializer.Deserialize<CutType[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));


            apiEndPoint = "ItemMaster/GetHandleType";
            ItemMasters.HandleTypeList = JsonSerializer.Deserialize<HandleTypeMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            apiEndPoint = "Masters/GetHandlePresence";
            ItemMasters.HandlePresencelist = JsonSerializer.Deserialize<CutType[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));


            if (!string.IsNullOrEmpty(Mode))
            {
                var json = new { RequestNo = ReqValue };
                string jsonData = JsonSerializer.Serialize(json);
                apiEndPoint = "changeNote/GetProductionDetailsFromReqNo";
                ItemMasters.ProductionDetails_List = JsonSerializer.Deserialize<ProductionDetails>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));

                 
                //  apiEndPointCustomer = "ItemMaster/GetDetailsForSKUSet";
                //ItemMasters.SKUSetList = JsonSerializer.Deserialize<SKUSet[]>(await _iGenericMethods.PostDataEcm(apiEndPointCustomer, jsonData));

            }
            return View(ItemMasters);
        }
        public IActionResult Newsetdispatchdetails()
        {
            return View();
        }
        public IActionResult Newsethandle()
        {
            return View();
        }



        public async Task<ActionResult> wrapper(string Mode, int ReqValue)
        {
            ItemMaster ItemMasters = new ItemMaster();
            var json = new { CategoryId = 1 };
            string jsonData = JsonSerializer.Serialize(json);
            string apiEndPoint = "ItemMaster/GetMaterialList";
            ItemMasters.PackingMaterialLists = JsonSerializer.Deserialize<PackingMaterialList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));


            var json1 = new { RequestId = ReqValue };
            jsonData = JsonSerializer.Serialize(json1);
            apiEndPoint = "ItemMaster/GetWrapperDetails";
            ItemMasters.WrapperDrawingSetList = JsonSerializer.Deserialize<WrapperDrawingSet[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));


            return View(ItemMasters);
        }
        public IActionResult Newsetpackingmaterialdetails()
        {
            return View();
        }
        public IActionResult Newsetlabeldetails()
        {
            return View();
        }
        public IActionResult Newsetotherpackingdetails()
        {
            return View();
        }
        //new-set-other-packing-details.html
        [HttpPost]
        public async Task<ActionResult> GetMaterialList(string JsonData)
        {
            string apiEndPoint = "ItemMaster/GetMaterialList";
            var MaterialList = JsonSerializer.Deserialize<MaterialList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { success = true, MaterialList });
        }

        [HttpPost]
        public async Task<ActionResult> GetFileSubType(string JsonData)
        {
            //JsonData is {"FileType":"-1","Filesize":"-1"} 
            string fileType = "", fileSize = "";
            using (JsonDocument doc = JsonDocument.Parse(JsonData))
            {
                JsonElement root = doc.RootElement;
                fileType = root.GetProperty("FileType").GetString();
                fileSize = root.GetProperty("Filesize").GetString();
            }


            ItemMaster obj = new ItemMaster();

            if (fileType == "-1")
            {

                var fileSubType_List = new FileSubTypeMaster[]
                    {
                            new FileSubTypeMaster { Id = -1 , FileSubTypeName =  "Add New" }
                    };
                obj.FileSubType_List = fileSubType_List.ToArray();


                var cutSpecification_List = new CutSpecificationsList[]
                     {
                                new CutSpecificationsList { Id = -1 , CutSpecName =  "Add New" }
                     };
                obj.CutSpecification_List = cutSpecification_List.ToArray();
            }
            else
            {
                string apiEndPoint = "ItemMaster/GetFileSubType";
                obj.FileSubType_List = JsonSerializer.Deserialize<FileSubTypeMaster[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

                var fileSubType_List = obj.FileSubType_List;
                var lstFileSubType = fileSubType_List.ToList();
                lstFileSubType.Insert(0, new FileSubTypeMaster { Id = -1, FileSubTypeName = "Add New" });
                obj.FileSubType_List = lstFileSubType.ToArray();

            }
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> GetCutSpecList(string JsonData)
        {
            //JsonData is {"FileType":"-1","Filesize":"-1"} 
            string fileType = "", fileSize = "", cutType = "";
            using (JsonDocument doc = JsonDocument.Parse(JsonData))
            {
                JsonElement root = doc.RootElement;
                fileType = root.GetProperty("FileType").GetString();
                fileSize = root.GetProperty("Filesize").GetString();
                cutType = root.GetProperty("CutType").GetString();
            }


            ItemMaster obj = new ItemMaster();

            if (fileType == "-1")
            {
                var cutSpecification_List = new CutSpecificationsList[]
                     {
                                new CutSpecificationsList { Id = -1 , CutSpecName =  "Add New" }
                     };
                obj.CutSpecification_List = cutSpecification_List.ToArray();
            }
            else
            {
                string apiEndPoint = "ItemMaster/GetSelectedCutSpecificationsList";
                obj.CutSpecification_List = JsonSerializer.Deserialize<CutSpecificationsList[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

                var cutSpecification_List = obj.CutSpecification_List;
                var lstcutSpecification = cutSpecification_List.ToList();

                // Insert "Select" option at the beginning.
                lstcutSpecification.Insert(0, new CutSpecificationsList { Id = 0, CutSpecName = "Select" });
                // Insert "Add New" option after the "Select" option.
                lstcutSpecification.Insert(1, new CutSpecificationsList { Id = -1, CutSpecName = "Add New" });

                obj.CutSpecification_List = lstcutSpecification.ToArray();

            }
            return Json(obj);
        }


        [HttpPost]
        public async Task<ActionResult> GetDimesionsAttribute(string JsonData)
        {
            string apiEndPoint = "ItemMaster/GetDimesionsAttribute";
            var DimentionAttribute = JsonSerializer.Deserialize<DimentionAttribute[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { success = true, DimentionAttribute });
        }

        [HttpPost]
        public async Task<ActionResult> GetDetailsForSet(string ReqValue)
        {
            ItemMaster ItemMasters = new ItemMaster();
            var json = new { RequestNo = ReqValue };
            string jsonData = JsonSerializer.Serialize(json);
            string apiEndPointCustomer = "ItemMaster/GetDetailsForSKUSet";
            ItemMasters.SKUSetList = JsonSerializer.Deserialize<SKUSet[]>(await _iGenericMethods.PostDataEcm(apiEndPointCustomer, jsonData));
            return Json(new { success = true, ItemMasters.SKUSetList });
        }


        [HttpPost]
        public async Task<ActionResult> GetFileCode(string JsonData)
        {
            string apiEndPoint = "ItemMaster/GetFileCode";
            var DimentionAttribute = JsonSerializer.Deserialize<UpdateResponse[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { success = true, DimentionAttribute });
        }
        [HttpPost]
        public async Task<ActionResult> GetCountryContinent(string JsonData)
        {
            string apiEndPoint = "ItemMaster/GetCountryContinent";
            var CountryContinent = JsonSerializer.Deserialize<UpdateResponse[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { success = true, CountryContinent });
        }

        [HttpPost]
        public async Task<ActionResult> GetCutSideStandard(string JsonData)
        {
            Master objList = new Master();
            string apiEndPoint = "Masters/GetCutSpecificationData";
            objList.CutSpecificationEdit_List = JsonSerializer.Deserialize<CutSpecificationEdit[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return Json(new { objList });
        }

        [HttpPost]
        public async Task<ActionResult> GetFileParameter(string JsonData)
        {
            Master objList = new Master();
            string apiEndPoint = "Masters/GetFileParameter";
            objList.CutSpecParameterslist = JsonSerializer.Deserialize<CutSpecParametersjarr[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return Json(new { objList });
        }


        [HttpPost]
        public async Task<ActionResult> GetDimesionsAttributeList(string JsonData)
        {
            string apiEndPoint = "ItemMaster/GetDimesionsAttributeList";
            var DimentionAttribute = JsonSerializer.Deserialize<dynamic[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { success = true, DimentionAttribute });
        }


        [HttpPost]
        public async Task<ActionResult> AddDimesionsAttribute(string JsonData)
        {
            string apiEndPoint = "ItemMaster/AddDimesionsAttribute";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<ActionResult> AddPackingMaterialDetails(string JsonData)
        {
            string apiEndPoint = "ItemMaster/AddPackingMaterialDetails";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }


        [HttpPost]
        public async Task<ActionResult> AddSampleImage(string JsonData)
        {
            string apiEndPoint = "ItemMaster/AddSampleImage";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<ActionResult> GetSampleImagesList(string JsonData)
        {
            string apiEndPoint = "ItemMaster/GetSampleImagesList";
            var SampleImagesList = JsonSerializer.Deserialize<dynamic[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { success = true, SampleImagesList });
        }

        [HttpPost]
        public async Task<ActionResult> GetArtworkImagesList(string JsonData)
        {
            string apiEndPoint = "ItemMaster/GetArtworkImagesList";
            var ArtworkImagesList = JsonSerializer.Deserialize<dynamic[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { success = true, ArtworkImagesList });
        }

        [HttpPost]
        public async Task<ActionResult> SaveNewSetRequest(string JsonData)
        {
            string apiEndPoint = "ItemMaster/SaveNewSetRequest";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<ActionResult> AddCloneAndAmendRequest(string JsonData)
        {
            string apiEndPoint = "ItemMaster/AddCloneAndAmendRequest";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            int NewTxnRequestId = 0;
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
                NewTxnRequestId = updateResponses[0].NewTxnRequestId;
            }
            return Json(new { response = resultMessage, NewTxnRequestId });
        }


        [HttpPost]
        public async Task<ActionResult> AddCloneAndAmendImagesRequest(string JsonData1)
        {
            string apiEndPoint = "ItemMaster/AddCloneAndAmendImagesRequest";
            var CloneAllImagesLists = JsonSerializer.Deserialize<dynamic>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData1));
            return Json(new { success = true, CloneAllImagesLists });
        }



        [HttpPost]
        public async Task<ActionResult> GetSelectedCelloTape(string JsonData)
        {
            string apiEndPoint = "ItemMaster/GetSelectedCelloTape";
            var CelloTapeImage = JsonSerializer.Deserialize<dynamic[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { success = true, CelloTapeImage });
        }

        [HttpPost]
        public async Task<ActionResult> GetDetailsForSKUSet(string JsonData)
        {
            string apiEndPoint = "ItemMaster/GetDetailsForSKUSet";
            var DimentionAttribute = JsonSerializer.Deserialize<UpdateResponse[]>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            return Json(new { success = true, DimentionAttribute });
        }

        public async Task<ActionResult> ItemMasterArchive()
        {
            Master objMaster = new Master();
            string apiEndPointCustomer = "ItemMaster/GetItemMasterApprovedSKUListArchive";
            objMaster.ApprovedSKUDetails_List = JsonSerializer.Deserialize<ApprovedSKUDetails[]>(await _iGenericMethods.GetDataEcm(apiEndPointCustomer));

            return View(objMaster);
        }

        public async Task<ActionResult> DrawingArchive()
        {

            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ViewBag.ReportBasePath = appSettings?.ReportBasePath;

            Master objList = new Master();
            string apiEndPointSize = "Masters/GetDrawingList";
            objList.Drawing_List = JsonSerializer.Deserialize<Drawing[]>(await _iGenericMethods.GetDataEcm(apiEndPointSize));

            return View(objList);
        }

        public async Task<IActionResult> Labeldetails(string Mode, int ReqValue)
        {
            ViewBag.NewReqNo = ReqValue;
            ViewBag.JWTToken = JwtToken;
            ViewBag.ApiUrl = appSettings?.API_blob_1231;
            ViewBag.BaseBlobPath = appSettings?.BaseBlobPath;
            ItemMaster objList = new ItemMaster();
            string apiEndPoint = "ItemMaster/GetCategoryList";
            objList.CategoryList = JsonSerializer.Deserialize<CategoryList[]>(await _iGenericMethods.GetDataEcm(apiEndPoint));

            string apiEndPointCustomer = "ItemMaster/GetCustomerMaster";
            objList.ecm_CustomerMaster = JsonSerializer.Deserialize<CustomerMaster[]>(await _iGenericMethods.GetDataEcm(apiEndPointCustomer));

            string apiEndBrandPoint = "ItemMaster/GetBrandMaster";
            objList.ecm_BrandMaster = JsonSerializer.Deserialize<BrandMaster[]>(await _iGenericMethods.GetDataEcm(apiEndBrandPoint));

            if (ReqValue > 0)
            {
                var ProdJson = new { RequestNo = ReqValue };
                string jsonData = JsonSerializer.Serialize(ProdJson);
                apiEndPoint = "changeNote/GetProductionDetailsFromReqNo";
                objList.ProductionDetails_List = JsonSerializer.Deserialize<ProductionDetails>(await _iGenericMethods.PostDataEcm(apiEndPoint, jsonData));
            }

            return View(objList);
        }
        [HttpPost]
        public async Task<ActionResult> GetPackingStickerDetails(string JsonData)
        {
            string apiEndPoint = "ItemMaster/GetPackingStickerDetails";
            var PackingStickerDetails = JsonSerializer.Deserialize<dynamic>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return Json(new { success = true, PackingStickerDetails });
        }


        [HttpPost]
        public async Task<ActionResult> GetPackingFilteredImage(string JsonData)
        {
            string apiEndPoint = "ItemMaster/GetPackingFilteredImage";
            var PackingFilteredImages = JsonSerializer.Deserialize<dynamic>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));

            return Json(new { success = true, PackingFilteredImages });
        }

        [HttpPost]
        public async Task<ActionResult> AddPackingSelectedImage(string JsonData)
        {
            string apiEndPoint = "ItemMaster/AddPackingSelectedImage";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }

        [HttpPost]
        public async Task<ActionResult> DeletePackingStickerDetails(string JsonData)
        {
            string apiEndPoint = "ItemMaster/DeletePackingStickerDetails";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
        [HttpPost]
        public async Task<ActionResult> DeletePackingStickerDetailsAll(string JsonData)
        {
            string apiEndPoint = "ItemMaster/DeletePackingStickerDetailsAll";
            var updateResponses = JsonSerializer.Deserialize<List<UpdateResponse>>(await _iGenericMethods.PostDataEcm(apiEndPoint, JsonData));
            string resultMessage = "";
            if (updateResponses != null && updateResponses.Count > 0)
            {
                resultMessage = updateResponses[0].Result;
            }
            return Json(new { response = resultMessage });
        }
        [HttpPost]
        public async Task<ActionResult> DeleteDrawingFromSet(string JsonData)
        {
            string apiEndPoint = "ItemMaster/DeleteDrawingFromSet";
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
