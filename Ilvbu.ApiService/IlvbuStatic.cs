using Ilvbu.AI.Baidu;
using Ilvbu.Auth;
using Ilvbu.Auth.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Ilvbu.AI.Baidu.UNITModels;

namespace Ilvbu.ApiService
{
    public class IlvbuStatic
    {
        private static BaiduAuthResult _baiduAuth;

        public static BaiduAuthResult baiduAuth
        {
            get
            {
                if (_baiduAuth == null)
                {
                    _baiduAuth = BaiduAIAuth.GetToken();
                }
                return _baiduAuth;
            }
        }
        private static WeixinAuthResult _weixinAuth;

        public static WeixinAuthResult weixinAuth
        {
            get
            {
                if (_baiduAuth == null)
                {
                    _weixinAuth = WeixinAuth.GetToken();
                }
                return _weixinAuth;
            }
        }
    }
}
