using System;
using System.Collections.Generic;
using System.Text;

namespace weipin.Common
{
    public class Pagination
    {
        public Pagination()
        { }
        /// <summary>
        /// 计算分页开始/结束条数
        /// </summary>
        /// <param name="_nowpage">当前页</param>
        /// <param name="_perpage">每页条数</param>
        /// <returns></returns>
        public static string[] CountStartEnd(int nowpage, int perpage)
        {
            string[] _arr = new string[2];
            _arr[0] = ((nowpage - 1) * perpage + 1).ToString();
            _arr[1] = (Convert.ToInt16(_arr[0]) + perpage - 1).ToString();
            return _arr;
        }
        /// <summary>
        /// 计算当前实际的最大页数
        /// </summary>
        /// <param name="_total">总条数</param>
        /// <param name="_perpage">每页条数</param>
        /// <returns></returns>
        public static int CountMaxPage(int total, int perpage)
        {
            int _maxpage = 0;
            if (total % perpage == 0) { _maxpage = total / perpage; }
            else { _maxpage = total / perpage + 1; }
            return _maxpage;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="total">总条数</param>
        /// <param name="now">当前页</param>
        /// <param name="per">每页显示条数</param>
        /// <param name="url">页面url</param>
        /// <param name="showpage">显示总页数</param>
        /// <param name="param">参数链接</param>
        /// <returns>分页代码</returns>
        public static string Paging(int total, int now, int per, string url, int showpage, string param)
        {
            total = (total - 1) / per + 1;
            int offset = showpage / 2;
            if (now < 1) now = 1;
            if (now > total) now = total;
            int start = now - offset;
            if (start < 1) start = 1;
            int end = start + showpage - 1;
            if (end > total)
            {
                end = total;
                if (end < showpage) start = 1;
                else start = end - showpage + 1;
            }
            if (total == 1) return "";
            string rs = string.Empty;
            if (now > 1) rs += "<a href=\"" + url + (now - 1) + param + "\" class=\"arrow_up\" style=\"padding-left:20px;\">上一页</a>";
            for (int i = start; i <= end; i++)
            {
                if (i == now)
                {
                    rs += "<span class=\"pageon\">" + i + "</span>";
                }
                else
                {
                    rs += "<a href=\"" + url + i + param + "\">" + i + "</a>";
                }
            }
            if (now < total) rs += "<a href=\"" + url + (now + 1) + param + "\" class=\"arrow_down\" style=\"padding-left:20px;\">下一页</a>";
            return rs;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="total">总条数</param>
        /// <param name="now">当前页</param>
        /// <param name="per">每页显示条数</param>
        /// <param name="url">页面url</param>
        /// <param name="showpage">显示总页数</param>
        /// <param name="param">参数链接</param>
        /// <returns>分页代码</returns>
        public static string PagingOnlyFirstLast(int total, int now, int per, string url, int showpage, string param)
        {
            total = (total - 1) / per + 1;
            int offset = showpage / 2;
            if (now < 1) now = 1;
            if (now > total) now = total;
            int start = now - offset;
            if (start < 1) start = 1;
            int end = start + showpage - 1;
            if (end > total)
            {
                end = total;
                if (end < showpage) start = 1;
                else start = end - showpage + 1;
            }
            if (total == 1) return "";
            string rs = string.Empty;
            if (now > 1) { rs += "<li><a href=\"" + url + (now - 1) + param + "\" class=\"type_but ico_type3\">上一页</a></li>"; }
            else { rs += "<li><span class=\"type_but ico_type3\" style=\"color:#ccc;\">上一页</span></li>"; }
            if (now < total) { rs += "<li><a href=\"" + url + (now + 1) + param + "\" class=\"type_but ico_type4\">下一页</a></li>"; }
            else { rs += "<li><span class=\"type_but ico_type4\" style=\"color:#ccc;\">下一页</span></li>"; }
            return rs;
        }
        /// <summary>
        /// 分页(包含“首页/尾页”按钮)
        /// </summary>
        /// <param name="total">总条数</param>
        /// <param name="now">当前页</param>
        /// <param name="per">每页显示条数</param>
        /// <param name="url">页面url</param>
        /// <param name="showpage">显示总页数</param>
        /// <param name="param">参数链接</param>
        /// <returns>分页代码</returns>
        public static string PagingFirstLast(int total, int now, int per, string url, int showpage, string param)
        {
            total = (total - 1) / per + 1;
            int offset = showpage / 2;
            if (now < 1) now = 1;
            if (now > total) now = total;
            int start = now - offset;
            if (start < 1) start = 1;
            int end = start + showpage - 1;
            if (end > total)
            {
                end = total;
                if (end < showpage) start = 1;
                else start = end - showpage + 1;
            }
            if (total == 1) return "";
            string rs = "", style = "";
            if (now > 1)
            {
                rs += "<li><a href=\"" + url + (1) + param + "\">首页</a></li><li><a href=\"" + url + (now - 1) + param + "\">上一页</a></li>";
            }
            for (int i = start; i <= end; i++)
            {
                if (i == now)
                {
                    style = "style=\"color:#f00;font-weight:bold;\"";
                    rs += "<li><span " + style + ">" + i + "</span></li>";
                }
                else
                {
                    style = "";
                    rs += "<li><a href=\"" + url + i + param + "\" " + style + ">" + i + "</a></li>";
                }
            }
            if (now < total) rs += "<li><a href=\"" + url + (now + 1) + param + "\">下一页</a></li><li><a href=\"" + url + (total) + param + "\">尾页</a></li>";
            return rs;
        }
        /// <summary>
        /// 分页(静态,包含“首页/尾页”按钮)
        /// </summary>
        /// <param name="total">总条数</param>
        /// <param name="now">当前页</param>
        /// <param name="per">每页显示条数</param>
        /// <param name="url">页面url</param>
        /// <param name="showpage">显示总页数</param>
        /// <param name="suffix">链接后缀</param>
        /// <returns>分页代码</returns>
        public static string PagingFirstLastStatic(int total, int now, int per, string url, int showpage, string suffix)
        {
            total = (total - 1) / per + 1;
            int offset = showpage / 2;
            if (now < 1) now = 1;
            if (now > total) now = total;
            int start = now - offset;
            if (start < 1) start = 1;
            int end = start + showpage - 1;
            if (end > total)
            {
                end = total;
                if (end < showpage) start = 1;
                else start = end - showpage + 1;
            }
            if (total == 1) return "";
            string rs = "", style = "";
            if (now > 1)
            {
                rs += "<li><a href=\"" + url + (1) + suffix + "\">首页</a></li><li><a href=\"" + url + (now - 1) + suffix + "\">上一页</a></li>";
            }
            for (int i = start; i <= end; i++)
            {
                if (i == now)
                {
                    style = "style=\"color:#f00;font-weight:bold;\"";
                    rs += "<li><span " + style + ">" + i + "</span></li>";
                }
                else
                {
                    style = "";
                    rs += "<li><a href=\"" + url + i + suffix + "\" " + style + ">" + i + "</a></li>";
                }
            }
            if (now < total) rs += "<li><a href=\"" + url + (now + 1) + suffix + "\">下一页</a></li><li><a href=\"" + url + (total) + suffix + "\">尾页</a></li>";
            return rs;
        }
    }
}