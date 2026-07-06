<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="weipin.myhome.UserInfo" %>

<%@ Register Src="../controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="../controls/bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<%@ Register Src="../controls/myhome.ascx" TagName="myhome" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>个人资料_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城</title>
    <link href="css/userinfo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc1:top ID="top1" runat="server" />
    <script src="js/userinfo.js" type="text/javascript"></script>
    <script src="/js/jquery/jquery.validate.min.js" type="text/javascript"></script>
    <script src="/js/jquery/tipswindown.min.js" type="text/javascript"></script>
    <div class="main">
        <uc3:myhome ID="myhome1" runat="server" />
        <div class="main_right r">
            <h1>个人资料</h1>
            <div>
                <form id="fmUserInfo" method="post" runat="server">
                <table width="100%" border="0">
                    <tr>
                        <td width="15%" class="tdL">登录名：</td>
                        <td width="85%" colspan="2">
                            <label id="lblLoginID" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">真实姓名：</td>
                        <td>
                            <input type="text" id="txtUserName" name="txtUserName" class="logo_input" maxlength="10"
                                runat="server" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tdL">昵称：</td>
                        <td>
                            <input type="text" id="txtNickName" name="txtNickName" class="logo_input" maxlength="25"
                                runat="server" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tdL">性别：</td>
                        <td>
                            <input type="radio" id="rdoMale" name="rdoUserSex" runat="server" />男&nbsp;&nbsp;<input
                                type="radio" id="rdoWoman" name="rdoUserSex" runat="server" />女&nbsp;<input type="hidden"
                                    id="hidUserSex" name="hidUserSex" runat="server" /></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tdL">出生日期：</td>
                        <td>
                            <select id="selYear" name="selYear" runat="server" class="birth"><option value="2012">2012</option><option value="2011">2011</option><option value="2010">2010</option><option value="2009">2009</option><option value="2008">2008</option><option value="2007">2007</option><option value="2006">2006</option><option value="2005">2005</option><option value="2004">2004</option><option value="2003">2003</option><option value="2002">2002</option><option value="2001">2001</option><option value="2000">2000</option><option value="1999">1999</option><option value="1998">1998</option><option value="1997">1997</option><option value="1996">1996</option><option value="1995">1995</option><option value="1994">1994</option><option value="1993">1993</option><option value="1992">1992</option><option value="1991">1991</option><option value="1990">1990</option><option value="1989">1989</option><option value="1988">1988</option><option value="1987">1987</option><option value="1986">1986</option><option value="1985">1985</option><option value="1984">1984</option><option value="1983">1983</option><option value="1982">1982</option><option value="1981">1981</option><option value="1980">1980</option><option value="1979">1979</option><option value="1978">1978</option><option value="1977">1977</option><option value="1976">1976</option><option value="1975">1975</option><option value="1974">1974</option><option value="1973">1973</option><option value="1972">1972</option><option value="1971">1971</option><option value="1970">1970</option><option value="1969">1969</option><option value="1968">1968</option><option value="1967">1967</option><option value="1966">1966</option><option value="1965">1965</option><option value="1964">1964</option><option value="1963">1963</option><option value="1962">1962</option><option value="1961">1961</option><option value="1960">1960</option><option value="1959">1959</option><option value="1958">1958</option><option value="1957">1957</option><option value="1956">1956</option><option value="1955">1955</option><option value="1954">1954</option><option value="1953">1953</option><option value="1952">1952</option><option value="1951">1951</option><option value="1950">1950</option><option value="1949">1949</option><option value="1948">1948</option><option value="1947">1947</option><option value="1946">1946</option><option value="1945">1945</option><option value="1944">1944</option><option value="1943">1943</option><option value="1942">1942</option><option value="1941">1941</option><option value="1940">1940</option><option value="1939">1939</option><option value="1938">1938</option><option value="1937">1937</option><option value="1936">1936</option><option value="1935">1935</option><option value="1934">1934</option><option value="1933">1933</option><option value="1932">1932</option><option value="1931">1931</option><option value="1930">1930</option></select>&nbsp;<select id="selMonth" name="selMonth" runat="server" class="birth"><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option></select>&nbsp;<select id="selDay" name="selDay" runat="server" class="birth"></select></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td width="15%" class="tdL">邮箱：</td>
                        <td width="85%" colspan="2">
                            <label id="lblEmail" runat="server">
                            </label>&nbsp;<a href="/myhome/VerifyUpdateEmail.aspx" style="color:#a10000;">修改>></a>&nbsp;<span id="spVerify" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdL">详细地址：</td>
                        <td>
                            <input type="text" id="txtUserAddress" name="txtUserAddress" class="logo_input" maxlength="150"
                                runat="server" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tdL">手机号码：</td>
                        <td>
                            <input type="text" id="txtMobilePhone" name="txtMobilePhone" class="logo_input" maxlength="12"
                                runat="server" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td height="80">&nbsp;</td>
                        <td>
                            <a href="#" id="aSubmit" onclick="FormSubmit();return false;">确定</a>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                </form>
            </div>
        </div>
    </div>
    <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>