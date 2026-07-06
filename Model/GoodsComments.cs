using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类GoodsComments 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class GoodsComments
    {
        public GoodsComments()
        { }
        #region Model
        private int _commentid;
        private int _goodsid;
        private string _loginid;
        private int _ordersgoodsid;
        private int _similarnumber;
        private byte _appearancegrade;
        private byte _qualitygrade;
        private int _commentgrade;
        private string _commentcontent;
        private DateTime _addtime;
        private int _commentstatus;
        private int _orderid;
        private DateTime deliverytime;
        private string _goodspicturepath;
        private bool _iscommented;
        /// <summary>
        /// 
        /// </summary>
        public int CommentID
        {
            set { _commentid = value; }
            get { return _commentid; }
        }
        /// <summary>
        /// 被评价商品ID(外)
        /// </summary>
        public int GoodsID
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        /// <summary>
        /// 评价人登录名
        /// </summary>
        public string LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 订单商品ID(外)
        /// </summary>
        public int OrdersGoodsID
        {
            get { return _ordersgoodsid; }
            set { _ordersgoodsid = value; }
        }
        /// <summary>
        /// 同类编号(同款商品款式/颜色不同,这些商品的同类编号相同)
        /// </summary>
        public int SimilarNumber
        {
            get { return _similarnumber; }
            set { _similarnumber = value; }
        }
        /// <summary>
        /// 外观评价等级(分5个等级[1:差评;2/3:中评;4/5:好评])
        /// </summary>
        public byte AppearanceGrade
        {
            get { return _appearancegrade; }
            set { _appearancegrade = value; }
        }
        /// <summary>
        /// 质量评价等级(分5个等级[1:差评;2/3:中评;4/5:好评])
        /// </summary>
        public byte QualityGrade
        {
            get { return _qualitygrade; }
            set { _qualitygrade = value; }
        }
        /// <summary>
        /// 综合评价等级(分5个等级[1:差评;2/3:中评;4/5:好评])
        /// </summary>
        public int CommentGrade
        {
            set { _commentgrade = value; }
            get { return _commentgrade; }
        }
        /// <summary>
        /// 评价内容
        /// </summary>
        public string CommentContent
        {
            set { _commentcontent = value; }
            get { return _commentcontent; }
        }
        /// <summary>
        /// 评价时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 评价状态(1:待审核;2:审核通过;3:审核不通过)
        /// </summary>
        public int CommentStatus
        {
            set { _commentstatus = value; }
            get { return _commentstatus; }
        }
        /// <summary>
        /// 订单ID(外)
        /// </summary>
        public int OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        /// <summary>
        /// 订单实际送达时间
        /// </summary>
        public DateTime DeliveryTime
        {
            get { return deliverytime; }
            set { deliverytime = value; }
        }
        /// <summary>
        /// 商品图片(此处拼接了多个字段值)
        /// </summary>
        public string GoodsPicturePath
        {
            get { return _goodspicturepath; }
            set { _goodspicturepath = value; }
        }
        /// <summary>
        /// 是否已评论(1:是;0:否)
        /// </summary>
        public bool IsCommented
        {
            get { return _iscommented; }
            set { _iscommented = value; }
        }
        #endregion Model
    }
}