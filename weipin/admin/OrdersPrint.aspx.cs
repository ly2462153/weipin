using System;
using System.Xml;

namespace weipin.admin
{
    public partial class OrdersPrint : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.Commonality.JudgeNumber(Request.QueryString["oid"], 10))
            {
                BindOrders(Convert.ToInt32(Request.QueryString["oid"].ToString()));
            }
        }
        /// <summary>
        /// 绑定订单
        /// <param name="oid">订单号</param>
        /// </summary>
        private void BindOrders(int oid)
        {
            Model.Orders mo = new weipin.Model.Orders();
            BLL.Orders bos = new weipin.BLL.Orders();
            System.Data.DataSet ds = bos.SelectOrdersByID(oid);
            if (ds != null && ds.Tables[0] != null && ds.Tables[1] != null)
            {
                spOrderID1.InnerText = ds.Tables[0].Rows[0]["OrderID"].ToString();
                spOrderID2.InnerText = ds.Tables[0].Rows[0]["OrderID"].ToString();
                spOrderTime1.InnerText = ds.Tables[0].Rows[0]["AddTime"].ToString();
                spOrderTime2.InnerText = ds.Tables[0].Rows[0]["AddTime"].ToString();
                spConsigneeName1.InnerText = ds.Tables[0].Rows[0]["ConsigneeName"].ToString();
                spConsigneeName2.InnerText = ds.Tables[0].Rows[0]["ConsigneeName"].ToString();
                if (ds.Tables[0].Rows[0]["MobilePhone"].ToString() != "")
                {
                    spPhone1.InnerText = ds.Tables[0].Rows[0]["MobilePhone"].ToString();
                    spPhone2.InnerText = ds.Tables[0].Rows[0]["MobilePhone"].ToString();
                }
                else
                {
                    spPhone1.InnerText = ds.Tables[0].Rows[0]["TelePhone"].ToString();
                    spPhone2.InnerText = ds.Tables[0].Rows[0]["TelePhone"].ToString();
                }
                spAddress1.InnerHtml = ds.Tables[0].Rows[0]["ShippingAddress"].ToString();
                spAddress2.InnerText = ds.Tables[0].Rows[0]["ShippingAddress"].ToString();
                string _payway = ds.Tables[0].Rows[0]["PayWay"].ToString();
                if (_payway == "1") { spPayWay1.InnerText = "货到付款"; spPayWay2.InnerText = "货到付款"; }
                else if (_payway == "2") { spPayWay1.InnerText = "支付宝"; spPayWay2.InnerText = "支付宝"; }
                double _ordermoney = 0;
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    _ordermoney += Math.Round(Convert.ToDouble(ds.Tables[1].Rows[i]["TransactionPrice"].ToString()) * Convert.ToDouble(ds.Tables[1].Rows[i]["GoodsCount"].ToString()), 1);
                }
                spOrderMoney1.InnerText = _ordermoney.ToString();
                spOrderMoney2.InnerText = _ordermoney.ToString();
                CountFeight(_ordermoney, Convert.ToInt16(ds.Tables[0].Rows[0]["AreaID"].ToString()));
                spCost1.InnerText = Math.Round(_ordermoney + Convert.ToDouble(spFreight1.InnerText), 1).ToString();
                spCost2.InnerText = Math.Round(_ordermoney + Convert.ToDouble(spFreight1.InnerText), 1).ToString();
            }
        }
        /// <summary>
        /// 计算运费
        /// </summary>
        /// <param name="ordermoney">订单金额</param>
        /// <param name="_areaid">区域ID</param>
        /// <returns></returns>
        private void CountFeight(double ordermoney, int _areaid)
        {
            if (((_areaid > 1 && _areaid < 30 || _areaid > 30 && _areaid < 216 || _areaid > 216 && _areaid < 325 || _areaid > 325 && _areaid < 528 || _areaid > 528 && _areaid < 667 || _areaid > 1142 && _areaid < 1272 || _areaid > 1272 && _areaid < 1377 || _areaid > 1377 && _areaid < 1513 || _areaid > 1513 && _areaid < 1615 || _areaid > 1615 && _areaid < 1737 || _areaid > 1737 && _areaid < 1910 || _areaid > 1910 && _areaid < 2096 || _areaid > 2096 && _areaid < 2219 || _areaid > 2219 && _areaid < 2357 || _areaid > 2357 && _areaid < 2545 || _areaid > 2545 && _areaid < 2670 || _areaid > 2670 && _areaid < 2705 || _areaid > 2705 && _areaid < 2805 || _areaid > 2805 && _areaid < 2957 || _areaid > 3038 && _areaid < 3160) && ordermoney >= 38) || ((_areaid > 667 && _areaid < 785 || _areaid > 785 && _areaid < 915 || _areaid > 915 && _areaid < 991 || _areaid > 991 && _areaid < 1142 || _areaid > 2957 && _areaid < 3038 || _areaid > 3160 && _areaid < 3263 || _areaid > 3263 && _areaid < 3316 || _areaid > 3316 && _areaid < 3346 || _areaid > 3346 && _areaid < 3463) && ordermoney >= 68))
            {
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
                            if (_areaid.ToString() == nodelist[i].Attributes["ai"].Value)
                            {
                                spAddress1.InnerText = nodelist[i].ParentNode.ParentNode.Attributes["an"].Value + "-" + nodelist[i].ParentNode.Attributes["an"].Value + "-" + nodelist[i].Attributes["an"].Value + "-" + spAddress1.InnerText;
                                spAddress2.InnerText = nodelist[i].ParentNode.ParentNode.Attributes["an"].Value + "-" + nodelist[i].ParentNode.Attributes["an"].Value + "-" + nodelist[i].Attributes["an"].Value + "-" + spAddress2.InnerText;
                                spFreight1.InnerText = "0";
                                spFreight2.InnerText = "0";
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
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
                            if (_areaid.ToString() == nodelist[i].Attributes["ai"].Value)
                            {
                                spAddress1.InnerText = nodelist[i].ParentNode.ParentNode.Attributes["an"].Value + "-" + nodelist[i].ParentNode.Attributes["an"].Value + "-" + nodelist[i].Attributes["an"].Value + "-" + spAddress1.InnerText;
                                spAddress2.InnerText = nodelist[i].ParentNode.ParentNode.Attributes["an"].Value + "-" + nodelist[i].ParentNode.Attributes["an"].Value + "-" + nodelist[i].Attributes["an"].Value + "-" + spAddress2.InnerText;
                                spFreight1.InnerText = nodelist[i].Attributes["fr"].Value;
                                spFreight2.InnerText = nodelist[i].Attributes["fr"].Value;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}