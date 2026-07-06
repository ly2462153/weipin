<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyOffsetPrice.aspx.cs"
Inherits="weipin.myhome.MyOffsetPrice" %>

<%@ Register Src="../controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="../controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<%@ Register Src="../controls/myhome.ascx" TagName="myhome" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="x-ua-compatible" content="ie=7" />
<title>我的抵价券_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
<link href="css/myoffsetprice.css" rel="stylesheet" type="text/css" />
</head>
<body>
<uc1:top ID="top1" runat="server" />
<div class="main">
<uc3:myhome ID="myhome1" runat="server" />
<div class="main_right r">
<h1>我的抵价券</h1>
<div class="div_bottom" style="padding: 10px 0 10px 10px;">您当前的抵价券金额：<b id="bOffsetPrice" runat="server" style="color: #a10000;"></b>元</div>
<div style="padding: 0 0 10px 10px;">抵价券等级：<b id="bVIPGrade" runat="server" style="color: #a10000;"></b></div>
<div style="padding: 10px 0 10px 10px;"><b style="color: #a10000;">抵价券使用说明</b>
<p>1、抵价券用于在商品订单核对和结算时，对购买商品的价格进行优惠抵消；</p>
<p>2、抵价券是通过微品网上商城的商品购买、活动馈赠、积分兑换的方式发放给用户；</p>
<p>3、商品选购完成进入订单信息核对及结算页面后，系统将根据您的抵价券等级及总额自动计算可使用抵价券的金额，你可以自行决定是否使用抵价券；</p>
<p>4、更多关于抵价券的说明请见<a href="/help/offsetprice.html" target="_blank">《抵价券使用说明》</a>。</p>
</div>
</div>
</div>
<uc2:bottom ID="bottom1" runat="server" />
</body>
</html>