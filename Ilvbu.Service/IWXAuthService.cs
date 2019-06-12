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
        /// <summary>
        /// 当处理出现异常时，触发
        /// </summary>
         Action<Exception> OnError = null;
        /// <summary>
        /// 当获取AccessToken成功是触发
        /// </summary>
         Action<WXAuthAccess_Token> OnGetTokenSuccess = null;
        /// <summary>
        /// 当获取用户信息成功时触发
        /// </summary>
         Action<WXAuthUser> OnGetUserInfoSuccess = null;
        void GetAccess_Token(string code);
        WXAuthAccess_Token RefreshAccess_Token();
        void GetUserInfo();
    }
}
