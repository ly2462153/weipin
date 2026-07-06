/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-10
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using System.Collections.Generic;

namespace weipin.BLL
{
    public class AttributeValues
    {
        public AttributeValues()
        { }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool InsertAttributeValues(Model.AttributeValues mdl)
        {
            DAL.AttributeValues dal = new DAL.AttributeValues();
            if (dal.InsertAttributeValues(mdl) > 0)
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
        public bool DeleteAttributeValuesByID(int id)
        {
            DAL.AttributeValues dal = new DAL.AttributeValues();
            if (dal.DeleteAttributeValuesByID(id) > 0)
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
        public bool UpdateAttributeValues(Model.AttributeValues mdl)
        {
            DAL.AttributeValues dal = new DAL.AttributeValues();
            if (dal.UpdateAttributeValues(mdl) > 0)
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
        public DataTable SelectAllAttributeValues()
        {
            DAL.AttributeValues dal = new DAL.AttributeValues();
            return dal.SelectAllAttributeValues();
        }
        
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.AttributeValues SelectAttributeValuesByID(int id)
        {
            DAL.AttributeValues dal = new DAL.AttributeValues();
            return dal.SelectAttributeValuesByID(id);
        }
        ///// <summary>2012-1-17待删
        ///// 查询属性值
        ///// </summary>
        ///// <param name="_aid">属性ID</param>
        ///// <returns></returns>
        //public List<Model.AttributeValues> SelectAttributeValuesByAttributeID(int _aid)
        //{
        //    DAL.AttributeValues dav = new weipin.DAL.AttributeValues();
        //    return dav.SelectAttributeValuesByAttributeID(_aid);
        //}
    }
}