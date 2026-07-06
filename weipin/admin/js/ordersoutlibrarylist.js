$(document).ready(function() {
$("#selArea").change(function() {if($(this).val()!="") { $.cookie("OrdersAreaID",$(this).val(),{ expires: 1000 }); } else { $.cookie("OrdersAreaID",null); }$.cookie("OrdersDeliveryPeriod",$("#selDeliveryPeriod").val(),{ expires: 1000 });location.href="OrdersOutLibraryList.aspx?p=1&aid="+$(this).val()+"&dp="+$("#selDeliveryPeriod").val()+"&cid="+$("#selCouriers").val();});
$("#selProvince").change(function() { if($(this).val()!="") { var _provinceid=$(this).val();$.ajax({ type: "get",url: "/xml/areas/areas.xml",error: function() { alert("服务器响应超时，数据加载失败！"); },success: function(xml) { var _city="<option value=\"\">请选择</option>";$(xml).find("pr").each(function() { if($(this).attr("ai")==_provinceid) { $(this).find("ct").each(function() { _city+="<option value=\""+$(this).attr("ai")+"\">"+$(this).attr("an")+"</option>"; }); } });$("#selCity").html(_city);$("#selArea").html("<option value=\"\">请选择</option>"); } }); } else { $("#selCity").html("<option value=\"\">请选择</option>");$("#selArea").html("<option value=\"\">请选择</option>"); } });
$("#selCity").change(function() { if($(this).val()!="") { var _cityid=$(this).val();$.ajax({ type: "get",url: "/xml/areas/areas.xml",error: function() { alert("服务器响应超时，数据加载失败！"); },success: function(xml) { var _area="<option value=\"\">请选择</option>";$(xml).find("ct").each(function() { if($(this).attr("ai")==_cityid) { $(this).find("ar").each(function() { _area+="<option value=\""+$(this).attr("ai")+"\">"+$(this).attr("an")+"</option>"; }); } });$("#selArea").html(_area); } }); } else { $("#selArea").html("<option value=\"\">请选择</option>"); } });
$("#selDeliveryPeriod").change(function() { $.cookie("OrdersDeliveryPeriod",$(this).val(),{ expires: 1000 });location.href="OrdersOutLibraryList.aspx?p=1&aid="+$("#selArea").val()+"&dp="+$(this).val()+"&cid="+$("#selCouriers").val(); });
//送货时间
$.ajax({ type: "get",url: "/xml/deliveryperiod.xml",error: function() { alert("服务器响应超时，数据加载失败！"); },
success: function(xml) {
$("#divOrdersCountStatistics table tr").each(function() {
var _obj=$(this).children(".dp");
var _dp=$(this).children(".dp").children("input").val();
$(xml).find("DeliveryPeriod").each(function() {
if(_dp==$(this).find("DeliveryPeriodValue").text()) { $(_obj).text($(this).find("DeliveryPeriodKey").text());return false; }
});
});
}
});
$("#selCouriers").change(function() { location.href="OrdersOutLibraryList.aspx?p=1&aid="+$("#selArea").val()+"&dp="+$("#selDeliveryPeriod").val()+"&cid="+$(this).val(); });
$(".tb select").change(function() {
var _ordersgoodsid=$(this).next().val();
if($(this).val()=="6") {
//交易成功
$("#txtReturnGoodsCount"+_ordersgoodsid).val(0);
$("#txtReturnGoodsCount"+_ordersgoodsid).show();
$("#txtReturnGoodsCount"+_ordersgoodsid).keyup(function() {
if(IsNonnegativeInteger($(this).val())||$(this).val()=="") {
$(this).val(parseInt($(this).val()));
var _upperlimit=parseInt($.trim($("#tdGoodsCount"+_ordersgoodsid).text()))*2;
if($(this).val()!=""&&parseInt($(this).val())>_upperlimit) {
$("#txtReturnGoodsCount"+_ordersgoodsid).val(_upperlimit);
}
} else { $("#txtReturnGoodsCount"+_ordersgoodsid).val(0); }
});
}
else {
$("#txtReturnGoodsCount"+_ordersgoodsid).val("");
$("#txtReturnGoodsCount"+_ordersgoodsid).hide();
}
});
});
//提交
function SubmitOrder(_oid,_tdid,_loginid) {
var _sql="";
var _orderstatus="";
var _bargaincount=0;//实际成交量
var _monetary=0;//实际成交额
var _deliverytimes=0;//送货商品量
var _result=1;
var _gidarr="";
$(".tb select[name='sel"+_oid+"']").each(function() {
var _ordersgoodsid=$(this).next().val();
var _goodsstatus=$(this).next().next().val();
var _completecount=$(this).next().next().next().val();//商品完成量,用于判断是否为已经成交的商品
var _gid=$.trim($("#tdGoodsID"+_ordersgoodsid).text());
var _goodscount=$.trim($("#tdGoodsCount"+_ordersgoodsid).text());
var _returncount=$.trim($("#txtReturnGoodsCount"+_ordersgoodsid).val());
var _status=$(this).val();
if(_status=="6") {
if(_completecount==0) {
//未交易成功过的商品
if(_goodscount==_returncount) { _status="5"; }
}
else {
//交易成功后，顾客点击换货的商品
if(_goodsstatus=="4") { if(_goodscount==_returncount) { _status="5"; } } else { if(parseInt(_goodscount)*2==parseInt(_returncount)) { _status="5"; } }
//测试顾客点击退货、换货的情况即可
}
}
if(_status!="") {
_gidarr+="|"+_gid;
if(_status=="3"||_status=="5") {
//换货或退货成功
_sql+=" update Orders_Goods set GoodsStatus="+_status+" where OrdersGoodsID="+_ordersgoodsid;
var _salevolume=0;
if(_status=="5"&&_completecount>0) {
_salevolume= -_goodscount;
//删除评论积分
_sql+=" delete from Integral where OrdersGoodsID="+_ordersgoodsid+" and SourseType=1";
}
if(_goodsstatus!="4"&&_status=="5"&&_completecount>0) { /*顾客点击的换货*/_goodscount=_goodscount*2; }
_sql+=" update Goods set Inventory=Inventory+"+_goodscount+",SalesVolume=SalesVolume+"+_salevolume+" where GoodsID="+_gid;//更新库存
}
else {
//交易成功
if(IsNonnegativeInteger(_returncount)&&parseInt(_returncount)<=parseInt(_goodscount)*2) {
//计算商品成交量
var _complete="";
if(_goodsstatus!="4") { _complete=parseInt(_goodscount)-parseInt(_returncount); } else { _complete= -parseInt(_returncount); }
_sql+=" update Orders_Goods set GoodsStatus="+_status+",CompleteCount=CompleteCount+"+_complete+",CompleteAmount=CompleteAmount+"+$.trim($("#tdTransactionPrice"+_ordersgoodsid).text())+"*"+_complete+" where OrdersGoodsID="+_ordersgoodsid;
var _inventory="";
if(_goodsstatus!="4") { _inventory=parseInt(_goodscount)-_complete; } else { _inventory= -_complete; }
_sql+=" update Goods set Inventory=Inventory+"+_inventory+",SalesVolume=SalesVolume+"+_complete+" where GoodsID="+_gid;//更新库存及销量
//计算实际成交量和实际成交额
_bargaincount+=_complete;
_monetary=Addition(_monetary,Multiply($.trim($("#tdTransactionPrice"+_ordersgoodsid).text()),_complete));
}
else {
if($.trim($("#tdSizeName"+_ordersgoodsid).text())!="") { alert("订单“"+_oid+"”->商品“"+_gid+"”->尺码“"+$.trim($("#tdSizeName"+_ordersgoodsid).text())+"”的商品返回数量必须为非负整数且不大于"+parseInt(_goodscount)*2+"！"); }
else { alert("订单“"+_oid+"”->商品“"+_gid+"”的商品返回数量必须为非负整数且不大于"+parseInt(_goodscount)*2+"！"); }
_result=0;
return false;
}
}
_deliverytimes++;
if(_orderstatus!="3") {
if(_orderstatus!="6") { _orderstatus=_status; }
else { if(_status=="3") { _orderstatus=_status; } }
}
}
else {
if($.trim($("#tdSizeName"+_ordersgoodsid).text())!="") { alert("请选择订单“"+_oid+"”->商品“"+_gid+"”->尺码“"+$.trim($("#tdSizeName"+_ordersgoodsid).text())+"”的商品交易状态！"); }
else { alert("请选择订单“"+_oid+"”->商品“"+_gid+"”的商品交易状态！"); }
_result=0;
return false;
}
});
_sql+=" update Users set CompleteCount=CompleteCount+"+_bargaincount+",Monetary=Monetary+"+_monetary+" where LoginID='"+_loginid+"'";//更新用户实际成交量及成交额
_sql+=" update Couriers set DeliveryTimes=DeliveryTimes+"+_deliverytimes+",DeliveryAmount=DeliveryAmount+"+_monetary+" where CourierID="+$("#hidCourierID"+_oid).val();//更新快递送货商品量和送货金额
if(_result==1) {
$("#"+_tdid).text("loading");
$.ajax({ type: "post",url: "ajaxservice/Orders.aspx",async: true,data: { ptype: "UpdateOrdersAndGoodsByID",oid: _oid,orderstatus: _orderstatus,deliveryperiod: $("#selDeliveryPeriod").val(),sql: _sql,gidarr: _gidarr.substring(1) },
success: function(msg) {
if(msg=="1") { $("#"+_tdid).text("提交成功"); }
else if(msg=="2") { $("#"+_tdid).text("该订单状态已变更,请查证后再进行操作"); }
else { alert("提交失败！");location=location; }
}
});
}
}
//验证是否为非负整数
function IsNonnegativeInteger(oNum) {
if(!oNum) return false;
var strP=/^\d+$/;
if(!strP.test(oNum)) return false;
try { if(parseFloat(oNum)!=oNum) return false; }
catch(ex) { return false; }
return true;
}
//计算浮点数乘法
function Multiply(arg1,arg2) { arg1=String(arg1);var i=arg1.length-arg1.indexOf(".")-1;i=(i>=arg1.length)?0:i;arg2=String(arg2);var j=arg2.length-arg2.indexOf(".")-1;j=(j>=arg2.length)?0:j;return arg1.replace(".","")*arg2.replace(".","")/Math.pow(10,i+j); }
function Addition(arg1,arg2) { var r1,r2,m;try { r1=arg1.toString().split(".")[1].length } catch(e) { r1=0 } try { r2=arg2.toString().split(".")[1].length } catch(e) { r2=0 } m=Math.pow(10,Math.max(r1,r2));return (arg1*m+arg2*m)/m; }