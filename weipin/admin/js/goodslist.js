//删除
function DeleteDogs(_did,_cid) {
if(confirm("确定删除吗？")) {
$.ajax({ type: "post",url: "ajaxservice/Dogs.aspx",async: true,data: { ptype: "DeleteDogsByDogID",did: _did,cid: _cid },
success: function(msg) {
if(msg=="1") { alert("删除成功！");location.href="SizesList.aspx"; }
else { alert("删除失败！");location.href="SizesList.aspx"; }
}
});
}
}