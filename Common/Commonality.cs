using System;
using System.Web;
using System.Text.RegularExpressions;

namespace weipin.Common
{
    public class Commonality
    {
        public Commonality()
        { }
        /// <summary>
        /// 判断指定长度的字符串是否为正整数/0
        /// </summary>
        /// <param name="num">要判断的字符串</param>
        /// <param name="maxlength">最大位数(一般Byte:3;Int16:5;Int32:10;Int64:19)</param>
        /// <returns>true:正整数/0</returns>
        public static bool JudgeNumber(string num, byte maxlength)
        {
            bool _result = false;
            if (!string.IsNullOrEmpty(num) && num.Length < maxlength)
            {
                if (Regex.IsMatch(num, @"^\d+$")) { _result = true; } else { _result = false; }
            }
            return _result;
        }
        /// <summary>
        /// 判断指定长度的字符串是否为正数/0
        /// </summary>
        /// <param name="num">要判断的字符串</param>
        /// <param name="maxlength">最大位数</param>
        /// <returns>true:正数/0</returns>
        public static bool JudgeFloat(string num, byte maxlength)
        {
            bool _result = false;
            if (!string.IsNullOrEmpty(num) && num.Length < maxlength)
            {
                if (Regex.IsMatch(num, @"^\d+(\.\d+)?$")) { _result = true; } else { _result = false; }
            }
            return _result;
        }
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="cutcount">要截取的字符串长度</param>
        /// <returns></returns>
        public static string CutString(string str, int cutcount)
        {
            if (!string.IsNullOrEmpty(str)) { if (str.Length > cutcount) { str = str.Substring(0, cutcount); } }
            else { str = ""; }
            return str;
        }
        /// <summary>
        /// 移出URL中的指定参数
        /// </summary>
        /// <param name="url">原始url</param>
        /// <param name="param">需要移出的参数</param>
        /// <returns></returns>
        public static string RemoveParam(string url, string param)
        {
            if (url.Length < 1) return "";
            int _start = url.IndexOf(param + "=");
            if (_start < 0) return url;
            int _end = url.IndexOf("&", _start);
            if (_end < 0)
            {
                return url.Remove(_start - 1);
            }
            int count = _end - _start + 1;
            return url.Remove(_start, count);
        }
        /// <summary>
        /// 删除Cache
        /// </summary>
        /// <param name="cachename">要删除的Cache名称</param>
        public static void ClearCache(string cachename)
        {
            HttpRuntime.Cache.Remove(cachename);
        }
    }
}