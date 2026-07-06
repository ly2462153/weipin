using System;
using weipin.Common;

namespace weipin.help
{
    public partial class MySuggest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtSuggest"] != null) { SubmitSuggest(); }
        }
        /// <summary>
        /// 提交意见与建议
        /// </summary>
        private void SubmitSuggest()
        {
            string _suggest = Commonality.CutString(Request.Form["txtSuggest"].ToString().Replace("\r\n", "<br/>"), 300);
            string _name = Request.Form["txtSuggestPerson"].ToString();
            string _email = Request.Form["txtEmail"].ToString();
            string _qq = Request.Form["txtQQ"].ToString();
            SendMail.SendMailText("info@weipin365.com", "service@weipin365.com", _suggest + "<br/>姓名:" + _name + "<br/>E-mail:" + _email + "<br/>QQ:" + _qq, "用户反馈邮件", "用户对微品网上商城的意见与建议");
            ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:提交成功,非常感谢您对我们的意见与建议!<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"1\",\"\");</script>");
        }
    }
}