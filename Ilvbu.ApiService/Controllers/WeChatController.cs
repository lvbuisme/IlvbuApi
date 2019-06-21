using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ilvbu;
using Ilvbu.DataBase;
using Ilvbu.Interface.Arguments;
using Ilvbu.Interface.DbModels;
using Ilvbu.Interface.Models;
using Ilvbu.Interface.ResultModels;
using Ilvbu.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace IlvbuService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeChatController : WxController
    {
        private readonly IWXService _wxService;

        public WeChatController(IWXService wxService , MyDbContext context):base(context)
        {

            _wxService = wxService;
        }

        [HttpPost("AddFood")]
        public async Task<BaseResult> AddFood(AddFoodArg addFoodArg) 
        {
           return await _wxService.AddFood(User, addFoodArg.FoodName);
        }
        [HttpGet("FoodList")]
        public async Task<BaseResult<FoodRecordData[]>> GetFoodList(DateTime? dateTime)
        {
            return await _wxService.GetFoodList(User,dateTime);
        }
        /// <summary>
        /// 授权登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("Login")]
        public string Login(string code)
        {
            return _wxService.GetToken(code);
         }
        /// <summary>
        /// 授权登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("Test")]
        public async Task<TestModel> Test()
        {
            TestModel testModel = new TestModel()
            {
                Guid = Guid.NewGuid().ToString(),
                Message = "测试消息"
            };
            return testModel;
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