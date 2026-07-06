$(document).ready(function() {
CountPrice();
CountFreight();
$.ajax({ type: "get",url: "/xml/areas/areas.xml",dataType: "xml",success: function(xml) { var _areastr=$("#spArea").text();var _areaid=$("#spArea").children("input[type='hidden']").val();$(xml).find("ar").each(function() { if($(this).attr("ai")==_areaid) { $("#spArea").text(($(this).parent().parent().attr("an")+"-"+$(this).parent().attr("an")+"-"+$(this).attr("an")+"-"+_areastr));return false; } }); } });
});
function CountFreight() {
var _areaid=parseInt($("#spArea").children("input[type='hidden']").val());
var _expense=parseFloat($("#spOrderPrice").text());
if(((_areaid>1&&_areaid<30||_areaid>30&&_areaid<216||_areaid>216&&_areaid<325||_areaid>325&&_areaid<528||_areaid>528&&_areaid<667||_areaid>1142&&_areaid<1272||_areaid>1272&&_areaid<1377||_areaid>1377&&_areaid<1513||_areaid>1513&&_areaid<1615||_areaid>1615&&_areaid<1737||_areaid>1737&&_areaid<1910||_areaid>1910&&_areaid<2096||_areaid>2096&&_areaid<2219||_areaid>2219&&_areaid<2357||_areaid>2357&&_areaid<2545||_areaid>2545&&_areaid<2670||_areaid>2670&&_areaid<2705||_areaid>2705&&_areaid<2805||_areaid>2805&&_areaid<2957||_areaid>3038&&_areaid<3160)&&_expense>=38)||((_areaid>667&&_areaid<785||_areaid>785&&_areaid<915||_areaid>915&&_areaid<991||_areaid>991&&_areaid<1142||_areaid>2957&&_areaid<3038||_areaid>3160&&_areaid<3263||_areaid>3263&&_areaid<3316||_areaid>3316&&_areaid<3346||_areaid>3346&&_areaid<3463)&&_expense>=68)) { $("#spFreight").text(0); }
else { $.ajax({ type: "get",url: "/xml/areas/areas.xml",dataType: "xml",success: function(xml) { $(xml).find("ar").each(function() { if(_areaid.toString()==$(this).attr("ai")) { $("#spFreight").text($(this).attr("fr"));$("#spBargainPrice").text(Addition($("#spOrderPrice").text(),$("#spFreight").text()));if($("#spBargainPriceYet").text()!=0) { $("#spBargainPriceYet").text(Addition($("#spBargainPriceYet").text(),$("#spFreight").text())); } else { $("#spBargainPriceYet").text(0); } } }); } }); }
}
function CountPrice() {
var _orderpricetotal=0;var _bargainpricetotal=0;
$("#divOrdersList table tr").each(function(i) {
if(i!=0) {
var _price=$(this).children().eq(2).text().replace("￥","");
var _ordercount=$(this).children().eq(3).text();
var _bargaincount=$(this).children().eq(4).text();
_orderpricetotal=Addition(_orderpricetotal,Multiply(_price,_ordercount));
_bargainpricetotal=Addition(_bargainpricetotal,Multiply(_price,_bargaincount));
}
});
$("#divOrdersList .div_bottom").append("<div class=\"amount\"><ul><li>订购商品总金额：￥<span id=\"spOrderPrice\">"+_orderpricetotal.toFixed(1)+"</span></li><li>运费：￥<span id=\"spFreight\"></span></li><li>应付总金额：￥<span id=\"spBargainPrice\">"+_bargainpricetotal.toFixed(1)+"</span></li><li>实际成交总金额：￥<span id=\"spBargainPriceYet\">"+_bargainpricetotal.toFixed(1)+"</span></li></ul></div>");
}
function Multiply(arg1,arg2) { arg1=String(arg1);var i=arg1.length-arg1.indexOf(".")-1;i=(i>=arg1.length)?0:i;arg2=String(arg2);var j=arg2.length-arg2.indexOf(".")-1;j=(j>=arg2.length)?0:j;return arg1.replace(".","")*arg2.replace(".","")/Math.pow(10,i+j); }
function Addition(arg1,arg2) { var r1,r2,m;try { r1=arg1.toString().split(".")[1].length } catch(e) { r1=0 } try { r2=arg2.toString().split(".")[1].length } catch(e) { r2=0 } m=Math.pow(10,Math.max(r1,r2));return (arg1*m+arg2*m)/m; }