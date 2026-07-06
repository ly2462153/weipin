<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="top.ascx.cs" Inherits="weipin.controls.top" %>
<link href="/css/top.css" rel="stylesheet" type="text/css" />
<script src="/js/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
<script src="/js/jquery/jquery.cookie.min.js" type="text/javascript"></script>
<script src="/js/top.js" type="text/javascript"></script>
<div class="head">
<div class="w970">
<div class="head_l"><ul id="ulLoginMessage" runat="server"></ul></div>
<div class="shopbg"><div class="shopbg_s02" ><a href="/ShoppingCart.aspx">去结算</a></div><div class="shopbg_m">购物车<span class="shopbg_s01"><a href="/ShoppingCart.aspx" id="spCount">0</a></span>件</div><div style="float:right;"><img src="/img/shopbg_l.jpg" width="34" height="30" /></div></div>
<div class="head_r">
<ul><li><a href="/myhome/MyOrdersList.aspx" class="top_hidico">我的微品</a></li>
<div class="top_hid"><ul><li><a href="/myhome/MyOrdersList.aspx">我的订单</a></li><li><a href="/myhome/MyCollectList.aspx">我的收藏</a></li><li><a href="/myhome/MyIntegralList.aspx">我的积分</a></li></ul></div>
</ul>
</div>
<div class="wddd"><a href="/myhome/MyOrdersList.aspx">我的订单</a></div>
</div><div class="clear"></div>
</div>
<div class="top w970">
<a href="/index.html" title="微品网上商城_心动小商品" class="logo"></a>
<div class="menu">
<div class="tel">全国客服热线：<span>400-728-6962</span></div>
<div class="menu_tab">
<div class="menu_down"><span class="menu_down01"></span><a href="/index.html" class="menu_down02">首页</a><span class="menu_down03"></span></div>
<div class="menu_down"><span class="menu_down01"></span><a href="/page/categorygoods/categorygoods_17.html" class="menu_down02">潮流饰品</a><span class="menu_down03"></span></div>
<div class="menu_down"><span class="menu_down01"></span><a href="/page/categorygoods/categorygoods_3.html" class="menu_down02">服饰/帽袜</a><span class="menu_down03"></span></div>
<div class="menu_down"><span class="menu_down01"></span><a href="/page/categorygoods/categorygoods_9.html" class="menu_down02">家居/家纺</a><span class="menu_down03"></span></div>
<div class="menu_down"><span class="menu_down01"></span><a href="/page/categorygoods/categorygoods_20.html" class="menu_down02">汽车用品</a><span class="menu_down03"></span></div>
<div class="menu_down"><span class="menu_down01"></span><a href="/page/categorygoods/categorygoods_63.html" class="menu_down02">生活日用</a><span class="menu_down03"></span></div>
</div>
</div>
</div>
<div class=" w970 menu_sec">
<form method="get" action="/Search.aspx" accept-charset="gbk" onsubmit="document.charset='gbk';">
<div class="input_box">
<input type="text" name="key" class="input_s" maxlength="50" />
</div>
<div style="float: left;">
<input type="submit" class="but_s" value="搜索" />
</div>
</form>
<div class="hot">热门搜索：<a href="/Search.aspx?key=%D1%FC%BF%BF">腰靠</a><a href="/Search.aspx?key=%BE%B1%D5%ED">颈枕</a><a href="/Search.aspx?key=%D6%F1%CC%BF%B9%AB%D7%D0">竹炭公仔</a><a href="/Search.aspx?key=%CA%D6%BB%FA%BF%C7">手机壳</a><a href="/Search.aspx?key=%C2%ED%BF%CB%B1%AD">马克杯</a></div>
<div class="but_gn"><span class="tjcx"><a href="/NewGoodsList.aspx" target="_blank" style="background:url(/img/but_gn01.gif) no-repeat 0 0;">新品上架</a></span><span class="tuang"><a href="/DiscountGoodsList.aspx" target="_blank" style="background:url(/img/but_gn01.gif) no-repeat -78px 0;">特惠抢购</a></span></div>
</div>