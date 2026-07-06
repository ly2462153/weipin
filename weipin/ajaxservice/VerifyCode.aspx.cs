using System;

namespace weipin.ajaxservice
{
    public partial class VerifyCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string value = string.Empty;
            string strParam = Request.Form["ptype"];
            if (strParam != null)
            {
                switch (strParam)
                {
                    case "GetRegisterVerifyCode": value = GetRegisterVerifyCode(); break;
                    case "GetForgetPasswordVerifyCode": value = GetForgetPasswordVerifyCode(); break;
                    case "GetUpdatePasswordVerifyCode": value = GetUpdatePasswordVerifyCode(); break;
                    case "GetForgetUpdatePasswordVerifyCode": value = GetForgetUpdatePasswordVerifyCode(); break;
                    case "GetEmailVerifyCode": value = GetEmailVerifyCode(); break;
                }
            }
            Response.Write(value);
            Response.End();
        }
        /// <summary>
        /// 获取注册验证码
        /// </summary>
        /// <returns></returns>
        private string GetRegisterVerifyCode()
        {
            string _res = string.Empty;
            if (Session["RegisterVerifyCode"] != null) { _res = Session["RegisterVerifyCode"].ToString(); }
            return _res;
        }
        /// <summary>
        /// 获取忘记密码验证码
        /// </summary>
        /// <returns></returns>
        private string GetForgetPasswordVerifyCode()
        {
            string _res = string.Empty;
            if (Session["ForgetPasswordVerifyCode"] != null) { _res = Session["ForgetPasswordVerifyCode"].ToString(); }
            return _res;
        }
        /// <summary>
        /// 获取修改密码验证码
        /// </summary>
        /// <returns></returns>
        private string GetUpdatePasswordVerifyCode()
        {
            string _res = string.Empty;
            if (Session["UpdatePasswordVerifyCode"] != null) { _res = Session["UpdatePasswordVerifyCode"].ToString(); }
            return _res;
        }
        /// <summary>
        /// 获取修改密码验证码(忘记密码)
        /// </summary>
        /// <returns></returns>
        private string GetForgetUpdatePasswordVerifyCode()
        {
            string _res = string.Empty;
            if (Session["ForgetpasswrodUpdateVerifyCode"] != null) { _res = Session["ForgetpasswrodUpdateVerifyCode"].ToString(); }
            return _res;
        }
        /// <summary>
        /// 获取验证邮箱的验证码
        /// </summary>
        /// <returns></returns>
        private string GetEmailVerifyCode()
        {
            string _res = string.Empty;
            if (Session["EmailVerifyCode"] != null) { _res = Session["EmailVerifyCode"].ToString(); }
            return _res;
        }
    }
}