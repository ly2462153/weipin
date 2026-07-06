using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace weipin.admin.ajaxservice
{
    public partial class GoodsPictures : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string value = string.Empty;
            string strParam = Request.Form["ptype"];
            if (strParam != null)
            {
                switch (strParam)
                {
                    case "DeletePicture":
                        value = DeletePicture();
                        break;
                }
            }
            Response.Write(value);
            Response.End();
        }
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="_picpath"></param>
        protected string DeletePicture()
        {
            string _picpath = Request.Form["picpath"].ToString();
            _picpath = Server.MapPath(_picpath);
            if (System.IO.File.Exists(_picpath))
            {
                System.IO.File.Delete(_picpath);
            }
            return _picpath;
        }
    }
}