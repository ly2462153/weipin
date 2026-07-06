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
    public class Goods_Sizes
    {
        public Goods_Sizes()
        { }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool InsertGoods_Sizes(Model.Goods_Sizes mdl)
        {
            DAL.Goods_Sizes dal = new DAL.Goods_Sizes();
            if (dal.InsertGoods_Sizes(mdl) > 0)
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
        public bool DeleteGoods_SizesByID(int id)
        {
            DAL.Goods_Sizes dal = new DAL.Goods_Sizes();
            if (dal.DeleteGoods_SizesByID(id) > 0)
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
        public bool UpdateGoods_Sizes(Model.Goods_Sizes mdl)
        {
            DAL.Goods_Sizes dal = new DAL.Goods_Sizes();
            if (dal.UpdateGoods_Sizes(mdl) > 0)
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
        public DataTable SelectAllGoods_Sizes()
        {
            DAL.Goods_Sizes dal = new DAL.Goods_Sizes();
            return dal.SelectAllGoods_Sizes();
        }
        
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Goods_Sizes SelectGoods_SizesByID(int id)
        {
            DAL.Goods_Sizes dal = new DAL.Goods_Sizes();
            return dal.SelectGoods_SizesByID(id);
        }
    }
}