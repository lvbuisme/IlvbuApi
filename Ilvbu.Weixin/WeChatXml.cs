using Ilvbu.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Ilvbu.Weixin
{
    public class WeChatXml
    {
        public static string ResponseXML(WxXmlModel WxXmlModel)
        {
            string XML = "";
            switch (WxXmlModel.MsgType)
            {
                case "text"://文本回复
                    XML = ReText(WxXmlModel.FromUserName, WxXmlModel.ToUserName, WxXmlModel.Content);
                    break;
                default://默认回复
                    XML = ReText(WxXmlModel.FromUserName, WxXmlModel.ToUserName, WxXmlModel.Content);
                    break;
            }
            return XML;
        }

        /// <summary>
        /// 回复文本
        /// </summary>
        /// <param name="FromUserName">发送给谁(openid)</param>
        /// <param name="ToUserName">来自谁(公众账号ID)</param>
        /// <param name="Content">回复类型文本</param>
        /// <returns>拼凑的XML</returns>
        public static string ReText(string FromUserName, string ToUserName, string Content)
        {
            string XML = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName>";//发送给谁(openid)，来自谁(公众账号ID)
            XML += "<CreateTime>" + GetTimestamp() + "</CreateTime>";//回复时间戳
            XML += "<MsgType><![CDATA[text]]></MsgType>";//回复类型文本
            XML += "<Content><![CDATA[" + Content + "]]></Content><FuncFlag>0</FuncFlag></xml>";//回复内容 FuncFlag设置为1的时候，自动星标刚才接收到的消息，适合活动统计使用
            return XML;
        }
        public static long GetTimestamp()
        {
            TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);//ToUniversalTime()转换为标准时区的时间,去掉的话直接就用北京时间
            //return (long)ts.TotalMilliseconds; //精确到毫秒
            return (long)ts.TotalSeconds;//获取10位
        }
        public static WxXmlModel LoadXmlModel(string xmlstr)
        {
            XmlDocument requestDocXml = new XmlDocument();
            requestDocXml.LoadXml(xmlstr);
            XmlElement rootElement = requestDocXml.DocumentElement;
            WxXmlModel WxXmlModel = new WxXmlModel();
            WxXmlModel.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
            WxXmlModel.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
            WxXmlModel.CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText;
            WxXmlModel.MsgType = rootElement.SelectSingleNode("MsgType").InnerText;
            switch (WxXmlModel.MsgType)
            {
                case "text"://文本
                    WxXmlModel.Content = rootElement.SelectSingleNode("Content").InnerText;
                    break;
                case "image"://图片
                    WxXmlModel.PicUrl = rootElement.SelectSingleNode("PicUrl").InnerText;
                    WxXmlModel.MediaId = rootElement.SelectSingleNode("MediaId").InnerText;
                    break;
                case "event"://事件
                    WxXmlModel.Event = rootElement.SelectSingleNode("Event").InnerText;
                    if (WxXmlModel.Event == "subscribe")//关注类型
                    {
                        WxXmlModel.EventKey = rootElement.SelectSingleNode("EventKey").InnerText;
                    }
                    break;
                case "voice":
                    WxXmlModel.MediaId = rootElement.SelectSingleNode("MediaId").InnerText;
                    WxXmlModel.Recognition= rootElement.SelectSingleNode("Recognition").InnerText;
                    break;
                default:
                    break;
            }
            return WxXmlModel;
        }
    }
}
