$(document).ready(function() {
$("#form1").validate({
rules: { txtAttributeNameAdd: { required: true} },
messages: { txtAttributeNameAdd: { required: "请输要添加的属性名称!"} }
});
$("#form2").validate({
rules: { txtAttributeNameUpdate: { required: true} },
messages: { txtAttributeNameUpdate: { required: "请输要修改的属性名称!"} }
});
$("#ulTree img").click(function() {
var objSP=$(this).parent().prev();
var spID=objSP.attr("id");
var _aid=spID.substring(2);
if($(this).attr("title")=="修改") {
//修改
$("#hidAttributeID").attr("value",_aid);//获取ID
$("#txtAttributeNameUpdate").attr("value",objSP.text());
$("#fdsAttributes").show("slow");
}
else if($(this).attr("title")=="编辑属性值") { location.href="AttributeValues.aspx?aid="+_aid+"&cid="+$("#hidCategoryID").val(); }
else {
//删除
if(confirm("确定删除吗？")) {
$.ajax({ type: "post",url: "ajaxservice/Attributes.aspx",async: true,data: { ptype: "DeleteAttributesByAttributeID",aid: _aid,cid: $("#hidCategoryID").val() },timeout: 5000,error: function() { alert("服务器响应超时，删除失败！"); },
success: function(msg) {
if(msg!=""&&msg=="1") { alert("删除属性成功！");location=location; }
else { alert("删除属性失败！"); }
}
});
}
}
});
$("#ulTree img").mouseover(function() { $(this).parent().prev().attr("style","color:#ff0000;"); });
$("#ulTree img").mouseout(function() { $(this).parent().prev().attr("style","color:#303030;"); });
});