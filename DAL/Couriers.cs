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
    public class Couriers
    {        
        public Couriers()
        { }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertCouriers(Model.Couriers mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.LoginPassword);
            arr.Add(mdl.CourierName);
            arr.Add(mdl.CourierSex);
            arr.Add(mdl.AreaID);
            arr.Add(mdl.MobilePhone);
            return SqlData.InsDelUpdData("Couriers_Insert", arr);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCouriersByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("Couriers_DeleteByID", arr);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateCouriers(Model.Couriers mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.CourierID);
            arr.Add(mdl.LoginPassword);
            arr.Add(mdl.CourierName);
            arr.Add(mdl.CourierSex);
            arr.Add(mdl.AreaID);
            arr.Add(mdl.IsLeft);
            arr.Add(mdl.MobilePhone);
            return SqlData.InsDelUpdData("Couriers_Update", arr);
        }
        /// <summary>
        /// 注销快递员
        /// </summary>
        /// <param name="_cid">CourierID</param>
        /// <returns></returns>
        public int UpdateCouriersIsLeftByID(int _cid)
        {
            ArrayList arr = new ArrayList();
            arr.Add(_cid);
            return SqlData.InsDelUpdData("Couriers_UpdateIsLeftByID", arr);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Model.Couriers> SelectAllCouriers()
        {
            try
            {
                List<Model.Couriers> lmc = new List<weipin.Model.Couriers>();
                using (SqlDataReader sdr = SqlData.SelectDataReader("Couriers_Select", null))
                {
                    while (sdr.Read())
                    {
                        Model.Couriers mdl = new Model.Couriers();
                        mdl.CourierID = Convert.ToInt32(sdr["CourierID"].ToString());
                        mdl.CourierName = sdr["CourierName"].ToString();
                        mdl.AreaID = Convert.ToInt32(sdr["AreaID"].ToString());
                        lmc.Add(mdl);
                    }
                    return lmc;
                }
            }
            catch { throw; }
        }
        
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Couriers SelectCouriersByID(int id)
        {
            try
            {
                Model.Couriers mdl = new Model.Couriers();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Couriers_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        mdl.CourierID = Convert.ToInt32(sdr["CourierID"].ToString());
                        mdl.CourierName = sdr["CourierName"].ToString();
                        mdl.CourierSex = Convert.ToBoolean(sdr["CourierSex"].ToString());
                        mdl.DeliveryTimes = Convert.ToInt32(sdr["DeliveryTimes"].ToString());
                        mdl.DeliveryAmount = Convert.ToDouble(sdr["DeliveryAmount"].ToString());
                        mdl.AreaID = Convert.ToInt32(sdr["AreaID"].ToString());
                        mdl.MobilePhone = sdr["MobilePhone"].ToString();
                        mdl.IsLeft = Convert.ToBoolean(sdr["IsLeft"].ToString());
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询快递员信息列表
        /// </summary>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        /// <returns></returns>
        public DataSet SelectCouriersOfPaging(int _start, int _end)
        {
            ArrayList arr = new ArrayList();
            arr.Add(_start);
            arr.Add(_end);
            return SqlData.SelectDataSet("Couriers_SelectOfPaging", arr);
        }
    }
}