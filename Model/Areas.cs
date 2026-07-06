using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类Areas 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Areas
    {
        public Areas()
        { }
        #region Model
        private int _areaid;
        private int _parentid;
        private string _areaname;
        private int _freight = -1;
        private DateTime _updatetime;
        private bool _isdeleted;
        /// <summary>
        /// 
        /// </summary>
        public int AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string AreaName
        {
            set { _areaname = value; }
            get { return _areaname; }
        }
        /// <summary>
        /// 到达该区域所需运费
        /// </summary>
        public int Freight
        {
            set { _freight = value; }
            get { return _freight; }
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