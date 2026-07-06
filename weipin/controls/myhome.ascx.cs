using System;
using weipin.Common;

namespace weipin.controls
{
    public partial class myhome : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            if (BasePage.GetSessionOfLoginUser() == null)
            {
                Response.Redirect("/Login.aspx?returnurl=" + Request.Url.ToString());
            }
            base.OnInit(e);
        }
    }
}