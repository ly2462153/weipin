/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-10
 *
 * 描述: 
**************************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

using weipin.Common;
using weipin.Model;

namespace weipin.DAL
{
    public class GoodsCollect
    {
        public GoodsCollect()
        { }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllGoodsCollect()
        {
            return SqlData.SelectDataTable("GoodsCollect_Select", null);
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.GoodsCollect SelectGoodsCollectByID(int id)
        {
            try
            {
                Model.GoodsCollect mdl = new Model.GoodsCollect();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("GoodsCollect_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        //mdl.CollectID = sdr["CollectID"].ToString();
                        //mdl.LoginID = sdr["LoginID"].ToString();
                        //mdl.GoodsID = sdr["GoodsID"].ToString();
                        //mdl.AddTime = sdr["AddTime"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询我的收藏
        /// </summary>
        /// <param name="loginid">用户名ID</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataList<Model.GoodsCollect> SelectMyGoodsCollectByLoginIDOfPaging(string loginid, string start, string end)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                arr.Add(start);
                arr.Add(end);
                using (SqlDataReader sdr = SqlData.SelectDataReader("GoodsCollect_SelectMyByLoginIDOfPaging", arr))
                {
                    DataList<Model.GoodsCollect> dmgc = new DataList<weipin.Model.GoodsCollect>();
                    while (sdr.Read())
                    {
                        if (dmgc.Total == 0)
                        {
                            dmgc.Total = Convert.ToInt32(sdr["CollectID"].ToString());
                        }
                        else
                        {
                            Model.GoodsCollect mdl = new Model.GoodsCollect();
                            mdl.CollectID = Convert.ToInt64(sdr["CollectID"].ToString());
                            mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                            mdl.GoodsName = sdr["GoodsName"].ToString();
                            mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                            mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                            if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
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
        /// 添加
        /// </summary>
        /// <param name="loginid">用户名</param>
        /// <param name="gid">商品ID</param>
        /// <returns></returns>
        public int InsertGoodsCollect(string loginid, int gid)
        {
            ArrayList arr = new ArrayList();
            arr.Add(loginid);
            arr.Add(gid);
            return SqlData.InsDelUpdDataReturnOneValue("GoodsCollect_Insert", arr);
        }
        /// <summary>
        /// 取消我的收藏
        /// </summary>
        /// <param name="loginid"></param>
        /// <param name="cid">收藏主键</param>
        /// <returns></returns>
        public int DeleteGoodsCollectByID(string loginid, long cid)
        {
            ArrayList arr = new ArrayList();
            arr.Add(loginid);
            arr.Add(cid);
            return SqlData.InsDelUpdData("GoodsCollect_DeleteByID", arr);
        }
        /// <summary>
        /// 删除勾选的收藏
        /// </summary>
        /// <param name="sql">拼接删除收藏的字符串</param>
        /// <returns></returns>
        public int DeleteGoodsCollectAllByID(string sql)
        {
            return SqlData.InsDelUpdData(sql);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateGoodsCollect(Model.GoodsCollect mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.CollectID);
            //arr.Add(mdl.LoginID);
            //arr.Add(mdl.GoodsID);
            //arr.Add(mdl.AddTime);
            return SqlData.InsDelUpdData("GoodsCollect_Update", arr);
        }
    }
}