<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersOutLibraryList.aspx.cs"
Inherits="weipin.admin.OrdersOutLibraryList" %>

<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="x-ua-compatible" content="ie=7" />
<title>出库列表</title>
<link href="css/ordersoutlibrarylist.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="main">
<uc1:headadmin ID="headadmin1" runat="server" />
<script src="../js/jquery/jquery.cookie.min.js" type="text/javascript"></script>
<script src="js/ordersoutlibrarylist.js" type="text/javascript"></script>
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
<ul class="box"><li><a href="OrdersList.aspx">订单列表</a></li> <li id="submenu-active">
<a href="OrdersOutLibraryList.aspx">出库列表</a></li> <li><a href="OrdersChangeGoodsList.aspx">
换货列表</a></li> <li><a href="OrdersReturnGoodsList.aspx">退货列表</a></li> <li><a href="OrdersRemarksAdd.aspx">
订单备注添加</a></li> <li><a href="OrdersRemarksList.aspx">订单备注列表</a></li></ul>
</div>
<div id="content" class="box">
<h1>出库列表</h1>
<div>
<div id="divOrdersCountStatistics" runat="server">
</div>
<select id="selProvince" name="selProvince" runat="server" style="margin-top: 10px;">
</select>
<select id="selCity" name="selCity" runat="server" style="margin-top: 10px;">
</select>
<select id="selArea" runat="server" style="margin-top: 10px;">
</select><select id="selDeliveryPeriod" runat="server" style="margin: 10px 0 0 10px;"></select><select
id="selCouriers" runat="server" style="margin: 10px 0 0 10px;"></select>
<div id="divShowDataCount" runat="server" style="padding-top: 10px">
查询到订单：<span id="spDataCount" runat="server" style="color: #ff6600;"></span>条</div>
<asp:Repeater ID="rptOrdersOutLibraryList" runat="server" OnPreRender="rptOrdersOutLibraryList_PreRender">
<HeaderTemplate>
<table class="tb" style="border: 1px solid #CFCFCF; margin-top: 10px;">
<tr>
<th>图片</th>
<th>订单号</th>
<th>用户名</th>
<th>商品编号</th>
<th>商品名称</th>
<th>成交单价</th>
<th>尺码</th>
<th>快递员</th>
<th>备注</th>
<th style="width: 90px;">商品交易状态</th>
<th style="color: #ff0000;">商品订购数量</th>
<th>商品返回数量</th>
<th>&nbsp;</th>
<th>&nbsp;</th>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td><a href='/page/<%# Convert.ToInt32(DataBinder.Eval(Container.DataItem, "GoodsID"))/1000%>/goodsshow_<%#DataBinder.Eval(Container.DataItem, "GoodsID")%>.html'
target="_blank"><img src='<%#DataBinder.Eval(Container.DataItem,"GoodsPicturePath") %>' /></a>
</td><td id="tdOrderID" runat="server">
<%#DataBinder.Eval(Container.DataItem, "OrderID")%></td><td style="word-break:break-all;">
<%#DataBinder.Eval(Container.DataItem, "LoginID")%></td><td id='tdGoodsID<%#DataBinder.Eval(Container.DataItem, "OrdersGoodsID")%>'>
<%#DataBinder.Eval(Container.DataItem, "GoodsID")%>
</td><td>
<%#DataBinder.Eval(Container.DataItem, "GoodsName")%></td><td id='tdTransactionPrice<%#DataBinder.Eval(Container.DataItem, "OrdersGoodsID")%>'>
<%#DataBinder.Eval(Container.DataItem, "TransactionPrice").ToString()%>
</td><td id='tdSizeName<%#DataBinder.Eval(Container.DataItem, "OrdersGoodsID")%>'>
<%#DataBinder.Eval(Container.DataItem, "SizeName")%>
</td><td id="tdCourierID" runat="server">
<%#DataBinder.Eval(Container.DataItem, "CourierName")%><input type="hidden" id='hidCourierID<%#DataBinder.Eval(Container.DataItem, "OrderID")%>'
value='<%#DataBinder.Eval(Container.DataItem, "CourierID")%>' />
</td><td id="tdRemarks" runat="server" style="color: #ff0000;">
<%#DataBinder.Eval(Container.DataItem, "Remarks")%></td><td style="text-align: left;
padding-left: 10px;">
<%int _goodsstatus = ((System.Collections.Generic.List<weipin.Model.Orders>)rptOrdersOutLibraryList.DataSource)[_index].GoodsStatus;
int _completecount = ((System.Collections.Generic.List<weipin.Model.Orders>)rptOrdersOutLibraryList.DataSource)[_index].CompleteCount;
_index++;
if (_goodsstatus == 1 || _goodsstatus == 3)
{ %>
<select name='sel<%#DataBinder.Eval(Container.DataItem, "OrderID")%>'>
<option value="">请选择</option>
<option value="3">换货</option>
<option value="6">交易成功</option>
</select><input type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "OrdersGoodsID")%>' /><input
type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "GoodsStatus")%>' /><input
type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "CompleteCount")%>' />
<%}
else if (_goodsstatus == 4)
{%>
<select name='sel<%#DataBinder.Eval(Container.DataItem, "OrderID")%>'>
<option value="">请选择</option>
<option value="6">交易成功</option>
</select><input type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "OrdersGoodsID")%>' /><input
type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "GoodsStatus")%>' /><input
type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "CompleteCount")%>' />
<%}
else if (_goodsstatus == 5)
{ %>
退货成功<%}
else
{ %>
交易成功
<%} %>
</td><td id='tdGoodsCount<%#DataBinder.Eval(Container.DataItem, "OrdersGoodsID")%>'
style="color: #ff0000; font-weight: bold;">
<%#DataBinder.Eval(Container.DataItem, "GoodsCount")%></td><td>
<input type="text" id='txtReturnGoodsCount<%#DataBinder.Eval(Container.DataItem, "OrdersGoodsID")%>'
style="width: 16px; display: none;" maxlength="2" />
</td><td id='tdOutLibrary' runat="server"><a href="#" onclick="SubmitOrder('<%#DataBinder.Eval(Container.DataItem, "OrderID")%>',$(this).parent().attr('id'),'<%#DataBinder.Eval(Container.DataItem, "LoginID")%>');return false;">
提交</a></td><td id="tdOrdersPrint" runat="server"><a href='OrdersPrint.aspx?oid=<%#DataBinder.Eval(Container.DataItem, "OrderID")%>'
target="_blank">打印</a></td>
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