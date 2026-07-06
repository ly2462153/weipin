using System;
using System.Web.Security;

namespace weipin.myhome
{
    public partial class UpdatePassword : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UpdatePasswordVerifyCode"] != null && !string.IsNullOrEmpty(Request.Form["txtVerifyCode"]) && !string.IsNullOrEmpty(Request.Form["txtOldPassword"]) && !string.IsNullOrEmpty(Request.Form["txtNewPassword"]))
            {
                string _oldpassword = Request.Form["txtOldPassword"].ToString();
                string _newpassword = Request.Form["txtNewPassword"].ToString();
                #region 验证
                if (Session["UpdatePasswordVerifyCode"].ToString().ToLower() != Request.Form["txtVerifyCode"].ToLower()) { Response.Write("<script>alert('验证码输入错误,请重新输入!');</script>"); return; }
                if (_oldpassword.Length < 6 || _oldpassword.Length > 20) { Response.Write("<script>alert('旧密码长度请在6-20位之间!');</script>"); return; }
                if (_newpassword.Length < 6 || _newpassword.Length > 20) { Response.Write("<script>alert('新密码长度请在6-20位之间!');</script>"); return; }
                #endregion
                _oldpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(_oldpassword, "MD5");
                _newpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(_newpassword, "MD5");
                BLL.Users bu = new weipin.BLL.Users();
                int _res = bu.UpdateUsersPassword(GetSessionOfLoginUser().LoginID, _oldpassword, _newpassword);
                if (_res == 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:密码修改成功<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"2000\",\"0\",\"\");</script>");
                    txtOldPassword.Value = "";
                    txtNewPassword.Value = "";
                    txtConfirmNewPassword.Value = "";
                }
                else if (_res == 2)
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:旧密码输入错误<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"0\",\"\");</script>");
                    txtOldPassword.Value = "";
                    txtNewPassword.Value = "";
                    txtConfirmNewPassword.Value = "";
                }
                else { ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:系统错误,添加失败<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"0\",\"\");</script>"); }
            }
        }
    }
}