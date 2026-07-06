using System;
using System.Collections.Generic;
using System.Text;

namespace weipin.BLL
{
    public class Admins
    {
        public Admins()
        { }

        public bool InsertAdmin(Model.Admins ma)
        {
            DAL.Admins da = new weipin.DAL.Admins();
            if (da.InsertAdmin(ma) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 登陆检查
        /// </summary>
        /// <param name="sID">sID</param>
        /// <param name="psw">密码</param>
        /// <param name="bRmb">是否记住登陆状态</param>
        /// <returns>1:成功;2:密码错误;3.用户名不存在</returns>
        public string CheckUser(string sID, string sPsw, bool bRmb)
        {
            DAL.Admins da = new DAL.Admins();
            Model.Admins ea = new Model.Admins();
            ea = da.CheckUser(sID);
            if (ea.AdminID != null && ea.AdminPSW != null)
            {
                //string sEncPSW = FormsAuthentication.HashPasswordForStoringInConfigFile(sPsw, "sha1");加密比较
                if (ea.AdminPSW == sPsw)
                {
                    Common.BasePageAdmin.SetSessionOfLoginAdmin(ea);
                    if (bRmb == true) { Common.BasePageAdmin.SetCookieOfLoginAdmin(ea); }
                    return "1";
                }
                else { return "2"; }
            }
            else { return "3"; }
        }
    }
}