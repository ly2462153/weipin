<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headadmin.ascx.cs" Inherits="weipin.admin.controls.headadmin" %>
<link href="css/headadmin.css" rel="stylesheet" type="text/css" />
<link rel="alternate stylesheet" type="text/css" href="css/1col.css" title="1col" />
<link rel="stylesheet" type="text/css" href="css/2col.css" title="2col" />
<!--[if lte IE 6]><link rel="stylesheet" type="text/css" href="css/main-ie6.css" /><![endif]-->
<script src="../js/jQuery/jquery-1.3.2.min.js" type="text/javascript"></script>
<script src="js/switcher.js" type="text/javascript"></script>
<div id="tray" class="box">
    <p class="f-left box"><span class="f-left" id="switcher"><a href="#" rel="1col" class="styleswitch ico-col1"
        title="Display one column">
        <img src="img/switcher-1col.gif" alt="1 Column" /></a> <a href="#" rel="2col" class="styleswitch ico-col2"
            title="Display two columns">
            <img src="img/switcher-2col.gif" alt="2 Columns" /></a> </span>您好: <strong id="stName"
                runat="server"></strong>&nbsp;&nbsp;今天是:<strong id="stToday" runat="server"></strong>
    </p>
    <p class="f-right">&nbsp;&nbsp; <strong><a href="/Logout.aspx?logout=2" id="logout">
        退出</a></strong></p>
</div>
<div id="menu" class="box">
    <ul class="box">
        <li><a href="GoodsAdd.aspx"><span>商品管理</span></a></li>
        <li><a href="OrdersList.aspx"><span>订单管理</span></a></li>
        <li><a href="CouriersAdd.aspx"><span>人员管理</span></a></li>
        <li><a href="Cagegories.aspx"><span>分类管理</span></a></li>
        <li><a href="SendAdvertisementMail.aspx"><span>邮件管理</span></a></li>
    </ul>
</div>