using System;

namespace weipin.admin.ajaxservice
{
    public partial class Orders : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string value = string.Empty;
                string strParam = Request.Form["ptype"];
                if (strParam != null)
                {
                    switch (strParam)
                    {
                        case "UpdateOrdersOutLibraryByOrderID":
                            value = UpdateOrdersOutLibraryByOrderID();
                            break;
                        case "UpdateOrdersAndGoodsOutLibraryByOrderID":
                            value = UpdateOrdersAndGoodsOutLibraryByOrderID();
                            break;
                        case "UpdateOrdersAndGoodsByID":
                            value = UpdateOrdersAndGoodsByID();
                            break;
                        case "UpdateOrdersAndGoodsExtractGoodsByOrderID":
                            value = UpdateOrdersAndGoodsExtractGoodsByOrderID();
                            break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 修改订单交易状态(出库)
        /// </summary>
        /// <returns></returns>
        private string UpdateOrdersOutLibraryByOrderID()
        {
            string _res = string.Empty;
            Model.Orders mo = new weipin.Model.Orders();
            mo.OrderID = Convert.ToInt32(Request.Form["oid"].ToString());
            mo.CourierID = Convert.ToInt32(Request.Form["cid"].ToString());
            string _sql = Request.Form["sql"].ToString();
            string[] _gidarr = Request.Form["gidarr"].ToString().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            BLL.Orders bo = new weipin.BLL.Orders();
            _res = bo.UpdateOrdersOutLibraryByOrderID(mo, _sql).ToString();
            if (_res == "1")
            {
                for (int i = 0; i < _gidarr.Length; i++)
                {
                    BLL.Goods bg = new weipin.BLL.Goods();
                    bg.CreateGoodsShow(Convert.ToInt32(_gidarr[i]), "");
                }
            }
            return _res;
        }
        /// <summary>
        /// 修改订单及商品交易状态(出库)
        /// </summary>
        /// <returns></returns>
        private string UpdateOrdersAndGoodsOutLibraryByOrderID()
        {
            string _res = string.Empty;
            Model.Orders mo = new weipin.Model.Orders();
            mo.OrderID = Convert.ToInt32(Request.Form["oid"].ToString());
            mo.CourierID = Convert.ToInt32(Request.Form["cid"].ToString());
            string _sql = Request.Form["sql"].ToString();
            string[] _gidarr = Request.Form["gidarr"].ToString().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            BLL.Orders bo = new weipin.BLL.Orders();
            _res = bo.UpdateOrdersAndGoodsOutLibraryByOrderID(mo, _sql).ToString();
            if (_res == "1")
            {
                for (int i = 0; i < _gidarr.Length; i++)
                {
                    BLL.Goods bg = new weipin.BLL.Goods();
                    bg.CreateGoodsShow(Convert.ToInt32(_gidarr[i]), "");
                }
            }
            return _res;
        }
        /// <summary>
        /// 修改订单及商品的交易状态
        /// </summary>
        /// <returns></returns>
        private string UpdateOrdersAndGoodsByID()
        {
            string _res = string.Empty;
            BLL.Orders bo = new weipin.BLL.Orders();
            int _orderid = Convert.ToInt32(Request.Form["oid"].ToString());
            byte _orderstatus = Convert.ToByte(Request.Form["orderstatus"].ToString());
            byte _deliveryperiod = Convert.ToByte(Request.Form["deliveryperiod"].ToString());
            byte _addday = bo.CountDeliveryTimePlan(_deliveryperiod);
            string _sql = Request.Form["sql"].ToString();
            string[] _gidarr = Request.Form["gidarr"].ToString().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            _res = bo.UpdateOrdersAndGoodsByID(_orderid, _orderstatus, _addday, _sql).ToString();
            if (_res == "1")
            {
                for (int i = 0; i < _gidarr.Length; i++)
                {
                    BLL.Goods bg = new weipin.BLL.Goods();
                    bg.CreateGoodsShow(Convert.ToInt32(_gidarr[i]), "");
                }
            }
            return _res;
        }
        /// <summary>
        /// 修改订单及商品交易状态(取货)
        /// </summary>
        /// <returns></returns>
        private string UpdateOrdersAndGoodsExtractGoodsByOrderID()
        {
            Model.Orders mo = new weipin.Model.Orders();
            mo.OrderID = Convert.ToInt32(Request.Form["oid"].ToString());
            mo.CourierID = Convert.ToInt32(Request.Form["cid"].ToString());
            //string _sql = Request.Form["sql"].ToString();待删除2012-6-7
            BLL.Orders bo = new weipin.BLL.Orders();
            return bo.UpdateOrdersAndGoodsExtractGoodsByOrderID(mo).ToString();
        }
    }
}