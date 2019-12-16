using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EL.Common
{
    public static class JsonHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String ObjectToJsonString(this Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T JsonStringToObject<T>(this String jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
