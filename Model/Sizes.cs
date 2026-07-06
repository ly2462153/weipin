using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类Sizes 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Sizes
    {
        public Sizes()
        { }
        #region Model
        private int _sizeid;
        private string _sizename;
        private int _ordernum;
        private DateTime _updatetime;
        private bool _isdeleted;
        /// <summary>
        /// 
        /// </summary>
        public int SizeID
        {
            set { _sizeid = value; }
            get { return _sizeid; }
        }
        /// <summary>
        /// 尺码名称(如:S/M/L/26cm-28cm)
        /// </summary>
        public string SizeName
        {
            set { _sizename = value; }
            get { return _sizename; }
        }
        /// <summary>
        /// 排序码(0:最大，排名最靠前)
        /// </summary>
        public int OrderNum
        {
            set { _ordernum = value; }
            get { return _ordernum; }
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
        /// 
        /// </summary>
        public bool IsDeleted
        {
            set { _isdeleted = value; }
            get { return _isdeleted; }
        }
        #endregion Model
    }
}