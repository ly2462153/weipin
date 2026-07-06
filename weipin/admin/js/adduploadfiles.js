$(document).ready(function() {
CreateBrowser($("#divUploadBox"));
});
//创建上传控件
function CreateBrowser(obj) {
var strContent="<div class='uploadcontrol'>";
strContent+="<div class=\"object\"><div id=\"divShowPic1\"><img src='img/fork.jpg'/></div><div id=\"divUploading1\" class=\"prompt\"></div></div>";
strContent+="<div class=\"object\"><div id=\"divShowPic2\"><img src='img/fork.jpg'/></div><div id=\"divUploading2\" class=\"prompt\"></div></div>";
strContent+="<div class=\"object\"><div id=\"divShowPic3\"><img src='img/fork.jpg'/></div><div id=\"divUploading3\" class=\"prompt\"></div></div>";
strContent+="<div class=\"object\"><div id=\"divShowPic4\"><img src='img/fork.jpg'/></div><div id=\"divUploading4\" class=\"prompt\"></div></div>";
strContent+="<div class=\"object\"><div id=\"divShowPic5\"><img src='img/fork.jpg'/></div><div id=\"divUploading5\" class=\"prompt\"></div></div>";
strContent+="</div><iframe src=\"ajaxservice/UploadPicture.aspx\" id=\"ifUpload\" frameborder=\"no\" scrolling=\"no\" style=\"width:895px;height:42px;\"></iframe>";//上传提示
obj.append(strContent);
}
//选择文件后的事件
function AfterSelect(imgsrc,itemid) {
//上传时暂时隐藏上传按钮及背景s
$("#ifUpload").contents().find("#divUploadBg"+itemid+" .fileUploadDiv").hide();
//上传时暂时隐藏上传按钮及背景e
$("#divShowPic"+itemid).html("<div style=\"width:172px;height:172px;\"><img src='img/loading.gif' align='absmiddle' style=\"margin:80px 0 0 80px;\"/></div>");
}
//上传成功后的处理
function UploadSuccess(newpath,itemid,type,uploadctrlid) {
if(type=="1") {
$("#divUploading"+itemid).html("文件上传成功!<a href='#' onclick=\"DeletePicture("+itemid+",'"+newpath+"');return false;\">[删除]</a>");
var _arr=uploadctrlid.split("|");
for(var i=0;i<_arr.length;i++) {
$("#ifUpload").contents().find("#divUploadBg"+_arr[i]+" .fileUploadDiv").hide();
$("#ifUpload").contents().find("#divUploadBg"+_arr[i]).attr("class","fileUploadBgGary");
}
$("#divShowPic"+itemid).html("<img src='"+newpath+"' width=\"172\" height=\"172\"/>");
//构造上传的图片路径
var _path="";
$("#divUploadBox .object div img").each(function() {
if($(this).attr("src").indexOf("fork.jpg")== -1) {
var _relativepath=$(this).attr("src").substring($(this).attr("src").indexOf("/file/images/tempfolder/"));
_path+="|"+_relativepath;
}
});
$("#hidPicPath").val(_path.substring(1));
}
}
//删除上传图片
function DeletePicture(itemid,_path) {
$.ajax({
type: "post",
url: "ajaxservice/GoodsPictures.aspx",
async: false,
data: { ptype: "DeletePicture",picpath: _path },
success: function(msg) {
//显示上传按钮及背景
$("#ifUpload").contents().find("#hidDisable").val($("#ifUpload").contents().find("#hidDisable").val().replace("|"+itemid,""));
$("#ifUpload").contents().find("#divUploadBg"+itemid+" .fileUploadDiv").show();
$("#ifUpload").contents().find("#divUploadBg"+itemid).attr("class","fileUploadBg");
$("#divUploading"+itemid).text("");
$("#divShowPic"+itemid).html("<img src='img/fork.jpg' align='absmiddle'/>");
//构造上传的图片路径
var _path="";
$("#divUploadBox .object div img").each(function() {
if($(this).attr("src").indexOf("fork.jpg")== -1) {
var _relativepath=$(this).attr("src").substring($(this).attr("src").indexOf("/file/images/tempfolder/"));
_path+="|"+_relativepath;
}
});
$("#hidPicPath").val(_path.substring(1));
}
});
}
//上传时程序发生错误时,给提示,并返回上传状态
function UploadError(itemid,type) {
if(type=='0') {
alert("上传文件超过限制的大小!");
$("#divShowPic"+itemid).html("<img src='img/fork.jpg' align='absmiddle'/>");
$("#ifUpload").contents().find("#divUploadBg"+itemid+" .fileUploadDiv").show();
}
else if(type=='1') {
alert("上传文件类型不正确!");
$("#divShowPic"+itemid).html("<img src='img/fork.jpg' align='absmiddle'/>");
$("#ifUpload").contents().find("#divUploadBg"+itemid+" .fileUploadDiv").show();
}
else if(type=='2') {
alert("请上传宽度和高度为500px的图片!");
$("#divShowPic"+itemid).html("<img src='img/fork.jpg' align='absmiddle'/>");
$("#ifUpload").contents().find("#divUploadBg"+itemid+" .fileUploadDiv").show();
}
else {
alert("程序异常，"+itemid+"项上传未成功。");
$("#divShowPic"+itemid).html("<img src='img/fork.jpg' align='absmiddle'/>");
$("#ifUpload").contents().find("#divUploadBg"+itemid+" .fileUploadDiv").show();
}
}