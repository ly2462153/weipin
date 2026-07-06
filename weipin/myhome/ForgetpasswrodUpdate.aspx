<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetpasswrodUpdate.aspx.cs"
    Inherits="weipin.myhome.ForgetpasswrodUpdate" %>

<%@ Register Src="../controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="../controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>修改密码_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
    <link href="css/forgetpasswrodupdate.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc1:top ID="top1" runat="server" />
    <script src="js/forgetpasswrodupdate.js" type="text/javascript"></script>
    <script src="/js/jquery/jquery.validate.min.js" type="text/javascript"></script>
    <script src="/js/jquery/tipswindown.min.js" type="text/javascript"></script>
    <div class="main"><div class="main_left l"><h1>我的微品</h1><ul><li class="li">交易管理</li><li><a href="/myhome/MyOrdersList.aspx">我的订单</a></li><li><a href="/myhome/MyReturnOrdersList.aspx">退换货办理</a></li><li><a href="/myhome/MyCollectList.aspx">我的收藏</a></li><li><a href="/myhome/GoodsCommentsList.aspx">商品评论</a></li><li class="li">账户管理</li><li><a href="/myhome/UserInfo.aspx">个人资料</a></li><li><a href="/myhome/UpdatePassword.aspx">修改密码</a></li><li><a href="/myhome/MyShippingAddressesList.aspx">收货地址</a></li><li><a href="/myhome/MyIntegralList.aspx">我的积分</a></li></ul></div>
        <div class="main_right r">
            <h1>修改密码</h1>
            <div id="divForm" runat="server">
                <form id="fmUpdatePassword" method="post" runat="server">
                <table width="100%" border="0">
                    <tr>
                        <td width="33%" class="tdL">请输入新密码：</td>
                        <td width="67%" colspan="2">
                            <input type="password" id="txtNewPassword" name="txtNewPassword" class="logo_input"
                                maxlength="20" runat="server" /><input type="hidden" id="hidOldPassword" name="hidOldPassword" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">请再次输入新密码：</td>
                        <td colspan="2">
                            <input type="password" id="txtConfirmNewPassword" name="txtConfirmNewPassword" class="logo_input"
                                maxlength="20" runat="server" />
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
                                            document.write("<img id=imgVerifyCode src=/verifycode/ForgetpasswrodUpdateVerifyCode.aspx?",Math.random(),">");
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
                            <a href="#" id="aSubmit" onclick="FormSubmit();return false;">确定</a>
                        </td>
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