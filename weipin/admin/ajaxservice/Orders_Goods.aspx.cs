using System;

namespace weipin.admin.ajaxservice
{
    public partial class Orders_Goods : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    string value = string.Empty;
            //    string strParam = Request.Form["ptype"];
            //    if (strParam != null)
            //    {
            //        switch (strParam)
            //        {
            //            case "UpdateOrdersOutLibraryByOrderID":
            //                value = UpdateOrdersOutLibraryByOrderID();
            //                break;
            //        }
            //    }
            //    Response.Write(value);
            //    Response.End();
            //}
        }
        /// <summary>
        /// 修改订单及商品交易状态
        /// </summary>
        /// <returns></returns>
        //private string UpdateOrdersOutLibraryByOrderID()
        //{
        //    Model.Orders mo = new weipin.Model.Orders();
        //    mo.OrderID = Convert.ToInt32(Request.Form["oid"].ToString());
        //    mo.CourierID = Convert.ToInt32(Request.Form["cid"].ToString());
        //    string _sql = Request.Form["sql"].ToString();
        //    BLL.Orders bo = new weipin.BLL.Orders();
        //    return bo.UpdateOrdersOutLibraryByOrderID(mo, _sql).ToString();
        //}
    }
}