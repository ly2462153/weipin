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
using weipin.Model;

namespace weipin.DAL
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
        public Model.Orders SelectMyOrdersByID(string loginid, int oid)
        {
            try
            {
                Model.Orders mdl = new Model.Orders();
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                arr.Add(oid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Orders_SelectMyByID", arr))
                {
                    while (sdr.Read())
                    {
                        mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                        mdl.LoginID = sdr["LoginID"].ToString();
                        mdl.AreaID = Convert.ToInt32(sdr["AreaID"].ToString());
                        mdl.ConsigneeName = sdr["ConsigneeName"].ToString();
                        mdl.ShippingAddress = sdr["ShippingAddress"].ToString();
                        mdl.MobilePhone = sdr["MobilePhone"].ToString();
                        mdl.Telephone = sdr["Telephone"].ToString();
                        mdl.Email = sdr["Email"].ToString();
                        mdl.Zipcode = sdr["Zipcode"].ToString();
                        mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString()); ;
                        mdl.DeliveryPeriod = Convert.ToByte(sdr["DeliveryPeriod"].ToString());
                        mdl.OrdersStatus = Convert.ToByte(sdr["OrdersStatus"].ToString());
                        mdl.LogisticsStatus = Convert.ToByte(sdr["LogisticsStatus"].ToString());
                        mdl.IsCancel = Convert.ToBoolean(sdr["IsCancel"].ToString());
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllOrders()
        {
            return SqlData.SelectDataTable("Orders_Select", null);
        }
        /// <summary>
        /// 查询订单及订单商品
        /// </summary>
        /// <param name="id">OrderID</param>
        /// <returns></returns>
        public DataSet SelectOrdersByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.SelectDataSet("Orders_SelectByID", arr);
        }
        /// <summary>
        /// 查询订单列表
        /// </summary>
        /// <param name="_top">查询订单数量</param>
        /// <param name="_aid">AreaID</param>
        /// <param name="_deliveryperiod">送货时间(1:只工作日送货(双休日、假日不用送);2:工作日、双休日与假日均可送货;3:只双休日、假日送货(工作日不用送)</param>
        /// <returns></returns>
        public DataList<Model.Orders> SelectOrdersOfTop(int _top, int _aid, byte _deliveryperiod)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(_top);
                arr.Add(_aid);
                arr.Add(_deliveryperiod);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Orders_SelectOfTop", arr))
                {
                    DataList<Model.Orders> dmo = new DataList<weipin.Model.Orders>();
                    int _maxorderid = 0;
                    int _singleorder = 1;//1:只有一条订单(一条订单可存在多个商品);0:多条订单
                    while (sdr.Read())
                    {
                        if (dmo.Total == 0)
                        {
                            dmo.Total = Convert.ToInt32(sdr["OrderID"].ToString());
                            if (sdr["LoginID"].ToString() != "") { _maxorderid = Convert.ToInt32(sdr["LoginID"].ToString()); }
                        }
                        else
                        {
                            if (_maxorderid == Convert.ToInt32(sdr["OrderID"].ToString()) && _singleorder == 1)
                            {
                                Model.Orders mdl = new Model.Orders();
                                mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                                mdl.LoginID = sdr["LoginID"].ToString();
                                mdl.OrdersGoodsID = Convert.ToInt32(sdr["OrdersGoodsID"].ToString());
                                mdl.ConsigneeName = sdr["ConsigneeName"].ToString();
                                mdl.ShippingAddress = sdr["ShippingAddress"].ToString();
                                mdl.MobilePhone = sdr["MobilePhone"].ToString();
                                mdl.Telephone = sdr["Telephone"].ToString();
                                mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                                mdl.DeliveryTimePlan = Convert.ToDateTime(sdr["DeliveryTimePlan"].ToString());
                                mdl.SizeName = sdr["SizeName"].ToString();
                                mdl.GoodsCount = Convert.ToInt16(sdr["GoodsCount"].ToString());
                                mdl.GoodsStatus = Convert.ToByte(sdr["GoodsStatus"].ToString());
                                mdl.TransactionPrice = Convert.ToDouble(sdr["TransactionPrice"].ToString());
                                mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                                mdl.GoodsName = sdr["GoodsName"].ToString();
                                if (sdr["GoodsWeight"].ToString() != "") { mdl.GoodsWeight = Convert.ToDouble(sdr["GoodsWeight"].ToString()); }
                                mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                                mdl.Remarks = sdr["Remarks"].ToString();
                                dmo.Rows.Add(mdl);
                            }
                            if (_maxorderid != Convert.ToInt32(sdr["OrderID"].ToString()))
                            {
                                Model.Orders mdl = new Model.Orders();
                                mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                                mdl.LoginID = sdr["LoginID"].ToString();
                                mdl.OrdersGoodsID = Convert.ToInt32(sdr["OrdersGoodsID"].ToString());
                                mdl.ConsigneeName = sdr["ConsigneeName"].ToString();
                                mdl.ShippingAddress = sdr["ShippingAddress"].ToString();
                                mdl.MobilePhone = sdr["MobilePhone"].ToString();
                                mdl.Telephone = sdr["Telephone"].ToString();
                                mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                                mdl.DeliveryTimePlan = Convert.ToDateTime(sdr["DeliveryTimePlan"].ToString());
                                mdl.SizeName = sdr["SizeName"].ToString();
                                mdl.GoodsCount = Convert.ToInt16(sdr["GoodsCount"].ToString());
                                mdl.GoodsStatus = Convert.ToByte(sdr["GoodsStatus"].ToString());
                                mdl.TransactionPrice = Convert.ToDouble(sdr["TransactionPrice"].ToString());
                                mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                                mdl.GoodsName = sdr["GoodsName"].ToString();
                                if (sdr["GoodsWeight"].ToString() != "") { mdl.GoodsWeight = Convert.ToDouble(sdr["GoodsWeight"].ToString()); }
                                mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                                mdl.Remarks = sdr["Remarks"].ToString();
                                dmo.Rows.Add(mdl);
                                //多条订单
                                _singleorder = 0;
                            }
                        }
                    }
                    return dmo;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询换货列表
        /// </summary>
        /// <param name="_top">查询订单数量</param>
        /// <param name="_aid">AreaID</param>
        /// <param name="_deliveryperiod">送货时间(1:只工作日送货(双休日、假日不用送);2:工作日、双休日与假日均可送货;3:只双休日、假日送货(工作日不用送)</param>
        /// <returns></returns>
        public DataList<Model.Orders> SelectOrdersChangeGoodsOfTop(int _top, int _aid, byte _deliveryperiod)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(_top);
                arr.Add(_aid);
                arr.Add(_deliveryperiod);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Orders_SelectChangeGoodsOfTop", arr))
                {
                    DataList<Model.Orders> dmo = new DataList<weipin.Model.Orders>();
                    int _maxorderid = 0;
                    int _singleorder = 1;
                    while (sdr.Read())
                    {
                        if (dmo.Total == 0)
                        {
                            dmo.Total = Convert.ToInt32(sdr["OrderID"].ToString());
                            if (sdr["LoginID"].ToString() != "") { _maxorderid = Convert.ToInt32(sdr["LoginID"].ToString()); }
                        }
                        else
                        {
                            if (_maxorderid == Convert.ToInt32(sdr["OrderID"].ToString()) && _singleorder == 1)
                            {
                                Model.Orders mdl = new Model.Orders();
                                mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                                mdl.LoginID = sdr["LoginID"].ToString();
                                mdl.OrdersGoodsID = Convert.ToInt32(sdr["OrdersGoodsID"].ToString());
                                mdl.ConsigneeName = sdr["ConsigneeName"].ToString();
                                mdl.ShippingAddress = sdr["ShippingAddress"].ToString();
                                mdl.MobilePhone = sdr["MobilePhone"].ToString();
                                mdl.Telephone = sdr["Telephone"].ToString();
                                mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                                mdl.DeliveryTimePlan = Convert.ToDateTime(sdr["DeliveryTimePlan"].ToString());
                                mdl.ExchangeReturnReasons = sdr["ExchangeReturnReasons"].ToString();
                                mdl.SizeName = sdr["SizeName"].ToString();
                                mdl.GoodsCount = Convert.ToInt16(sdr["GoodsCount"].ToString());
                                mdl.GoodsStatus = Convert.ToByte(sdr["GoodsStatus"].ToString());
                                mdl.TransactionPrice = Convert.ToDouble(sdr["TransactionPrice"].ToString());
                                mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                                mdl.GoodsName = sdr["GoodsName"].ToString();
                                if (sdr["GoodsWeight"].ToString() != "") { mdl.GoodsWeight = Convert.ToDouble(sdr["GoodsWeight"].ToString()); }
                                mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                                dmo.Rows.Add(mdl);
                            }
                            if (_maxorderid != Convert.ToInt32(sdr["OrderID"].ToString()))
                            {
                                Model.Orders mdl = new Model.Orders();
                                mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                                mdl.LoginID = sdr["LoginID"].ToString();
                                mdl.OrdersGoodsID = Convert.ToInt32(sdr["OrdersGoodsID"].ToString());
                                mdl.ConsigneeName = sdr["ConsigneeName"].ToString();
                                mdl.ShippingAddress = sdr["ShippingAddress"].ToString();
                                mdl.MobilePhone = sdr["MobilePhone"].ToString();
                                mdl.Telephone = sdr["Telephone"].ToString();
                                mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                                mdl.DeliveryTimePlan = Convert.ToDateTime(sdr["DeliveryTimePlan"].ToString());
                                mdl.ExchangeReturnReasons = sdr["ExchangeReturnReasons"].ToString();
                                mdl.SizeName = sdr["SizeName"].ToString();
                                mdl.GoodsCount = Convert.ToInt16(sdr["GoodsCount"].ToString());
                                mdl.GoodsStatus = Convert.ToByte(sdr["GoodsStatus"].ToString());
                                mdl.TransactionPrice = Convert.ToDouble(sdr["TransactionPrice"].ToString());
                                mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                                mdl.GoodsName = sdr["GoodsName"].ToString();
                                if (sdr["GoodsWeight"].ToString() != "") { mdl.GoodsWeight = Convert.ToDouble(sdr["GoodsWeight"].ToString()); }
                                mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                                dmo.Rows.Add(mdl);
                                _singleorder = 0;
                            }
                        }
                    }
                    return dmo;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询出库列表
        /// </summary>
        /// <param name="_top">查询订单数量</param>
        /// <param name="_aid">AreaID</param>
        /// <param name="_deliveryperiod">送货时间(1:只工作日送货(双休日、假日不用送);2:工作日、双休日与假日均可送货;3:只双休日、假日送货(工作日不用送)</param>
        /// <param name="_courierID">快递员ID</param>
        /// <returns></returns>
        public DataList<Model.Orders> SelectOrdersOutLibraryOfTop(int _top, int _aid, byte _deliveryperiod, string _courierid)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(_top);
                arr.Add(_aid);
                arr.Add(_deliveryperiod);
                arr.Add(_courierid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Orders_SelectOutLibraryOfTop", arr))
                {
                    DataList<Model.Orders> dmo = new DataList<weipin.Model.Orders>();
                    int _maxorderid = 0;
                    int _singleorder = 1;
                    while (sdr.Read())
                    {
                        if (dmo.Total == 0)
                        {
                            dmo.Total = Convert.ToInt32(sdr["OrderID"].ToString());
                            if (sdr["LoginID"].ToString() != "") { _maxorderid = Convert.ToInt32(sdr["LoginID"].ToString()); }
                        }
                        else
                        {
                            if (_maxorderid == Convert.ToInt32(sdr["OrderID"].ToString()) && _singleorder == 1)
                            {
                                Model.Orders mdl = new Model.Orders();
                                mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                                mdl.LoginID = sdr["LoginID"].ToString();
                                mdl.OrdersGoodsID = Convert.ToInt32(sdr["OrdersGoodsID"].ToString());
                                mdl.SizeName = sdr["SizeName"].ToString();
                                mdl.GoodsCount = Convert.ToInt16(sdr["GoodsCount"].ToString());
                                mdl.GoodsStatus = Convert.ToByte(sdr["GoodsStatus"].ToString());
                                mdl.TransactionPrice = Convert.ToDouble(sdr["TransactionPrice"].ToString());
                                mdl.CompleteCount = Convert.ToInt32(sdr["CompleteCount"].ToString());
                                mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                                mdl.GoodsName = sdr["GoodsName"].ToString();
                                mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                                mdl.CourierID = Convert.ToInt32(sdr["CourierID"].ToString());
                                mdl.CourierName = sdr["CourierName"].ToString();
                                mdl.Remarks = sdr["Remarks"].ToString();
                                dmo.Rows.Add(mdl);
                            }
                            if (_maxorderid != Convert.ToInt32(sdr["OrderID"].ToString()))
                            {
                                Model.Orders mdl = new Model.Orders();
                                mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                                mdl.LoginID = sdr["LoginID"].ToString();
                                mdl.OrdersGoodsID = Convert.ToInt32(sdr["OrdersGoodsID"].ToString());
                                mdl.SizeName = sdr["SizeName"].ToString();
                                mdl.GoodsCount = Convert.ToInt16(sdr["GoodsCount"].ToString());
                                mdl.GoodsStatus = Convert.ToByte(sdr["GoodsStatus"].ToString());
                                mdl.TransactionPrice = Convert.ToDouble(sdr["TransactionPrice"].ToString());
                                mdl.CompleteCount = Convert.ToInt32(sdr["CompleteCount"].ToString());
                                mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                                mdl.GoodsName = sdr["GoodsName"].ToString();
                                mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                                mdl.CourierID = Convert.ToInt32(sdr["CourierID"].ToString());
                                mdl.CourierName = sdr["CourierName"].ToString();
                                mdl.Remarks = sdr["Remarks"].ToString();
                                dmo.Rows.Add(mdl);
                                _singleorder = 0;
                            }
                        }
                    }
                    return dmo;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询退货列表
        /// </summary>
        /// <param name="_top">查询订单数量</param>
        /// <param name="_aid">AreaID</param>
        /// <param name="_deliveryperiod">送货时间(1:只工作日送货(双休日、假日不用送);2:工作日、双休日与假日均可送货;3:只双休日、假日送货(工作日不用送)</param>
        /// <returns></returns>
        public DataList<Model.Orders> SelectOrdersReturnGoodsOfTop(int _top, int _aid, byte _deliveryperiod)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(_top);
                arr.Add(_aid);
                arr.Add(_deliveryperiod);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Orders_SelectReturnGoodsOfTop", arr))
                {
                    DataList<Model.Orders> dmo = new DataList<weipin.Model.Orders>();
                    int _maxorderid = 0;
                    int _singleorder = 1;
                    while (sdr.Read())
                    {
                        if (dmo.Total == 0)
                        {
                            dmo.Total = Convert.ToInt32(sdr["OrderID"].ToString());
                            if (sdr["LoginID"].ToString() != "") { _maxorderid = Convert.ToInt32(sdr["LoginID"].ToString()); }
                        }
                        else
                        {
                            if (_maxorderid == Convert.ToInt32(sdr["OrderID"].ToString()) && _singleorder == 1)
                            {
                                Model.Orders mdl = new Model.Orders();
                                mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                                mdl.LoginID = sdr["LoginID"].ToString();
                                mdl.OrdersGoodsID = Convert.ToInt32(sdr["OrdersGoodsID"].ToString());
                                mdl.ConsigneeName = sdr["ConsigneeName"].ToString();
                                mdl.ShippingAddress = sdr["ShippingAddress"].ToString();
                                mdl.MobilePhone = sdr["MobilePhone"].ToString();
                                mdl.Telephone = sdr["Telephone"].ToString();
                                mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                                mdl.DeliveryTimePlan = Convert.ToDateTime(sdr["DeliveryTimePlan"].ToString());
                                mdl.ExchangeReturnReasons = sdr["ExchangeReturnReasons"].ToString();
                                mdl.SizeName = sdr["SizeName"].ToString();
                                mdl.GoodsCount = Convert.ToInt16(sdr["GoodsCount"].ToString());
                                mdl.GoodsStatus = Convert.ToByte(sdr["GoodsStatus"].ToString());
                                mdl.TransactionPrice = Convert.ToDouble(sdr["TransactionPrice"].ToString());
                                mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                                mdl.GoodsName = sdr["GoodsName"].ToString();
                                if (sdr["GoodsWeight"].ToString() != "") { mdl.GoodsWeight = Convert.ToDouble(sdr["GoodsWeight"].ToString()); }
                                mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                                dmo.Rows.Add(mdl);
                            }
                            if (_maxorderid != Convert.ToInt32(sdr["OrderID"].ToString()))
                            {
                                Model.Orders mdl = new Model.Orders();
                                mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                                mdl.LoginID = sdr["LoginID"].ToString();
                                mdl.OrdersGoodsID = Convert.ToInt32(sdr["OrdersGoodsID"].ToString());
                                mdl.ConsigneeName = sdr["ConsigneeName"].ToString();
                                mdl.ShippingAddress = sdr["ShippingAddress"].ToString();
                                mdl.MobilePhone = sdr["MobilePhone"].ToString();
                                mdl.Telephone = sdr["Telephone"].ToString();
                                mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                                mdl.DeliveryTimePlan = Convert.ToDateTime(sdr["DeliveryTimePlan"].ToString());
                                mdl.ExchangeReturnReasons = sdr["ExchangeReturnReasons"].ToString();
                                mdl.SizeName = sdr["SizeName"].ToString();
                                mdl.GoodsCount = Convert.ToInt16(sdr["GoodsCount"].ToString());
                                mdl.GoodsStatus = Convert.ToByte(sdr["GoodsStatus"].ToString());
                                mdl.TransactionPrice = Convert.ToDouble(sdr["TransactionPrice"].ToString());
                                mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                                mdl.GoodsName = sdr["GoodsName"].ToString();
                                if (sdr["GoodsWeight"].ToString() != "") { mdl.GoodsWeight = Convert.ToDouble(sdr["GoodsWeight"].ToString()); }
                                mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                                dmo.Rows.Add(mdl);
                                _singleorder = 0;
                            }
                        }
                    }
                    return dmo;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询我的订单列表
        /// </summary>
        /// <param name="loginid">用户名ID</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataList<Model.Orders> SelectMyOrdersByLoginIDOfPaging(string loginid, string start, string end)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                arr.Add(start);
                arr.Add(end);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Orders_SelectMyByLoginIDOfPaging", arr))
                {
                    DataList<Model.Orders> dmo = new DataList<weipin.Model.Orders>();
                    while (sdr.Read())
                    {
                        if (dmo.Total == 0) { dmo.Total = Convert.ToInt32(sdr["OrderID"].ToString()); }
                        else
                        {
                            Model.Orders mdl = new Model.Orders();
                            mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                            mdl.AreaID = Convert.ToInt32(sdr["AreaID"].ToString());
                            mdl.ConsigneeName = sdr["ConsigneeName"].ToString();
                            mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                            if (sdr["DeliveryTime"].ToString() != "") { mdl.DeliveryTime = Convert.ToDateTime(sdr["DeliveryTime"].ToString()); }
                            mdl.OrdersStatus = Convert.ToByte(sdr["OrdersStatus"].ToString());
                            mdl.LogisticsTimes = Convert.ToByte(sdr["LogisticsTimes"].ToString());
                            mdl.PayWay = Convert.ToByte(sdr["PayWay"].ToString());
                            mdl.IsPay = Convert.ToBoolean(sdr["IsPay"].ToString());
                            mdl.IsCancel = Convert.ToBoolean(sdr["IsCancel"].ToString());
                            mdl.IsCommented = Convert.ToBoolean(sdr["IsCommented"].ToString());
                            mdl.CompleteAmount = Convert.ToDouble(sdr["CompleteAmount"].ToString());
                            mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                            dmo.Rows.Add(mdl);
                        }
                    }
                    return dmo;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询我的订单列表
        /// </summary>
        /// <param name="loginid">用户名ID</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataList<Model.Orders> SelectMyReturnOrdersListByLoginIDOfPaging(string loginid, string start, string end)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                arr.Add(start);
                arr.Add(end);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Orders_SelectMyReturnByLoginIDOfPaging", arr))
                {
                    DataList<Model.Orders> dmo = new DataList<weipin.Model.Orders>();
                    while (sdr.Read())
                    {
                        if (dmo.Total == 0) { dmo.Total = Convert.ToInt32(sdr["OrderID"].ToString()); }
                        else
                        {
                            Model.Orders mdl = new Model.Orders();
                            mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                            mdl.ConsigneeName = sdr["ConsigneeName"].ToString();
                            mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                            if (sdr["DeliveryTime"].ToString() != "") { mdl.DeliveryTime = Convert.ToDateTime(sdr["DeliveryTime"].ToString()); }
                            mdl.OrdersStatus = Convert.ToByte(sdr["OrdersStatus"].ToString());
                            mdl.LogisticsTimes = Convert.ToByte(sdr["LogisticsTimes"].ToString());
                            mdl.IsCancel = Convert.ToBoolean(sdr["IsCancel"].ToString());
                            mdl.IsCommented = Convert.ToBoolean(sdr["IsCommented"].ToString());
                            mdl.CompleteAmount = Convert.ToDouble(sdr["CompleteAmount"].ToString());
                            mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                            dmo.Rows.Add(mdl);
                        }
                    }
                    return dmo;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询后台订单管理的数量统计
        /// </summary>
        /// <param name="orderstatus">订单状态(1:订货;2:出库(取货);3:换货;4:退货;5:退货完成;6:交易成功)</param>
        /// <returns></returns>
        public List<Model.Orders> SelectOrdersCountStatisticsByOrdersStatus(byte ordersstatus)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(ordersstatus);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Orders_SelectCountStatisticsByOrdersStatus", arr))
                {
                    List<Model.Orders> lmo = new List<weipin.Model.Orders>();
                    while (sdr.Read())
                    {
                        Model.Orders mdl = new Model.Orders();
                        mdl.AreaID = Convert.ToInt32(sdr["AreaID"].ToString());
                        mdl.AreaName = sdr["AreaName"].ToString();
                        mdl.DeliveryPeriod = Convert.ToByte(sdr["DeliveryPeriod"].ToString());
                        mdl.OrdersCount = Convert.ToInt32(sdr["OrdersCount"].ToString());
                        lmo.Add(mdl);
                    }
                    return lmo;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询订单详情(用于支付宝付款,包含订单总金额)
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="oid">订单号</param>
        /// <returns></returns>
        public Model.Orders SelectOrdersDetailByID(string loginid, int oid)
        {
            try
            {
                Model.Orders mdl = new Model.Orders();
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                arr.Add(oid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Orders_SelectDetailByID", arr))
                {
                    while (sdr.Read())
                    {
                        mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                        mdl.AreaID = Convert.ToInt32(sdr["AreaID"].ToString());
                        mdl.ConsigneeName = sdr["ConsigneeName"].ToString();
                        mdl.ShippingAddress = sdr["ShippingAddress"].ToString();
                        mdl.OrderAmount = Convert.ToDouble(sdr["OrderAmount"].ToString());
                    }
                    return mdl;
                }
            }
            catch { throw; }
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
            ArrayList arr = new ArrayList();
            arr.Add(mdl.LoginID);
            arr.Add(mdl.AreaID);
            arr.Add(mdl.ConsigneeName);
            arr.Add(mdl.ShippingAddress);
            if (mdl.MobilePhone != "") { arr.Add(mdl.MobilePhone); } else { arr.Add(null); }
            if (mdl.Telephone != "") { arr.Add(mdl.Telephone); } else { arr.Add(null); }
            if (mdl.Zipcode != "") { arr.Add(mdl.Zipcode); } else { arr.Add(null); }
            arr.Add(mdl.DeliveryPeriod);
            if (mdl.Remarks != "") { arr.Add(mdl.Remarks); } else { arr.Add(null); }
            arr.Add(sql);
            arr.Add(discountprice);
            arr.Add(mdl.PayWay);
            arr.Add(mdl.IsPay);
            return SqlData.InsDelUpdDataReturnOneValue("Orders_Insert", arr);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteOrdersByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("Orders_DeleteByID", arr);
        }
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="oid">订单号</param>
        /// <param name="loginid">LoginID</param>
        /// <returns></returns>
        public int UpdateOrdersIsCancelByID(int oid, string loginid)
        {
            ArrayList arr = new ArrayList();
            arr.Add(oid);
            arr.Add(loginid);
            return SqlData.InsDelUpdData("Orders_UpdateIsCancelByID", arr);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateOrders(Model.Orders mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.OrderID);
            //arr.Add(mdl.LoginID);
            //arr.Add(mdl.CourierID);
            //arr.Add(mdl.AreaID);
            //arr.Add(mdl.ConsigneeName);
            //arr.Add(mdl.ShippingAddress);
            //arr.Add(mdl.MobilePhone);
            //arr.Add(mdl.Email);
            //arr.Add(mdl.Zipcode);
            //arr.Add(mdl.AddTime);
            //arr.Add(mdl.DeliveryTimePlan);
            //arr.Add(mdl.DeliveryTime);
            //arr.Add(mdl.OrdersStatus);
            //arr.Add(mdl.LogisticsStatus);
            //arr.Add(mdl.LogisticsTimes);
            //arr.Add(mdl.ExchangeReturnReasons);
            return SqlData.InsDelUpdData("Orders_Update", arr);
        }
        /// <summary>
        /// 修改订单交易状态(出库)
        /// </summary>
        /// <param name="mo"></param>
        /// <param name="sql">更新商品库存的SQL</param>
        /// <returns></returns>
        public int UpdateOrdersOutLibraryByOrderID(Model.Orders mo, string sql)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mo.OrderID);
            arr.Add(mo.CourierID);
            arr.Add(sql);
            return SqlData.InsDelUpdDataReturnOneValue("Orders_UpdateOutLibraryByOrderID", arr);
        }
        /// <summary>
        /// 修改订单及商品交易状态(出库)
        /// </summary>
        /// <param name="mo"></param>
        /// <param name="sql">更新商品交易状态和库存的SQL</param>
        /// <returns></returns>
        public int UpdateOrdersAndGoodsOutLibraryByOrderID(Model.Orders mo, string sql)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mo.OrderID);
            arr.Add(mo.CourierID);
            arr.Add(sql);
            return SqlData.InsDelUpdDataReturnOneValue("Orders_UpdateAndGoodsOutLibraryByOrderID", arr);
        }
        /// <summary>
        /// 修改订单及商品交易状态(取货)
        /// </summary>
        /// <param name="mo"></param>
        /// <returns></returns>
        public int UpdateOrdersAndGoodsExtractGoodsByOrderID(Model.Orders mo)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mo.OrderID);
            arr.Add(mo.CourierID);
            return SqlData.InsDelUpdDataReturnOneValue("Orders_UpdateAndGoodsExtractGoodsByOrderID", arr);
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
            ArrayList arr = new ArrayList();
            arr.Add(orderid);
            arr.Add(orderstatus);
            arr.Add(addday);
            arr.Add(sql);
            return SqlData.InsDelUpdDataReturnOneValue("Orders_UpdateAndGoodsByID", arr);
        }
        /// <summary>
        /// 修改订单付款状态
        /// </summary>
        /// <param name="oid">订单号</param>
        /// <returns></returns>
        public int UpdateOrdersPayStatusByID(int oid)
        {
            ArrayList arr = new ArrayList();
            arr.Add(oid);
            return SqlData.InsDelUpdData("Orders_UpdatePayStatusByID", arr);
        }
    }
}