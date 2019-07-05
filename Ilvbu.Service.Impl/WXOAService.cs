using AutoMapper;
using Ilvbu.AI.Baidu;
using Ilvbu.DataBase;
using Ilvbu.DataBase.Models;
using Ilvbu.Interface.DbModels;
using Ilvbu.Interface.Models;
using Ilvbu.Interface.ResultModels;
using Ilvbu.Service;
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

namespace Ilvbu.Service
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

        public async Task<string> ReviceMessag(string sMsgSignature, string sTimeStamp, string sNonce, string sPostData,string token)
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
            Console.WriteLine("sMsg:"+sMsg);

            if (!string.IsNullOrEmpty(sMsg))
            {
                //封装请求类

                WxXmlModel wxXmlModel = WeChatXml.LoadXmlModel(sMsg);
           
                if (!string.IsNullOrEmpty(wxXmlModel.Content))
                {
                    if (wxXmlModel.FromUserName.Equals("oo34K6H7oloJ95aL8bewgVmCNlao")|| wxXmlModel.FromUserName.Equals("oo34K6LG-4hrJk4uIYbv17ba2tMk"))
                    {
                        switch (wxXmlModel.Content)
                        {
                            case "我爱你":
                                wxXmlModel.Content = "兰,我也爱你";
                                break;
                            default:
                                wxXmlModel.Content = UNIT.GetResponseMessage(wxXmlModel.Content, wxXmlModel.FromUserName, token);
                                break;
                        }
                    }
                    else
                    {
                        wxXmlModel.Content = UNIT.GetResponseMessage(wxXmlModel.Content, wxXmlModel.FromUserName, token);
                    }
                }
                encryptMsg= WeChatXml.ResponseXML(wxXmlModel);//回复消息
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
      

    }
}
