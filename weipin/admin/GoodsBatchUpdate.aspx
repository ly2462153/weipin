<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsBatchUpdate.aspx.cs"
    Inherits="weipin.admin.GoodsBatchUpdate" %>

<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>商品批量更新</title>
    <link href="css/goodsbatchupdate.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <uc1:headadmin ID="headadmin1" runat="server" />
        <script src="js/goodsbatchupdate.js" type="text/javascript"></script>
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
                    <li id="submenu-active"><a href="GoodsBatchUpdate.aspx">商品批量更新</a></li>
                    <li><a href="CreateGoodsIndex.aspx">创建索引</a></li>
                </ul>
            </div>
            <div id="content" class="box">
                <h1>商品批量更新</h1>
                <fieldset>
                    <table class="nostyle" style="width: 100%;">
                        <tr>
                            <td style="width:100px;">进度:</td>
                            <td style="text-align: left;"><span id="spFinished">0</span>/<span id="spTotal" runat="server"></span><input
                                type="hidden" id="hidGoodsIDMuster" runat="server" /><span>(已完成/总量)</span>
                            </td>
                        </tr>
                        <tr>
                            <td>未成功更新商品:</td>
                            <td style="text-align: left;"><span id="spMsg"></span></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <input type="button" id="btnBatchUpdate" class="input-submit" value="批量更新" />&nbsp;&nbsp;<input
                                    type="button" id="btnClear" class="input-submit" value="清零" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </div>
</body>
</html>