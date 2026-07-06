<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Areas.aspx.cs" Inherits="weipin.admin.Areas" %>

<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>区域管理</title>
    <link href="css/jquery/jquery.treeview.css" rel="stylesheet" type="text/css" />
    <link href="css/areas.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <uc1:headadmin ID="headadmin1" runat="server" />
        <script src="../js/jQuery/jquery.validate.min.js" type="text/javascript"></script>
        <script src="../js/jQuery/jquery.treeview.js" type="text/javascript"></script>
        <script src="js/areas.js" type="text/javascript"></script>
        <div id="cols" class="box">
            <div id="aside" class="box">
                <div class="padding box">
                    <p id="logo"><a href="http://www.weipin365.com" target="_blank"><img src="/img/logolengthways.gif" alt="微品网上商城" title="微品网上商城" /></a></p>
                </div>
                <ul class="box">
                    <li><a href="Cagegories.aspx">分类管理</a></li>
                    <li id="submenu-active"><a href="Areas.aspx">区域管理</a></li>
                </ul>
            </div>
            <div id="content" class="box">
                <h1>区域管理</h1>
                <fieldset>
                    <fieldset>
                        <form id="form1" method="post">
                        <table class="nostyle" style="margin: 0;">
                            <tr>
                                <td class="tdL" style="width: 96px">根区域名称: </td>
                                <td>
                                    <input type="text" id="txtRootAreaName" name="txtRootAreaName" class="input-text"
                                        maxlength="10" /></td>
                            </tr>
                            <tr>
                                <td>&nbsp; </td>
                                <td style="width: 200px;">
                                    <input type="submit" id="btnRoot" value="添加" class="input-submit" />
                                </td>
                            </tr>
                        </table>
                        </form>
                    </fieldset>
                    <fieldset id="fdsArea" style="display: none;">
                        <form id="form2" method="post">
                        <table class="nostyle" style="margin: 0;">
                            <tr id="trParent" style="display: none;">
                                <td class="tdL">父区域名称: </td>
                                <td colspan="2">
                                    <label id="lblParentName">
                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdL">
                                    <label id="lblSonName">
                                        子区域名称:</label>
                                </td>
                                <td style="width: 500px;">
                                    <input type="text" id="txtAreaName" name="txtAreaName" class="input-text" maxlength="10" />
                                    <input type="hidden" id="hidAreaID" name="hidAreaID" />
                                </td>
                            </tr>
                            <tr id="trFreight">
                            </tr>
                            <tr>
                                <td>&nbsp; </td>
                                <td style="width: 200px;">
                                    <input type="submit" id="btnAddSubclass" name="btnAddSubclass" value="添加" class="input-submit"
                                        style="text-align: center;" />
                                </td>
                            </tr>
                        </table>
                        </form>
                    </fieldset>
                </fieldset>
                <fieldset>
                    <legend>区域列表</legend>
                    <ul id="ulTree" runat="server">
                    </ul>
                </fieldset>
            </div>
        </div>
    </div>
</body>
</html>