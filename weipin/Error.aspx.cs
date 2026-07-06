using System;
using System.Text;

namespace weipin
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["msg"] != null) { strMsg.InnerText = Server.UrlDecode(Request.QueryString["msg"].ToString()); }
        }
    }
}