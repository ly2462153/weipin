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
using System.Collections.Generic;

namespace weipin.DAL
{
    public class Categories_Goods
    {
        public Categories_Goods()
        { }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertCategories_Goods(Model.Categories_Goods mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.CategoryGoodsID);
            //arr.Add(mdl.CategoryID);
            //arr.Add(mdl.GoodsID);
            return SqlData.InsDelUpdData("Categories_Goods_Insert", arr);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCategories_GoodsByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("Categories_Goods_DeleteByID", arr);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateCategories_Goods(Model.Categories_Goods mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.CategoryGoodsID);
            //arr.Add(mdl.CategoryID);
            //arr.Add(mdl.GoodsID);
            return SqlData.InsDelUpdData("Categories_Goods_Update", arr);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllCategories_Goods()
        {
            return SqlData.SelectDataTable("Categories_Goods_Select", null);
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Categories_Goods SelectCategories_GoodsByID(int id)
        {
            try
            {
                Model.Categories_Goods mdl = new Model.Categories_Goods();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Categories_Goods_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        //mdl.CategoryGoodsID = sdr["CategoryGoodsID"].ToString();
                        //mdl.CategoryID = sdr["CategoryID"].ToString();
                        //mdl.GoodsID = sdr["GoodsID"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询商品类别(3个级别)
        /// </summary>
        /// <param name="gid">商品ID</param>
        /// <returns></returns>
        public List<Model.Categories_Goods> SelectCategories_GoodsByGoodsID(int gid)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(gid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Categories_Goods_SelectByGoodsID", arr))
                {
                    List<Model.Categories_Goods> lmcg = new List<weipin.Model.Categories_Goods>();
                    while (sdr.Read())
                    {
                        Model.Categories_Goods mdl = new Model.Categories_Goods();
                        mdl.CategoryID = Convert.ToInt32(sdr["CategoryID"].ToString());
                        lmcg.Add(mdl);
                    }
                    return lmcg;
                }
            }
            catch { throw; }
        }
    }
}