using System.Text;
using System.Text.Json;
using api_1235_jk_ecm_v4.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace api_1235_jk_ecm_v4.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DrillMasterController : Controller
    {
        private readonly DBManager dbManager = new DBManager();
        private readonly ILogger<MastersController> _logger;
        private readonly IConfiguration _configuration;
        public DrillMasterController(ILogger<MastersController> logger, IConfiguration config)
        {
            _logger = logger;
            _configuration = config;
        }
        public string ConnStr => _configuration.GetConnectionString("DefaultConnection");


        [HttpPost]
        [Route("DroAddFileSize")]
        public async Task<IActionResult> DroAddFileSize()
        {

            string spName = "usp_CT_AddFileSize";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        [HttpPost]
        [Route("Add_CT_Size")]
        public async Task<IActionResult> Add_CT_Size()
        {

            string spName = "usp_Add_CT_Size";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        [HttpPost]
        [Route("DroAddFileType")]
        public async Task<IActionResult> DroAddFileType()
        {

            string spName = "usp_CT_AddFileType";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        
        [HttpPost]
        [Route("GetCTSizeDetails")]
        public async Task<IActionResult> GetCTSizeDetails()
        {

            string spName = "usp_CT_GetCTSizeDetails";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        [HttpPost]
        [Route("GetSizeDetailsByTypeAndProductLine")]
        public async Task<IActionResult> GetSizeDetailsByTypeAndProductLine()
        {

            string spName = "usp_CT_GetSizeDetailsByTypeAndProductLine";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        
        [HttpPost]
        [Route("GetDroFileSizeList")]
        public async Task<IActionResult> GetDroFileSizeList()
        {

            string spName = "usp_CT_GetDroFileSizeList";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        [HttpPost]
        [Route("GetCTKeyDimensionsByTypeCode")]
        public async Task<IActionResult> GetCTKeyDimensionsByTypeCode()
        {

            string spName = "usp_CT_GetCTKeyDimensionsByTypeCode";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        
        [HttpPost]
        [Route("CT_AddStampDetail")]
        public async Task<IActionResult> CT_AddStampDetail()
        {

            string spName = "usp_CT_AddStampDetails";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        [HttpPost]
        [Route("GetStampModalList")]
        public async Task<IActionResult> GetStampModalList()
        {

            string spName = "usp_CT_GetStampModalList";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        
        [HttpGet]
        [Route("CT_GetStampDetailsList")]
        public async Task<IActionResult> CT_GetStampDetailsList()
        {

            string spName = "usp_CT_GetStampDetailsList";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        [HttpGet]
        [Route("GetDroProdLine")]
        public async Task<IActionResult> GetDroProdLine()
        {

            string spName = "usp_GetDroProdLine";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        [HttpGet]
        [Route("GetSizeDropdown")]
        public async Task<IActionResult> GetSizeDropdown()
        {

            string spName = "usp_CT_GetSizeDropdown";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        [HttpPost]
        [Route("AddSubType")]
        public async Task<IActionResult> AddSubType()
        {
            

            string spName = "usp_CT_AddSubType";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        [HttpPost]
        [Route("GetSubTypeTableData")]
        public async Task<IActionResult> GetSubTypeTableData()
        {
            

            string spName = "usp_CT_GetSubTypeTableData";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        [HttpPost]
        [Route("CT_GetSubTypeData")]
        public async Task<IActionResult> CT_GetSubTypeData()
        {


            string spName = "usp_CT_GetSubTypeData";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        [HttpPost]
        [Route("GetDownloadCSVDataForSubtype")]
        public async Task<IActionResult> GetDownloadCSVDataForSubtype()
        {


            string spName = "usp_CT_GetDownloadCSVDataForSubtype";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        
        [HttpGet]
        [Route("GetSubTypeCSVDropdown")]
        public async Task<IActionResult> GetSubTypeCSVDropdown()
        {


            string spName = "usp_GetSubTypeCSVDropdown";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        [HttpPost]
        [Route("CT_ApproveStamp")]
        public async Task<IActionResult> CT_ApproveStamp()
        {


            string spName = "usp_CT_ApproveStamp";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
  
        [HttpPost]
        [Route("CT_ApproveSubType")]
        public async Task<IActionResult> CT_ApproveSubType()
        {
            

            string spName = "usp_CT_ApproveSubType";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        [HttpPost]
        [Route("CT_GetDrawingList")]
        public async Task<IActionResult> CT_GetDrawingList()
        {
            

            string spName = "usp_CT_GetDrawingList";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        [HttpPost]
        [Route("CTSubTypeDropdown")]
        public async Task<IActionResult> CTSubTypeDropdown()
        {


            string spName = "usp_CTSubTypeDropdown";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        [HttpPost]
        [Route("CT_AddNewRequest")]
        public async Task<IActionResult> CT_AddNewRequest()
        {


            string spName = "usp_CT_AddNewRequest";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
    
        [HttpPost]
        [Route("DroApproveFileSize")]
        public async Task<IActionResult> DroApproveFileSize()
        {
            

            string spName = "usp_CT_ApproveFileSize";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        [HttpPost]
        [Route("CTApproveFileType")]
        public async Task<IActionResult> CTApproveFileType()
        {

            string spName = "usp_CT_ApproveFileType";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        [HttpPost]
        [Route("UpdateTypeDetailsStatus")]
        public async Task<IActionResult> UpdateTypeDetailsStatus()
        {

            string spName = "usp_CT_UpdateTypeDetailsStatus";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        
        [HttpPost]
        [Route("GetDroOperationList")]
        public async Task<IActionResult> GetDroOperationList()
        {

            string spName = "usp_GetDroOperationList";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        [HttpPost]
        [Route("GetDroParametersList")]
        public async Task<IActionResult> GetDroParametersList()
        {

            string spName = "usp_CT_GetParametersList";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        
        [HttpPost]
        [Route("GetDroFileTypeList")]
        public async Task<IActionResult> GetDroFileTypeList()
        {

            string spName = "usp_CT_GetDroFileTypeList";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        [HttpPost]
        [Route("CT_GetTypeParametersList")]
        public async Task<IActionResult> CT_GetTypeParametersList()
        {

            string spName = "usp_CT_GetTypeParametersList";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        [HttpPost]
        [Route("GetTypeParameterList")]
        public async Task<IActionResult> GetTypeParameterList()
        {

            string spName = "usp_GetTypeParameterList";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }
        
        [HttpGet]
        [Route("GetDroFileTypes")]
        public async Task<IActionResult> GetDroFileTypes()
        {
            string spName = "usp_CT_GetDroFileTypeData";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        [HttpPost]
        [Route("GetCTTypeData")]
        public async Task<IActionResult> GetCTTypeData()
        {
            string spName = "usp_GetCTTypeData";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        
        [HttpPost]
        [Route("EditDroSaveFileType")]
        public async Task<IActionResult> EditDroSaveFileType()
        {

            string spName = "usp_EditDroFileType";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
        [HttpPost]
        [Route("InsertCSVTypeDetails")]
        public async Task<IActionResult> InsertCSVTypeDetails()
        {

            string spName = "usp_CT_InsertCSV_TypeDetails";
            string strJsonRequest = await new StreamReader(Request.Body).ReadToEndAsync();
            string jsonResult;
            if (string.IsNullOrEmpty(strJsonRequest))
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName);
            }
            else
            {
                jsonResult = await dbManager.JsonDataFromSqlAsync(ConnStr, spName, strJsonRequest);
            }
            return Content(jsonResult, Application.Json, Encoding.UTF8);

        }
    }
 }