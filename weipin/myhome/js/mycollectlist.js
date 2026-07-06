function ChooseAll(thisobj) {
    var _choose="";
    if($(thisobj).text()=="全选") {
        var _ckb=$(thisobj).parent().prev().children("input");
        var _res=$(_ckb).attr("checked");
        if(_res==true) { $(_ckb).attr("checked",""); } else { $(_ckb).attr("checked","checked"); }
        _choose=$(_ckb).attr("checked");
    } else { _choose=$(thisobj).attr("checked"); }
    $("#divCollectList table tr").each(function() {
        $(this).children().eq(0).children("input").attr("checked",_choose);
    });
}
function DeleteCollect(collectid,thisobj) {
    if(confirm("确定删除该商品收藏吗？")) {
        var _thistd=$(thisobj).parent();
        $(_thistd).text("loading");
        $.ajax({
            type: "post",
            url: "/ajaxservice/GoodsCollect.aspx",
            async: true,
            data: { ptype: "DeleteGoodsCollectByID",cid: collectid },
            success: function(msg) {
                if(msg=="1") {
                    $(_thistd).parent().remove();
                }
                else if(msg=="2") { location.href="/Login.aspx?returnurl=/myhome/MyCollectList.aspx"; }
                else { alert("删除收藏失败！"); }
            }
        });
    }
}
function DeleteAll() {
    var _str="";
    $("#divCollectList table tr").each(function() {
        var _chooseckb=$(this).children().eq(0).children("input[type='checkbox']:checked");
        if($(_chooseckb).val()!=null&&$(_chooseckb).val()!="on") {
            _str+="|"+$(_chooseckb).val();
        }
    });
    if(_str!="") {
        if(confirm("确定删除勾选的商品收藏吗？")) {
            $.ajax({
                type: "post",
                url: "/ajaxservice/GoodsCollect.aspx",
                async: true,
                data: { ptype: "DeleteGoodsCollectAllByID",cidarr: _str },
                success: function(msg) {
                    if(msg!="-1") {
                        if(msg!="0") {
                            location.href="/myhome/MyCollectList.aspx";
                        }
                        else { alert("删除收藏失败！"); }
                    }
                    else { location.href="/Login.aspx?returnurl=/myhome/MyCollectList.aspx"; }
                }
            });
        }
    } else { alert("请勾选要删除的商品收藏"); }
}