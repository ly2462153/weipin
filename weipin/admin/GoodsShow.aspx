<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsShow.aspx.cs" Inherits="weipin.admin.GoodsShow"
    ValidateRequest="false" %>

<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>商品详情</title>
    <link href="css/goodsshow.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <uc1:headadmin ID="headadmin1" runat="server" />
        <script src="js/goodsshow.js" type="text/javascript"></script>
        <div id="cols" class="box">
            <div id="aside" class="box">
                <div class="padding box">
                    <p id="logo"><a href="http://www.weipin365.com" target="_blank"><img src="/img/logolengthways.gif" alt="" /></a></p>
                </div>
                <form action="GoodsShow.aspx" method="post">
                <fieldset>
                    <legend>搜索</legend>
                    <p>
                        <input type="text" name="txtSearch" class="input-text-02" style="width: 138px; height: 19px;" />&nbsp;<input
                            type="submit" value="搜索" class="input-submit-02" /></p>
                </fieldset>
                </form>
                <ul class="box">
                    <li id="submenu-active"><a href="GoodsAdd.aspx">商品添加</a></li>
                    <li><a href="GoodsCommentsList.aspx">评价列表</a></li>
                    <li><a href="SizesAdd.aspx">尺码添加</a></li>
                    <li><a href="SizesList.aspx">尺码列表</a></li>
                    <li><a href="GoodsSupplyList.aspx">库存补给列表</a></li>
                    <li><a href="GoodsBatchUpdate.aspx">商品批量更新</a></li>
                    <li><a href="CreateGoodsIndex.aspx">创建索引</a></li>
                </ul>
            </div>
            <div id="content" class="box">
                <h1>显示</h1>
                <div id="divOperate" runat="server" style="padding-top: 5px;">
                    <input type="button" id="btnUpdate" value="修改" class="input-submit" />&nbsp;<input
                        type="button" id="btnDelete" value="删除" class="input-submit" /></div>
                <table id="tbGoodsShow" runat="server" class="borderstyle" style="width: 100%;">
                    <tr>
                        <td class="tdL">分类:</td>
                        <td colspan="3">
                            <div id="divCategories"></div>
                            <input type="hidden" id="hidCategoryID1" name="hidCategoryID1" runat="server" />
                            <input type="hidden" id="hidCategoryID3" name="hidCategoryID3" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="3">
                            <div id="divAttributes"></div>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">编号:</td>
                        <td colspan="3">
                            <label id="lblGoodsID" runat="server"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">名称:</td>
                        <td colspan="3">
                            <label id="lblGoodsName" runat="server"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">关键词:</td>
                        <td colspan="3">
                            <label id="lblKeywords" runat="server"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">同类编号:</td>
                        <td>
                            <label id="lblSimilarNumber" runat="server"></label>
                        </td>
                        <td class="tdL">区别关键词:</td>
                        <td>
                            <label id="lblDifferenceKeywords" runat="server"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">市场价:</td>
                        <td>
                            <label id="lblMarketPrice" runat="server"></label>
                        </td>
                        <td class="tdL">微品价:</td>
                        <td>
                            <label id="lblPrice" runat="server"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">折扣价:</td>
                        <td>
                            <label id="lblDiscountPrice" runat="server"></label>
                        </td>
                        <td class="tdL">重量:</td>
                        <td>
                            <label id="lblGoodsWeight" runat="server"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">尺码:</td>
                        <td colspan="3">
                            <ul id="ulSizes">
                            </ul>
                        </td>
                    </tr>
                    <tr id="trInventory" runat="server">
                        <td class="tdL">库存:</td>
                        <td>
                            <label id="lblInventory" runat="server"></label>
                        </td>
                        <td class="tdL">库存补给线:</td>
                        <td>
                            <label id="lblSupplyLine" runat="server"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">商家类型:</td>
                        <td>
                            <label id="lblMerchantType" runat="server"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">说明:</td>
                        <td colspan="3">
                            <div id="divRemarks" runat="server"></div>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">温馨提示:</td>
                        <td colspan="3">
                            <div id="divWarmPrompt" runat="server"></div>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">是否为特价抢购商品:</td>
                        <td>
                            <label id="lblIsBargain" runat="server"></label>
                        </td>
                        <td class="tdL">是否为首页一级分类置顶促销商品:</td>
                        <td>
                            <label id="lblIsCategoryPromotion" runat="server"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">是否为专题二级分类置顶促销商品:</td>
                        <td>
                            <label id="lblIsCategorySecondPromotion" runat="server"></label>
                        </td>
                        <td class="tdL">是否为专题新品推荐商品:</td>
                        <td>
                            <label id="lblIsNewRecommend" runat="server"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">是否为首页新品推荐商品:</td>
                        <td>
                            <label id="lblIsSeasonRecommend" runat="server"></label>
                        </td>
                        <td class="tdL">是否上架:</td>
                        <td>
                            <label id="lblIsGrounding" runat="server"></label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div id="divGoodsPictures"></div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</body>
</html>
