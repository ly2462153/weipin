/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2012-5-23
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using System.Collections.Generic;

namespace weipin.BLL
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
            DAL.MyShippingAddresses dal = new DAL.MyShippingAddresses();
            return dal.InsertMyShippingAddressesChoose(mdl, _oldmainadid);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertMyShippingAddresses(Model.MyShippingAddresses mdl)
        {
            DAL.MyShippingAddresses dal = new DAL.MyShippingAddresses();
            return dal.InsertMyShippingAddresses(mdl);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loginid">用户名</param>
        /// <returns></returns>
        public int DeleteMyShippingAddressesByID(int id, string loginid)
        {
            DAL.MyShippingAddresses dal = new DAL.MyShippingAddresses();
            return dal.DeleteMyShippingAddressesByID(id, loginid);
        }
        /// <summary>
        /// 修改地址的选择
        /// </summary>
        /// <param name="oldaddressid">修改前默认的地址ID</param>
        /// <param name="newaddressid">要修改的地址ID</param>
        /// <param name="loginid">用户名</param>
        /// <returns></returns>
        public bool UpdateMyShippingAddressesChoose(int oldaddressid, int newaddressid, string loginid)
        {
            DAL.MyShippingAddresses dal = new DAL.MyShippingAddresses();
            if (dal.UpdateMyShippingAddressesChoose(oldaddressid, newaddressid, loginid) > 0)
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
        public DataTable SelectAllMyShippingAddresses()
        {
            DAL.MyShippingAddresses dal = new DAL.MyShippingAddresses();
            return dal.SelectAllMyShippingAddresses();
        }
        /// <summary>
        /// 查询我的收货地址
        /// </summary>
        /// <param name="loginid">我的用户名</param>
        /// <returns></returns>
        public List<Model.MyShippingAddresses> SelectMyShippingAddressesByLoginID(string loginid)
        {
            DAL.MyShippingAddresses dal = new DAL.MyShippingAddresses();
            return dal.SelectMyShippingAddressesByLoginID(loginid);
        }
    }
}