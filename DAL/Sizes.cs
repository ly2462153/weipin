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
    public class Sizes
    {
        public Sizes()
        { }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertSizes(Model.Sizes mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.SizeName);
            return SqlData.InsDelUpdData("Sizes_Insert", arr);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteSizesByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("Sizes_DeleteByID", arr);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateSizes(Model.Sizes mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.SizeID);
            arr.Add(mdl.SizeName);
            return SqlData.InsDelUpdData("Sizes_Update", arr);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Model.Sizes> SelectAllSizes()
        {
            try
            {
                List<Model.Sizes> lms = new List<weipin.Model.Sizes>();
                using (SqlDataReader sdr = SqlData.SelectDataReader("Sizes_Select", null))
                {
                    while (sdr.Read())
                    {
                        Model.Sizes mdl = new Model.Sizes();
                        mdl.SizeID = Convert.ToInt16(sdr["SizeID"].ToString());
                        mdl.SizeName = sdr["SizeName"].ToString();
                        lms.Add(mdl);
                    }
                    return lms;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Sizes SelectSizesByID(int id)
        {
            try
            {
                Model.Sizes mdl = new Model.Sizes();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Sizes_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        mdl.SizeID = Convert.ToInt16(sdr["SizeID"].ToString());
                        mdl.SizeName = sdr["SizeName"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        /// <returns></returns>
        public DataSet SelectSizesOfPaging(int _start, int _end)
        {
            ArrayList arr = new ArrayList();
            arr.Add(_start);
            arr.Add(_end);
            return SqlData.SelectDataSet("Sizes_SelectOfPaging", arr);
        }
    }
}