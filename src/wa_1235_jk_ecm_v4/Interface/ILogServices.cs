namespace wa_1235_jk_ecm_v4.Interface;

public interface ILogServices
{
    /// <summary>
    /// Created Interface for loose coupling
    /// Flag property is created to store the log as per the flag 
    /// </summary>
    /// <param name="Controller"></param>
    /// <param name="Method"></param>
    /// <param name="UserId"></param>
    /// <param name="Flag"></param>
    /// <param name="Exception"></param>
    /// <param name="MethodType">Used to store the http method type like Get/Post/Put/Delete</param>
    /// <param name="Namespaces"></param>
    /// <returns></returns>

    Task LogInfo(string controller, string method, int userId, int oemId, string methodType, string namespaces);
    Task LogWarning(string controller, string method, int userId, int oemId, string methodType, string namespaces);
    Task LogError(string controller, string method, int userId, int oemId, string exception, string methodType, string namespaces);


}
