/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-17
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using System;
using weipin.Model;
using System.Text;
using System.Collections.Generic;

namespace weipin.BLL
{
    public class GoodsComments
    {
        public GoodsComments()
        { }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllGoodsComments()
        {
            DAL.GoodsComments dal = new DAL.GoodsComments();
            return dal.SelectAllGoodsComments();
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.GoodsComments SelectGoodsCommentsByID(int id)
        {
            DAL.GoodsComments dal = new DAL.GoodsComments();
            return dal.SelectGoodsCommentsByID(id);
        }
        /// <summary>
        /// 查询商品评论(首页)
        /// </summary>
        /// <param name="gid">商品ID</param>
        /// <param name="perpage">每页条数</param>
        /// <returns></returns>
        public string SelectGoodsCommentsTopByGID(int gid, int perpage)
        {
            StringBuilder sb = new StringBuilder();
            DAL.GoodsComments dgc = new weipin.DAL.GoodsComments();
            GoodsCommentsList<Model.GoodsComments> dmgc = dgc.SelectGoodsCommentsTopByGID(gid, perpage);
            if (dmgc != null && dmgc.Rows.Count > 0)
            {
                sb.Append(dmgc.Total + "|" + dmgc.GoodComment + "|" + dmgc.MediumComment + "|" + dmgc.BadComment + "|" + dmgc.TotalPoints + "|");
                for (int i = 0; i < dmgc.Rows.Count; i++)
                {
                    sb.Append("<div><ul class=\"assess\"><li class=\"assess_zl\"><a class=\"user_n\">" + dmgc.Rows[i].LoginID.Substring(0, 2) + "*****" + dmgc.Rows[i].LoginID.Substring(dmgc.Rows[i].LoginID.Length - 2, 2) + "</a><span class=\"star" + dmgc.Rows[i].CommentGrade + "\" title=\"" + dmgc.Rows[i].CommentGrade + "\"></span>");
                    sb.Append("<span class=\"time2\">评论时间 " + dmgc.Rows[i].AddTime + "</span><div class=\"clear\"></div></li><li>" + dmgc.Rows[i].CommentContent + "</li></ul></div>");
                }
            }
            else
            {
                sb.Append("0|0|0|0|0|");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 查询商品评论(分页)
        /// </summary>
        /// <param name="gid">商品ID</param>
        /// <param name="nowpage">当前页</param>
        /// <param name="perpage">每页条数</param>
        /// <returns></returns>
        public string SelectGoodsCommentsByGID(int gid, int nowpage, byte perpage)
        {
            string[] _arr = Common.Pagination.CountStartEnd(nowpage, perpage);
            StringBuilder sb = new StringBuilder();
            DAL.GoodsComments dgc = new weipin.DAL.GoodsComments();
            List<Model.GoodsComments> lmgc = dgc.SelectGoodsCommentsByGID(gid, Convert.ToInt32(_arr[0]), Convert.ToInt32(_arr[1]));
            if (lmgc != null && lmgc.Count > 0)
            {
                for (int i = 0; i < lmgc.Count; i++)
                {
                    sb.Append("<div><ul class=\"assess\"><li class=\"assess_zl\"><a class=\"user_n\">" + lmgc[i].LoginID.Substring(0, 2) + "*****" + lmgc[i].LoginID.Substring(lmgc[i].LoginID.Length - 2, 2) + "</a><span class=\"star" + lmgc[i].CommentGrade + "\" title=\"" + lmgc[i].CommentGrade + "\"></span>");
                    sb.Append("<span class=\"time2\">评论时间 " + lmgc[i].AddTime + "</span><div class=\"clear\"></div></li><li>" + lmgc[i].CommentContent + "</li></ul></div>");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 查询评论列表(分页)
        /// </summary>
        /// <param name="_nowpage">当前页</param>
        /// <param name="_perpage">每页条数</param>
        /// <param name="_status">评论状态</param>
        /// <returns></returns>
        public DataSet SelectGoodsCommentsOfPaging(int _nowpage, int _perpage, int _status)
        {
            string[] _arr = Common.Pagination.CountStartEnd(_nowpage, _perpage);
            DAL.GoodsComments dgc = new weipin.DAL.GoodsComments();
            return dgc.SelectGoodsCommentsOfPaging(Convert.ToInt16(_arr[0]), Convert.ToInt16(_arr[1]), _status);
        }
        /// <summary>
        /// 查询商品评论(分页)
        /// </summary>
        /// <param name="gid">商品ID</param>
        /// <param name="nowpage">当前页</param>
        /// <param name="perpage">每页条数</param>
        /// <param name="condition">构造条件SQL</param>
        /// <returns></returns>
        public string SelectGoodsCommentsPagingByGID(int gid, int nowpage, byte perpage, string condition)
        {
            string[] _arr = Common.Pagination.CountStartEnd(nowpage, perpage);
            StringBuilder sb = new StringBuilder();
            DAL.GoodsComments dgc = new weipin.DAL.GoodsComments();
            List<Model.GoodsComments> lmgc = dgc.SelectGoodsCommentsPagingByGID(gid, Convert.ToInt32(_arr[0]), Convert.ToInt32(_arr[1]), condition);
            if (lmgc != null && lmgc.Count > 0)
            {
                for (int i = 0; i < lmgc.Count; i++)
                {
                    sb.Append("<div><ul class=\"assess\"><li class=\"assess_zl\"><a class=\"user_n\">" + lmgc[i].LoginID.Substring(0, 2) + "*****" + lmgc[i].LoginID.Substring(lmgc[i].LoginID.Length - 2, 2) + "</a><span class=\"star" + lmgc[i].CommentGrade + "\" title=\"" + lmgc[i].CommentGrade + "\"></span>");
                    sb.Append("<span class=\"time2\">评论时间 " + lmgc[i].AddTime + "</span><div class=\"clear\"></div></li><li>" + lmgc[i].CommentContent + "</li></ul></div>");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 查询我的商品评论列表
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="nowpage">当前页</param>
        /// <param name="perpage">每页条数</param>
        /// <returns></returns>
        public DataList<Model.GoodsComments> SelectMyGoodsCommentsByLoginIDOfPaging(string loginid, int nowpage, int perpage)
        {
            string[] _arr = Common.Pagination.CountStartEnd(nowpage, perpage);
            DAL.GoodsComments dgc = new weipin.DAL.GoodsComments();
            return dgc.SelectMyGoodsCommentsByLoginIDOfPaging(loginid, _arr[0].ToString(), _arr[1].ToString());
        }
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool InsertGoodsComments(Model.GoodsComments mdl)
        {
            DAL.GoodsComments dal = new DAL.GoodsComments();
            if (dal.InsertGoodsComments(mdl) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteGoodsCommentsByID(int id)
        {
            DAL.GoodsComments dal = new DAL.GoodsComments();
            if (dal.DeleteGoodsCommentsByID(id) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool UpdateGoodsComments(Model.GoodsComments mdl)
        {
            DAL.GoodsComments dal = new DAL.GoodsComments();
            if (dal.UpdateGoodsComments(mdl) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="mgc"></param>
        /// <returns></returns>
        public bool UpdateGoodsCommentsStatus(Model.GoodsComments mgc)
        {
            DAL.GoodsComments dgc = new weipin.DAL.GoodsComments();
            if (dgc.UpdateGoodsCommentsStatus(mgc) > 0) { return true; } else { return false; }
        }
    }
}