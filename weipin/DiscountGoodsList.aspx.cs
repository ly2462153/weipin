using System;
using weipin.Common;
using System.Configuration;
using weipin.Model;

namespace weipin
{
    public partial class DiscountGoodsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGoodsList(Request.QueryString["p"]);
        }
        /// <summary>
        /// 绑定特惠抢购列表
        /// </summary>
        /// <param name="nowpage">当前页数</param>
        private void BindGoodsList(string nowpage)
        {
            if (!Commonality.JudgeNumber(nowpage, 5)) { nowpage = "1"; }
            BLL.Goods bg = new weipin.BLL.Goods();
            int _perpage = Convert.ToInt16(ConfigurationManager.AppSettings["GoodsListCount"].ToString());
            DataList<Model.Goods> dmg = bg.SelectGoodsDiscountPaging(Convert.ToInt16(nowpage), _perpage);
            if (dmg != null && dmg.Rows.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < dmg.Rows.Count; i++)
                {
                    string _path = dmg.Rows[i].GoodsPicturePath;
                    sb.Append("<div class=\"sec_cplsit\">");
                    if (dmg.Rows[i].DiscountPrice != 0) { sb.Append("<div class=\"zhek\">" + dmg.Rows[i].DiscountPrice + "</div>"); }
                    sb.Append("<ul><li><a href=\"/page/" + dmg.Rows[i].GoodsID / 1000 + "/goodsshow_" + dmg.Rows[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + dmg.Rows[i].GoodsName + "\"><img src=\"" + _path.Insert(_path.LastIndexOf("."), "_170x170") + "\"/></a></li>");
                    sb.Append("<li class=\"cp_wz\"><a href=\"/page/" + dmg.Rows[i].GoodsID / 1000 + "/goodsshow_" + dmg.Rows[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + dmg.Rows[i].GoodsName + "\">" + Commonality.CutString(dmg.Rows[i].GoodsName, 28) + "</a></li>");
                    sb.Append("<li>市场价：￥<span class=\"price_o\">" + dmg.Rows[i].MarketPrice.ToString() + "</span><span class=\"price_n\">微品价：￥" + dmg.Rows[i].Price.ToString() + "</span></li></ul></div>");
                }
                sb.Append("<div class=\"clear\"></div>");
                divGoodsList.InnerHtml = sb.ToString();
                divPaging.InnerHtml = Pagination.Paging(dmg.Total, Convert.ToInt16(nowpage), _perpage, "DiscountGoodsList.aspx?p=", 11, "");
            }
            else { divGoodsList.InnerHtml = "抱歉，没有找到符合条件的商品"; }
        }
    }
}