using System;
using System.Text.RegularExpressions; 
using System.Web;

namespace FanLi.Common
{
    /// <summary>
    /// 过滤提交数据
    /// </summary>
    public class SafeHelper
    {
        //过滤正则
        private const string StrRegex = @"\b(alert|confirm|prompt)\b|^\+/v(8|9)|\b(and|or)\b.{1,6}?(=|>|<|\bin\b|\blike\b)|/\*.+?\*/|<\s*script\b|<\s*/script\b|<\s*iframe\b|<\s*/iframe\b|<\s*img\b|<.+?\b|"".*?|'.*?|\bEXEC\b|UNION.+?SELECT|UPDATE.+?SET|INSERT\s+INTO.+?VALUES|(SELECT|DELETE).+?FROM|(CREATE|ALTER|DROP|TRUNCATE)\s+(TABLE|DATABASE)";

        /// <summary>
        /// 检查post提交的数据
        /// </summary>
        /// <returns></returns>
        public static bool PostData()
        {
            bool result = false;
            for (int i = 0; i < HttpContext.Current.Request.Form.Count; i++)
            {
                result = CheckData(HttpContext.Current.Request.Form[i].ToLower());
                if (result)
                {
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 检查get提交的数据
        /// </summary>
        /// <returns></returns>
        public static bool GetData()
        {
            bool result = false;
            for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
            {
                result = CheckData(HttpContext.Current.Request.QueryString[i].ToLower());
                if (result)
                {
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 检查cookie
        /// </summary>
        /// <returns></returns>
        public static bool CookieData()
        {
            bool result = false;
            for (int i = 0; i < HttpContext.Current.Request.Cookies.Count; i++)
            {
                result = CheckData(HttpContext.Current.Request.Cookies[i].Value.ToLower());
                if (result)
                {
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 检查危险字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool CheckData(string inputData)
        {
            return Regex.IsMatch(inputData, StrRegex);
        }

        /// <summary>
        /// 检查过滤所有提交的数据
        /// </summary>
        public static void Filter()
        {
            string msg = "<div style='position:fixed;top:0px;width:100%;height:100%;background-color:white;color:green;font-weight:bold;border-bottom:5px solid #999;'><br>您的提交带有不合法参数,谢谢合作!</div>";

            if (CookieData())
            {
                HttpContext.Current.Response.Write(msg);
                HttpContext.Current.Response.End();
            }

            if (HttpContext.Current.Request.RequestType.ToUpper() == "POST")
            {
                if (PostData())
                {
                    HttpContext.Current.Response.Write(msg);
                    HttpContext.Current.Response.End();
                }
            }
            if (HttpContext.Current.Request.RequestType.ToUpper() == "GET")
            {
                if (GetData())
                {
                    HttpContext.Current.Response.Write(msg);
                    HttpContext.Current.Response.End();
                }
            }
        }
    }
}
