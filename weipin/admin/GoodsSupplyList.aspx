<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsSupplyList.aspx.cs"
    Inherits="weipin.admin.GoodsSupplyList" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>库存补给列表</title>
    <link href="css/goodssupplylist.css" rel="stylesheet" type="text/css" />
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
                    <li id="submenu-active"><a href="GoodsSupplyList.aspx">库存补给列表</a></li>
                    <li><a href="GoodsBatchUpdate.aspx">商品批量更新</a></li>
                    <li><a href="CreateGoodsIndex.aspx">创建索引</a></li>
                </ul>
            </div>
            <div id="content" class="box">
                <h1>库存补给列表</h1>
                <div>
                    <asp:Repeater ID="rptGoodsSupplyList" runat="server">
                        <HeaderTemplate>
                            <table class="tb" style="border: 1px solid #CFCFCF; margin-top: 10px;">
                                <tr>
                                    <th>商品名称</th>
                                    <th>市场价</th>
                                    <th>微品价</th>
                                    <th>折扣价</th>
                                    <th>重量</th>
                                    <th style="color: #ff0000;">库存</th>
                                    <th style="color: #ff0000;">补给线</th>
                                    <th>销量</th>
                                    <th>点击率</th>
                                    <th>收藏次数</th>
                                    <th>商家类型</th>
                                    <th>特价商品</th>
                                    <th>分类置顶商品</th>
                                    <th>新品推荐商品</th>
                                    <th>上架</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><a href='GoodsShow.aspx?gid=<%# DataBinder.Eval(Container.DataItem, "GoodsID")%>'>
                                    <%# DataBinder.Eval(Container.DataItem, "GoodsName")%></a></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "MarketPrice")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "Price")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "DiscountPrice").ToString()!="0"?DataBinder.Eval(Container.DataItem, "DiscountPrice").ToString():""%>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "GoodsWeight").ToString()!="0"?DataBinder.Eval(Container.DataItem, "GoodsWeight").ToString():""%></td>
                                <td style="color: #ff0000;">
                                    <%# DataBinder.Eval(Container.DataItem, "Inventory")%></td>
                                <td style="color: #ff0000;">
                                    <%# DataBinder.Eval(Container.DataItem, "SupplyLine")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "SalesVolume")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "HitTime")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "CollectTimes")%></td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "MerchantType").ToString() == "1" ? "微品自营" : DataBinder.Eval(Container.DataItem, "MerchantType").ToString() == "2" ? "商家入驻" : ""%>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "IsBargain").ToString() == "True" ? "是" : "否"%>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "IsCategoryPromotion").ToString() == "True" ? "是" : "否"%>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "IsSeasonRecommend").ToString() == "True" ? "是" : "否"%>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "IsGrounding").ToString() == "True" ? "是" : "否"%>
                                </td>
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
