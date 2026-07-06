<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsCommentsList.aspx.cs"
    Inherits="weipin.admin.GoodsCommentsList" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>评论审核列表</title>
    <link href="css/goodscommentslist.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <uc1:headadmin ID="headadmin1" runat="server" />
        <script src="js/goodscommentslist.js" type="text/javascript"></script>
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
                    <li id="submenu-active"><a href="GoodsCommentsList.aspx">评价列表</a></li>
                    <li><a href="SizesAdd.aspx">尺码添加</a></li>
                    <li><a href="SizesList.aspx">尺码列表</a></li>
                    <li><a href="GoodsSupplyList.aspx">库存补给列表</a></li>
                    <li><a href="GoodsBatchUpdate.aspx">商品批量更新</a></li>
                    <li><a href="CreateGoodsIndex.aspx">创建索引</a></li>
                </ul>
            </div>
            <div id="content" class="box">
                <h1>评论审核列表</h1>
                <div id="divGoodsCommentsList" runat="server">
                    <select id="selCommentStatus" runat="server" style="margin-top: 10px;">
                        <option value="1">待审核</option>
                        <option value="2">审核通过</option>
                        <option value="3">审核未通过</option>
                    </select>
                    <asp:Repeater ID="rptGoodsCommentsList" runat="server" OnItemDataBound="rptGoodsCommentsList_ItemDataBound">
                        <HeaderTemplate>
                            <table class="tb" style="border: 1px solid #CFCFCF; margin-top: 10px;">
                                <tr>
                                    <th style="width: 200px;">商品名称</th>
                                    <th>评价人</th>
                                    <th>外观评分</th>
                                    <th>质量评分</th>
                                    <th>综合评分</th>
                                    <th>评价内容</th>
                                    <th>&nbsp;</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# ((DataRowView)Container.DataItem)["GoodsName"]%></td>
                                <td>
                                    <%# ((DataRowView)Container.DataItem)["LoginID"]%></td>
                                <td>
                                    <%# ((DataRowView)Container.DataItem)["AppearanceGrade"]%></td>
                                <td>
                                    <%# ((DataRowView)Container.DataItem)["QualityGrade"]%></td>
                                <td>
                                    <%# ((DataRowView)Container.DataItem)["CommentGrade"]%></td>
                                <td>
                                    <%# ((DataRowView)Container.DataItem)["CommentContent"]%></td>
                                <td id="tdStatus1" runat="server"><a href="#" onclick="VerifyComment('<%# ((DataRowView)Container.DataItem)["CommentID"]%>','2','<%# ((DataRowView)Container.DataItem)["OrdersGoodsID"]%>',$(this).parent().attr('id'));return false;">
                                    通过</a>&nbsp;<a href="#" onclick="VerifyComment('<%# ((DataRowView)Container.DataItem)["CommentID"]%>','3','<%# ((DataRowView)Container.DataItem)["OrdersGoodsID"]%>',$(this).parent().attr('id'));return false;">
                                        不通过</a></td>
                                <td id="tdStatus2" runat="server"><a href="#" onclick="VerifyComment('<%# ((DataRowView)Container.DataItem)["CommentID"]%>','3','0');return false;">
                                    删除到垃圾箱</a></td>
                                <td id="tdStatus3" runat="server"><a href="#" onclick="VerifyComment('<%# ((DataRowView)Container.DataItem)["CommentID"]%>','2','0');return false;">
                                    移至审核通过</a></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div id="divPaging" runat="server"></div>
            </div>
        </div>
    </div>
</body>
</html>
