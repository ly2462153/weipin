using System;
using System.Web.Security;

namespace weipin.admin
{
    public partial class OrdersRemarksAdd : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtGoodsID"] != null)
            {
                InsertOrdersRemarks();
            }
        }
        /// <summary>
        /// 提交订单备注表单
        /// </summary>
        private void InsertOrdersRemarks()
        {
            Model.OrdersRemarks mor = new weipin.Model.OrdersRemarks();
            BLL.OrdersRemarks bor = new weipin.BLL.OrdersRemarks();
            mor.GoodsID = Convert.ToInt32(Request.Form["txtGoodsID"].ToString());
            mor.CourierID = Convert.ToInt32(Request.Form["selCourierID"].ToString());
            mor.LoginID = Request.Form["txtLoginID"].ToString();
            if (Request.Form["txtLogisticsTimes"].ToString() != "")
            {
                mor.LogisticsTimes = Convert.ToInt16(Request.Form["txtLogisticsTimes"].ToString());
            }
            mor.CompleteCount = Convert.ToInt16(Request.Form["txtCompleteCount"].ToString());
            mor.CompleteAmount = Convert.ToDouble(Request.Form["txtCompleteAmount"].ToString());
            mor.Inventory = Convert.ToInt16(Request.Form["txtInventory"].ToString());
            mor.SalesVolume = Convert.ToInt16(Request.Form["txtSalesVolume"].ToString());
            mor.DeliveryTimes = Convert.ToInt16(Request.Form["txtDeliveryTimes"].ToString());
            mor.OrderTime = Convert.ToDateTime(Request.Form["txtOrderTime"].ToString());
            mor.Remarks = Request.Form["txtRemarks"].ToString().Replace("\r\n", "<br/>");
            if (bor.InsertOrdersRemarks(mor))
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