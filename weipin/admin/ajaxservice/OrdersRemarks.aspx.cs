using System;

namespace weipin.admin.ajaxservice
{
    public partial class OrdersRemarks : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string value = string.Empty;
                string strParam = Request.Form["ptype"];
                if (strParam != null)
                {
                    switch (strParam)
                    {
                        case "DeleteOrdersRemarksByOrdersRemarkID":
                            value = DeleteOrdersRemarksByOrdersRemarkID();
                            break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 删除订单备注
        /// </summary>
        /// <returns></returns>
        private string DeleteOrdersRemarksByOrdersRemarkID()
        {
            string _res = string.Empty;
            int _orid = Convert.ToInt16(Request.Form["orid"].ToString());
            BLL.OrdersRemarks bor = new weipin.BLL.OrdersRemarks();
            if (bor.DeleteOrdersRemarksByID(_orid))
            {
                _res = "1";
            }
            else
            {
                _res = "0";
            }
            return _res;
        }
    }
}