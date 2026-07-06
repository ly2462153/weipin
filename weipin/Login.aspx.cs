using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace weipin
{
    public partial class Login : Common.BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            if (GetSessionOfLoginUser() == null)
            {
                if (GetCookieOfLoginUser() != null)
                {
                    BLL.Users bu = new BLL.Users();
                    if (bu.CheckUser(GetCookieOfLoginUser().Values["loginid"].ToString(), GetCookieOfLoginUser().Values["loginpsw"].ToString(), false) == "1") { ulLoginMessage.InnerHtml = "<li>您好,<a href=\"/myhome/UserInfo.aspx\" style=\"color:#ff6600;display:inline;clear:both;\">" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a><a href=\"/Logout.aspx?logout=1\">[退出]</a></li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
                    else { ulLoginMessage.InnerHtml = "<li>您好，欢迎光临微品网上商城！</li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li><a href=\"Login.aspx\">[登录]</a><a href=\"Register.aspx\">[注册]</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
                }
                else { ulLoginMessage.InnerHtml = "<li>您好，欢迎光临微品网上商城！</li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li><a href=\"Login.aspx\">[登录]</a><a href=\"Register.aspx\">[注册]</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
            }
            else { ulLoginMessage.InnerHtml = "<li>您好,<a href=\"/myhome/UserInfo.aspx\" style=\"color:#ff6600;display:inline;clear:both;\">" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a><a href=\"/Logout.aspx?logout=1\">[退出]</a></li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtLoginID"] != null)
            {
                string _logid = Request.Form["txtLoginID"].ToString();
                string _logpsw = FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["txtPassword"].ToString(), "MD5");
                BLL.Users bu = new weipin.BLL.Users();
                bool _rmb = false;
                if (Request.Form["ckbRemember"] == "on") { _rmb = true; }
                string _res = bu.CheckUser(_logid, _logpsw, _rmb);
                if (_res == "1")
                {
                    if (Request.QueryString["returnurl"] != null) { Response.Redirect(Request.QueryString["returnurl"].ToString()); }
                    else { Response.Redirect("http://www.weipin365.com"); }
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