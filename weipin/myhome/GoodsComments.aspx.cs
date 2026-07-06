using System;
using weipin.Common;

namespace weipin.myhome
{
    public partial class GoodsComments : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Commonality.JudgeNumber(Request.Form["hidGoodsID"], 10)) { InsertGoodsComments(); }
            else if (Commonality.JudgeNumber(Request.QueryString["ogid"], 10)) { BindGoodsAndJudgeCommentRightByOGID(Convert.ToInt32(Request.QueryString["ogid"].ToString())); }
            else if (Commonality.JudgeNumber(Request.QueryString["gid"], 10)) { BindGoodsAndJudgeCommentRightByGoodsID(Convert.ToInt32(Request.QueryString["gid"].ToString())); }
        }
        /// <summary>
        /// 绑定商品信息并判断评论权限
        /// <param name="ogid">OrdersGoodsID</param>
        /// </summary>
        private void BindGoodsAndJudgeCommentRightByOGID(int ogid)
        {
            BLL.Goods bg = new weipin.BLL.Goods();
            Model.Goods mg = bg.SelectGoodsAndJudgeCommentRightByOGID(GetSessionOfLoginUser().LoginID, ogid);
            if (mg != null && mg.GoodsID != 0)
            {
                if (mg.GoodsID > 0)
                {
                    string _str = string.Empty;
                    string _path = mg.GoodsPicturePath;
                    _str = "<ul><li style=\"width:100px;\"><a href=\"/page/" + mg.GoodsID / 1000 + "/goodsshow_" + mg.GoodsID.ToString() + ".html\" target=\"_blank\" style=\"float:left;\"><img src=\"" + _path.Insert(_path.LastIndexOf("."), "_85x85") + "\"/></a></li><li style=\"width:300px;\"><p>" + mg.GoodsName + "<input type=\"hidden\" name=\"hidGoodsID\" value=\"" + mg.GoodsID.ToString() + "\"/><input type=\"hidden\" name=\"hidSimilarNumber\" value=\"" + mg.SimilarNumber.ToString() + "\"/><input type=\"hidden\" name=\"hidOrdersGoodsID\" value=\"" + ogid.ToString() + "\"/></p><p style=\"color:#a10000;font-weight:bold;\">售价:￥" + (mg.DiscountPrice != 0 ? mg.DiscountPrice : mg.Price) + "</p></li></ul>";
                    divGoods.InnerHtml = _str;
                }
                else { divComment.InnerHtml = "您暂不能评论该商品，原因可能是您没有购买过该商品或已对该商品进行过评论。<a href=\"GoodsCommentsList.aspx\">评论其它商品>></a>"; }
            }
        }
        /// <summary>
        /// 绑定商品信息并判断评论权限
        /// <param name="gid">商品ID</param>
        /// </summary>
        private void BindGoodsAndJudgeCommentRightByGoodsID(int gid)
        {
            BLL.Goods bg = new weipin.BLL.Goods();
            Model.Goods mg = bg.SelectGoodsAndJudgeCommentRightByGoodsID(GetSessionOfLoginUser().LoginID, gid);
            if (mg != null && mg.GoodsID != 0)
            {
                if (mg.GoodsID > 0)
                {
                    string _str = string.Empty;
                    string _path = mg.GoodsPicturePath;
                    _str = "<ul><li style=\"width:100px;\"><a href=\"/page/" + mg.GoodsID / 1000 + "/goodsshow_" + mg.GoodsID.ToString() + ".html\" target=\"_blank\" style=\"float:left;\"><img src=\"" + _path.Insert(_path.LastIndexOf("."), "_85x85") + "\"/></a></li><li style=\"width:300px;\"><p>" + mg.GoodsName + "<input type=\"hidden\" name=\"hidGoodsID\" value=\"" + mg.GoodsID.ToString() + "\"/><input type=\"hidden\" name=\"hidSimilarNumber\" value=\"" + mg.SimilarNumber.ToString() + "\"/><input type=\"hidden\" name=\"hidOrdersGoodsID\" value=\"" + mg.OrdersGoodsID.ToString() + "\"/></p><p style=\"color:#a10000;font-weight:bold;\">售价:￥" + (mg.DiscountPrice != 0 ? mg.DiscountPrice : mg.Price) + "</p></li></ul>";
                    divGoods.InnerHtml = _str;
                }
                else { divComment.InnerHtml = "您暂不能评论该商品，原因可能是您没有购买过该商品或已对该商品进行过评论。<a href=\"GoodsCommentsList.aspx\">评论其它商品>></a>"; }
            }
        }
        /// <summary>
        /// 提交商品评论
        /// </summary>
        private void InsertGoodsComments()
        {
            Model.GoodsComments mgc = new weipin.Model.GoodsComments();
            mgc.GoodsID = Convert.ToInt32(Request.Form["hidGoodsID"].ToString());
            if (Commonality.JudgeNumber(Request.Form["hidSimilarNumber"], 10)) { mgc.SimilarNumber = Convert.ToInt32(Request.Form["hidSimilarNumber"].ToString()); }
            mgc.LoginID = GetSessionOfLoginUser().LoginID;
            mgc.OrdersGoodsID = Convert.ToInt32(Request.Form["hidOrdersGoodsID"].ToString());
            #region 验证
            if (Commonality.JudgeNumber(Request.Form["hidAppearance"], 3) && Convert.ToByte(Request.Form["hidAppearance"].ToString()) >= 1 && Convert.ToByte(Request.Form["hidAppearance"].ToString()) <= 5) { mgc.AppearanceGrade = Convert.ToByte(Request.Form["hidAppearance"].ToString()); } else { Response.Write("<script>alert('请正确选择外观评分!');</script>"); return; }
            if (Commonality.JudgeNumber(Request.Form["hidQuality"], 3) && Convert.ToByte(Request.Form["hidQuality"].ToString()) >= 1 && Convert.ToByte(Request.Form["hidQuality"].ToString()) <= 5) { mgc.QualityGrade = Convert.ToByte(Request.Form["hidQuality"].ToString()); } else { Response.Write("<script>alert('请正确选择质量评分!');</script>"); return; }
            if (Commonality.JudgeNumber(Request.Form["hidComment"], 3) && Convert.ToByte(Request.Form["hidComment"].ToString()) >= 1 && Convert.ToByte(Request.Form["hidComment"].ToString()) <= 5) { mgc.CommentGrade = Convert.ToByte(Request.Form["hidComment"].ToString()); } else { Response.Write("<script>alert('请正确选择综合评分!');</script>"); return; }
            #endregion
            mgc.CommentContent = Commonality.CutString(Request.Form["txtComment"].ToString().Replace("\r\n", "<br/>"), 300);
            BLL.GoodsComments bgc = new weipin.BLL.GoodsComments();
            if (bgc.InsertGoodsComments(mgc))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:提交评论成功<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"1\",\"\");</script>");
            }
            else { divComment.InnerHtml = "您暂不能评论该商品，原因可能是您没有购买过该商品或已对该商品进行过评论。<a href=\"GoodsCommentsList.aspx\">评论其它商品>></a>"; }
        }
    }
}