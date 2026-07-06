<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersRemarksEdit.aspx.cs"
    Inherits="weipin.admin.OrdersRemarksEdit" %>

<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>订单备注编辑</title>
    <link href="css/ordersremarksedit.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <uc1:headadmin ID="headadmin1" runat="server" />
        <script src="../js/jQuery/jquery.validate.min.js" type="text/javascript"></script>
        <script src="../js/jquery/jquery.validate.textarea.js" type="text/javascript"></script>
        <script src="../js/calendar.js" type="text/javascript"></script>
        <script src="js/ordersremarksedit.js" type="text/javascript"></script>
        <div id="cols" class="box">
            <div id="aside" class="box">
                <div class="padding box">
                    <p id="logo"><a href="http://www.weipin365.com" target="_blank"><img src="/img/logolengthways.gif" alt="" /></a></p>
                </div>
                <form name="form1" action="OrdersSearchGoodsList.aspx" method="post">
                <fieldset>
                    <legend>订单号</legend>
                    <p>
                        <input type="text" id="txtSearch" name="txtSearch" runat="server" class="input-text-02"
                            style="width: 138px; height: 19px;" />&nbsp;<input type="submit" value="搜索" class="input-submit-02" /></p>
                </fieldset>
                </form>
                <ul class="box">
                    <li><a href="OrdersList.aspx">订单列表</a></li>
                    <li><a href="OrdersOutLibraryList.aspx">出库列表</a></li>
                    <li id="submenu-active"><a href="OrdersChangeGoodsList.aspx">换货列表</a></li>
                    <li><a href="OrdersReturnGoodsList.aspx">退货列表</a></li>
                    <li><a href="OrdersRemarksAdd.aspx">订单备注添加</a></li>
                    <li><a href="OrdersRemarksList.aspx">订单备注列表</a></li>
                </ul>
            </div>
            <div id="content" class="box">
                <h1>订单备注编辑</h1>
                <fieldset>
                    <form id="form2" method="post">
                    <table class="nostyle" style="width: 100%;">
                        <tr>
                            <td class="tdL">订单号: </td>
                            <td>
                                <label id="lblOrderID" runat="server">
                                </label>
                                <input type="hidden" id="hidOrderID" name="hidOrderID" runat="server" />
                                <input type="hidden" id="hidOrdersGoodsID" name="hidOrdersGoodsID" runat="server" />
                            </td>
                            <td class="tdL">商品名称: </td>
                            <td>
                                <label id="lblGoodsName" runat="server">
                                </label>
                                <input type="hidden" id="hidGoodsID" name="hidGoodsID" runat="server" />
                                <input type="hidden" id="hidTransactionPrice" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">用户名: </td>
                            <td>
                                <label id="lblLoginID" runat="server">
                                </label>
                                <input type="hidden" id="hidLoginID" name="hidLoginID" runat="server" />
                            </td>
                            <td class="tdL">快递员: </td>
                            <td>
                                <select id="selCourierID" name="selCourierID">
                                </select>
                                <input type="hidden" id="hidCourierID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">物流次数: </td>
                            <td>
                                <input type="text" id="txtLogisticsTimes" name="txtLogisticsTimes" class="input-text"
                                    maxlength="2" />
                            </td>
                            <td class="tdL">成交商品数量: </td>
                            <td>
                                <input type="text" id="txtCompleteCount" name="txtCompleteCount" class="input-text"
                                    maxlength="3" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">成交商品总价: </td>
                            <td>
                                <input type="text" id="txtCompleteAmount" name="txtCompleteAmount" class="input-text"
                                    maxlength="6" />
                            </td>
                            <td class="tdL">库存: </td>
                            <td>
                                <input type="text" id="txtInventory" name="txtInventory" class="input-text" maxlength="3" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">销量: </td>
                            <td>
                                <input type="text" id="txtSalesVolume" name="txtSalesVolume" class="input-text" maxlength="6" />
                            </td>
                            <td class="tdL">送货商品量: </td>
                            <td>
                                <input type="text" id="txtDeliveryTimes" name="txtDeliveryTimes" class="input-text"
                                    maxlength="2" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">订单发生日期：</td>
                            <td colspan="3">
                                <input type="text" id="txtOrderTime" name="txtOrderTime" runat="server" onclick="calendar.show(this);"
                                    style="width: 70px; height: 22px; cursor: pointer;" maxlength="10" readonly="readonly" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">备注: </td>
                            <td colspan="3">
                                <textarea id="txtRemarks" name="txtRemarks" runat="server" cols="80" rows="10"></textarea><br />
                                <span id="spMsg" style="color: #ff0000;"></span></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center;">
                                <input type="submit" id="btnSubmit" class="input-submit" value="提交" />
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