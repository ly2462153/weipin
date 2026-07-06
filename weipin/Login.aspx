<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="weipin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="x-ua-compatible" content="ie=7" />
<title>会员登录_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
<link href="css/login.css" rel="stylesheet" type="text/css" />
<script src="js/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
<script src="js/jquery/jquery.cookie.min.js" type="text/javascript"></script>
<script src="js/jquery/jquery.validate.min.js" type="text/javascript"></script>
<script type="text/javascript" src="http://qzonestyle.gtimg.cn/qzone/openapi/qc_loader.js" data-appid="100387986" data-redirecturi="http://www.weipin365.com/qc_back.html" charset="utf-8"></script>
<script src=" http://tjs.sjs.sinajs.cn/open/api/js/wb.js?appkey=3830747693" type="text/javascript" charset="utf-8"></script>
<script src="js/login.js" type="text/javascript"></script>
</head>
<body>
<div class="head">
<div class="w970">
<div class="head_l">
<ul id="ulLoginMessage" runat="server">
</ul>
</div>
<div class="shopbg"><div class="shopbg_s02" ><a href="/ShoppingCart.aspx">去结算</a></div><div class="shopbg_m">购物车<span class="shopbg_s01"><a href="/ShoppingCart.aspx" id="spCount">0</a></span>件</div><div style="float:right;"><img src="/img/shopbg_l.jpg" width="34" height="30" /></div></div>
<div class="head_r">
<ul>
<li><a href="/myhome/MyOrdersList.aspx" class="top_hidico">我的微品</a></li>
<div class="top_hid">
<ul>
<li><a href="/myhome/MyOrdersList.aspx">我的订单</a></li>
<li><a href="/myhome/MyCollectList.aspx">我的收藏</a></li>
<li><a href="/myhome/MyIntegralList.aspx">我的积分</a></li>
</ul>
</div>
</ul>
</div>
<div class="wddd"><a href="/myhome/MyOrdersList.aspx">我的订单</a></div>
</div>
<div class="clear"></div>
</div>
<div class="top w970">
<a href="/index.html" title="微品网上商城_心动小商品" class="logo"></a>
</div>
<div class="logo_tit">用户登录</div>
<div class="logo_box">
<div>
<div class="l">
<form id="fmLogin" method="post">
<table width="600" border="0">
<tr>
<td height="40" align="right" style="font-size: 14px;">
<br />
<input name="hidUrlReferrer" type="hidden" id="hidUrlReferrer" value="http://www.weipin365.com" />
</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td width="22%" align="right" valign="top" height="58" style="font-size: 14px; padding-top: 8px;">
用户名：<br />
</td>
<td width="43%" valign="top">
<input type="text" id="txtLoginID" name="txtLoginID" class="logo_input" runat="server"
onkeydown="EnterPress(event);" maxlength="20" />
<label id="lblLoginID" runat="server" class="error"></label>
</td>
<td width="35%">&nbsp;</td>
</tr>
<tr>
<td align="right" valign="top" height="58" style="font-size: 14px; padding-top: 8px;">
密码：</td>
<td valign="top">
<input type="password" id="txtPassword" name="txtPassword" onkeydown="EnterPress(event);"
class="logo_input" maxlength="20" />
<label id="lblLoginPassword" runat="server" class="error"></label>
</td>
<td valign="top" style="padding-top: 8px;"><a href="ForgetPassword.aspx">忘记密码？</a>
</td>
</tr>
<tr>
<td height="10">&nbsp;</td>
<td>
<table width="200" border="0" cellspacing="5">
<tr>
<td width="23" align="right">
<label>
    <input type="checkbox" name="ckbRemember" />
</label>
</td>
<td width="132">记住密码</td>
<td width="10">&nbsp;</td>
<td width="17">&nbsp;</td>
</tr>
</table>
</td>
<td>&nbsp;</td>
</tr>
<tr>
<td height="70">&nbsp;</td>
<td><a href="#" id="aLogin" onclick="Login();return false;">
<img src="img/logo_but01.jpg" width="110" height="38" /></a></td>
<td>&nbsp;</td>
</tr>
<tr>
<td height="30" colspan="3" style="color:#666; padding-left:50px;">使用合作网站账号登录微品：</td>
</tr>
<tr>
<td height="30" style="padding-left:43px;">
<div id="divQQLogin" style="padding:3px 0 30px 0;"></div>
</td>
<td><div id="divSinaLogin" style="padding-bottom:30px;"></div></td>
<td>&nbsp;</td>
</tr>
</table>
</form>
</div>
</div>
<div class="logo_r">
<ul>
<li>您还没注册吗？请点击注册微品网络超市</li>
<li><a href="/Register.aspx">
<img src="img/logo_but03.jpg" width="119" height="45" /></a></li>
</ul>
</div>
<div></div>
<div class="clear"></div>
</div>
<div class="food"><a href="/help/aboutus.html" target="_blank">关于我们</a>|<a href="/help/businesscooperation.html" target="_blank">商务合作</a>|<a href="/help/MySuggest.aspx" target="_blank">用户反馈</a><br />Copyright &copy; 2013 微品网上商城 版权所有 蜀ICP备11026502号</div>
<span style="display: none;"><script type="text/javascript">var _bdhmProtocol=(("https:"==document.location.protocol)?" https://":" http://");document.write(unescape("%3Cscript src='"+_bdhmProtocol+"hm.baidu.com/h.js%3F86db9334e8f9422b3e8f7dfe91f7ef0c' type='text/javascript'%3E%3C/script%3E"));</script>
<script type="text/javascript">
var _bdhmProtocol=(("https:"==document.location.protocol)?" https://":" http://");
document.write(unescape("%3Cscript src='"+_bdhmProtocol+"hm.baidu.com/h.js%3F55b43d07c531867409e5de8a43537eb7' type='text/javascript'%3E%3C/script%3E"));
</script>
</span>
</body>
</html>