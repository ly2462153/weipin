/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-12-26
 *
 * 描述: 
**************************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

using weipin.Common;
using weipin.Model;

namespace weipin.DAL
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
        public int InsertOrdersRemarks(Model.OrdersRemarks mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.GoodsID);
            arr.Add(mdl.CourierID);
            if (mdl.LoginID != "")
            {
                arr.Add(mdl.LoginID);
            }
            else
            {
                arr.Add(null);
            }
            if (mdl.LogisticsTimes != 0)
            {
                arr.Add(mdl.LogisticsTimes);
            }
            else
            {
                arr.Add(null);
            }
            arr.Add(mdl.CompleteCount);
            arr.Add(mdl.CompleteAmount);
            arr.Add(mdl.Inventory);
            arr.Add(mdl.SalesVolume);
            arr.Add(mdl.DeliveryTimes);
            arr.Add(mdl.OrderTime);
            if (mdl.Remarks != "")
            {
                arr.Add(mdl.Remarks);
            }
            else
            {
                arr.Add(null);
            }
            return SqlData.InsDelUpdData("OrdersRemarks_Insert", arr);
        }
        /// <summary>
        /// 添加(从订单处编辑按钮添加,有订单ID等属性)
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertOrdersRemarksEdit(Model.OrdersRemarks mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.OrderID);
            arr.Add(mdl.OrdersGoodsID);
            arr.Add(mdl.GoodsID);
            arr.Add(mdl.CourierID);
            arr.Add(mdl.LoginID);
            arr.Add(mdl.LogisticsTimes);
            arr.Add(mdl.CompleteCount);
            arr.Add(mdl.CompleteAmount);
            arr.Add(mdl.Inventory);
            arr.Add(mdl.SalesVolume);
            arr.Add(mdl.DeliveryTimes);
            arr.Add(mdl.OrderTime);
            if (mdl.Remarks != "")
            {
                arr.Add(mdl.Remarks);
            }
            else
            {
                arr.Add(null);
            }
            return SqlData.InsDelUpdData("OrdersRemarks_InsertEdit", arr);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteOrdersRemarksByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("OrdersRemarks_DeleteByID", arr);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateOrdersRemarks(Model.OrdersRemarks mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.OrdersRemarkID);
            //arr.Add(mdl.OrderID);
            //arr.Add(mdl.OrdersGoodsID);
            //arr.Add(mdl.GoodsID);
            //arr.Add(mdl.CourierID);
            //arr.Add(mdl.LoginID);
            //arr.Add(mdl.LogisticsTimes);
            //arr.Add(mdl.CompleteCount);
            //arr.Add(mdl.CompleteAmount);
            //arr.Add(mdl.Inventory);
            //arr.Add(mdl.SalesVolume);
            //arr.Add(mdl.DeliveryTimes);
            //arr.Add(mdl.OrderTime);
            //arr.Add(mdl.AddTime);
            //arr.Add(mdl.Remarks);
            return SqlData.InsDelUpdData("OrdersRemarks_Update", arr);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllOrdersRemarks()
        {
            return SqlData.SelectDataTable("OrdersRemarks_Select", null);
        }

        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.OrdersRemarks SelectOrdersRemarksByID(int id)
        {
            try
            {
                Model.OrdersRemarks mdl = new Model.OrdersRemarks();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("OrdersRemarks_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        //mdl.OrdersRemarkID = sdr["OrdersRemarkID"].ToString();
                        //mdl.OrderID = sdr["OrderID"].ToString();
                        //mdl.OrdersGoodsID = sdr["OrdersGoodsID"].ToString();
                        //mdl.GoodsID = sdr["GoodsID"].ToString();
                        //mdl.CourierID = sdr["CourierID"].ToString();
                        //mdl.LoginID = sdr["LoginID"].ToString();
                        //mdl.LogisticsTimes = sdr["LogisticsTimes"].ToString();
                        //mdl.CompleteCount = sdr["CompleteCount"].ToString();
                        //mdl.CompleteAmount = sdr["CompleteAmount"].ToString();
                        //mdl.Inventory = sdr["Inventory"].ToString();
                        //mdl.SalesVolume = sdr["SalesVolume"].ToString();
                        //mdl.DeliveryTimes = sdr["DeliveryTimes"].ToString();
                        //mdl.OrderTime = sdr["OrderTime"].ToString();
                        //mdl.AddTime = sdr["AddTime"].ToString();
                        //mdl.Remarks = sdr["Remarks"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询订单备注列表
        /// </summary>
        /// <param name="_nowpage">当前页</param>
        /// <param name="_perpage">每页条数</param>
        /// <param name="_starttime">开始时间</param>
        /// <param name="_end">结束时间</param>
        /// <returns></returns>
        public DataList<Model.OrdersRemarks> SelectOrdersRemarksOfPaging(int _start, int _end, string _starttime, string _endtime)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(_start);
                arr.Add(_end);
                arr.Add(_starttime);
                arr.Add(_endtime);
                using (SqlDataReader sdr = SqlData.SelectDataReader("OrdersRemarks_SelectOfPaging", arr))
                {
                    DataList<Model.OrdersRemarks> dmo = new DataList<weipin.Model.OrdersRemarks>();
                    while (sdr.Read())
                    {
                        //int _maxid = 0;
                        if (dmo.Total == 0)
                        {
                            dmo.Total = Convert.ToInt32(sdr["OrdersRemarkID"].ToString());
                            //if (sdr["OrderID"].ToString() != "")
                            //{
                            //    _maxid = Convert.ToInt32(sdr["OrderID"].ToString());
                            //}
                        }
                        else
                        {
                            //if (_maxid != Convert.ToInt32(sdr["OrdersRemarkID"].ToString()))
                            //{
                            Model.OrdersRemarks mdl = new Model.OrdersRemarks();
                            mdl.OrdersRemarkID = Convert.ToInt32(sdr["OrdersRemarkID"].ToString());
                            if (sdr["OrderID"].ToString() != "")
                            {
                                mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString());
                            }
                            if (sdr["OrdersGoodsID"].ToString() != "")
                            {
                                mdl.OrdersGoodsID = Convert.ToInt32(sdr["OrdersGoodsID"].ToString());
                            }
                            mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                            mdl.GoodsName = sdr["GoodsName"].ToString();
                            mdl.CourierID = Convert.ToInt32(sdr["CourierID"].ToString());
                            mdl.CourierName = sdr["CourierName"].ToString();
                            mdl.LoginID = sdr["LoginID"].ToString();
                            if (sdr["LogisticsTimes"].ToString() != "")
                            {
                                mdl.LogisticsTimes = Convert.ToInt16(sdr["LogisticsTimes"].ToString());
                            }
                            mdl.CompleteCount = Convert.ToInt16(sdr["CompleteCount"].ToString());
                            mdl.CompleteAmount = Convert.ToDouble(sdr["CompleteAmount"].ToString());
                            mdl.Inventory = Convert.ToInt16(sdr["Inventory"].ToString());
                            mdl.SalesVolume = Convert.ToInt16(sdr["SalesVolume"].ToString());
                            mdl.DeliveryTimes = Convert.ToInt16(sdr["DeliveryTimes"].ToString());
                            mdl.OrderTime = Convert.ToDateTime(sdr["OrderTime"].ToString());
                            mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                            mdl.Remarks = sdr["Remarks"].ToString();
                            dmo.Rows.Add(mdl);
                            //}
                        }
                    }
                    return dmo;
                }
            }
            catch { throw; }
        }
    }
}