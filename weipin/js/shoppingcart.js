$(document).ready(function() {
$(".shop_jian").click(function() { SubtractionCount($(this)); });
$(".shop_count").keyup(function() { KeyupCount($(this)); });
$(".shop_count").blur(function() { BlurCount($(this)); });
$(".shop_jia").click(function() { AddCount($(this)); });
LoadSizes();
CountPrice();
});
function CountPrice() {
var _total=0;var _amount=0;
$("table.ordr_tab1 tr").each(function() {
var _count=$(this).children().children(".choose").children().children().children(".shop_count").val();
if(_count!=""&&_count!=null) {
var _price=$(this).children().children(".red").text().replace("￥","");
_amount=Addition(_amount,Multiply(_price,_count));
_total=parseInt(_total)+parseInt(_count);
}
});
$("#spTotal").text(_total);$("#spAmount").text("￥"+_amount);
}
function LoadSizes() {
var _myshoppingcart=$.cookie("MyShoppingCart");
if(_myshoppingcart!=""&&_myshoppingcart!=null) {
var _arrmyshoppingcart=_myshoppingcart.split("|");
for(var i=0;i<_arrmyshoppingcart.length;i++) {
if(_arrmyshoppingcart[i].split(",")[3]!="") {
var _goodsid=_arrmyshoppingcart[i].split(",")[0];
var _sid=_arrmyshoppingcart[i].split(",")[3];
$.ajax({
type: "get",url: "/xml/goods/goodssizes/"+_goodsid+".xml",async: false,dataType: "xml",
success: function(xml) {
$(xml).find("size").each(function() {
if($(this).attr("value")==_sid) {
$("#td"+_goodsid+"_"+_sid).next().children().text($("#td"+_goodsid+"_"+_sid).next().children().text()+"_"+$(this).attr("name"));
return false;
}
});
}
});
}
}
}
}
function StructMyShoppingCartCookie(gid,count,price,sid) {
if(sid==null) { sid=""; }
var _myshoppingcart=$.cookie("MyShoppingCart");
if(_myshoppingcart!=""&&_myshoppingcart!=null) {
var _arrmyshoppingcart=_myshoppingcart.split("|");
var _res=0;
for(var i=0;i<_arrmyshoppingcart.length;i++) {
if(_arrmyshoppingcart[i].split(",")[0]==gid&&_arrmyshoppingcart[i].split(",")[3]==sid) {
_arrmyshoppingcart[i]=gid+","+count+","+price+","+sid;
_res=1;
break;
}
}
_myshoppingcart="";
for(var i=0;i<_arrmyshoppingcart.length;i++) {
_myshoppingcart+="|"+_arrmyshoppingcart[i].split(",")[0]+","+_arrmyshoppingcart[i].split(",")[1]+","+_arrmyshoppingcart[i].split(",")[2]+","+_arrmyshoppingcart[i].split(",")[3];
}
if(_res==0) {
_myshoppingcart+="|"+gid+","+count+","+price+","+sid;
}
$.cookie("MyShoppingCart",_myshoppingcart.substring(1),{ expires: 90,path: "/" });
}
else {
_myshoppingcart=gid+","+count+","+price+","+sid;
$.cookie("MyShoppingCart",_myshoppingcart,{ expires: 90,path: "/" });
}
}
function SubtractionCount(thisobj) {
var _goods_id=$(thisobj).parent().parent().parent().siblings(".goods_id");
var _gid=$(_goods_id).text();
var _price=$(_goods_id).next().next().children(".red").text().replace("￥","");
var _sid=$(_goods_id).children("input").val();
var _count=$(thisobj).next().children().val();
if(IsInteger(_count)) {
if(_count<=1) { alert("商品数量最少为1！"); } else { $(thisobj).next().children().val(_count-1); }
} else { $(thisobj).next().children().val(1); }
CountPrice();
StructMyShoppingCartCookie(_gid,$(thisobj).next().children().val(),_price,_sid);
}
function KeyupCount(thisobj) {
var _obj=$(thisobj).parent().parent().parent().parent().siblings(".goods_id");
var _price=$(_obj).next().next().children(".red").text().replace("￥","");
var _count=$(thisobj).val();
if(!IsInteger(_count)) { $(thisobj).val(1); }
CountPrice();
StructMyShoppingCartCookie($(_obj).text(),$(thisobj).val(),_price,$(_obj).children("input").val());
}
function BlurCount(thisobj) {
var _obj=$(thisobj).parent().parent().parent().parent().siblings(".goods_id");
var _price=$(_obj).next().next().children(".red").text().replace("￥","");
var _count=$(thisobj).val();
if(!IsInteger(_count)) { alert("请输入正确的数量！");$(thisobj).val(1); }
CountPrice();
StructMyShoppingCartCookie($(_obj).text(),$(thisobj).val(),_price,$(_obj).children("input").val());
}
function AddCount(thisobj) {
var _goods_id=$(thisobj).parent().parent().parent().siblings(".goods_id");
var _gid=$(_goods_id).text();
var _price=$(_goods_id).next().next().children(".red").text().replace("￥","");
var _sid=$(_goods_id).children("input").val();
var _count=$(thisobj).prev().children().val();
if(IsInteger(_count)) { if(_count>=99) { alert("商品数量最多为99！"); } else { $(thisobj).prev().children().val(parseInt(_count)+1); } }
else { $(thisobj).prev().children().val(1); }
CountPrice();
StructMyShoppingCartCookie(_gid,$(thisobj).prev().children().val(),_price,_sid);
}
function GoPay() {
$.ajax({
type: "post",url: "/ajaxservice/Users.aspx",async: true,data: { ptype: "CheckIsLogin" },
success: function(msg) {
if(msg=="1") { location.href="/OrderCheck.aspx"; } else { tipsWindown("登录","iframe:../../LoginPopOrderCheck.aspx","380","370","false","","true",""); }
}
});
}
function DeleteGoods(thisobj,gid) {
if(confirm("确定不购买此商品吗？")) {
$(thisobj).parent().parent().remove();
CountPrice();
var _myshoppingcart=$.cookie("MyShoppingCart");
if(_myshoppingcart!=""&&_myshoppingcart!=null) {
var _sid=$(thisobj).parent().siblings(".goods_id").children("input").val();
if(_sid==null) { _sid=""; }
var _arrmyshoppingcart=_myshoppingcart.split("|");
for(var i=0;i<_arrmyshoppingcart.length;i++) {
if(_arrmyshoppingcart[i].split(",")[0]==gid&&_arrmyshoppingcart[i].split(",")[3]==_sid) { _arrmyshoppingcart.splice(i,1);break; }
}
_myshoppingcart="";
for(var i=0;i<_arrmyshoppingcart.length;i++) {
_myshoppingcart+="|"+_arrmyshoppingcart[i].split(",")[0]+","+_arrmyshoppingcart[i].split(",")[1]+","+_arrmyshoppingcart[i].split(",")[2]+","+_arrmyshoppingcart[i].split(",")[3];
}
if(_myshoppingcart=="") {
$("#divShoppingCart").html("<div style=\"font-size:14px;text-align:center;color:#808080;font-weight:bold;padding:30px;\">您的购物车中没有商品，请先进行<a href=\"index.html\" style=\"color:#cc0001;text-decoration:underline;\">选购>></a></div>");
$.cookie("MyShoppingCart",null,{ expires: 90,path: "/" });
}
else { $.cookie("MyShoppingCart",_myshoppingcart.substring(1),{ expires: 90,path: "/" }); }
}
}
}
function ClearShopping() {
if(confirm("确定清空购物车的商品吗？")) {
$("#divShoppingCart").html("<div style=\"font-size:14px;text-align:center;color:#808080;font-weight:bold;padding:30px;\">您的购物车中没有商品，请先进行<a href=\"index.html\" style=\"color:#cc0001;text-decoration:underline;\">选购>></a></div>");
$.cookie("MyShoppingCart",null,{ expires: 90,path: "/" });
}
}
//是否是正整数
function IsInteger(s) { var patrn=/^[0-9]*[1-9][0-9]*$/;if(!patrn.exec(s)) { return false; } else { return true; } }
//计算浮点数乘法
function Multiply(arg1,arg2) { arg1=String(arg1);var i=arg1.length-arg1.indexOf(".")-1;i=(i>=arg1.length)?0:i;arg2=String(arg2);var j=arg2.length-arg2.indexOf(".")-1;j=(j>=arg2.length)?0:j;return arg1.replace(".","")*arg2.replace(".","")/Math.pow(10,i+j); }
function Addition(arg1,arg2) { var r1,r2,m;try { r1=arg1.toString().split(".")[1].length } catch(e) { r1=0 } try { r2=arg2.toString().split(".")[1].length } catch(e) { r2=0 } m=Math.pow(10,Math.max(r1,r2));return (arg1*m+arg2*m)/m; }