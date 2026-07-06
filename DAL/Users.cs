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
    public class Users
    {
        public Users()
        { }
        /// <summary>
        /// 查询用户名
        /// </summary>
        /// <param name="loginid">用户登录名</param>
        /// <returns></returns>
        public Model.Users SelectUsersByLoginID(string loginid)
        {
            try
            {
                Model.Users mdl = new Model.Users();
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Users_SelectLoginIDByLoginID", arr))
                {
                    while (sdr.Read())
                    {
                        mdl.LoginID = sdr["LoginID"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllUsers()
        {
            return SqlData.SelectDataTable("Users_Select", null);
        }
        /// <summary>
        /// 查询个人资料
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <returns></returns>
        public Model.Users SelectUsersByID(string loginid)
        {
            try
            {
                Model.Users mdl = new Model.Users();
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Users_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        mdl.LoginID = sdr["LoginID"].ToString();
                        mdl.Email = sdr["Email"].ToString();
                        mdl.UserName = sdr["UserName"].ToString();
                        mdl.NickName = sdr["NickName"].ToString();
                        if (sdr["UserSex"].ToString() != "") { mdl.UserSex = Convert.ToBoolean(sdr["UserSex"].ToString()); }
                        if (sdr["Birthdate"].ToString() != "") { mdl.Birthdate = Convert.ToDateTime(sdr["Birthdate"].ToString()); }
                        mdl.UserAddress = sdr["UserAddress"].ToString();
                        mdl.MobilePhone = sdr["MobilePhone"].ToString();
                        mdl.IsVerify = Convert.ToBoolean(sdr["IsVerify"].ToString());
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询用户抵价券金额
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <returns></returns>
        public Model.Users SelectUsersOffsetPriceByLoginID(string loginid)
        {
            try
            {
                Model.Users mdl = new Model.Users();
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Users_SelectOffsetPriceByLoginID", arr))
                {
                    while (sdr.Read())
                    {
                        mdl.VIPGrade = Convert.ToByte(sdr["VIPGrade"].ToString());
                        mdl.OffsetPrice = Convert.ToDouble(sdr["OffsetPrice"].ToString());
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 登陆检查
        /// </summary>
        /// <param name="loginid">用户登录名</param>
        /// <param name="psw">用户登录密码</param>
        /// <returns></returns>
        public Model.Users CheckUser(string loginid, string psw)
        {
            Model.Users mu = new Model.Users();
            ArrayList arr = new ArrayList();
            arr.Add(loginid);
            arr.Add(psw);
            try
            {
                using (SqlDataReader sdr = SqlData.SelectDataReader("Users_SelectByLoginID", arr))
                {
                    while (sdr.Read())
                    {
                        mu.LoginID = sdr["LoginID"].ToString();
                        mu.LoginPassword = sdr["LoginPassword"].ToString();
                        mu.NickName = sdr["NickName"].ToString();
                        mu.VIPGrade = Convert.ToByte(sdr["VIPGrade"].ToString());
                    }
                    return mu;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 检查验证邮箱的登录名与验证码是否匹配
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="code">验证码</param>
        public Model.Users CheckUpdateUsersPasswordInfo(string loginid, string code)
        {
            Model.Users mu = new Model.Users();
            ArrayList arr = new ArrayList();
            arr.Add(loginid);
            arr.Add(code);
            try
            {
                using (SqlDataReader sdr = SqlData.SelectDataReader("Users_CheckUpdatePasswordInfo", arr))
                {
                    while (sdr.Read()) { mu.LoginPassword = sdr["LoginPassword"].ToString(); }
                    return mu;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询我的邮箱
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <returns></returns>
        public Model.Users SelectUsersMyEmail(string loginid)
        {
            Model.Users mu = new Model.Users();
            ArrayList arr = new ArrayList();
            arr.Add(loginid);
            try
            {
                using (SqlDataReader sdr = SqlData.SelectDataReader("Users_SelectMyEmail", arr))
                {
                    while (sdr.Read()) { mu.Email = sdr["Email"].ToString(); }
                    return mu;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertUsers(Model.Users mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.LoginID);
            arr.Add(mdl.LoginPassword);
            arr.Add(mdl.Email);
            arr.Add(mdl.VerifyCode);
            return SqlData.InsDelUpdDataReturnOneValue("Users_Insert", arr);
        }
        /// <summary>
        /// 其它方式登录
        /// </summary>
        /// <param name="mu"></param>
        /// <returns></returns>
        public Model.Users InsertUsersByOtherLoginID(Model.Users mu)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mu.LoginID);
            arr.Add(mu.OtherLoginID);
            arr.Add(mu.LoginPassword);
            arr.Add(mu.Email);
            arr.Add(mu.NickName);
            arr.Add(mu.IsVerify);
            Model.Users mureturn = new weipin.Model.Users();
            try
            {
                using (SqlDataReader sdr = SqlData.SelectDataReader("Users_InsertByOtherLoginID", arr))
                {
                    while (sdr.Read())
                    {
                        mureturn.LoginID = sdr["LoginID"].ToString();
                        mureturn.LoginPassword = sdr["LoginPassword"].ToString();
                        mureturn.NickName = sdr["NickName"].ToString();
                    }
                    return mureturn;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteUsersByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("Users_DeleteByID", arr);
        }
        /// <summary>
        /// 判断用户名和Email是否匹配
        /// </summary>
        /// <param name="loginid">用户名</param>
        /// <param name="email">E-mail</param>
        /// <param name="code">验证码</param>
        /// <returns></returns>
        public int UpdateUsersVerifyCodeByLoginIDAndEmail(string loginid, string email, string code)
        {
            ArrayList arr = new ArrayList();
            arr.Add(loginid);
            arr.Add(email);
            arr.Add(code);
            return SqlData.InsDelUpdDataReturnOneValue("Users_UpdateVerifyCodeByLoginIDAndEmail", arr);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateUsers(Model.Users mdl)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.LoginID);
            arr.Add(mdl.UserName);
            if (mdl.NickName != "") { arr.Add(mdl.NickName); } else { arr.Add(null); }
            arr.Add(mdl.UserSex);
            arr.Add(mdl.Birthdate);
            if (mdl.UserAddress != "") { arr.Add(mdl.UserAddress); } else { arr.Add(null); }
            if (mdl.MobilePhone != "") { arr.Add(mdl.MobilePhone); } else { arr.Add(null); }
            return SqlData.InsDelUpdData("Users_Update", arr);
        }
        /// <summary>
        /// 验证用户邮箱
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="code">验证码</param>
        /// <returns></returns>
        public int UpdateUsersByLoginIDAndCode(string loginid, string code)
        {
            ArrayList arr = new ArrayList();
            arr.Add(loginid);
            arr.Add(code);
            return SqlData.InsDelUpdData("Users_UpdateByLoginIDAndCode", arr);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="loginid">用户名</param>
        /// <param name="oldpassword">旧密码</param>
        /// <param name="newpassword">新密码</param>
        /// <returns></returns>
        public int UpdateUsersPassword(string loginid, string oldpassword, string newpassword)
        {
            ArrayList arr = new ArrayList();
            arr.Add(loginid);
            arr.Add(oldpassword);
            arr.Add(newpassword);
            return SqlData.InsDelUpdDataReturnOneValue("Users_UpdatePassword", arr);
        }
        /// <summary>
        /// 修改密码(忘记密码)
        /// </summary>
        /// <param name="loginid">用户名</param>
        /// <param name="oldpassword">旧密码</param>
        /// <param name="newpassword">新密码</param>
        /// <returns></returns>
        public int UpdateUsersForgetPassword(string loginid, string oldpassword, string newpassword)
        {
            ArrayList arr = new ArrayList();
            arr.Add(loginid);
            arr.Add(oldpassword);
            arr.Add(newpassword);
            return SqlData.InsDelUpdDataReturnOneValue("Users_UpdateForgetPassword", arr);
        }
        /// <summary>
        /// 更新新邮箱和验证码(验证邮箱)
        /// </summary>
        /// <param name="mu"></param>
        /// <returns></returns>
        public int UpdateUsersNewEmailVerifyCode(Model.Users mu)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mu.LoginID);
            arr.Add(mu.EmailNew);
            arr.Add(mu.VerifyCode);
            return SqlData.InsDelUpdData("Users_UpdateNewEmailVerifyCode", arr);
        }
        /// <summary>
        /// 更新新邮箱和验证码(修改验证邮箱)
        /// </summary>
        /// <param name="mu"></param>
        /// <returns></returns>
        public int UpdateUsersEmailVerifyCodeByLoginID(Model.Users mu)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mu.LoginID);
            arr.Add(mu.Email);
            arr.Add(mu.EmailNew);
            arr.Add(mu.VerifyCode);
            return SqlData.InsDelUpdDataReturnOneValue("Users_UpdateEmailVerifyCodeByLoginID", arr);
        }
        /// <summary>
        /// 积分兑换抵价券
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="integral">积分</param>
        /// <returns></returns>
        public int UpdateUsersExchangeOffsetPrice(string loginid, int integral)
        {
            ArrayList arr = new ArrayList();
            arr.Add(loginid);
            arr.Add(integral);
            return SqlData.InsDelUpdDataReturnOneValue("Users_UpdateExchangeOffsetPrice", arr);
        }
    }
}