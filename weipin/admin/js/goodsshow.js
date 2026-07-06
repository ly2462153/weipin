$(document).ready(function() {
    var _categoryid3=$("#hidCategoryID3").val();
    if(_categoryid3!=""&&_categoryid3!=null) {
        $.ajax({ type: "get",url: "/xml/categories.xml",dataType: "xml",error: function() { alert("服务器响应超时，数据加载失败！"); },
            success: function(xml) {
                $(xml).find("category3").each(function() {
                    if($(this).attr("value")==_categoryid3) {
                        $("#divCategories").text($(this).parent().parent().attr("name")+"->"+$(this).parent().attr("name")+"->"+$(this).attr("name"));
                        return false;
                    }
                });
            }
        });
        $.ajax({ type: "get",url: "/xml/attributes/"+_categoryid3+".xml",dataType: "xml",error: function() { alert("服务器响应超时，数据加载失败！"); },
            success: function(xmlattributes) {
                var _goodsid=$("#lblGoodsID").text();
                $.ajax({ type: "get",url: "/xml/goods/goodsattributesvalues/"+_goodsid+".xml",dataType: "xml",error: function(XMLHttpRequest,textStatus,errorThrown) { if(textStatus=="timeout") { alert("服务器响应超时，数据加载失败！"); } },
                    success: function(xmlattributesvalues) {
                        var _str="<ul>";
                        $(xmlattributes).find("Attribute").each(function() {
                            var _allattributeid=$(this).attr("value");
                            var _allattributename=$(this).attr("name");
                            var _valueid="";
                            $(xmlattributesvalues).find("attributevalue").each(function() {
                                var _attribute=$(this).attr("attributeid");
                                if(_allattributeid==_attribute) {
                                    _valueid=$(this).attr("valueid");
                                    return false;
                                }
                            });
                            if(_valueid!="") {
                                $(this).find("AttributeValues").each(function() {
                                    if($(this).attr("value")==_valueid) {
                                        _str+="<li>"+_allattributename+":"+$(this).attr("name")+"</li>";
                                        return false;
                                    }
                                });
                            }
                        });
                        _str+="</ul>";
                        $("#divAttributes").html(_str);
                    }
                });
            }
        });
        //加载尺码
        $.ajax({ type: "get",url: "/xml/sizes.xml",dataType: "xml",error: function() { alert("服务器响应超时，数据加载失败！"); },
            success: function(xmlsizes) {
                $.ajax({ type: "get",url: "/xml/goods/goodssizes/"+$("#lblGoodsID").text()+".xml",dataType: "xml",cache: false,error: function(XMLHttpRequest,textStatus,errorThrown) { if(textStatus=="timeout") { alert("服务器响应超时，数据加载失败！"); } },
                    success: function(xml) {
                        var _sizes="";
                        $(xmlsizes).find("size").each(function() {
                            var _allsize=$(this).attr("value");
                            var _allsizename=$(this).attr("name");
                            var _sizeid="";var _ivt="";var _sl="";
                            $(xml).find("size").each(function() {
                                var _thissizeid=$(this).attr("value");
                                if(_allsize==_thissizeid) {
                                    _sizeid=$(this).attr("value");_ivt=$(this).attr("ivt");_sl=$(this).attr("sl");
                                    return false;
                                }
                            });
                            if(_allsize==_sizeid) {
                                _sizes+="<br/>"+$(this).attr("name")+"&nbsp;&nbsp;库存:"+_ivt+"&nbsp;&nbsp;补给线:"+_sl;
                            }
                        });
                        $("#ulSizes").html(_sizes.substring(5));
                    }
                });
            }
        });
        //加载图片
        $.ajax({ type: "get",url: "/xml/goods/goodspaths/"+$("#lblGoodsID").text()+".xml",dataType: "xml",error: function() { alert("服务器响应超时，数据加载失败！"); },
            success: function(xml) {
                var _goodsimg="";
                $(xml).find("path").each(function(i) { _goodsimg+="<div><img src=\""+$(this).attr("value")+"\"/></div>"; });
                $("#divGoodsPictures").html(_goodsimg);
            }
        });
        $("#btnUpdate").click(function() { location.href="GoodsUpdate.aspx?gid="+$("#lblGoodsID").text(); });
        $("#btnDelete").click(function() {
            if(confirm("确定删除吗？")) {
                $.ajax({ type: "post",url: "ajaxservice/Goods.aspx",async: true,data: { ptype: "DeleteGoodsByGoodsID",gid: $("#lblGoodsID").text(),oldsn: $("#lblSimilarNumber").text(),cid1: $("#hidCategoryID1").val() },
                    success: function(msg) {
                        if(msg=="1") { alert("删除成功！");location.href="GoodsAdd.aspx"; }
                        else { alert("删除失败！");location=location; }
                    }
                });
            }
        });
    }
});