using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类Orders_Goods 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Orders_Goods
    {
        public Orders_Goods()
        { }
        #region Model
        private int _ordersgoodsid;
        private int _orderid;
        private int _goodsid;
        private string _goodsname;
        private string _loginid;
        private int _courierid;
        private string _sizename;
        private int _goodscount;
        private byte _goodsstatus;
        private double _transactionprice;
        private int _completecount;
        private double _completeamount;
        private string goodspicturepath;
        /// <summary>
        /// 
        /// </summary>
        public int OrdersGoodsID
        {
            set { _ordersgoodsid = value; }
            get { return _ordersgoodsid; }
        }
        /// <summary>
        /// 订单ID(外)
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
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
        /// 商品名称
        /// </summary>
        public string GoodsName
        {
            get { return _goodsname; }
            set { _goodsname = value; }
        }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string LoginID
        {
            get { return _loginid; }
            set { _loginid = value; }
        }
        /// <summary>
        /// 快递员ID
        /// </summary>
        public int CourierID
        {
            get { return _courierid; }
            set { _courierid = value; }
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
        /// 订购商品数量
        /// </summary>
        public int GoodsCount
        {
            set { _goodscount = value; }
            get { return _goodscount; }
        }
        /// <summary>
        /// 商品交易状态
        /// </summary>
        public byte GoodsStatus
        {
            get { return _goodsstatus; }
            set { _goodsstatus = value; }
        }
        /// <summary>
        /// 商品成交单价
        /// </summary>
        public double TransactionPrice
        {
            get { return _transactionprice; }
            set { _transactionprice = value; }
        }
        /// <summary>
        /// 实际成交商品数量
        /// </summary>
        public int CompleteCount
        {
            set { _completecount = value; }
            get { return _completecount; }
        }
        /// <summary>
        /// 实际成交商品总价(商品单价*实际成交商品数量)
        /// </summary>
        public double CompleteAmount
        {
            set { _completeamount = value; }
            get { return _completeamount; }
        }
        /// <summary>
        /// 商品主要图片路径
        /// </summary>
        public string GoodsPicturePath
        {
            get { return goodspicturepath; }
            set { goodspicturepath = value; }
        }
        #endregion Model
    }
}