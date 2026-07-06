<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="weipin.Error" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>页面出错</title>
    <link href="/css/error.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc1:top ID="top1" runat="server" />
    <div class="errormian">
        <div class="roll">
            <img src="/img/error/roll.jpg" /></div>
        <div class="text_l">
            <div class="tips">页面出错</div>
            <div class="tip_cont">
                <p><span><strong id="strMsg" runat="server">页面出错啦，您访问的页面不存在</strong></span></p>
                <p><a href="/index.html">请点击返回首页</a></p>
            </div>
        </div>
    </div>
    <span style="display: none;"><script type="text/javascript">var _bdhmProtocol=(("https:"==document.location.protocol)?" https://":" http://");document.write(unescape("%3Cscript src='"+_bdhmProtocol+"hm.baidu.com/h.js%3F86db9334e8f9422b3e8f7dfe91f7ef0c' type='text/javascript'%3E%3C/script%3E"));</script>
        <%--保留此前的JS代码,去掉此后的JS代码--%><script type="text/javascript">
            var _bdhmProtocol=(("https:"==document.location.protocol)?" https://":" http://");
            document.write(unescape("%3Cscript src='"+_bdhmProtocol+"hm.baidu.com/h.js%3F55b43d07c531867409e5de8a43537eb7' type='text/javascript'%3E%3C/script%3E"));
        </script>
    </span>
    <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>