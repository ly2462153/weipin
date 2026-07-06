using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类Categories_Goods 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Categories_Goods
    {
        public Categories_Goods()
        { }
        #region Model
        private int _categorygoodsid;
        private int _categoryid;
        private int _goodsid;
        /// <summary>
        /// 
        /// </summary>
        public int CategoryGoodsID
        {
            set { _categorygoodsid = value; }
            get { return _categorygoodsid; }
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
        /// 商品(外)
        /// </summary>
        public int GoodsID
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        #endregion Model
    }
}