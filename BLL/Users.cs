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
    public class Users
    {
        public Users()
        { }
        /// <summary>
        /// 判断登录名是否存在
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <returns>true:该用户已存在;false:该用户不存在</returns>
        public bool SelectUsersByLoginID(string loginid)
        {
            DAL.Users du = new weipin.DAL.Users();
            Model.Users eu = du.SelectUsersByLoginID(loginid);
            if (eu.LoginID != null) { return true; } else { return false; }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllUsers()
        {
            DAL.Users dal = new DAL.Users();
            return dal.SelectAllUsers();
        }
        /// <summary>
        /// 查询个人资料
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <returns></returns>
        public Model.Users SelectUsersByID(string loginid)
        {
            DAL.Users dal = new DAL.Users();
            return dal.SelectUsersByID(loginid);
        }
        /// <summary>
        /// 查询我的邮箱
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <returns></returns>
        public Model.Users SelectUsersMyEmail(string loginid)
        {
            DAL.Users du = new weipin.DAL.Users();
            return du.SelectUsersMyEmail(loginid);
        }
        /// <summary>
        /// 查询用户抵价券金额
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <returns></returns>
        public Model.Users SelectUsersOffsetPriceByLoginID(string loginid)
        {
            DAL.Users du = new weipin.DAL.Users();
            return du.SelectUsersOffsetPriceByLoginID(loginid);
        }
        /// <summary>
        /// 登陆检查
        /// </summary>
        /// <param name="loginid">用户登录名</param>
        /// <param name="psw">密码</param>
        /// <param name="isrmb">是否记住登陆状态</param>
        /// <returns>1:成功;2:密码错误;3.用户名不存在</returns>
        public string CheckUser(string loginid, string psw, bool isrmb)
        {
            DAL.Users du = new DAL.Users();
            Model.Users mu = new Model.Users();
            mu = du.CheckUser(loginid, psw);
            if (mu.LoginID != null && mu.LoginPassword != null)
            {
                // string _encpsw = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(psw, "md5");
                if (mu.LoginPassword == psw)
                {
                    Common.BasePage.SetSessionOfLoginUser(mu);
                    if (isrmb == true)
                    {
                        Common.BasePage.SetCookieOfLoginUser(mu);
                    }
                    return "1";
                }
                else { return "2"; }
            }
            else { return "3"; }
        }
        /// <summary>
        /// 检查验证邮箱的登录名与验证码是否匹配
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="code">验证码</param>
        public Model.Users CheckUpdateUsersPasswordInfo(string loginid, string code)
        {
            DAL.Users du = new weipin.DAL.Users();
            return du.CheckUpdateUsersPasswordInfo(loginid, code);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertUsers(Model.Users mdl)
        {
            DAL.Users dal = new DAL.Users();
            return dal.InsertUsers(mdl);
        }
        /// <summary>
        /// 其它方式登录
        /// </summary>
        /// <param name="mu"></param>
        /// <returns></returns>
        public Model.Users InsertUsersByOtherLoginID(Model.Users mu)
        {
            DAL.Users dal = new DAL.Users();
            return dal.InsertUsersByOtherLoginID(mu);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteUsersByID(int id)
        {
            DAL.Users dal = new DAL.Users();
            if (dal.DeleteUsersByID(id) > 0) { return true; } else { return false; }
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
            DAL.Users du = new weipin.DAL.Users();
            return du.UpdateUsersVerifyCodeByLoginIDAndEmail(loginid, email, code);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool UpdateUsers(Model.Users mdl)
        {
            DAL.Users dal = new DAL.Users();
            if (dal.UpdateUsers(mdl) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 验证用户邮箱
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="code">验证码</param>
        /// <returns></returns>
        public bool UpdateUsersByLoginIDAndCode(string loginid, string code)
        {
            DAL.Users du = new weipin.DAL.Users();
            if (du.UpdateUsersByLoginIDAndCode(loginid, code) > 0) { return true; } else { return false; }
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
            DAL.Users du = new weipin.DAL.Users();
            return du.UpdateUsersPassword(loginid, oldpassword, newpassword);
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
            DAL.Users du = new weipin.DAL.Users();
            return du.UpdateUsersForgetPassword(loginid, oldpassword, newpassword);
        }
        /// <summary>
        /// 更新新邮箱和验证码(验证邮箱)
        /// </summary>
        /// <param name="mu"></param>
        /// <returns></returns>
        public bool UpdateUsersNewEmailVerifyCode(Model.Users mu)
        {
            DAL.Users du = new weipin.DAL.Users();
            if (du.UpdateUsersNewEmailVerifyCode(mu) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 更新新邮箱和验证码(修改验证邮箱)
        /// </summary>
        /// <param name="mu"></param>
        /// <returns></returns>
        public int UpdateUsersEmailVerifyCodeByLoginID(Model.Users mu)
        {
            DAL.Users du = new weipin.DAL.Users();
            return du.UpdateUsersEmailVerifyCodeByLoginID(mu);
        }
        /// <summary>
        /// 积分兑换抵价券
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="integral">积分</param>
        /// <returns></returns>
        public int UpdateUsersExchangeOffsetPrice(string loginid, int integral)
        {
            DAL.Users du = new weipin.DAL.Users();
            return du.UpdateUsersExchangeOffsetPrice(loginid, integral);
        }
    }
}