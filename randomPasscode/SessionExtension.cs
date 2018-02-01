using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace randomPasscode
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectAsJson<T>(this ISession session, string key)
        {
            string val = session.GetString(key);
            return val == null ? default(T) : JsonConvert.DeserializeObject<T>(val);
        }
    }
}
