using System;

namespace weipin.admin.ajaxservice
{
    public partial class Attributes : Common.BasePageAdmin
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
                        case "DeleteAttributesByAttributeID":
                            value = DeleteAttributesByAttributeID();
                            break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 删除分类属性
        /// </summary>
        /// <returns></returns>
        private string DeleteAttributesByAttributeID()
        {
            string _res = string.Empty;
            int _aid = Convert.ToInt32(Request.Form["aid"].ToString());
            int _cid = Convert.ToInt32(Request.Form["cid"].ToString());
            BLL.Attributes ba = new weipin.BLL.Attributes();
            if (ba.DeleteAttributesByID(_aid))
            {
                ba.CreateAttributesXML(_cid);
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