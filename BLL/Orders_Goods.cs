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
    public class Orders_Goods
    {
        public Orders_Goods()
        { }
        /// <summary>
        /// 查询当前订单下的商品列表
        /// </summary>
        /// <param name="oid">OrderID</param>
        /// <returns></returns>
        public List<Model.Orders_Goods> SelectMyOrders_GoodsByOrderID(int oid)
        {
            DAL.Orders_Goods dog = new weipin.DAL.Orders_Goods();
            return dog.SelectMyOrders_GoodsByOrderID(oid);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllOrders_Goods()
        {
            DAL.Orders_Goods dal = new DAL.Orders_Goods();
            return dal.SelectAllOrders_Goods();
        }
        /// <summary>
        /// 查询订单信息(用于订单备注记录功能)
        /// </summary>
        /// <param name="id">OrdersGoodsID</param>
        /// <returns></returns>
        public Model.Orders_Goods SelectOrders_GoodsByID(int id)
        {
            DAL.Orders_Goods dal = new DAL.Orders_Goods();
            return dal.SelectOrders_GoodsByID(id);
        }
        /// <summary>
        /// 查询我的交易成功的订单商品(退换货办理)
        /// </summary>
        /// <param name="loginid">用户名</param>
        /// <param name="oid">订单ID</param>
        /// <returns></returns>
        public List<Model.Orders_Goods> SelectMySucceeOrdersGoodsByLoginID(string loginid, int oid)
        {
            DAL.Orders_Goods dg = new weipin.DAL.Orders_Goods();
            return dg.SelectMySucceeOrdersGoodsByLoginID(loginid, oid);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool InsertOrders_Goods(Model.Orders_Goods mdl)
        {
            DAL.Orders_Goods dal = new DAL.Orders_Goods();
            if (dal.InsertOrders_Goods(mdl) > 0)
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
        public bool DeleteOrders_GoodsByID(int id)
        {
            DAL.Orders_Goods dal = new DAL.Orders_Goods();
            if (dal.DeleteOrders_GoodsByID(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改订单/商品的状态(退换货办理)
        /// </summary>
        /// <param name="orderid">订单ID</param>
        /// <param name="ordersstatus">订单状态</param>
        /// <param name="loginid">用户名</param>
        /// <param name="sql">修改商品的状态</param>
        /// <param name="reason">退换货理由</param>
        /// <returns></returns>
        public int UpdateOrders_GoodsStatusByLoginID(int orderid, byte ordersstatus, string loginid, string sql, string reason)
        {
            DAL.Orders_Goods dog = new weipin.DAL.Orders_Goods();
            return dog.UpdateOrders_GoodsStatusByLoginID(orderid, ordersstatus, loginid, sql, reason);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool UpdateOrders_Goods(Model.Orders_Goods mdl)
        {
            DAL.Orders_Goods dal = new DAL.Orders_Goods();
            if (dal.UpdateOrders_Goods(mdl) > 0) { return true; }
            else { return false; }
        }
    }
}