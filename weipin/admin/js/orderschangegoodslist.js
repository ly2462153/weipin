$(document).ready(function() {
$("#selArea").change(function() {if($(this).val()!="") { $.cookie("OrdersAreaID",$(this).val(),{ expires: 1000 }); }else { $.cookie("OrdersAreaID",null); }$.cookie("OrdersDeliveryPeriod",$("#selDeliveryPeriod").val(),{ expires: 1000 });location.href="OrdersChangeGoodsList.aspx?p=1&aid="+$(this).val()+"&dp="+$("#selDeliveryPeriod").val();});
$("#selProvince").change(function() { if($(this).val()!="") { var _provinceid=$(this).val();$.ajax({ type: "get",url: "/xml/areas/areas.xml",error: function() { alert("服务器响应超时，数据加载失败！"); },success: function(xml) { var _city="<option value=\"\">请选择</option>";$(xml).find("pr").each(function() { if($(this).attr("ai")==_provinceid) { $(this).find("ct").each(function() { _city+="<option value=\""+$(this).attr("ai")+"\">"+$(this).attr("an")+"</option>"; }); } });$("#selCity").html(_city);$("#selArea").html("<option value=\"\">请选择</option>"); } }); } else { $("#selCity").html("<option value=\"\">请选择</option>");$("#selArea").html("<option value=\"\">请选择</option>"); } });
$("#selCity").change(function() { if($(this).val()!="") { var _cityid=$(this).val();$.ajax({ type: "get",url: "/xml/areas/areas.xml",error: function() { alert("服务器响应超时，数据加载失败！"); },success: function(xml) { var _area="<option value=\"\">请选择</option>";$(xml).find("ct").each(function() { if($(this).attr("ai")==_cityid) { $(this).find("ar").each(function() { _area+="<option value=\""+$(this).attr("ai")+"\">"+$(this).attr("an")+"</option>"; }); } });$("#selArea").html(_area); } }); } else { $("#selArea").html("<option value=\"\">请选择</option>"); } });
$("#selDeliveryPeriod").change(function() { $.cookie("OrdersDeliveryPeriod",$(this).val(),{ expires: 1000 });location.href="OrdersChangeGoodsList.aspx?p=1&aid="+$("#selArea").val()+"&dp="+$(this).val(); });
//加载商品交易状态
$.ajax({ type: "get",url: "/xml/goods/goodsstatus.xml",error: function() { alert("服务器响应超时，数据加载失败！"); },
success: function(xml) {
$("input[name='hidGoodsStatus']").each(function() {
var _hidgoodsstatus=$(this);
$(xml).find("Status").each(function() {
if($(_hidgoodsstatus).val()==$(this).find("StatusID").text()) {
$(_hidgoodsstatus).before($(this).find("StatusName").text());
return false;
}
});
});
}
});
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
//加载快递员
$.ajax({ type: "get",url: "/xml/couriers/couriers.xml",error: function() { alert("服务器响应超时，数据加载失败！"); },
success: function(xml) {
var _areacourier="<option value=\"\">请选择</option>";
var _otherareacourier="<option value=\"\">---------</option>";
$(xml).find("Courier").each(function() {
if($("#selArea").val()==$(this).find("AreaID").text()) { _areacourier+="<option value=\""+$(this).find("CourierID").text()+"\">"+$(this).find("CourierName").text()+"</option>"; }
else { _otherareacourier+="<option value=\""+$(this).find("CourierID").text()+"\">"+$(this).find("CourierName").text()+"</option>"; }
});
$(".tb select").html(_areacourier+_otherareacourier);
}
});
});
//出库
function OutLibrary(_oid,_tdid) {
if($("#sel"+_oid).val()!="") {
$("#"+_tdid).text("loading");
var _cid=$("#sel"+_oid).val();
var _sql="";
var _gidarr="";
$("td[name='tdOID"+_oid+"']").each(function() {
var _ordersgoodsid=$(this).children("input").val();
var _hidgoodsstatus=$("#hidGoodsStatus"+_ordersgoodsid).val();
var _gid=$.trim($(this).text());
var _count=$.trim($("#tdGoodsCount"+_ordersgoodsid).text());//获取商品订购数量
if(_hidgoodsstatus=="3") {
_sql+=" update Goods set Inventory=Inventory-"+_count+" where GoodsID="+_gid;
_gidarr+="|"+_gid;
}
});
$.ajax({ type: "post",url: "ajaxservice/Orders.aspx",async: true,data: { ptype: "UpdateOrdersAndGoodsOutLibraryByOrderID",oid: _oid,cid: _cid,sql: _sql,gidarr: _gidarr.substring(1) },
success: function(msg) {
if(msg=="1") { $("#"+_tdid).text("提交成功"); }
else if(msg=="2") { $("#"+_tdid).text("该商品状态已变更,请将该商品入库"); }
else { alert("提交失败！");location=location; }
}
});
}
else { alert("请选择订单“"+_oid+"”的快递员！"); }
}