using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类Categories 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Categories
    {
        public Categories()
        { }
        #region Model
        private int _categoryid;
        private int _parentid;
        private string _categoryname;
        private DateTime _updatetime;
        private string _remarks;
        private int _ordernum;
        private bool _ishighlight;
        private bool _isdeleted;
        /// <summary>
        /// 
        /// </summary>
        public int CategoryID
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 父级分类ID
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName
        {
            set { _categoryname = value; }
            get { return _categoryname; }
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
        /// 备注
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        /// <summary>
        /// 分类排序标识(0:最大，排名最靠前)
        /// </summary>
        public int OrderNum
        {
            set { _ordernum = value; }
            get { return _ordernum; }
        }
        /// <summary>
        /// 是否为高亮显示(1:是;0:否)
        /// </summary>
        public bool IsHighlight
        {
            set { _ishighlight = value; }
            get { return _ishighlight; }
        }
        /// <summary>
        /// 是否为已删除文档(1:是;0:否)
        /// </summary>
        public bool IsDeleted
        {
            set { _isdeleted = value; }
            get { return _isdeleted; }
        }
        #endregion Model
    }
}