using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类Admins 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Admins
    {
        public Admins()
        { }
        #region Model
        private string _adminguid;
        private string _adminid;
        private string _adminpsw;
        private string _adminname;
        private DateTime _addtime;
        /// <summary>
        /// 
        /// </summary>
        public string AdminGUID
        {
            set { _adminguid = value; }
            get { return _adminguid; }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        public string AdminID
        {
            set { _adminid = value; }
            get { return _adminid; }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string AdminPSW
        {
            set { _adminpsw = value; }
            get { return _adminpsw; }
        }
        /// <summary>
        /// 管理员名称
        /// </summary>
        public string AdminName
        {
            set { _adminname = value; }
            get { return _adminname; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model
    }
}