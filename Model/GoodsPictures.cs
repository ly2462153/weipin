using System;

namespace weipin.Model
{
    /// <summary>
    /// 实体类GoodsPictures 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class GoodsPictures
    {
        public GoodsPictures()
        { }
        #region Model
        private int _goodspictureid;
        private int _goodsid;
        private string _picturepath;
        /// <summary>
        /// 
        /// </summary>
        public int GoodsPictureID
        {
            set { _goodspictureid = value; }
            get { return _goodspictureid; }
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
        /// 商品图片路径
        /// </summary>
        public string PicturePath
        {
            set { _picturepath = value; }
            get { return _picturepath; }
        }
        #endregion Model
    }
}