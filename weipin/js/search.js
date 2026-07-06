$(document).ready(function() {
$("input[name='key']").val($("#hidKey").val());
$.ajax({ type: "get",url: "/xml/goods/seasonrecommendgoods.xml",dataType: "xml",
success: function(xml) {
var _seasonrecommend="";
$(xml).find("good").each(function() {
var _path=$(this).attr("path");
var _index=_path.lastIndexOf(".");
var _goodname=$(this).attr("name");
var _gid=$(this).attr("id");
_seasonrecommend+="<div class=\"list_side01\"><div class=\"list_sidep\"><a href=\"/page/"+Math.floor(_gid/1000)+"/goodsshow_"+_gid+".html\" target=\"_blank\" title=\""+_goodname+"\"><img src=\""+_path.substring(0,_index)+"_60x60"+_path.substring(_index)+"\"/></a></div><ul class=\"list_sider\"><li class=\"cp_wz\">";
_seasonrecommend+="<a href=\"/page/"+Math.floor(_gid/1000)+"/goodsshow_"+$(this).attr("id")+".html\" target=\"_blank\" title=\""+_goodname+"\">"+_goodname.substring(0,16)+"</a></li><li class=\"price_n\">售价：￥"+$(this).attr("price")+"</li></ul><div class=\"clear\"></div></div>";
});
$("#divSeasonRecommend").html(_seasonrecommend);
}
});
var _sort=$("#hidSort").val();
switch(_sort) {
case "1": $("#aRelated").css("color","#ff0000");$("#aRelated").attr("onclick","");break;
case "2": $("#aNewest").css("color","#ff0000");$("#aNewest").attr("onclick","");break;
case "3": $("#aLowToHigh").css("color","#ff0000");$("#aLowToHigh").attr("onclick","");break;
case "4": $("#aHighToLow").css("color","#ff0000");$("#aHighToLow").attr("onclick","");break;
}
//我的浏览
var _mybrowsedlist=$.cookie("MyBrowsedList");
if(_mybrowsedlist!=""&&_mybrowsedlist!=null) {
var _str="";
var _goods=_mybrowsedlist.split("|");
for(var i=0;i<_goods.length;i++) {
var _path=_goods[i].split(",")[3];
var _index=_path.lastIndexOf(".");
var _gid=_goods[i].split(",")[0];
_str+="<div class=\"list_side01\"><div class=\"list_sidep\"><a href=\"/page/"+Math.floor(_gid/1000)+"/goodsshow_"+_gid+".html\" title=\""+_goods[i].split(",")[1]+"\" target=\"_blank\"><img src=\""+_path.substring(0,_index)+"_60x60"+_path.substring(_index)+"\"/></a></div><ul class=\"list_sider\"><li class=\"cp_wz\">";
_str+="<a href=\"/page/"+Math.floor(_gid/1000)+"/goodsshow_"+_gid+".html\" title=\""+_goods[i].split(",")[1]+"\" target=\"_blank\">"+_goods[i].split(",")[1].substring(0,16)+"</a></li><li class=\"price_n\">售价：￥"+_goods[i].split(",")[2]+"</li></ul><div class=\"clear\"></div></div>";
}
$("#divMyBrowsedList").html(_str);
}
else {
$("#divMyBrowsedListTag").hide();
$("#divMyBrowsedList").hide();
}
});
function ListSort(sort) { location.href="/Search.aspx?key="+$("#hidKey").val()+"&st="+sort; }