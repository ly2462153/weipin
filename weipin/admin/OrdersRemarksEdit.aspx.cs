using System;
using System.Data;
using System.Collections;

namespace weipin.admin
{
    public partial class OrdersRemarksEdit : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["hidOrderID"] != null)
            {
                InsertOrdersRemarksEdit();
            }
            else if (Common.Commonality.JudgeNumber(Request.QueryString["ogid"], 10))
            {
                BindOrdersGoods(Convert.ToInt32(Request.QueryString["ogid"].ToString()));
            }
        }
        /// <summary>
        /// 绑定
        /// </summary>
        /// <param name="_sid">SizeID</param>
        public void BindOrdersGoods(int _ogid)
        {
            BLL.Orders_Goods bog = new weipin.BLL.Orders_Goods();
            Model.Orders_Goods mo = bog.SelectOrders_GoodsByID(_ogid);
            if (mo.OrderID != 0)
            {
                lblOrderID.InnerText = mo.OrderID.ToString();
                hidOrderID.Value = mo.OrderID.ToString();
                hidOrdersGoodsID.Value = mo.OrdersGoodsID.ToString();
                lblGoodsName.InnerText = mo.GoodsName;
                hidGoodsID.Value = mo.GoodsID.ToString();
                lblLoginID.InnerText = mo.LoginID;
                hidLoginID.Value = mo.LoginID;
                hidCourierID.Value = mo.CourierID.ToString();
                hidTransactionPrice.Value = mo.TransactionPrice.ToString();
                txtOrderTime.Value = DateTime.Today.ToShortDateString();
            }
        }
        /// <summary>
        /// 提交订单备注表单
        /// </summary>
        private void InsertOrdersRemarksEdit()
        {
            Model.OrdersRemarks mor = new weipin.Model.OrdersRemarks();
            BLL.OrdersRemarks bor = new weipin.BLL.OrdersRemarks();
            mor.OrderID = Convert.ToInt32(Request.Form["hidOrderID"].ToString());
            mor.OrdersGoodsID = Convert.ToInt32(Request.Form["hidOrdersGoodsID"].ToString());
            mor.GoodsID = Convert.ToInt32(Request.Form["hidGoodsID"].ToString());
            mor.CourierID = Convert.ToInt32(Request.Form["selCourierID"].ToString());
            mor.LoginID = Request.Form["hidLoginID"].ToString();
            mor.LogisticsTimes = Convert.ToInt16(Request.Form["txtLogisticsTimes"].ToString());
            mor.CompleteCount = Convert.ToInt16(Request.Form["txtCompleteCount"].ToString());
            mor.CompleteAmount = Convert.ToDouble(Request.Form["txtCompleteAmount"].ToString());
            mor.Inventory = Convert.ToInt16(Request.Form["txtInventory"].ToString());
            mor.SalesVolume = Convert.ToInt16(Request.Form["txtSalesVolume"].ToString());
            mor.DeliveryTimes = Convert.ToInt16(Request.Form["txtDeliveryTimes"].ToString());
            mor.OrderTime = Convert.ToDateTime(Request.Form["txtOrderTime"].ToString());
            mor.Remarks = Request.Form["txtRemarks"].ToString().Replace("\r\n", "<br/>");
            if (bor.InsertOrdersRemarksEdit(mor))
            {
                Response.Write("<script>alert('添加成功！');location.href='OrdersRemarksList.aspx?st=" + mor.OrderTime.ToShortDateString() + "&et=" + mor.OrderTime.ToShortDateString() + "';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！');location=location;</script>");
            }
        }
    }
}