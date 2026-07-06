/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2013-1-13
 *
 * 描述: 
**************************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

using weipin.Common;

namespace weipin.DAL
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
        public int UpdateEmailStatistics(Model.EmailStatistics mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.InternetIP);
            arr.Add(mdl.LanIP);
            arr.Add(mdl.UserIPArea);
            arr.Add(mdl.VersionNum);
            return SqlData.InsDelUpdData("EmailStatistics_Update", arr);
        }
    }
}