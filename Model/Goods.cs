using System;
namespace weipin.Model
{
    /// <summary>
    /// 实体类Goods 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Goods
    {
        public Goods()
        { }
        #region Model
        private int _goodsid;
        private string _goodsname;
        private string _goodsnamestyle;
        private string _keywords;
        private int _similarnumber;
        private string _differencekeywords;
        private double _marketprice;
        private double _price;
        private double _discountprice;
        private double _goodsweight;
        private string _goodspicturepath;
        private int? _inventory;
        private int? _supplyline;
        private int _salesvolume;
        private int _hittime;
        private int _collecttimes;
        private byte _merchanttype;
        private string _remarks;
        private string _warmprompt;
        private DateTime _addtime;
        private bool _isbargain;
        private bool _iscategorypromotion;
        private bool _iscategorysecondpromotion;
        private bool _isnewrecommend;
        private bool _isseasonrecommend;
        private bool _isgrounding;
        private bool _isdeleted;
        private int _categoryid1;
        private int _categoryid2;
        private int _categoryid3;
        private int _ordersgoodsid;
        /// <summary>
        /// 
        /// </summary>
        public int GoodsID
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName
        {
            set { _goodsname = value; }
            get { return _goodsname; }
        }
        /// <summary>
        /// 商品名称(用于搜索引擎高亮显示)
        /// </summary>
        public string GoodsNameStyle
        {
            get { return _goodsnamestyle; }
            set { _goodsnamestyle = value; }
        }
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }
        /// <summary>
        /// 同类编号
        /// </summary>
        public int SimilarNumber
        {
            get { return _similarnumber; }
            set { _similarnumber = value; }
        }
        /// <summary>
        /// 同类商品不同款的区别关键词
        /// </summary>
        public string DifferenceKeywords
        {
            get { return _differencekeywords; }
            set { _differencekeywords = value; }
        }
        /// <summary>
        /// 市场价
        /// </summary>
        public double MarketPrice
        {
            set { _marketprice = value; }
            get { return _marketprice; }
        }
        /// <summary>
        /// 现价
        /// </summary>
        public double Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 折扣价
        /// </summary>
        public double DiscountPrice
        {
            get { return _discountprice; }
            set { _discountprice = value; }
        }
        /// <summary>
        /// 商品重量(公斤/kg)
        /// </summary>
        public double GoodsWeight
        {
            set { _goodsweight = value; }
            get { return _goodsweight; }
        }
        /// <summary>
        /// 商品主要图片路径
        /// </summary>
        public string GoodsPicturePath
        {
            set { _goodspicturepath = value; }
            get { return _goodspicturepath; }
        }
        /// <summary>
        /// 商品库存数量
        /// </summary>
        public int? Inventory
        {
            set { _inventory = value; }
            get { return _inventory; }
        }
        /// <summary>
        /// 商品库存补给线
        /// </summary>
        public int? SupplyLine
        {
            get { return _supplyline; }
            set { _supplyline = value; }
        }
        /// <summary>
        /// 销量
        /// </summary>
        public int SalesVolume
        {
            set { _salesvolume = value; }
            get { return _salesvolume; }
        }
        /// <summary>
        /// 点击次数
        /// </summary>
        public int HitTime
        {
            set { _hittime = value; }
            get { return _hittime; }
        }
        /// <summary>
        /// 收藏次数
        /// </summary>
        public int CollectTimes
        {
            set { _collecttimes = value; }
            get { return _collecttimes; }
        }
        /// <summary>
        /// 商家类型
        /// </summary>
        public byte MerchantType
        {
            get { return _merchanttype; }
            set { _merchanttype = value; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        /// <summary>
        /// 温馨提示
        /// </summary>
        public string WarmPrompt
        {
            get { return _warmprompt; }
            set { _warmprompt = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 是否为特价商品(1:是;0:否)
        /// </summary>
        public bool IsBargain
        {
            set { _isbargain = value; }
            get { return _isbargain; }
        }
        /// <summary>
        /// 是否为分类置顶促销商品(1:是;0:否)
        /// </summary>
        public bool IsCategoryPromotion
        {
            set { _iscategorypromotion = value; }
            get { return _iscategorypromotion; }
        }
        /// <summary>
        /// 是否为专题二级分类置顶促销商品(1:是;0:否)
        /// </summary>
        public bool IsCategorySecondPromotion
        {
            get { return _iscategorysecondpromotion; }
            set { _iscategorysecondpromotion = value; }
        }
        /// <summary>
        /// 是否为专题新品推荐商品(1:是;0:否)
        /// </summary>
        public bool IsNewRecommend
        {
            get { return _isnewrecommend; }
            set { _isnewrecommend = value; }
        }
        /// <summary>
        /// 是否为新品推荐商品(1:是;0:否)
        /// </summary>
        public bool IsSeasonRecommend
        {
            get { return _isseasonrecommend; }
            set { _isseasonrecommend = value; }
        }
        /// <summary>
        /// 是否是上架的商品(1:是;0:否)
        /// </summary>
        public bool IsGrounding
        {
            set { _isgrounding = value; }
            get { return _isgrounding; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted
        {
            set { _isdeleted = value; }
            get { return _isdeleted; }
        }
        /// <summary>
        /// 商品所属分类(此为第一级分类)
        /// </summary>
        public int CategoryID1
        {
            get { return _categoryid1; }
            set { _categoryid1 = value; }
        }
        /// <summary>
        /// 商品所属分类(此为第二级分类)
        /// </summary>
        public int CategoryID2
        {
            get { return _categoryid2; }
            set { _categoryid2 = value; }
        }
        /// <summary>
        /// 商品所属分类(此为第三级分类)
        /// </summary>
        public int CategoryID3
        {
            get { return _categoryid3; }
            set { _categoryid3 = value; }
        }
        /// <summary>
        /// 订单商品ID(外)
        /// </summary>
        public int OrdersGoodsID
        {
            get { return _ordersgoodsid; }
            set { _ordersgoodsid = value; }
        }
        #endregion Model
    }
}