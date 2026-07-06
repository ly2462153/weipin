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

namespace weipin.DAL
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
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(oid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Orders_Goods_SelectMyByOrderID", arr))
                {
                    List<Model.Orders_Goods> lmog = new List<weipin.Model.Orders_Goods>();
                    while (sdr.Read())
                    {
                        Model.Orders_Goods mdl = new weipin.Model.Orders_Goods();
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        mdl.SizeName = sdr["SizeName"].ToString();
                        mdl.GoodsCount = Convert.ToInt16(sdr["GoodsCount"].ToString());
                        mdl.TransactionPrice = Convert.ToDouble(sdr["TransactionPrice"].ToString());
                        mdl.CompleteCount = Convert.ToInt16(sdr["CompleteCount"].ToString());
                        lmog.Add(mdl);
                    }
                    return lmog;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllOrders_Goods()
        {
            return SqlData.SelectDataTable("Orders_Goods_Select", null);
        }
        /// <summary>
        /// 查询订单信息(用于订单备注记录功能)
        /// </summary>
        /// <param name="id">OrdersGoodsID</param>
        /// <returns></returns>
        public Model.Orders_Goods SelectOrders_GoodsByID(int id)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Orders_Goods_SelectByID", arr))
                {
                    Model.Orders_Goods mdl = new Model.Orders_Goods();
                    while (sdr.Read())
                    {
                        mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                        mdl.OrdersGoodsID = Convert.ToInt32(sdr["OrdersGoodsID"].ToString());
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        mdl.TransactionPrice = Convert.ToDouble(sdr["TransactionPrice"].ToString());
                        mdl.LoginID = sdr["LoginID"].ToString();
                        if (sdr["CourierID"].ToString() != "")
                        {
                            mdl.CourierID = Convert.ToInt32(sdr["CourierID"].ToString());
                        }
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询我的交易成功的订单商品(退换货办理)
        /// </summary>
        /// <param name="loginid">用户名</param>
        /// <param name="oid">订单ID</param>
        /// <returns></returns>
        public List<Model.Orders_Goods> SelectMySucceeOrdersGoodsByLoginID(string loginid, int oid)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                arr.Add(oid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectMySucceeOrdersByLoginID", arr))
                {
                    List<Model.Orders_Goods> lmg = new List<weipin.Model.Orders_Goods>();
                    while (sdr.Read())
                    {
                        Model.Orders_Goods mdl = new weipin.Model.Orders_Goods();
                        mdl.OrdersGoodsID = Convert.ToInt32(sdr["OrdersGoodsID"].ToString());
                        mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        mdl.GoodsStatus = Convert.ToByte(sdr["GoodsStatus"].ToString());
                        mdl.TransactionPrice = Convert.ToDouble(sdr["TransactionPrice"].ToString());
                        mdl.CompleteCount = Convert.ToInt16(sdr["CompleteCount"].ToString());
                        mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                        lmg.Add(mdl);
                    }
                    return lmg;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertOrders_Goods(Model.Orders_Goods mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.OrdersGoodsID);
            //arr.Add(mdl.OrderID);
            //arr.Add(mdl.GoodsID);
            //arr.Add(mdl.SizeName);
            //arr.Add(mdl.GoodsCount);
            //arr.Add(mdl.CompleteCount);
            //arr.Add(mdl.CompleteAmount);
            return SqlData.InsDelUpdData("Orders_Goods_Insert", arr);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteOrders_GoodsByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("Orders_Goods_DeleteByID", arr);
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
            ArrayList arr = new ArrayList();
            arr.Add(orderid);
            arr.Add(ordersstatus);
            arr.Add(loginid);
            arr.Add(sql);
            arr.Add(reason);
            return SqlData.InsDelUpdDataReturnOneValue("Orders_Goods_UpdateStatusByLoginID", arr);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateOrders_Goods(Model.Orders_Goods mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.OrdersGoodsID);
            //arr.Add(mdl.OrderID);
            //arr.Add(mdl.GoodsID);
            //arr.Add(mdl.SizeName);
            //arr.Add(mdl.GoodsCount);
            //arr.Add(mdl.CompleteCount);
            //arr.Add(mdl.CompleteAmount);
            return SqlData.InsDelUpdData("Orders_Goods_Update", arr);
        }
    }
}