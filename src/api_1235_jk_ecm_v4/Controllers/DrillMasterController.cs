using System.Text;
using System.Text.Json;
using api_1235_jk_ecm_v4.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wa_1235_jk_ecm_v4.Models.DecintellCommon;
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

            string spName = "usp_Dro_AddFileSize";
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

            string spName = "usp_Dro_AddFileType";
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

            string spName = "usp_GetDroFileSizeList";
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
        [HttpPost]
        [Route("DroApproveFileSize")]
        public async Task<IActionResult> DroApproveFileSize()
        {

            string spName = "usp_DroApproveFileSize";
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
        [Route("DroApproveFileType")]
        public async Task<IActionResult> DroApproveFileType()
        {

            string spName = "usp_DroApproveFileType";
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

            string spName = "usp_GetDroParametersList";
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

            string spName = "usp_GetDroFileTypeList";
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
            string spName = "usp_GetDroFileTypeData";
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
    }
 }