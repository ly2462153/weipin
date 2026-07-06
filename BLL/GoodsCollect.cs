/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-10
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using weipin.Model;

namespace weipin.BLL
{
    public class GoodsCollect
    {
        public GoodsCollect()
        { }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllGoodsCollect()
        {
            DAL.GoodsCollect dal = new DAL.GoodsCollect();
            return dal.SelectAllGoodsCollect();
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.GoodsCollect SelectGoodsCollectByID(int id)
        {
            DAL.GoodsCollect dal = new DAL.GoodsCollect();
            return dal.SelectGoodsCollectByID(id);
        }
        /// <summary>
        /// 查询我的收藏
        /// </summary>
        /// <param name="loginid">用户名ID</param>
        /// <param name="nowpage">当前页</param>
        /// <param name="perpage">每页条数</param>
        /// <returns></returns>
        public DataList<Model.GoodsCollect> SelectMyGoodsCollectByLoginIDOfPaging(string loginid, int nowpage, int perpage)
        {
            string[] _arr = Common.Pagination.CountStartEnd(nowpage, perpage);
            DAL.GoodsCollect dgc = new weipin.DAL.GoodsCollect();
            return dgc.SelectMyGoodsCollectByLoginIDOfPaging(loginid, _arr[0].ToString(), _arr[1].ToString());
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="loginid">用户名</param>
        /// <param name="gid">商品ID</param>
        /// <returns></returns>
        public int InsertGoodsCollect(string loginid, int gid)
        {
            DAL.GoodsCollect dal = new DAL.GoodsCollect();
            return dal.InsertGoodsCollect(loginid, gid);
        }
        /// <summary>
        /// 删除我的收藏
        /// </summary>
        /// <param name="loginid"></param>
        /// <param name="cid">收藏主键</param>
        /// <returns></returns>
        public int DeleteGoodsCollectByID(string loginid, long cid)
        {
            DAL.GoodsCollect dal = new DAL.GoodsCollect();
            return dal.DeleteGoodsCollectByID(loginid, cid);
        }
        /// <summary>
        /// 删除勾选的收藏
        /// </summary>
        /// <param name="sql">拼接删除收藏的字符串</param>
        /// <returns></returns>
        public int DeleteGoodsCollectAllByID(string sql)
        {
            DAL.GoodsCollect dal = new DAL.GoodsCollect();
            return dal.DeleteGoodsCollectAllByID(sql);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool UpdateGoodsCollect(Model.GoodsCollect mdl)
        {
            DAL.GoodsCollect dal = new DAL.GoodsCollect();
            if (dal.UpdateGoodsCollect(mdl) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}