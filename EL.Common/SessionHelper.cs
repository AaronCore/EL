using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace EL.Common
{
    public class SessionHelper
    {
        public static void SetString(string key, string value)
        {
            HttpContext.Current.Session.SetString(key, value);
        }
        public static void SetInt32(string key, int value)
        {
            HttpContext.Current.Session.SetInt32(key, value);
        }
        public static void Set<T>(string key, T value)
        {
            HttpContext.Current.Session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static string GetString(string key)
        {
            return HttpContext.Current.Session.GetString(key);
        }
        public static int SetInt32(string key)
        {
            return HttpContext.Current.Session.GetInt32(key) ?? 0;
        }
        public static T Get<T>(string key)
        {
            var value = HttpContext.Current.Session.GetString(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
        public static void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
