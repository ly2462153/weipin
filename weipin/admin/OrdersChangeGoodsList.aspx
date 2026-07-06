<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersChangeGoodsList.aspx.cs"
Inherits="weipin.admin.OrdersChangeGoodsList" %>

<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="x-ua-compatible" content="ie=7" />
<title>换货列表</title>
<link href="css/orderschangegoodslist.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="main">
<uc1:headadmin ID="headadmin1" runat="server" />
<script src="../js/jquery/jquery.cookie.min.js" type="text/javascript"></script>
<script src="js/orderschangegoodslist.js" type="text/javascript"></script>
<div id="cols" class="box">
<div id="aside" class="box">
<div class="padding box">
<p id="logo"><a href="http://www.weipin365.com" target="_blank"><img src="/img/logolengthways.gif"
alt="" /></a></p>
</div>
<form name="form1" action="OrdersSearchGoodsList.aspx" method="post">
<fieldset>
<legend>订单号</legend><p>
<input type="text" id="txtSearch" name="txtSearch" runat="server" class="input-text-02"
style="width: 138px; height: 19px;" />&nbsp;<input type="submit" value="搜索" class="input-submit-02" /></p>
</fieldset>
</form>
<ul class="box"><li><a href="OrdersList.aspx">订单列表</a></li> <li><a href="OrdersOutLibraryList.aspx">
出库列表</a></li> <li id="submenu-active"><a href="OrdersChangeGoodsList.aspx">换货列表</a></li>
<li><a href="OrdersReturnGoodsList.aspx">退货列表</a></li> <li><a href="OrdersRemarksAdd.aspx">
订单备注添加</a></li> <li><a href="OrdersRemarksList.aspx">订单备注列表</a></li> </ul>
</div>
<div id="content" class="box">
<h1>换货列表</h1>
<div>
<div id="divOrdersCountStatistics" runat="server">
</div>
<select id="selProvince" name="selProvince" runat="server" style="margin-top: 10px;">
</select>
<select id="selCity" name="selCity" runat="server" style="margin-top: 10px;">
</select>
<select id="selArea" runat="server" style="margin-top: 10px;">
</select><select id="selDeliveryPeriod" runat="server" style="margin: 10px 0 0 10px;"></select>
<div id="divShowDataCount" runat="server" style="padding-top: 10px">
查询到订单：<span id="spDataCount" runat="server" style="color: #ff6600;"></span>条</div>
<asp:Repeater ID="rptOrdersChangeGoodsList" runat="server" OnPreRender="rptOrdersChangeGoodsList_PreRender">
<HeaderTemplate>
<table class="tb" style="border: 1px solid #CFCFCF; margin-top: 10px;">
<tr>
<th>图片</th>
<th>订单号</th>
<th>用户名</th>
<th>收货人</th>
<th>收货地址</th>
<th>手机</th>
<th>座机</th>
<th>订单提交时间</th>
<th>预计送达日期</th>
<th>商品编号</th>
<th>商品名称</th>
<th>成交单价</th>
<th>商品重量</th>
<th>尺码</th>
<th style="color: #ff0000;">订购数量</th>
<th>交易状态</th>
<th>换货理由</th>
<th style="width: 80px;">快递员</th>
<th style="width: 30px;">&nbsp;</th>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td><img src='<%#DataBinder.Eval(Container.DataItem,"GoodsPicturePath") %>' /></td>
<td id="tdOrderID" runat="server">
<%#DataBinder.Eval(Container.DataItem, "OrderID")%></td><td style="word-break:break-all;">
<%#DataBinder.Eval(Container.DataItem, "LoginID")%></td><td>
<%#DataBinder.Eval(Container.DataItem, "ConsigneeName")%></td><td id="ShippingAddress"
runat="server">
<%#DataBinder.Eval(Container.DataItem, "ShippingAddress")%></td>
<td>
<%#DataBinder.Eval(Container.DataItem, "MobilePhone")%></td><td>
<%#DataBinder.Eval(Container.DataItem, "TelePhone")%></td><td>
<%#DataBinder.Eval(Container.DataItem, "AddTime")%></td><td>
<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DeliveryTimePlan")).ToShortDateString()%>
</td><td name='tdOID<%#DataBinder.Eval(Container.DataItem, "OrderID")%>'>
<%#DataBinder.Eval(Container.DataItem, "GoodsID")%><input type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "OrdersGoodsID")%>' />
</td><td>
<%#DataBinder.Eval(Container.DataItem, "GoodsName")%></td><td>
<%#DataBinder.Eval(Container.DataItem, "TransactionPrice").ToString()%>
</td><td>
<%#DataBinder.Eval(Container.DataItem, "GoodsWeight")%></td>
<td>
<%#DataBinder.Eval(Container.DataItem, "SizeName")%>
</td><td id='tdGoodsCount<%#DataBinder.Eval(Container.DataItem, "OrdersGoodsID")%>'
style="color: #ff0000; font-weight: bold;">
<%#DataBinder.Eval(Container.DataItem, "GoodsCount")%></td><td>
<input type="hidden" id='hidGoodsStatus<%#DataBinder.Eval(Container.DataItem, "OrdersGoodsID")%>'
name="hidGoodsStatus" value='<%#DataBinder.Eval(Container.DataItem, "GoodsStatus")%>' />
</td><td>
<%#DataBinder.Eval(Container.DataItem, "ExchangeReturnReasons")%></td><td id="tdCourierID"
runat="server" style="text-align: left; padding-left: 10px;">
<select id='sel<%#DataBinder.Eval(Container.DataItem, "OrderID")%>'>
</select></td><td id='tdOutLibrary' runat="server"><a href="#" onclick="OutLibrary('<%#DataBinder.Eval(Container.DataItem, "OrderID")%>',$(this).parent().attr('id'));return false;">
出库</a></td>
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