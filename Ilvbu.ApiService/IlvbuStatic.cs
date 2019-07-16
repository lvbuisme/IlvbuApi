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
        private static BaiduAuthResult _baiduAIAuth;

        public static BaiduAuthResult baiduAIAuth
        {
            get
            {
                if (_baiduAIAuth == null)
                {
                    _baiduAIAuth = BaiduAIAuth.GetAIToken();
                }
                return _baiduAIAuth;
            }
        }
        private static BaiduAuthResult _baiduImageAuth;

        public static BaiduAuthResult baiduImageAuth
        {
            get
            {
                if (_baiduImageAuth == null)
                {
                    _baiduImageAuth = BaiduAIAuth.GetImageToken();
                }
                return _baiduImageAuth;
            }
        }
        private static WeixinAuthResult _weixinAuth;

        public static WeixinAuthResult weixinAuth
        {
            get
            {
                if (_weixinAuth == null)
                {
                    _weixinAuth = WeixinAuth.GetToken();
                }
                return _weixinAuth;
            }
        }
    }
}
