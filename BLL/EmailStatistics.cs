/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2013-1-13
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using System.Collections.Generic;

namespace weipin.BLL
{
    public class EmailStatistics
    {
        public EmailStatistics()
        { }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool UpdateEmailStatistics(Model.EmailStatistics mdl)
        {
            DAL.EmailStatistics dal = new DAL.EmailStatistics();
            if (dal.UpdateEmailStatistics(mdl) > 0) { return true; } else { return false; }
        }
    }
}