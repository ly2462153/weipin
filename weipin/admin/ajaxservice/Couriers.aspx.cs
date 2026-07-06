using System;

namespace weipin.admin.ajaxservice
{
    public partial class Couriers : Common.BasePageAdmin
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
                        case "LogoutCouriersByCourierID":
                            value = LogoutCouriersByCourierID();
                            break;
                        case "DeleteCouriersByCourierID":
                            value = DeleteCouriersByCourierID();
                            break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 注销快递员
        /// </summary>
        /// <returns></returns>
        private string LogoutCouriersByCourierID()
        {
            string _res = string.Empty;
            int _cid = Convert.ToInt16(Request.Form["cid"].ToString());
            BLL.Couriers bc = new weipin.BLL.Couriers();
            if (bc.LogoutCouriersByID(_cid))
            {
                bc.CreateCouriersXML();
                _res = "1";
            }
            else
            {
                _res = "0";
            }
            return _res;
        }
        /// <summary>
        /// 删除快递员
        /// </summary>
        /// <returns></returns>
        private string DeleteCouriersByCourierID()
        {
            string _res = string.Empty;
            int _cid = Convert.ToInt16(Request.Form["cid"].ToString());
            BLL.Couriers bc = new weipin.BLL.Couriers();
            if (bc.DeleteCouriersByID(_cid))
            {
                bc.CreateCouriersXML();
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