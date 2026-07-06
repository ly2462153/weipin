<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="weipin.ShoppingCart" %>

<%@ Register Src="controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>购物车_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
    <link href="css/shoppingcart.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="js/jquery/jquery.cookie.min.js" type="text/javascript"></script>
    <script src="js/jquery/tipswindown.min.js" type="text/javascript"></script>
    <script src="js/shoppingcart.js" type="text/javascript"></script>
</head>
<body>
    <div class="ordr_top w970">
        <div class="l"><a href="/index.html" title="微品网上商城_心动小商品"><img src="img/logo.gif" width="312" height="36" style="margin:26px 18px 0 10px;" /></a></div>
        <div id="divLoginMessage" runat="server" class="ordr_user"></div>
        <div class="clear"></div>
    </div>
    <div class="ordr_arrowbox w970">
        <div class="ordr_ar01 ordr_arrow">我的购物车</div>
        <div class="ordr_ar02 ordr_arrow">填写核对订单信息</div>
        <div class="ordr_ar04 ordr_arrow">成功提交订单</div>
    </div>
    <div class="w970">
        <div class="ordr_tit">我的购物车</div>
        <div id="divShoppingCart" runat="server"></div>
        <div class="ordrtab_tit">还有这些商品供您选择</div>
        <div id="divOtherChoose" runat="server" class="ordrtab_box"></div>
    </div>
    <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>