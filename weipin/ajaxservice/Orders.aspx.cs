using System;

namespace weipin.ajaxservice
{
    public partial class Orders : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string value = string.Empty;
            string strParam = Request.Form["ptype"];
            if (strParam != null)
            {
                switch (strParam)
                {
                    case "UpdateOrdersIsCancelByID":
                        value = UpdateOrdersIsCancelByID();
                        break;
                }
            }
            Response.Write(value);
            Response.End();
        }
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <returns></returns>
        private string UpdateOrdersIsCancelByID()
        {
            int _oid = Convert.ToInt32(Request.Form["oid"].ToString());
            string _loginid = GetSessionOfLoginUser().LoginID;
            BLL.Orders bos = new weipin.BLL.Orders();
            return bos.UpdateOrdersIsCancelByID(_oid, _loginid).ToString();
        }
    }
}