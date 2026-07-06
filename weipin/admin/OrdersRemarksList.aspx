<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersRemarksList.aspx.cs"
    Inherits="weipin.admin.OrdersRemarksList" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>订单备注列表</title>
    <link href="css/ordersremarkslist.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <uc1:headadmin ID="headadmin1" runat="server" />
        <script src="js/ordersremarkslist.js" type="text/javascript"></script>
        <script src="../js/calendar.js" type="text/javascript"></script>
        <div id="cols" class="box">
            <div id="aside" class="box">
                <div class="padding box">
                    <p id="logo"><a href="http://www.weipin365.com" target="_blank"><img src="/img/logolengthways.gif" alt="" /></a></p>
                </div>
                <form name="form1" action="OrdersSearchGoodsList.aspx" method="post">
                <fieldset>
                    <legend>订单号</legend>
                    <p>
                        <input type="text" id="txtSearch" name="txtSearch" runat="server" class="input-text-02"
                            style="width: 138px; height: 19px;" />&nbsp;<input type="submit" value="搜索" class="input-submit-02" /></p>
                </fieldset>
                </form>
                <ul class="box">
                    <li><a href="OrdersList.aspx">订单列表</a></li>
                    <li><a href="OrdersOutLibraryList.aspx">出库列表</a></li>
                    <li><a href="OrdersChangeGoodsList.aspx">换货列表</a></li>
                    <li><a href="OrdersReturnGoodsList.aspx">退货列表</a></li>
                    <li><a href="OrdersRemarksAdd.aspx">订单备注添加</a></li>
                    <li id="submenu-active"><a href="OrdersRemarksList.aspx">订单备注列表</a></li>
                </ul>
            </div>
            <div id="content" class="box">
                <h1>订单备注列表</h1>
                <div id="divOrdersRemarksList" runat="server">
                    <form id="form2" method="post">
                    日期：<input type="text" id="txtStartTime" name="txtStartTime" onclick="calendar.show(this);"
                        style="width: 70px; height: 22px; cursor: pointer; margin-top: 10px;" maxlength="10"
                        readonly="readonly" runat="server" />&nbsp;-&nbsp;<input type="text" id="txtEndTime"
                            name="txtEndTime" onclick="calendar.show(this);" style="width: 70px; height: 22px;
                            cursor: pointer; margin-top: 10px;" maxlength="10" readonly="readonly" runat="server" />&nbsp;<input
                                type="submit" id="btnSelect" value="查询" />
                    </form>
                    <asp:Repeater ID="rptOrdersRemarksList" runat="server">
                        <HeaderTemplate>
                            <table class="tb" style="border: 1px solid #CFCFCF; margin-top: 10px;">
                                <tr>
                                    <th>订单号</th>
                                    <th>商品名称</th>
                                    <th>用户名</th>
                                    <th>快递员</th>
                                    <th>物流次数</th>
                                    <th>成交商品数量</th>
                                    <th>成交商品总价</th>
                                    <th>库存</th>
                                    <th>销量</th>
                                    <th>送货商品量</th>
                                    <th>订单发生日期</th>
                                    <th>添加时间</th>
                                    <th>备注</th>
                                    <th style="width: 30px;">&nbsp;</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "OrderID").ToString()!="0"?DataBinder.Eval(Container.DataItem, "OrderID"):""%>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "GoodsName")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "LoginID")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "CourierName")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "LogisticsTimes")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "CompleteCount")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "CompleteAmount")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "Inventory")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "SalesVolume")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "DeliveryTimes")%></td>
                                <td>
                                    <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "OrderTime")).ToShortDateString()%>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "AddTime")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "Remarks")%></td>
                                <td><a href="#" onclick="DeleteOrdersRemarks('<%# DataBinder.Eval(Container.DataItem, "OrdersRemarkID")%>');">
                                    删除</a></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div id="divPaging" runat="server"></div>
            </div>
        </div>
    </div>
</body>
</html>