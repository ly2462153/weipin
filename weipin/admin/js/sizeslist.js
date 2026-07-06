//删除
function DeleteSizes(_sid) {
if(confirm("确定删除吗？")) {
$.ajax({ type: "post",url: "ajaxservice/Sizes.aspx",async: true,data: { ptype: "DeleteSizesBySizeID",sid: _sid },
success: function(msg) {
if(msg=="1") { alert("删除成功！");location.href="SizesList.aspx"; }
else { alert("删除失败！");location.href="SizesList.aspx"; }
}
});
}
}