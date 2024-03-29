﻿using Baidu.Aip.Speech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using static Ilvbu.AI.Baidu.UNITModels;

namespace Ilvbu.AI.Baidu
{
    public class UNIT
    {
        

        public static string GetSpeechString(byte[] data)
        {
            // 设置APPID/AK/SK
            string APP_ID = "16787165";
            string API_KEY = "k7s2FUxEx2xuVFy6B0VKRH5C";
            string SECRET_KEY = "no8gKK05u6Hs2FVCuTGDrXPVYEXM1EpA ";
            var client = new Asr(APP_ID, API_KEY, SECRET_KEY);
            // 可选参数
            var options = new Dictionary<string, object>
            {
                { "dev_pid", 1536}
            };
            client.Timeout = 120000; // 若语音较长，建议设置更大的超时时间. ms
            var result = client.Recognize(data, "wav", 16000, options).ToObject<BaiduSpeechResult>();

            return result.result.FirstOrDefault();
        }
        public static string GetResponseMessage(string requestMessage,string userId,string token)
        {
            string responreMessage = string.Empty; ;
            string host = "https://aip.baidubce.com/rpc/2.0/unit/service/chat?access_token=" + token;
            BaiduAIModel baiduAIModel = new BaiduAIModel()
            {
                log_id = "UNITTEST_10000",
                version = "2.0",
                service_id = "S19874",
                session_id = "",
                request = new BaiduAIRequest()
                {
                    query = requestMessage,
                    user_id = userId
                },
                dialog_state = new BaiduAIDialogState()
                {
                    contexts = new BaiduAIDialogStateContext
                    {
                        SYS_REMEMBERED_SKILLS = new string[] { "1057" }
                    }
                }
            };
            try
            {
                BaiduAIResultModel baiduAIResult = NetHelper.HttpPost<BaiduAIResultModel>(host, baiduAIModel); 
                List<BaiduAIResultMessage> resultMessage = new List<BaiduAIResultMessage>();
                foreach (var res in baiduAIResult.result.response_list)
                {
                    resultMessage.Add(new BaiduAIResultMessage
                    {
                        domain_confidence = res.schema.domain_confidence,
                        say = res.action_list.FirstOrDefault().say
                    });
                }
                if (resultMessage.Any(c => c.domain_confidence == 1))
                {
                    resultMessage = resultMessage.Where(c => c.domain_confidence == 1).ToList();
                    Random reum = new Random();
                    responreMessage = resultMessage[reum.Next(resultMessage.Count)].say;
                }
                else
                {
                    responreMessage = resultMessage.OrderByDescending(c => c.domain_confidence).FirstOrDefault().say;
                }
            }
            catch (Exception o)
            {

            }

            return responreMessage;
        }
        public static string GetImageDisposeStr(byte[] data,string token)
        {
            string host = "https://aip.baidubce.com/rest/2.0/image-classify/v2/advanced_general?access_token=" + token;
            string base64 = ConvertUtility.GetFileBase64(data);
            String str = "image=" + HttpUtility.UrlEncode(base64);
            BaiduImageRecognitionResult result = NetHelper.HttpPost<BaiduImageRecognitionResult>(host, str);
            if(result.result != null && result.result.Any())
            {
                var bdresult = result.result.OrderByDescending(c => c.score).FirstOrDefault();
                return bdresult.root + bdresult.keyword;
            }
            else
            {
                return "无法解析此图片";

            }
            
        }

    }
}
