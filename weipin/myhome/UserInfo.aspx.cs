using System;

namespace weipin.myhome
{
    public partial class UserInfo : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtUserName"] != null) { UpdateUserInfo(); }
            else { BindUserInfo(); }
        }
        /// <summary>
        /// 查询个人资料
        /// </summary>
        private void BindUserInfo()
        {
            BLL.Users bu = new weipin.BLL.Users();
            Model.Users mu = bu.SelectUsersByID(GetSessionOfLoginUser().LoginID);
            if (mu != null && mu.LoginID != "")
            {
                lblLoginID.InnerText = mu.LoginID;
                txtUserName.Value = mu.UserName;
                txtNickName.Value = mu.NickName;
                if (mu.UserSex != null) { if (mu.UserSex == true) { rdoMale.Checked = true; hidUserSex.Value = "1"; } else { rdoWoman.Checked = true; hidUserSex.Value = "0"; } }
                if (mu.Birthdate != null)
                {
                    int _year = ((DateTime)mu.Birthdate).Year;
                    int _month = ((DateTime)mu.Birthdate).Month;
                    StructDaySelect(_year, _month);
                    selYear.SelectedIndex = selYear.Items.IndexOf(selYear.Items.FindByValue(_year.ToString()));
                    selMonth.SelectedIndex = selMonth.Items.IndexOf(selMonth.Items.FindByValue(_month.ToString()));
                    selDay.SelectedIndex = selDay.Items.IndexOf(selDay.Items.FindByValue(((DateTime)mu.Birthdate).Day.ToString()));
                }
                else
                {
                    for (int i = 1; i <= 31; i++)
                    {
                        selDay.Items.Add(i.ToString());
                    }
                }
                lblEmail.InnerText = StructEmail(mu.Email);
                if (mu.IsVerify == true) { spVerify.InnerHtml = "(已验证)"; } else { spVerify.InnerHtml = "<a href=\"VerifyEmail.aspx\" style=\"color:#a10000;\">去验证>></a>"; }
                txtUserAddress.Value = mu.UserAddress;
                txtMobilePhone.Value = mu.MobilePhone;
            }
        }
        /// <summary>
        /// 修改个人信息
        /// </summary>
        private void UpdateUserInfo()
        {
            string _username = Request.Form["txtUserName"].ToString();
            string _nickname = Request.Form["txtNickName"].ToString();
            string _usersex = Request.Form["hidUserSex"].ToString();
            DateTime _result;
            string _birth = Request.Form["selYear"].ToString() + "-" + Request.Form["selMonth"].ToString() + "-" + Request.Form["selDay"].ToString();
            string _address = Request.Form["txtUserAddress"].ToString();
            string _mobilephone = Request.Form["txtMobilePhone"].ToString();
            #region 验证
            if (_username == "" || _username.Length > 10) { Response.Write("<script>alert('请输入您的姓名且不能超过10个字符!');</script>"); return; }
            if (_usersex == "" || (_usersex != "1" && _usersex != "0")) { Response.Write("<script>alert('请选择性别!');</script>"); return; }
            if (!DateTime.TryParse(_birth, out _result)) { Response.Write("<script>alert('请选择正确的出生日期!');</script>"); return; }
            if (_address.Length > 150) { Response.Write("<script>alert('详细地址的字数限制为150字以内!');</script>"); return; }
            if (_mobilephone.Length > 12) { Response.Write("<script>alert('手机号码的字数限制为12字以内!');</script>"); return; }
            #endregion
            Model.Users mu = new weipin.Model.Users();
            mu.LoginID = GetSessionOfLoginUser().LoginID;
            mu.UserName = _username;
            mu.NickName = _nickname;
            if (_usersex == "1") { mu.UserSex = true; } else { mu.UserSex = false; }
            mu.Birthdate = Convert.ToDateTime(_birth);
            mu.UserAddress = _address;
            mu.MobilePhone = _mobilephone;
            BLL.Users bu = new weipin.BLL.Users();
            if (bu.UpdateUsers(mu)) { ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:更新成功<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"2000\",\"0\",\"\");</script>"); }
            else { Response.Redirect("~/Error.aspx?msg=" + Server.UrlEncode("个人资料更新失败")); }
        }
        /// <summary>
        /// 构造下拉列表(天)
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        private void StructDaySelect(int year, int month)
        {
            int _daycount = 0;
            switch (month)
            {
                case 1: _daycount = 31; break;
                case 2: if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)) { _daycount = 29; } else { _daycount = 28; } break;
                case 3: _daycount = 31; break;
                case 4: _daycount = 30; break;
                case 5: _daycount = 31; break;
                case 6: _daycount = 30; break;
                case 7: _daycount = 31; break;
                case 8: _daycount = 31; break;
                case 9: _daycount = 30; break;
                case 10: _daycount = 31; break;
                case 11: _daycount = 30; break;
                case 12: _daycount = 31; break;
            }
            for (int i = 1; i <= _daycount; i++)
            {
                selDay.Items.Add(i.ToString());
            }
        }
        /// <summary>
        /// 构造隐藏部分的邮箱
        /// </summary>
        /// <param name="email">邮箱</param>
        private string StructEmail(string email)
        {
            string _email = string.Empty;
            int _index = email.IndexOf("@");
            string _emailname = email.Substring(0, _index);
            string _emailprovider = email.Substring(_index);
            int _emailnamelength = _emailname.Length;
            if (_emailnamelength == 1) { _email = email; }
            else if (_emailnamelength == 2 || _emailnamelength == 3) { _email = _emailname.Substring(0, 1) + "*****" + _emailname.Substring(_emailname.Length - 1, 1) + _emailprovider; }
            else if (_emailnamelength > 3) { _email = _emailname.Substring(0, 2) + "*****" + _emailname.Substring(_emailname.Length - 2, 2) + _emailprovider; }
            return _email;
        }
    }
}