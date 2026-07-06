//删除订单备注
function DeleteOrdersRemarks(_orid) {
if(confirm("确定删除吗？")) {
$.ajax({ type: "post",url: "ajaxservice/OrdersRemarks.aspx",async: true,data: { ptype: "DeleteOrdersRemarksByOrdersRemarkID",orid: _orid },
success: function(msg) {
if(msg=="1") { alert("删除成功！");location.href="OrdersRemarksList.aspx?st="+$("#txtStartTime").val()+"&et="+$("#txtEndTime").val(); }
else { alert("删除失败！");location.href="OrdersRemarksList.aspx"; }
}
});
}
}