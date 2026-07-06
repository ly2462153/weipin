<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyUpdateEmail.aspx.cs" Inherits="weipin.myhome.VerifyUpdateEmail" %>

<%@ Register Src="../controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="../controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<%@ Register Src="../controls/myhome.ascx" TagName="myhome" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>修改验证邮箱_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
    <link href="css/verifyupdateemail.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc1:top ID="top1" runat="server" />
    <script src="js/verifyupdateemail.js" type="text/javascript"></script>
    <script src="../js/jquery/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../js/jquery/tipswindown.min.js" type="text/javascript"></script>
    <div class="main">
        <uc3:myhome ID="myhome1" runat="server" />
        <div class="main_right r">
            <h1>修改验证邮箱</h1>
            <div>
                <form id="fmVerifyEmail" method="post" runat="server">
                <table width="100%" border="0">
                    <tr>
                        <td width="33%" class="tdL">验证过的邮箱：</td>
                        <td width="67%">
                            <label id="lblOldEmail" runat="server"></label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tdL">请重新输入验证过的邮箱：</td>
                        <td colspan="2">
                            <input type="text" id="txtOldEmail" name="txtOldEmail" class="logo_input" maxlength="50"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">请输入需要验证的新邮箱：</td>
                        <td colspan="2">
                            <input type="text" id="txtNewEmail" name="txtNewEmail" class="logo_input" maxlength="50"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">验证码：</td>
                        <td colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="98">
                                        <input type="text" id="txtVerifyCode" name="txtVerifyCode" class="openbox_input2"
                                            maxlength="4" /></td>
                                    <td>
                                        <script language="javascript" type="text/javascript">
                                            document.write("<img id=imgVerifyCode src=/verifycode/EmailVerifyCode.aspx?",Math.random(),">");
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
                        <td><a href="#" id="aSubmit" onclick="FormSubmit();return false;">确定</a> </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                </form>
            </div>
        </div>
    </div>
    <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>