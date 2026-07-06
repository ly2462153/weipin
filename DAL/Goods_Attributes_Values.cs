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
    public class Goods_Attributes_Values
    {        
        public Goods_Attributes_Values()
        { }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertGoods_Attributes_Values(Model.Goods_Attributes_Values mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.GoodsAttributeValueID);
            //arr.Add(mdl.GoodsID);
            //arr.Add(mdl.AttributeID);
            //arr.Add(mdl.ValueID);
            return SqlData.InsDelUpdData("Goods_Attributes_Values_Insert", arr);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteGoods_Attributes_ValuesByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("Goods_Attributes_Values_DeleteByID", arr);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateGoods_Attributes_Values(Model.Goods_Attributes_Values mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.GoodsAttributeValueID);
            //arr.Add(mdl.GoodsID);
            //arr.Add(mdl.AttributeID);
            //arr.Add(mdl.ValueID);
            return SqlData.InsDelUpdData("Goods_Attributes_Values_Update", arr);
        }
        
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllGoods_Attributes_Values()
        {
            return SqlData.SelectDataTable("Goods_Attributes_Values_Select", null);
        }
        
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Goods_Attributes_Values SelectGoods_Attributes_ValuesByID(int id)
        {
            try
            {
                Model.Goods_Attributes_Values mdl = new Model.Goods_Attributes_Values();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_Attributes_Values_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        //mdl.GoodsAttributeValueID = sdr["GoodsAttributeValueID"].ToString();
                        //mdl.GoodsID = sdr["GoodsID"].ToString();
                        //mdl.AttributeID = sdr["AttributeID"].ToString();
                        //mdl.ValueID = sdr["ValueID"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
    }
}