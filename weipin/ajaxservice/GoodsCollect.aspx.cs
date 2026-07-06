using System;
using weipin.Common;

namespace weipin.ajaxservice
{
    public partial class GoodsCollect : Common.BasePage
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
                        case "CollectGoods":
                            value = CollectGoods();
                            break;
                        case "DeleteGoodsCollectByID":
                            value = DeleteGoodsCollectByID();
                            break;
                        case "DeleteGoodsCollectAllByID":
                            value = DeleteGoodsCollectAllByID();
                            break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 收藏商品
        /// </summary>
        /// <returns></returns>
        private string CollectGoods()
        {
            int _gid = Convert.ToInt32(Request.Form["gid"].ToString());
            if (GetSessionOfLoginUser() != null)
            {
                BLL.GoodsCollect bgc = new weipin.BLL.GoodsCollect();
                return bgc.InsertGoodsCollect(GetSessionOfLoginUser().LoginID, _gid).ToString();
            }
            else { return "3"; }
        }
        /// <summary>
        /// 删除我的收藏
        /// </summary>
        /// <returns></returns>
        private string DeleteGoodsCollectByID()
        {
            long _cid = Convert.ToInt64(Request.Form["cid"].ToString());
            if (GetSessionOfLoginUser() != null)
            {
                BLL.GoodsCollect bgc = new weipin.BLL.GoodsCollect();
                return bgc.DeleteGoodsCollectByID(GetSessionOfLoginUser().LoginID, _cid).ToString();
            }
            else { return "2"; }
        }
        /// <summary>
        /// 删除勾选的收藏
        /// </summary>
        /// <returns></returns>
        private string DeleteGoodsCollectAllByID()
        {
            string _res = string.Empty;
            string[] cidarr = Request.Form["cidarr"].ToString().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            if (GetSessionOfLoginUser() != null && cidarr != null)
            {
                System.Text.StringBuilder sbSQL = new System.Text.StringBuilder();
                for (int i = 0; i < cidarr.Length; i++)
                {
                    if (Commonality.JudgeNumber(cidarr[i], 19))
                    {
                        sbSQL.Append(" delete from GoodsCollect where LoginID='" + GetSessionOfLoginUser().LoginID + "' and CollectID=" + cidarr[i]);
                    }
                }
                if (sbSQL.ToString() != "")
                {
                    BLL.GoodsCollect bgc = new weipin.BLL.GoodsCollect();
                    _res = bgc.DeleteGoodsCollectAllByID(sbSQL.ToString()).ToString();
                }
            }
            else { _res = "-1"; }
            return _res;
        }
    }
}