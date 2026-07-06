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

namespace weipin.DAL
{
    public class ConsigneeAddresses
    {        
        public ConsigneeAddresses()
        { }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertConsigneeAddresses(Model.ConsigneeAddresses mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.ConsigneeAddressID);
            //arr.Add(mdl.LoginID);
            //arr.Add(mdl.ConsigneeAddress);
            //arr.Add(mdl.IsMain);
            return SqlData.InsDelUpdData("ConsigneeAddresses_Insert", arr);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteConsigneeAddressesByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("ConsigneeAddresses_DeleteByID", arr);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateConsigneeAddresses(Model.ConsigneeAddresses mdl)
        {
            ArrayList arr = new ArrayList();
            //arr.Add(mdl.ConsigneeAddressID);
            //arr.Add(mdl.LoginID);
            //arr.Add(mdl.ConsigneeAddress);
            //arr.Add(mdl.IsMain);
            return SqlData.InsDelUpdData("ConsigneeAddresses_Update", arr);
        }
        
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllConsigneeAddresses()
        {
            return SqlData.SelectDataTable("ConsigneeAddresses_Select", null);
        }
        
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.ConsigneeAddresses SelectConsigneeAddressesByID(int id)
        {
            try
            {
                Model.ConsigneeAddresses mdl = new Model.ConsigneeAddresses();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("ConsigneeAddresses_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        //mdl.ConsigneeAddressID = sdr["ConsigneeAddressID"].ToString();
                        //mdl.LoginID = sdr["LoginID"].ToString();
                        //mdl.ConsigneeAddress = sdr["ConsigneeAddress"].ToString();
                        //mdl.IsMain = sdr["IsMain"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
    }
}