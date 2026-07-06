<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPop.aspx.cs" Inherits="weipin.LoginPop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title></title>
    <link href="css/loginpop.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="js/jquery/jquery.validate.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://qzonestyle.gtimg.cn/qzone/openapi/qc_loader.js" data-appid="100387986" data-redirecturi="http://www.weipin365.com/qc_back.html" charset="utf-8"></script>
    <script src=" http://tjs.sjs.sinajs.cn/open/api/js/wb.js?appkey=3830747693" type="text/javascript" charset="utf-8"></script>
    <script src="js/loginpop.js" type="text/javascript"></script>
</head>
<body>
    <div class="openbox_tab"><span class="openbox_tab01">登录</span><span class="openbox_tab02">
        <a href="/Register.aspx?returnurl=<%= _thisurl %>" target="_parent">注册</a></span></div>
    <form id="fmLogin" method="post">
    <table width="94%" border="0" align="center" cellspacing="4" style="padding-top: 20px;">
        <tr>
            <td width="50" align="right" valign="top" height="58" style="padding-top: 8px;">用户名：<br />
            </td>
            <td width="220" valign="top">
                <input type="text" id="txtLoginID" name="txtLoginID" class="logo_input" runat="server"
                    onkeydown="EnterPress(event);" maxlength="20" />
                <label id="lblLoginID" runat="server" class="error">
                </label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="right" valign="top" height="55" style="padding-top: 8px;">密码：</td>
            <td valign="top">
                <input type="password" id="txtPassword" name="txtPassword" onkeydown="EnterPress(event);"
                    class="logo_input" maxlength="20" />
                <label id="lblLoginPassword" runat="server" class="error">
                </label>
            </td>
            <td valign="top" style="padding-top: 8px;"><a href="/ForgetPassword.aspx" target="_blank">
                忘记密码？</a></td>
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
    </table>
    </form>
    <div class="but_div">
        <ul>
            <li><a href="#" class="openbox_but" onclick="Login();return false;" style="color: #fff;">登录</a></li>
            <li>新用户？<a href="/Register.aspx?returnurl=<%= _thisurl %>" target="_parent">立即注册</a></li>
        </ul>
        <div class="clear"></div>
    </div>
    <div class="but_div" style="color:#666;">使用合作网站账号登录微品：</div>
    <div style="margin-left:20px;"><div id="divQQLogin" style="float:left;padding-right:10px;"></div><div id="divSinaLogin"></div></div>
<span style="display: none;"><script type="text/javascript">var _bdhmProtocol=(("https:"==document.location.protocol)?" https://":" http://");document.write(unescape("%3Cscript src='"+_bdhmProtocol+"hm.baidu.com/h.js%3F86db9334e8f9422b3e8f7dfe91f7ef0c' type='text/javascript'%3E%3C/script%3E"));</script><script type="text/javascript">
var _bdhmProtocol=(("https:"==document.location.protocol)?" https://":" http://");
document.write(unescape("%3Cscript src='"+_bdhmProtocol+"hm.baidu.com/h.js%3F55b43d07c531867409e5de8a43537eb7' type='text/javascript'%3E%3C/script%3E"));
</script></span>
</body>
</html>