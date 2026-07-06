//注销
function LogoutCouriers(_cid) {
if(confirm("确定注销吗？")) {
$.ajax({ type: "post",url: "ajaxservice/Couriers.aspx",async: true,data: { ptype: "LogoutCouriersByCourierID",cid: _cid },
success: function(msg) {
if(msg=="1") { alert("注销成功！");location.href="CouriersList.aspx"; }
else { alert("注销失败！");location.href="CouriersList.aspx"; }
}
});
}
}
//删除
function DeleteCouriers(_cid) {
if(confirm("确定删除吗？")) {
$.ajax({ type: "post",url: "ajaxservice/Couriers.aspx",async: true,data: { ptype: "DeleteCouriersByCourierID",cid: _cid },
success: function(msg) {
if(msg=="1") { alert("删除成功！");location.href="CouriersList.aspx"; }
else { alert("删除失败！");location.href="CouriersList.aspx"; }
}
});
}
}