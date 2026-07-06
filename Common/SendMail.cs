using System;
using System.Web;
using System.Net.Mail;

namespace weipin.Common
{
    public class SendMail : System.Web.UI.Page
    {
        public SendMail()
        { }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="from">发送者的邮箱</param>
        /// <param name="to">接收者的邮箱</param>
        /// <param name="content">邮件内容</param>
        /// <param name="fromname">邮件标题</param>
        /// <param name="subject">邮件主题</param>
        /// <returns></returns>
        public static void SendMailText(string from, string to, string content, string fromname, string subject)
        {
            MailMessage msg = new MailMessage();
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(from, fromname);
            msg.To.Add(new MailAddress(to));
            msg.Subject = subject;
            msg.Body = content;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            SmtpClient smtp = new SmtpClient("mail.weipin365.com");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential("info@weipin365.com", "wip365mail2012*");
            smtp.EnableSsl = false;
            try { smtp.Send(msg); }
            catch (Exception ex) { HttpContext.Current.Response.Write("发送失败:" + ex); }
        }
        /// <summary>
        /// 发送邮件(含有抄送接收者)
        /// </summary>
        /// <param name="from">发送者的邮箱</param>
        /// <param name="to">接收者的邮箱(string[]数组)</param>
        /// <param name="cc">抄送接收者的邮箱(string[]数组)</param>
        /// <param name="content">邮件内容(html)</param>
        /// <param name="fromname">发送者名称</param>
        /// <param name="subject">主题</param>
        /// <returns></returns>
        public static void SendMailText(string from, string[] to, string[] cc, string content, string fromname, string subject)
        {
            MailMessage msg = new MailMessage();
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(from, fromname);
            for (int i = 0; i < to.Length; i++)
            {
                msg.To.Add(new MailAddress(to[i].ToString()));
            }
            if (cc != null)
            {
                for (int j = 0; j < cc.Length; j++)
                {
                    msg.CC.Add(new MailAddress(cc[j].ToString()));
                }
            }
            msg.Subject = subject;
            msg.Body = content;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            SmtpClient smtp = new SmtpClient("mail.weipin365.com");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential("info@weipin365.com", "wip365mail2012*");
            smtp.EnableSsl = false;
            try { smtp.Send(msg); }
            catch { throw; }
        }
        /// <summary>
        /// 发送邮件(附件)
        /// </summary>
        /// <param name="from">发送者的邮箱</param>
        /// <param name="to">接收者的邮箱</param>
        /// <param name="mailsubject">邮件主题</param>
        /// <param name="mailtitle">邮件标题</param>
        /// <param name="mailcontent">邮件内容</param>
        /// <param name="attapath">附件路径</param>
        /// <returns></returns>
        public static void SendMailText(string from, string to, string content, string fromname, string subject, string attapath)
        {
            MailMessage msg = new MailMessage();
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(from, fromname);
            msg.To.Add(new MailAddress(to));
            msg.Subject = subject;
            msg.Body = content;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.Attachments.Add(new Attachment(HttpContext.Current.Server.MapPath(attapath)));
            SmtpClient smtp = new SmtpClient("mail.weipin365.com");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential("info@weipin365.com", "wip365mail2012*");
            smtp.EnableSsl = false;
            try { smtp.Send(msg); }
            catch (Exception ex) { HttpContext.Current.Response.Write("发送失败:" + ex); }
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="from">发送者的邮箱</param>
        /// <param name="to">接收者的邮箱</param>
        /// <param name="path">模板路径</param>
        /// <param name="fromname">发送者名称</param>
        /// <param name="subject">主题</param>
        /// <returns></returns>
        public static void SendMailTemplate(string from, string to, string path, string fromname, string subject)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath(path), System.Text.Encoding.UTF8));

            MailMessage msg = new MailMessage();
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(from, fromname);
            msg.To.Add(new MailAddress(to));
            msg.Subject = subject;
            msg.Body = sb.ToString();
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            //SmtpClient smtp = new SmtpClient("smtp.cd.9kz.cn");
            SmtpClient smtp = new SmtpClient("mail.tianqiang.cn");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.Credentials = new System.Net.NetworkCredential("liaoyi@cd.9kz.cn", "liaoyi123");
            smtp.Credentials = new System.Net.NetworkCredential("postmaster@tianqiang.cn", "Tmail990");
            smtp.EnableSsl = false;
            try { smtp.Send(msg); }
            catch (Exception ex) { HttpContext.Current.Response.Write("发送失败:" + ex); }
        }
        /// <summary>
        /// 发送邮件(附件)
        /// </summary>
        /// <param name="from">发送者的邮箱</param>
        /// <param name="to">接收者的邮箱</param>
        /// <param name="path">模板路径</param>
        /// <param name="fromname">发送者名称</param>
        /// <param name="subject">主题</param>
        /// <param name="attapath">附件路径</param>
        /// <returns></returns>
        public static void SendMailTemplate(string from, string to, string path, string fromname, string subject, string attapath)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath(path), System.Text.Encoding.UTF8));

            MailMessage msg = new MailMessage();
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(from, fromname);
            msg.To.Add(new MailAddress(to));
            msg.Subject = subject;
            msg.Body = sb.ToString();
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.Attachments.Add(new Attachment(HttpContext.Current.Server.MapPath(attapath)));
            SmtpClient smtp = new SmtpClient("mail.weipin365.com");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential("info@weipin365.com", "wip365mail2012*");
            smtp.EnableSsl = false;
            try { smtp.Send(msg); }
            catch (Exception ex) { HttpContext.Current.Response.Write("发送失败:" + ex); }
        }
    }
}