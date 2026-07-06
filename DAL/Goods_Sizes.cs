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

namespace weipin.DAL
{
    public class Goods_Sizes
    {        
        public Goods_Sizes()
        { }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertGoods_Sizes(Model.Goods_Sizes mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.GoodsSizesID);
            //arr.Add(mdl.GoodsID);
            //arr.Add(mdl.SizeID);
            return SqlData.InsDelUpdData("Goods_Sizes_Insert", arr);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteGoods_SizesByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("Goods_Sizes_DeleteByID", arr);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateGoods_Sizes(Model.Goods_Sizes mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.GoodsSizesID);
            //arr.Add(mdl.GoodsID);
            //arr.Add(mdl.SizeID);
            return SqlData.InsDelUpdData("Goods_Sizes_Update", arr);
        }
        
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllGoods_Sizes()
        {
            return SqlData.SelectDataTable("Goods_Sizes_Select", null);
        }
        
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Goods_Sizes SelectGoods_SizesByID(int id)
        {
            try
            {
                Model.Goods_Sizes mdl = new Model.Goods_Sizes();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_Sizes_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        //mdl.GoodsSizesID = sdr["GoodsSizesID"].ToString();
                        //mdl.GoodsID = sdr["GoodsID"].ToString();
                        //mdl.SizeID = sdr["SizeID"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
    }
}