<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="weipin.Search" ValidateRequest="false" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>商品搜索_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
</head>
<body>
    <uc1:top ID="top1" runat="server" />
    <link href="css/search.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery/jquery.cookie.min.js" type="text/javascript"></script>
    <script src="js/search.js" type="text/javascript"></script>
    <div class="w970">
        <div id="divTag" class="dqwz">您现在的位置：<a href="/index.html">首页</a> > <span>商品搜索</span></div>
        <div class="sec_l">
            <div class="sec_tit01">新品推荐</div>
            <div id="divSeasonRecommend" class="sec_box"></div>
            <div id="divMyBrowsedListTag" class="sec_tit01" style="margin-top:10px;">我最近浏览</div>
            <div id="divMyBrowsedList" class="sec_box"></div>
        </div>
        <div class="sec_r">
<div class="type_box"><input type="hidden" id="hidSort" runat="server" value="1" /></div>
<div class="type_runc">
<ul class="l">
<li class="pad">排序：</li><li><a href="#" onclick="ListSort(1);return false;" id="aRelated" class="type_but">相关性</a></li>
<li><a href="#" onclick="ListSort(2);return false;" id="aNewest" class="type_but">最新</a></li>
<li><a href="#" onclick="ListSort(3);return false;" id="aLowToHigh" class="type_but ico_type2">价格由低到高</a></li>
<li><a href="#" onclick="ListSort(4);return false;" id="aHighToLow" class="type_but ico_type1">价格由高到低</a></li></ul>
<ul id="ulPage" runat="server" class="r"></ul>
<div class="clear"></div>
</div>
            <div>
                <div id="divSearchList" runat="server" class="sec_lsit"></div>
                <div id="divPaging" runat="server" class="page"></div>
                <input type="hidden" id="hidKey" runat="server" />
            </div>
        </div>
        <div class="clear"></div>
    </div>
    <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>