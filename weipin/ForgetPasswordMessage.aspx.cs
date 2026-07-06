using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace weipin
{
    public partial class ForgetPasswordMessage : Common.BasePage
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
            if (Request.QueryString["mail"] != null) { spEmail.InnerText = Request.QueryString["mail"].ToString(); }
        }
    }
}