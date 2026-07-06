<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyShippingAddressesList.aspx.cs"
    Inherits="weipin.myhome.MyShippingAddressesList" %>

<%@ Register Src="../controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="../controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<%@ Register Src="../controls/myhome.ascx" TagName="myhome" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>我的收货地址_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
</head>
<body>
    <uc1:top ID="top1" runat="server" />
    <link href="css/myshippingaddresseslist.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery/jquery.validate.min.js" type="text/javascript"></script>
    <script src="js/myshippingaddresseslist.js" type="text/javascript"></script>
    <div class="main">
        <uc3:myhome ID="myhome1" runat="server" />
        <div class="main_right r">
            <h1>我的收货地址</h1>
            <div id="divMyShippingAddressesList" runat="server" class="div_bottom">
            </div>
        </div>
        <div class="main_right r" style="margin-top: 20px;">
            <h1>添加新的收货地址</h1>
            <div>
                <form id="fmMyAddressAdd">
                <table id="tbMyAddressAdd" width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="8%" height="40" align="right">收货人：<br />
                        </td><td>
                            <input type="text" id="txtConsigneeName" name="txtConsigneeName" class="logo_input"
                                style="width: 80px;" maxlength="15" /></td>
                    </tr>
                    <tr>
                        <td height="40" align="right">地区：<br />
                        </td><td>
                            <select id="selProvince" name="selProvince">
                                <option value="">请选择</option>
                            </select><select id="selCity" name="selCity" style="width:155px;"><option value="">请选择</option>
                            </select><select id="selArea" name="selArea">
                                <option value="">请选择</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td height="40" align="right">详细地址：</td><td>
                            <label id="lblArea">
                            </label>
                            <input type="text" id="txtMyAddress" name="txtMyAddress" size="50" class="logo_input"
                                maxlength="150" />
                        </td>
                    </tr>
                    <tr>
                        <td height="40" align="right">手机：</td><td>
                            <input type="text" id="txtMobilePhone" name="txtMobilePhone" maxlength="12" class="logo_input" />
                            <span style="color: #878787;">或者</span> 座机：<input type="text" id="txtTelephone" name="txtTelephone"
                                class="logo_input" maxlength="15" /></td>
                    </tr>
                    <tr>
                        <td height="40" align="right">邮编：</td><td>
                            <input type="text" id="txtMyZipcode" name="txtMyZipcode" maxlength="6" class="logo_input" />
                        </td>
                    </tr>
                    <tr>
                        <td></td><td height="40" align="right"><a href="javascript:void(0);" id="aSaveMyAddress"
                            class="ordr_but">添加地址</a></td>
                    </tr>
                </table>
                </form>
            </div>
        </div>
    </div>
    <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>