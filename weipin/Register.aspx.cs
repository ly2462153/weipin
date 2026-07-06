using System;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Text;

namespace weipin
{
    public partial class Register : Common.BasePage
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
            if (Session["RegisterVerifyCode"] != null && !string.IsNullOrEmpty(Request.Form["txtVerifyCode"]) && !string.IsNullOrEmpty(Request.Form["txtRegLoginID"]) && !string.IsNullOrEmpty(Request.Form["txtRegPassword"]) && !string.IsNullOrEmpty(Request.Form["txtEmail"]))
            {
                Model.Users mu = new weipin.Model.Users();
                mu.LoginID = Request.Form["txtRegLoginID"].ToString();
                mu.LoginPassword = Request.Form["txtRegPassword"].ToString();
                mu.Email = Request.Form["txtEmail"].ToString();
                #region 验证
                if (Session["RegisterVerifyCode"].ToString().ToLower() != Request.Form["txtVerifyCode"].ToLower()) { Response.Write("<script>alert('验证码输入错误,请重新输入!');</script>"); return; }
                if (mu.LoginID.Length < 4 || mu.LoginID.Length > 20 || !Regex.IsMatch(mu.LoginID, @"^[a-zA-Z_0-9]+$")) { Response.Write("<script>alert('4-20位字符,可由英文、数字及“_”组成!');</script>"); return; }
                if (mu.LoginPassword.Length < 6 || mu.LoginPassword.Length > 20) { Response.Write("<script>alert('密码长度请在6-20位之间!');</script>"); return; }
                if (mu.Email.Length > 50 || !Regex.IsMatch(mu.Email, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$")) { Response.Write("<script>alert('邮箱格式不正确或超出了50个字符!');</script>"); return; }
                #endregion
                mu.VerifyCode = Guid.NewGuid().ToString().Replace("-", "");
                BLL.Users bu = new weipin.BLL.Users();
                mu.LoginPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(mu.LoginPassword, "MD5");
                int _res = bu.InsertUsers(mu);
                if (_res == 1)
                {
                    mu.Email = null;
                    string _verifycode = mu.VerifyCode;
                    mu.VerifyCode = null;
                    mu.VIPGrade = 1;
                    SetSessionOfLoginUser(mu);
                    StringBuilder sbMail = new StringBuilder();
                    sbMail.Append(System.IO.File.ReadAllText(Server.MapPath("mailtemplate/registerverify.html")).Replace("{weipin:loginid}", mu.LoginID).Replace("{weipin:activatelink}", "<a href=\"http://www.weipin365.com/UserVerify.aspx?loginid=" + mu.LoginID + "&code=" + _verifycode + "\" style=\"color:#005aa0;font-weight:bold;\">点击激活微品网账户</a>").Replace("{weipin:activatelinkall}", "<a style=\"color:#005aa0\" href=\"http://www.weipin365.com/UserVerify.aspx?loginid=" + mu.LoginID + "&code=" + _verifycode + "\">http://www.weipin365.com/UserVerify.aspx?loginid=" + mu.LoginID + "&code=" + _verifycode + "</a>"));
                    Common.SendMail.SendMailText("info@weipin365.com", Request.Form["txtEmail"].ToString(), sbMail.ToString(), "微品网上商城", "微品网上商城邮箱激活邮件信息");
                    if (Request.QueryString["returnurl"] != null) { Response.Redirect(Request.QueryString["returnurl"].ToString()); }
                    else { Response.Redirect("http://www.weipin365.com"); }
                }
                else if (_res == 2) { Response.Write("<script>alert('此用户名已存在,请重新输入!');</script>"); }
                else { Response.Write("<script>alert('系统错误,添加失败!');</script>"); }
            }
        }
    }
}