$(document).ready(function() {
$("#ulTree").treeview({ collapsed: true,animated: "medium",persist: "location" });
$("#form1").validate({
rules: { txtRootCategoryName: { required: true} },
messages: { txtRootCategoryName: { required: "请输入根分类名称!"} }
});
$("#form2").validate({
rules: { txtCategoryName: { required: true} },
messages: { txtCategoryName: { required: "请输入子分类名称!"} }
});
$("#ulTree img").click(function() {
var objSP=$(this).parent().prev();
var spID=objSP.attr("id");
var _cid=spID.substring(2);
if($(this).attr("title")=="添加子分类") {
//添加子分类
$("#hidCategoryID").attr("value",_cid);//获取父级ID
$("#lblParentName").text("【"+objSP.text()+"】");
$("#rdoIsHighlightNo").attr("checked",true);
$("#trParent").show();
$("#txtCategoryName").attr("value","");
$("#lblSonName").text("子分类名称:");
$("#btnAddSubclass").attr("value","添加");
$("#fdsCategory").show("slow");
}
else if($(this).attr("title")=="修改") {
//修改
$("#hidCategoryID").attr("value",_cid);//获取ID
$("#txtRemarks").attr("value",$("#hid"+_cid).val());
var _ishighlight=$("#hidIsHighlight"+_cid).val();
if(_ishighlight=="True") {
$("#rdoIsHighlightYes").attr("checked",true);
$("#rdoIsHighlightNo").attr("checked",'');
}
else {
$("#rdoIsHighlightYes").attr("checked",'');
$("#rdoIsHighlightNo").attr("checked",true);
}
$("#trParent").hide();
$("#txtCategoryName").attr("value",objSP.text());
$("#lblSonName").text("分类名称:");
$("#btnAddSubclass").attr("value","修改");
$("#fdsCategory").show("slow");
}
else if($(this).attr("title")=="编辑属性") { location.href="Attributes.aspx?cid="+_cid; }
else {
//删除
if(confirm("此操作将删除当前分类及当前分类的子分类，确定继续吗？")) {
$.ajax({ type: "post",url: "ajaxservice/Categories.aspx",async: true,data: "ptype=DeleteCategoriesByCategoryID&cid="+_cid,timeout: 5000,error: function() { alert("服务器响应超时，删除失败！"); },
success: function(msg) {
if(msg!=""&&msg=="1") { alert("删除分类成功！");location=location; }
else { alert("删除分类失败！"); }
}
});
}
}
});
$("#ulTree img").mouseover(function() { $(this).parent().prev().attr("style","color:#ff0000;"); });
$("#ulTree img").mouseout(function() { $(this).parent().prev().attr("style","color:#303030;"); });
});