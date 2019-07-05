using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ilvbu;
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

namespace IlvbuService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeChatController : WxController
    {
        private string foodImageSavePaht = @"{0}\{1}";
        private readonly IWXService _wxService;

        public WeChatController(IWXService wxService , MyDbContext context):base(context)
        {

            _wxService = wxService;
        }
        /// <summary>
        /// 添加食物记录
        /// </summary>
        /// <param name="addFoodArg"></param>
        /// <returns></returns>
        [HttpPost("AddFood")]
        public async Task<BaseResult> AddFoodRecord([FromBody]AddFoodArg addFoodArg) 
        {
           return await _wxService.AddFood(User, addFoodArg.FoodName);
        }
        /// <summary>
        /// 获取食物记录list
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        [HttpGet("FoodList")]
        public async Task<BaseResult<FoodRecordData[]>> GetFoodRecordList(DateTime? dateTime)
        {
            return await _wxService.GetFoodList(User,dateTime);
        }
        /// <summary>
        /// 授权登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("Login")]
        public async Task<string> Login(string code)
        {
            return _wxService.GetToken(code);
         }
        /// <summary>
        /// 测试
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
        /// <summary>
        /// 获取食物列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("FoodInfo")]
        public async Task<BaseResult<FoodInfoData[]>> GetFoodInfo()
        {
            return await _wxService.GetFoodInfo();
        }
        [HttpPost("FoodInfo")]
        public async Task<BaseResult> AddFoodInfo([FromForm]IFormFile file, [FromForm]string FoodName)
        {
            var result = await _wxService.AddFoodInfo(FoodName);
            if (!result.IsSccuess) return result;
            string path = string.Format(foodImageSavePaht, Directory.GetCurrentDirectory(), result.Data);
            Directory.CreateDirectory(path);
            path= path + "\\" + file.FileName;
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            await _wxService.AddFoodImagePath(result.Data, path);           
            return new BaseResult();
        }
        [HttpGet("FoodImage/{foodId}")]
        public async Task<IActionResult> GetFoodImage(int foodId)
        {
            var result = await _wxService.GetFoodImagePath(foodId);
            if (!result.IsSccuess) return NotFound();
            StreamReader streamReader = new StreamReader(result.Data);
          
            IContentTypeProvider contentTypeProvider = new FileExtensionContentTypeProvider();
            if (contentTypeProvider.TryGetContentType(result.Data, out string contentType))
            {
                Stream stream = streamReader.BaseStream;
                return File(stream, contentType);
            }
            return NotFound();
        }
    }
}