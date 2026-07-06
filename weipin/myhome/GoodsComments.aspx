<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsComments.aspx.cs"
    Inherits="weipin.myhome.GoodsComments" %>

<%@ Register Src="../controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="../controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<%@ Register Src="../controls/myhome.ascx" TagName="myhome" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>商品评论_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
    <link href="css/goodscomments.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc1:top ID="top1" runat="server" />
    <script src="js/goodscomments.js" type="text/javascript"></script>
    <script src="/js/jquery/jquery.validate.textarea.js" type="text/javascript"></script>
    <script src="/js/jquery/tipswindown.min.js" type="text/javascript"></script>
    <div class="main">
        <uc3:myhome ID="myhome1" runat="server" />
        <div class="main_right r">
            <h1>商品评论</h1>
            <div id="divComment" runat="server" style="margin: 20px 0 0 20px;">
                <form id="fmComments" method="post" runat="server">
                <div id="divGoods" runat="server" class="imgbox"></div>
                <div class="comment">
                    <div><span>外观评分:</span><img src="/img/s1.gif" title="1" /><img src="/img/s1.gif"
                        title="2" /><img src="/img/s1.gif" title="3" /><img src="/img/s1.gif" title="4" /><img
                            src="/img/s1.gif" title="5" /><input type="hidden" name="hidAppearance" value="5" /></div>
                    <div><span>质量评分:</span><img src="/img/s1.gif" title="1" /><img src="/img/s1.gif"
                        title="2" /><img src="/img/s1.gif" title="3" /><img src="/img/s1.gif" title="4" /><img
                            src="/img/s1.gif" title="5" /><input type="hidden" name="hidQuality" value="5" /></div>
                    <div><span>综合评分:</span><img src="/img/s1.gif" title="1" /><img src="/img/s1.gif"
                        title="2" /><img src="/img/s1.gif" title="3" /><img src="/img/s1.gif" title="4" /><img
                            src="/img/s1.gif" title="5" /><input type="hidden" name="hidComment" value="5" /></div>
                    <div><span style="vertical-align: top;">商品评论:</span><textarea id="txtComment" name="txtComment"
                        style="width: 500px; height: 155px; margin-left: 6px; font-size: 12px;"></textarea>
                        <span>5-200字之间</span></div>
                    <div style="height: 12px;"><span id="spCommentMsg" class="red"></span></div>
                    <div><a href="#" id="aSubmit" onclick="FormSubmit();return false;">发表评论</a></div>
                </div>
                </form>
            </div>
        </div>
    </div>
    <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>