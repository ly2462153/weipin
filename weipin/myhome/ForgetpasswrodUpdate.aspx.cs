using System;
using System.Web.Security;

namespace weipin.myhome
{
    public partial class ForgetpasswrodUpdate : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["hidOldPassword"]) && !string.IsNullOrEmpty(Request.QueryString["loginid"])) { UpdatePassword(); }
            else if (!string.IsNullOrEmpty(Request.QueryString["loginid"]) && !string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                CheckUpdatePasswordInfo(Request.QueryString["loginid"].ToString(), Request.QueryString["code"].ToString());
            }
            else { divForm.InnerText = "抱歉，登录名和验证码不匹配"; }
        }
        /// <summary>
        /// 检查验证邮箱的登录名与验证码是否匹配
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="code">验证码</param>
        private void CheckUpdatePasswordInfo(string loginid, string code)
        {
            BLL.Users bu = new weipin.BLL.Users();
            Model.Users mu = bu.CheckUpdateUsersPasswordInfo(loginid, code);
            if (mu != null && mu.LoginPassword != null) { hidOldPassword.Value = mu.LoginPassword; }
            else { divForm.InnerText = "抱歉，登录名和验证码不匹配"; }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        private void UpdatePassword()
        {
            string _oldpassword = Request.Form["hidOldPassword"].ToString();
            string _newpassword = Request.Form["txtNewPassword"].ToString();
            #region 验证
            if (Session["ForgetpasswrodUpdateVerifyCode"].ToString().ToLower() != Request.Form["txtVerifyCode"].ToLower()) { Response.Write("<script>alert('验证码输入错误,请重新输入!');</script>"); return; }
            if (_newpassword.Length < 6 || _newpassword.Length > 20) { Response.Write("<script>alert('新密码长度请在6-20位之间!');</script>"); return; }
            #endregion
            _newpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(_newpassword, "MD5");
            BLL.Users bu = new weipin.BLL.Users();
            int _res = bu.UpdateUsersForgetPassword(Request.QueryString["loginid"].ToString(), _oldpassword, _newpassword);
            if (_res == 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:密码修改成功<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"2000\",\"0\",\"\");setTimeout(Redir,2000);</script>");
                txtNewPassword.Value = "";
                txtConfirmNewPassword.Value = "";
            }
            else if (_res == 2)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:旧密码输入错误<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"0\",\"\");</script>");
                txtNewPassword.Value = "";
                txtConfirmNewPassword.Value = "";
            }
            else { ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:系统错误,添加失败<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"0\",\"\");</script>"); }
        }
    }
}