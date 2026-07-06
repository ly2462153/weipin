<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CouriersUpdate.aspx.cs"
    Inherits="weipin.admin.CouriersUpdate" %>

<%@ Register Src="controls/headadmin.ascx" TagName="headadmin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>快递员信息修改</title>
    <link href="css/couriersupdate.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <uc1:headadmin ID="headadmin1" runat="server" />
        <script src="../js/jQuery/jquery.validate.min.js" type="text/javascript"></script>
        <script src="js/couriersupdate.js" type="text/javascript"></script>
        <div id="cols" class="box">
            <div id="aside" class="box">
                <div class="padding box">
                    <p id="logo"><a href="http://www.weipin365.com" target="_blank"><img src="/img/logolengthways.gif"
                        alt="" /></a></p>
                </div>
                <form name="form1" action="CouriersUpdate.aspx" method="post">
                <fieldset>
                    <legend>搜索</legend><p>
                        <input type="text" name="txtCourierID" class="input-text-02" style="width: 138px;
                            height: 19px;" />&nbsp;<input type="submit" value="搜索" class="input-submit-02" /></p>
                </fieldset>
                </form>
                <ul class="box"><li><a href="CouriersAdd.aspx">快递员添加</a></li> <li id="submenu-active">
                    <a href="CouriersList.aspx">快递员列表</a></li> </ul>
            </div>
            <div id="content" class="box">
                <h1>
                    快递员信息修改</h1>
                <fieldset>
                    <form id="form1" method="post">
                    <table class="nostyle" style="width: 100%;">
                        <tr>
                            <td class="tdL">登录密码: </td><td>
                                <input type="password" id="txtLoginPassword" name="txtLoginPassword" class="input-text" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">确认密码: </td><td>
                                <input type="password" id="txtConfirmLoginPassword" name="txtConfirmLoginPassword"
                                    class="input-text" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">快递员姓名: </td><td>
                                <input type="text" id="txtCourierName" name="txtCourierName" runat="server" class="input-text"
                                    maxlength="20" /><input type="hidden" id="hidCourierID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">性别: </td><td>
                                <input type="radio" id="rdoSexMale" name="rdoSex" checked="true" runat="server" />男&nbsp;
                                <input type="radio" id="rdoSexWoman" name="rdoSex" runat="server" />女</td>
                        </tr>
                        <tr>
                            <td class="tdL">手机: </td><td>
                                <input type="text" id="txtMobilePhone" name="txtMobilePhone" runat="server" class="input-text"
                                    maxlength="12" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdL">主要负责区域: </td><td>
                                <select id="selProvince" name="selProvince">
                                    <option value="">请选择</option>
                                </select><select id="selCity" name="selCity"><option value="">请选择</option>
                                </select><select id="selArea" name="selArea" runat="server">
                                </select><input type="hidden" id="hidAreaID" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="tdL">已离职: </td><td>
                                <input type="radio" id="rdoIsLeftYes" name="rdoIsLeft" checked="true" runat="server" />是&nbsp;
                                <input type="radio" id="rdoIsLeftNo" name="rdoIsLeft" runat="server" />否</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td><td style="text-align: left;">
                                <input type="submit" id="btnSubmit" class="input-submit" value="提交" />&nbsp;<input
                                    type="button" value="返回" onclick="javascript:history.go(-1);" class="input-submit" />
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