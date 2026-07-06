$(document).ready(function() {
    jQuery.validator.addMethod("IsMobilePhone",function(value,element) { return this.optional(element)||/^13[0-9]{1}[0-9]{8}$|^15[0-9]{1}[0-9]{8}$|^18[0-9]{1}[0-9]{8}$/.test(value); },"");
    $("input[name='rdoUserSex']").click(function() { if($(this).attr("id")=="rdoMale") { $("#hidUserSex").val("1"); } else { $("#hidUserSex").val("0"); } });
    $("#selYear").change(function() { StructDaySelect($(this).val(),$("#selMonth").val()); });
    $("#selMonth").change(function() { StructDaySelect($("#selYear").val(),$(this).val()); });
    _validate=$("#fmUserInfo").validate({
        rules: {
            txtUserName: { required: true },
            hidUserSex: { required: true },
            txtMobilePhone: { IsMobilePhone: true }
        },
        messages: {
            txtUserName: { required: "请输入您的姓名" },
            hidUserSex: { required: "请选择性别" },
            txtMobilePhone: { IsMobilePhone: "手机号码格式不正确,参考格式:13880566221" }
        }
    });
});
function StructDaySelect(year,month) {
    var _daycount=0;
    switch(month) {
        case "1": _daycount=31;break;
        case "2": if(year%400==0||(year%4==0&&year%100!=0)) { _daycount=29; } else { _daycount=28; } break;
        case "3": _daycount=31;break;
        case "4": _daycount=30;break;
        case "5": _daycount=31;break;
        case "6": _daycount=30;break;
        case "7": _daycount=31;break;
        case "8": _daycount=31;break;
        case "9": _daycount=30;break;
        case "10": _daycount=31;break;
        case "11": _daycount=30;break;
        case "12": _daycount=31;break;
    }
    var _str="";
    for(var i=1;i<=_daycount;i++) { _str+="<option value="+i+">"+i+"</option>"; }
    $("#selDay").html(_str);
}
var _validate="";
function FormSubmit() {
    if(_validate.form()) {
        $("#aSubmit").attr("onclick","");
        $("#fmUserInfo").submit();
    }
}
function ClosePop() { $("#windownbg").remove();$("#windown-box").hide("",function() { $(this).remove(); }); }