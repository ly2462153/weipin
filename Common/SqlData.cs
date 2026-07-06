/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2008年10月9日
 * 
 * 最后修改时间：2011年7月21日
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace weipin.Common
{
    public class SqlData
    {
        /// <summary>
        /// 添加,删除，更改数据
        /// </summary>
        /// <param name="strProc">存储过程</param>
        /// <param name="arr">参数</param>
        /// <returns>受到影响的行数</returns>
        public static int InsDelUpdData(string strProc, ArrayList arr)
        {
            SqlCommand scom = null;
            try
            {
                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["weipin"].ConnectionString))
                {
                    if (scon.State.Equals(ConnectionState.Closed)) { scon.Open(); }
                    scom = new SqlCommand(strProc, scon);
                    scom.CommandType = CommandType.StoredProcedure;
                    if (arr != null)
                    {
                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i] != null)
                            {
                                scom.Parameters.Add(new SqlParameter("para" + i, arr[i]));
                            }
                            else
                            {
                                scom.Parameters.Add(new SqlParameter("para" + i, System.DBNull.Value));
                            }
                        }
                    }
                    return scom.ExecuteNonQuery();
                }
            }
            catch { throw; }
            finally { scom.Dispose(); }
        }
        /// <summary>
        /// 添加,删除，更改数据
        /// </summary>
        /// <param name="strProc">存储过程</param>
        /// <param name="arr">参数</param>
        /// <returns>存储过程中自定义的返回值(默认返回值为:-1)</returns>
        public static int InsDelUpdDataReturnOneValue(string strProc, ArrayList arr)
        {
            SqlCommand scom = null;
            try
            {
                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["weipin"].ConnectionString))
                {
                    if (scon.State.Equals(ConnectionState.Closed)) { scon.Open(); }
                    SqlParameter sparm = null;
                    scom = new SqlCommand(strProc, scon);
                    scom.CommandType = CommandType.StoredProcedure;
                    if (arr != null)
                    {
                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i] != null)
                            {
                                sparm = new SqlParameter("para" + i, arr[i]);
                            }
                            else
                            {
                                sparm = new SqlParameter("para" + i, System.DBNull.Value);
                            }
                            sparm.Direction = ParameterDirection.Input;
                            scom.Parameters.Add(sparm);
                        }
                        sparm = new SqlParameter("para" + arr.Count, -1);
                        sparm.Direction = ParameterDirection.Output;
                        scom.Parameters.Add(sparm);
                    }
                    else
                    {
                        sparm = new SqlParameter("para0", -1);
                        sparm.Direction = ParameterDirection.Output;
                        scom.Parameters.Add(sparm);
                    }
                    scom.ExecuteNonQuery();
                    return System.Convert.ToInt16(scom.Parameters[arr.Count].Value.ToString());
                }
            }
            catch { throw; }
            finally { scom.Dispose(); }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="strProc">存储过程</param>
        /// <param name="arr">参数</param>
        /// <returns>DataTable</returns>
        public static DataTable SelectDataTable(string strProc, ArrayList arr)
        {
            SqlDataAdapter sda = null;
            try
            {
                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["weipin"].ConnectionString))
                {
                    if (scon.State.Equals(ConnectionState.Closed)) { scon.Open(); }
                    DataTable dt = new DataTable();
                    sda = new SqlDataAdapter(strProc, scon);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (arr != null)
                    {
                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i] != null)
                            {
                                sda.SelectCommand.Parameters.Add(new SqlParameter("para" + i, arr[i]));
                            }
                            else
                            {
                                sda.SelectCommand.Parameters.Add(new SqlParameter("para" + i, System.DBNull.Value));
                            }
                        }
                    }
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch { throw; }
            finally { sda.Dispose(); }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="strProc">存储过程</param>
        /// <param name="arr">参数</param>
        /// <returns>DataSet</returns>
        public static DataSet SelectDataSet(string strProc, ArrayList arr)
        {
            SqlDataAdapter sda = null;
            try
            {
                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["weipin"].ConnectionString))
                {
                    if (scon.State.Equals(ConnectionState.Closed)) { scon.Open(); }
                    DataSet ds = new DataSet();
                    sda = new SqlDataAdapter(strProc, scon);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (arr != null)
                    {
                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i] != null)
                            {
                                sda.SelectCommand.Parameters.Add(new SqlParameter("para" + i, arr[i]));
                            }
                            else
                            {
                                sda.SelectCommand.Parameters.Add(new SqlParameter("para" + i, System.DBNull.Value));
                            }
                        }
                    }
                    sda.Fill(ds);
                    return ds;
                }
            }
            catch { throw; }
            finally { sda.Dispose(); }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="strProc">存储过程</param>
        /// <param name="arr">参数</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader SelectDataReader(string strProc, ArrayList arr)
        {
            SqlConnection scon = null;
            SqlCommand scom = null;
            try
            {
                scon = new SqlConnection(ConfigurationManager.ConnectionStrings["weipin"].ConnectionString);
                if (scon.State.Equals(ConnectionState.Closed)) { scon.Open(); }
                scom = new SqlCommand(strProc, scon);
                scom.CommandType = CommandType.StoredProcedure;
                if (arr != null)
                {
                    for (int i = 0; i < arr.Count; i++)
                    {
                        if (arr[i] != null)
                        {
                            scom.Parameters.Add(new SqlParameter("para" + i, arr[i]));
                        }
                        else
                        {
                            scom.Parameters.Add(new SqlParameter("para" + i, System.DBNull.Value));
                        }
                    }
                }
                return scom.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch { scon.Close(); throw; }
            finally { scom.Dispose(); }
        }
        /// <summary>
        /// 添加,删除，更改数据
        /// </summary>
        /// <param name="_sql">sql语句</param>
        /// <returns>受到影响的行数</returns>
        public static int InsDelUpdData(string _sql)
        {
            SqlCommand scom = null;
            try
            {
                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["weipin"].ConnectionString))
                {
                    if (scon.State.Equals(ConnectionState.Closed)) { scon.Open(); }
                    scom = new SqlCommand(_sql, scon);
                    scom.CommandType = CommandType.Text;
                    return scom.ExecuteNonQuery();
                }
            }
            catch { throw; }
            finally { scom.Dispose(); }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>DataTable</returns>
        public static DataTable SelectDataTable(string sql)
        {
            SqlDataAdapter sda = null;
            try
            {
                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["weipin"].ConnectionString))
                {
                    if (scon.State.Equals(ConnectionState.Closed)) { scon.Open(); }
                    DataTable dt = new DataTable();
                    sda = new SqlDataAdapter(sql, scon);
                    sda.SelectCommand.CommandType = CommandType.Text;
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch { throw; }
            finally { sda.Dispose(); }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static DataSet SelectDataSet(string sql)
        {
            SqlDataAdapter sda = null;
            try
            {
                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["weipin"].ConnectionString))
                {
                    if (scon.State.Equals(ConnectionState.Closed)) { scon.Open(); }
                    DataSet ds = new DataSet();
                    sda = new SqlDataAdapter(sql, scon);
                    sda.SelectCommand.CommandType = CommandType.Text;
                    sda.Fill(ds);
                    return ds;
                }
            }
            catch { throw; }
            finally { sda.Dispose(); }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader SelectDataReader(string sql)
        {
            SqlConnection scon = null;
            SqlCommand scom = null;
            try
            {
                scon = new SqlConnection(ConfigurationManager.ConnectionStrings["weipin"].ConnectionString);
                if (scon.State.Equals(ConnectionState.Closed)) { scon.Open(); }
                scom = new SqlCommand(sql, scon);
                scom.CommandType = CommandType.Text;
                return scom.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch { scon.Close(); throw; }
            finally { scom.Dispose(); }
        }
    }
}