using System;
using System.Web.Security;

namespace weipin
{
    public partial class LoginPopOrderCheck : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtLoginID"] != null)
            {
                string _logid = Request.Form["txtLoginID"].ToString();
                string _logpsw = FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["txtPassword"].ToString(), "MD5");
                BLL.Users bu = new weipin.BLL.Users();
                bool _rmb = false;
                if (Request.Form["ckbRemember"] == "on")
                {
                    _rmb = true;
                }
                string _res = bu.CheckUser(_logid, _logpsw, _rmb);
                if (_res == "1")
                {
                    Response.Write("<script>parent.location.href='OrderCheck.aspx';</script>");
                }
                else if (_res == "2")
                {
                    txtLoginID.Value = _logid;
                    lblLoginPassword.InnerText = "您输入的密码有误，请重新输入";
                }
                else
                {
                    txtLoginID.Value = _logid;
                    lblLoginID.InnerText = "您输入的用户名不存在";
                }
            }
        }
    }
}