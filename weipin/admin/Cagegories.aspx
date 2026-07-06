<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cagegories.aspx.cs" Inherits="weipin.admin.Cagegories" %>

<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>分类管理</title>
    <link href="css/jquery/jquery.treeview.css" rel="stylesheet" type="text/css" />
    <link href="css/cagegories.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <uc1:headadmin ID="headadmin1" runat="server" />
        <script src="../js/jQuery/jquery.validate.min.js" type="text/javascript"></script>
        <script src="../js/jQuery/jquery.treeview.js" type="text/javascript"></script>
        <script src="js/cagegories.js" type="text/javascript"></script>
        <div id="cols" class="box">
            <div id="aside" class="box">
                <div class="padding box">
                    <p id="logo"><a href="http://www.weipin365.com" target="_blank"><img src="/img/logolengthways.gif" alt="微品网上商城" title="微品网上商城" /></a></p>
                </div>
                <ul class="box">
                    <li id="submenu-active"><a href="Cagegories.aspx">分类管理</a></li>
                    <li><a href="Areas.aspx">区域管理</a></li>
                </ul>
            </div>
            <div id="content" class="box">
                <h1>分类管理</h1>
                <fieldset>
                    <fieldset>
                        <form id="form1" method="post">
                        <table class="nostyle" style="margin: 0;">
                            <tr>
                                <td class="tdL" style="width: 96px">是否重要显示: </td>
                                <td colspan="2">
                                    <input type="radio" id="rdoRootIsHighlightYes" name="rdoRootIsHighlight" runat="server" />是&nbsp;&nbsp;
                                    <input type="radio" id="rdoRootIsHighlightNo" name="rdoRootIsHighlight" runat="server"
                                        checked="true" />否 </td>
                            </tr>
                            <tr>
                                <td class="tdL" style="width: 96px">根分类名称: </td>
                                <td colspan="2">
                                    <input type="text" id="txtRootCategoryName" name="txtRootCategoryName" class="input-text"
                                        maxlength="10" /></td>
                            </tr>
                            <tr>
                                <td class="tdL" style="width: 96px">根分类备注: </td>
                                <td>
                                    <input type="text" name="txtRootCategoryRemarks" class="input-text" maxlength="50" />
                                </td>
                                <td style="width: 200px;">
                                    <input type="submit" id="btnRoot" value="添加" class="input-submit" />
                                </td>
                            </tr>
                        </table>
                        </form>
                    </fieldset>
                    <fieldset id="fdsCategory" style="display: none;">
                        <form id="form2" method="post">
                        <table class="nostyle" style="margin: 0;">
                            <tr id="trParent" style="display: none;">
                                <td class="tdL">父分类名称: </td>
                                <td colspan="2">
                                    <label id="lblParentName"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdL" style="width: 96px">
                                    <label>是否重要显示:</label>
                                </td>
                                <td colspan="2" style="width: 500px;">
                                    <input type="radio" id="rdoIsHighlightYes" name="rdoIsHighlight" runat="server" />是&nbsp;&nbsp;
                                    <input type="radio" id="rdoIsHighlightNo" name="rdoIsHighlight" runat="server" checked="true" />否
                                </td>
                            </tr>
                            <tr id="trSonName">
                                <td class="tdL">
                                    <label id="lblSonName">子分类名称:</label>
                                </td>
                                <td colspan="2" style="width: 500px;">
                                    <input type="text" id="txtCategoryName" name="txtCategoryName" class="input-text"
                                        maxlength="10" />
                                    <span id="catmsg" style="color: Red;"></span>
                                    <input type="hidden" id="hidCategoryID" name="hidCategoryID" />
                                </td>
                            </tr>
                            <tr id="trRemarks">
                                <td class="tdL">备注: </td>
                                <td>
                                    <input type="text" id="txtRemarks" name="txtRemarks" class="input-text" maxlength="50" />
                                </td>
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
                    <legend>分类列表</legend>
                    <ul id="ulTree" runat="server">
                    </ul>
                </fieldset>
            </div>
        </div>
    </div>
</body>
</html>