/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-10
 *
 * 描述: 
**************************************************************************************************/
using System.Data;

namespace weipin.BLL
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
        public bool InsertConsigneeAddresses(Model.ConsigneeAddresses mdl)
        {
            DAL.ConsigneeAddresses dal = new DAL.ConsigneeAddresses();
            if (dal.InsertConsigneeAddresses(mdl) > 0)
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
        public bool DeleteConsigneeAddressesByID(int id)
        {
            DAL.ConsigneeAddresses dal = new DAL.ConsigneeAddresses();
            if (dal.DeleteConsigneeAddressesByID(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool UpdateConsigneeAddresses(Model.ConsigneeAddresses mdl)
        {
            DAL.ConsigneeAddresses dal = new DAL.ConsigneeAddresses();
            if (dal.UpdateConsigneeAddresses(mdl) > 0)
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
        public DataTable SelectAllConsigneeAddresses()
        {
            DAL.ConsigneeAddresses dal = new DAL.ConsigneeAddresses();
            return dal.SelectAllConsigneeAddresses();
        }
        
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.ConsigneeAddresses SelectConsigneeAddressesByID(int id)
        {
            DAL.ConsigneeAddresses dal = new DAL.ConsigneeAddresses();
            return dal.SelectConsigneeAddressesByID(id);
        }
    }
}