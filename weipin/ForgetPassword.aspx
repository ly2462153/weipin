<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs"
    Inherits="weipin.ForgetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>忘记密码_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
    <link href="css/forgetpassword.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="js/jquery/jquery.validate.min.js" type="text/javascript"></script>
    <script src="js/jquery/jquery.cookie.min.js" type="text/javascript"></script>
    <script src="js/forgetpassword.js" type="text/javascript"></script>
    <script src="/js/jquery/tipswindown.min.js" type="text/javascript"></script>
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
    <div class="logo_tit">
        <div class="l" style="font-size: 14px; font-weight: bold;">找回密码</div>
        <div class="r">我已经注册 ，立即<a href="Login.aspx" style="padding-right: 20px; color: #003399;">登录</a></div>
    </div>
    <div class="logo_box">
        <div>
            <div style="line-height: 90px; text-indent: 4em; font-size: 14px;">忘记了密码？请输入用户名和注册时填写的邮箱，我们会把重设密码邮件发送到您的邮箱！</div>
            <form id="fmForgetPassword" method="post" runat="server">
            <table width="90%" border="0">
                <tr>
                    <td width="20%" height="40" align="right" style="font-size: 14px;">用户名：</td>
                    <td width="80%">
                        <input type="text" id="txtLoginID" name="txtLoginID" class="logo_input" size="45"
                            maxlength="20" />
                    </td>
                </tr>
                <tr>
                    <td width="20%" height="40" align="right" style="font-size: 14px;">邮箱：</td>
                    <td width="80%">
                        <input type="text" id="txtEmail" name="txtEmail" class="logo_input" size="45" maxlength="50" />
                    </td>
                </tr>
                <tr>
                    <td height="40" align="right" style="font-size: 14px;">验证码：</td>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="98">
                                    <input type="text" id="txtVerifyCode" name="txtVerifyCode" class="openbox_input2"
                                        maxlength="4" /></td>
                                <td>
                                    <script language="javascript" type="text/javascript">
                                        document.write("<img id=imgVerifyCode src=verifycode/ForgetPasswordVerifyCode.aspx?",Math.random(),">");
                                    </script>
                                </td>
                                <td width="122">&nbsp;看不清？<a href="#" style="color: #005AA0;" onclick="ChangeCode();return false;">换一张</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="80">&nbsp;</td>
                    <td>
                        <img src="img/suer.jpg" id="imgSubmit" width="96" height="38" style="cursor: pointer;" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td height="40">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <div class="food"><a href="/help/aboutus.html" target="_blank">关于我们</a>|<a href="/help/businesscooperation.html" target="_blank">商务合作</a>|<a href="/help/MySuggest.aspx" target="_blank">用户反馈</a><br />Copyright &copy; 2013 微品网上商城 版权所有 蜀ICP备11026502号</div>
<span style="display: none;"><script type="text/javascript">var _bdhmProtocol=(("https:"==document.location.protocol)?" https://":" http://");document.write(unescape("%3Cscript src='"+_bdhmProtocol+"hm.baidu.com/h.js%3F86db9334e8f9422b3e8f7dfe91f7ef0c' type='text/javascript'%3E%3C/script%3E"));</script><script type="text/javascript">
var _bdhmProtocol=(("https:"==document.location.protocol)?" https://":" http://");
document.write(unescape("%3Cscript src='"+_bdhmProtocol+"hm.baidu.com/h.js%3F55b43d07c531867409e5de8a43537eb7' type='text/javascript'%3E%3C/script%3E"));
</script></span>
</body>
</html>