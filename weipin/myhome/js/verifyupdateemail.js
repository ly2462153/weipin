$(document).ready(function() {
    jQuery.validator.addMethod("IsEmail",function(value,element) { return this.optional(element)||/^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/.test(value); },"");
    _validate=$("#fmVerifyEmail").validate({
        success: function(label) { if(label.prev().attr("id")!="txtVerifyCode") { label.addClass("success"); } },
        rules: {
            txtOldEmail: { required: true,IsEmail: true },
            txtNewEmail: { required: true,IsEmail: true }
        },
        messages: {
            txtOldEmail: { required: "请重新输入验证过的邮箱",IsEmail: "邮箱格式不正确" },
            txtNewEmail: { required: "请输入需要验证的新邮箱",IsEmail: "邮箱格式不正确" }
        }
    });
});
var _validate="";
function FormSubmit() {
    if(_validate.form()) {
        var _code=$("#txtVerifyCode").val();
        if(_code!="") {
            $.ajax({ type: "post",url: "/ajaxservice/VerifyCode.aspx",async: false,data: { ptype: "GetEmailVerifyCode" },
                success: function(msg) {
                    if(msg!=""&&_code.toLowerCase()==msg.toLowerCase()) {
                        $("#aSubmit").attr("onclick","");
                        $('#fmVerifyEmail').submit();
                    }
                    else { alert("验证码输入错误,请重新输入!");$("#txtVerifyCode").val(""); }
                }
            });
        }
        else { alert("请输入验证码!"); }
    }
}
function ChangeCode() { $("#imgVerifyCode").attr("src","/verifycode/EmailVerifyCode.aspx?"+Math.random()); }
function ClosePop() { $("#windownbg").remove();$("#windown-box").hide("",function() { $(this).remove(); }); }