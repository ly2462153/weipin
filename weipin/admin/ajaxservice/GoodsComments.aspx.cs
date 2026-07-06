using System;

namespace weipin.admin.ajaxservice
{
    public partial class GoodsComments : Common.BasePageAdmin
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
                        case "UpdateStatusByCommentID":
                            value = UpdateStatusByCommentID();
                            break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <returns></returns>
        private string UpdateStatusByCommentID()
        {
            string _res = string.Empty;
            Model.GoodsComments mgc = new weipin.Model.GoodsComments();
            mgc.CommentID = Convert.ToInt32(Request.Form["cid"].ToString());
            mgc.CommentStatus = Convert.ToByte(Request.Form["status"].ToString());
            mgc.OrdersGoodsID = Convert.ToInt32(Request.Form["ogid"].ToString());
            BLL.GoodsComments bgc = new weipin.BLL.GoodsComments();
            if (bgc.UpdateGoodsCommentsStatus(mgc)) { _res = "1"; }
            else { _res = "0"; }
            return _res;
        }
    }
}