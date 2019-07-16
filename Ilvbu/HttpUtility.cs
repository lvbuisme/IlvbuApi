using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Ilvbu
{
    public class NetHelper
    {
        /// <summary>
        /// 指定Url地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求链接地址</param>
        /// <returns></returns>
        public static string HttpGet(string url)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            try
            {
                //获取内容
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            finally
            {
                stream.Close();
            }
            return result;
        }
        public static byte[] HttpGetByte(string url)
        {
            byte[] data;
            using (WebClient webClient = new WebClient())
            {
                data = webClient.DownloadData(url);
            }
            return data;
        }
        /// <summary>
        /// 发送Get请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="dic">请求参数定义</param>
        /// <returns></returns>
        public static string HttpGet(string url, Dictionary<string, string> dic)
        {
            string result = "";
            StringBuilder builder = new StringBuilder();
            builder.Append(url);
            if (dic.Count > 0)
            {
                builder.Append("?");
                int i = 0;
                foreach (var item in dic)
                {
                    if (i > 0)
                        builder.Append("&");
                    builder.AppendFormat("{0}={1}", item.Key, item.Value);
                    i++;
                }
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(builder.ToString());
            //添加参数
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            try
            {
                //获取内容
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            finally
            {
                stream.Close();
            }
            return result;
        }

        /// <summary>
        /// 指定Url地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求链接地址</param>
        /// <returns></returns>
        public static T HttpGet<T>(string url)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            try
            {
                //获取内容
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            finally
            {
                stream.Close();
            }
            T t = result.ToObject<T>();
            return t;
        }

        /// <summary>
        /// 指定Url地址 post方式获取全部字符串
        /// </summary>
        /// <param name="url">请求链接地址</param>
        /// <returns></returns>
        public static T HttpPost<T>(string url, Object postData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "post";
            request.ContentType = "application/json";
            request.KeepAlive = true;
            string st = postData.ToJsonString();
            byte[] buffer = Encoding.UTF8.GetBytes(st);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();
            Console.WriteLine(result);
            T t = result.ToObject<T>();
            return t;
        }
    

        /// <summary>
        /// 指定Url地址 post方式获取全部字符串
        /// </summary>
        /// <param name="url">请求链接地址</param>
        /// <returns></returns>
        public static string HttpPost(string url, Object postData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "post";
            request.ContentType = "application/json";
            request.KeepAlive = true;
            string st = postData.ToJsonString();
            byte[] buffer = Encoding.UTF8.GetBytes(st);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();
           
            return result;
        }
        /// <summary>
        /// 指定Url地址 post方式获取全部字符串
        /// </summary>
        /// <param name="url">请求链接地址</param>
        /// <returns></returns>
        public static T HttpPost<T>(string url, string postData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "post";
            request.ContentType = "application/json";
            request.KeepAlive = true;
            byte[] buffer = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();
            Console.WriteLine(result);
            T t = result.ToObject<T>();
            return t;
        }

    }
}
