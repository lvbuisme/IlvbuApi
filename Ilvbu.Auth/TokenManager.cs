using Ilvbu.Auth.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilvbu.Auth
{
    public class BaiduAIAuth
    {
        public static BaiduAuthResult GetAIToken()
        {
            string Tokenhost = @"https://aip.baidubce.com/oauth/2.0/token?grant_type=client_credentials&client_id=GwHZaNvnPZ4yAzkCx6Va9yfN&client_secret=FrxvBLZDA4Bmv39mHkSmhFysq57MI7Iq ";
            BaiduAuthResult baiduAuthResult = NetHelper.HttpGet<BaiduAuthResult>(Tokenhost);
            return baiduAuthResult;
        }
        public static BaiduAuthResult GetImageToken()
        {
            string Tokenhost = @"https://aip.baidubce.com/oauth/2.0/token?grant_type=client_credentials&client_id=4Ebj5niSYWlXvuhvKGL7CcgZ&client_secret=21GajBNbMqp1GLsgOXvZCHiNVZpSAQAr";
            BaiduAuthResult baiduAuthResult = NetHelper.HttpGet<BaiduAuthResult>(Tokenhost);
            return baiduAuthResult;
        }
    }
    public class WeixinAuth
    {
        public static WeixinAuthResult GetToken()
        {
            string Tokenhost = @"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx2dcb3e7144a271d9&secret=4057a84f858a8acc91c963c51eac115b";
            WeixinAuthResult baiduAuthResult = NetHelper.HttpGet<WeixinAuthResult>(Tokenhost);
            return baiduAuthResult;
        }
    }
}
