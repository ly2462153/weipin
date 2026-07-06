<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSuccess.aspx.cs" Inherits="weipin.OrderSuccess" %>

<%@ Register Src="controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="x-ua-compatible" content="ie=7" />
<title>成功提交订单_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
<link href="css/ordersuccess.css" rel="stylesheet" type="text/css" />
<script src="js/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
<script src="js/ordersuccess.js" type="text/javascript"></script>
</head>
<body>
<div class="ordr_top w970"><div class="l"><a href="/index.html" title="微品网上商城_心动小商品"><img src="img/logo.gif" width="312" height="36" style="margin:26px 18px 0 10px;" /></a></div>
<div id="divLoginMessage" runat="server" class="ordr_user"></div><div class="clear"></div>
</div>
<div class="ordr_arrowbox w970"><div class="ordr_ar02 ordr_arrow">我的购物车</div><div class="ordr_ar03 ordr_arrow">填写核对订单信息</div><div class="ordr_ar05 ordr_arrow">成功提交订单</div></div>
<div class="ordrtab_tit">成功提交订单</div>
<div class="ordrtab_box">
<form id="fmAlipay" action="/alipay/default.aspx" method="get">
<div class="ordr_bg1" style="color: #656565; height: auto; margin: 0 20px 20px;">
<p id="pMessage" runat="server" style="color: #656565; font-size: 14px; font-weight: bold;
line-height: 50px;">提交成功！我们会尽快安排发货</p>
<p id="pOrderMessage" runat="server" style="line-height: 20px; padding-bottom: 15px;">
您的订单号：<span id="spOrderID" name="spOrderID" runat="server"></span>&nbsp;&nbsp;&nbsp;应付金额：<span id="spAmount"
style="font-size: 14px; color: #ff0000;"></span><input type="hidden" id="hidAreaID"
runat="server" /><input type="hidden" id="hidDiscountPrice" runat="server" />&nbsp;&nbsp;&nbsp; 支付方式：货到付款&nbsp;&nbsp;&nbsp;配送方式：快递&nbsp;&nbsp;&nbsp;送货时间：<input
type="hidden" id="hidDeliveryPeriod" runat="server" /></p>
<div id="divSettleTitle" runat="server" class="ordrtab_boxtit">本次商品订单</div>
<div id="divOrders" runat="server" class="ordr_bg2"></div>
<div id="divMessage" runat="server" style="color: #ff0000; padding: 10px 20px 0;font-size: 14px;"></div>
<div id="divAlipay" runat="server" visible="false">
<p style="color: #cc0000; font-weight: bold;">您选择的支付方式为：支付宝，请点击“立即支付”进行付款</p>
<p>提示：</p>
<p>1.请在24小时内进行支付，否则订单将自动取消；</p>
<p>2.在您付款后，我们会尽快安排发货；</p>
<p>3.微品网上商城采用“支付宝担保交易付款方式”，您的付款暂时由支付宝保管，待您收货后再在支付宝系统确认收货，保障交易安全。</p>
<input type="hidden" id="hidOrderID" name="hidOrderID" runat="server" />
<img src="/img/alipay.gif" title="支付宝担保交易" alt="支付宝担保交易" style="margin:10px 0 10px 25px;display: block;float: left;" />
<img id="imgAlipay" src="/img/alipay_pay.gif" style="cursor: pointer;margin: 10px 0 20px 25px;" onclick="AlipaySubmit();" />
</div>
<div class="odr_nav"><a href="/myhome/MyOrdersList.aspx">查看订单</a>&nbsp;&nbsp;&nbsp;<a href="/index.html">继续购物</a></div>
</div></form>
</div>
<uc2:bottom ID="bottom1" runat="server" />
<input type="hidden" id="hidAmount" />
<iframe id="ifrXR" height=0 width=0></iframe>
</body>
</html>