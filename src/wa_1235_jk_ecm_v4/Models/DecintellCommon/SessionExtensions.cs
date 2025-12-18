using System.Text.Json;

namespace wa_1235_jk_ecm_v4.Models.DecintellCommon
{
    public static class SessionExtensions
    {
        public static T GetNotificationlistData<T>(this ISession session, string key)
        {
            var data = session.GetString(key);

            if (data != null)
            {
                return JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Optional: Ignores case when deserializing
                });
            }

            return default;
        }


        public static T GetOEMlistData<T>(this ISession session, string key)
        {
            var data = session.GetString(key);

            if (data != null)
            {
                return JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Optional: Ignores case when deserializing
                });
            }

            return default;
        }

    }
}
