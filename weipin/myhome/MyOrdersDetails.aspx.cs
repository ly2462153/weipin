using System;
using System.Data;
using System.Collections.Generic;

namespace weipin.myhome
{
    public partial class MyOrdersDetails : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.Commonality.JudgeNumber(Request.QueryString["oid"], 10)) { BindOrdersByOrderID(Convert.ToInt32(Request.QueryString["oid"].ToString())); }
            else { divOrderID.InnerText = "抱歉,没有找到符合的订单"; divConsigneeInfo.Visible = false; divShippingInfo.Visible = false; divOrdersList.Visible = false; }
        }
        /// <summary>
        /// 查询订单详情
        /// <param name="_oid">订单ID</param>
        /// </summary>
        private void BindOrdersByOrderID(int _oid)
        {
            BLL.Orders bo = new weipin.BLL.Orders();
            Model.Orders mo = bo.SelectMyOrdersByID(GetSessionOfLoginUser().LoginID, _oid);
            if (mo != null && mo.OrderID != 0)
            {
                divOrderID.InnerHtml = "<h1>订单号：" + mo.OrderID.ToString() + "</h1>";
                divConsigneeInfo.InnerHtml = "<h1>收货信息</h1><div class=\"div_bottom\"><ul><li>收货人：" + mo.ConsigneeName + "</li><li>地址：<span id=\"spArea\"><input type=\"hidden\" value=\"" + mo.AreaID.ToString() + "\"/>" + mo.ShippingAddress + "</span></li><li>手机：" + mo.MobilePhone + "</li><li>座机：" + mo.Telephone + "</li><li>E-mail：" + mo.Email + "</li><li>邮编：" + mo.Zipcode + "</li></ul></div>";
                string _shippinginfo = "<h1>支付及配送信息</h1><div class=\"div_bottom\"><ul><li>支付方式：货到付款</li><li>配送方式：快递</li><li>付款方式：现金</li><li>";
                switch (mo.DeliveryPeriod)
                {
                    case 1: _shippinginfo += "送货日期：只工作日送货(双休日、假日不用送)"; break;
                    case 2: _shippinginfo += "送货日期：工作日、双休日与假日均可送货"; break;
                    case 3: _shippinginfo += "送货日期：只双休日、假日送货(工作日不用送)"; break;
                }
                divShippingInfo.InnerHtml = _shippinginfo + "</li></ul></div>";
                //switch (mo.OrdersStatus)
                //{
                //    case 1: lblOrdersStatus.InnerText = "订货"; break;
                //    case 2: lblOrdersStatus.InnerText = "出库(取货)"; break;
                //    case 3: lblOrdersStatus.InnerText = "换货"; break;
                //    case 4: lblOrdersStatus.InnerText = "退货"; break;
                //    case 5: lblOrdersStatus.InnerText = "退货成功"; break;
                //    case 6: lblOrdersStatus.InnerText = "交易成功"; break;
                //}
                //switch (mo.LogisticsStatus)
                //{
                //    case 1: lblLogisticsStatus.InnerText = "处理中"; break;
                //    case 2: lblLogisticsStatus.InnerText = "已发货"; break;
                //    case 3: lblLogisticsStatus.InnerText = "已完成"; break;
                //}

                //查询当前订单下的商品列表
                BLL.Orders_Goods bog = new weipin.BLL.Orders_Goods();
                List<Model.Orders_Goods> lmog = bog.SelectMyOrders_GoodsByOrderID(_oid);
                if (lmog != null && lmog.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<h1>商品清单</h1><div class=\"div_bottom\" style=\"padding:0;\"><table><tr><th width=\"20%\">商品编号</th><th width=\"50%\">商品名称</th><th width=\"10%\">单价</th><th width=\"10%\">订购数量</th><th width=\"10%\">成交数量</th></tr>");
                    for (int i = 0; i < lmog.Count; i++)
                    {
                        sb.Append("<tr><td>" + lmog[i].GoodsID.ToString() + "</td><td style=\"text-align: left;\">");
                        if (lmog[i].SizeName != "") { sb.Append(lmog[i].GoodsName + "_" + lmog[i].SizeName); } else { sb.Append(lmog[i].GoodsName); }
                        sb.Append("</td><td>￥" + lmog[i].TransactionPrice.ToString() + "</td><td>" + lmog[i].GoodsCount.ToString() + "</td><td>" + lmog[i].CompleteCount.ToString() + "</td></tr>");
                    }
                    sb.Append("</table></div>");
                    divOrdersList.InnerHtml = sb.ToString();
                }
            }
            else { divOrderID.InnerText = "抱歉,没有找到符合的订单"; divConsigneeInfo.Visible = false; divShippingInfo.Visible = false; divOrdersList.Visible = false; }
        }
    }
}