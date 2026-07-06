$(document).ready(function() {
    jQuery.validator.addMethod("IsLoginID",function(value,element) { return this.optional(element)||/^[a-zA-Z_0-9]+$/.test(value); },"");
    jQuery.validator.addMethod("IsEmail",function(value,element) { return this.optional(element)||/^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/.test(value); },"");
    var _validate=$("#fmRegister").validate({
        success: function(label) {
            if (label.prev().attr("id") == "txtVerifyCode") { label.addClass("success"); }
        },
        rules: {
            txtRegLoginID: {
                required: true,
                minlength: 4,
                maxlength: 20,
                IsLoginID: true,
                remote: {
                    url: "../ajaxservice/Users.aspx",
                    type: "post",
                    dataType: "json",
                    data: {
                        ptype: "CheckLoginID",
                        regloginid: function() { return $("#txtRegLoginID").val(); }
                    }
                }
            },
            txtRegPassword: {
                required: true,
                minlength: 6,
                maxlength: 20
            },
            txtRegConfirmPassword: {
                required: true,
                minlength: 6,
                maxlength: 20,
                equalTo: "#txtRegPassword"
            },
            txtEmail: {
                required: true,
                IsEmail: true
            }
        },
        messages: {
            txtRegLoginID: {
                required: "请输入用户名",
                minlength: "4-20位字符,可由英文、数字及“_”组成",
                maxlength: "4-20位字符,可由英文、数字及“_”组成",
                IsLoginID: "4-20位字符,可由英文、数字及“_”组成",
                remote: "此用户名已存在,请重新输入"
            },
            txtRegPassword: {
                required: "请输入密码",
                minlength: "密码长度请在6-20位之间",
                maxlength: "密码长度请在6-20位之间"
            },
            txtRegConfirmPassword: {
                required: "请再次输入密码",
                minlength: "密码长度请在6-20位之间",
                maxlength: "密码长度请在6-20位之间",
                equalTo: "两次密码不一致,请重新输入"
            },
            txtEmail: {
                required: "请输入邮箱",
                IsEmail: "邮箱格式不正确"
            }
        }
    });
    $("#imgRegister").click(function() {
        if(_validate.form()) {
            var _code=$("#txtVerifyCode").val();
            if(_code!="") {
                $.ajax({
                    type: "post",url: "../ajaxservice/VerifyCode.aspx",async: false,data: { ptype: "GetRegisterVerifyCode" },
                    success: function(msg) {
                        if(msg!=""&&_code.toLowerCase()==msg.toLowerCase()) {
                            $("#imgRegister").attr("onclick","");
                            $('#fmRegister').submit();
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
function ChangeCode() { $("#imgVerifyCode").attr("src","verifycode/RegisterVerifyCode.aspx?"+Math.random()); }
function CollectFavorite() { var a="http://www.weipin365.com/";var b="微品网上商城-心动小商品";if(document.all) { window.external.AddFavorite(a,b) } else if(window.sidebar) { window.sidebar.addPanel(b,a,"") } else { alert("对不起，您的浏览器不支持此操作!\n请您使用菜单栏或Ctrl+D收藏本站。") } }