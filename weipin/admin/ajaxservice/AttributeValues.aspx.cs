using System;

namespace weipin.admin.ajaxservice
{
    public partial class AttributeValues : Common.BasePageAdmin
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
                        case "DeleteAttributeValuesByAttributeValueID":
                            value = DeleteAttributeValuesByAttributeValueID();
                            break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 删除属性值
        /// </summary>
        /// <returns></returns>
        private string DeleteAttributeValuesByAttributeValueID()
        {
            string _res = string.Empty;
            int _avid = Convert.ToInt32(Request.Form["avid"].ToString());
            int _cid = Convert.ToInt32(Request.Form["cid"].ToString());
            BLL.AttributeValues bav = new weipin.BLL.AttributeValues();
            if (bav.DeleteAttributeValuesByID(_avid))
            {
                BLL.Attributes ba = new weipin.BLL.Attributes();
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