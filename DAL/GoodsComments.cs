/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-17
 *
 * 描述: 
**************************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

using weipin.Common;
using weipin.Model;
using System.Collections.Generic;

namespace weipin.DAL
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
            return SqlData.SelectDataTable("GoodsComments_Select", null);
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.GoodsComments SelectGoodsCommentsByID(int id)
        {
            try
            {
                Model.GoodsComments mdl = new Model.GoodsComments();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("GoodsComments_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        //mdl.CommentID = sdr["CommentID"].ToString();
                        //mdl.GoodsID = sdr["GoodsID"].ToString();
                        //mdl.LoginID = sdr["LoginID"].ToString();
                        //mdl.CommentGrade = sdr["CommentGrade"].ToString();
                        //mdl.CommentContent = sdr["CommentContent"].ToString();
                        //mdl.AddTime = sdr["AddTime"].ToString();
                        //mdl.CommentStatus = sdr["CommentStatus"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询商品评论(首页)
        /// </summary>
        /// <param name="gid">商品ID</param>
        /// <param name="perpage">每页条数</param>
        /// <returns></returns>
        public GoodsCommentsList<Model.GoodsComments> SelectGoodsCommentsTopByGID(int gid, int perpage)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(gid);
                arr.Add(perpage);
                using (SqlDataReader sdr = SqlData.SelectDataReader("GoodsComments_SelectTopByGID", arr))
                {
                    GoodsCommentsList<Model.GoodsComments> dmgc = new GoodsCommentsList<weipin.Model.GoodsComments>();
                    while (sdr.Read())
                    {
                        if (dmgc.Total == 0)
                        {
                            dmgc.Total = Convert.ToInt32(sdr["CommentID"].ToString());
                            dmgc.GoodComment = Convert.ToInt32(sdr["LoginID"].ToString());
                            dmgc.MediumComment = Convert.ToInt32(sdr["CommentGrade"].ToString());
                            dmgc.BadComment = Convert.ToInt32(sdr["CommentContent"].ToString());
                            if (sdr["AddTime"].ToString() != "") { dmgc.TotalPoints = Convert.ToInt32(sdr["AddTime"].ToString()); }
                        }
                        else
                        {
                            Model.GoodsComments mdl = new weipin.Model.GoodsComments();
                            mdl.CommentID = Convert.ToInt32(sdr["CommentID"].ToString());
                            mdl.LoginID = sdr["LoginID"].ToString();
                            mdl.CommentGrade = Convert.ToByte(sdr["CommentGrade"].ToString());
                            mdl.CommentContent = sdr["CommentContent"].ToString();
                            mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                            dmgc.Rows.Add(mdl);
                        }
                    }
                    return dmgc;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询商品评论(分页)
        /// </summary>
        /// <param name="gid">商品ID</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<Model.GoodsComments> SelectGoodsCommentsByGID(int gid, int start, int end)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(gid);
                arr.Add(start);
                arr.Add(end);
                using (SqlDataReader sdr = SqlData.SelectDataReader("GoodsComments_SelectByGID", arr))
                {
                    List<Model.GoodsComments> lmgc = new List<weipin.Model.GoodsComments>();
                    while (sdr.Read())
                    {
                        Model.GoodsComments mdl = new weipin.Model.GoodsComments();
                        mdl.CommentID = Convert.ToInt32(sdr["CommentID"].ToString());
                        mdl.LoginID = sdr["LoginID"].ToString();
                        mdl.CommentGrade = Convert.ToByte(sdr["CommentGrade"].ToString());
                        mdl.CommentContent = sdr["CommentContent"].ToString();
                        mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                        lmgc.Add(mdl);
                    }
                    return lmgc;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询评论列表(分页)
        /// </summary>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        /// <param name="_status">评论状态</param>
        /// <returns></returns>
        public DataSet SelectGoodsCommentsOfPaging(int _start, int _end, int _status)
        {
            ArrayList arr = new ArrayList();
            arr.Add(_start);
            arr.Add(_end);
            arr.Add(_status);
            return SqlData.SelectDataSet("GoodsComments_SelectOfPaging", arr);
        }
        /// <summary>
        /// 查询商品评论(分页)
        /// </summary>
        /// <param name="gid">商品ID</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="condition">构造条件SQL</param>
        /// <returns></returns>
        public List<Model.GoodsComments> SelectGoodsCommentsPagingByGID(int gid, int start, int end, string condition)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(gid.ToString());
                arr.Add(start.ToString());
                arr.Add(end.ToString());
                arr.Add(condition);
                using (SqlDataReader sdr = SqlData.SelectDataReader("GoodsComments_SelectPagingByGID", arr))
                {
                    List<Model.GoodsComments> lmgc = new List<weipin.Model.GoodsComments>();
                    while (sdr.Read())
                    {
                        Model.GoodsComments mdl = new weipin.Model.GoodsComments();
                        mdl.CommentID = Convert.ToInt32(sdr["CommentID"].ToString());
                        mdl.LoginID = sdr["LoginID"].ToString();
                        mdl.CommentGrade = Convert.ToByte(sdr["CommentGrade"].ToString());
                        mdl.CommentContent = sdr["CommentContent"].ToString();
                        mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                        lmgc.Add(mdl);
                    }
                    return lmgc;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询我的商品评论列表
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataList<Model.GoodsComments> SelectMyGoodsCommentsByLoginIDOfPaging(string loginid, string start, string end)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                arr.Add(start);
                arr.Add(end);
                using (SqlDataReader sdr = SqlData.SelectDataReader("GoodsComments_SelectMyByLoginIDOfPaging", arr))
                {
                    DataList<Model.GoodsComments> dmgc = new DataList<weipin.Model.GoodsComments>();
                    while (sdr.Read())
                    {
                        if (dmgc.Total == 0) { dmgc.Total = Convert.ToInt32(sdr["OrderID"].ToString()); }
                        else
                        {
                            Model.GoodsComments mdl = new Model.GoodsComments();
                            mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                            mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                            mdl.DeliveryTime = Convert.ToDateTime(sdr["DeliveryTime"].ToString());
                            mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                            mdl.IsCommented = Convert.ToBoolean(sdr["IsCommented"].ToString());
                            dmgc.Rows.Add(mdl);
                        }
                    }
                    return dmgc;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertGoodsComments(Model.GoodsComments mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.GoodsID);
            arr.Add(mdl.LoginID);
            arr.Add(mdl.OrdersGoodsID);
            arr.Add(mdl.AppearanceGrade);
            arr.Add(mdl.QualityGrade);
            arr.Add(mdl.CommentGrade);
            arr.Add(mdl.CommentContent);
            if (mdl.SimilarNumber != 0) { arr.Add(mdl.SimilarNumber); } else { arr.Add(null); }
            return SqlData.InsDelUpdData("GoodsComments_Insert", arr);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteGoodsCommentsByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("GoodsComments_DeleteByID", arr);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateGoodsComments(Model.GoodsComments mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.CommentID);
            //arr.Add(mdl.GoodsID);
            //arr.Add(mdl.LoginID);
            //arr.Add(mdl.CommentGrade);
            //arr.Add(mdl.CommentContent);
            //arr.Add(mdl.AddTime);
            //arr.Add(mdl.CommentStatus);
            return SqlData.InsDelUpdData("GoodsComments_Update", arr);
        }
        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="mgc"></param>
        /// <returns></returns>
        public int UpdateGoodsCommentsStatus(Model.GoodsComments mgc)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mgc.CommentID);
            arr.Add(mgc.CommentStatus);
            arr.Add(mgc.OrdersGoodsID);
            return SqlData.InsDelUpdData("GoodsComments_UpdateStatus", arr);
        }
    }
}