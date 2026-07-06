$(document).ready(function() {
    $(".img-list").each(function() {
        var _img=$(this).children("input").val().split("|");
        var _str="";
        for(var i=0;i<_img.length;i++) {
            var _imgpath=_img[i].split(",")[1];
            var _index=_imgpath.lastIndexOf(".");
            var _gid=_img[i].split(",")[0];
            _str+="<a href=\"/page/"+Math.floor(_gid/1000)+"/goodsshow_"+_gid+".html\" target=\"_blank\"><img src=\""+_imgpath.substring(0,_index)+"_60x60"+_imgpath.substring(_index)+"\"/></a>";
        }
        $(this).html(_str);
    });
});
function CancelOrders(orderid,thisobj) {
    if(confirm("确定取消该订单吗？")) {
        var _thistd=$(thisobj).parent();
        $(_thistd).text("loading");
        $.ajax({
            type: "post",
            url: "/ajaxservice/Orders.aspx",
            async: true,
            data: { ptype: "UpdateOrdersIsCancelByID",oid: orderid },
            success: function(msg) {
                if(msg=="1") {
                    $(_thistd).prev().text("已取消");
                    $(_thistd).text("-");
                }
                else { alert("取消订单失败！"); }
            }
        });
    }
}