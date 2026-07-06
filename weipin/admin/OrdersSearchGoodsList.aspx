<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersSearchGoodsList.aspx.cs"
Inherits="weipin.admin.OrdersSearchGoodsList" %>

<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="x-ua-compatible" content="ie=7" />
<title>订单详情</title>
<link href="css/orderssearchgoodslist.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="main">
<uc1:headadmin ID="headadmin1" runat="server" />
<script src="js/orderssearchgoodslist.js" type="text/javascript"></script>
<div id="cols" class="box">
<div id="aside" class="box">
<div class="padding box">
<p id="logo"><a href="http://www.weipin365.com" target="_blank">
<img src="/img/logolengthways.gif" alt="" /></a></p>
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
<li><a href="OrdersRemarksList.aspx">订单备注列表</a></li>
</ul>
</div>
<div id="content" class="box">
<h1>订单详情</h1>
<div id="divShow" runat="server">
<table class="tb" style="margin-top: 10px;">
<tr>
<td class="tdL" style="width: 130px">订单号: </td>
<td>
<label id="lblOrderID" runat="server">
</label>
&nbsp;&nbsp;&nbsp;<a href="#" id="aPrint" runat="server">打印</a> </td>
<td class="tdL" style="width: 130px">用户名: </td>
<td>
<label id="lblLoginID" runat="server">
</label>
</td>
</tr>
<tr>
<td class="tdL" style="width: 130px">收件人: </td>
<td>
<label id="lblConsigneeName" runat="server">
</label>
</td>
<td class="tdL" style="width: 130px">快递员: </td>
<td>
<label id="lblCourierName" runat="server">
</label>
</td>
</tr>
<tr>
<td class="tdL" style="width: 130px">收件地址: </td>
<td colspan="3">
<div id="divShippingAddress" runat="server"></div>
</td>
</tr>
<tr>
<td class="tdL" style="width: 130px">手机: </td>
<td>
<label id="lblMobilePhone" runat="server">
</label>
</td>
<td class="tdL" style="width: 130px">座机: </td>
<td>
<label id="lblTelePhone" runat="server">
</label>
</td>
</tr>
<tr>
<td class="tdL" style="width: 130px">E-mail: </td>
<td>
<label id="lblEmail" runat="server">
</label>
</td>
<td class="tdL" style="width: 130px">邮编: </td>
<td>
<label id="lblZipcode" runat="server">
</label>
</td>
</tr>
<tr>
<td class="tdL" style="width: 130px">添加时间: </td>
<td>
<label id="lblAddTime" runat="server">
</label>
</td>
<td class="tdL" style="width: 130px">预计送达日期: </td>
<td>
<label id="lblDeliveryTimePlan" runat="server">
</label>
</td>
</tr>
<tr>
<td class="tdL" style="width: 130px">实际送达时间: </td>
<td>
<label id="lblDeliveryTime" runat="server">
</label>
</td>
<td class="tdL" style="width: 130px">送货时间: </td>
<td>
<label id="lblDeliveryPeriod" runat="server">
</label>
</td>
</tr>
<tr>
<td class="tdL" style="width: 130px">订单状态: </td>
<td>
<label id="lblOrdersStatus" runat="server">
</label>
</td>
<td class="tdL" style="width: 130px">物流状态: </td>
<td>
<label id="lblLogisticsStatus" runat="server">
</label>
</td>
</tr>
<tr>
<td class="tdL" style="width: 130px">物流次数: </td>
<td colspan="3">
<label id="lblLogisticsTimes" runat="server">
</label>
</td>
</tr>
<tr>
<td class="tdL" style="width: 130px">备注: </td>
<td colspan="3" style="color: #ff0000;">
<div id="divRemarks" runat="server"></div>
</td>
</tr>
<tr>
<td class="tdL" style="width: 130px">退换货理由: </td>
<td colspan="3" style="color: #ff0000;">
<div id="divExchangeReturnReasons" runat="server"></div>
</td>
</tr>
</table>
<asp:Repeater ID="rptOrdersSearchGoodsList" runat="server">
<HeaderTemplate>
<table class="tablelist" style="border: 1px solid #CFCFCF; margin-top: 10px;">
<tr>
<th>图片</th>
<th>商品编号</th>
<th>商品名称</th>
<th>商品重量</th>
<th>尺码</th>
<th style="color: #ff0000;">订购数量</th>
<th>交易状态</th>
<th>成交单价</th>
<th>交易备注</th>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td><a href='/page/<%# Convert.ToInt32(DataBinder.Eval(Container.DataItem, "GoodsID"))/1000%>/goodsshow_<%#DataBinder.Eval(Container.DataItem, "GoodsID")%>.html'
target="_blank">
<img src='<%#DataBinder.Eval(Container.DataItem,"GoodsPicturePath") %>' /></a>
</td>
<td>
<%#DataBinder.Eval(Container.DataItem, "GoodsID")%>
</td>
<td>
<%#DataBinder.Eval(Container.DataItem, "GoodsName")%></td>
<td>
<%#DataBinder.Eval(Container.DataItem, "GoodsWeight")%></td>
<td>
<%#DataBinder.Eval(Container.DataItem, "SizeName")%>
</td>
<td style="color: #ff0000; font-weight: bold;">
<%#DataBinder.Eval(Container.DataItem, "GoodsCount")%></td>
<td>
<input type="hidden" id='hidGoodsStatus<%#DataBinder.Eval(Container.DataItem, "OrdersGoodsID")%>'
name="hidGoodsStatus" value='<%#DataBinder.Eval(Container.DataItem, "GoodsStatus")%>' />
</td>
<td>
<%#DataBinder.Eval(Container.DataItem, "TransactionPrice").ToString()%>
</td>
<td><a href='OrdersRemarksEdit.aspx?ogid=<%#DataBinder.Eval(Container.DataItem, "OrdersGoodsID").ToString()%>'>
编辑</a> </td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>
</div>
</div>
</div>
</div>
</body>
</html>