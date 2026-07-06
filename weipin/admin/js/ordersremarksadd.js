$(document).ready(function() {
//加载快递员
$.ajax({ type: "get",url: "/xml/couriers/couriers.xml",error: function() { alert("服务器响应超时，数据加载失败！"); },
success: function(xml) {
var _courierid=$("#hidCourierID").val();
var _areacourier="<option value=\"\">请选择</option>";
$(xml).find("Courier").each(function() { _areacourier+="<option value=\""+$(this).find("CourierID").text()+"\">"+$(this).find("CourierName").text()+"</option>"; });
$("#selCourierID").html(_areacourier);
}
});
$("#txtGoodsID").keyup(function() {
var _lasttime=$(this).val();
setTimeout(function() {
var _nexttime=$("#txtGoodsID").val();
if(_lasttime==_nexttime&&IsNonnegativeInteger(_nexttime)) {
$.ajax({ type: "post",url: "ajaxservice/Goods.aspx",async: true,data: { ptype: "SelectGoodsPartByID",gid: _nexttime },
success: function(xml) {
if(xml!="") {
$(xml).find("Good").each(function() {
$("#lblGoodsName").text($(this).find("GoodsName").text());
$("#hidTransactionPrice").val($(this).find("Price").text());
});
}
else {
$("#lblGoodsName").html("<span style='color:#ff0000;'>没有找到该商品号码对应的商品！</span>");
$("#hidTransactionPrice").val("");
}
}
});
}
else { $("#lblGoodsName").text("");$("#hidTransactionPrice").val(""); }
},500);
});
//计算商品总价/自动填充库存和销量
$("#txtCompleteCount").keyup(function() {
if(IsInteger($(this).val())) {
$("#txtCompleteAmount").val(Multiply($(this).val(),$("#hidTransactionPrice").val()));
$("#txtInventory").val(-parseInt($(this).val()));
$("#txtSalesVolume").val($(this).val());
if(parseInt($(this).val())>0) { $("#txtDeliveryTimes").val(1); }
else if(parseInt($(this).val())<0) { $("#txtDeliveryTimes").val(-1); }
else { $("#txtDeliveryTimes").val(0); }
}
else {
$("#txtCompleteAmount").val("");
$("#txtInventory").val("");
$("#txtSalesVolume").val("");
$("#txtDeliveryTimes").val("");
}
});
$("#txtRemarks").keyup(function() {
var _txtRemarks=$("#txtRemarks").checkLength({ min: -1,max: 301 });
if(!_txtRemarks) {
$("#spMsg").text("您最多可以输入300个字！");
$(this).val($(this).val().substring(0,300));
}
else { $("#spMsg").text(""); }
});
$("#btnSubmit").click(function() {
if(_validate.form()) {
var _txtRemarks=$("#txtRemarks").checkLength({ min: -1,max: 301 });
if(!_txtRemarks) { $("#txtRemarks").val($("#txtRemarks").val().substring(0,300)); }
}
});
//验证为整数
jQuery.validator.addMethod("isInteger",function(value,element) { var tel=/^-?\d+$/;return this.optional(element)||(tel.test(value)); },"");
//验证为浮点数
jQuery.validator.addMethod("isFloat",function(value,element) { var tel=/^(-?\d+)(\.\d+)?$/;return this.optional(element)||(tel.test(value)); },"");
var _validate=$("#form2").validate({
rules: {
selCourierID: { required: true },
txtLogisticsTimes: { required: true,isInteger: true },
txtCompleteCount: { required: true,isInteger: true },
hidTransactionPrice: { required: true },
txtCompleteAmount: { required: true,isFloat: true },
txtInventory: { required: true,isInteger: true },
txtSalesVolume: { required: true,isInteger: true },
txtDeliveryTimes: { required: true,isInteger: true },
txtOrderTime: { required: true }
},
messages: {
selCourierID: { required: "请选择快递员！" },
txtLogisticsTimes: { required: "请填写物流次数！",isInteger: "请填写整数！" },
txtCompleteCount: { required: "请填写成交商品数量！",isInteger: "请填写整数！" },
hidTransactionPrice: { required: "请填写正确的商品标号！" },
txtCompleteAmount: { required: "请填写商品总价！",isFloat: "请填写数字！" },
txtInventory: { required: "请填写商品库存！",isInteger: "请填写整数！" },
txtSalesVolume: { required: "请填写商品销量！",isInteger: "请填写整数！" },
txtDeliveryTimes: { required: "请填写送货商品量！",isInteger: "请填写整数！" },
txtOrderTime: { required: "请填写订单发生日期！" }
}
});
});
//计算浮点数乘法
function Multiply(arg1,arg2) {
arg1=String(arg1);var i=arg1.length-arg1.indexOf(".")-1;i=(i>=arg1.length)?0:i;
arg2=String(arg2);var j=arg2.length-arg2.indexOf(".")-1;j=(j>=arg2.length)?0:j;
return arg1.replace(".","")*arg2.replace(".","")/Math.pow(10,i+j);
}
//验证是否是非负整数
function IsNonnegativeInteger(oNum) {
if(!oNum) return false;
var strP=/^\d+$/;
if(!strP.test(oNum)) return false;
try { if(parseFloat(oNum)!=oNum) return false; }
catch(ex) { return false; }
return true;
}
//验证是否是整数
function IsInteger(oNum) {
if(!oNum) return false;
var strP=/^-?\d+$/;
if(!strP.test(oNum)) return false;
try { if(parseFloat(oNum)!=oNum) return false; }
catch(ex) { return false; }
return true;
}