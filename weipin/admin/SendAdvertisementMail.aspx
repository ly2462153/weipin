<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendAdvertisementMail.aspx.cs"
    Inherits="weipin.admin.SendAdvertisementMail" %>

<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>广告邮件</title>
    <link href="css/sendadvertisementmail.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <uc1:headadmin ID="headadmin1" runat="server" />
        <script src="js/sendadvertisementmail.js" type="text/javascript"></script>
        <div id="cols" class="box">
            <div id="aside" class="box">
                <div class="padding box">
                    <p id="logo"><a href="http://www.weipin365.com" target="_blank">
                        <img src="/img/logolengthways.gif" alt="" /></a></p>
                </div>
                <ul class="box">
                    <li id="submenu-active"><a href="SendAdvertisementMail.aspx">广告邮件</a></li>
                </ul>
            </div>
            <div id="content" class="box">
                <h1>广告邮件</h1>
                <fieldset>
                    <form id="fmMail" method="post">
                    <table class="nostyle">
                        <tr>
                            <td class="va-top">邮箱地址 (<span style="color: #ff0000;">多个邮件地址请提行，输入邮箱地址请不要超过100个</span>):
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="width: 850px;">
                                    <textarea id="txtEmailAddress" name="txtEmailAddress" style="width: 600px; height: 200px;"></textarea></div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left;">
                                <input type="button" id="btnSendMail" value="发送" class="input-submit" />
                            </td>
                        </tr>
                    </table>
                    </form>
                </fieldset>
            </div>
        </div>
    </div>
</body>
</html>