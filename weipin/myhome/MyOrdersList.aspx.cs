using System;
using System.Web.UI.WebControls;
using weipin.Common;
using System.Configuration;
using weipin.Model;
using System.Xml;

namespace weipin.myhome
{
    public partial class MyOrdersList : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindMyOrdersList(Request.QueryString["p"]);
        }
        /// <summary>
        /// 绑定我的订单列表
        /// </summary>
        /// <param name="nowpage">当前页</param>
        private void BindMyOrdersList(string nowpage)
        {
            string _param = string.Empty;
            if (!Commonality.JudgeNumber(nowpage, 5)) { nowpage = "1"; }
            BLL.Orders bos = new weipin.BLL.Orders();
            int _perpage = Convert.ToInt16(ConfigurationManager.AppSettings["OrdersListCount"].ToString());
            DataList<Model.Orders> dmo = bos.SelectMyOrdersByLoginIDOfPaging(GetSessionOfLoginUser().LoginID, Convert.ToInt16(nowpage), _perpage);
            if (dmo != null && dmo.Rows.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<table><tr><th width=\"12%\">订单号</th><th width=\"28%\">订单商品</th><th width=\"10%\">收货人</th><th width=\"12%\">订单金额</th><th width=\"12%\">下单时间</th><th width=\"12%\">订单状态</th><th width=\"14%\">操作</th></tr>");
                for (int i = 0; i < dmo.Rows.Count; i++)
                {
                    sb.Append("<tr><td><a href=\"/myhome/MyOrdersDetails.aspx?oid=" + dmo.Rows[i].OrderID.ToString() + "\" target=\"_blank\">" + dmo.Rows[i].OrderID.ToString() + "</a></td>");
                    sb.Append("<td style=\"text-align:left;\"><div class=\"img-list\"><input type=\"hidden\" value=\"" + dmo.Rows[i].GoodsPicturePath.ToString() + "\"/></div></td>");
                    sb.Append("<td>" + dmo.Rows[i].ConsigneeName + "</td><td>￥" + (dmo.Rows[i].CompleteAmount + Convert.ToInt16(GetAddressAndFeight(dmo.Rows[i].CompleteAmount, dmo.Rows[i].AreaID)[1])) + "<br/>");
                    if (dmo.Rows[i].PayWay == 1) { sb.Append("货到付款"); } else { if (dmo.Rows[i].IsPay == true) { sb.Append("支付宝已付款"); } else { if (dmo.Rows[i].IsCancel == false) { sb.Append("<a href=\"/alipay/default.aspx?hidOrderID=" + dmo.Rows[i].OrderID.ToString() + "\" class=\"a_go_alipay\"> </a>"); } } }
                    sb.Append("</td><td><span>" + dmo.Rows[i].AddTime.ToShortDateString() + "<br/>" + dmo.Rows[i].AddTime.ToLongTimeString() + "</span></td><td>");
                    if (dmo.Rows[i].IsCancel == true) { sb.Append("已取消"); }
                    else
                    {
                        switch (dmo.Rows[i].OrdersStatus)
                        {
                            case 1: if (dmo.Rows[i].PayWay != 1 && dmo.Rows[i].IsPay == false) { sb.Append("等待付款"); } else { sb.Append("处理中"); } break;
                            case 2: sb.Append("已出库"); break;
                            case 3: sb.Append("换货处理中"); break;
                            case 4: sb.Append("退货处理中"); break;
                            case 5: sb.Append("退货完成"); break;
                            case 6: sb.Append("交易成功"); break;
                        }
                    }
                    sb.Append("</td>");
                    if (dmo.Rows[i].IsCancel == true) { sb.Append("<td>-</td>"); }
                    else
                    {
                        switch (dmo.Rows[i].OrdersStatus)
                        {
                            case 1: sb.Append("<td><a href=\"#\" onclick=\"CancelOrders('" + dmo.Rows[i].OrderID.ToString() + "',this);return false;\">取消订单</a></td>"); break;
                            case 2: sb.Append("<td>-</td>"); break;
                            case 3: sb.Append("<td>-</td>"); break;
                            case 4: sb.Append("<td>-</td>"); break;
                            case 5: sb.Append("<td>-</td>"); break;
                            case 6:
                                sb.Append("<td style=\"color:#005ea7;\">");
                                if (dmo.Rows[i].IsCommented == false) { sb.Append("<a href=\"/myhome/GoodsCommentsList.aspx\">评论</a>"); }
                                if (dmo.Rows[i].DeliveryTime.AddDays(Convert.ToInt16(ConfigurationManager.AppSettings["ReturnAndChangeGoodsDeadline"].ToString())) >= DateTime.Now && dmo.Rows[i].LogisticsTimes <= 1)
                                {
                                    if (dmo.Rows[i].IsCommented == false) { sb.Append("|"); }
                                    sb.Append("<a href=\"ReturnGoodsList.aspx?oid=" + dmo.Rows[i].OrderID.ToString() + "\">退换货办理</a>");
                                }
                                sb.Append("</td>");
                                break;
                        }
                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                divOrdersList.InnerHtml = sb.ToString();
                //ulPage.InnerHtml = "<li class=\"pad\">共<span class=\"red\">" + dmo.Total + "</span>个商品</li><li class=\"pad\">" + nowpage + "/" + Pagination.CountMaxPage(dmo.Total, _perpage) + "</li>" + Pagination.PagingOnlyFirstLast(dmo.Total, Convert.ToInt16(nowpage), _perpage, "GoodsList.aspx?p=", 11, _param);
                divPaging.InnerHtml = Pagination.Paging(dmo.Total, Convert.ToInt16(nowpage), _perpage, "/myhome/MyOrdersList.aspx?p=", 11, _param);
            }
            else { divOrdersList.InnerHtml = "抱歉，没有找到符合条件的订单！"; }
        }
        /// <summary>
        /// 获取地址和运费
        /// </summary>
        /// <param name="ordermoney">订单金额</param>
        /// <param name="_areaid">区域ID</param>
        /// <returns></returns>
        private string[] GetAddressAndFeight(double ordermoney, int _areaid)
        {
            string[] arr = new string[2];
            string _path = Server.MapPath("~/xml/areas/areas.xml");
            if (System.IO.File.Exists(_path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_path);
                XmlNodeList nodelist = doc.GetElementsByTagName("ar");
                if (nodelist.Count > 0)
                {
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        if (_areaid.ToString() == nodelist[i].Attributes["ai"].Value && Common.Commonality.JudgeNumber(nodelist[i].Attributes["ai"].Value, 5))
                        {
                            arr[0] = nodelist[i].ParentNode.ParentNode.Attributes["an"].Value + nodelist[i].ParentNode.Attributes["an"].Value + nodelist[i].Attributes["an"].Value;
                            if (((_areaid > 1 && _areaid < 30 || _areaid > 30 && _areaid < 216 || _areaid > 216 && _areaid < 325 || _areaid > 325 && _areaid < 528 || _areaid > 528 && _areaid < 667 || _areaid > 1142 && _areaid < 1272 || _areaid > 1272 && _areaid < 1377 || _areaid > 1377 && _areaid < 1513 || _areaid > 1513 && _areaid < 1615 || _areaid > 1615 && _areaid < 1737 || _areaid > 1737 && _areaid < 1910 || _areaid > 1910 && _areaid < 2096 || _areaid > 2096 && _areaid < 2219 || _areaid > 2219 && _areaid < 2357 || _areaid > 2357 && _areaid < 2545 || _areaid > 2545 && _areaid < 2670 || _areaid > 2670 && _areaid < 2705 || _areaid > 2705 && _areaid < 2805 || _areaid > 2805 && _areaid < 2957 || _areaid > 3038 && _areaid < 3160) && ordermoney >= 38) || ((_areaid > 667 && _areaid < 785 || _areaid > 785 && _areaid < 915 || _areaid > 915 && _areaid < 991 || _areaid > 991 && _areaid < 1142 || _areaid > 2957 && _areaid < 3038 || _areaid > 3160 && _areaid < 3263 || _areaid > 3263 && _areaid < 3316 || _areaid > 3316 && _areaid < 3346 || _areaid > 3346 && _areaid < 3463) && ordermoney >= 68)) { arr[1] = "0"; } else { arr[1] = nodelist[i].Attributes["fr"].Value; }
                            break;
                        }
                    }
                }
            }
            return arr;
        }
    }
}