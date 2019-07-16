using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ilvbu.Service.Impl.Common
{
    public class ConvertUtility
    {
        public static string GetFileBase64(String fileName)
        {
            FileStream filestream = new FileStream(fileName, FileMode.Open);
            byte[] arr = new byte[filestream.Length];
            filestream.Read(arr, 0, (int)filestream.Length);
            string baser64 = Convert.ToBase64String(arr);
            filestream.Close();
            return baser64;
        }
        public static string GetFileBase64(byte[] arr)
        {
            string baser64 = Convert.ToBase64String(arr);
            return baser64;
        }
    }
}
