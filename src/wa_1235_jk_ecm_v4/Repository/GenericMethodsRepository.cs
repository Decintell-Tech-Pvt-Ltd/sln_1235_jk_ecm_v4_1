using System.Net.Http.Headers;
using System.Text.Json;
using wa_1235_jk_ecm_v4.Interface;
using wa_1235_jk_ecm_v4.Models.DecintellCommon;
using static System.Net.Mime.MediaTypeNames;


namespace wa_1235_jk_ecm_v4.Repository
{
    public class GenericMethodsRepository : IGenericMethods
    {

        //All Definitions
        #region
        private static JsonSerializerOptions JsonOptions => new(JsonSerializerDefaults.Web);
        //private static string JwtToken => GlobalVariables.Instance.AccessToken;
        private readonly IAppSettingsService _appSettingsService;
        public static DecintellSettings? appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _clientFactory;
        public GenericMethodsRepository(IHttpClientFactory clientFactory, IAppSettingsService appSettingsService, IHttpContextAccessor httpContextAccessor)
        {
            _clientFactory = clientFactory;
            _appSettingsService = appSettingsService;
            appSettings = _appSettingsService.GetAppSettings();
            _httpContextAccessor = httpContextAccessor;
        }
        private string JwtToken => _httpContextAccessor.HttpContext.Request.Cookies["1231_AccessToken"];

        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;
            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();
            return content;
        }
        private Exception BuildApiError(string content, int statusCode)
        {
            throw new wa_1235_jk_ecm_v4.Repository.ApiException
            {
                StatusCode = statusCode,
                Content = content
            };
        }

        //---Updated for ClientFactory Multiple HttpClient here --by Satish 27aug23 
        private HttpClient HttpClientLogin()
        {
            HttpClient client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(appSettings.API_LOGIN_1231);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Application.Json));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            return client;
        }

        private HttpClient HttpClientAdmin()
        {
            HttpClient client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(appSettings.API_ADMIN_1231);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Application.Json));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            return client;
        }
        private HttpClient HttpClientSwas()
        {
            HttpClient client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(appSettings.API_SWASCORE_1234);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Application.Json));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            return client;
        }  
        private HttpClient HttpClientTem()
        {
            HttpClient client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(appSettings.API_TEM_1234);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Application.Json));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            return client;
        }
        private HttpClient HttpClientJwt()
        {
            HttpClient client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(appSettings.API_JWT_1231);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Application.Json));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            return client;
        }
        private HttpClient HttpClientCem()
        {
            HttpClient client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(appSettings.API_CEM_1234);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Application.Json));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            return client;
        }
        private HttpClient HttpClientEcm()
        {
            HttpClient client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(appSettings.API_ECM_1231);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Application.Json));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            return client;
        }

        #endregion     
        //All Definitions

        //Standard GET Method
        #region 
        //Decintell Standard For GET type call JSON API Data into Object --by satish 27aug23
        public async Task<Stream> GetDataAdmin(string apiEndPoint)
        {
            //string apiEndPoint = "ServiceCalls/GetAllCustomers";
            using HttpClient client = HttpClientAdmin();
            HttpResponseMessage response = await client.GetAsync(apiEndPoint);
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }
        public async Task<Stream> PostDataAdmin(string apiEndPoint, string Jsondata)
        {
            using HttpClient client = HttpClientAdmin();
            HttpResponseMessage response = await client.PostAsync(apiEndPoint, new StringContent(Jsondata));
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }


        public async Task<Stream> GetDataJwt(string apiEndPoint)
        {
            using HttpClient client = HttpClientJwt();
            HttpResponseMessage response = await client.GetAsync(apiEndPoint);
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }

        public async Task<Stream> PostDataJwt(string apiEndPoint, string Jsondata)
        {
            using HttpClient client = HttpClientJwt();
            HttpResponseMessage response = await client.PostAsync(apiEndPoint, new StringContent(Jsondata));
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }


        public async Task<Stream> GetDataLogin(string apiEndPoint)
        {
            using HttpClient client = HttpClientLogin();
            HttpResponseMessage response = await client.GetAsync(apiEndPoint);
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }
        public async Task<Stream> PostDataLogin(string apiEndPoint, string Jsondata)
        {
            using HttpClient client = HttpClientLogin();
            HttpResponseMessage response = await client.PostAsync(apiEndPoint, new StringContent(Jsondata));
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }
        public async Task<Stream> GetDataCem(string apiEndPoint)
        {
            //string apiEndPoint = "ServiceCalls/GetAllCustomers";
            using HttpClient client = HttpClientCem();
            HttpResponseMessage response = await client.GetAsync(apiEndPoint);
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }
        public async Task<Stream> PostDataCem(string apiEndPoint, string Jsondata)
        {
            using HttpClient client = HttpClientCem();
            HttpResponseMessage response = await client.PostAsync(apiEndPoint, new StringContent(Jsondata));
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }

        /// Lina Bisen 

        public async Task<Stream> GetDataSwas(string apiEndPoint)
        {
            //string apiEndPoint = "ServiceCalls/GetAllCustomers";
            using HttpClient client = HttpClientSwas();
            HttpResponseMessage response = await client.GetAsync(apiEndPoint);
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }

        public async Task<Stream> PostDataSwas(string apiEndPoint, string Jsondata)
        {
            using HttpClient client = HttpClientSwas();
            HttpResponseMessage response = await client.PostAsync(apiEndPoint, new StringContent(Jsondata));
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }



        //

        public async Task<Stream> GetDataTem(string apiEndPoint)
        {
            //string apiEndPoint = "ServiceCalls/GetAllCustomers";
            using HttpClient client = HttpClientTem();
            HttpResponseMessage response = await client.GetAsync(apiEndPoint);
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }

        public async Task<Stream> PostDataTem(string apiEndPoint, string Jsondata)
        {
            using HttpClient client = HttpClientTem();
            HttpResponseMessage response = await client.PostAsync(apiEndPoint, new StringContent(Jsondata));
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }
        //
        public async Task<Stream> PostDataEcm(string apiEndPoint, string Jsondata)
        {
            using HttpClient client = HttpClientEcm();
            HttpResponseMessage response = await client.PostAsync(apiEndPoint, new StringContent(Jsondata));
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }
        public async Task<Stream> GetDataEcm(string apiEndPoint)
        {
            using HttpClient client = HttpClientEcm();
            HttpResponseMessage response = await client.GetAsync(apiEndPoint);
            Stream stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return stream;
            var content = await StreamToStringAsync(stream);
            throw BuildApiError(content, (int)response.StatusCode);
        }
    }
    #endregion   //Standard POST Method
}

