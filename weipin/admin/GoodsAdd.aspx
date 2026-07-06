<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsAdd.aspx.cs" Inherits="weipin.admin.GoodsAdd"
    ValidateRequest="false" %>

<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>商品添加</title>
    <link href="css/goodsadd.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <uc1:headadmin ID="headadmin1" runat="server" />
        <script src="../js/jQuery/jquery.validate.min.js" type="text/javascript" charset="utf-8"></script>
        <script src="../js/jquery/jquery.validate.textarea.js" type="text/javascript"></script>
        <script src="js/goodsadd.js" type="text/javascript"></script>
        <script src="js/adduploadfiles.js" type="text/javascript"></script>
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
                <h1>添加</h1>
                <fieldset>
                    <form id="form1" method="post">
                    <table class="nostyle" style="width: 100%;">
                        <tr>
                            <td class="tdL">分类:</td>
                            <td colspan="3">
                                <select id="selCategory1" name="selCategory1" class="ctg">
                                </select><select id="selCategory2" name="selCategory2" class="ctg"><option value="">
                                    请选择</option>
                                </select><select id="selCategory3" name="selCategory3" class="ctg"><option value="">
                                    请选择</option>
                                </select><input type="hidden" id="hidCategories" name="hidCategories" /></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">
                                <div id="divAttributes"></div>
                                <input type="hidden" id="hidAttributes" name="hidAttributes" />
                                <input type="hidden" id="hidAttributesXML" name="hidAttributesXML" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">名称:</td>
                            <td colspan="3">
                                <input type="text" id="txtGoodsName" name="txtGoodsName" maxlength="50" class="input-text" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">关键词:</td>
                            <td colspan="3">
                                <input type="text" id="txtKeywords" name="txtKeywords" maxlength="30" class="input-text" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">同类编号:</td>
                            <td>
                                <select id="selSimilarNumber" name="selSimilarNumber">
                                    <option value="">请选择</option>
                                    <option value="1">生成新编号</option>
                                    <option value="0">填写已有编号</option>
                                </select>&nbsp;<input type="text" id="txtSimilarNumber" name="txtSimilarNumber" style="width: 30px;
                                    display: none;" maxlength="8" />
                            </td>
                            <td class="tdL"><span id="spDifferenceKeywords" style="display: none;">区别关键词:</span>
                            </td>
                            <td>
                                <input type="text" id="txtDifferenceKeywords" name="txtDifferenceKeywords" maxlength="15"
                                    class="input-text-03" style="display: none;" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">市场价:</td>
                            <td>
                                <input type="text" id="txtMarketPrice" name="txtMarketPrice" maxlength="6" class="input-text-03" />
                            </td>
                            <td class="tdL">微品价:</td>
                            <td>
                                <input type="text" id="txtPrice" name="txtPrice" maxlength="6" class="input-text-03" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">折扣价:</td>
                            <td>
                                <input type="text" id="txtDiscountPrice" name="txtDiscountPrice" maxlength="6" class="input-text-03" />
                            </td>
                            <td class="tdL">重量:</td>
                            <td>
                                <input type="text" id="txtGoodsWeight" name="txtGoodsWeight" maxlength="5" class="input-text-03" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">尺码:</td>
                            <td colspan="3">
                                <ul id="ulSizes">
                                </ul>
                                <input type="hidden" id="hidSizesXML" name="hidSizesXML" />
                            </td>
                        </tr>
                        <tr id="trInventory">
                            <td class="tdL">库存:</td>
                            <td>
                                <input type="text" id="txtInventory" name="txtInventory" maxlength="8" class="input-text-03" />
                            </td>
                            <td class="tdL">库存补给线:</td>
                            <td>
                                <input type="text" id="txtSupplyLine" name="txtSupplyLine" maxlength="6" class="input-text-03" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">商家类型:</td>
                            <td>
                                <select id="selMerchantType" name="selMerchantType">
                                    <option value="1">自营</option>
                                    <option value="2">入驻商家</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">说明:</td>
                            <td colspan="3">
                                <textarea id="txtRemarks" name="txtRemarks" cols="80" rows="10"></textarea><br />
                                <span id="spMsg" style="color: #ff0000;"></span></td>
                        </tr>
                        <tr>
                            <td class="tdL">温馨提示:</td>
                            <td colspan="3">
                                <textarea id="txtWarmPrompt" name="txtWarmPrompt" cols="80" rows="10"></textarea><br />
                                <span id="spWarmPrompt" style="color: #ff0000;"></span></td>
                        </tr>
                        <tr>
                            <td class="tdL">是否为特价抢购商品:</td>
                            <td>
                                <select id="selIsBargain" name="selIsBargain">
                                    <option value="">请选择</option>
                                    <option value="1">是</option>
                                    <option value="0">否</option>
                                </select>
                            </td>
                            <td class="tdL">是否为首页一级分类置顶促销商品:</td>
                            <td>
                                <select id="selIsCategoryPromotion" name="selIsCategoryPromotion">
                                    <option value="">请选择</option>
                                    <option value="1">是</option>
                                    <option value="0">否</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">是否为专题二级分类置顶促销商品:</td>
                            <td>
                                <select id="selIsCategorySecondPromotion" name="selIsCategorySecondPromotion">
                                    <option value="">请选择</option>
                                    <option value="1">是</option>
                                    <option value="0">否</option>
                                </select>
                            </td>
                            <td class="tdL">是否为专题新品推荐商品:</td>
                            <td>
                                <select id="selIsNewRecommend" name="selIsNewRecommend">
                                    <option value="">请选择</option>
                                    <option value="1">是</option>
                                    <option value="0">否</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">是否为首页新品推荐商品:</td>
                            <td>
                                <select id="selIsSeasonRecommend" name="selIsSeasonRecommend">
                                    <option value="">请选择</option>
                                    <option value="1">是</option>
                                    <option value="0">否</option>
                                </select>
                            </td>
                            <td class="tdL">是否上架:</td>
                            <td>
                                <select id="selIsGrounding" name="selIsGrounding">
                                    <option value="1">是</option>
                                    <option value="0">否</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div id="divUploadBox" class="box"></div>
                                <input type="hidden" id="hidPicPath" name="hidPicPath" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center;">
                                <input type="button" id="btnSubmit" class="input-submit" value="提交" />
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