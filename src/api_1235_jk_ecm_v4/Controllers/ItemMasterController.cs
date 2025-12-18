using api_1235_jk_ecm_v4.DAL;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace api_1235_jk_ecm_v4.Controllers
{
     // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemMasterController : Controller
    {
        private readonly DBManager dbManager = new DBManager();
        private readonly ILogger<ItemMasterController> _logger;
        private readonly IConfiguration _configuration;
        public ItemMasterController(ILogger<ItemMasterController> logger, IConfiguration config)
        {
            _logger = logger;
            _configuration = config;
        }
        public string ConnStr => _configuration.GetConnectionString("DefaultConnection");

        [HttpGet]
        [Route("GetCategoryList")]
        public async Task<IActionResult> GetCategoryList()
        {
            string spName = "[usp_GetCategoryList]";
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
        [Route("GetPackingMaterialList")]
        public async Task<IActionResult> GetPackingMaterialList()
        {
            string spName = "[usp_GetPackingMaterialList]";
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
        [Route("GetMaterialList")]
        public async Task<IActionResult> GetMaterialList()
        {
            string spName = "[usp_GetMaterialList]";
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
        [Route("SaveNewRequest")]
        public async Task<IActionResult> SaveNewRequest()
        {
            string spName = "usp_AddNewRequest";
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
        [Route("SaveStampDetails")]
        public async Task<IActionResult> SaveStampDetails()
        {
            string spName = "usp_AddStampDetails";
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
        [Route("SaveHandleDetails")]
        public async Task<IActionResult> SaveHandleDetails()
        {
            string spName = "usp_AddHandleDetails";
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
        [Route("SaveOtherPackingDetails")]
        public async Task<IActionResult> SaveOtherPackingDetails()
        {
            string spName = "usp_AddOtherPackingDetails";
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
        [Route("GetCustomerMaster")]
        public async Task<IActionResult> GetCustomerMaster()
        {

            string spName = "usp_GetCustomerMaster";
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
        [Route("GetLookupData")]
        public async Task<IActionResult> GetLookupData()
        {

            string spName = "usp_GetLookupData";
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
        [Route("GetBrandMaster")]
        public async Task<IActionResult> GetBrandMaster()
        {

            string spName = "usp_GetBrandMaster";
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
        [Route("GetFileTypeMaster")]
        public async Task<IActionResult> GetFileTypeMaster()
        {

            string spName = "usp_GetFileTypeMaster";
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
        [Route("GetStampMaster")]
        public async Task<IActionResult> GetStampMaster()
        {
            string spName = "usp_GetStampMaster";
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

        /// <summary>
        /// Lina Bisen
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHandleType")]
        public async Task<IActionResult> GetHandleType()
        {
            string spName = "usp_GetHandleMaster";
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
        [Route("GetHandleChartData")]
        public async Task<IActionResult> GetHandleChartData()
        {
            string spName = "[usp_GetHandleChart]";
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

        //GetHandleChartData
       
        [HttpPost]
        [Route("GetDimesionsAttribute")]
        public async Task<IActionResult> GetDimesionsAttribute()
        {
            string spName = "[usp_GetDimesionsAttribute]";
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
        [Route("GetFileSubType")]
        public async Task<IActionResult> GetFileSubType()
        {
            string spName = "usp_GetFileSubType";
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
        [Route("GetCutSpecifications")]
        public async Task<IActionResult> GetCutSpecifications()
        {
            string spName = "usp_GetCutSpecifications";
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
        [Route("GetSelectedCutSpecificationsList")]
        public async Task<IActionResult> GetSelectedCutSpecificationsList()
        {
            string spName = "usp_GetSelectedCutSpecificationsList";
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



        //GetFileCode
        [HttpPost]
        [Route("GetFileCode")]
        public async Task<IActionResult> GetFileCode()
        {
            string spName = "usp_GetGetFileCode";
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
        [Route("GetCountryContinent")]
        public async Task<IActionResult> GetCountryContinent()
        {
            string spName = "usp_GetCountryContinent";
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
        [Route("GetCutSideStandard")]
        public async Task<IActionResult> GetCutSideStandard()
        {
            string spName = "usp_GetCutSideStandard";
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
        [Route("GetDimesionsAttributeList")]
        public async Task<IActionResult> GetDimesionsAttributeList()
        {
            string spName = "[usp_GetDimesionsAttributeList]";
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
        [Route("AddDimesionsAttribute")]
        public async Task<IActionResult> AddDimesionsAttribute()
        {
            string spName = "[usp_AddDimesionsAttribute]";
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
        [Route("AddPackingMaterialDetails")]
        public async Task<IActionResult> AddPackingMaterialDetails()
        {
            string spName = "[usp_AddPackingMaterialDetails]";
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
        [Route("AddSampleImage")]
        public async Task<IActionResult> AddSampleImage()
        {
            string spName = "[usp_AddSampleImage]";
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
        [Route("GetSampleImagesList")]
        public async Task<IActionResult> GetSampleImagesList()
        {
            string spName = "[usp_GetSampleImagesList]";
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
        [Route("GetArtworkImagesList")]
        public async Task<IActionResult> GetArtworkImagesList()
        {
            string spName = "[usp_GetArtworkImagesList]";
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
        [Route("AddArtworkImage")]
        public async Task<IActionResult> AddArtworkImage()
        {
            string spName = "[usp_AddArtworkImage]";
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
        [Route("GetSampleImage")]
        public async Task<IActionResult> GetSampleImage()
        {
            string spName = "[usp_GetSampleImage]";
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
        [Route("GetArtworkImage")]
        public async Task<IActionResult> GetArtworkImage()
        {
            string spName = "[usp_GetArtworkImage]";
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
        [Route("GetPackingStickerDetails")]
        public async Task<IActionResult> GetPackingStickerDetails()
        {
            string spName = "[usp_GetPackingStickerDetails]";
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
        [Route("GetPackingFilteredImage")]
        public async Task<IActionResult> GetPackingFilteredImage()
        {
            string spName = "[usp_GetPackingFilteredImage]";
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
        [Route("AddPackingSelectedImage")]
        public async Task<IActionResult> AddPackingSelectedImage()
        {
            string spName = "[usp_AddPackingSelectedImage]";
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
        [Route("DeletePackingStickerDetails")]
        public async Task<IActionResult> DeletePackingStickerDetails()
        {
            string spName = "[usp_DeletePackingStickerDetails]";
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
        [Route("DeletePackingStickerDetailsAll")]
        public async Task<IActionResult> DeletePackingStickerDetailsAll()
        {
            string spName = "[usp_DeletePackingStickerDetailsAll]";
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


        //added by Mayuri 25 jul 2024
        [HttpGet]
        [Route("GetItemMasterApprovedSKUList")]
        public async Task<IActionResult> GetItemMasterApprovedSKUList()
        {
            string spName = "usp_GetItemMasterApprovedSKUList";
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
        [Route("GetItemMasterApprovedSKUListArchive")]
        public async Task<IActionResult> GetItemMasterApprovedSKUListArchive()
        {
            string spName = "usp_GetItemMasterApprovedSKUListArchive";
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
        [Route("GetDrawingSKU")]
        public async Task<IActionResult> GetDrawingSKU()
        {
            string spName = "usp_Set_GetDrawingSKU";
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
        [Route("SaveNewSetRequest")]
        public async Task<IActionResult> SaveNewSetRequest()
        {
            string spName = "usp_Set_AddNewRequest";
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
        [Route("GetWrapperDetails")]
        public async Task<IActionResult> GetWrapperDetails()
        {
            string spName = "usp_Set_GetWrapperDetails";
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
        [Route("AddCloneAndAmendRequest")]
        public async Task<IActionResult> AddCloneAndAmendRequest()
        {
            string spName = "[usp_AddCloneAndAmendRequest]";
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
        [Route("AddCloneAndAmendImagesRequest")]
        public async Task<IActionResult> AddCloneAndAmendImagesRequest()
        {
            string spName = "[usp_AddCloneAndAmendImagesRequest]";
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
        [Route("GetRecycleBinSKUList")]
        public async Task<IActionResult> GetRecycleBinSKUList()
        {
            string spName = "[usp_GetRecycleBinSKUList]";
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
        [Route("GetProdSKUKeyFromId")]
        public async Task<IActionResult> GetProdSKUKeyFromId()
        {
            string spName = "usp_GetProdSKUKeyFromId";
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

        //18 sep 2024 added
        [HttpPost]
        [Route("GetPackingDetailsForViewLL")]
        public async Task<IActionResult> GetPackingDetailsForViewLL()
        {
            string spName = "usp_GetPackingDetailsForViewLL";
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
        [Route("GetSelectedCelloTape")]
        public async Task<IActionResult> GetSelectedCelloTape()
        {
            string spName = "[usp_GetSelectedCelloTape]";
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
        [Route("GetDetailsForSKUSet")]
        public async Task<IActionResult> GetDetailsForSKUSet()
        {
            string spName = "usp_GetDetailsForSKUSet";
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
        [Route("GetComingSoonApprovedSKUList")]
        public async Task<IActionResult> GetComingSoonApprovedSKUList()
        {
            string spName = "usp_GetComingSoonApprovedSKUList";
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
        [Route("DeleteDrawingFromSet")]
        public async Task<IActionResult> DeleteDrawingFromSet()
        {
            string spName = "usp_DeleteDrawingFromSet";
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
