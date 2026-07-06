using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类Couriers 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Couriers
    {
        public Couriers()
        { }
        #region Model
        private int _courierid;
        private int _areaid;
        private string _loginpassword;
        private string _couriername;
        private bool _couriersex;
        private string _mobilephone;
        private int _deliverytimes;
        private double _deliveryamount;
        private bool _isleft;
        /// <summary>
        /// 
        /// </summary>
        public int CourierID
        {
            set { _courierid = value; }
            get { return _courierid; }
        }
        /// <summary>
        /// 主要负责区域
        /// </summary>
        public int AreaID
        {
            get { return _areaid; }
            set { _areaid = value; }
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
        /// 快递员姓名
        /// </summary>
        public string CourierName
        {
            set { _couriername = value; }
            get { return _couriername; }
        }
        /// <summary>
        /// 性别(1:男;0:女)
        /// </summary>
        public bool CourierSex
        {
            set { _couriersex = value; }
            get { return _couriersex; }
        }
        /// <summary>
        /// 快递员手机
        /// </summary>
        public string MobilePhone
        {
            get { return _mobilephone; }
            set { _mobilephone = value; }
        }
        /// <summary>
        /// 送货次数
        /// </summary>
        public int DeliveryTimes
        {
            set { _deliverytimes = value; }
            get { return _deliverytimes; }
        }
        /// <summary>
        /// 送货金额
        /// </summary>
        public double DeliveryAmount
        {
            set { _deliveryamount = value; }
            get { return _deliveryamount; }
        }
        /// <summary>
        /// 已离职
        /// </summary>
        public bool IsLeft
        {
            get { return _isleft; }
            set { _isleft = value; }
        }
        #endregion Model
    }
}