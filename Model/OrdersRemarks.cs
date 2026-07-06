using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类OrdersRemarks 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class OrdersRemarks
    {
        public OrdersRemarks()
        { }
        #region Model
        private int _ordersremarkid;
        private int _orderid;
        private int _ordersgoodsid;
        private int _goodsid;
        private string _goodsname;
        private int _courierid;
        private string _couriername;
        private string _loginid;
        private int _logisticstimes;
        private int _completecount;
        private double _completeamount;
        private int _inventory;
        private int _salesvolume;
        private int _deliverytimes;
        private DateTime _ordertime;
        private DateTime _addtime;
        private string _remarks;
        /// <summary>
        /// 
        /// </summary>
        public int OrdersRemarkID
        {
            set { _ordersremarkid = value; }
            get { return _ordersremarkid; }
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
        /// Orders_Goods表(外)
        /// </summary>
        public int OrdersGoodsID
        {
            set { _ordersgoodsid = value; }
            get { return _ordersgoodsid; }
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
        /// 快递员ID(外)
        /// </summary>
        public int CourierID
        {
            set { _courierid = value; }
            get { return _courierid; }
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
        /// 用户ID(外)
        /// </summary>
        public string LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 物流次数(Orders)
        /// </summary>
        public int LogisticsTimes
        {
            set { _logisticstimes = value; }
            get { return _logisticstimes; }
        }
        /// <summary>
        /// 实际成交商品数量(同时Users中的CompleteCount也记录于此字段)(Orders_Goods)
        /// </summary>
        public int CompleteCount
        {
            set { _completecount = value; }
            get { return _completecount; }
        }
        /// <summary>
        /// 实际成交商品总价(商品单价*实际成交商品数量)(同时"Users中的Monetary"、"Couriers中的DeliveryAmount"也记录于此字段)(Orders_Goods)
        /// </summary>
        public double CompleteAmount
        {
            set { _completeamount = value; }
            get { return _completeamount; }
        }
        /// <summary>
        /// 商品库存数量(Goods)
        /// </summary>
        public int Inventory
        {
            set { _inventory = value; }
            get { return _inventory; }
        }
        /// <summary>
        /// 销量(Goods)
        /// </summary>
        public int SalesVolume
        {
            set { _salesvolume = value; }
            get { return _salesvolume; }
        }
        /// <summary>
        /// 送货商品量(如果1张订单有3条商品数据,则此快递员送货商品量为3)(Couriers)
        /// </summary>
        public int DeliveryTimes
        {
            set { _deliverytimes = value; }
            get { return _deliverytimes; }
        }
        /// <summary>
        /// 订单发生日期
        /// </summary>
        public DateTime OrderTime
        {
            set { _ordertime = value; }
            get { return _ordertime; }
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
        /// 订单交易问题的备注、记录等
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        #endregion Model
    }
}