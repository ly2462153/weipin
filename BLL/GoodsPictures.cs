/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-10
 *
 * 描述: 
**************************************************************************************************/
using System.Data;

namespace weipin.BLL
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
        public bool InsertGoodsPictures(Model.GoodsPictures mdl)
        {
            DAL.GoodsPictures dal = new DAL.GoodsPictures();
            if (dal.InsertGoodsPictures(mdl) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteGoodsPicturesByID(int id)
        {
            DAL.GoodsPictures dal = new DAL.GoodsPictures();
            if (dal.DeleteGoodsPicturesByID(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool UpdateGoodsPictures(Model.GoodsPictures mdl)
        {
            DAL.GoodsPictures dal = new DAL.GoodsPictures();
            if (dal.UpdateGoodsPictures(mdl) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllGoodsPictures()
        {
            DAL.GoodsPictures dal = new DAL.GoodsPictures();
            return dal.SelectAllGoodsPictures();
        }
        
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.GoodsPictures SelectGoodsPicturesByID(int id)
        {
            DAL.GoodsPictures dal = new DAL.GoodsPictures();
            return dal.SelectGoodsPicturesByID(id);
        }
    }
}