using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类Users 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Users
    {
        public Users()
        { }
        #region Model
        private string _loginid;
        private string _otherloginid;
        private string _loginpassword;
        private string _email;
        private string _emailnew;
        private string _username;
        private string _nickname;
        private bool? _usersex;
        private DateTime? _birthdate;
        private string _useraddress;
        private string _mobilephone;
        private byte _vipgrade;
        private int _ordercount;
        private int _completecount;
        private double _monetary;
        private int _integral;
        private double _offsetprice;
        private DateTime _addtime;
        private DateTime _updatetime;
        private DateTime _lastlogintime;
        private string _verifycode;
        private bool _isverify;
        private bool _isdeleted;
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 其它登录方式登录名(如:QQ登录/新浪微博登录)
        /// </summary>
        public string OtherLoginID
        {
            get { return _otherloginid; }
            set { _otherloginid = value; }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPassword
        {
            set { _loginpassword = value; }
            get { return _loginpassword; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 验证邮箱时的临时新邮箱
        /// </summary>
        public string EmailNew
        {
            get { return _emailnew; }
            set { _emailnew = value; }
        }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
        /// <summary>
        /// 性别(1:男;0:女)
        /// </summary>
        public bool? UserSex
        {
            set { _usersex = value; }
            get { return _usersex; }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthdate
        {
            set { _birthdate = value; }
            get { return _birthdate; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string UserAddress
        {
            set { _useraddress = value; }
            get { return _useraddress; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string MobilePhone
        {
            set { _mobilephone = value; }
            get { return _mobilephone; }
        }
        /// <summary>
        /// VIP等级(1级VIP为最低级)
        /// </summary>
        public byte VIPGrade
        {
            get { return _vipgrade; }
            set { _vipgrade = value; }
        }
        /// <summary>
        /// 订购商品数量
        /// </summary>
        public int OrderCount
        {
            set { _ordercount = value; }
            get { return _ordercount; }
        }
        /// <summary>
        /// 实际成交商品数量
        /// </summary>
        public int CompleteCount
        {
            set { _completecount = value; }
            get { return _completecount; }
        }
        /// <summary>
        /// 已消费金额
        /// </summary>
        public double Monetary
        {
            set { _monetary = value; }
            get { return _monetary; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int Integral
        {
            get { return _integral; }
            set { _integral = value; }
        }
        /// <summary>
        /// 抵价券
        /// </summary>
        public double OffsetPrice
        {
            get { return _offsetprice; }
            set { _offsetprice = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }
        /// <summary>
        /// 邮箱验证码
        /// </summary>
        public string VerifyCode
        {
            set { _verifycode = value; }
            get { return _verifycode; }
        }
        /// <summary>
        /// 是否已激活(1:是;0:否)
        /// </summary>
        public bool IsVerify
        {
            set { _isverify = value; }
            get { return _isverify; }
        }
        /// <summary>
        /// 是否已删除(1:是;0:否)
        /// </summary>
        public bool IsDeleted
        {
            set { _isdeleted = value; }
            get { return _isdeleted; }
        }
        #endregion Model
    }
}