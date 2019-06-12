using System;
using System.Collections.Generic;
using System.Text;

namespace Ilvbu.Interface.Models
{
    public class WXAuthAccess_Token
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        /// <summary>
        /// 用户针对当前公众号的唯一标识
        /// 关注后会产生，返回公众号下页面也会产生
        /// </summary>
        public string openid { get; set; }
        public string scope { get; set; }
        /// <summary>
        /// 当前用户的unionid，只有在用户将公众号绑定到微信开放平台帐号后
        /// </summary>
        public string unionid { get; set; }
    }
}
