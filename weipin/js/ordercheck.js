$(document).ready(function() {
$.ajax({ type: "get",url: "/xml/areas/areas.xml",dataType: "xml",
success: function(xml) {
var _province="<option value=\"\">请选择</option>";
$(xml).find("pr").each(function() {
_province+="<option value=\""+$(this).attr("ai")+"\">"+$(this).attr("an")+"</option>";
});
$("#selProvince").html(_province);
//将区域ID转换为文字插入地址(格式如:XX省-XX市-XX区-XX街道)
var _areaid=$("#hidAreaID").val();
$(xml).find("ar").each(function() {
if($(this).attr("ai")==_areaid) {
$("#hidAreaID").parent().next().prepend($(this).parent().parent().attr("an")+"-"+$(this).parent().attr("an")+"-"+$(this).attr("an")+"-");
return false;
}
});
$("input[name='rdoMyAddress']").each(function() {
if($(this).attr("id")!="rdoAddAddress") {
var _eachareaid=$(this).next().next().val();
var _eachrdo=$(this);
$(xml).find("ar").each(function() {
if($(this).attr("ai")==_eachareaid) {
$(_eachrdo).parent().next().next().prepend($(this).parent().parent().attr("an")+"-"+$(this).parent().attr("an")+"-"+$(this).attr("an")+"-");
return false;
}
});
}
});
}
});
$("#selProvince").change(function() { if($(this).val()!="") { $("#lblArea").text($(this).find("option:selected").text()+",");var _provinceid=$(this).val();$.ajax({ type: "get",url: "/xml/areas/areas.xml",error: function() { alert("服务器响应超时，数据加载失败！"); },success: function(xml) { var _city="<option value=\"\">请选择</option>";$(xml).find("pr").each(function() { if($(this).attr("ai")==_provinceid) { $(this).find("ct").each(function() { _city+="<option value=\""+$(this).attr("ai")+"\">"+$(this).attr("an")+"</option>"; }); } });$("#selCity").html(_city);$("#selArea").html("<option value=\"\">请选择</option>"); } }); } else { $("#lblArea").text("");$("#selCity").html("<option value=\"\">请选择</option>");$("#selArea").html("<option value=\"\">请选择</option>"); } });
$("#selCity").change(function() { $("#lblArea").text($("#selProvince").find("option:selected").text()+",");if($(this).val()!="") { $("#lblArea").append($(this).find("option:selected").text()+",");var _cityid=$(this).val();$.ajax({ type: "get",url: "/xml/areas/areas.xml",error: function() { alert("服务器响应超时，数据加载失败！"); },success: function(xml) { var _area="<option value=\"\">请选择</option>";$(xml).find("ct").each(function() { if($(this).attr("ai")==_cityid) { $(this).find("ar").each(function() { _area+="<option value=\""+$(this).attr("ai")+"\">"+$(this).attr("an")+"</option>"; }); } });$("#selArea").html(_area); } }); } else { $("#selArea").html("<option value=\"\">请选择</option>"); } });
$("#selArea").change(function() { $("#lblArea").text($("#selProvince").find("option:selected").text()+","+$("#selCity").find("option:selected").text()+",");if($(this).val()!="") { $("#lblArea").append($(this).find("option:selected").text()+","); } });
$("#divOrders table tr").each(function() {
var _tr=$(this);
var _sid=$(this).children().eq(1).children("input").val();
if(_sid!=null) {
var _goodsid=$(this).children().eq(0).text();
$.ajax({
type: "get",url: "/xml/goods/goodssizes/"+_goodsid+".xml",async: false,dataType: "xml",
success: function(xml) {
$(xml).find("size").each(function() {
if($(this).attr("value")==_sid) {
$(_tr).children().eq(1).text($(_tr).children().eq(1).text()+"_"+$(this).attr("name"));
return false;
}
});
}
});
}
});
$("input[name='rdoPayWay']").click(function() { if($(this).attr("id")=="rdoCOD") { $("#trPayWay").show(); } else { $("#trPayWay").hide(); } });
$("input[name='rdoMyAddress']").click(function() {
if($(this).attr("id")=="rdoAddAddress") {
$("#txtConsigneeName").val("");
$("#selArea").val("");
$("#lblArea").text("");
$("#txtMyAddress").val("");
$("#txtMobilePhone").val("");
$("#txtTelephone").val("");
$("#txtMyZipcode").val("");
$("#tbMyAddressAdd").show();
$("#divSendMyAddress").hide();
}
else {
$("#tbMyAddressAdd").hide();
$("#divSendMyAddress").show();
}
});
$("#aSaveSendMyAddress").click(function() {
if(_validate.form()) {
var _cname=$("#txtConsigneeName").val();
var _areaid=$("#selArea").val();
var _address=$("#txtMyAddress").val();
var _mphone=$("#txtMobilePhone").val();
var _tphone=$("#txtTelephone").val();
var _zipcode=$("#txtMyZipcode").val();
var _oldmainadid=$("#hidMyAddressID").val();
if(_oldmainadid==null) { _oldmainadid=""; }
$.ajax({
type: "post",url: "/ajaxservice/MyShippingAddresses.aspx",data: { ptype: "InsertMyAddressChoose",cname: _cname,areaid: _areaid,address: _address,mphone: _mphone,tphone: _tphone,zipcode: _zipcode,oldmainadid: _oldmainadid },
success: function(msg) {
if(parseInt(msg)>0) {
var _tbstr="<tr><td width=\"4%\" height=\"26\" align=\"center\"><input type=\"radio\" name=\"rdoMyAddress\" style=\"border:0;\"/><input type=\"hidden\" value=\""+msg+"\"/><input type=\"hidden\" value=\""+_areaid+"\"/></td><td width=\"8%\" align=\"left\">"+_cname+"</td><td width=\"50%\" align=\"left\">"+_address+"</td>";
_tbstr+="<td width=\"13%\" align=\"center\">"+_mphone+"</td><td width=\"13%\" align=\"center\">"+_tphone+"</td><td width=\"2%\" align=\"center\">"+_zipcode+"</td><td width=\"10%\" align=\"center\"><a href=\"#\" onclick=\"DeleteMyAddress('"+msg+"',this);return false;\">删除</a></td></tr>";
if($.trim($("#divMyAddressList").text())!="") { $("#divMyAddressList table").append(_tbstr); }
else { $("#divMyAddressList").html("<table class=\"ordr_bg2td\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">"+_tbstr+"</table>"); }
$("#aControl").show();
$("#aControl").text("[修改]");
$("#hidMyAddressID").val(msg);
ChooseThisAddress();
LoadArea(msg);
$("#divMyAddressShow").show();
$("#divMyAddressList").hide();
$("#divMyAddressAdd").hide();
$("#tbMyAddressAdd").hide();
$("#divSendMyAddress").hide();
//控制支付及配送信息
$("#aPaySendControl").text("");
$("#divPayWayShow").hide();
$("#divPayWayChoose").show();
$("#divPaySendWayShow").hide();
$("#divPaySendChoose").show();
$("#aPaySendWay").show();
$("input[name='rdoDeliveryPeriod'][value="+$("#hidPaySendWay").val()+"]").attr("checked","checked");
}
else if(msg=="-1") { alert("您填写的资料超出了限定的字数!"); }
else if(msg=="-2") { alert("您最多可以保存10条地址信息,如需添加此条地址信息,可暂时删除其它任意信息后再进行添加!"); }
else { alert("添加失败!"); }
}
});
}
});
$("#aPaySendControl").click(function() {
var _text=$(this).text();
if(_text=="[修改]") {
$(this).text("[不保存并关闭]");
$("#divPayWayShow").hide();
$("#divPayWayChoose").show();
$("#divPaySendWayShow").hide();
$("#divPaySendChoose").show();
$("#aPaySendWay").show();
$("input[name='rdoPayWay'][value='"+$("#hidPayWay").val()+"']").attr("checked","checked");
if($("#rdoCOD").attr("checked")==true) { $("#trPayWay").show(); } else { $("#trPayWay").hide(); }
$("input[name='rdoDeliveryPeriod'][value="+$("#hidPaySendWay").val()+"]").attr("checked","checked");
}
else if(_text=="[不保存并关闭]") {
$(this).text("[修改]");
$("#divPayWayShow").show();
$("#divPayWayChoose").hide();
$("#divPaySendWayShow").show();
$("#divPaySendChoose").hide();
$("#aPaySendWay").hide();
}
});
$("#aPaySendWay").click(function() {
$("#aPaySendControl").text("[修改]");
$("#divPayWayShow").html("<ul><li>支付方式："+$("input[name='rdoPayWay']:checked").parent().text()+"</li></ul>");
$("#divPayWayShow").show();
$("#divPayWayChoose").hide();
var _chooserdo=$("input[name='rdoDeliveryPeriod']:checked");
var _paysendwayshow="<ul>";
if($("#trPayWay").css("display")!="none") { _paysendwayshow+="<li>付款方式：现金</li>"; }
_paysendwayshow+="<li>"+$(_chooserdo).parent().siblings().text()+"</li></ul><div class=\"clear\"></div>";
$("#divPaySendWayShow").html(_paysendwayshow);
$("#divPaySendWayShow").show();
$("#divPaySendChoose").hide();
$("#aPaySendWay").hide();
$("#hidPayWay").val($("input[name='rdoPayWay']:checked").val());
$("#hidPaySendWay").val($(_chooserdo).val());
});
$("#imgSubmit").click(function() {
var _msg="";
if($("#hidMyAddress").val()==""||$("#divMyAddressShow").css("display")=="none") { _msg+="“收货地址”"; }
if($("#hidPaySendWay").val()==""||$("#divPaySendWayShow").css("display")=="none") { _msg+="“支付及配送信息”"; }
if(_msg!="") { $("#lblMessage").text("请先确认"+_msg); }
else { $("#lblMessage").text("");$("#fmSubmit").submit(); }
});
$("#ckbUseOffsetPrice").click(function() {
if($(this).attr("checked")==true) { $("#spDiscountPrice").html($("#spDiscountPrice").children("input").val()+"<input type=\"hidden\" value=\""+$("#spDiscountPrice").children("input").val()+"\"/>");CountPrice();CountFreight(); }
else { $("#spDiscountPrice").html("0"+"<input type=\"hidden\" value=\""+$("#spDiscountPrice").children("input").val()+"\"/>");CountPrice();CountFreight(); }
});
jQuery.validator.addMethod("IsMobilePhone",function(value,element) { return this.optional(element)||/^13[0-9]{1}[0-9]{8}$|^15[0-9]{1}[0-9]{8}$|^18[0-9]{1}[0-9]{8}$/.test(value); },"");
jQuery.validator.addMethod("IsTelephone",function(value,element) { return this.optional(element)||/^(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$/.test(value); },"");
jQuery.validator.addMethod("IsZipcode",function(value,element) { return this.optional(element)||/^[1-9]\d{5}$/.test(value); },"");
var _validate=$("#fmMyAddressAdd").validate({
rules: {
txtConsigneeName: { required: true },
selArea: { required: true },
txtMyAddress: { required: true },
txtMobilePhone: { required: function() { return $("#txtTelephone").val()==""; },IsMobilePhone: true },
txtTelephone: { required: function() { return $("#txtMobilePhone").val()==""; },IsTelephone: true },
txtMyZipcode: { IsZipcode: true }
},
messages: {
txtConsigneeName: { required: "请填写收货人姓名" },
selArea: { required: "请选择区/县" },
txtMyAddress: { required: "请填写详情街道地址" },
txtMobilePhone: { required: "",IsMobilePhone: "手机号码格式不正确,参考格式:13880566221" },
txtTelephone: { required: "请至少填写手机或座机中的一项",IsTelephone: "座机号码格式不正确,参考格式:86682233" },
txtMyZipcode: { IsZipcode: "邮编格式不正确" }
}
});
CountPrice();
CountFreight();
ChoosePayWay();
});
function ControlMyAddress() {
var _text=$("#aControl").text();
if(_text=="[修改]") {
$("#aControl").text("[不保存并关闭]");
$("#divMyAddressShow").hide();
$("#divMyAddressList").show();
$("#divMyAddressAdd").show();
$("#divSendMyAddress").show();
ChooseThisAddress();
}
else if(_text=="[不保存并关闭]") {
$("#aControl").text("[修改]");
$("#divMyAddressShow").show();
$("#divMyAddressList").hide();
$("#divMyAddressAdd").hide();
$("#tbMyAddressAdd").hide();
$("#divSendMyAddress").hide();
}
}
function SendMyAddress() {
var _newmainadid=$("input[name='rdoMyAddress']:checked").next().val();
$.ajax({
type: "post",url: "/ajaxservice/MyShippingAddresses.aspx",async: true,
data: { ptype: "UpdateMyAddressChoose",oldmainadid: $("#hidMyAddressID").val(),newmainadid: _newmainadid },
success: function(msg) {
if(msg=="1") {
$("#aControl").show();
$("#aControl").text("[修改]");
$("#hidMyAddressID").val(_newmainadid);
ChooseThisAddress();
$("#divMyAddressShow").show();
$("#divMyAddressList").hide();
$("#divMyAddressAdd").hide();
$("#tbMyAddressAdd").hide();
$("#divSendMyAddress").hide();
//控制支付及配送信息
$("#aPaySendControl").text("");
$("#divPayWayShow").hide();
$("#divPayWayChoose").show();
$("#divPaySendWayShow").hide();
$("#divPaySendChoose").show();
$("#aPaySendWay").show();
$("input[name='rdoDeliveryPeriod'][value="+$("#hidPaySendWay").val()+"]").attr("checked","checked");
}
else { alert("修改失败！"); }
}
});
}
function ChooseThisAddress() {
$("input[name='rdoMyAddress']").each(function() {
if($(this).next("input").val()==$("#hidMyAddressID").val()) {
$(this).attr("checked","checked");
var _areaid=$(this).next().next().val();
var _addressshow="<ul>";
var _hidmyaddress="";
$(this).parent().siblings().each(function(i) {
if(i==0) {
_addressshow+="<li>"+$(this).text()+"<input type=\"hidden\" id=\"hidMyAddressID\" value=\""+$("#hidMyAddressID").val()+"\"/><input type=\"hidden\" id=\"hidAreaID\" value=\""+_areaid+"\"/></li>";
_hidmyaddress=_areaid+"|"+$(this).text();
}
else if(i<5) {
_addressshow+="<li>"+$(this).text()+"</li>";
_hidmyaddress+="|"+$(this).text();
}
$("#hidMyAddress").val(_hidmyaddress);
});
_addressshow+="</ul><div class=\"clear\"></div>";
$("#divMyAddressShow").html(_addressshow);
return false;
}
});
CountFreight();
ChoosePayWay();
}
function LoadArea(myaddressid) {
$.ajax({
type: "get",url: "/xml/areas/areas.xml",dataType: "xml",
success: function(xml) {
var _areaid=$("#hidAreaID").val();
$(xml).find("ar").each(function() {
if($(this).attr("ai")==_areaid) {
$("#hidAreaID").parent().next().prepend($(this).parent().parent().attr("an")+"-"+$(this).parent().attr("an")+"-"+$(this).attr("an")+"-");
return false;
}
});
$("input[name='rdoMyAddress']").each(function() {
if($(this).next().val()==myaddressid) {
var _eachareaid=$(this).next().next().val();
var _eachrdo=$(this);
$(xml).find("ar").each(function() {
if($(this).attr("ai")==_eachareaid) {
$(_eachrdo).parent().next().next().prepend($(this).parent().parent().attr("an")+"-"+$(this).parent().attr("an")+"-"+$(this).attr("an")+"-");
return false;
}
});
return false;
}
});
}
});
}
function DeleteMyAddress(addressid,thisobj) {
$.ajax({
type: "post",url: "/ajaxservice/MyShippingAddresses.aspx",async: true,data: { ptype: "DeleteMyAddress",adid: addressid },
success: function(msg) {
if(msg=="-1") { $(thisobj).parent().parent().remove(); }
else if(msg=="0") {
$("#divMyAddressList").hide();
$("#divMyAddressList").text("");
$("#divSendMyAddress").hide();
$("#rdoAddAddress").attr("checked","checked");
$("#tbMyAddressAdd").show();
$("#aControl").hide();
}
else if(parseInt(msg)>0) {
$(thisobj).parent().parent().remove();
$("#hidMyAddressID").val(msg);
ChooseThisAddress();
}
//控制支付及配送信息
$("#aPaySendControl").text("");
$("#divPayWayShow").hide();
$("#divPayWayChoose").show();
$("#divPaySendWayShow").hide();
$("#divPaySendChoose").show();
$("#aPaySendWay").show();
$("input[name='rdoDeliveryPeriod'][value="+$("#hidPaySendWay").val()+"]").attr("checked","checked");
}
});
}
function CountFreight() {
var _areaid=parseInt($("#hidAreaID").val());
var _expense=parseFloat(Subduction(parseFloat($("#spGoodsPrice").text()),parseFloat($("#spDiscountPrice").text())));
if(((_areaid>1&&_areaid<30||_areaid>30&&_areaid<216||_areaid>216&&_areaid<325||_areaid>325&&_areaid<528||_areaid>528&&_areaid<667||_areaid>1142&&_areaid<1272||_areaid>1272&&_areaid<1377||_areaid>1377&&_areaid<1513||_areaid>1513&&_areaid<1615||_areaid>1615&&_areaid<1737||_areaid>1737&&_areaid<1910||_areaid>1910&&_areaid<2096||_areaid>2096&&_areaid<2219||_areaid>2219&&_areaid<2357||_areaid>2357&&_areaid<2545||_areaid>2545&&_areaid<2670||_areaid>2670&&_areaid<2705||_areaid>2705&&_areaid<2805||_areaid>2805&&_areaid<2957||_areaid>3038&&_areaid<3160)&&_expense>=38)||((_areaid>667&&_areaid<785||_areaid>785&&_areaid<915||_areaid>915&&_areaid<991||_areaid>991&&_areaid<1142||_areaid>2957&&_areaid<3038||_areaid>3160&&_areaid<3263||_areaid>3263&&_areaid<3316||_areaid>3316&&_areaid<3346||_areaid>3346&&_areaid<3463)&&_expense>=68)) {
//如果是成都或四川其它区域满38,免运费
$("#spFreight").text(0);
$("#hidFreight").val(0);
$("#spAmount").text(_expense);
}
else {
$.ajax({
type: "get",url: "/xml/areas/areas.xml",dataType: "xml",
success: function(xml) {
$(xml).find("ar").each(function() {
if(_areaid==$(this).attr("ai")) {
$("#spFreight").text($(this).attr("fr"));
$("#hidFreight").val($(this).attr("fr"));
$("#spAmount").text(Addition(_expense,$("#spFreight").text()));
}
});
}
});
}
}
function CountPrice() {
var _total=0;
var _amount=0;
$("#divOrders table tr").each(function(i) {
if(i!=0) {
var _count=$(this).children(".cnt").text();
var _price=$(this).children(".prc").text().replace("￥","");
_amount=Addition(_amount,Multiply(_price,_count));
_total=parseInt(_total)+parseInt(_count);
}
});
$("#spCount").text(_total);
$("#spGoodsPrice").text(_amount.toFixed(1));
}
function ChoosePayWay() {
var _areaid=$("#hidAreaID").val();
if(_areaid!="") {
$.ajax({
type: "get",url: "/xml/areas/areas.xml",dataType: "xml",
success: function(xml) {
var _res="0";
$(xml).find("ct").each(function() {
if($(this).attr("ai")=="2") {
$(this).find("ar").each(function() { if($(this).attr("ai")==_areaid) { _res="1";return false; } });
if(_res=="1") { $("input[name='rdoPayWay']").attr("disabled","");if($("#hidPayWay").val()!="2") { $("#rdoCOD").attr("checked","checked");$("#trPayWay").show(); } else { $("#rdoAlipay").attr("checked","checked");$("#trPayWay").hide(); } $("#spPayMsg").text("[您选择的地区支持：货到付款、支付宝]"); }
else { $("#rdoCOD").attr("disabled","disabled");$("#rdoAlipay").attr("disabled","");$("#rdoAlipay").attr("checked","checked");$("#trPayWay").hide();$("#spPayMsg").text("[您选择的地区支持：支付宝]"); }
$("#hidPayWay").val($("input[name='rdoPayWay']:checked").val());
return false;
}
});
}
});
}
}
//计算浮点数乘法
function Multiply(arg1,arg2) { arg1=String(arg1);var i=arg1.length-arg1.indexOf(".")-1;i=(i>=arg1.length)?0:i;arg2=String(arg2);var j=arg2.length-arg2.indexOf(".")-1;j=(j>=arg2.length)?0:j;return arg1.replace(".","")*arg2.replace(".","")/Math.pow(10,i+j); }
function Addition(arg1,arg2) { var r1,r2,m;try { r1=arg1.toString().split(".")[1].length } catch(e) { r1=0 } try { r2=arg2.toString().split(".")[1].length } catch(e) { r2=0 } m=Math.pow(10,Math.max(r1,r2));return (arg1*m+arg2*m)/m; }
function Subduction(arg1,arg2) { var r1,r2,m,n;try { r1=arg1.toString().split(".")[1].length } catch(e) { r1=0 } try { r2=arg2.toString().split(".")[1].length } catch(e) { r2=0 } m=Math.pow(10,Math.max(r1,r2));n=(r1>=r2)?r1:r2;return ((arg1*m-arg2*m)/m).toFixed(n); }