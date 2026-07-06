using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace weipin
{
    public partial class UserVerify : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["loginid"] != null && Request.QueryString["code"] != null)
            {
                VerifyLoginID(Request.QueryString["loginid"].ToString(), Request.QueryString["code"].ToString());
            }
        }
        /// <summary>
        /// 用户邮箱激活
        /// </summary>
        /// <param name="loginid">登录邮箱</param>
        /// <param name="code">激活码</param>
        private void VerifyLoginID(string loginid, string code)
        {
            BLL.Users bu = new weipin.BLL.Users();
            if (bu.UpdateUsersByLoginIDAndCode(loginid, code)) { divMsg.InnerHtml = "<div><ul><li style=\"float:left;\"><img src=\"/img/verifysuccess.jpg\" alt=\"您好，您的邮箱已经验证成功！\"/></li><li style=\"float:left;padding:30px 0 0 30px;\"><strong style=\"font-size:22px;line-height:28px;font-family:微软雅黑;color:#47983C;\">您好，您的邮箱已经验证成功！</strong></li></ul></div>"; }
            else { divMsg.InnerHtml = "<div><ul><li style=\"float:left;\"><img src=\"/img/verifyfail.jpg\" alt=\"您好，您的邮箱验证失败！\"/></li><li style=\"float:left;padding:30px 0 0 30px;\"><strong style=\"font-size:22px;line-height:28px;font-family:微软雅黑;color:#47983C;\">您好，您的邮箱验证失败！</strong></li></ul></div>"; }
        }
    }
}