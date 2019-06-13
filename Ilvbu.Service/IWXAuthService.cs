using Ilvbu.Interface.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilvbu.Service
{
    /// <summary>
    /// 授权之后获取用户基本信息
    /// </summary>
    public interface IWXAuthService
    {

        //string GetCodeUrl();
        //void GetAccess_Token(string code);
        //WXAuthAccess_Token RefreshAccess_Token();
        //void GetUserInfo();
        string GetToken(string code);
    }
}
