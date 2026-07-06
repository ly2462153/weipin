<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsList.aspx.cs" Inherits="weipin.GoodsList" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="x-ua-compatible" content="ie=7" />
<title id="ttName" runat="server"></title>
</head>
<body>
<uc1:top ID="top1" runat="server" />
<link href="css/goodslist.css" rel="stylesheet" type="text/css" />
<script src="js/jquery/jquery.cookie.min.js" type="text/javascript"></script>
<script src="js/goodslist.js" type="text/javascript"></script>
<div class="w970" style="margin-top:8px;cursor:pointer;"><a href="/help/deliverypay.html" target="_blank"><img src="/file/images/homepage/mianyunfei.jpg" alt="全场满38元免运费" title="全场满38元免运费" /></a></div>
<div class="w970">
<div id="divTag" class="dqwz"></div>
<div class="sec_l">
<div id="divCategory" class="sec_menubox"></div>
<div class="sec_tit01">新品推荐</div>
<div id="divSeasonRecommend" class="sec_box"></div>
<div id="divMyBrowsedListTag" class="sec_tit01">我最近浏览</div>
<div id="divMyBrowsedList" class="sec_box"></div>
</div>
<div class="sec_r">
<div class="type_box">
<ul id="ulAttributes"></ul>
<input type="hidden" id="hidCategoryID2" runat="server" />
<input type="hidden" id="hidCategoryID3" runat="server" />
<input type="hidden" id="hidAttributes" runat="server" />
<input type="hidden" id="hidSort" runat="server" value="1" />
</div>
<div class="type_runc">
<ul class="l">
<li class="pad">排序：</li><li><a href="#" onclick="ListSort(1);return false;" id="aActiveDemand" class="type_but">畅销</a></li>
<li><a href="#" onclick="ListSort(2);return false;" id="aNewest" class="type_but">最新</a></li>
<li><a href="#" onclick="ListSort(3);return false;" id="aLowToHigh" class="type_but ico_type2">价格由低到高</a></li>
<li><a href="#" onclick="ListSort(4);return false;" id="aHighToLow" class="type_but ico_type1">价格由高到低</a></li>
<li><input type="text" id="txtStartPrice" runat="server" class="input_jia" maxlength="5"
onkeydown="EnterPress(event);" />-<input type="text" id="txtEndPrice" runat="server"
class="input_jia" maxlength="5" onkeydown="EnterPress(event);" />元</li>
<li><a href="#" onclick="ChoosePrice();return false;">
<img style="margin-top: 6px;" src="img/but_sure.gif" width="40" height="22" /></a></li></ul>
<ul id="ulPage" runat="server" class="r"></ul>
<div class="clear"></div>
</div>
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