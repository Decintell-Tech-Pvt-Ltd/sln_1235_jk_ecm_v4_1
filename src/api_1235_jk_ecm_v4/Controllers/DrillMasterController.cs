using api_1235_jk_ecm_v4.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

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
        [Route("DroAddFileType")]
        public async Task<IActionResult> SaveFileType()
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
        [HttpGet]
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
    }
 }