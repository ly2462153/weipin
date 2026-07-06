$(document).ready(function() {
$("#form1").validate({
rules: { txtAttributeValueNameAdd: { required: true} },
messages: { txtAttributeValueNameAdd: { required: "请输要添加的属性值名称!"} }
});
$("#form2").validate({
rules: { txtAttributeValueNameUpdate: { required: true} },
messages: { txtAttributeValueNameUpdate: { required: "请输要修改的属性值名称!"} }
});
$("#btnBack").click(function() { location.href="Attributes.aspx?cid="+$("#hidCategoryID").val(); });
$("#ulTree img").click(function() {
var objSP=$(this).parent().prev();
var spID=objSP.attr("id");
var _avid=spID.substring(2);
if($(this).attr("title")=="修改") {
//修改
$("#hidAttributeValueID").attr("value",_avid);//获取ID
$("#txtAttributeValueNameUpdate").attr("value",objSP.text());
$("#fdsAttributeValues").show("slow");
}
else {
//删除
if(confirm("确定删除吗？")) {
$.ajax({ type: "post",url: "ajaxservice/AttributeValues.aspx",async: true,data: { ptype: "DeleteAttributeValuesByAttributeValueID",avid: _avid,cid: $("#hidCategoryID").val() },timeout: 5000,error: function() { alert("服务器响应超时，删除失败！"); },
success: function(msg) {
if(msg!=""&&msg=="1") { alert("删除属性值成功！");location=location; }
else { alert("删除属性值失败！"); } 
}
});
}
}
});
$("#ulTree img").mouseover(function() { $(this).parent().prev().attr("style","color:#ff0000;"); });
$("#ulTree img").mouseout(function() { $(this).parent().prev().attr("style","color:#303030;"); });
});