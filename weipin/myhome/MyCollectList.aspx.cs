using System;
using System.Web.UI.WebControls;
using weipin.Common;
using System.Configuration;
using weipin.Model;

namespace weipin.myhome
{
    public partial class MyCollectList : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindMyCollectList(Request.QueryString["p"]);
        }
        /// <summary>
        /// 绑定我的收藏列表
        /// </summary>
        /// <param name="nowpage">当前页</param>
        private void BindMyCollectList(string nowpage)
        {
            string _param = string.Empty;
            if (!Commonality.JudgeNumber(nowpage, 5)) { nowpage = "1"; }
            BLL.GoodsCollect bgc = new weipin.BLL.GoodsCollect();
            int _perpage = Convert.ToInt16(ConfigurationManager.AppSettings["GoodsCollectListCount"].ToString());
            DataList<Model.GoodsCollect> dmgc = bgc.SelectMyGoodsCollectByLoginIDOfPaging(GetSessionOfLoginUser().LoginID, Convert.ToInt16(nowpage), _perpage);
            if (dmgc != null && dmgc.Rows.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<table><tr><th width=\"2%\"><input type=\"checkbox\" onclick=\"ChooseAll(this);\"/></th><th width=\"16%\"><a href=\"#\" onclick=\"ChooseAll(this);return false;\" style=\"padding-right:6px;\">全选</a><a href=\"javascript:DeleteAll();\">删除</a></th><th width=\"50%\">商品</th><th width=\"12%\">价格</th><th width=\"12%\">收藏时间</th><th width=\"8%\">&nbsp;</th></tr>");
                for (int i = 0; i < dmgc.Rows.Count; i++)
                {
                    string _path = dmgc.Rows[i].GoodsPicturePath;
                    sb.Append("<tr><td><input type=\"checkbox\" value=\"" + dmgc.Rows[i].CollectID.ToString() + "\"/></td><td colspan=2 style=\"text-align:left;\"><div class=\"img-list\"><a href=\"/page/" + dmgc.Rows[i].GoodsID / 1000 + "/goodsshow_" + dmgc.Rows[i].GoodsID.ToString() + ".html\" target=\"_blank\"><img src=\"" + _path.Insert(_path.LastIndexOf("."), "_60x60") + "\"/></a>");
                    sb.Append("<a href=\"/page/" + dmgc.Rows[i].GoodsID / 1000 + "/goodsshow_" + dmgc.Rows[i].GoodsID.ToString() + ".html\" target=\"_blank\" style=\"padding-left:10px;\">" + dmgc.Rows[i].GoodsName + "</a></div></td>");
                    if (dmgc.Rows[i].DiscountPrice != 0) { sb.Append("<td>￥" + dmgc.Rows[i].DiscountPrice.ToString() + "</td>"); }
                    else { sb.Append("<td>￥" + dmgc.Rows[i].Price.ToString() + "</td>"); }
                    sb.Append("<td><span>" + dmgc.Rows[i].AddTime + "</span></td><td style=\"text-align:center;\"><a href=\"#\" onclick=\"DeleteCollect('" + dmgc.Rows[i].CollectID + "',this);return false;\" style=\"float:none;\">删除</a></td></tr>");
                }
                sb.Append("</table>");
                divCollectList.InnerHtml = sb.ToString();
                ulPage.InnerHtml = "<li style=\"padding:5px;\">共收藏了<span class=\"red\">" + dmgc.Total + "</span>个商品</li>";
                divPaging.InnerHtml = Pagination.Paging(dmgc.Total, Convert.ToInt16(nowpage), _perpage, "/myhome/MyCollectList.aspx?p=", 11, _param);
            }
            else { divCollectList.InnerHtml = "您还没有收藏任何商品！"; }
        }
    }
}