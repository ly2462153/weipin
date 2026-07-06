$(document).ready(function () {
    _validate = $("#fmLogin").validate({
        rules: { txtLoginID: { required: true, minlength: 4, maxlength: 20 }, txtPassword: { required: true, minlength: 6, maxlength: 20 } },
        messages: { txtLoginID: { required: "请输入用户名", minlength: "用户名长度请在4-20位之间", maxlength: "用户名长度请在4-20位之间" }, txtPassword: { required: "请输入密码", minlength: "密码长度请在6-20位之间", maxlength: "密码长度请在6-20位之间" } }
    });
    $("#txtLoginID").focus(function () { $("#lblLoginID").text(""); $("#lblLoginPassword").text(""); });
    $("#txtPassword").focus(function () { $("#lblLoginPassword").text(""); $("#lblLoginID").text(""); });
    $(".top_hidico").mouseover(function () { $(".top_hid").show(); });
    $(".top_hidico").parent().parent().mouseout(function () { $(".top_hid").hide(); });
    $(".top_hid").mouseover(function () { $(".top_hid").show(); });
    if ($.cookie("MyShoppingCart") != null) { $("#spCount").text($.cookie("MyShoppingCart").split("|").length); }
});
QC.Login({ btnId: "divQQLogin", scope: "get_user_info", size: "A_M" },
function (reqdata, opts) {
    QC.Login.getMe(function (openid, accesstoken) {
        $.ajax({
            type: "post", url: "/ajaxservice/Login.aspx", async: true, data: { ptype: "OtherLogin", otherloginid: openid, nickname: reqdata.nickname, loginway: "qq" },
            success: function (msg) {
                if (msg == "1") {
                    var _index = location.href.indexOf("?returnurl=");
                    var _returnurl = location.href.substring(_index + 11);
                    location.href = _returnurl;
                }
                else { alert("登录失败,请重试"); }
            }
        });
    });
});
WB2.anyWhere(function (W) {
    W.widget.connectButton({
        id: "divSinaLogin",
        type: '3,2',
        callback: {
            login: function (o) {
                $.ajax({
                    type: "post", url: "/ajaxservice/Login.aspx", async: true, data: { ptype: "OtherLogin", otherloginid: o.id, nickname: o.screen_name, loginway: "sina" },
                    success: function (msg) {
                        if (msg == "1") {
                            var _index = location.href.indexOf("?returnurl=");
                            var _returnurl = location.href.substring(_index + 11);
                            location.href = _returnurl;
                        }
                        else { alert("登录失败,请重试"); }
                    }
                });
            }
        }
    });
});
function EnterPress(e) {
    e = (e) ? e : ((window.event) ? window.event : "");
    var key = e.keyCode ? e.keyCode : e.which;
    if (key == 13) { document.getElementById("aLogin").click(); }
}
var _validate = "";
function Login() { if (_validate.form()) { $("#fmLogin").submit(); } }
function CollectFavorite() { var a = "http://www.weipin365.com/"; var b = "微品网上商城-心动小商品"; if (document.all) { window.external.AddFavorite(a, b) } else if (window.sidebar) { window.sidebar.addPanel(b, a, "") } else { alert("对不起，您的浏览器不支持此操作!\n请您使用菜单栏或Ctrl+D收藏本站。") } }