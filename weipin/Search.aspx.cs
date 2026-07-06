using System;
using System.Collections.Generic;
using weipin.Common;
using weipin.Model;

namespace weipin
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["key"] != null && Request.QueryString["key"].ToString().Trim() != "") { BindGoodsSearch(Server.UrlDecode(Request.QueryString["key"].ToString()).Trim(), Request.QueryString["p"], Request.QueryString["st"]); }
            else { divSearchList.InnerText = "请输入搜索关键词"; }
        }
        /// <summary>
        /// 绑定搜索到的商品
        /// </summary>
        /// <param name="key">搜索关键词</param>
        /// <param name="nowpage">当前页</param>
        /// <param name="st">排序编号</param>
        private void BindGoodsSearch(string key, string nowpage, string st)
        {
            hidKey.Value = key;
            string _param = string.Empty;
            string _field = string.Empty;
            bool _sort = false;
            if (Commonality.JudgeNumber(st, 3))
            {
                switch (st)
                {
                    case "2": _field = "AddTime"; _sort = true; break;
                    case "3": _field = "DiscountPrice"; _sort = false; break;
                    case "4": _field = "DiscountPrice"; _sort = true; break;
                }
                hidSort.Value = st;
            }
            else { hidSort.Value = "1"; }
            _param += "&st=" + hidSort.Value;
            BLL.SE bs = new weipin.BLL.SE();
            if (!Commonality.JudgeNumber(nowpage, 5)) { nowpage = "1"; }
            _param += "&key=" + key;
            int _perpage = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["GoodsListCount"].ToString());
            DataList<Model.Goods> dmg = bs.GoodsSearch(key, Convert.ToInt16(nowpage), _perpage, _field, _sort);
            if (dmg != null && dmg.Rows.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < dmg.Rows.Count; i++)
                {
                    string _path = dmg.Rows[i].GoodsPicturePath;
                    sb.Append("<div class=\"sec_cplsit\">");
                    if (dmg.Rows[i].DiscountPrice != dmg.Rows[i].Price) { sb.Append("<div class=\"zhek\">" + dmg.Rows[i].DiscountPrice + "</div>"); }
                    sb.Append("<ul><li><a href=\"/page/" + dmg.Rows[i].GoodsID / 1000 + "/goodsshow_" + dmg.Rows[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + dmg.Rows[i].GoodsName + "\"><img src=\"" + _path.Insert(_path.LastIndexOf("."), "_170x170") + "\"/></a></li>");
                    sb.Append("<li class=\"cp_wz\"><a href=\"/page/" + dmg.Rows[i].GoodsID / 1000 + "/goodsshow_" + dmg.Rows[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + dmg.Rows[i].GoodsName + "\">" + (dmg.Rows[i].GoodsNameStyle != "" ? dmg.Rows[i].GoodsNameStyle : Commonality.CutString(dmg.Rows[i].GoodsName, 28)) + "</a></li>");
                    sb.Append("<li>市场价：￥<span class=\"price_o\">" + dmg.Rows[i].MarketPrice.ToString() + "</span><span class=\"price_n\">微品价：￥" + dmg.Rows[i].Price.ToString() + "</span></li></ul></div>");
                }
                sb.Append("<div class=\"clear\"></div>");
                divSearchList.InnerHtml = sb.ToString();
                ulPage.InnerHtml = "<li class=\"pad\">找到和<span class=\"red\">" + (key.Length > 7 ? key.Substring(0, 6) + "…" : key) + "</span>相关的商品共<span class=\"red\">" + dmg.Total + "</span>个</li><li class=\"pad\">" + nowpage + "/" + Pagination.CountMaxPage(dmg.Total, _perpage) + "</li>" + Pagination.PagingOnlyFirstLast(dmg.Total, Convert.ToInt16(nowpage), _perpage, "Search.aspx?p=", 11, _param);
                divPaging.InnerHtml = Pagination.Paging(dmg.Total, Convert.ToInt16(nowpage), _perpage, "Search.aspx?p=", 11, _param);
            }
            else { divSearchList.InnerHtml = "抱歉，没有找到符合条件的商品"; }
        }
    }
}