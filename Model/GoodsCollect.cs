using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类GoodsCollect 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class GoodsCollect
    {
        public GoodsCollect()
        { }
        #region Model
        private long _collectid;
        private string _loginid;
        private int _goodsid;
        private DateTime _addtime;
        private string _goodsname;
        private string _goodspicturepath;
        private double _price;
        private double _discountprice;
        /// <summary>
        /// 
        /// </summary>
        public long CollectID
        {
            set { _collectid = value; }
            get { return _collectid; }
        }
        /// <summary>
        /// 收藏人登录名
        /// </summary>
        public string LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 收藏的商品
        /// </summary>
        public int GoodsID
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        /// <summary>
        /// 收藏时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName
        {
            get { return _goodsname; }
            set { _goodsname = value; }
        }
        /// <summary>
        /// 商品图片路径
        /// </summary>
        public string GoodsPicturePath
        {
            get { return _goodspicturepath; }
            set { _goodspicturepath = value; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        /// <summary>
        /// 抢购价
        /// </summary>
        public double DiscountPrice
        {
            get { return _discountprice; }
            set { _discountprice = value; }
        }
        #endregion Model
    }
}