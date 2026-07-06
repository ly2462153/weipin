$(document).ready(function() {
    _validate=$("#fmUpdatePassword").validate({
        success: function(label) {
            if(label.prev().attr("id")!="txtVerifyCode") {
                label.addClass("success");
            }
        },
        rules: {
            txtOldPassword: {
                required: true,
                minlength: 6,
                maxlength: 20
            },
            txtNewPassword: {
                required: true,
                minlength: 6,
                maxlength: 20
            },
            txtConfirmNewPassword: {
                required: true,
                minlength: 6,
                maxlength: 20,
                equalTo: "#txtNewPassword"
            }
        },
        messages: {
            txtOldPassword: {
                required: "请输入旧密码",
                minlength: "密码长度请在6-20位之间",
                maxlength: "密码长度请在6-20位之间"
            },
            txtNewPassword: {
                required: "请输入新密码",
                minlength: "密码长度请在6-20位之间",
                maxlength: "密码长度请在6-20位之间"
            },
            txtConfirmNewPassword: {
                required: "请再次输入新密码",
                minlength: "密码长度请在6-20位之间",
                maxlength: "密码长度请在6-20位之间",
                equalTo: "两次输入新密码不一致,请重新输入"
            }
        }
    });
});
var _validate="";
function FormSubmit() {
    if(_validate.form()) {
        var _code=$("#txtVerifyCode").val();
        if(_code!="") {
            $.ajax({
                type: "post",
                url: "../ajaxservice/VerifyCode.aspx",
                async: false,
                data: { ptype: "GetUpdatePasswordVerifyCode" },
                success: function(msg) {
                    if(msg!=""&&_code.toLowerCase()==msg.toLowerCase()) {
                        $("#aSubmit").attr("onclick","");
                        $('#fmUpdatePassword').submit();
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
}
function ChangeCode() { $("#imgVerifyCode").attr("src","/verifycode/UpdatePasswordVerifyCode.aspx?"+Math.random()); }
function ClosePop() { $("#windownbg").remove();$("#windown-box").hide("",function() { $(this).remove(); }); }