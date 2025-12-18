using api_1235_jk_ecm_v4.DAL;

using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace api_1235_jk_ecm_v4.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class UploadAndDownLoadFileController : Controller
    {
        private readonly DBManager dbManager = new DBManager();
       // public static readonly EncryptDecrypt encryptDecrypt = new EncryptDecrypt();
        private readonly ILogger<UploadAndDownLoadFileController> _logger;
        private readonly IConfiguration _configuration;
        private object filePath;

        public UploadAndDownLoadFileController(ILogger<UploadAndDownLoadFileController> logger, IConfiguration config)
        {
            _logger = logger;
            _configuration = config;
        }
        public string ConnStr => _configuration.GetConnectionString("DefaultConnection");
        //public string StrJwtApiEndpoint => _configuration.GetSection("JWT_LOGIN_API").Value;
        //--Additionals
        public string BaseStaticFolder => _configuration.GetSection("BaseStaticFolder").Value;



        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadAsync")]
        public async Task<IActionResult> UploadAsync()
        {
            string CustomerID = string.Empty;
            //string recordFolderName = string.Empty;
            // var files = Request.Form.Files;
            var formCollection = await Request.ReadFormAsync();
            var files = formCollection.Files;
            bool v = formCollection.TryGetValue("FilePath", value: out var filePath);
            //bool s = formCollection.TryGetValue("SaveAsFileName", value: out var saveAsFileName);

            //var KeyArray = formCollection.Keys;
            //if (KeyArray.Count > 0)
            //{

            //    CustomerID = Convert.ToString(formCollection["CustomerID"]);
            //    // recordFolderName = Convert.ToString(formCollection["Folder"]);
            //}
            long size = files.Sum(f => f.Length);
            List<DocumentDetails> filePathList = new List<DocumentDetails>();

            //var ValidToken = encryptDecrypt.ValidateToken(Request.HttpContext, StrJwtApiEndpoint);
            //if (!ValidToken) return Unauthorized();

            //G:\static_decintell_net\1234_nc\swas\sc\C0002704\SC12\SE50\vl
            //BaseStaticFolder = "G:\\static_decintell_net\\1234_nc\\swas\\";
            //filePath="sc\\C0002704\\SC12\\SE50\\vl";
            var folderName = Path.Combine(BaseStaticFolder, filePath);

            if (!System.IO.Directory.Exists(folderName))
                System.IO.Directory.CreateDirectory(folderName);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');

                    var fullPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {

                        await formFile.CopyToAsync(stream);
                    }

                    var docDetails = new DocumentDetails
                    {
                        FileName = fileName,
                        DocPath = fullPath
                    };

                    filePathList.Add(docDetails);
                }
            }
            var json = new
            {
                Count = files.Count,
                filePathList = filePathList,
            };

            string jsonResult = JsonSerializer.Serialize(json);
            // return Ok(jo.ToString());
            return Content(jsonResult, Application.Json, Encoding.UTF8);
        }


        [HttpPost("DownloadAsync")]
        public async Task<IActionResult> DownloadAsync([FromBody] DownloadRequestModel request)
        {

            var fileName = request.FileName;
            var filePath = Path.Combine(BaseStaticFolder, fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found");

           // var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

            // You can add additional logic here if needed.
            // Determine the content type based on the file extension (e.g., JPEG for .jpg files).
            var contentType = GetContentType(fileName);

            return File(System.IO.File.ReadAllBytes(filePath), contentType);

        }

        [HttpPost("copy")]
        public async Task<IActionResult> CopyFile([FromForm] CopyFileRequest request)
        {
            try
            {
                string targetFile = Path.Combine(BaseStaticFolder, request.TargetFilePath);

                // Ensure the target directory exists
                string targetDirectory = Path.GetDirectoryName(targetFile);
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                if (request.UploadedFile != null)
                {
                    // Handle file upload
                    if (System.IO.File.Exists(targetFile))
                    {
                        // Log or notify about overriding
                        Console.WriteLine($"Overriding existing file: {targetFile}");
                    }

                    using (var stream = new FileStream(targetFile, FileMode.Create))
                    {
                        await request.UploadedFile.CopyToAsync(stream);
                    }
                }
                else if (!string.IsNullOrEmpty(request.SourceFilePath))
                {
                    // Handle server source file
                    string sourceFile = Path.Combine(BaseStaticFolder, request.SourceFilePath);

                    // Ensure the source file exists
                    if (!System.IO.File.Exists(sourceFile))
                    {
                        return NotFound(new { success = false, error = "Source file not found." });
                    }

                    if (System.IO.File.Exists(targetFile))
                    {
                        // Log or notify about overriding
                        Console.WriteLine($"Overriding existing file: {targetFile}");
                    }

                    // Copy the file
                    System.IO.File.Copy(sourceFile, targetFile, true);
                }
                else
                {
                    return BadRequest(new { success = false, error = "Either source file path or uploaded file must be provided." });
                }

                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, error = ex.Message });
            }
        }


        //[HttpPost("copy")]
        //public async Task<IActionResult> CopyFile([FromForm] CopyFileRequest request)
        //{
        //    try
        //    {
        //        string targetFile = Path.Combine(BaseStaticFolder, request.TargetFilePath);

        //        // Ensure the target directory exists
        //        string targetDirectory = Path.GetDirectoryName(targetFile);
        //        if (!Directory.Exists(targetDirectory))
        //        {
        //            Directory.CreateDirectory(targetDirectory);
        //        }

        //        if (request.UploadedFile != null)
        //        {
        //            // Handle file upload
        //            using (var stream = new FileStream(targetFile, FileMode.Create))
        //            {
        //                await request.UploadedFile.CopyToAsync(stream);
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(request.SourceFilePath))
        //        {
        //            // Handle server source file
        //            string sourceFile = Path.Combine(BaseStaticFolder, request.SourceFilePath);

        //            // Ensure the source file exists
        //            if (!System.IO.File.Exists(sourceFile))
        //            {
        //                return NotFound(new { success = false, error = "Source file not found." });
        //            }

        //            // Copy the file
        //            System.IO.File.Copy(sourceFile, targetFile, true);
        //        }
        //        else
        //        {
        //            return BadRequest(new { success = false, error = "Either source file path or uploaded file must be provided." });
        //        }

        //        return Ok(new { success = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { success = false, error = ex.Message });
        //    }
        //}

        public class CopyFileRequest
        {
            //null enable with ? is nessary for UploadedFile as existing file from db will be copied
            //null enable with ? is nessary for SourceFilePath as new file uploaded
            public string? SourceFilePath { get; set; }
            public string TargetFilePath { get; set; }
            public IFormFile? UploadedFile { get; set; }
        }


        //[HttpPost("copy")]
        //public IActionResult CopyFile([FromBody] CopyFileRequest request)
        //{
        //    try
        //    {
        //        string sourceFile = Path.Combine(BaseStaticFolder, request.SourceFilePath);
        //        string targetFile = Path.Combine(BaseStaticFolder, request.TargetFilePath);

        //        // Ensure the source file exists
        //        if (!System.IO.File.Exists(sourceFile))
        //        {
        //            return NotFound(new { success = false, error = "Source file not found." });
        //        }

        //        // Ensure the target directory exists
        //        string targetDirectory = Path.GetDirectoryName(targetFile);
        //        if (!Directory.Exists(targetDirectory))
        //        {
        //            Directory.CreateDirectory(targetDirectory);
        //        }

        //        // Copy the file
        //        System.IO.File.Copy(sourceFile, targetFile, true);

        //        return Ok(new { success = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { success = false, error = ex.Message });
        //    }
        //}

        //public class CopyFileRequest
        //{
        //    public string SourceFilePath { get; set; }
        //    public string TargetFilePath { get; set; }
        //}


        // Helper function to get content type based on file extension.
        private string GetContentType(string fileName)
        {
            var ext = Path.GetExtension(fileName).ToLowerInvariant();
            switch (ext)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".pdf":
                    return "application/pdf"; // Content type for PDF files.
                // Add more cases for other image formats if needed.
                default:
                    return "application/octet-stream"; // Default to binary if the format is unknown.
            }
        }

    }


    
    public class DownloadRequestModel
    {
        public string FileName { get; set; }
    }


    public class DocumentDetails
    {
        public string FileName { get; set; }
        public string DocPath { get; set; }

    }
}
