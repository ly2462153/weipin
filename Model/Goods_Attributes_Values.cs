using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类Goods_Attributes_Values 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Goods_Attributes_Values
    {
        public Goods_Attributes_Values()
        { }
        #region Model
        private int _goodsattributevalueid;
        private int _goodsid;
        private int _attributeid;
        private int _valueid;
        /// <summary>
        /// 
        /// </summary>
        public int GoodsAttributeValueID
        {
            set { _goodsattributevalueid = value; }
            get { return _goodsattributevalueid; }
        }
        /// <summary>
        /// 商品ID(外)
        /// </summary>
        public int GoodsID
        {
            set { _goodsid = value; }
            get { return _goodsid; }
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
        /// 属性值ID(外)
        /// </summary>
        public int ValueID
        {
            set { _valueid = value; }
            get { return _valueid; }
        }
        #endregion Model
    }
}