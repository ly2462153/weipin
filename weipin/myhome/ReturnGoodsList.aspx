<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReturnGoodsList.aspx.cs"
    Inherits="weipin.myhome.ReturnGoodsList" %>

<%@ Register Src="../controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="../controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<%@ Register Src="../controls/myhome.ascx" TagName="myhome" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>退换货办理_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
    <link href="css/returngoodslist.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc1:top ID="top1" runat="server" />
    <script src="/js/jquery/jquery.validate.textarea.js" type="text/javascript"></script>
    <script src="/js/jquery/tipswindown.min.js" type="text/javascript"></script>
    <script src="js/returngoodslist.js" type="text/javascript"></script>
    <div class="main">
        <uc3:myhome ID="myhome1" runat="server" />
        <div class="main_right r">
            <h1>退换货办理</h1>
            <form id="fmReturnChangeGoods" method="post" runat="server">
            <input type="hidden" id="hidOrderID" name="hidOrderID" runat="server" />
            <div id="divMySucceeOrdersList" runat="server" class="div_bottom"></div>
            <div style="margin-top: 10px;"><span style="vertical-align: top;">退换货理由：</span><textarea
                id="txtExchangeReturnReasons" name="txtExchangeReturnReasons" style="width: 500px;
                height: 150px;"></textarea></div>
            <div class="message">
                <a href="javascript:void(0);" id="btnSubmit" class="comment" style="margin-left:70px;" >提交</a>  <a href="javascript:void(0);" id="btnBack" class="comment" onclick="location.href='/myhome/MyReturnOrdersList.aspx';">返回</a><span id="spMsg" style="color: #ff0000;"></span><span id="spReasonMsg" style="color: #ff0000;"></span>
                <input type="hidden" id="hidOrdersStatus" name="hidOrdersStatus" /><input type="hidden"
                    id="hidGoodsStatus" name="hidGoodsStatus" /></div>
            </form>
        </div>
    </div>
    <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>