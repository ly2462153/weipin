using System.Collections.Generic;

namespace weipin.Model
{
    public class GoodsCommentsList<T> where T : new()
    {
        private int _total;
        private int _goodcomment;
        private int _mediumcomment;
        private int _badcomment;
        private int _totalpoints;
        private List<T> _rows;

        /// <summary>
        /// 数据总条数
        /// </summary>
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }
        /// <summary>
        /// 好评数
        /// </summary>
        public int GoodComment
        {
            get { return _goodcomment; }
            set { _goodcomment = value; }
        }
        /// <summary>
        /// 中评数
        /// </summary>
        public int MediumComment
        {
            get { return _mediumcomment; }
            set { _mediumcomment = value; }
        }
        /// <summary>
        /// 差评数
        /// </summary>
        public int BadComment
        {
            get { return _badcomment; }
            set { _badcomment = value; }
        }
        /// <summary>
        /// 总分数
        /// </summary>
        public int TotalPoints
        {
            get { return _totalpoints; }
            set { _totalpoints = value; }
        }
        /// <summary>
        /// 数据行
        /// </summary>
        public List<T> Rows
        {
            get
            {
                if (_rows == null)
                {
                    _rows = new List<T>();
                }
                return _rows;
            }
            set { _rows = value; }
        }
    }
}