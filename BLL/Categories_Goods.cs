/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-10
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using System.Collections.Generic;

namespace weipin.BLL
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
        public bool InsertCategories_Goods(Model.Categories_Goods mdl)
        {
            DAL.Categories_Goods dal = new DAL.Categories_Goods();
            if (dal.InsertCategories_Goods(mdl) > 0)
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
        public bool DeleteCategories_GoodsByID(int id)
        {
            DAL.Categories_Goods dal = new DAL.Categories_Goods();
            if (dal.DeleteCategories_GoodsByID(id) > 0)
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
        public bool UpdateCategories_Goods(Model.Categories_Goods mdl)
        {
            DAL.Categories_Goods dal = new DAL.Categories_Goods();
            if (dal.UpdateCategories_Goods(mdl) > 0)
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
        public DataTable SelectAllCategories_Goods()
        {
            DAL.Categories_Goods dal = new DAL.Categories_Goods();
            return dal.SelectAllCategories_Goods();
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Categories_Goods SelectCategories_GoodsByID(int id)
        {
            DAL.Categories_Goods dal = new DAL.Categories_Goods();
            return dal.SelectCategories_GoodsByID(id);
        }
        /// <summary>
        /// 查询商品类别(3个级别)
        /// </summary>
        /// <param name="gid">商品ID</param>
        /// <returns></returns>
        public List<Model.Categories_Goods> SelectCategories_GoodsByGoodsID(int gid)
        {
            DAL.Categories_Goods dal = new DAL.Categories_Goods();
            return dal.SelectCategories_GoodsByGoodsID(gid);
        }
    }
}