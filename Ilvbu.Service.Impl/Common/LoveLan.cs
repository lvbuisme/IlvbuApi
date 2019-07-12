using Ilvbu.AI.Baidu;
using Ilvbu.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilvbu.Service.Impl.Common
{
    public class LoveLan
    {
        public static bool IsWXLoveLan(ref WxXmlModel wxXmlModel)
        {

            if (wxXmlModel.FromUserName.Equals("oo34K6H7oloJ95aL8bewgVmCNlao") || wxXmlModel.FromUserName.Equals("oo34K6LG-4hrJk4uIYbv17ba2tMk"))
            {
                switch (wxXmlModel.Content)
                {
                    case "我爱你":
                        wxXmlModel.Content = "兰,我也爱你";
                        return true;
                    case "我想你":
                        wxXmlModel.Content = "兰兰,我也想你！";
                        return true;
                    case "亲爱的":
                        wxXmlModel.Content = "亲爱的小仙女！";
                        return true;
                }
            }
           return  false;
        }
    }
}
