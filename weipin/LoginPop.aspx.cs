using System;
using System.Web.Security;

namespace weipin
{
    public partial class LoginPop : Common.BasePage
    {
        public string _thisurl = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtLoginID"] != null && Common.Commonality.JudgeNumber(Request.QueryString["gid"], 10))
            {
                string _logid = Request.Form["txtLoginID"].ToString();
                string _logpsw = FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["txtPassword"].ToString(), "MD5");
                BLL.Users bu = new weipin.BLL.Users();
                bool _rmb = false;
                if (Request.Form["ckbRemember"] == "on") { _rmb = true; }
                string _res = bu.CheckUser(_logid, _logpsw, _rmb);
                if (_res == "1")
                {
                    Response.Write("<script>parent.document.getElementById('ulLoginMessage').innerHTML=\"<li>您好,<a href='#' style='color:#ff6600;display:inline;clear:both;'>" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a><a href='/Logout.aspx?logout=1'>[退出]</a></li><li class='noline'><a href='#' onclick='CollectFavorite();return false;'>收藏网站</a></li>\";</script>");
                    Response.Write("<script>parent.document.getElementById('windownbg').style.display='none';parent.document.getElementById('windown-box').style.display='none';</script>");
                    BLL.GoodsCollect bgc = new weipin.BLL.GoodsCollect();
                    int _collectres = bgc.InsertGoodsCollect(_logid, Convert.ToInt32(Request.QueryString["gid"].ToString()));
                    if (_collectres == 1) { Response.Write("<script>parent.document.getElementById('pCollectGoodsMessage').innerHTML='收藏成功！';parent.document.getElementById('divCollectGoodsAlert').style.display='block';</script>"); }
                    else if (_collectres == 2) { Response.Write("<script>parent.document.getElementById('pCollectGoodsMessage').innerHTML='您已经收藏过该商品！';parent.document.getElementById('divCollectGoodsAlert').style.display='block';</script>"); }
                    else { Response.Write("<script>parent.document.getElementById('pCollectGoodsMessage').innerHTML='系统出错，收藏失败！';parent.document.getElementById('divCollectGoodsAlert').style.display='block';</script>"); }
                }
                else if (_res == "2") { txtLoginID.Value = _logid; lblLoginPassword.InnerText = "您输入的密码有误，请重新输入"; }
                else { txtLoginID.Value = _logid; lblLoginID.InnerText = "您输入的用户名不存在"; }
            }
            else { _thisurl = Request.UrlReferrer.ToString(); }
        }
    }
}