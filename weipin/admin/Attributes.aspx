<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attributes.aspx.cs" Inherits="weipin.admin.Attributes" %>

<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>分类属性管理</title>
    <link href="css/attributes.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <uc1:headadmin ID="headadmin1" runat="server" />
        <script src="../js/jQuery/jquery.validate.min.js" type="text/javascript"></script>
        <script src="js/attributes.js" type="text/javascript"></script>
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
                <h1>分类属性管理</h1>
                <fieldset>
                    <fieldset>
                        <legend>添加</legend>
                        <form id="form1" method="post">
                        <table class="nostyle" style="margin: 0;">
                            <tr>
                                <td class="tdL" style="width: 96px">属性名称: </td>
                                <td>
                                    <input type="text" id="txtAttributeNameAdd" name="txtAttributeNameAdd" class="input-text"
                                        maxlength="10" />
                                    <input type="hidden" id="hidCategoryID" name="hidCategoryID" runat="server" />
                                </td>
                            </tr>
                            <tr> 
                                <td>&nbsp;</td>
                                <td>
                                    <input type="submit" id="btnAdd" value="添加" class="input-submit" />&nbsp;<input type="button"
                                        value="返回" class="input-submit" onclick="javascript:location.href='Cagegories.aspx'" />
                                </td>
                            </tr>
                        </table>
                        </form>
                    </fieldset>
                    <fieldset id="fdsAttributes" style="display: none;">
                        <legend>修改</legend>
                        <form id="form2" method="post">
                        <table class="nostyle" style="margin: 0;">
                            <tr>
                                <td class="tdL">
                                    <label>
                                        属性名称:</label>
                                </td>
                                <td style="width: 500px;">
                                    <input type="text" id="txtAttributeNameUpdate" name="txtAttributeNameUpdate" class="input-text"
                                        maxlength="10" />
                                    <span id="catmsg" style="color: Red;"></span>
                                    <input type="hidden" id="hidCategoryID2" name="hidCategoryID2" runat="server" />
                                    <input type="hidden" id="hidAttributeID" name="hidAttributeID" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <input type="submit" id="btnUpdate" name="btnUpdate" value="修改" class="input-submit"
                                        style="text-align: center;" />
                                </td>
                            </tr>
                        </table>
                        </form>
                    </fieldset>
                </fieldset>
                <fieldset>
                    <legend>属性列表</legend>
                    <ul id="ulTree" runat="server">
                    </ul>
                </fieldset>
            </div>
        </div>
    </div>
</body>
</html>
