using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ilvbu.Interface.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IlvbuService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
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
