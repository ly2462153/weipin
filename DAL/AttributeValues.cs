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
    public class AttributeValues
    {        
        public AttributeValues()
        { }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertAttributeValues(Model.AttributeValues mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.AttributeID);
            arr.Add(mdl.AttributeValueName);
            return SqlData.InsDelUpdData("AttributeValues_Insert", arr);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteAttributeValuesByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("AttributeValues_DeleteByID", arr);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateAttributeValues(Model.AttributeValues mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.AttributeValueID);
            arr.Add(mdl.AttributeValueName);
            return SqlData.InsDelUpdData("AttributeValues_Update", arr);
        }
        
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllAttributeValues()
        {
            return SqlData.SelectDataTable("AttributeValues_Select", null);
        }
        
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.AttributeValues SelectAttributeValuesByID(int id)
        {
            try
            {
                Model.AttributeValues mdl = new Model.AttributeValues();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("AttributeValues_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        //mdl.AttributeValueID = sdr["AttributeValueID"].ToString();
                        //mdl.AttributeID = sdr["AttributeID"].ToString();
                        //mdl.AttributeValueName = sdr["AttributeValueName"].ToString();
                        //mdl.UpdateTime = sdr["UpdateTime"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        ///// <summary>2012-1-17待删
        ///// 查询属性值
        ///// </summary>
        ///// <param name="_aid">属性ID</param>
        ///// <returns></returns>
        //public List<Model.AttributeValues> SelectAttributeValuesByAttributeID(int _aid)
        //{
        //    try
        //    {
        //        List<Model.AttributeValues> lmav = new List<weipin.Model.AttributeValues>();
        //        ArrayList arr = new ArrayList();
        //        arr.Add(_aid);
        //        using (SqlDataReader sdr = SqlData.SelectDataReader("AttributeValues_SelectByAttributeID", arr))
        //        {
        //            while (sdr.Read())
        //            {
        //                Model.AttributeValues mdl = new Model.AttributeValues();
        //                mdl.AttributeValueID = Convert.ToInt32(sdr["AttributeValueID"].ToString());
        //                mdl.AttributeID = Convert.ToInt32(sdr["AttributeID"].ToString());
        //                mdl.AttributeValueName = sdr["AttributeValueName"].ToString();
        //                lmav.Add(mdl);
        //            }
        //            return lmav;
        //        }
        //    }
        //    catch { throw; }
        //}
    }
}