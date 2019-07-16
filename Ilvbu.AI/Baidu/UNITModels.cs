using System;
using System.Collections.Generic;
using System.Text;

namespace Ilvbu.AI.Baidu
{
    public class UNITModels
    {
        public class BaiduAIResultMessage
        {
            public double domain_confidence { get; set; }
            public string say { get; set; }

        }
        public class BaiduAIResultModel
        {
            public BaiduAIResult result { get; set; }
            public int error_code { get; set; }
        }
        public class BaiduAIResult
        {
            public string version { get; set; }
            public DateTime timestamp { get; set; }
            public string service_id { get; set; }
            public string log_id { get; set; }
            public string session_id { get; set; }
            public string interaction_id { get; set; }
            public BaiduAIResponse[] response_list { get; set; }
            public BaiduAIDialogState dialog_state { get; set; }
        }
        public class BaiduAIResponse
        {
            public string version { get; set; }
            public string msg { get; set; }
            public string origin { get; set; }
            public BaiduAISchema schema { get; set; }
            public BaiduAIAction[] action_list { get; set; }
            public Object qu_res { get; set; }

        }
        public class BaiduAIAction
        {
            public string action_id { get; set; }
            public object refine_detail { get; set; }
            public double confidence { get; set; }
            public string custom_reply { get; set; }
            public string say { get; set; }
            public string type { get; set; }
        }
        public class BaiduAISchema
        {
            public double intent_confidence { get; set; }
            public double domain_confidence { get; set; }
            public string intent { get; set; }
        }
        public class BaiduAIModel
        {
            public string log_id { get; set; }
            public string version { get; set; }
            public string service_id { get; set; }
            public string session_id { get; set; }
            public BaiduAIRequest request { get; set; }
            public BaiduAIDialogState dialog_state { get; set; }
        }
        public class BaiduAIRequest
        {
            public string query { get; set; }
            public string user_id { get; set; }
        }
        public class BaiduAIDialogState
        {
            public BaiduAIDialogStateContext contexts { get; set; }
            public Object dialog_state { get; set; }
        }
        public class BaiduAIDialogStateContext
        {
            public string[] SYS_REMEMBERED_SKILLS { get; set; }
        }
        public  class BaiduSpeechResult
        {
            public string corpus_no { get; set; }
            public string err_msg { get; set; }
            public string err_no { get; set; }
            public string[] result { get; set; }
            public string sn { get; set; }
        }

        public class BaiduImageRecognitionResult
        {
            public string log_id { get; set; }
            public int result_num { get; set; }
            public BaiduImageResult[] result { get; set; }
        }
        public class BaiduImageResult
        {
            public double score { get; set; }
            public string root { get; set; }
            public string keyword { get; set; }
        }

    }
}
