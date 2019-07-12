using AutoMapper;
using Ilvbu.AI.Baidu;
using Ilvbu.DataBase;
using Ilvbu.DataBase.Models;
using Ilvbu.Interface.DbModels;
using Ilvbu.Interface.Models;
using Ilvbu.Interface.ResultModels;
using Ilvbu.Service;
using Ilvbu.Service.Impl.Common;
using Ilvbu.Weixin;
using Ilvbu.Weixin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Ilvbu.Service.Impl
{
    /// <summary>
    /// 网页授权逻辑处理，
    /// 处理三步操作，处理成功，返回用户基本信息
    /// </summary>
    public class WXOAService : IWXOAService
    {
        private readonly ILogger<IWXOAService> _logger;
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private string sToken = "ilvbu";
        private string sAppID = "wx2dcb3e7144a271d9";
        private string sEncodingAESKey = "OEt3gN6PxtYPope9Tq8JAm8JDB3R51D7ahWcp3Qezg1";
        public WXOAService(ILogger<IWXOAService> logger, MyDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Check(string signature, string timestamp, string nonce, string echostr)
        {

            _context.WxOfficialPlatformLoginRecord.Add(new WxOfficialPlatformLoginRecord()
            {

                CreateTime = DateTime.Now,
                Echostr = echostr,
                Nonce = nonce,
                Timestamp = timestamp,
                Signature = signature
            });
            _context.SaveChanges();
            return 0;
        }

        public async Task<string> ReviceMessag(string sMsgSignature, string sTimeStamp, string sNonce, string sPostData, string token)
        {
            string encryptMsg = "";
            _context.WxOfficialPlatformLoginRecord.Add(new WxOfficialPlatformLoginRecord()
            {
                CreateTime = DateTime.Now,
                Nonce = sNonce,
                Timestamp = sTimeStamp,
                Signature = sMsgSignature,
                PostData = sPostData
            });
            _context.SaveChanges();
            Tencent.WXBizMsgCrypt wxcpt = new Tencent.WXBizMsgCrypt(sToken, sEncodingAESKey, sAppID);
            // int ret = 0;
            string sMsg = sPostData;  //解析之后的明文
            //ret = wxcpt.DecryptMsg(sMsgSignature, sTimeStamp, sNonce, sPostData, ref sMsg);
            Console.WriteLine("sMsg:" + sMsg);

            if (!string.IsNullOrEmpty(sMsg))
            {
                //封装请求类

                WxXmlModel wxXmlModel = WeChatXml.LoadXmlModel(sMsg);
                Console.WriteLine(wxXmlModel);
                switch (wxXmlModel.MsgType)
                {
                    case "text"://文本
                        encryptMsg = WxTextAnalytical(wxXmlModel, token);
                        break;
                    case "image"://图片
                        encryptMsg = "图片还没有办法识别哦,期待下次更新";
                        break;
                    case "voice":
                        encryptMsg = WxVoiceAnalytical(wxXmlModel, token, null);
                        break;
                    default:
                        break;
                }
            }


            //try
            //{
            //    //加密回复消息
            //     wxcpt.EncryptMsg(respMessage, sTimeStamp, sNonce,ref encryptMsg);
            //    Console.WriteLine("encryptMsg:" + encryptMsg);
            //}
            //catch (Exception e)
            //{
            //    _logger.LogError(e, "");
            //}
            return encryptMsg;
        }
        private string WxTextAnalytical(WxXmlModel wxXmlModel, string token)
        {
            Console.WriteLine("WxTextAnalytical_Content>>" + wxXmlModel.Content);
            if (!string.IsNullOrEmpty(wxXmlModel.Content))
            {
                if (!LoveLan.IsWXLoveLan(ref wxXmlModel))
                {
                    if (wxXmlModel.Content.Contains("是什么垃圾"))
                    {
                        string rubbishName = wxXmlModel.Content.Replace("是什么垃圾", string.Empty);
                        wxXmlModel.Content = RubbishDispose(rubbishName);
                    }
                    else
                    {
                        wxXmlModel.Content = UNIT.GetResponseMessage(wxXmlModel.Content, wxXmlModel.FromUserName, token);
                    }
                  
                }

            }
            return WeChatXml.ResponseXML(wxXmlModel);
        }
        //private string WechatGetMediaUrl = @"http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";
        private string WxVoiceAnalytical(WxXmlModel wxXmlModel, string token, string wxToken)
        {
            Console.WriteLine("WxVoiceAnalytical_Recognition>>" + wxXmlModel.Recognition);
            // string url = string.Format(WechatGetMediaUrl, wxToken, wxXmlModel.MediaId);
            if (string.IsNullOrEmpty(wxXmlModel.Recognition))
            {
                wxXmlModel.Content = "无法识别您说的话哦,请在说一遍";
            }
            else if (wxXmlModel.Recognition.Contains("是什么垃圾"))
            {
                string rubbishName = wxXmlModel.Recognition.Replace("是什么垃圾", string.Empty).Replace("。",string.Empty).Replace(" ",string.Empty);
                wxXmlModel.Content = RubbishDispose(rubbishName);
            }
            else
            {
                if (!LoveLan.IsWXLoveLan(ref wxXmlModel))
                {
                    wxXmlModel.Content = UNIT.GetResponseMessage(wxXmlModel.Recognition, wxXmlModel.FromUserName, token);
                }
            }
            wxXmlModel.MsgType = "text";
            return WeChatXml.ResponseXML(wxXmlModel);
        }
        public string RubbishDispose(string rubbishName)
        {
            Rubbish rubbish = _context.Rubbish.Include(c=>c.RubbishType).FirstOrDefault(c => c.RubbishName.Contains(rubbishName));
            if (rubbish != null)
            {
                return rubbishName + "是"+ rubbish.RubbishType.RubbishTypeName +"哦。";
            }
            else
            {
                return rubbishName + "是什么垃圾我也不知道哦,如果你知道了请告诉我把。";
            }
        }
    }
}
