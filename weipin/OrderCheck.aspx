<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderCheck.aspx.cs" Inherits="weipin.OrderCheck" %>

<%@ Register Src="controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="x-ua-compatible" content="ie=7" />
<title>填写核对订单信息_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
<link href="css/ordercheck.css" rel="stylesheet" type="text/css" />
<script src="js/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
<script src="js/jquery/jquery.validate.min.js" type="text/javascript"></script>
<script src="js/jquery/jquery.cookie.min.js" type="text/javascript"></script>
<script src="js/ordercheck.js" type="text/javascript"></script>
</head>
<body>
<div class="ordr_top w970">
<div class="l">
<a href="/index.html" title="微品网上商城_心动小商品"><img src="img/logo.gif" width="312" height="36"
style="margin: 26px 18px 0 10px;" /></a></div>
<div id="divLoginMessage" runat="server" class="ordr_user">
</div>
<div class="clear">
</div>
</div>
<div class="ordr_arrowbox w970">
<div class="ordr_ar03 ordr_arrow">
<a href="ShoppingCart.aspx">我的购物车</a></div>
<div class="ordr_ar01 ordr_arrow">
填写核对订单信息</div>
<div class="ordr_ar04 ordr_arrow">
成功提交订单</div>
</div>
<div class="ordrtab_tit">
填写核对订单信息</div>
<div class="ordrtab_box">
<div class="ordrtab_boxtit">
收货地址<a href="#" id="aControl" onclick="ControlMyAddress();return false;" runat="server"></a></div>
<div class="ordr_bg1">
<div id="divMyAddressShow" runat="server">
</div>
<div id="divMyAddressList" runat="server" class="shdz02">
</div>
<div id="divMyAddressAdd" runat="server" class="shdz01">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="4%" height="26" align="center">
<label>
<input type="radio" id="rdoAddAddress" runat="server" name="rdoMyAddress" style="border: 0;" />
</label>
</td><td align="left">添加新地址</td>
</tr>
</table>
</div>
<form id="fmMyAddressAdd">
<table id="tbMyAddressAdd" runat="server" width="100%" border="0" cellpadding="0"
cellspacing="0">
<tr>
<td width="12%" height="30" align="right">收货人：<br />
</td><td>
<input type="text" id="txtConsigneeName" name="txtConsigneeName" style="width: 80px;
line-height: 22px;" maxlength="15" /></td>
</tr>
<tr>
<td height="30" align="right">地区：<br />
</td><td>
<select id="selProvince" name="selProvince">
<option value="">请选择</option>
</select><select id="selCity" name="selCity" style="width:155px;"><option value="">请选择</option>
</select><select id="selArea" name="selArea"><option value="">请选择</option>
</select>
</td>
</tr>
<tr>
<td height="30" align="right">详细地址：</td><td>
<label id="lblArea">
</label>
<input type="text" id="txtMyAddress" name="txtMyAddress" size="50" maxlength="150"
style="line-height: 22px;" /></td>
</tr>
<tr>
<td height="30" align="right">手机：</td><td>
<input type="text" id="txtMobilePhone" name="txtMobilePhone" style="line-height: 22px;"
maxlength="12" />
<span style="color: #878787;">或者</span> 座机：<input type="text" id="txtTelephone" name="txtTelephone"
style="line-height: 22px;" maxlength="15" /></td>
</tr>
<tr>
<td height="30" align="right">邮编：</td><td>
<input type="text" id="txtMyZipcode" name="txtMyZipcode" maxlength="6" style="line-height: 22px;" />
</td>
</tr>
<tr>
<td height="30" colspan="2" align="right"><a href="javascript:void(0);" id="aSaveSendMyAddress"
class="ordr_but">保存并送到这个地址</a></td>
</tr>
</table>
</form>
<div id="divSendMyAddress" style="height: 35px; display: none;">
<a href="#" class="ordr_but" onclick="SendMyAddress();return false;">送到这个地址</a></div>
</div>
<div class="ordrtab_boxtit">
支付及配送信息<a href="javascript:void(0);" id="aPaySendControl"></a></div>
<div class="ordr_bg">
<div id="divPayWayShow" style="display: none;">
</div>
<div id="divPayWayChoose" style="color: #656565;">
支付方式：<span><input type="radio" id="rdoCOD" name="rdoPayWay" value="1" disabled="disabled" />货到付款</span>&nbsp;<span><input
type="radio" id="rdoAlipay" name="rdoPayWay" value="2" disabled="disabled" />支付宝</span>&nbsp;<span
id="spPayMsg" style="color: #ff0000;"></span></div>
<div style="color: #656565;">配送方式：快递<span style="color: #ff0000;">[全场购物满38元免运费]</span></div>
<div id="divPaySendWayShow" style="display: none;">
</div>
<div id="divPaySendChoose" style="background: #fff; border: solid  1px #ccc; margin-top: 10px;
padding: 15px;">
<table width="80%" border="0" cellpadding="8">
<tr>
<td><span class="ordr_inl2">送货日期：</span>
<table border="0">
<tr>
<td>
<input type="radio" name="rdoDeliveryPeriod" value="1" checked="checked" />
</td><td>只工作日送货(双休日、假日不用送)</td>
</tr>
<tr>
<td>
<input type="radio" name="rdoDeliveryPeriod" value="2" />
</td><td>工作日、双休日与假日均可送货</td>
</tr>
<tr>
<td>
<input type="radio" name="rdoDeliveryPeriod" value="3" />
</td><td>只双休日、假日送货(工作日不用送)</td>
</tr>
</table>
</td>
</tr>
<tr id="trPayWay">
<td><span class="ordr_inl2">付款方式：</span>
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td>
<input type="radio" name="rdoPayMoneyWay" checked="checked" />
</td><td>现金 </td><td>
<input type="radio" name="rdoPayMoneyWay" disabled="disabled" /></td><td>POS机刷卡
</td>
</tr>
</table>
</td>
</tr>
<tr>
<td><span class="ordr_inl2" style="color: #ff0000;">声明：</span>
<div style="float: left; color: #656565">
我们会努力按照您指定的时间配送，但因天气、交通等各类因素影响，您的订单有可能会有延误现象！</div>
</td>
</tr>
</table>
<div class="ordr_indiv">
</div>
<div>
<div class="clear">
</div>
</div>
</div>
<div>
<div>
<a href="javascript:void(0);" id="aPaySendWay" class="ordr_but">保存支付方式及配送信息</a>
<div class="clear">
</div>
</div>
</div>
</div>
<div class="ordrtab_boxtit">
商品清单<a href="ShoppingCart.aspx">[修改购物车]</a></div>
<div id="divOrders" runat="server" class="ordr_bg2">
</div>
<div id="divMessage" runat="server" style="color: #ff0000; padding: 10px 20px 0;">
</div>
<div id="divSettleTitle" runat="server" class="ordrtab_boxtit">
结算信息</div>
<form id="fmSubmit" method="post" action="OrderSuccess.aspx">
<div id="divSettleMessage" runat="server" class="ordr_bg2">
<div>
<ul><li class="ordr_jsxx">商品数量总计:<span id="spCount"></span>件&nbsp;&nbsp;&nbsp;商品总金额:<span
id="spGoodsPrice"></span>元 - 抵价券：<span id="spDiscountPrice" runat="server"></span>元
+ 运费:<span id="spFreight"></span>元</li> <li class="ordr_jsxx" style="border-top: 0;
color: #ff0000; font-weight: bold;"><a href="/myhome/MyOffsetPrice.aspx" target="_blank">
我的抵价券总金额</a>:<span id="spMyOffsetPrice" runat="server"></span>元，此次可用抵价券金额:<span id="spThisOrdersUse"
runat="server"></span>元，<a href="/help/offsetprice.html" target="_blank">《抵价券使用说明》</a></li>
<li class="ordr_jsxx" style="border-top: 0;">
<input type="checkbox" id="ckbUseOffsetPrice" name="ckbUseOffsetPrice" checked="checked" />使用抵价券</li>
<li class="ordr_jge">应付总额：<span id="spAmount"></span>元</li> </ul>
</div>
<div class="clear">
</div>
</div>
<div style="font-size: 14px; padding: 10px 20px 0;">
备注:<input type="text" id="txtRemarks" name="txtRemarks" style="width: 300px; height: 22px;"
maxlength="150" /></div>
<div class="but_tijiao">
<label id="lblMessage" style="color: #ff0000;">
</label>
<input type="hidden" id="hidMyAddress" name="hidMyAddress" runat="server" /><input
type="hidden" id="hidPayWay" name="hidPayWay" /><input type="hidden" id="hidPaySendWay"
name="hidPaySendWay" /><input type="hidden" id="hidFreight" name="hidFreight" />
<img src="img/but_tijiao.jpg" id="imgSubmit" runat="server" width="120" height="42"
border="0" style="cursor: pointer;" /></div>
</form>
</div>
<uc2:bottom ID="bottom1" runat="server" />
</body>
</html>