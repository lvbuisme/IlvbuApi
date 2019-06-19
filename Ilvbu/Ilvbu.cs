using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilvbu
{
    public static class Ilvbu
    {
        public static string ToJsonString(this Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static T ToObject<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
        public static JObject ToJObject(this string str)
        {
            return (JObject)JsonConvert.DeserializeObject(str);
        }
    }
}
