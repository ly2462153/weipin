using System;
using System.Web.Security;

namespace weipin.ajaxservice
{
    public partial class Login : Common.BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            string value = string.Empty;
            string _param = Request.Form["ptype"];
            if (_param != null)
            {
                switch (_param)
                {
                    case "CheckUser": value = CheckUser(); break;
                    case "OtherLogin": value = OtherLogin(); break;
                    case "OtherLoginCollect": value = OtherLoginCollect(); break;
                }
            }
            Response.Write(value);
            Response.End();
            base.OnInit(e);
        }
        /// <summary>
        /// 检查用户登录
        /// </summary>
        /// <returns></returns>
        private string CheckUser()
        {
            string _str = string.Empty;
            if (GetSessionOfLoginUser() == null)
            {
                if (GetCookieOfLoginUser() != null)
                {
                    BLL.Users bu = new BLL.Users();
                    if (bu.CheckUser(GetCookieOfLoginUser().Values["loginid"].ToString(), GetCookieOfLoginUser().Values["loginpsw"].ToString(), false) == "1") { _str = "<li>您好,<a href=\"/myhome/UserInfo.aspx\" style=\"color:#ff6600;display:inline;clear:both;\">" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a><a href=\"/Logout.aspx?logout=1\">[退出]</a></li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
                    else { _str = "<li>您好，欢迎光临微品网上商城！</li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li><a href=\"/Login.aspx?returnurl=" + Request.UrlReferrer.ToString() + "\">[登录]</a><a href=\"/Register.aspx?returnurl=" + Request.UrlReferrer.ToString() + "\">[注册]</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
                }
                else { _str = "<li>您好，欢迎光临微品网上商城！</li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li><a href=\"/Login.aspx?returnurl=" + Request.UrlReferrer.ToString() + "\">[登录]</a><a href=\"/Register.aspx?returnurl=" + Request.UrlReferrer.ToString() + "\">[注册]</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
            }
            else { _str = "<li>您好,<a href=\"/myhome/UserInfo.aspx\" style=\"color:#ff6600;display:inline;clear:both;\">" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a><a href=\"/Logout.aspx?logout=1\">[退出]</a></li><li><a href=\"#\" onclick=\"CollectFavorite();return false;\">收藏网站</a></li><li class=\"noline\"><a href=\"http://e.weibo.com/weipin365\" target=\"_blank\" style=\"background:url(/img/sinaweibo.gif) no-repeat left center;padding-left:20px;display:block;\">关注我们</a></li>"; }
            return _str;
        }
        /// <summary>
        /// 其它方式登录(QQ登录/新浪微博登录)
        /// </summary>
        /// <returns></returns>
        private string OtherLogin()
        {
            string _res = string.Empty;
            string _otherloginid = Request.Form["otherloginid"].ToString();
            string _nickname = Request.Form["nickname"].ToString();
            string _loginway = Request.Form["loginway"].ToString();
            Model.Users mu = new weipin.Model.Users();
            if (_loginway == "sina" && _otherloginid.Length <= 28) { mu.LoginID = Guid.NewGuid().ToString().Replace("-", "").ToUpper(); mu.OtherLoginID = "sina_" + _otherloginid; }
            else if (_loginway == "qq" && _otherloginid.Length == 32) { mu.LoginID = _otherloginid; mu.OtherLoginID = _otherloginid; }
            else { return "0"; }
            mu.LoginPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20).ToUpper(), "MD5");
            mu.Email = "default@weipin365.com";//default邮箱为虚构邮箱(用户界面判定若是此邮箱则可直接修改邮箱)
            mu.NickName = _nickname;
            mu.IsVerify = true;
            BLL.Users bu = new weipin.BLL.Users();
            Model.Users mureturn = bu.InsertUsersByOtherLoginID(mu);
            if (mureturn != null && mureturn.LoginID != null)
            {
                mureturn.VIPGrade = 1;
                SetSessionOfLoginUser(mureturn);
                _res = "1";
            }
            else { _res = "0"; }
            return _res;
        }
        /// <summary>
        /// 其它方式登录并收藏商品
        /// </summary>
        /// <returns></returns>
        private string OtherLoginCollect()
        {
            string _res = string.Empty;
            string _otherloginid = Request.Form["otherloginid"].ToString();
            string _nickname = Request.Form["nickname"].ToString();
            string _loginway = Request.Form["loginway"].ToString();
            int _gid = Convert.ToInt32(Request.Form["gid"].ToString());
            Model.Users mu = new weipin.Model.Users();
            if (_loginway == "sina" && _otherloginid.Length <= 28) { mu.LoginID = Guid.NewGuid().ToString().Replace("-", "").ToUpper(); mu.OtherLoginID = "sina_" + _otherloginid; }
            else if (_loginway == "qq" && _otherloginid.Length == 32) { mu.LoginID = _otherloginid; mu.OtherLoginID = _otherloginid; }
            else { return "0"; }
            mu.LoginPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20).ToUpper(), "MD5");
            mu.Email = "default@weipin365.com";//default邮箱为虚构邮箱(用户界面判定若是此邮箱则可直接修改邮箱)
            mu.NickName = _nickname;
            mu.IsVerify = true;
            BLL.Users bu = new weipin.BLL.Users();
            Model.Users mureturn = bu.InsertUsersByOtherLoginID(mu);
            if (mureturn != null && mureturn.LoginID != null)
            {
                mureturn.VIPGrade = 1;
                SetSessionOfLoginUser(mureturn);
                BLL.GoodsCollect bgc = new weipin.BLL.GoodsCollect();
                int _collectres = bgc.InsertGoodsCollect(mureturn.LoginID, _gid);
                string _js = "parent.document.getElementById('ulLoginMessage').innerHTML=\"<li>您好,<a href='#' style='color:#ff6600;display:inline;clear:both;'>" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a><a href='/Logout.aspx?logout=1'>[退出]</a></li><li class='noline'><a href='#' onclick='CollectFavorite();return false;'>收藏网站</a></li>\";parent.document.getElementById('windownbg').style.display='none';parent.document.getElementById('windown-box').style.display='none';";
                if (_collectres == 1) { _res = "1" + _js; } else if (_collectres == 2) { _res = "2" + _js; } else { _res = "3" + _js; }
            }
            else { _res = "0"; }
            return _res;
        }
    }
}