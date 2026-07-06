using System;
namespace weipin.Model
{
    /// <summary>
    /// 实体类Integral
    /// </summary>
    [Serializable]
    public class Integral
    {
        public Integral()
        { }
        #region Model
        private int _integralid;
        private int? _ordersgoodsid;
        private string _loginid;
        private int _integralnum;
        private int _soursetype;
        private DateTime _effectivetime;
        private bool _iseffect;
        private int? _orderid;
        /// <summary>
        /// 
        /// </summary>
        public int IntegralID
        {
            set { _integralid = value; }
            get { return _integralid; }
        }
        /// <summary>
        /// 订单商品ID(外)
        /// </summary>
        public int? OrdersGoodsID
        {
            set { _ordersgoodsid = value; }
            get { return _ordersgoodsid; }
        }
        /// <summary>
        /// 登录名(外)
        /// </summary>
        public string LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int IntegralNum
        {
            set { _integralnum = value; }
            get { return _integralnum; }
        }
        /// <summary>
        /// 来源方式(1:评论;2:购买;验证邮箱)
        /// </summary>
        public int SourseType
        {
            set { _soursetype = value; }
            get { return _soursetype; }
        }
        /// <summary>
        /// 积分生效时间
        /// </summary>
        public DateTime EffectiveTime
        {
            set { _effectivetime = value; }
            get { return _effectivetime; }
        }
        /// <summary>
        /// 是否已生效(1:是;0:否)
        /// </summary>
        public bool IsEffect
        {
            set { _iseffect = value; }
            get { return _iseffect; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public int? OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        #endregion Model
    }
}