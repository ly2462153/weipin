using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类AttributeValues 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class AttributeValues
    {
        public AttributeValues()
        { }
        #region Model
        private int _attributevalueid;
        private int _attributeid;
        private string _attributevaluename;
        private DateTime _updatetime;
        /// <summary>
        /// 
        /// </summary>
        public int AttributeValueID
        {
            set { _attributevalueid = value; }
            get { return _attributevalueid; }
        }
        /// <summary>
        /// 属性ID(外)
        /// </summary>
        public int AttributeID
        {
            set { _attributeid = value; }
            get { return _attributeid; }
        }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string AttributeValueName
        {
            set { _attributevaluename = value; }
            get { return _attributevaluename; }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        #endregion Model
    }
}