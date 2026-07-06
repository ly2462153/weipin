using System;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace weipin.myhome
{
    public partial class VerifyUpdateEmail : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmailVerifyCode"] != null && !string.IsNullOrEmpty(Request.Form["txtVerifyCode"]) && Request.Form["txtOldEmail"] != null && Request.Form["txtNewEmail"] != null)
            {
                UpdateNewEmailVerifyCode(Request.Form["txtOldEmail"].ToString(), Request.Form["txtNewEmail"]);
            }
            else { BindMyEmail(); }
        }
        /// <summary>
        /// 绑定我的邮箱
        /// </summary>
        private void BindMyEmail()
        {
            BLL.Users bu = new weipin.BLL.Users();
            Model.Users mu = bu.SelectUsersMyEmail(GetSessionOfLoginUser().LoginID);
            if (mu != null && mu.Email != "") { lblOldEmail.InnerText = StructEmail(mu.Email); }
        }
        /// <summary>
        /// 更新新邮箱和验证码
        /// </summary>
        /// <param name="oldemail">验证过的邮箱</param>
        /// <param name="newemail">需要验证的新邮箱</param>
        private void UpdateNewEmailVerifyCode(string oldemail, string newemail)
        {
            Model.Users mu = new weipin.Model.Users();
            mu.LoginID = GetSessionOfLoginUser().LoginID;
            mu.VerifyCode = Guid.NewGuid().ToString().Replace("-", "");
            mu.Email = oldemail;
            mu.EmailNew = newemail;
            #region 验证
            if (Session["EmailVerifyCode"].ToString().ToLower() != Request.Form["txtVerifyCode"].ToLower()) { Response.Write("<script>alert('验证码输入错误,请重新输入!');</script>"); return; }
            if (mu.Email.Length > 50 || !Regex.IsMatch(mu.Email, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$")) { Response.Write("<script>alert('邮箱格式不正确或超出了50个字符!');</script>"); return; }
            if (mu.EmailNew.Length > 50 || !Regex.IsMatch(mu.EmailNew, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$")) { Response.Write("<script>alert('邮箱格式不正确或超出了50个字符!');</script>"); return; }
            #endregion
            BLL.Users bu = new weipin.BLL.Users();
            int _res = bu.UpdateUsersEmailVerifyCodeByLoginID(mu);
            if (_res == 1)
            {
                System.Text.StringBuilder sbMail = new System.Text.StringBuilder();
                sbMail.Append(System.IO.File.ReadAllText(Server.MapPath("~/mailtemplate/registerverify.html")).Replace("{weipin:loginid}", mu.LoginID).Replace("{weipin:activatelink}", "<a href=\"http://www.weipin365.com/UserVerify.aspx?loginid=" + mu.LoginID + "&code=" + mu.VerifyCode + "\" style=\"color:#005aa0;font-weight:bold;\">点击激活微品网账户</a>").Replace("{weipin:activatelinkall}", "<a style=\"color:#005aa0\" href=\"http://www.weipin365.com/UserVerify.aspx?loginid=" + mu.LoginID + "&code=" + mu.VerifyCode + "\">http://www.weipin365.com/UserVerify.aspx?loginid=" + mu.LoginID + "&code=" + mu.VerifyCode + "</a>"));
                Common.SendMail.SendMailText("info@weipin365.com", mu.EmailNew, sbMail.ToString(), "微品网上商城", "微品网上商城邮箱激活邮件信息");
                ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:发送验证邮件成功,请立即登录邮箱进行验证<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"0\",\"\");</script>");
            }
            else if (_res == 2) { ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:验证过的邮箱输入不正确<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"0\",\"\");</script>"); }
            else { ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:发送验证邮件失败<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"0\",\"\");</script>"); }
        }
        /// <summary>
        /// 构造隐藏部分的邮箱
        /// </summary>
        /// <param name="email">邮箱</param>
        private string StructEmail(string email)
        {
            string _email = string.Empty;
            int _index = email.IndexOf("@");
            string _emailname = email.Substring(0, _index);
            string _emailprovider = email.Substring(_index);
            int _emailnamelength = _emailname.Length;
            if (_emailnamelength == 1) { _email = email; }
            else if (_emailnamelength == 2 || _emailnamelength == 3) { _email = _emailname.Substring(0, 1) + "*****" + _emailname.Substring(_emailname.Length - 1, 1) + _emailprovider; }
            else if (_emailnamelength > 3) { _email = _emailname.Substring(0, 2) + "*****" + _emailname.Substring(_emailname.Length - 2, 2) + _emailprovider; }
            return _email;
        }
    }
}