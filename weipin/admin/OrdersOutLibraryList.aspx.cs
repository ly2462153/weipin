using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Collections.Generic;
using weipin.Model;

namespace weipin.admin
{
    public partial class OrdersOutLibraryList : Common.BasePageAdmin
    {
        public int _index = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindOrdersCountStatistics();
            if (Common.Commonality.JudgeNumber(Request.QueryString["aid"], 10) && Common.Commonality.JudgeNumber(Request.QueryString["dp"], 3))
            {
                BindOrdersOutLibraryList(Convert.ToInt32(Request.QueryString["aid"].ToString()), Convert.ToByte(Request.QueryString["dp"].ToString()), Request.QueryString["cid"]);
                BindAreas(Request.QueryString["aid"].ToString());
                BindOrdersDeliveryPeriods();
                BindCouriers(Request.QueryString["aid"].ToString());
                selDeliveryPeriod.SelectedIndex = selDeliveryPeriod.Items.IndexOf(selDeliveryPeriod.Items.FindByValue(Request.QueryString["dp"].ToString()));
                selCouriers.SelectedIndex = selCouriers.Items.IndexOf(selCouriers.Items.FindByValue(Request.QueryString["cid"]));
            }
            else
            {
                if (Request.Cookies["OrdersAreaID"] != null && Request.Cookies["OrdersDeliveryPeriod"] != null)
                {
                    BindOrdersOutLibraryList(Convert.ToInt32(Request.Cookies["OrdersAreaID"].Value), Convert.ToByte(Request.Cookies["OrdersDeliveryPeriod"].Value), "");
                    BindAreas(Request.Cookies["OrdersAreaID"].Value);
                    BindOrdersDeliveryPeriods();
                    BindCouriers(Request.Cookies["OrdersAreaID"].Value);
                    selDeliveryPeriod.SelectedIndex = selDeliveryPeriod.Items.IndexOf(selDeliveryPeriod.Items.FindByValue(Request.Cookies["OrdersDeliveryPeriod"].Value));
                }
                else
                {
                    BindAreas("");
                    BindOrdersDeliveryPeriods();
                    if (Request.Cookies["OrdersDeliveryPeriod"] != null)
                    {
                        selDeliveryPeriod.SelectedIndex = selDeliveryPeriod.Items.IndexOf(selDeliveryPeriod.Items.FindByValue(Request.Cookies["OrdersDeliveryPeriod"].Value));
                    }
                    BindCouriers("");
                    selCouriers.SelectedIndex = selCouriers.Items.IndexOf(selCouriers.Items.FindByValue(Request.QueryString["cid"]));
                    divShowDataCount.Visible = false;
                }
            }
        }
        /// <summary>
        /// 绑定订单数量统计(订单)
        /// </summary>
        private void BindOrdersCountStatistics()
        {
            BLL.Orders bos = new weipin.BLL.Orders();
            List<Model.Orders> lmo = bos.SelectOrdersCountStatisticsByOrdersStatus(2);
            if (lmo != null && lmo.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<table class=\"tb\" style=\"border:1px solid #CFCFCF;margin-top:10px;\"><tr><th>区域</th><th>送货时间</th><th>订单数量</th></tr>");
                for (int i = 0; i < lmo.Count; i++)
                {
                    sb.Append("<tr><td>" + lmo[i].AreaName + "</td><td class=\"dp\"><input type=\"hidden\" value=\"" + lmo[i].DeliveryPeriod.ToString() + "\"/></td><td>" + lmo[i].OrdersCount.ToString() + "</td></tr>");
                }
                sb.Append("</table>");
                divOrdersCountStatistics.InnerHtml = sb.ToString();
            }
        }
        /// <summary>
        /// 绑定订单出库列表
        /// <param name="_nowpage">当前页</param>
        /// <param name="_aid">AreaID</param>
        /// </summary>
        private void BindOrdersOutLibraryList(int _aid, byte _deliveryperiod, string _courierid)
        {
            BLL.Orders bo = new weipin.BLL.Orders();
            int _ordercount = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["OrderCount"].ToString());//正式设置为35，用户每条订单最多提交30件商品
            DataList<Model.Orders> dmo = bo.SelectOrdersOutLibraryOfTop(_ordercount, _aid, _deliveryperiod, _courierid);
            if (dmo != null && dmo.Rows.Count > 0)
            {
                spDataCount.InnerText = dmo.Total.ToString();
                rptOrdersOutLibraryList.DataSource = dmo.Rows;
                rptOrdersOutLibraryList.DataBind();
            }
            else { divShowDataCount.Visible = false; }
        }
        /// <summary>
        /// 合并订单号和按钮列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptOrdersOutLibraryList_PreRender(object sender, EventArgs e)
        {
            MergeRowsRPT(rptOrdersOutLibraryList);
        }
        /// <summary>
        /// 合并Repeater相同数据行
        /// <param name="rpt">Repeater</param>
        /// </summary>
        public static void MergeRowsRPT(Repeater rpt)
        {
            for (int rowIndex = rpt.Items.Count - 2; rowIndex >= 0; rowIndex--)
            {
                //合并tdOrderID列
                HtmlTableCell cells = rpt.Items[rowIndex].FindControl("tdOrderID") as HtmlTableCell;
                HtmlTableCell previouscells = rpt.Items[rowIndex + 1].FindControl("tdOrderID") as HtmlTableCell;
                if (cells.InnerText == previouscells.InnerText)
                {
                    cells.RowSpan = previouscells.RowSpan < 2 ? 2 : previouscells.RowSpan + 1;
                    previouscells.Visible = false;
                    //合并tdRemarks列
                    HtmlTableCell cellsRemarks = rpt.Items[rowIndex].FindControl("tdRemarks") as HtmlTableCell;
                    HtmlTableCell previouscellsRemarks = rpt.Items[rowIndex + 1].FindControl("tdRemarks") as HtmlTableCell;
                    if (cellsRemarks.InnerText == previouscellsRemarks.InnerText)
                    {
                        cellsRemarks.RowSpan = previouscellsRemarks.RowSpan < 2 ? 2 : previouscellsRemarks.RowSpan + 1;
                        previouscellsRemarks.Visible = false;
                    }
                    //合并tdOrdersPrint列
                    HtmlTableCell cellsOrdersPrint = rpt.Items[rowIndex].FindControl("tdOrdersPrint") as HtmlTableCell;
                    HtmlTableCell previouscellsOrdersPrint = rpt.Items[rowIndex + 1].FindControl("tdOrdersPrint") as HtmlTableCell;
                    if (cellsOrdersPrint.InnerText == previouscellsOrdersPrint.InnerText)
                    {
                        cellsOrdersPrint.RowSpan = previouscellsOrdersPrint.RowSpan < 2 ? 2 : previouscellsOrdersPrint.RowSpan + 1;
                        previouscellsOrdersPrint.Visible = false;
                    }
                }
                //合并tdCourierID列
                HtmlTableCell cellsCourierID = rpt.Items[rowIndex].FindControl("tdCourierID") as HtmlTableCell;
                HtmlTableCell previouscellsCourierID = rpt.Items[rowIndex + 1].FindControl("tdCourierID") as HtmlTableCell;
                if (cellsCourierID.InnerText == previouscellsCourierID.InnerText)
                {
                    cellsCourierID.RowSpan = previouscellsCourierID.RowSpan < 2 ? 2 : previouscellsCourierID.RowSpan + 1;
                    previouscellsCourierID.Visible = false;
                }
                //合并tdOutLibrary列
                HtmlTableCell cellsName = rpt.Items[rowIndex].FindControl("tdOutLibrary") as HtmlTableCell;
                HtmlTableCell previouscellsName = rpt.Items[rowIndex + 1].FindControl("tdOutLibrary") as HtmlTableCell;
                if (cellsName.InnerText == previouscellsName.InnerText)
                {
                    cellsName.RowSpan = previouscellsName.RowSpan < 2 ? 2 : previouscellsName.RowSpan + 1;
                    previouscellsName.Visible = false;
                }
            }
        }
        /// <summary>
        /// 绑定区域列表
        /// <param name="aid">区域ID</param>
        /// </summary>
        private void BindAreas(string aid)
        {
            if (aid != "")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Server.MapPath("~/xml/areas/areas.xml"));
                XmlNodeList nodelist = doc.GetElementsByTagName("ar");
                if (nodelist.Count > 0)
                {
                    string _str = string.Empty;
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        if (nodelist[i].Attributes["ai"].Value == aid)
                        {
                            string _cityid = nodelist[i].ParentNode.Attributes["ai"].Value;
                            string _provinceid = nodelist[i].ParentNode.ParentNode.Attributes["ai"].Value;
                            selArea.Items.Add(new ListItem("请选择", ""));
                            XmlNodeList nodelistarea = nodelist[i].ParentNode.ChildNodes;
                            for (int j = 0; j < nodelistarea.Count; j++)
                            {
                                selArea.Items.Add(new ListItem(nodelistarea[j].Attributes["an"].Value, nodelistarea[j].Attributes["ai"].Value));
                            }
                            selArea.SelectedIndex = selArea.Items.IndexOf(selArea.Items.FindByValue(aid));
                            selCity.Items.Add(new ListItem("请选择", ""));
                            XmlNodeList nodelistcity = nodelist[i].ParentNode.ParentNode.ChildNodes;
                            for (int k = 0; k < nodelistcity.Count; k++)
                            {
                                selCity.Items.Add(new ListItem(nodelistcity[k].Attributes["an"].Value, nodelistcity[k].Attributes["ai"].Value));
                            }
                            selCity.SelectedIndex = selCity.Items.IndexOf(selCity.Items.FindByValue(_cityid));
                            selProvince.Items.Add(new ListItem("请选择", ""));
                            XmlNodeList nodelistprovince = nodelist[i].ParentNode.ParentNode.ParentNode.ChildNodes;
                            for (int l = 0; l < nodelistprovince.Count; l++)
                            {
                                selProvince.Items.Add(new ListItem(nodelistprovince[l].Attributes["an"].Value, nodelistprovince[l].Attributes["ai"].Value));
                            }
                            selProvince.SelectedIndex = selProvince.Items.IndexOf(selProvince.Items.FindByValue(_provinceid));
                        }
                    }
                }
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Server.MapPath("~/xml/areas/areas.xml"));
                XmlNodeList nodelist = doc.GetElementsByTagName("pr");
                if (nodelist.Count > 0)
                {
                    string _str = string.Empty;
                    selProvince.Items.Add(new ListItem("请选择", ""));
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        selProvince.Items.Add(new ListItem(nodelist[i].Attributes["an"].Value, nodelist[i].Attributes["ai"].Value));
                    }
                    selCity.Items.Add(new ListItem("请选择", ""));
                    selArea.Items.Add(new ListItem("请选择", ""));
                }
            }
        }
        /// <summary>
        /// 绑定订单送货时间
        /// </summary>
        private void BindOrdersDeliveryPeriods()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/xml/deliveryperiod.xml"));
            XmlNodeList nodelist = doc.GetElementsByTagName("DeliveryPeriod");
            if (nodelist.Count > 0)
            {
                for (int i = 0; i < nodelist.Count; i++)
                {
                    selDeliveryPeriod.Items.Add(new ListItem(nodelist[i].ChildNodes[1].InnerText, nodelist[i].ChildNodes[0].InnerText));
                }
            }
        }
        /// <summary>
        /// 绑定快递员
        /// <param name="_aid">区域ID</param>
        /// </summary>
        private void BindCouriers(string _aid)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/xml/couriers/couriers.xml"));
            XmlNodeList nodelist = doc.GetElementsByTagName("Courier");
            if (nodelist.Count > 0 && _aid != "")
            {
                ListItemCollection _lic = new ListItemCollection();
                selCouriers.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < nodelist.Count; i++)
                {
                    if (_aid == nodelist[i].ChildNodes[1].InnerText)
                    {
                        selCouriers.Items.Add(new ListItem(nodelist[i].ChildNodes[2].InnerText, nodelist[i].ChildNodes[0].InnerText));
                    }
                    else
                    {
                        _lic.Add(new ListItem(nodelist[i].ChildNodes[2].InnerText, nodelist[i].ChildNodes[0].InnerText));
                    }
                }
                if (_lic.Count > 0)
                {
                    selCouriers.Items.Add(new ListItem("---------", ""));
                    for (int j = 0; j < _lic.Count; j++)
                    {
                        selCouriers.Items.Add(_lic[j]);
                    }
                }
            }
            else
            {
                selCouriers.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < nodelist.Count; i++)
                {
                    selCouriers.Items.Add(new ListItem(nodelist[i].ChildNodes[2].InnerText, nodelist[i].ChildNodes[0].InnerText));
                }
            }
        }
    }
}