using System.Collections.Generic;

namespace weipin.Model
{
    public class DataList<T> where T : new()
    {
        private int _total;
        private int _integraltotle;
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
        /// 我的积分总和(用于查询我的积分列表中查询出我的积分总和)
        /// </summary>
        public int IntegralTotle
        {
            get { return _integraltotle; }
            set { _integraltotle = value; }
        }
        /// <summary>
        /// 数据行
        /// </summary>
        public List<T> Rows
        {
            get
            {
                if (_rows == null) { _rows = new List<T>(); }
                return _rows;
            }
            set { _rows = value; }
        }
    }
}