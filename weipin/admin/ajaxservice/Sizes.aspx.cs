using System;

namespace weipin.admin.ajaxservice
{
    public partial class Sizes : Common.BasePageAdmin
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
                        case "DeleteSizesBySizeID":
                            value = DeleteSizesBySizeID();
                            break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 删除尺码
        /// </summary>
        /// <returns></returns>
        private string DeleteSizesBySizeID()
        {
            string _res = string.Empty;
            int _avid = Convert.ToInt16(Request.Form["sid"].ToString());
            BLL.Sizes bs = new weipin.BLL.Sizes();
            if (bs.DeleteSizesByID(_avid))
            {
                bs.CreateSizesXML();
                _res = "1";
            }
            else
            {
                _res = "0";
            }
            return _res;
        }
    }
}