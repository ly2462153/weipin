$(document).ready(function() {
    $(".comment div img").mouseover(function() {
        $(this).attr("src","/img/s1.gif");
        $(this).prevAll().attr("src","/img/s1.gif");
        $(this).nextAll().attr("src","/img/s0.gif");
    });
    $(".comment div img").mouseout(function() {
        var _mark=$(this).siblings("input").val();
        $(this).parent().children("img").each(function() {
            if(parseInt($(this).attr("title"))<=parseInt(_mark)) { $(this).attr("src","/img/s1.gif"); } else { $(this).attr("src","/img/s0.gif"); }
        });
    });
    $(".comment div img").click(function() { $(this).siblings("input").val($(this).attr("title")); });
    $("#txtComment").keyup(function() {
        var _txtComment=$("#txtComment").checkLength({ min: 4,max: 201 });
        if(!_txtComment) {
            $("#spCommentMsg").text("商品评论字数长度请在5-200个字之间");
            $(this).val($(this).val().substring(0,200));
        }
        else { $("#spCommentMsg").text(""); }
    });
    $("#windown-close").click(function() { location.href="GoodsCommentsList.aspx"; });
});
function FormSubmit() {
    var _txtComment=$("#txtComment").checkLength({ min: 4,max: 201 });
    if(!_txtComment) {
        $("#spCommentMsg").text("商品评论字数长度请在5-200个字之间");
        $("#txtComment").val($("#txtComment").val().substring(0,200));
    }
    else {
        $("#aSubmit").attr("onclick","");
        $("#fmComments").submit();
    }
}
function ClosePop() { $("#windownbg").remove();$("#windown-box").hide("",function() { $(this).remove(); });location.href="GoodsCommentsList.aspx"; }