using System;

namespace weipin.ajaxservice
{
    public partial class GoodsComments : System.Web.UI.Page
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
                        case "SelectGoodsCommentsTopByGID":
                            value = SelectGoodsCommentsTopByGID();
                            break;
                        case "SelectGoodsCommentsByGID":
                            value = SelectGoodsCommentsByGID();
                            break;
                        case "SelectGoodsCommentsTypeByGID":
                            value = SelectGoodsCommentsTypeByGID();
                            break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 查询商品评论(首页)
        /// </summary>
        /// <returns></returns>
        private string SelectGoodsCommentsTopByGID()
        {
            int _gid = Convert.ToInt32(Request.Form["gid"].ToString());
            int _perpage = Convert.ToInt32(Request.Form["perpage"].ToString());
            BLL.GoodsComments bgc = new weipin.BLL.GoodsComments();
            return bgc.SelectGoodsCommentsTopByGID(_gid, _perpage);
        }
        /// <summary>
        /// 查询商品评论(分页)
        /// </summary>
        /// <returns></returns>
        private string SelectGoodsCommentsByGID()
        {
            int _gid = Convert.ToInt32(Request.Form["gid"].ToString());
            int _nowpage = Convert.ToInt16(Request.Form["nowpage"].ToString());
            byte _perpage = Convert.ToByte(Request.Form["perpage"].ToString());
            BLL.GoodsComments bgc = new weipin.BLL.GoodsComments();
            return bgc.SelectGoodsCommentsByGID(_gid, _nowpage, _perpage);
        }
        /// <summary>
        /// 查询商品评论(分页)
        /// </summary>
        /// <returns></returns>
        private string SelectGoodsCommentsTypeByGID()
        {
            int _gid = Convert.ToInt32(Request.Form["gid"].ToString());
            int _nowpage = Convert.ToInt16(Request.Form["nowpage"].ToString());
            byte _perpage = Convert.ToByte(Request.Form["perpage"].ToString());
            byte _typeid = Convert.ToByte(Request.Form["typeid"].ToString());
            string _condition = string.Empty;
            switch (_typeid)
            {
                case 1: _condition = ""; break;
                case 2: _condition = " and CommentGrade>=4 and CommentGrade<=5"; break;
                case 3: _condition = " and CommentGrade>=2 and CommentGrade<=3"; break;
                case 4: _condition = " and CommentGrade=1"; break;
            }
            BLL.GoodsComments bgc = new weipin.BLL.GoodsComments();
            return bgc.SelectGoodsCommentsPagingByGID(_gid, _nowpage, _perpage, _condition);
        }
    }
}