using System;

namespace weipin.admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtLoginUser.Value.ToString()) && !string.IsNullOrEmpty(this.txtLoginPSW.Value.ToString()))
            {
                //个人登陆
                string sID = this.txtLoginUser.Value.ToString();
                string sLoginPSW = this.txtLoginPSW.Value.ToString();
                bool bRemember = this.ckbLoginType.Checked;
                BLL.Admins ba = new weipin.BLL.Admins();
                string res = ba.CheckUser(sID, sLoginPSW, bRemember);
                if (res == "1")
                {
                    Response.Redirect("GoodsAdd.aspx");
                }
                else if (res == "2")
                {
                    this.txtLoginPSW.Value = "";
                    this.spAlert.InnerText = "提示:密码错误，请重新输入！";
                }
                else
                {
                    this.txtLoginUser.Value = "";
                    this.txtLoginPSW.Value = "";
                    this.spAlert.InnerText = "提示:该用户名不存在，请重新输入！";
                }
            }
            else
            {
                this.spAlert.InnerText = "提示:请输入用户名和密码！";
            }
        }
    }
}