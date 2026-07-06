using System;

namespace weipin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["logout"] != null)
            {
                string _type = Request.QueryString["logout"].ToString();
                if (_type == "1")
                {
                    //用户退出
                    Common.BasePage.ClearCookieOfLoginUser();
                    Common.BasePage.ClearSessionOfLoginUser();
                    Response.Write("<script type=\"text/javascript\" src=\"http://qzonestyle.gtimg.cn/qzone/openapi/qc_loader.js\" data-appid=\"100387986\" data-redirecturi=\"http://www.weipin365.com/qc_back.html\" charset=\"utf-8\"></script><script src=\" http://tjs.sjs.sinajs.cn/open/api/js/wb.js?appkey=3830747693\" type=\"text/javascript\" charset=\"utf-8\"></script>");
                    Response.Write("<script type=\"text/javascript\">QC.Login.signOut();WB2.logout(function(){location.href=\"" + Request.UrlReferrer.ToString() + "\";});location.href=\"" + Request.UrlReferrer.ToString() + "\";</script>");
                }
                else if (_type == "2")
                {
                    //管理系统用户退出
                    Common.BasePageAdmin.ClearCookieOfLoginAdmin();
                    Common.BasePageAdmin.ClearSessionOfLoginAdmin();
                    Response.Redirect("admin/Login.aspx");
                }
                else { Response.Redirect("index.html"); }
            }
            else { Response.Redirect("index.html"); }
        }
    }
}