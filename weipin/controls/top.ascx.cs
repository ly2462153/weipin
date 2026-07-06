using System;
using weipin.Common;
using System.Web;
namespace weipin.controls
{
    public partial class top : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            if (BasePage.GetSessionOfLoginUser() == null)
            {
                if (BasePage.GetCookieOfLoginUser() != null)
                {
                    BLL.Users bu = new BLL.Users();
                    if (bu.CheckUser(BasePage.GetCookieOfLoginUser().Values["loginid"].ToString(), BasePage.GetCookieOfLoginUser().Values["loginpsw"].ToString(), false) == "1") { ulLoginMessage.InnerHtml = "<li>您好,<a href=\"/myhome/UserInfo.aspx\" style=\"color:#ff6600;display:inline;clear:both;\">" + (BasePage.GetSessionOfLoginUser().NickName != "" ? BasePage.GetSessionOfLoginUser().NickName : BasePage.GetSessionOfLoginUser().LoginID) + "</a><a href=\"/Logout.aspx?logout=1\">[退出]</a></li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
                    else { ulLoginMessage.InnerHtml = "<li>您好，欢迎光临微品网上商城！</li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li><a href=\"Login.aspx?returnurl=" + Request.Url.ToString() + "\">[登录]</a><a href=\"Register.aspx?returnurl=" + Request.Url.ToString() + "\">[注册]</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
                }
                else { ulLoginMessage.InnerHtml = "<li>您好，欢迎光临微品网上商城！</li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li><a href=\"Login.aspx?returnurl=" + Request.Url.ToString() + "\">[登录]</a><a href=\"Register.aspx?returnurl=" + Request.Url.ToString() + "\">[注册]</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
            }
            else { ulLoginMessage.InnerHtml = "<li>您好,<a href=\"/myhome/UserInfo.aspx\" style=\"color:#ff6600;display:inline;clear:both;\">" + (BasePage.GetSessionOfLoginUser().NickName != "" ? BasePage.GetSessionOfLoginUser().NickName : BasePage.GetSessionOfLoginUser().LoginID) + "</a><a href=\"/Logout.aspx?logout=1\">[退出]</a></li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
            base.OnInit(e);
        }
    }
}