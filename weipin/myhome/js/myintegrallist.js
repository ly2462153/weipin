$(document).ready(function() {
    $.ajax({
        type: "get",url: "/xml/integralsourse.xml",dataType: "xml",
        success: function(xml) {
            $("#divIntegralList tr td input[name='hidSource']").each(function() {
                var _td=$(this).parent();
                var _source=$(this).val();
                $(xml).find("source").each(function() { if($(this).attr("value")==_source) { $(_td).text($(this).attr("name")); } });
            });
        }
    });
    $(".nedit-nav li a").click(function() {
        $(".nedit-nav li a").attr("class","");
        $(this).attr("class","selected");
        $("#divChange div").hide();
        var _thisid=$(this).attr("id").replace("a","div");
        $("#"+_thisid).show();
        $("#"+_thisid).children().show();
        if(_thisid=="aIntegralRecord") { $("#divMsg").show(); } else { $("#divMsg").hide(); }
    });
    $("#txtIntegral").keyup(function() {
        if(IsPositiveInteger($(this).val())&&parseInt($(this).val())%100==0) { $("#spOffsetPrice").text(parseInt($(this).val())/100); }
        else { $("#spOffsetPrice").text(0); }
    });
    $("#aSubmit").click(function() {
        if(IsPositiveInteger($("#txtIntegral").val())&&parseInt($("#txtIntegral").val())%100==0) { $("#fmExchange").submit(); }
        else { tipsWindown("提示","text:请输入100的倍数<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>","300","60","false","2000","0",""); }
    });
});
function IsPositiveInteger(s) { var patrn=/^[0-9]*[1-9][0-9]*$/;if(!patrn.exec(s)) { return false; } else { return true; } }
function ClosePop() { $("#windownbg").remove();$("#windown-box").hide("",function() { $(this).remove(); }); }