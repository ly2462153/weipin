using System;

namespace weipin.ajaxservice
{
    public partial class Users : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string value = string.Empty;
                string strParam = Request.Form["ptype"];
                if (strParam != null)
                {
                    switch (strParam)
                    {
                        case "CheckIsLogin": value = CheckIsLogin(); break;
                        case "CheckLoginID": value = CheckLoginID(); break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 检查是否已登录
        /// </summary>
        /// <returns></returns>
        private string CheckIsLogin()
        {
            string res = string.Empty;
            if (GetSessionOfLoginUser() != null) { return "1"; } else { return "0"; }
        }
        /// <summary>
        /// 验证邮箱是否已存在
        /// </summary>
        /// <returns></returns>
        private string CheckLoginID()
        {
            string res = string.Empty;
            string _regloginid = Request.Form["txtRegLoginID"].ToString();
            BLL.Users bu = new weipin.BLL.Users();
            if (bu.SelectUsersByLoginID(_regloginid)) { return "false"; } else { return "true"; }
        }
    }
}