/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2012-9-21
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using System.Collections.Generic;
using weipin.Model;

namespace weipin.BLL
{
    public class Integral
    {
        public Integral()
        { }
        /// <summary>
        /// 查询我的积分列表
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="nowpage">当前页</param>
        /// <param name="perpage">每页条数</param>
        /// <returns></returns>
        public DataList<Model.Integral> SelectMyGoodsIntegralByLoginIDOfPaging(string loginid, int nowpage, int perpage)
        {
            string[] _arr = Common.Pagination.CountStartEnd(nowpage, perpage);
            DAL.Integral di = new weipin.DAL.Integral();
            return di.SelectMyGoodsIntegralByLoginIDOfPaging(loginid, _arr[0].ToString(), _arr[1].ToString());
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Integral SelectIntegralByID(int id)
        {
            DAL.Integral dal = new DAL.Integral();
            return dal.SelectIntegralByID(id);
        }
        /// <summary>
        /// 查询多条记录
        /// </summary>
        /// <returns></returns>
        public List<Model.Integral> SelectIntegral()
        {
            DAL.Integral dal = new DAL.Integral();
            return dal.SelectIntegral();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllIntegral()
        {
            DAL.Integral dal = new DAL.Integral();
            return dal.SelectAllIntegral();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool InsertIntegral(Model.Integral mdl)
        {
            DAL.Integral dal = new DAL.Integral();
            if (dal.InsertIntegral(mdl) > 0)
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
        public bool DeleteIntegralByID(int id)
        {
            DAL.Integral dal = new DAL.Integral();
            if (dal.DeleteIntegralByID(id) > 0)
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
        public bool UpdateIntegral(Model.Integral mdl)
        {
            DAL.Integral dal = new DAL.Integral();
            if (dal.UpdateIntegral(mdl) > 0)
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