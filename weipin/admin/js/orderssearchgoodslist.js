$(document).ready(function() {
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
});