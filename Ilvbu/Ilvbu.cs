using Newtonsoft.Json;
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
    }
}
