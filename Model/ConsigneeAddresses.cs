using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类ConsigneeAddresses 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ConsigneeAddresses
    {
        public ConsigneeAddresses()
        { }
        #region Model
        private int _consigneeaddressid;
        private string _loginid;
        private string _consigneeaddress;
        private bool _ismain;
        /// <summary>
        /// 
        /// </summary>
        public int ConsigneeAddressID
        {
            set { _consigneeaddressid = value; }
            get { return _consigneeaddressid; }
        }
        /// <summary>
        /// 用户ID(外)
        /// </summary>
        public string LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 收件人地址
        /// </summary>
        public string ConsigneeAddress
        {
            set { _consigneeaddress = value; }
            get { return _consigneeaddress; }
        }
        /// <summary>
        /// 是否是首选地址(1:是;0:否)
        /// </summary>
        public bool IsMain
        {
            set { _ismain = value; }
            get { return _ismain; }
        }
        #endregion Model
    }
}