using AutoMapper;
using Ilvbu.Auth;
using Ilvbu.Auth.Models;
using Ilvbu.DataBase;
using Ilvbu.DataBase.Models;
using Ilvbu.Interface.DbModels;
using Ilvbu.Interface.Models;
using Ilvbu.Interface.ResultModels;
using Ilvbu.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ilvbu.Service
{
    /// <summary>
    /// 网页授权逻辑处理，
    /// 处理三步操作，处理成功，返回用户基本信息
    /// </summary>
    public class WXService : IWXService
    {
        private readonly ILogger<WXService> _logger;
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public WXService(ILogger<WXService> logger, MyDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        #region 基本信息定义
        /// <summary>
        /// 公众号的唯一标识
        /// </summary>
        private string _appid = "wxf2fbcb7b1b56771e";
        /// <summary>
        /// 公众号的appsecret
        /// </summary>
        private string _secret = "461bb3cfebd193e233beab0c28786420";
        ///// <summary>
        ///// 回调url地址
        ///// </summary>
        //private string redirect_uri = "snsapi_userinfo";
        /// <summary>
        /// 获取微信用户基本信息使用snsapi_userinfo模式
        /// 如果使用静默授权，无法获取用户基本信息但可以获取到openid
        /// </summary>
        //private string scope;
        #endregion
        public string GetToken(string code)
        {
            string url = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code",
              this._appid,
              this._secret,
              code);
            WeiXinJscode jscode = NetHelper.HttpGet<WeiXinJscode>(url);
          
            //string openId = jObject["openId"].ToString();
            //string session_key = jObject["session_key"].ToString();
            //string expires_in = jObject["expires_in"].ToString();
            Guid guid = Guid.NewGuid();
            UserInfo userInfo = _context.UserInfo.FirstOrDefault(c=>c.OpenId.Equals(jscode.openId));
            WxLoginRecord wxLoginRecord;
            if (userInfo == null)
            {
                wxLoginRecord = new WxLoginRecord()
                {
                    ExpiresIn = jscode.expires_in,
                    Guid = guid.ToString(),
                    UserInfo = new UserInfo()
                    {
                        OpenId = jscode.openId,
                        UserName = "",
                        Password = ""
                    },
                    SessionKey = jscode.session_key
                };
            }
            else
            {
                wxLoginRecord = new WxLoginRecord()
                {
                    ExpiresIn = jscode.expires_in,
                    Guid = guid.ToString(),
                    UserId = userInfo.Id,
                    SessionKey = jscode.session_key
                };
            }
            _context.WxLoginRecord.Add(wxLoginRecord);
            _context.SaveChanges();
            return guid.ToString();
        }
        public async Task<BaseResult> AddFood(User user,string foodName)
        {
            try
            {
                FoodRecord foodRecord = new FoodRecord()
                {
                    UserId = user.UserId,
                    FoodName = foodName,
                    CreateTime = DateTime.Now
                };
                _context.FoodRecord.Add(foodRecord);
                await _context.SaveChangesAsync();
                return  new BaseResult();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");
                return new BaseResult(-1, e.Message);
            }

        }
        public async Task<BaseResult<FoodRecordData[]>> GetFoodList(User user,DateTime? dateTime)
        {
            try
            {
                IQueryable<FoodRecord> DbfoodRecords = _context.FoodRecord.Where(c => c.UserId == user.UserId);
                if (dateTime != null)
                {
                    DateTime dayTime = Convert.ToDateTime(dateTime.Value.ToString("yyyy-MM-dd"));
                    DbfoodRecords = DbfoodRecords.Where(c => c.CreateTime < dayTime.AddHours(24) && c.CreateTime >= dayTime);
                }
                else
                {
                    DbfoodRecords = DbfoodRecords.Where(c => c.CreateTime > DateTime.Today.AddDays(-3));
                }
                FoodRecord[] foodRecords =await DbfoodRecords.ToArrayAsync();
                FoodRecordData[] foodRecordDatas = _mapper.Map<FoodRecordData[]>(foodRecords);
                return BaseResult<FoodRecordData[]>.From(foodRecordDatas);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");
                return new BaseResult<FoodRecordData[]>(-1, e.Message);
            }
        }
        public async Task<BaseResult<int>> AddFoodInfo(string foodName)
        {
            try
            {
                FoodInfo foodInfo = new FoodInfo()
                {
                    FoodName = foodName
                };
                _context.FoodInfo.Add(foodInfo);
                await _context.SaveChangesAsync();
                return BaseResult<int>.From(foodInfo.Id);
            }
            catch(Exception e)
            {
                _logger.LogError(e, "");
                return new BaseResult<int>(-1, e.Message);
            }           
        }
        public async Task<BaseResult> AddFoodImagePath(int id,string imagePath)
        {
            try
            {
                FoodInfo foodInfo = _context.FoodInfo.FirstOrDefault(c => c.Id == id);
                foodInfo.ImagePath = imagePath;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");
                return new BaseResult(-1, e.Message);
            }
            return new BaseResult();
        }
        public async Task<BaseResult<FoodInfoData[]>> GetFoodInfo()
        {
            try
            {
                FoodInfo[] foodInfos = _context.FoodInfo.ToArray();
                FoodInfoData[] foodInfoDatas = _mapper.Map<FoodInfoData[]>(foodInfos);
                return  BaseResult<FoodInfoData[]>.From(foodInfoDatas);
            }
            catch(Exception e)
            {
                _logger.LogError(e, "");
                return new BaseResult<FoodInfoData[]>(-1, e.Message);
            }
    
        }
        public async Task<BaseResult<string>> GetFoodImagePath(int id)
        {
            try
            {
                FoodInfo foodInfos = _context.FoodInfo.FirstOrDefault(c => c.Id == id);
                return BaseResult<string>.From(foodInfos.ImagePath);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");
                return new BaseResult<string>(-1, e.Message);
            }

        }
    }
}
