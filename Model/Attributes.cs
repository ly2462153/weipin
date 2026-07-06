using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类Attributes 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Attributes
    {
        public Attributes()
        { }
        #region Model
        private int _attributeid;
        private int _categoryid;
        private string _attributename;
        private DateTime _updatetime;
        private int _attributevalueid;
        private string _attributevaluename;
        /// <summary>
        /// 
        /// </summary>
        public int AttributeID
        {
            set { _attributeid = value; }
            get { return _attributeid; }
        }
        /// <summary>
        /// 分类ID(外)
        /// </summary>
        public int CategoryID
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string AttributeName
        {
            set { _attributename = value; }
            get { return _attributename; }
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
        /// 属性值ID
        /// </summary>
        public int AttributeValueID
        {
            get { return _attributevalueid; }
            set { _attributevalueid = value; }
        }
        /// <summary>
        /// 属性值名称
        /// </summary>
        public string AttributeValueName
        {
            get { return _attributevaluename; }
            set { _attributevaluename = value; }
        }
        #endregion Model
    }
}