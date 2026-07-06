using System;
using System.Web.UI.WebControls;
using weipin.Common;
using System.Configuration;
using weipin.Model;

namespace weipin.myhome
{
    public partial class GoodsCommentsList : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGoodsCommentsList(Request.QueryString["p"]);
        }
        /// <summary>
        /// 绑定我的评论列表
        /// </summary>
        /// <param name="nowpage">当前页</param>
        private void BindGoodsCommentsList(string nowpage)
        {
            string _param = string.Empty;
            if (!Commonality.JudgeNumber(nowpage, 5)) { nowpage = "1"; }
            BLL.GoodsComments bgc = new weipin.BLL.GoodsComments();
            int _perpage = Convert.ToInt16(ConfigurationManager.AppSettings["GoodsCommentsListCount"].ToString());
            DataList<Model.GoodsComments> dmgc = bgc.SelectMyGoodsCommentsByLoginIDOfPaging(GetSessionOfLoginUser().LoginID, Convert.ToInt16(nowpage), _perpage);
            if (dmgc != null && dmgc.Rows.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<table>");
                for (int i = 0; i < dmgc.Rows.Count; i++)
                {
                    sb.Append("<tr><td width=\"20%\">订单号:<a href=\"/myhome/MyOrdersDetails.aspx?oid=" + dmgc.Rows[i].OrderID.ToString() + "\" target=\"_blank\">" + dmgc.Rows[i].OrderID.ToString() + "</a><br/><br/>购买日期:" + dmgc.Rows[i].AddTime.ToShortDateString() + "<br/><br/><div>");
                    if (dmgc.Rows[i].IsCommented == true) { sb.Append("<span class=\"commented\" style=\"margin:0px auto;\">(交易已评论)</span>"); }
                    else { sb.Append(""); }
                    //else { sb.Append("<a href=\"#\" class=\"comment\" style=\"margin:0px auto;\" target=\"_blank\">交易评论</a>"); }若将交易评论功能制作完成后可将此注释内容替换上一行代码else { sb.Append(""); }
                    sb.Append("</div></td><td width=\"80%\" style=\"text-align:left\"><div class=\"img-list\"><input type=\"hidden\" value=\"" + dmgc.Rows[i].GoodsPicturePath.ToString() + "\"/></div></td></tr>");
                }
                sb.Append("</table>");
                divGoodsCommentsList.InnerHtml = sb.ToString();
                //ulPage.InnerHtml = "<li class=\"pad\">共<span class=\"red\">" + dmgc.Total + "</span>个商品</li><li class=\"pad\">" + nowpage + "/" + Pagination.CountMaxPage(dmgc.Total, _perpage) + "</li>" + Pagination.PagingOnlyFirstLast(dmgc.Total, Convert.ToInt16(nowpage), _perpage, "GoodsList.aspx?p=", 11, _param);
                divPaging.InnerHtml = Pagination.Paging(dmgc.Total, Convert.ToInt16(nowpage), _perpage, "/myhome/GoodsCommentsList.aspx?p=", 11, _param);
            }
            else { divGoodsCommentsList.InnerHtml = "您没有可以评论的商品！"; }
        }
    }
}