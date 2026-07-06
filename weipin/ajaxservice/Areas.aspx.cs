using System;

namespace weipin.ajaxservice
{
    public partial class Areas : System.Web.UI.Page
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
                        case "DeleteAreasByAreaID":
                            value = DeleteAreasByAreaID();
                            break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 删除区域分类
        /// </summary>
        /// <returns></returns>
        private string DeleteAreasByAreaID()
        {
            string _res = string.Empty;
            int _aid = Convert.ToInt32(Request.Form["aid"].ToString());
            BLL.Areas ba = new weipin.BLL.Areas();
            if (ba.DeleteAreasByID(_aid))
            {
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