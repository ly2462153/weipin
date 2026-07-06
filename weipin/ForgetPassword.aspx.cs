using System;
using System.Text.RegularExpressions;
using System.Text;

namespace weipin
{
    public partial class ForgetPassword : Common.BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            if (GetSessionOfLoginUser() == null)
            {
                if (GetCookieOfLoginUser() != null)
                {
                    BLL.Users bu = new BLL.Users();
                    if (bu.CheckUser(GetCookieOfLoginUser().Values["loginid"].ToString(), GetCookieOfLoginUser().Values["loginpsw"].ToString(), false) == "1")
                    {
                        ulLoginMessage.InnerHtml = "<li>您好,<a href=\"/myhome/UserInfo.aspx\" style=\"color:#ff6600;display:inline;clear:both;\">" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a><a href=\"/Logout.aspx?logout=1\">[退出]</a></li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>";
                    }
                    else { ulLoginMessage.InnerHtml = "<li>您好，欢迎光临微品网上商城！</li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li><a href=\"Login.aspx\">[登录]</a><a href=\"Register.aspx\">[注册]</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
                }
                else { ulLoginMessage.InnerHtml = "<li>您好，欢迎光临微品网上商城！</li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li><a href=\"Login.aspx\">[登录]</a><a href=\"Register.aspx\">[注册]</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
            }
            else { ulLoginMessage.InnerHtml = "<li>您好,<a href=\"/myhome/UserInfo.aspx\" style=\"color:#ff6600;display:inline;clear:both;\">" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a><a href=\"/Logout.aspx?logout=1\">[退出]</a></li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ForgetPasswordVerifyCode"] != null && !string.IsNullOrEmpty(Request.Form["txtVerifyCode"]) && !string.IsNullOrEmpty(Request.Form["txtLoginID"]) && !string.IsNullOrEmpty(Request.Form["txtEmail"]))
            {
                string _loginid = Request.Form["txtLoginID"].ToString();
                string _email = Request.Form["txtEmail"].ToString();
                string _verifycode = Guid.NewGuid().ToString().Replace("-", "");
                #region 验证
                if (Session["ForgetPasswordVerifyCode"].ToString().ToLower() != Request.Form["txtVerifyCode"].ToLower()) { Response.Write("<script>alert('验证码输入错误,请重新输入!');</script>"); return; }
                if (_loginid.Length < 4 || _loginid.Length > 20 || !Regex.IsMatch(_loginid, @"^[a-zA-Z_0-9]+$")) { Response.Write("<script>alert('4-20位字符,可由英文、数字及“_”组成!');</script>"); return; }
                if (_email.Length > 50 || !Regex.IsMatch(_email, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$")) { Response.Write("<script>alert('邮箱格式不正确或超出了50个字符!');</script>"); return; }
                #endregion
                BLL.Users bu = new weipin.BLL.Users();
                int _res = bu.UpdateUsersVerifyCodeByLoginIDAndEmail(_loginid, _email, _verifycode);
                if (_res == 1)
                {
                    StringBuilder sbMail = new StringBuilder();
                    sbMail.Append(System.IO.File.ReadAllText(Server.MapPath("mailtemplate/updatepasswordverify.html")).Replace("{weipin:loginid}", _loginid).Replace("{weipin:activatelink}", "<a href=\"http://www.weipin365.com/myhome/ForgetpasswrodUpdate.aspx?loginid=" + _loginid + "&code=" + _verifycode + "\" style=\"color:#005aa0;font-weight:bold;\">请点击这里修改密码</a>").Replace("{weipin:activatelinkall}", "<a style=\"color:#005aa0\" href=\"http://www.weipin365.com/myhome/ForgetpasswrodUpdate.aspx?loginid=" + _loginid + "&code=" + _verifycode + "\">http://www.weipin365.com/myhome/ForgetpasswrodUpdate.aspx?loginid=" + _loginid + "&code=" + _verifycode + "</a>"));
                    Common.SendMail.SendMailText("info@weipin365.com", _email, sbMail.ToString(), "微品网上商城", "微品网上商城修改密码邮件信息");
                    Response.Redirect("ForgetPasswordMessage.aspx?mail=" + _email);
                }
                else if (_res == 2) { ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:您输入的用户名和邮箱不匹配\",\"300\",\"50\",\"false\",\"\",\"0\",\"\");</script>"); }
                else if (_res == 3) { ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:您输入的用户名不存在\",\"300\",\"50\",\"false\",\"\",\"0\",\"\");</script>"); }
                else { ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:系统错误\",\"300\",\"50\",\"false\",\"\",\"0\",\"\");</script>"); }
            }
        }
    }
}