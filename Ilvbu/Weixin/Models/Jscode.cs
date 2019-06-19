using System;
using System.Collections.Generic;
using System.Text;

namespace Ilvbu.Weixin.Models
{
    public class Jscode
    {
        public string openId { get; set; }
        public string session_key { get; set; }
        public string expires_in { get; set;}
    }
}
