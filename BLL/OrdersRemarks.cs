/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-12-26
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using System;
using weipin.Model;

namespace weipin.BLL
{
    public class OrdersRemarks
    {
        public OrdersRemarks()
        { }

        /// <summary>
        /// 添加(从订单备注添加)
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool InsertOrdersRemarks(Model.OrdersRemarks mdl)
        {
            DAL.OrdersRemarks dal = new DAL.OrdersRemarks();
            if (dal.InsertOrdersRemarks(mdl) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加(从订单处编辑按钮添加,有订单ID等属性)
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool InsertOrdersRemarksEdit(Model.OrdersRemarks mdl)
        {
            DAL.OrdersRemarks dal = new DAL.OrdersRemarks();
            if (dal.InsertOrdersRemarksEdit(mdl) > 0)
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
        public bool DeleteOrdersRemarksByID(int id)
        {
            DAL.OrdersRemarks dal = new DAL.OrdersRemarks();
            if (dal.DeleteOrdersRemarksByID(id) > 0)
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
        public bool UpdateOrdersRemarks(Model.OrdersRemarks mdl)
        {
            DAL.OrdersRemarks dal = new DAL.OrdersRemarks();
            if (dal.UpdateOrdersRemarks(mdl) > 0)
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
        public DataTable SelectAllOrdersRemarks()
        {
            DAL.OrdersRemarks dal = new DAL.OrdersRemarks();
            return dal.SelectAllOrdersRemarks();
        }

        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.OrdersRemarks SelectOrdersRemarksByID(int id)
        {
            DAL.OrdersRemarks dal = new DAL.OrdersRemarks();
            return dal.SelectOrdersRemarksByID(id);
        }
        /// <summary>
        /// 查询订单备注列表
        /// </summary>
        /// <param name="_nowpage">当前页</param>
        /// <param name="_perpage">每页条数</param>
        /// <param name="_starttime">开始时间</param>
        /// <param name="_end">结束时间</param>
        /// <returns></returns>
        public DataList<Model.OrdersRemarks> SelectOrdersRemarksOfPaging(int _nowpage, int _perpage, string _starttime, string _endtime)
        {
            string[] _arr = Common.Pagination.CountStartEnd(_nowpage, _perpage);
            DAL.OrdersRemarks dor = new weipin.DAL.OrdersRemarks();
            return dor.SelectOrdersRemarksOfPaging(Convert.ToInt16(_arr[0]), Convert.ToInt16(_arr[1]), _starttime, _endtime);
        }
    }
}