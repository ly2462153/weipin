/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2012-9-21
 *
 * 描述: 
**************************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

using weipin.Common;
using weipin.Model;

namespace weipin.DAL
{
    public class Integral
    {
        public Integral()
        { }
        /// <summary>
        /// 查询我的积分列表
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataList<Model.Integral> SelectMyGoodsIntegralByLoginIDOfPaging(string loginid, string start, string end)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                arr.Add(start);
                arr.Add(end);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Integral_SelectMyByLoginIDOfPaging", arr))
                {
                    DataList<Model.Integral> dmi = new DataList<weipin.Model.Integral>();
                    while (sdr.Read())
                    {
                        if (dmi.Total == 0)
                        {
                            dmi.Total = Convert.ToInt32(sdr["IntegralNum"].ToString());
                            dmi.IntegralTotle = Convert.ToInt32(sdr["OrderID"].ToString());
                        }
                        else
                        {
                            Model.Integral mdl = new Model.Integral();
                            mdl.IntegralNum = Convert.ToInt16(sdr["IntegralNum"].ToString());
                            if (sdr["OrderID"].ToString() != "") { mdl.OrderID = Convert.ToInt32(sdr["OrderID"].ToString()); }
                            mdl.SourseType = Convert.ToByte(sdr["SourseType"].ToString());
                            mdl.EffectiveTime = Convert.ToDateTime(sdr["EffectiveTime"].ToString());
                            dmi.Rows.Add(mdl);
                        }
                    }
                    return dmi;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Integral SelectIntegralByID(int id)
        {
            try
            {
                Model.Integral mdl = new Model.Integral();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Integral_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        //mdl.IntegralID = sdr["IntegralID"].ToString();
                        //mdl.OrdersGoodsID = sdr["OrdersGoodsID"].ToString();
                        //mdl.LoginID = sdr["LoginID"].ToString();
                        //mdl.IntegralNum = sdr["IntegralNum"].ToString();
                        //mdl.SourseType = sdr["SourseType"].ToString();
                        //mdl.EffectiveTime = sdr["EffectiveTime"].ToString();
                        //mdl.IsEffect = sdr["IsEffect"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询多条记录
        /// </summary>
        /// <returns></returns>
        public List<Model.Integral> SelectIntegral()
        {
            try
            {
                ArrayList arr = new ArrayList();
                //arr.Add();
                using (SqlDataReader sdr = SqlData.SelectDataReader("Integral_Select", arr))
                {
                    List<Model.Integral> list = new List<Model.Integral>();
                    while (sdr.Read())
                    {
                        Model.Integral mdl = new Model.Integral();
                        //mdl.IntegralID = sdr["IntegralID"].ToString();
                        //mdl.OrdersGoodsID = sdr["OrdersGoodsID"].ToString();
                        //mdl.LoginID = sdr["LoginID"].ToString();
                        //mdl.IntegralNum = sdr["IntegralNum"].ToString();
                        //mdl.SourseType = sdr["SourseType"].ToString();
                        //mdl.EffectiveTime = sdr["EffectiveTime"].ToString();
                        //mdl.IsEffect = sdr["IsEffect"].ToString();
                        list.Add(mdl);
                    }
                    return list;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllIntegral()
        {
            return SqlData.SelectDataTable("Integral_SelectAll", null);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertIntegral(Model.Integral mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.IntegralID);
            //arr.Add(mdl.OrdersGoodsID);
            //arr.Add(mdl.LoginID);
            //arr.Add(mdl.IntegralNum);
            //arr.Add(mdl.SourseType);
            //arr.Add(mdl.EffectiveTime);
            //arr.Add(mdl.IsEffect);
            return SqlData.InsDelUpdData("Integral_Insert", arr);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteIntegralByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("Integral_DeleteByID", arr);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateIntegral(Model.Integral mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.IntegralID);
            //arr.Add(mdl.OrdersGoodsID);
            //arr.Add(mdl.LoginID);
            //arr.Add(mdl.IntegralNum);
            //arr.Add(mdl.SourseType);
            //arr.Add(mdl.EffectiveTime);
            //arr.Add(mdl.IsEffect);
            return SqlData.InsDelUpdData("Integral_Update", arr);
        }
    }
}