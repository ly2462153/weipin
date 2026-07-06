using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

using weipin.Common;

namespace weipin.DAL
{
    public class Admins
    {
        public Admins()
        { }
        public int InsertAdmin(Model.Admins ma)
        {
            return SqlData.InsDelUpdData("insert into Admins(AdminGUID,AdminID,AdminPSW,AdminName) values('" + ma.AdminGUID + "','" + ma.AdminID + "','" + ma.AdminPSW + "','" + ma.AdminName + "');");
        }
        /// <summary>
        /// 登陆检查
        /// </summary>
        /// <param name="sID">sID</param>
        /// <returns></returns>
        public Model.Admins CheckUser(string sID)
        {
            try
            {
                Model.Admins ea = new Model.Admins();
                ArrayList arr = new ArrayList();
                arr.Add(sID);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Admins_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        ea.AdminGUID = sdr["AdminGuid"].ToString();
                        ea.AdminID = sdr["AdminID"].ToString();
                        ea.AdminPSW = sdr["AdminPSW"].ToString();
                        ea.AdminName = sdr["AdminName"].ToString();
                        ea.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                    }
                    return ea;
                }
            }
            catch { throw; }
        }
    }
}