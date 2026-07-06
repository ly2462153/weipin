<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="weipin.admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>登陆</title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="divMain">
        <img src="img/logoLogin.gif" style="padding: 50px 0 10px 0;" />
        <div class="content">
            <table width="80%" border="0" cellspacing="0" align="left" cellpadding="0">
                <tr>
                    <td colspan="2">用户名: </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="text" id="txtLoginUser" runat="server" class="textFieldLogin" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">密码: </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="password" id="txtLoginPSW" runat="server" class="textFieldLogin" />
                    </td>
                </tr>
                <tr height="50">
                    <td style="width: 270px;">
                        <input type="checkbox" id="ckbLoginType" runat="server" checked="true" />记住我的登录状态
                    </td>
                    <td align="right">
                        <asp:Button ID="btnLogin" runat="server" Text="　登 陆..." CssClass="button" OnClick="btnLogin_Click" />
                    </td>
                </tr>
                <tr height="20">
                    <td colspan="2"><span id="spAlert" runat="server" class="red" style="margin-left: 3px;">
                    </span></td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>