<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiscountGoodsList.aspx.cs" Inherits="weipin.DiscountGoodsList" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="x-ua-compatible" content="ie=7" />
<title>特惠抢购_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
</head>
<body>
<uc1:top ID="top1" runat="server" />
<link href="css/discountgoodslist.css" rel="stylesheet" type="text/css" />
<script src="js/jquery/jquery.cookie.min.js" type="text/javascript"></script>
<script src="js/discountgoodslist.js" type="text/javascript"></script>
<div class="w970" style="margin-top:8px;cursor:pointer;"><a href="/help/deliverypay.html" target="_blank"><img src="/file/images/homepage/mianyunfei.jpg" alt="全场满38元免运费" title="全场满38元免运费" /></a></div>
<div class="w970">
<div class="dqwz">您现在的位置：<a href="index.html">首页</a> > <span>特惠抢购</span></div>
<div class="sec_l">
<div class="sec_tit01">新品推荐</div>
<div id="divSeasonRecommend" class="sec_box"></div>
<div id="divMyBrowsedListTag" class="sec_tit01" style="margin-top:10px;">我最近浏览</div>
<div id="divMyBrowsedList" class="sec_box"></div>
</div>
<div class="sec_r">
<div class="sycon_titbg"><div class="sycon_tit01">特惠抢购</div></div>
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