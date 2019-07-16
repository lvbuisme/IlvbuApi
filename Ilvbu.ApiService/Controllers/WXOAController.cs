using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ilvbu;
using Ilvbu.ApiService;
using Ilvbu.DataBase;
using Ilvbu.DataBase.Models;
using Ilvbu.Interface.Arguments;
using Ilvbu.Interface.DbModels;
using Ilvbu.Interface.Models;
using Ilvbu.Interface.ResultModels;
using Ilvbu.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;

namespace IlvbuService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WXOAController : WxAccountController
    {
        private string foodImageSavePaht = @"{0}\{1}";
        private readonly IWXOAService _WXOAService;

        private readonly ILogger<WXOAController> _logger;
        public WXOAController(IWXOAService WXOAService, MyDbContext context, ILogger<WXOAController> logger) :base(context)
        {

            _WXOAService = WXOAService;
            _logger = logger;
        }
        /// <summary>
        /// 授权登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("Login")]
        public async Task<string> Login(string signature,string timestamp,string nonce,string echostr)
        {
            Console.WriteLine("signature:" + signature + ",timestamp:" + timestamp + ",nonce:" + nonce + ",echostr:" + echostr);
            _logger.Log(LogLevel.Debug, signature + timestamp + nonce + echostr);
            if (await _WXOAService.Check(signature, timestamp, nonce, echostr) == 0)
            {
                return echostr;
            }
            return "";
        }
        /// <summary>
        /// 接受消息
        /// </summary>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<string> LoginPost(string signature, string timestamp, string nonce)
        {
            Stream stream = HttpContext.Request.Body;
            byte[] buffer = new byte[HttpContext.Request.ContentLength.Value];
            stream.Read(buffer, 0, buffer.Length);
            string postData = Encoding.UTF8.GetString(buffer);
            _logger.Log( LogLevel.Debug,signature+ timestamp+ nonce+postData);
            Console.WriteLine("signature:"+signature+ ",timestamp:" + timestamp + ",nonce:" + nonce + ",postData:" + postData);
            string token1 = IlvbuStatic.baiduAIAuth.access_token;
            string token2 = IlvbuStatic.baiduImageAuth.access_token;
            string token3 = IlvbuStatic.weixinAuth.access_token;
            return await _WXOAService.ReviceMessag(signature,timestamp,nonce,postData, token1, token2, token3);
        }
    }
}