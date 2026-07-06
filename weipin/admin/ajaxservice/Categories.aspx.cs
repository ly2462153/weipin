using System;

namespace weipin.admin.ajaxservice
{
    public partial class Categories : Common.BasePageAdmin
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
                        case "DeleteCategoriesByCategoryID":
                            value = DeleteCategoriesByCategoryID();
                            break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 删除分类
        /// </summary>
        /// <returns></returns>
        private string DeleteCategoriesByCategoryID()
        {
            string _res = string.Empty;
            int _cid = Convert.ToInt32(Request.Form["cid"].ToString());
            BLL.Categories bc = new weipin.BLL.Categories();
            if (bc.DeleteCategoriesByID(_cid))
            {
                bc.CreateCategoriesXML();
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