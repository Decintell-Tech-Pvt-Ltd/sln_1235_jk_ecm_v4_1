using api_1235_jk_ecm_v4.DAL;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
namespace api_1235_jk_ecm_v4.Controllers
{
    //  [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeNoteController : Controller
    {

        private readonly DBManager dbManager = new DBManager();
        private readonly ILogger<ChangeNoteController> _logger;
        private readonly IConfiguration _configuration;
        public ChangeNoteController(ILogger<ChangeNoteController> logger, IConfiguration config)
        {
            _logger = logger;
            _configuration = config;
        }
        public string ConnStr => _configuration.GetConnectionString("DefaultConnection");

        [HttpGet]
        [Route("GetChangeNoteList")]
        public async Task<IActionResult> GetChangeNoteList()
        {
            string spName = "[usp_ChangeNoteRequestList]";
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
        [Route("GetChangeNoteWorkFlowList")]
        public async Task<IActionResult> GetChangeNoteWorkFlowList()
        {
            string spName = "[usp_GetChangeNoteWorkFlowList]";
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


        //added by mayuri 14 jul 2024
        [HttpGet]
        [Route("GetChangenoteapprovals")]
        public async Task<IActionResult> GetChangenoteapprovals()
        {

            string spName = "usp_GetChangeNoteApprovalList";
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



        //added by mayuri 16 jul 2024
        [HttpPost]
        [Route("GetProductionDetailsFromReqNo")]
        public async Task<IActionResult> GetProductionDetailsFromReqNo()
        {
            string spName = "[usp_GetProductionDetailsFromReqNo]";
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

        //added by mayuri 16 jul 2024
        [HttpPost]
        [Route("UpdateSKURequestApprovalStatus")]
        public async Task<IActionResult> UpdateSKURequestApprovalStatus()
        {
            string spName = "[usp_ApproveRejectChangeNoteRequest]";
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



        //added by mayuri 16 jul 2024
        [HttpPost]
        [Route("ApproveRejectChangeNoteRequest")]
        public async Task<IActionResult> ApproveRejectChangeNoteRequest()
        {
            string spName = "[usp_ApproveRejectChangeNoteRequest]";
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

        //added by mayuri 16 jul 2024
        [HttpPost] 
        [Route("GetDispatchDetailsFromReqNo")]
        public async Task<IActionResult> GetDispatchDetailsFromReqNo()
        {
            string spName = "[usp_GetDispatchDetailsFromReqNo]";
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
        [Route("GetStampDetails")]
        public async Task<IActionResult> GetStampDetails()
        {
            string spName = "[usp_GetStampDetails]";
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

        //added by mayuri 17 Sep 2024
        [HttpPost]
        [Route("UpdateSKUStatusOnChangeNote")]
        public async Task<IActionResult> UpdateSKUStatusOnChangeNote()
        {
            string spName = "[usp_UpdateSKUStatusOnChangeNote]";
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
        [Route("GetFinalApprovalList")]
        public async Task<IActionResult> GetFinalApprovalList()
        {
            string spName = "[usp_GetFinalApprovalList]";
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
        [Route("GetRequestApprovalList")]
        public async Task<IActionResult> GetRequestApprovalList()
        {
            string spName = "[usp_GetRequestApprovalList]";
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
        [Route("SubmitRequestTrigger")]
        public async Task<IActionResult> SubmitRequestTrigger()
        {
            string spName = "[usp_SubmitRequestTrigger]";
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
        [Route("UpdateWorkFlowApprovalStatus")]
        public async Task<IActionResult> UpdateWorkFlowApprovalStatus()
        {
            string spName = "[usp_UpdateWorkFlowApprovalStatus]";
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
