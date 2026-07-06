$(document).ready(function() {
    $(".img-list").each(function() {
        var _img=$(this).children("input").val().split("|");
        var _str="";
        for(var i=0;i<_img.length;i++) {
            var _gid=_img[i].split(",")[0];
            var _gname=_img[i].split(",")[1];
            var _imgpath=_img[i].split(",")[2];
            var _ogid=_img[i].split(",")[3];
            var _commented=_img[i].split(",")[4];
            var _index=_imgpath.lastIndexOf(".");
            _str+="<div><a href=\"/page/"+Math.floor(_gid/1000)+"/goodsshow_"+_gid+".html\" style=\"text-align:center;\" title=\""+_gname+"\" target=\"_blank\"><img src=\""+_imgpath.substring(0,_index)+"_60x60"+_imgpath.substring(_index)+"\"/></a>";
            _str+="<a href=\"/page/"+Math.floor(_gid/1000)+"/goodsshow_"+_gid+".html\" title=\""+_gname+"\" target=\"_blank\">"+_gname.substring(0,48)+"</a>";
            if(_commented=="1") { _str+="<span class=\"commented\">(商品已评论)</span>"; } else { _str+="<a href=\"GoodsComments.aspx?ogid="+_ogid+"\" class=\"comment\">商品评论</a>"; }
            _str+="</div>";
        }
        $(this).html(_str);
    });
});