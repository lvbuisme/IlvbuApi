using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ilvbu;
using Ilvbu.Interface.Arguments;
using Ilvbu.Interface.ResultModels;
using Ilvbu.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace IlvbuService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WXController : Controller
    {
        private readonly IWXAuthService _authService;

        public WXController(IWXAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("AddFood")]
        public async Task<BaseResult> AddFood(AddFoodArg model) 
        {
            return new BaseResult();
        }
        /// <summary>
        /// 授权登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("Login")]
        public string Login(string code)
        {
            return _authService.GetToken(code);
 
        }
        ///// <summary>
        ///// 回调处理
        ///// </summary>
        //[HttpGet("OAuthHandle")]
        //public ActionResult OAuthHandle(string code)
        //{
        //    string result = "";
        //    //注册事件处理
        //    _authService.OnError = (e) =>
        //    {
        //        string msg = "";
        //        Exception inner = e;
        //        while (inner != null)
        //        {
        //            msg += inner.Message;
        //            inner = inner.InnerException;
        //        }
        //        result = msg;
        //    };
        //    _authService.OnGetTokenSuccess = (token) =>
        //    {
        //        result += "<br/>";
        //        result += token.ToJsonString();
        //    };
        //    _authService.OnGetUserInfoSuccess = (user) =>
        //    {
        //        result += "<br/>";
        //        result += user.ToJsonString();
        //    };
        //    //第二步
        //    _authService.GetAccess_Token(code);
        //    //第三步
        //    _authService.GetUserInfo();
        //    //显示结果
        //    ViewBag.msg = result;
        //    return View();
        //}
    }
}