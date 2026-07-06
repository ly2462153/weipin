using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Collections.Generic;
using weipin.Model;

namespace weipin.admin
{
    public partial class OrdersSearchGoodsList : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.Commonality.JudgeNumber(Request.Form["txtSearch"], 10)) { BindOrdersByOrderID(Convert.ToInt32(Request.Form["txtSearch"].ToString())); }
            else { divShow.Visible = false; }
        }
        /// <summary>
        /// 绑定搜到的订单
        /// <param name="_oid">订单ID</param>
        /// </summary>
        private void BindOrdersByOrderID(int _oid)
        {
            BLL.Orders bo = new weipin.BLL.Orders();
            DataSet ds = bo.SelectOrdersByID(_oid);
            if (ds != null && ds.Tables[0] != null && ds.Tables[1] != null)
            {
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    lblOrderID.InnerText = ds.Tables[0].Rows[0]["OrderID"].ToString();
                    lblLoginID.InnerText = ds.Tables[0].Rows[0]["LoginID"].ToString();
                    aPrint.HRef = "OrdersPrint.aspx?oid=" + ds.Tables[0].Rows[0]["OrderID"].ToString();
                    aPrint.Target = "_blank";
                    lblConsigneeName.InnerText = ds.Tables[0].Rows[0]["ConsigneeName"].ToString();
                    lblCourierName.InnerText = ds.Tables[0].Rows[0]["CourierName"].ToString();
                    divShippingAddress.InnerText = GetAddress(Convert.ToInt16(ds.Tables[0].Rows[0]["AreaID"].ToString())) + "-" + ds.Tables[0].Rows[0]["ShippingAddress"].ToString();
                    lblMobilePhone.InnerText = ds.Tables[0].Rows[0]["MobilePhone"].ToString();
                    lblTelePhone.InnerText = ds.Tables[0].Rows[0]["TelePhone"].ToString();
                    lblEmail.InnerText = ds.Tables[0].Rows[0]["Email"].ToString();
                    lblZipcode.InnerText = ds.Tables[0].Rows[0]["Zipcode"].ToString();
                    lblAddTime.InnerText = ds.Tables[0].Rows[0]["AddTime"].ToString();
                    lblDeliveryTimePlan.InnerText = Convert.ToDateTime(ds.Tables[0].Rows[0]["DeliveryTimePlan"].ToString()).ToShortDateString();
                    lblDeliveryTime.InnerText = ds.Tables[0].Rows[0]["DeliveryTime"].ToString();
                    byte _deliveryperiod = Convert.ToByte(ds.Tables[0].Rows[0]["DeliveryPeriod"].ToString());
                    switch (_deliveryperiod)
                    {
                        case 1: lblDeliveryPeriod.InnerText = "只工作日送货(双休日、假日不用送)"; break;
                        case 2: lblDeliveryPeriod.InnerText = "工作日、双休日与假日均可送货"; break;
                        case 3: lblDeliveryPeriod.InnerText = "只双休日、假日送货(工作日不用送)"; break;
                    }
                    byte _ordersstatus = Convert.ToByte(ds.Tables[0].Rows[0]["OrdersStatus"].ToString());
                    switch (_ordersstatus)
                    {
                        case 1: lblOrdersStatus.InnerText = "订货"; break;
                        case 2: lblOrdersStatus.InnerText = "出库(取货)"; break;
                        case 3: lblOrdersStatus.InnerText = "换货"; break;
                        case 4: lblOrdersStatus.InnerText = "退货"; break;
                        case 5: lblOrdersStatus.InnerText = "退货成功"; break;
                        case 6: lblOrdersStatus.InnerText = "交易成功"; break;
                    }
                    byte _logisticsstatus = Convert.ToByte(ds.Tables[0].Rows[0]["LogisticsStatus"].ToString());
                    switch (_logisticsstatus)
                    {
                        case 1: lblLogisticsStatus.InnerText = "处理中"; break;
                        case 2: lblLogisticsStatus.InnerText = "已发货"; break;
                        case 3: lblLogisticsStatus.InnerText = "已完成"; break;
                    }
                    lblLogisticsTimes.InnerText = ds.Tables[0].Rows[0]["LogisticsTimes"].ToString();
                    divRemarks.InnerHtml = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    divExchangeReturnReasons.InnerHtml = ds.Tables[0].Rows[0]["ExchangeReturnReasons"].ToString();
                    //该订单下的商品列表
                    rptOrdersSearchGoodsList.DataSource = ds.Tables[1];
                    rptOrdersSearchGoodsList.DataBind();
                }
                else { divShow.Visible = false; }
            }
            else { divShow.Visible = false; }
        }
        /// <summary>
        /// 获取地址
        /// </summary>
        /// <param name="_areaid">区域ID</param>
        /// <returns></returns>
        private string GetAddress(int _areaid)
        {
            string _area = string.Empty;
            string _path = Server.MapPath("~/xml/areas/areas.xml");
            if (System.IO.File.Exists(_path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_path);
                XmlNodeList nodelist = doc.GetElementsByTagName("ar");
                if (nodelist.Count > 0)
                {
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        if (_areaid.ToString() == nodelist[i].Attributes["ai"].Value && Common.Commonality.JudgeNumber(nodelist[i].Attributes["ai"].Value, 5))
                        {
                            _area = nodelist[i].ParentNode.ParentNode.Attributes["an"].Value + "-" + nodelist[i].ParentNode.Attributes["an"].Value + "-" + nodelist[i].Attributes["an"].Value;
                            break;
                        }
                    }
                }
            }
            return _area;
        }
    }
}