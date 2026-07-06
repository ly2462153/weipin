using System;
namespace weipin.Model
{
    /// <summary>
    /// 实体类EmailStatistics 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class EmailStatistics
    {
        public EmailStatistics()
        { }
        #region Model
        private int _statisticsid;
        private string _internetip;
        private string _lanip;
        private string _useriparea;
        private int _visittimes;
        private DateTime _addtime;
        private DateTime _updatetime;
        private string _versionnum;
        /// <summary>
        /// 
        /// </summary>
        public int StatisticsID
        {
            set { _statisticsid = value; }
            get { return _statisticsid; }
        }
        /// <summary>
        /// 互联网IP
        /// </summary>
        public string InternetIP
        {
            set { _internetip = value; }
            get { return _internetip; }
        }
        /// <summary>
        /// 局域网IP
        /// </summary>
        public string LanIP
        {
            set { _lanip = value; }
            get { return _lanip; }
        }
        /// <summary>
        /// 用户IP区域(如:四川成都)
        /// </summary>
        public string UserIPArea
        {
            set { _useriparea = value; }
            get { return _useriparea; }
        }
        /// <summary>
        /// 打开邮件次数
        /// </summary>
        public int VisitTimes
        {
            set { _visittimes = value; }
            get { return _visittimes; }
        }
        /// <summary>
        /// 第一次打开邮件时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 最后一次打开邮件时间
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 版本编号
        /// </summary>
        public string VersionNum
        {
            get { return _versionnum; }
            set { _versionnum = value; }
        }
        #endregion Model
    }
}