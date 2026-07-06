$(document).ready(function() {
    $(".edit input:checkbox").click(function() {
        if($(this).siblings("input").attr("checked")==true) { $(this).siblings("input").attr("checked",""); }
        $("#spMsg").text("");
    });
    $("#btnSubmit").click(function() {
        var _str="";var _ordersstatus=0;
        $(".edit input[type='checkbox']:checked").each(function() {
            _str+="|"+$(this).attr("name").replace("ckbOrdersGoods","")+","+$(this).val();
            if(_ordersstatus!=3) { _ordersstatus=$(this).val(); }
        });
        if(_str!="") {
            var _txtExchangeReturnReasons=$("#txtExchangeReturnReasons").checkLength({ min: 0,max: 301 });
            if(!_txtExchangeReturnReasons) { $("#spReasonMsg").text("退换货理由为必填项且不能超过300个字");$("#txtExchangeReturnReasons").val($("#txtExchangeReturnReasons").val().substring(0,300)); }
            else {
                _str=_str.substring(1);
                $("#hidOrdersStatus").val(_ordersstatus);
                $("#hidGoodsStatus").val(_str);
                $("#fmReturnChangeGoods").submit();
            }
        }
        else { $("#spMsg").text("请在需要退换货的商品后面勾选相应选项"); }
    });
    $("#txtExchangeReturnReasons").keyup(function() {
        var _txtExchangeReturnReasons=$("#txtExchangeReturnReasons").checkLength({ min: 0,max: 301 });
        if(!_txtExchangeReturnReasons) { $("#spReasonMsg").text("退换货理由为必填项且不能超过300个字");$(this).val($(this).val().substring(0,300)); }
        else { $("#spReasonMsg").text(""); }
    });
});
function ClosePop() { $("#windownbg").remove();$("#windown-box").hide("",function() { $(this).remove(); });location.href="/myhome/MyReturnOrdersList.aspx"; }