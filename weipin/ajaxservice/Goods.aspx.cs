using System;

namespace weipin.ajaxservice
{
    public partial class Goods : System.Web.UI.Page
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
                        case "SelectGoodsSimilarBrowerBuyByCID":
                            value = SelectGoodsSimilarBrowerBuyByCID();
                            break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 查询同类商品/浏览过此商品的用户还购买过
        /// </summary>
        /// <returns></returns>
        private string SelectGoodsSimilarBrowerBuyByCID()
        {
            int _cid = Convert.ToInt32(Request.Form["cid"].ToString());
            int _gid = Convert.ToInt32(Request.Form["gid"].ToString());
            BLL.Goods bg = new weipin.BLL.Goods();
            return bg.SelectGoodsSimilarBrowerBuyByCID(_cid, _gid);
        }
    }
}