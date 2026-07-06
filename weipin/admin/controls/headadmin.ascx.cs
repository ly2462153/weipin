using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace weipin.admin.controls
{
    public partial class headadmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.stName.InnerText = Common.BasePageAdmin.GetSessionOfLoginAdmin().AdminName.ToString();
            this.stToday.InnerText = DateTime.Today.ToString("yyyy年M月dd日");
        }
    }
}