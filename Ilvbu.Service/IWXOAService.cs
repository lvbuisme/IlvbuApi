using Ilvbu.Interface.DbModels;
using Ilvbu.Interface.Models;
using Ilvbu.Interface.ResultModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ilvbu.Service
{
    /// <summary>
    /// 授权之后获取用户基本信息
    /// </summary>
    public interface IWXOAService
    {
        Task<int> Check(string signature, string timestamp, string nonce, string echostr);
        Task<string> ReviceMessag(string sMsgSignature, string sTimeStamp, string sNonce, string sPostData,string token);

    }
}
