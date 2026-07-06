<%@ Page Language="C#" AutoEventWireup="true" Inherits="weipin.alipay.return_url"
    CodeBehind="return_url.aspx.cs" %>

<%@ Register Src="../controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="../controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="ttTitle" runat="server"></title>
</head>
<body>
    <uc1:top ID="top1" runat="server" />
    <div id="divMsg" runat="server" style="margin: 100px 0 0 460px;">
    </div>
    <div style="margin: 22px 0 160px 510px;">
        <ul><li style="float: left; padding-top: 30px;"><a href="/myhome/MyOrdersList.aspx" style="font-size: 16px;
            line-height: 28px; font-family: 微软雅黑; color: #47983C;">>>查看订单</a></li><li style="float: left;
                padding: 30px 0 0 30px;"><a href="/index.html" style="font-size: 16px; line-height: 28px; font-family: 微软雅黑;
                    color: #47983C;">>>继续购物</a></li></ul>
    </div>
    <div style="clear: both;">
    </div>
    <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>