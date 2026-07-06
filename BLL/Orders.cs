/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-10
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using System.Collections.Generic;
using weipin.Model;
using System;

namespace weipin.BLL
{
    public class Orders
    {
        public Orders()
        { }
        /// <summary>
        /// 查询我的订单
        /// </summary>
        /// <param name="logdinid">登录名</param>
        /// <param name="oid">OrderID</param>
        /// <returns></returns>
        public Model.Orders SelectMyOrdersByID(string logdinid, int oid)
        {
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.SelectMyOrdersByID(logdinid, oid);
        }
        /// <summary>
        /// 查询订单及订单商品
        /// </summary>
        /// <param name="id">OrderID</param>
        /// <returns></returns>
        public DataSet SelectOrdersByID(int id)
        {
            DAL.Orders dos = new DAL.Orders();
            return dos.SelectOrdersByID(id);
        }
        /// <summary>
        /// 查询订单列表
        /// </summary>
        /// <param name="_top">查询订单数量</param>
        /// <param name="_aid">AreaID</param>
        /// <param name="_deliveryperiod">送货时间(1:只工作日送货(双休日、假日不用送);2:工作日、双休日与假日均可送货;3:只双休日、假日送货(工作日不用送)</param>
        /// <returns></returns>
        public DataList<Model.Orders> SelectOrdersOfTop(int top, int aid, byte deliveryperiod)
        {
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.SelectOrdersOfTop(top, aid, deliveryperiod);
        }
        /// <summary>
        /// 查询换货列表
        /// </summary>
        /// <param name="_top">查询订单数量</param>
        /// <param name="_aid">AreaID</param>
        /// <param name="_deliveryperiod">送货时间(1:只工作日送货(双休日、假日不用送);2:工作日、双休日与假日均可送货;3:只双休日、假日送货(工作日不用送)</param>
        /// <returns></returns>
        public DataList<Model.Orders> SelectOrdersChangeGoodsOfTop(int top, int aid, byte deliveryperiod)
        {
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.SelectOrdersChangeGoodsOfTop(top, aid, deliveryperiod);
        }
        /// <summary>
        /// 查询出库列表
        /// </summary>
        /// <param name="_top">查询订单数量</param>
        /// <param name="_aid">AreaID</param>
        /// <param name="_deliveryperiod">送货时间(1:只工作日送货(双休日、假日不用送);2:工作日、双休日与假日均可送货;3:只双休日、假日送货(工作日不用送)</param>
        /// <param name="_courierid">快递员ID</param>
        /// <returns></returns>
        public DataList<Model.Orders> SelectOrdersOutLibraryOfTop(int top, int aid, byte deliveryperiod, string courierid)
        {
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.SelectOrdersOutLibraryOfTop(top, aid, deliveryperiod, courierid);
        }
        /// <summary>
        /// 查询退货列表
        /// </summary>
        /// <param name="top">查询订单数量</param>
        /// <param name="aid">AreaID</param>
        /// <param name="deliveryperiod">送货时间(1:只工作日送货(双休日、假日不用送);2:工作日、双休日与假日均可送货;3:只双休日、假日送货(工作日不用送)</param>
        /// <returns></returns>
        public DataList<Model.Orders> SelectOrdersReturnGoodsOfTop(int top, int aid, byte deliveryperiod)
        {
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.SelectOrdersReturnGoodsOfTop(top, aid, deliveryperiod);
        }
        /// <summary>
        /// 查询我的订单列表
        /// </summary>
        /// <param name="loginid">用户名ID</param>
        /// <param name="nowpage">当前页</param>
        /// <param name="perpage">每页条数</param>
        /// <returns></returns>
        public DataList<Model.Orders> SelectMyOrdersByLoginIDOfPaging(string loginid, int nowpage, int perpage)
        {
            string[] _arr = Common.Pagination.CountStartEnd(nowpage, perpage);
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.SelectMyOrdersByLoginIDOfPaging(loginid, _arr[0].ToString(), _arr[1].ToString());
        }
        /// <summary>
        /// 查询我的退换货列表
        /// </summary>
        /// <param name="loginid">用户名ID</param>
        /// <param name="nowpage">当前页</param>
        /// <param name="perpage">每页条数</param>
        /// <returns></returns>
        public DataList<Model.Orders> SelectMyReturnOrdersListByLoginIDOfPaging(string loginid, int nowpage, int perpage)
        {
            string[] _arr = Common.Pagination.CountStartEnd(nowpage, perpage);
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.SelectMyReturnOrdersListByLoginIDOfPaging(loginid, _arr[0].ToString(), _arr[1].ToString());
        }
        /// <summary>
        /// 查询后台订单管理的数量统计
        /// </summary>
        /// <param name="orderstatus">订单状态(1:订货;2:出库(取货);3:换货;4:退货;5:退货完成;6:交易成功)</param>
        /// <returns></returns>
        public List<Model.Orders> SelectOrdersCountStatisticsByOrdersStatus(byte ordersstatus)
        {
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.SelectOrdersCountStatisticsByOrdersStatus(ordersstatus);
        }
        /// <summary>
        /// 查询订单详情(用于支付宝付款,包含订单总金额)
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="oid">订单号</param>
        /// <returns></returns>
        public Model.Orders SelectOrdersDetailByID(string loginid, int oid)
        {
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.SelectOrdersDetailByID(loginid, oid);
        }
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="mdl">订单表数据</param>
        /// <param name="sql">添加订单下商品的SQL拼接</param>
        /// <param name="discountprice">优惠总额</param>
        /// <returns></returns>
        public int InsertOrders(Model.Orders mdl, string sql, double discountprice)
        {
            DAL.Orders dal = new DAL.Orders();
            return dal.InsertOrders(mdl, sql, discountprice);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteOrdersByID(int id)
        {
            DAL.Orders dal = new DAL.Orders();
            if (dal.DeleteOrdersByID(id) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="oid">订单号</param>
        /// <param name="loginid">LoginID</param>
        /// <returns></returns>
        public int UpdateOrdersIsCancelByID(int oid, string loginid)
        {
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.UpdateOrdersIsCancelByID(oid, loginid);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool UpdateOrders(Model.Orders mdl)
        {
            DAL.Orders dal = new DAL.Orders();
            if (dal.UpdateOrders(mdl) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 修改订单交易状态(出库)
        /// </summary>
        /// <param name="mo"></param>
        /// <param name="sql">更新商品库存的SQL</param>
        /// <returns></returns>
        public int UpdateOrdersOutLibraryByOrderID(Model.Orders mo, string sql)
        {
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.UpdateOrdersOutLibraryByOrderID(mo, sql);
        }
        /// <summary>
        /// 修改订单及商品交易状态(出库)
        /// </summary>
        /// <param name="mo"></param>
        /// <param name="sql">更新商品交易状态和库存的SQL</param>
        /// <returns></returns>
        public int UpdateOrdersAndGoodsOutLibraryByOrderID(Model.Orders mo, string sql)
        {
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.UpdateOrdersAndGoodsOutLibraryByOrderID(mo, sql);
        }
        /// <summary>
        /// 修改订单及商品交易状态(取货)
        /// </summary>
        /// <param name="mo"></param>
        /// <returns></returns>
        public int UpdateOrdersAndGoodsExtractGoodsByOrderID(Model.Orders mo)
        {
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.UpdateOrdersAndGoodsExtractGoodsByOrderID(mo);
        }
        /// <summary>
        /// 修改订单及商品的交易状态
        /// </summary>
        /// <param name="orderstatus">要更新的订单状态</param>
        /// <param name="orderid">订单ID</param>
        /// <param name="addday">计算订单预计送达时间所要在订单提交时间增加的天数</param>
        /// <param name="sql">构造的更新订单商品交易状态和商品库存</param>
        /// <returns></returns>
        public int UpdateOrdersAndGoodsByID(int orderid, byte orderstatus, byte addday, string sql)
        {
            DAL.Orders dos = new weipin.DAL.Orders();
            return dos.UpdateOrdersAndGoodsByID(orderid, orderstatus, addday, sql);
        }
        /// <summary>
        /// 修改订单付款状态
        /// </summary>
        /// <param name="oid">订单号</param>
        /// <returns></returns>
        public bool UpdateOrdersPayStatusByID(int oid)
        {
            DAL.Orders dos = new weipin.DAL.Orders();
            if (dos.UpdateOrdersPayStatusByID(oid) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllOrders()
        {
            DAL.Orders dal = new DAL.Orders();
            return dal.SelectAllOrders();
        }
        /// <summary>
        /// 计算预计送达时间
        /// </summary>
        /// <param name="deliveryperiod"></param>
        /// <returns></returns>
        public byte CountDeliveryTimePlan(byte deliveryperiod)
        {
            byte _result = 0;
            byte _day = Convert.ToByte(DateTime.Today.DayOfWeek);
            if (deliveryperiod == 1)
            {
                //只工作日送货(双休日、假日不用送)
                if (_day == 5) { _result = 3; } else if (_day == 6) { _result = 2; } else { _result = 1; }
            }
            else if (deliveryperiod == 2)
            {
                //工作日、双休日与假日均可送货
                _result = 1;
            }
            else
            {
                //只双休日、假日送货(工作日不用送)
                if (_day != 5 && _day != 6) { _result = Convert.ToByte(7 - Convert.ToByte(_day) - 1); }
                else { _result = 1; }
            }
            return _result;
        }
    }
}