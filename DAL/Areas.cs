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
    public class Areas
    {
        public Areas()
        { }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertAreas(Model.Areas mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.ParentID);
            arr.Add(mdl.AreaName);
            if (mdl.Freight == -1) { arr.Add(null); } else { arr.Add(mdl.Freight); }
            return SqlData.InsDelUpdData("Areas_Insert", arr);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteAreasByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("Areas_DeleteByID", arr);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateAreas(Model.Areas mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.AreaID);
            arr.Add(mdl.AreaName);
            if (mdl.Freight == -1) { arr.Add(null); } else { arr.Add(mdl.Freight); }
            return SqlData.InsDelUpdData("Areas_Update", arr);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Model.Areas> SelectAllAreas()
        {
            try
            {
                List<Model.Areas> lma = new List<weipin.Model.Areas>();
                using (SqlDataReader sdr = SqlData.SelectDataReader("Areas_Select", null))
                {
                    while (sdr.Read())
                    {
                        Model.Areas mdl = new Model.Areas();
                        mdl.AreaID = Convert.ToInt32(sdr["AreaID"].ToString());
                        mdl.ParentID = Convert.ToInt32(sdr["ParentID"].ToString());
                        mdl.AreaName = sdr["AreaName"].ToString();
                        if (sdr["Freight"].ToString() != "") { mdl.Freight = Convert.ToInt16(sdr["Freight"].ToString()); }
                        lma.Add(mdl);
                    }
                    return lma;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Areas SelectAreasByID(int id)
        {
            try
            {
                Model.Areas mdl = new Model.Areas();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Areas_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        //mdl.AreaID = sdr["AreaID"].ToString();
                        //mdl.ParentID = sdr["ParentID"].ToString();
                        //mdl.AreaName = sdr["AreaName"].ToString();
                        //mdl.Freight = sdr["Freight"].ToString();
                        //mdl.UpdateTime = sdr["UpdateTime"].ToString();
                        //mdl.IsDeleted = sdr["IsDeleted"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
    }
}