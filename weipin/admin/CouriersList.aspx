<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CouriersList.aspx.cs" Inherits="weipin.admin.CouriersList" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>快递员列表</title>
    <link href="css/courierslist.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <uc1:headadmin ID="headadmin1" runat="server" />
        <script src="js/courierslist.js" type="text/javascript"></script>
        <div id="cols" class="box">
            <div id="aside" class="box">
                <div class="padding box">
                    <p id="logo"><a href="http://www.weipin365.com" target="_blank"><img src="/img/logolengthways.gif" alt="" /></a></p>
                </div>
                <form action="CouriersUpdate.aspx" method="post">
                <fieldset>
                    <legend>搜索</legend>
                    <p>
                        <input type="text" name="txtCourierID" class="input-text-02" style="width: 138px;
                            height: 19px;" />&nbsp;<input type="submit" value="搜索" class="input-submit-02" /></p>
                </fieldset>
                </form>
                <ul class="box">
                    <li><a href="CouriersAdd.aspx">快递员添加</a></li>
                    <li id="submenu-active"><a href="CouriersList.aspx">快递员列表</a></li>
                </ul>
            </div>
            <div id="content" class="box">
                <h1>快递员列表</h1>
                <div id="divCouriersList" runat="server">
                    <asp:Repeater ID="rptCouriersList" runat="server">
                        <HeaderTemplate>
                            <table class="tb" style="border: 1px solid #CFCFCF; margin-top: 10px;">
                                <tr>
                                    <th>编号</th>
                                    <th>姓名</th>
                                    <th>性别</th>
                                    <th>手机</th>
                                    <th>送货量</th>
                                    <th>送货金额</th>
                                    <th>&nbsp;</th>
                                    <th>&nbsp;</th>
                                    <th>&nbsp;</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# ((DataRowView)Container.DataItem)["CourierID"]%></td>
                                <td>
                                    <%# ((DataRowView)Container.DataItem)["CourierName"]%></td>
                                <td>
                                    <%# ((DataRowView)Container.DataItem)["CourierSex"].ToString()=="True"?"男":"女"%>
                                </td>
                                <td>
                                    <%# ((DataRowView)Container.DataItem)["MobilePhone"]%></td>
                                <td>
                                    <%# ((DataRowView)Container.DataItem)["DeliveryTimes"]%></td>
                                <td>
                                    <%# ((DataRowView)Container.DataItem)["DeliveryAmount"]%></td>
                                <td><a href='CouriersUpdate.aspx?cid=<%# ((DataRowView)Container.DataItem)["CourierID"]%>'>
                                    修改</a></td>
                                <td><a href="#" onclick="LogoutCouriers('<%# ((DataRowView)Container.DataItem)["CourierID"]%>');">
                                    注销</a></td>
                                <td><a href="#" onclick="DeleteCouriers('<%# ((DataRowView)Container.DataItem)["CourierID"]%>');">
                                    删除</a></td>
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