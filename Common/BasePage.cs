using System;
using System.Configuration;
using System.Web;

namespace weipin.Common
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        { }
        /// <summary>
        /// 将用户信息存入Session
        /// </summary>
        /// <param name="ecp"></param>
        public static void SetSessionOfLoginUser(Model.Users eu)
        {
            HttpContext.Current.Session["LoginUser"] = eu;
            HttpContext.Current.Session.Timeout = Convert.ToInt16(ConfigurationSettings.AppSettings["SessionTimeout"].ToString());
        }
        /// <summary>
        /// 取出用户信息Session
        /// </summary>
        public static Model.Users GetSessionOfLoginUser()
        {
            Model.Users ecp = null;
            if (HttpContext.Current.Session["LoginUser"] != null) { ecp = HttpContext.Current.Session["LoginUser"] as Model.Users; }
            return ecp;
        }
        /// <summary>
        /// 清除用户信息Session
        /// </summary>
        public static void ClearSessionOfLoginUser()
        {
            HttpContext.Current.Session.Remove("LoginUser");
        }
        /// <summary>
        /// 将用户信息存入Cookie
        /// </summary>
        /// <param name="ecp"></param>
        public static void SetCookieOfLoginUser(Model.Users mu)
        {
            HttpCookie ckLoinUser = new HttpCookie("LoginUser");
            ckLoinUser.Values.Add("loginid", mu.LoginID);
            ckLoinUser.Values.Add("loginpsw", mu.LoginPassword);
            ckLoinUser.Expires = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationSettings.AppSettings["CookieTimeout"].ToString()));
            HttpContext.Current.Response.AppendCookie(ckLoinUser);
        }
        /// <summary>
        /// 获取用户信息Cookie
        /// </summary>
        /// <returns></returns>
        public static HttpCookie GetCookieOfLoginUser()
        {
            HttpCookie hck = null;
            HttpRequest req = HttpContext.Current.Request;
            if (req.Cookies["LoginUser"] != null) { hck = req.Cookies["LoginUser"]; }
            return hck;
        }
        /// <summary>
        /// 清除用户信息Cookie
        /// </summary>
        public static void ClearCookieOfLoginUser()
        {
            HttpCookie ckU = HttpContext.Current.Response.Cookies["LoginUser"];
            ckU.Expires = DateTime.Now.AddDays(-100);
            HttpContext.Current.Response.Cookies.Add(ckU);
        }
    }
}