<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyIntegralList.aspx.cs"
    Inherits="weipin.myhome.MyIntegralList" %>

<%@ Register Src="../controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="../controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<%@ Register Src="../controls/myhome.ascx" TagName="myhome" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>我的积分_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
    <link href="css/myintegrallist.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc1:top ID="top1" runat="server" />
    <script src="/js/jquery/tipswindown.min.js" type="text/javascript"></script>
    <script src="js/myintegrallist.js" type="text/javascript"></script>
    <div class="main">
        <uc3:myhome ID="myhome1" runat="server" />
        <div class="main_right r">
            <h1>我的积分</h1>
            <ul class="nedit-nav">
                <li><a id="aIntegralRecord" class="selected">我的会员积分</a></li>
                <li><a id="aIntegralExchange">积分对换抵价券</a></li>
            </ul>
            <div class="div_bottom" style="padding: 10px 0 10px 10px;">您当前的积分：<b id="bIntegral"
                runat="server" style="color: #a10000;"></b>分</div>
            <div id="divMsg" style="padding-left: 10px; color: #a10000;">为了保证您30天退换货的权益，您的积分会在商品出库后30天生效</div>
        </div>
        <div id="divChange">
            <div id="divIntegralRecord" class="main_right r" style="margin-top: 20px;">
                <h1>积分记录</h1>
                <div id="divIntegralList" runat="server" class="div_bottom"></div>
                <div id="divPaging" runat="server" class="page"></div>
            </div>
            <form id="fmExchange" method="post" runat="server">
            <div id="divIntegralExchange" class="main_right r" style="display: none;">
                <div class="div_bottom" style="padding: 10px 0 10px 10px; color: #999;">我要兑换<input
                    type="text" id="txtIntegral" name="txtIntegral" runat="server" style="width: 60px; height: 22px;
                    margin: 0 5px;" maxlength="5" value="100" />分为<span id="spOffsetPrice" style="padding: 0 2px;">1</span>元抵价券</div>
                <a href="#" id="aSubmit">确定兑换抵价券</a>
                <p>兑换说明</p>
                <p>1、积分兑换抵价券的最低限制为100分(即每次兑换抵价券的积分不得低于100分)；</p>
                <p>2、100积分=1元抵价券</p>
            </div>
            </form>
        </div>
    </div>
    <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>
