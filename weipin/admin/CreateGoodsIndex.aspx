<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateGoodsIndex.aspx.cs"
    Inherits="weipin.admin.CreateGoodsIndex" %>

<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>创建索引</title>
    <link href="css/creategoodsindex.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <uc1:headadmin ID="headadmin1" runat="server" />
        <div id="cols" class="box">
            <div id="aside" class="box">
                <div class="padding box">
                    <p id="logo"><a href="http://www.weipin365.com" target="_blank"><img src="/img/logolengthways.gif" alt="" /></a></p>
                </div>
                <form action="GoodsShow.aspx" method="post">
                <fieldset>
                    <legend>搜索</legend>
                    <p>
                        <input type="text" id="txtSearch" name="txtSearch" runat="server" class="input-text-02"
                            style="width: 138px; height: 19px;" />&nbsp;<input type="submit" value="搜索" class="input-submit-02" /></p>
                </fieldset>
                </form>
                <ul class="box">
                    <li><a href="GoodsAdd.aspx">商品添加</a></li>
                    <li><a href="GoodsCommentsList.aspx">评价列表</a></li>
                    <li><a href="SizesAdd.aspx">尺码添加</a></li>
                    <li><a href="SizesList.aspx">尺码列表</a></li>
                    <li><a href="GoodsSupplyList.aspx">库存补给列表</a></li>
                    <li><a href="GoodsBatchUpdate.aspx">商品批量更新</a></li>
                    <li id="submenu-active"><a href="CreateGoodsIndex.aspx">创建索引</a></li>
                </ul>
            </div>
            <div id="content" class="box">
                <h1>创建索引</h1>
                <fieldset>
                    <form runat="server">
                    <table class="nostyle" style="width: 100%;">
                        <tr>
                            <td>
                                <input type="checkbox" id="ckbIndexOptimize" checked="checked" runat="server" />&nbsp;优化索引
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnCreateIndex" Text="创建索引" runat="server" 
                                    CssClass="input-submit" onclick="btnCreateIndex_Click" />
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