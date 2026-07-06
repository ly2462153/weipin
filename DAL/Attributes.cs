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
    public class Attributes
    {
        public Attributes()
        { }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertAttributes(Model.Attributes mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.CategoryID);
            arr.Add(mdl.AttributeName);
            return SqlData.InsDelUpdData("Attributes_Insert", arr);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteAttributesByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("Attributes_DeleteByID", arr);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateAttributes(Model.Attributes mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.AttributeID);
            arr.Add(mdl.AttributeName);
            return SqlData.InsDelUpdData("Attributes_Update", arr);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllAttributes()
        {
            return SqlData.SelectDataTable("Attributes_Select", null);
        }

        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Attributes SelectAttributesByID(int id)
        {
            try
            {
                Model.Attributes mdl = new Model.Attributes();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Attributes_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        //mdl.AttributeID = sdr["AttributeID"].ToString();
                        //mdl.CategoryID = sdr["CategoryID"].ToString();
                        //mdl.AttributeName = sdr["AttributeName"].ToString();
                        //mdl.UpdateTime = sdr["UpdateTime"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        ///// <summary>2012-1-17待删
        ///// 查询分类属性
        ///// </summary>
        ///// <param name="_cid">分类ID</param>
        ///// <returns></returns>
        //public List<Model.Attributes> SelectAttributesByCategoryID(int _cid)
        //{
        //    try
        //    {
        //        List<Model.Attributes> lma = new List<weipin.Model.Attributes>();
        //        ArrayList arr = new ArrayList();
        //        arr.Add(_cid);
        //        using (SqlDataReader sdr = SqlData.SelectDataReader("Attributes_SelectByCategoryID", arr))
        //        {
        //            while (sdr.Read())
        //            {
        //                Model.Attributes mdl = new Model.Attributes();
        //                mdl.AttributeID = Convert.ToInt32(sdr["AttributeID"].ToString());
        //                mdl.CategoryID = Convert.ToInt32(sdr["CategoryID"].ToString());
        //                mdl.AttributeName = sdr["AttributeName"].ToString();
        //                lma.Add(mdl);
        //            }
        //            return lma;
        //        }
        //    }
        //    catch { throw; }
        //}
        /// <summary>
        /// 查询分类属性和属性值
        /// </summary>
        /// <param name="_cid">CategoryID</param>
        /// <returns></returns>
        public List<Model.Attributes> SelectAttributesAndValuesByCategoryID(int _cid)
        {
            try
            {
                List<Model.Attributes> lma = new List<weipin.Model.Attributes>();
                ArrayList arr = new ArrayList();
                arr.Add(_cid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Attributes_SelectAndValuesByCategoryID", arr))
                {
                    while (sdr.Read())
                    {
                        Model.Attributes mdl = new Model.Attributes();
                        mdl.AttributeID = Convert.ToInt32(sdr["AttributeID"].ToString());
                        mdl.CategoryID = Convert.ToInt32(sdr["CategoryID"].ToString());
                        mdl.AttributeName = sdr["AttributeName"].ToString();
                        if (sdr["AttributeValueID"].ToString() != "")
                        {
                            mdl.AttributeValueID = Convert.ToInt32(sdr["AttributeValueID"].ToString());
                        }
                        mdl.AttributeValueName = sdr["AttributeValueName"].ToString();
                        lma.Add(mdl);
                    }
                    return lma;
                }
            }
            catch { throw; }
        }
    }
}