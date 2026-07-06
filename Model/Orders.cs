using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类Orders 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Orders
    {
        public Orders()
        { }
        #region Model
        private int _orderid;
        private string _loginid;
        private int _courierid;
        private int _areaid;
        private string _areaname;
        private string _consigneename;
        private string _shippingaddress;
        private string _mobilephone;
        private string _telephone;
        private string _email;
        private string _zipcode;
        private DateTime _addtime;
        private DateTime _deliverytimeplan;
        private DateTime _deliverytime;
        private byte _deliveryperiod;
        private byte _ordersstatus;
        private byte _logisticsstatus;
        private byte _logisticstimes;
        private byte _payway;
        private bool _ispay;
        private string _remarks;
        private string _exchangereturnreasons;
        private int _ordersgoodsid;
        private string _sizename;
        private int _goodscount;
        private byte _goodsstatus;
        private double _transactionprice;
        private int _completecount;
        private double _completeamount;
        private int _goodsid;
        private string _goodsname;
        private double _price;
        private double _discountprice;
        private double _goodsweight;
        private string _goodspicturepath;
        private string _couriername;
        private bool _iscancel;
        private bool _iscommented;
        private int _orderscount;
        private double _orderamount;
        /// <summary>
        /// 
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 用户登录名(外)
        /// </summary>
        public string LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 快递员ID(外)
        /// </summary>
        public int CourierID
        {
            set { _courierid = value; }
            get { return _courierid; }
        }
        /// <summary>
        /// 区域ID(外)
        /// </summary>
        public int AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string AreaName
        {
            get { return _areaname; }
            set { _areaname = value; }
        }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string ConsigneeName
        {
            set { _consigneename = value; }
            get { return _consigneename; }
        }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string ShippingAddress
        {
            set { _shippingaddress = value; }
            get { return _shippingaddress; }
        }
        /// <summary>
        /// 收货人手机
        /// </summary>
        public string MobilePhone
        {
            set { _mobilephone = value; }
            get { return _mobilephone; }
        }
        /// <summary>
        /// 座机
        /// </summary>
        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }
        /// <summary>
        /// 收货人邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 收货地址的邮编
        /// </summary>
        public string Zipcode
        {
            set { _zipcode = value; }
            get { return _zipcode; }
        }
        /// <summary>
        /// 订单提交时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 订单预计送达时间(此时间前送达)
        /// </summary>
        public DateTime DeliveryTimePlan
        {
            set { _deliverytimeplan = value; }
            get { return _deliverytimeplan; }
        }
        /// <summary>
        /// 订单实际送达时间
        /// </summary>
        public DateTime DeliveryTime
        {
            set { _deliverytime = value; }
            get { return _deliverytime; }
        }
        /// <summary>
        /// 送货时间(1:只工作日送货(双休日、假日不用送);2:工作日、双休日与假日均可送货;3:只双休日、假日送货(工作日不用送))
        /// </summary>
        public byte DeliveryPeriod
        {
            get { return _deliveryperiod; }
            set { _deliveryperiod = value; }
        }
        /// <summary>
        /// 订单交易状态(1:订货;2:出库(取货);3:换货;4:退货;5:退货完成;6:交易成功)
        /// </summary>
        public byte OrdersStatus
        {
            set { _ordersstatus = value; }
            get { return _ordersstatus; }
        }
        /// <summary>
        /// 物流状态(1:处理中;2:已发货;3:已完成;)
        /// </summary>
        public byte LogisticsStatus
        {
            set { _logisticsstatus = value; }
            get { return _logisticsstatus; }
        }
        /// <summary>
        /// 物流次数
        /// </summary>
        public byte LogisticsTimes
        {
            set { _logisticstimes = value; }
            get { return _logisticstimes; }
        }
        /// <summary>
        /// 付款方式(1:货到付款;2:支付宝)
        /// </summary>
        public byte PayWay
        {
            get { return _payway; }
            set { _payway = value; }
        }
        /// <summary>
        /// 是否已付款(1:是;0:否)
        /// </summary>
        public bool IsPay
        {
            get { return _ispay; }
            set { _ispay = value; }
        }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
        /// <summary>
        /// 退换货理由
        /// </summary>
        public string ExchangeReturnReasons
        {
            set { _exchangereturnreasons = value; }
            get { return _exchangereturnreasons; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrdersGoodsID
        {
            get { return _ordersgoodsid; }
            set { _ordersgoodsid = value; }
        }
        /// <summary>
        /// 尺码
        /// </summary>
        public string SizeName
        {
            get { return _sizename; }
            set { _sizename = value; }
        }
        /// <summary>
        /// 订购商品数量
        /// </summary>
        public int GoodsCount
        {
            get { return _goodscount; }
            set { _goodscount = value; }
        }
        /// <summary>
        /// 商品交易状态(1:订货;3:换货;4:退货;5:退货成功;6:交易成功)
        /// </summary>
        public byte GoodsStatus
        {
            get { return _goodsstatus; }
            set { _goodsstatus = value; }
        }
        /// <summary>
        /// 成交单价
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
            get { return _completecount; }
            set { _completecount = value; }
        }
        /// <summary>
        /// 实际成交商品总价(商品单价*实际成交商品数量)
        /// </summary>
        public double CompleteAmount
        {
            get { return _completeamount; }
            set { _completeamount = value; }
        }
        /// <summary>
        /// GoodsID(外)
        /// </summary>
        public int GoodsID
        {
            get { return _goodsid; }
            set { _goodsid = value; }
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
        /// 现价
        /// </summary>
        public double Price
        {
            get { return _price; }
            set { _price = value; }
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
            get { return _goodsweight; }
            set { _goodsweight = value; }
        }
        /// <summary>
        /// 商品主要图片路径
        /// </summary>
        public string GoodsPicturePath
        {
            get { return _goodspicturepath; }
            set { _goodspicturepath = value; }
        }
        /// <summary>
        /// 快递员姓名
        /// </summary>
        public string CourierName
        {
            get { return _couriername; }
            set { _couriername = value; }
        }
        /// <summary>
        /// 是否为已取消订单(1:是;0:否)
        /// </summary>
        public bool IsCancel
        {
            get { return _iscancel; }
            set { _iscancel = value; }
        }
        /// <summary>
        /// 是否已评论(1:是;0:否)
        /// </summary>
        public bool IsCommented
        {
            get { return _iscommented; }
            set { _iscommented = value; }
        }
        /// <summary>
        /// 订单数量统计
        /// </summary>
        public int OrdersCount
        {
            get { return _orderscount; }
            set { _orderscount = value; }
        }
        /// <summary>
        /// 订单总金额(用于支付宝付款查询出的订单总金额)
        /// </summary>
        public double OrderAmount
        {
            get { return _orderamount; }
            set { _orderamount = value; }
        }
        #endregion Model
    }
}