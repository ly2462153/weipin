<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersPrint.aspx.cs" Inherits="weipin.admin.OrdersPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="x-ua-compatible" content="ie=7" />
<title>订单打印</title>
<link href="css/ordersprint.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div>
<div style="margin-bottom: 10px;">
<img src="/img/logo.gif" /></div>
<table class="tb">
<tr>
<td style="width: 150px;">订单编号：<span id="spOrderID1" runat="server"></span></td>
<td style="width: 260px;">订购时间：<span id="spOrderTime1" runat="server"></span></td>
<td style="width: 160px;">客户姓名：<span id="spConsigneeName1" runat="server"></span>
</td><td style="width: 160px;">联系方式：<span id="spPhone1" runat="server"></span></td>
</tr>
<tr>
<td colspan="4">地址：<span id="spAddress1" runat="server"></span></td>
</tr>
<tr>
<td>支付方式：<span id="spPayWay1" runat="server"></span></td><td colspan="3" style="text-align: right;">
订单金额：<span id="spOrderMoney1" runat="server"></span>元&nbsp;&nbsp;配送费：<span id="spFreight1"
runat="server"></span>元&nbsp;&nbsp;应付款：<span id="spCost1" runat="server"></span>元
</td>
</tr>
</table>
<div style="font-size: 12px; margin-top: 8px;">
非常感谢您在微品网上商城(www.weipin365.com)购物，我们期待您的再次光临！</div>
</div>
<div style="margin-top: 50px;">
<div style="margin-bottom: 10px;">
<img src="/img/logo.gif" /></div>
<table class="tb">
<tr>
<td style="width: 150px;">订单编号：<span id="spOrderID2" runat="server"></span></td>
<td style="width: 260px;">订购时间：<span id="spOrderTime2" runat="server"></span></td>
<td style="width: 160px;">客户姓名：<span id="spConsigneeName2" runat="server"></span>
</td><td style="width: 160px;">联系方式：<span id="spPhone2" runat="server"></span></td>
</tr>
<tr>
<td colspan="4">地址：<span id="spAddress2" runat="server"></span></td>
</tr>
<tr>
<td>支付方式：<span id="spPayWay2" runat="server"></span></td><td colspan="3" style="text-align: right;">
订单金额：<span id="spOrderMoney2" runat="server"></span>元&nbsp;&nbsp;配送费：<span id="spFreight2"
runat="server"></span>元&nbsp;&nbsp;应付款：<span id="spCost2" runat="server"></span>元
</td>
</tr>
</table>
<div style="font-size: 12px; margin-top: 8px;">
非常感谢您在微品网上商城(www.weipin365.com)购物，我们期待您的再次光临！&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;签收人（代签收人）：</div>
</div>
</body>
</html>