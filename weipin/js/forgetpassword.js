$(document).ready(function() {
    jQuery.validator.addMethod("IsLoginID",function(value,element) { return this.optional(element)||/^[a-zA-Z_0-9]+$/.test(value); },"");
    jQuery.validator.addMethod("IsEmail",function(value,element) { return this.optional(element)||/^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/.test(value); },"");
    var _validate=$("#fmForgetPassword").validate({
        success: function(label) {
            if(label.prev().attr("id")!="txtVerifyCode") {
                label.addClass("success");
            }
        },
        rules: {
            txtLoginID: {
                required: true,
                minlength: 4,
                IsLoginID: true
            },
            txtEmail: {
                required: true,
                IsEmail: true
            }
        },
        messages: {
            txtLoginID: {
                required: "请输入用户名",
                minlength: "4-20位字符,可由英文、数字及“_”组成",
                IsLoginID: "4-20位字符,可由英文、数字及“_”组成"
            },
            txtEmail: {
                required: "请输入邮箱",
                IsEmail: "邮箱格式不正确"
            }
        }
    });
    $("#imgSubmit").click(function() {
        if(_validate.form()) {
            var _code=$("#txtVerifyCode").val();
            if(_code!="") {
                $.ajax({
                    type: "post",url: "../ajaxservice/VerifyCode.aspx",async: false,data: { ptype: "GetForgetPasswordVerifyCode" },
                    success: function(msg) {
                        if(msg!=""&&_code.toLowerCase()==msg.toLowerCase()) {
                            $("#imgSubmit").attr("onclick","");
                            $('#fmForgetPassword').submit();
                        }
                        else {
                            alert("验证码输入错误,请重新输入!");
                            $("#txtVerifyCode").val("");
                        }
                    }
                });
            }
            else { alert("请输入验证码!"); }
        }
    });
    $(".top_hidico").mouseover(function() { $(".top_hid").show(); });
    $(".top_hidico").parent().parent().mouseout(function() { $(".top_hid").hide(); });
    $(".top_hid").mouseover(function() { $(".top_hid").show(); });
    if($.cookie("MyShoppingCart")!=null) { $("#spCount").text($.cookie("MyShoppingCart").split("|").length); }
});
function ChangeCode() {
    $("#imgVerifyCode").attr("src","verifycode/ForgetPasswordVerifyCode.aspx?"+Math.random());
}
function CollectFavorite() { var a="http://www.weipin365.com/";var b="微品网上商城-心动小商品";if(document.all) { window.external.AddFavorite(a,b) } else if(window.sidebar) { window.sidebar.addPanel(b,a,"") } else { alert("对不起，您的浏览器不支持此操作!\n请您使用菜单栏或Ctrl+D收藏本站。") } }