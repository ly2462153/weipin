<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MySuggest.aspx.cs" Inherits="weipin.help.MySuggest" %>

<%@ Register Src="../controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="../controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>用户反馈_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
    <link href="css/mysuggest.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc1:top ID="top1" runat="server" />
    <script src="/js/jquery/jquery.validate.textarea.js" type="text/javascript"></script>
    <script src="js/mysuggest.js" type="text/javascript"></script>
    <script src="/js/jquery/tipswindown.min.js" type="text/javascript"></script>
    <div class="jy_box">
        <form id="fmSuggest" method="post" runat="server">
        <p>&nbsp;</p>
        <div class="tex">
            <ul><li class="jy_tit"><img align="absmiddle" src="/img/ico_mail.gif" width="32"
                height="32" /> <span>意见与建议：</span></li><li class="tex01">&nbsp;</li> <li class="tex02">
                    <textarea id="txtSuggest" name="txtSuggest" cols="" rows=""></textarea>
                </li><li class="tex03">&nbsp;</li> <li style="text-align: right"><span id="spMsg"
                    class="error"></span></li></ul>
        </div>
        <div class="sug02">
            <ul><li style="color: red; line-height: 50px;">*请留下一种联系方式，以便于我们与您取得联系！ </li></ul>
            <ul class="input_01"><li>称呼：</li><li>
                <input type="text" id="txtSuggestPerson" name="txtSuggestPerson" class="msg" maxlength="10" />&nbsp;先生/女士</li><li
                    style="width: 60px; text-align: right;">E-mail：</li><li>
                        <input type="text" id="txtEmail" name="txtEmail" runat="server" class="msg" maxlength="50" />
                    </li><li style="width: 120px; text-align: right;">QQ：</li><li>
                        <input type="text" id="txtQQ" name="txtQQ" class="msg" maxlength="20" />
                    </li></ul>
            <ul><li style="clear: both; text-align: center; height: 60px; padding-top: 20px;"><a
                href="#" id="aSubmit" onclick="FormSubmit();return false;"><img src="/img/b_subm.jpg" border="0"
                    align="absmiddle" /></a> 您确认意见与建议填写完毕后，请点击提交按钮提交</li></ul>
        </div>
        </form>
    </div>
    <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>