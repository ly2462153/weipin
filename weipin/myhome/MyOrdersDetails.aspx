<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyOrdersDetails.aspx.cs"
    Inherits="weipin.myhome.MyOrdersDetails" %>

<%@ Register Src="../controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="../controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<%@ Register Src="../controls/myhome.ascx" TagName="myhome" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>我的订单详情_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
</head>
<body>
    <uc1:top ID="top1" runat="server" />
    <link href="css/myordersdetails.css" rel="stylesheet" type="text/css" />
    <script src="js/myordersdetails.js" type="text/javascript"></script>
    <div class="main">
        <uc3:myhome ID="myhome1" runat="server" />
        <div id="divOrderID" runat="server" class="main_c"></div>
        <div id="divConsigneeInfo" runat="server" class="main_right r"></div>
        <div id="divShippingInfo" runat="server" class="main_right r" style="margin-top: 20px;"></div>
        <div id="divOrdersList" runat="server" class="main_right r" style="margin-top: 20px;"></div>
    </div>
    <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>