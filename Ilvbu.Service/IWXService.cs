using Ilvbu.Auth;
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
    public interface IWXService
    {

        //string GetCodeUrl();
        //void GetAccess_Token(string code);
        //WXAuthAccess_Token RefreshAccess_Token();
        //void GetUserInfo();
        string GetToken(string code);
        Task<BaseResult> AddFood(User user, string foodName);
        Task<BaseResult<FoodRecordData[]>> GetFoodList(User user, DateTime? dateTime);
        Task<BaseResult<int>> AddFoodInfo(string foodName);
        Task<BaseResult> AddFoodImagePath(int id, string imagePath);
        Task<BaseResult<FoodInfoData[]>> GetFoodInfo();
        Task<BaseResult<string>> GetFoodImagePath(int id);
    }
}
