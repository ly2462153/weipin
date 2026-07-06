$(document).ready(function() {
$("#btnBatchUpdate").click(function() {
$("#spFinished").text(0);
var _gidarr=$("#hidGoodsIDMuster").val().split("|");
for(var i=0;i<_gidarr.length;i++) {
$.ajax({ type: "post",url: "ajaxservice/Goods.aspx",data: { ptype: "CreateGoodsShow",gid: _gidarr[i] },
success: function(msg) { if(msg!=""&&msg=="True") { $("#spFinished").text(parseInt($("#spFinished").text())+1); } else { $("#spMsg").append("<br/>"+msg); } }
});
}
});
$("#btnClear").click(function() { $("#spFinished").text(0);$("#spMsg").html(""); });
});