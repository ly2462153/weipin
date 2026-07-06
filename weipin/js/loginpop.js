$(document).ready(function() {
_validate=$("#fmLogin").validate({
rules: {
txtLoginID: { required: true,minlength: 4,maxlength: 20 },
txtPassword: { required: true,minlength: 6,maxlength: 20 }
},
messages: {
txtLoginID: { required: "请输入用户名",minlength: "用户名长度请在4-20位之间",maxlength: "用户名长度请在4-20位之间" },
txtPassword: { required: "请输入密码",minlength: "密码长度请在6-20位之间",maxlength: "密码长度请在6-20位之间" }
}
});
$("#txtLoginID").focus(function() { $("#lblLoginID").text("");$("#lblLoginPassword").text(""); });
$("#txtPassword").focus(function() { $("#lblLoginPassword").text("");$("#lblLoginID").text(""); });
});
QC.Login({ btnId: "divQQLogin",scope: "get_user_info",size: "A_M" },
function(reqdata,opts) {
QC.Login.getMe(function(openid,accesstoken) {
$.ajax({ type: "post",url: "/ajaxservice/Login.aspx",async: true,data: { ptype: "OtherLoginCollect",otherloginid: openid,nickname: reqdata.nickname,loginway: "qq",gid: parent.document.getElementById('spGoodsID').innerText },
success: function(msg) {
var _res=msg.substring(0,1);
if(_res=="1") { eval(msg.substring(1));parent.document.getElementById('pCollectGoodsMessage').innerHTML='收藏成功！';parent.document.getElementById('divCollectGoodsAlert').style.display='block'; }
else if(_res=="2") { eval(msg.substring(1));parent.document.getElementById('pCollectGoodsMessage').innerHTML='您已经收藏过该商品！';parent.document.getElementById('divCollectGoodsAlert').style.display='block'; }
else if(_res=="3") { eval(msg.substring(1));parent.document.getElementById('pCollectGoodsMessage').innerHTML='系统出错，收藏失败！';parent.document.getElementById('divCollectGoodsAlert').style.display='block'; }
else { alert("登录失败,请重试"); }
}
});
});
});
WB2.anyWhere(function(W) {
W.widget.connectButton({
id: "divSinaLogin",
type: '3,2',
callback: {
login: function(o) {
$.ajax({ type: "post",url: "/ajaxservice/Login.aspx",async: true,data: { ptype: "OtherLoginCollect",otherloginid: o.id,nickname: o.screen_name,loginway: "sina",gid: parent.document.getElementById('spGoodsID').innerText },
success: function(msg) {
var _res=msg.substring(0,1);
if(_res=="1") { eval(msg.substring(1));parent.document.getElementById('pCollectGoodsMessage').innerHTML='收藏成功！';parent.document.getElementById('divCollectGoodsAlert').style.display='block'; }
else if(_res=="2") { eval(msg.substring(1));parent.document.getElementById('pCollectGoodsMessage').innerHTML='您已经收藏过该商品！';parent.document.getElementById('divCollectGoodsAlert').style.display='block'; }
else if(_res=="3") { eval(msg.substring(1));parent.document.getElementById('pCollectGoodsMessage').innerHTML='系统出错，收藏失败！';parent.document.getElementById('divCollectGoodsAlert').style.display='block'; }
else { alert("登录失败,请重试"); }
}
});
}
}
});
});
var _validate="";
function Login() { if(_validate.form()) { $("#fmLogin").submit(); } }
function EnterPress(e) { e=(e)?e:((window.event)?window.event:"");var key=e.keyCode?e.keyCode:e.which;if(key==13) { $(".openbox_but").click(); } }