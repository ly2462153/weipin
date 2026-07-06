using System;
using weipin.Common;
using System.Configuration;
using System.Collections.Generic;

namespace weipin
{
    public partial class NewGoodsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGoodsList(Request.QueryString["p"]);
        }
        /// <summary>
        /// 绑定新品上架列表
        /// </summary>
        /// <param name="nowpage">当前页数</param>
        private void BindGoodsList(string nowpage)
        {
            if (!Commonality.JudgeNumber(nowpage, 5)) { nowpage = "1"; }
            BLL.Goods bg = new weipin.BLL.Goods();
            int _perpage = Convert.ToInt16(ConfigurationManager.AppSettings["GoodsListCount"].ToString());
            List<Model.Goods> lmg = bg.SelectGoodsNewPaging(Convert.ToInt16(nowpage), _perpage);
            if (lmg != null && lmg.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < lmg.Count; i++)
                {
                    string _path = lmg[i].GoodsPicturePath;
                    sb.Append("<div class=\"sec_cplsit\">");
                    if (lmg[i].DiscountPrice != 0) { sb.Append("<div class=\"zhek\">" + lmg[i].DiscountPrice + "</div>"); }
                    sb.Append("<ul><li><a href=\"/page/" + lmg[i].GoodsID / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + lmg[i].GoodsName + "\"><img src=\"" + _path.Insert(_path.LastIndexOf("."), "_170x170") + "\"/></a></li>");
                    sb.Append("<li class=\"cp_wz\"><a href=\"/page/" + lmg[i].GoodsID / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + lmg[i].GoodsName + "\">" + Commonality.CutString(lmg[i].GoodsName, 28) + "</a></li>");
                    sb.Append("<li>市场价：￥<span class=\"price_o\">" + lmg[i].MarketPrice.ToString() + "</span><span class=\"price_n\">微品价：￥" + lmg[i].Price.ToString() + "</span></li></ul></div>");
                }
                sb.Append("<div class=\"clear\"></div>");
                divGoodsList.InnerHtml = sb.ToString();
                divPaging.InnerHtml = Pagination.Paging(Convert.ToInt16(ConfigurationManager.AppSettings["NewGoodsListTotal"].ToString()), Convert.ToInt16(nowpage), _perpage, "NewGoodsList.aspx?p=", 11, "");
            }
            else { divGoodsList.InnerHtml = "抱歉，没有找到符合条件的商品"; }
        }
    }
}