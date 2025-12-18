using System.Text.Json;
using System.Threading.Tasks;

namespace wa_1235_jk_ecm_v4.Interface
{
    public interface IGenericMethods
    {
        Task<Stream> GetDataAdmin(string apiEndPoint);
        Task<Stream> PostDataAdmin(string apiEndPoint, string Jsondata);
        Task<Stream> GetDataJwt(string apiEndPoint);
        Task<Stream> PostDataJwt(string apiEndPoint, string Jsondata);
        Task<Stream> GetDataLogin(string apiEndPoint);
        Task<Stream> PostDataLogin(string apiEndPoint, string Jsondata);
        Task<Stream> GetDataCem(string apiEndPoint);
        Task<Stream> PostDataCem(string apiEndPoint, string Jsondata);
        Task<Stream> GetDataSwas(string apiEndPoint);
        Task<Stream> PostDataSwas(string apiEndPoint, string Jsondata);
        Task<Stream> GetDataTem(string apiEndPoint);
        Task<Stream> PostDataTem(string apiEndPoint, string Jsondata);
        Task<Stream> GetDataEcm(string apiEndPoint);
        Task<Stream> PostDataEcm(string apiEndPoint, string Jsondata);
    }
}
