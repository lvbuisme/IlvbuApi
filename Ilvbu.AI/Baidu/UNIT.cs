using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ilvbu.AI.Baidu.UNITModels;

namespace Ilvbu.AI.Baidu
{
    public class UNIT
    {
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
                responreMessage = resultMessage.OrderByDescending(c => c.domain_confidence).FirstOrDefault().say;
            }
            catch (Exception o)
            {

            }

            return responreMessage;
        }
    }
}
