using System;
using System.Web.UI.WebControls;
using weipin.Common;
using System.Configuration;
using weipin.Model;

namespace weipin.myhome
{
    public partial class MyReturnOrdersList : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindMyReturnOrdersList(Request.QueryString["p"]);
        }
        /// <summary>
        /// 绑定我的退换货
        /// </summary>
        /// <param name="nowpage">当前页</param>
        private void BindMyReturnOrdersList(string nowpage)
        {
            string _param = string.Empty;
            if (!Commonality.JudgeNumber(nowpage, 5)) { nowpage = "1"; }
            BLL.Orders bos = new weipin.BLL.Orders();
            int _perpage = Convert.ToInt16(ConfigurationManager.AppSettings["OrdersListCount"].ToString());
            DataList<Model.Orders> dmo = bos.SelectMyReturnOrdersListByLoginIDOfPaging(GetSessionOfLoginUser().LoginID, Convert.ToInt16(nowpage), _perpage);
            if (dmo != null && dmo.Rows.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<table><tr><th width=\"12%\">订单号</th><th width=\"28%\">订单商品</th><th width=\"10%\">收货人</th><th width=\"12%\">订单金额</th><th width=\"12%\">下单时间</th><th width=\"12%\">订单状态</th><th width=\"14%\">操作</th></tr>");
                for (int i = 0; i < dmo.Rows.Count; i++)
                {
                    sb.Append("<tr><td><a href=\"/myhome/MyOrdersDetails.aspx?oid=" + dmo.Rows[i].OrderID.ToString() + "\" target=\"_blank\">" + dmo.Rows[i].OrderID.ToString() + "</a></td>");
                    sb.Append("<td style=\"text-align:left;\"><div class=\"img-list\"><input type=\"hidden\" value=\"" + dmo.Rows[i].GoodsPicturePath.ToString() + "\"/></div></td>");
                    sb.Append("<td>" + dmo.Rows[i].ConsigneeName + "</td><td>￥" + dmo.Rows[i].CompleteAmount + "<br/>货到付款</td>");
                    sb.Append("<td><span>" + dmo.Rows[i].AddTime.ToShortDateString() + "<br/>" + dmo.Rows[i].AddTime.ToLongTimeString() + "</span></td><td>交易成功</td>");
                    sb.Append("<td style=\"color:#005ea7;\">");
                    sb.Append("<a href=\"ReturnGoodsList.aspx?oid=" + dmo.Rows[i].OrderID.ToString() + "\">退换货办理</a></td></tr>");
                }
                sb.Append("</table>");
                divMyReturnOrdersList.InnerHtml = sb.ToString();
                //ulPage.InnerHtml = "<li class=\"pad\">共<span class=\"red\">" + dmo.Total + "</span>个商品</li><li class=\"pad\">" + nowpage + "/" + Pagination.CountMaxPage(dmo.Total, _perpage) + "</li>" + Pagination.PagingOnlyFirstLast(dmo.Total, Convert.ToInt16(nowpage), _perpage, "GoodsList.aspx?p=", 11, _param);
                divPaging.InnerHtml = Pagination.Paging(dmo.Total, Convert.ToInt16(nowpage), _perpage, "/myhome/MyOrdersList.aspx?p=", 11, _param);
            }
            else { divMyReturnOrdersList.InnerHtml = "抱歉，没有找到可以退换货的订单！"; }
        }
    }
}