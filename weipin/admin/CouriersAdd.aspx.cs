using System;
using System.Web.Security;

namespace weipin.admin
{
    public partial class CouriersAdd : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtCourierName"] != null)
            {
                InsertCouriers();
            }
        }
        /// <summary>
        /// 添加快递员
        /// </summary>
        private void InsertCouriers()
        {
            Model.Couriers mc = new weipin.Model.Couriers();
            mc.LoginPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["txtLoginPassword"].ToString(), "MD5");
            mc.CourierName = Request.Form["txtCourierName"].ToString().Replace("<", "＜").Replace("&", "＆");
            if (Request.Form["rdoSex"].ToString() == "rdoSexMale")
            {
                mc.CourierSex = true;
            }
            else
            {
                mc.CourierSex = false;
            }
            mc.AreaID = Convert.ToInt32(Request.Form["selArea"].ToString());
            mc.MobilePhone = Request.Form["txtMobilePhone"].ToString();
            BLL.Couriers bc = new weipin.BLL.Couriers();
            if (bc.InsertCouriers(mc))
            {
                bc.CreateCouriersXML();
                Response.Write("<script>alert('添加成功！');location.href='CouriersList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！');location.href='CouriersList.aspx';</script>");
            }
        }
    }
}