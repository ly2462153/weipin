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
    public class Categories
    {        
        public Categories()
        { }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertCategories(Model.Categories mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.ParentID);
            arr.Add(mdl.CategoryName);
            arr.Add(mdl.IsHighlight);
            arr.Add(mdl.Remarks);
            return SqlData.InsDelUpdData("Categories_Insert", arr);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCategoriesByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("Categories_DeleteByID", arr);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateCategories(Model.Categories mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.CategoryID);
            arr.Add(mdl.CategoryName);
            arr.Add(mdl.IsHighlight);
            arr.Add(mdl.Remarks);
            return SqlData.InsDelUpdData("Categories_Update", arr);
        }
        
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Model.Categories> SelectAllCategories()
        {
            try
            {
                using (SqlDataReader sdr = SqlData.SelectDataReader("Categories_Select", null))
                {
                    List<Model.Categories> lmc = new List<weipin.Model.Categories>();
                    while (sdr.Read())
                    {
                        Model.Categories mdl = new Model.Categories();
                        mdl.CategoryID = Convert.ToInt32(sdr["CategoryID"].ToString());
                        mdl.ParentID = Convert.ToInt32(sdr["ParentID"].ToString());
                        mdl.CategoryName = sdr["CategoryName"].ToString();
                        mdl.IsHighlight = Convert.ToBoolean(sdr["IsHighlight"].ToString());
                        mdl.Remarks = sdr["Remarks"].ToString();
                        lmc.Add(mdl);
                    }
                    return lmc;
                }
            }
            catch { throw; }
        }        
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Categories SelectCategoriesByID(int id)
        {
            try
            {
                Model.Categories mdl = new Model.Categories();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Categories_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        //mdl.CategoryID = sdr["CategoryID"].ToString();
                        //mdl.ParentID = sdr["ParentID"].ToString();
                        //mdl.CategoryName = sdr["CategoryName"].ToString();
                        //mdl.UpdateTime = sdr["UpdateTime"].ToString();
                        //mdl.Remarks = sdr["Remarks"].ToString();
                        //mdl.OrderNum = sdr["OrderNum"].ToString();
                        //mdl.IsHighlight = sdr["IsHighlight"].ToString();
                        //mdl.IsDeleted = sdr["IsDeleted"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
    }
}