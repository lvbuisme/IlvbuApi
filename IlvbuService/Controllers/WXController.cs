using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ilvbu.Interface.Arguments;
using Ilvbu.Interface.ResultModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace IlvbuService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WXController : ControllerBase
    {
        [HttpPost("AddFood")]
        public async Task<BaseResult> AddFood(AddFoodArg model) 
        {
            return new BaseResult();
        }
        [HttpGet("Login")]
        public async Task<BaseResult> Login(string code)
        {
            return new BaseResult();
        }
    }
}