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
    public class GoodsPictures
    {        
        public GoodsPictures()
        { }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertGoodsPictures(Model.GoodsPictures mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.GoodsPictureID);
            //arr.Add(mdl.GoodsID);
            //arr.Add(mdl.PicturePath);
            return SqlData.InsDelUpdData("GoodsPictures_Insert", arr);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteGoodsPicturesByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("GoodsPictures_DeleteByID", arr);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateGoodsPictures(Model.GoodsPictures mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.GoodsPictureID);
            //arr.Add(mdl.GoodsID);
            //arr.Add(mdl.PicturePath);
            return SqlData.InsDelUpdData("GoodsPictures_Update", arr);
        }
        
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllGoodsPictures()
        {
            return SqlData.SelectDataTable("GoodsPictures_Select", null);
        }
        
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.GoodsPictures SelectGoodsPicturesByID(int id)
        {
            try
            {
                Model.GoodsPictures mdl = new Model.GoodsPictures();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("GoodsPictures_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        //mdl.GoodsPictureID = sdr["GoodsPictureID"].ToString();
                        //mdl.GoodsID = sdr["GoodsID"].ToString();
                        //mdl.PicturePath = sdr["PicturePath"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
    }
}