using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类Goods_Sizes 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Goods_Sizes
    {
        public Goods_Sizes()
        { }
        #region Model
        private int _goodssizesid;
        private int _goodsid;
        private int _sizeid;
        /// <summary>
        /// 
        /// </summary>
        public int GoodsSizesID
        {
            set { _goodssizesid = value; }
            get { return _goodssizesid; }
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
        /// 尺码ID(外)
        /// </summary>
        public int SizeID
        {
            set { _sizeid = value; }
            get { return _sizeid; }
        }
        #endregion Model
    }
}