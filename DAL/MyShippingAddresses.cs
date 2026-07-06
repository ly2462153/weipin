/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2012-5-23
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
    public class MyShippingAddresses
    {
        public MyShippingAddresses()
        { }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <param name="oldaddressid">添加前默认的地址ID</param>
        /// <returns></returns>
        public int InsertMyShippingAddressesChoose(Model.MyShippingAddresses mdl, int _oldmainadid)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.LoginID);
            arr.Add(mdl.AreaID);
            arr.Add(mdl.ConsigneeName);
            arr.Add(mdl.MyAddress);
            if (mdl.MobilePhone != "") { arr.Add(mdl.MobilePhone); } else { arr.Add(null); }
            if (mdl.Telephone != "") { arr.Add(mdl.Telephone); } else { arr.Add(null); }
            if (mdl.MyZipcode != "") { arr.Add(mdl.MyZipcode); } else { arr.Add(null); }
            arr.Add(mdl.IsMain);
            arr.Add(_oldmainadid);
            return SqlData.InsDelUpdDataReturnOneValue("MyShippingAddresses_InsertChoose", arr);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertMyShippingAddresses(Model.MyShippingAddresses mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.LoginID);
            arr.Add(mdl.AreaID);
            arr.Add(mdl.ConsigneeName);
            arr.Add(mdl.MyAddress);
            if (mdl.MobilePhone != "") { arr.Add(mdl.MobilePhone); } else { arr.Add(null); }
            if (mdl.Telephone != "") { arr.Add(mdl.Telephone); } else { arr.Add(null); }
            if (mdl.MyZipcode != "") { arr.Add(mdl.MyZipcode); } else { arr.Add(null); }
            arr.Add(mdl.IsMain);
            return SqlData.InsDelUpdDataReturnOneValue("MyShippingAddresses_Insert", arr);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loginid">用户名</param>
        /// <returns></returns>
        public int DeleteMyShippingAddressesByID(int id, string loginid)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            arr.Add(loginid);
            return SqlData.InsDelUpdDataReturnOneValue("MyShippingAddresses_DeleteByID", arr);
        }
        /// <summary>
        /// 修改地址的选择
        /// </summary>
        /// <param name="oldaddressid">修改前的地址ID</param>
        /// <param name="newaddressid">要修改的地址ID</param>
        /// <param name="loginid">用户名</param>
        /// <returns></returns>
        public int UpdateMyShippingAddressesChoose(int oldaddressid, int newaddressid, string loginid)
        {
            ArrayList arr = new ArrayList();
            arr.Add(oldaddressid);
            arr.Add(newaddressid);
            arr.Add(loginid);
            return SqlData.InsDelUpdData("MyShippingAddresses_UpdateChoose", arr);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllMyShippingAddresses()
        {
            return SqlData.SelectDataTable("MyShippingAddresses_Select", null);
        }
        /// <summary>
        /// 查询我的收货地址
        /// </summary>
        /// <param name="loginid">我的用户名</param>
        /// <returns></returns>
        public List<Model.MyShippingAddresses> SelectMyShippingAddressesByLoginID(string loginid)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("MyShippingAddresses_SelectByLoginID", arr))
                {
                    List<Model.MyShippingAddresses> lmmsa = new List<weipin.Model.MyShippingAddresses>();
                    while (sdr.Read())
                    {
                        Model.MyShippingAddresses mdl = new Model.MyShippingAddresses();
                        mdl.MyAddressID = Convert.ToInt32(sdr["MyAddressID"].ToString());
                        mdl.LoginID = sdr["LoginID"].ToString();
                        mdl.AreaID = Convert.ToInt32(sdr["AreaID"].ToString());
                        mdl.ConsigneeName = sdr["ConsigneeName"].ToString();
                        mdl.MyAddress = sdr["MyAddress"].ToString();
                        mdl.MyZipcode = sdr["MyZipcode"].ToString();
                        mdl.MobilePhone = sdr["MobilePhone"].ToString();
                        mdl.Telephone = sdr["Telephone"].ToString();
                        mdl.IsMain = Convert.ToBoolean(sdr["IsMain"].ToString());
                        lmmsa.Add(mdl);
                    }
                    return lmmsa;
                }
            }
            catch { throw; }
        }
    }
}