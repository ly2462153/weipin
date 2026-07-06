using System;
namespace weipin.Model
{
    /// <summary>
    /// 实体类MyShippingAddresses 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class MyShippingAddresses
    {
        public MyShippingAddresses()
        { }
        #region Model
        private int _myaddressid;
        private string _loginid;
        private int _areaid;
        private string _consigneename;
        private string _myaddress;
        private string _myzipcode;
        private string _mobilephone;
        private string _telephone;
        private bool _ismain;
        /// <summary>
        /// 
        /// </summary>
        public int MyAddressID
        {
            set { _myaddressid = value; }
            get { return _myaddressid; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 区域ID(外)
        /// </summary>
        public int AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string ConsigneeName
        {
            set { _consigneename = value; }
            get { return _consigneename; }
        }
        /// <summary>
        /// 详情地址
        /// </summary>
        public string MyAddress
        {
            set { _myaddress = value; }
            get { return _myaddress; }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string MyZipcode
        {
            set { _myzipcode = value; }
            get { return _myzipcode; }
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
        /// 座机
        /// </summary>
        public string Telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        //是否是默认选中数据(1:是;0:不是)
        public bool IsMain
        {
            get { return _ismain; }
            set { _ismain = value; }
        }
        #endregion Model
    }
}