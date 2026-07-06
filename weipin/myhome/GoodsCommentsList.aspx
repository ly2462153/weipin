<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsCommentsList.aspx.cs"
    Inherits="weipin.myhome.GoodsCommentsList" %>

<%@ Register Src="../controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="../controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<%@ Register Src="../controls/myhome.ascx" TagName="myhome" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>我的评论_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
    <link href="css/goodscommentslist.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc1:top ID="top1" runat="server" />
    <script src="js/goodscommentslist.js" type="text/javascript"></script>
    <div class="main">
        <uc3:myhome ID="myhome1" runat="server" />
        <div class="main_right r">
            <h1>我的评论</h1>
            <div id="divGoodsCommentsList" runat="server" class="div_bottom"></div>
            <div id="divPaging" runat="server" class="page"></div>
        </div>
    </div>
    <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>