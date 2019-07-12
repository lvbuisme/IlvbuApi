using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ilvbu;
using Ilvbu.Interface.Arguments;
using Ilvbu.Interface.DbModels;
using Ilvbu.Interface.Models;
using Ilvbu.Interface.ResultModels;
using Ilvbu.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IlvbuService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RubbishController : Controller
    {
        private readonly IRubbishService _rubbishService;

        public RubbishController(IRubbishService rubbishService)
        {
            _rubbishService = rubbishService;
        }
        /// <summary>
        /// 添加垃圾
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Rubish")]
        public async Task<BaseResult> AddRubish(RubbishData model)
        {
            return await _rubbishService.AddRubish(model);
        }
        /// <summary>
        /// 获取所有垃圾
        /// </summary>
        /// <returns></returns>
        [HttpGet("Rubbish")]
        public async Task<BaseResult<RubbishData[]>> GetRubbish()
        {
            return await _rubbishService.GetRubbish();
        }
    }
}
