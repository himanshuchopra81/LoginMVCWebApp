using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LoginMVC.Helper
{
    public static class Hashing
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string GetHashText(string txt)
        {
            byte[] tmpSource = new UTF8Encoding().GetBytes(txt);
            return Convert.ToBase64String(tmpSource);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string DecodeText(string txt)
        {
            byte[] tmpData = Convert.FromBase64String(txt);
            string tmp = new UTF8Encoding().GetString(tmpData);
            return tmp;
        }
    }
}