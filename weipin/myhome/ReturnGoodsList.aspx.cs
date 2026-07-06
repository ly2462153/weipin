using System;
using System.Collections.Generic;
using System.Web.UI;
using weipin.Common;

namespace weipin.myhome
{
    public partial class ReturnGoodsList : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Commonality.JudgeNumber(Request.Form["hidOrderID"], 10) && Request.Form["hidOrdersStatus"] != null)
            {
                ReturnChangeGoods();
            }
            else if (Commonality.JudgeNumber(Request.QueryString["oid"], 10))
            {
                BindMySucceeOrdersList(Convert.ToInt32(Request.QueryString["oid"].ToString()));
            }
        }
        /// <summary>
        /// 绑定我的交易成功的订单
        /// <param name="oid">订单ID</param>
        /// </summary>
        private void BindMySucceeOrdersList(int oid)
        {
            BLL.Orders_Goods bg = new weipin.BLL.Orders_Goods();
            List<Model.Orders_Goods> lmg = bg.SelectMySucceeOrdersGoodsByLoginID(GetSessionOfLoginUser().LoginID, oid);
            if (lmg != null && lmg.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<table><tr><th width=\"50%\">商品</th><th width=\"15%\">成交单价</th><th width=\"15%\">可退换货数量</th><th width=\"20%\">操作</th></tr>");
                for (int i = 0; i < lmg.Count; i++)
                {
                    if (i == 0) { hidOrderID.Value = lmg[i].OrderID.ToString(); }
                    string _path = lmg[i].GoodsPicturePath;
                    sb.Append("<tr><td style=\"text-align:left;\"><div class=\"img-list\"><a href=\"/page/" + lmg[i].GoodsID / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" target=\"_blank\"><img src=\"" + _path.Insert(_path.LastIndexOf("."), "_60x60") + "\"/></a>");
                    sb.Append("<a href=\"/page/" + lmg[i].GoodsID / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" target=\"_blank\" style=\"padding-left:10px;\">" + lmg[i].GoodsName + "</a></div></td>");
                    sb.Append("<td>￥" + lmg[i].TransactionPrice.ToString() + "</td><td>" + lmg[i].CompleteCount.ToString() + "</td><td class=\"edit\">");
                    if (lmg[i].GoodsStatus == 5) { sb.Append("已完成退货"); }
                    else if (lmg[i].GoodsStatus == 6 && lmg[i].CompleteCount != 0)
                    {
                        sb.Append("换货<input type=\"checkbox\" name=\"ckbOrdersGoods" + lmg[i].OrdersGoodsID.ToString() + "\" value=\"3\"/><br/>退货<input type=\"checkbox\" name=\"ckbOrdersGoods" + lmg[i].OrdersGoodsID.ToString() + "\" value=\"4\"/>");
                    }
                    else { sb.Append("-"); }
                    sb.Append("</td></tr>");
                }
                sb.Append("</table>");
                divMySucceeOrdersList.InnerHtml = sb.ToString();
            }
            else { divMySucceeOrdersList.InnerHtml = "抱歉，没有找到符合条件的订单商品！"; }
        }
        /// <summary>
        /// 退换货办理
        /// </summary>
        private void ReturnChangeGoods()
        {
            int _orderid = Convert.ToInt32(Request.Form["hidOrderID"].ToString());
            byte _ordersstatus = 0;
            if (Request.Form["hidOrdersStatus"].ToString() == "3" || Request.Form["hidOrdersStatus"].ToString() == "4")
            {
                _ordersstatus = Convert.ToByte(Request.Form["hidOrdersStatus"].ToString());
            }
            string[] _ordersgoods = Request.Form["hidGoodsStatus"].ToString().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            System.Text.StringBuilder sbSQL = new System.Text.StringBuilder();
            for (int i = 0; i < _ordersgoods.Length; i++)
            {
                //拼接更新GoodsStatus的SQL
                string _ogid = _ordersgoods[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                string _status = _ordersgoods[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1];
                if (Commonality.JudgeNumber(_ogid, 10) && (_status == "3" || _status == "4"))
                {
                    sbSQL.Append(" update Orders_Goods set GoodsStatus=" + _status + " where OrdersGoodsID=" + _ogid + " and GoodsStatus=6 and CompleteCount<>0");
                }
            }
            string _reasons = Request.Form["txtExchangeReturnReasons"].ToString();
            if (_reasons != "") { Commonality.CutString(_reasons, 350); }
            else { ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">alert('退换货理由为必填项且不能超过300个字');</script>"); return; }
            if (sbSQL.ToString() != "")
            {
                BLL.Orders_Goods bog = new weipin.BLL.Orders_Goods();
                int _res = bog.UpdateOrders_GoodsStatusByLoginID(_orderid, _ordersstatus, GetSessionOfLoginUser().LoginID, sbSQL.ToString(), _reasons);
                if (_res == 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:提交成功<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"0\",\"\");</script>");
                }
                else if (_res == -1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:您没有该订单的操作权限或退换货时间过期<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"0\",\"\");</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:提交失败<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"0\",\"\");</script>");
                }
            }
        }
    }
}