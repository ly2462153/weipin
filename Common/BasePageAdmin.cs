using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;

using weipin.Model;

namespace weipin.Common
{
    public class BasePageAdmin : System.Web.UI.Page
    {
        public BasePageAdmin()
        { }

        protected override void OnLoad(EventArgs e)
        {
            if (Session["LoginAdmin"] == null)
            {
                Response.Redirect("~/admin/Login.aspx");
            }
            base.OnLoad(e);
        }
        /// <summary>
        /// 将个人信息存入Session
        /// </summary>
        /// <param name="ecp"></param>
        public static void SetSessionOfLoginAdmin(Model.Admins ea)
        {
            HttpContext.Current.Session["LoginAdmin"] = ea;
            HttpContext.Current.Session.Timeout = Convert.ToInt16(ConfigurationSettings.AppSettings["SessionTimeout"].ToString());
        }
        /// <summary>
        /// 取出个人信息Session
        /// </summary>
        public static Model.Admins GetSessionOfLoginAdmin()
        {
            Model.Admins ecp = null;
            if (HttpContext.Current.Session["LoginAdmin"] != null)
            {
                ecp = HttpContext.Current.Session["LoginAdmin"] as Model.Admins;
            }
            return ecp;
        }
        /// <summary>
        /// 清除个人信息Session
        /// </summary>
        public static void ClearSessionOfLoginAdmin()
        {
            HttpContext.Current.Session.Remove("LoginAdmin");
        }
        /// <summary>
        /// 将个人信息存入Cookie
        /// </summary>
        /// <param name="ecp"></param>
        public static void SetCookieOfLoginAdmin(Model.Admins ea)
        {
            HttpCookie ckLoinAdmin = new HttpCookie("LoginAdmin");
            ckLoinAdmin.Values.Add("username", ea.AdminID);
            ckLoinAdmin.Values.Add("userpsw", ea.AdminPSW);
            ckLoinAdmin.Expires = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationSettings.AppSettings["CookieTimeout"].ToString()));
            HttpContext.Current.Response.AppendCookie(ckLoinAdmin);
        }
        /// <summary>
        /// 获取个人信息Cookie
        /// </summary>
        /// <returns></returns>
        public static HttpCookie GetCookieOfLoginAdmin()
        {
            HttpCookie hck = null;
            HttpRequest req = HttpContext.Current.Request;
            if (req.Cookies["LoginAdmin"] != null)
            {
                hck = req.Cookies["LoginAdmin"];
            }
            return hck;
        }
        /// <summary>
        /// 清除个人信息Cookie
        /// </summary>
        public static void ClearCookieOfLoginAdmin()
        {
            HttpCookie ckU = HttpContext.Current.Response.Cookies["LoginAdmin"];
            ckU.Expires = DateTime.Now.AddDays(-100);
            HttpContext.Current.Response.Cookies.Add(ckU);
        }
    }
}