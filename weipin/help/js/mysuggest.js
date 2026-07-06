$(document).ready(function() {
    $("#txtSuggest").keyup(function() {
        var _txtSuggest=$("#txtSuggest").checkLength({ min: 4,max: 301 });
        if(!_txtSuggest) {
            $("#spMsg").text("意见与建议字数长度请在5-300个字之间");
            $(this).val($(this).val().substring(0,300));
        }
        else { $("#spMsg").text(""); }
    });
    $("#windown-close").click(function() { location.href="/index.html"; });
});
function FormSubmit() {
    var _txtSuggest=$("#txtSuggest").checkLength({ min: 4,max: 301 });
    if(!_txtSuggest) {
        $("#spMsg").text("意见与建议字数长度请在5-300个字之间");
        $("#txtSuggest").val($("#txtSuggest").val().substring(0,300));
    }
    else { $("#aSubmit").attr("onclick","");$("#fmSuggest").submit(); }
}
function ClosePop() { $("#windownbg").remove();$("#windown-box").hide("",function() { $(this).remove(); });location.href="/index.html"; }