using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Ilvbu.Interface.Models
{
    public class WXAuthUser
    {
        public string openid { get; set; }
        public string nickname { get; set; }
        public int sex { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string headimgurl { get; set; }
        /// <summary>
        /// 用户特权信息，json 数组
        /// </summary>
        public JArray privilege { get; set; }
        public string unionid { get; set; }
    }
}
