$(document).ready(function() {
$("#selCommentStatus").change(function() { location.href="GoodsCommentsList.aspx?p=1&cs="+$(this).val(); });
});
//审批评论
function VerifyComment(_cid,_status,_ogid,_trid) {
$.ajax({ type: "post",url: "ajaxservice/GoodsComments.aspx",async: true,
data: { ptype: "UpdateStatusByCommentID",cid: _cid,status: _status,ogid: _ogid },
success: function(msg) {
if(msg=="1") {
if(_trid!=null) {
if(_status=="2") { $("#"+_trid).text("通过"); }
else { $("#"+_trid).text("不通过"); }
}
else { alert("提交成功！");location.href="GoodsCommentsList.aspx?p=1&cs="+_status; }
}
else { alert("提交失败！");location.href="GoodsCommentsList.aspx?p=1&cs="+_status; }
}
});
}