using System;

namespace weipin.admin
{
    public partial class SendAdvertisementMail : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtEmailAddress"] != null) { SendMail(); }
        }
        /// <summary>
        /// 发送
        /// </summary>
        private void SendMail()
        {
            string sEmail = Request.Form["txtEmailAddress"].ToString().Replace("\r\n", "，").Replace(" ", "，");
            string[] strArrEmail = sEmail.Split(new string[] { "，" }, StringSplitOptions.RemoveEmptyEntries);
            if (strArrEmail.Length <= 100)
            {
                for (int i = 0; i < strArrEmail.Length; i++)
                {
                    Common.SendMail.SendMailTemplate("info@weipin365.com", strArrEmail[i].ToString(), "~/mailtemplate/info/template/weipinadmail.html", "微品网上商城", "2013开年大礼!汽车饰品画“蛇”点睛22元，冬季加厚棉袜6元，双插手电暖袋28元，精美手机壳5元，加绒手套16元!");
                }
                Response.Write("<script>alert('发送成功！');location=location;</script>");
            }
            else { Response.Write("<script>alert('输入邮箱地址请不要超过100个！');location=location;</script>"); }
        }
    }
}