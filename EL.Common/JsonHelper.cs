using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EL.Common
{
    public static class JsonHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String ToJson(this Object obj)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                //对所有Json属性名称使用 camel 大小写
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            return JsonSerializer.Serialize(obj, serializeOptions);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T ToJsonT<T>(this String jsonString)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                //对所有Json属性名称使用 camel 大小写
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            return JsonSerializer.Deserialize<T>(jsonString, serializeOptions);
        }
    }
}
