<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewGoodsList.aspx.cs" Inherits="weipin.NewGoodsList" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="x-ua-compatible" content="ie=7" />
<title>新品上架_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
</head>
<body>
<uc1:top ID="top1" runat="server" />
<link href="css/newgoodslist.css" rel="stylesheet" type="text/css" />
<script src="js/jquery/jquery.cookie.min.js" type="text/javascript"></script>
<script src="js/newgoodslist.js" type="text/javascript"></script>
<div class="w970" style="margin-top:8px;cursor:pointer;"><a href="/help/deliverypay.html" target="_blank"><img src="/file/images/homepage/mianyunfei.jpg" alt="全场满38元免运费" title="全场满38元免运费" /></a></div>
<div class="w970">
<div class="dqwz">您现在的位置：<a href="index.html">首页</a> > <span>新品上架</span></div>
<div class="sec_l">
<div class="sec_tit01">新品推荐</div>
<div id="divSeasonRecommend" class="sec_box"></div>
<div id="divMyBrowsedListTag" class="sec_tit01" style="margin-top:10px;">我最近浏览</div>
<div id="divMyBrowsedList" class="sec_box"></div>
</div>
<div class="sec_r">
<div class="sycon_titbg"><div class="sycon_tit01">新品上架</div><div class="sycon_tit02"><a href="/GoodsList.aspx?cid3=97&sp=&ep=&atb=&st=2" target="_blank">ipad保护套</a><a href="/GoodsList.aspx?cid3=45&sp=&ep=&st=2" target="_blank">手机壳</a><a href="/GoodsList.aspx?cid2=70&sp=&ep=&st=2" target="_blank">颈枕靠垫</a><a href="/GoodsList.aspx?cid3=29&sp=&ep=&atb=&st=2" target="_blank">马克杯</a><a href="/GoodsList.aspx?cid3=22&sp=&ep=&st=2" target="_blank">抱枕头枕</a><a href="/GoodsList.aspx?cid3=30&sp=&ep=&st=2" target="_blank">竹炭公仔</a><a href="/GoodsList.aspx?cid3=57&sp=&ep=&st=2" target="_blank">汽车摆挂饰</a><a href="/GoodsList.aspx?cid2=87&sp=&ep=&st=2" target="_blank">收纳用品</a><a href="/GoodsList.aspx?cid2=98&sp=&ep=&st=2" target="_blank">香薰香包</a><a href="/GoodsList.aspx?cid3=102&sp=&ep=&atb=&st=2" target="_blank">地毯地垫</a></div></div>
<div>
<div id="divGoodsList" runat="server" class="sec_lsit"></div>
<div id="divPaging" runat="server" class="page"></div>
</div>
</div>
<div class="clear"></div>
</div>
<uc2:bottom ID="bottom1" runat="server" />
</body>
</html>