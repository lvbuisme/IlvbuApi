using System;
using System.Collections.Generic;
using System.Text;

namespace Ilvbu.Auth.Models
{
    public class WeiXinJscode
    {
        public string openId { get; set; }
        public string session_key { get; set; }
        public string expires_in { get; set;}
    }
}
