$(document).ready(function() {
$("#ulTree").treeview({ collapsed: true,animated: "medium",persist: "location" });
$("#form1").validate({
rules: { txtRootAreaName: { required: true} },
messages: { txtRootAreaName: { required: "请输入根区域名称!"} }
});
$("#form2").validate({
rules: { txtAreaName: { required: true },
txtFreight: { required: true,range: [0,999] }
},
messages: {
txtAreaName: { required: "请输入子区域名称!" },
txtFreight: { required: "请输入该区域运费!",range: "请输入0到999间的数字！" }
}
});
$("#ulTree img").click(function() {
var objSP=$(this).parent().prev();
var spID=objSP.attr("id");
var _aid=spID.substring(2);
if($(this).attr("title")=="添加子区域") {
//添加子区域
$("#hidAreaID").attr("value",_aid);//获取父级ID
$("#lblParentName").text("【"+objSP.text()+"】");
$("#trParent").show();
$("#txtAreaName").attr("value","");
$("#lblSonName").text("子区域名称:");
if($(this).next().val()=="3") { $("#trFreight").html("<td>运费(元):</td><td style=\"width:200px;\"><input type=\"text\" id=\"txtFreight\" name=\"txtFreight\" class=\"input-text\" maxlength=\"3\"/></td>"); }
else { $("#trFreight").empty(); }
$("#btnAddSubclass").attr("value","添加");
$("#fdsArea").show("slow");
}
else if($(this).attr("title")=="修改") {
//修改
$("#hidAreaID").attr("value",_aid);//获取ID
$("#txtRemarks").attr("value",$("#hid"+_aid).val());
$("#trParent").hide();
$("#txtAreaName").attr("value",objSP.text());
$("#lblSonName").text("区域名称:");
if($(this).next().val()=="3") { $("#trFreight").html("<td>运费(元):</td><td style=\"width:200px;\"><input type=\"text\" id=\"txtFreight\" name=\"txtFreight\" class=\"input-text\" maxlength=\"3\" value=\""+$(this).next().next().val()+"\"/></td>"); }
else { $("#trFreight").empty(); }
$("#btnAddSubclass").attr("value","修改");
$("#fdsArea").show("slow");
}
else {
//删除
if(confirm("此操作将删除当前区域及当前区域的子区域，确定继续吗？")) {
$.ajax({ type: "post",url: "ajaxservice/Areas.aspx",async: true,data: { ptype: "DeleteAreasByAreaID",aid: _aid },timeout: 5000,error: function() { alert("服务器响应超时，删除失败！"); },
success: function(msg) {
if(msg!=""&&msg=="1") { alert("删除区域成功！");location=location; }
else { alert("删除区域失败！"); }
}
});
}
}
});
$("#ulTree img").mouseover(function() { $(this).parent().prev().attr("style","color:#ff0000;"); });
$("#ulTree img").mouseout(function() { $(this).parent().prev().attr("style","color:#303030;"); });
});