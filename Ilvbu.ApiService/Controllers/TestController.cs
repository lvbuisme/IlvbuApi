using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ilvbu.Interface.Arguments;
using Ilvbu.Interface.Models;
using Ilvbu.Interface.ResultModels;
using Ilvbu.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IlvbuService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IWXAuthService _authService;

        public TestController(IWXAuthService authService)
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
    }
}
