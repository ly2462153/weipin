$(document).ready(function() {
    $.ajax({ type: "get",url: "/xml/areas/areas.xml",dataType: "xml",success: function(xml) { var _province="<option value=\"\">请选择</option>";$(xml).find("pr").each(function() { _province+="<option value=\""+$(this).attr("ai")+"\">"+$(this).attr("an")+"</option>"; });$("#selProvince").html(_province); } });
    $("#selProvince").change(function() { if($(this).val()!="") { $("#lblArea").text($(this).find("option:selected").text()+",");var _provinceid=$(this).val();$.ajax({ type: "get",url: "/xml/areas/areas.xml",error: function() { alert("服务器响应超时，数据加载失败！"); },success: function(xml) { var _city="<option value=\"\">请选择</option>";$(xml).find("pr").each(function() { if($(this).attr("ai")==_provinceid) { $(this).find("ct").each(function() { _city+="<option value=\""+$(this).attr("ai")+"\">"+$(this).attr("an")+"</option>"; }); } });$("#selCity").html(_city);$("#selArea").html("<option value=\"\">请选择</option>"); } }); } else { $("#lblArea").text("");$("#selCity").html("<option value=\"\">请选择</option>");$("#selArea").html("<option value=\"\">请选择</option>"); } });
    $("#selCity").change(function() { $("#lblArea").text($("#selProvince").find("option:selected").text()+",");if($(this).val()!="") { $("#lblArea").append($(this).find("option:selected").text()+",");var _cityid=$(this).val();$.ajax({ type: "get",url: "/xml/areas/areas.xml",error: function() { alert("服务器响应超时，数据加载失败！"); },success: function(xml) { var _area="<option value=\"\">请选择</option>";$(xml).find("ct").each(function() { if($(this).attr("ai")==_cityid) { $(this).find("ar").each(function() { _area+="<option value=\""+$(this).attr("ai")+"\">"+$(this).attr("an")+"</option>"; }); } });$("#selArea").html(_area); } }); } else { $("#selArea").html("<option value=\"\">请选择</option>"); } });
    $("#selArea").change(function() { $("#lblArea").text($("#selProvince").find("option:selected").text()+","+$("#selCity").find("option:selected").text()+",");if($(this).val()!="") { $("#lblArea").append($(this).find("option:selected").text()+","); } });
    $("#aSaveMyAddress").click(function() {
        if(_validate.form()) {
            var _cname=$("#txtConsigneeName").val();
            var _areaid=$("#selArea").val();
            var _address=$("#txtMyAddress").val();
            var _mphone=$("#txtMobilePhone").val();
            var _tphone=$("#txtTelephone").val();
            var _zipcode=$("#txtMyZipcode").val();
            $.ajax({
                type: "post",
                url: "/ajaxservice/MyShippingAddresses.aspx",
                async: true,
                data: { ptype: "InsertMyAddress",cname: _cname,areaid: _areaid,address: _address,mphone: _mphone,tphone: _tphone,zipcode: _zipcode },
                success: function(msg) {
                    if(parseInt(msg)>0) {
                        var _tbstr="<tr><td>"+_cname+"</td><td style=\"text-align:left;\">"+_address+"";
                        if(_zipcode!="") { _tbstr+=","+_zipcode+"</td>"; } else { _tbstr+="</td>"; }
                        if(_mphone!="") { _tbstr+="<td>"+_mphone+"</td>"; } else { _tbstr+="<td></td>"; }
                        if(_tphone!="") { _tbstr+="<td>"+_tphone+"</td>"; } else { _tbstr+="<td></td>"; }
                        _tbstr+="<td><a href=\"#\" onclick=\"DeleteMyAddress('"+msg+"',this);return false;\" style=\"float:none;\">删除</a></td></tr>";
                        if($("#divMyShippingAddressesList").text()!="") {
                            $("#divMyShippingAddressesList table").append(_tbstr);
                        }
                        else {
                            $("#divMyShippingAddressesList").html("<table><tr><th width=\"10%\">收货人</th><th width=\"55%\">详细地址</th><th width=\"12%\">手机</th><th width=\"13%\">座机</th><th width=\"10%\">&nbsp;</th></tr>"+_tbstr+"</table>");
                        }
                    }
                    else if(msg=="-1") { alert("您填写的资料超出了限定的字数!"); }
                    else if(msg=="-2") { alert("您最多可以保存10条地址信息,如需添加此条地址信息,可暂时删除其它任意信息后再进行添加!"); }
                    else { alert("添加失败!"); }
                }
            });
        }
    });
    jQuery.validator.addMethod("IsMobilePhone",function(value,element) {
        return this.optional(element)||/^13[0-9]{1}[0-9]{8}$|^15[0-9]{1}[0-9]{8}$|^18[0-9]{1}[0-9]{8}$/.test(value);
    },"");
    jQuery.validator.addMethod("IsTelephone",function(value,element) {
        return this.optional(element)||/^(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$/.test(value);
    },"");
    jQuery.validator.addMethod("IsZipcode",function(value,element) {
        return this.optional(element)||/^[1-9]\d{5}$/.test(value);
    },"");
    var _validate=$("#fmMyAddressAdd").validate({
        rules: {
            txtConsigneeName: { required: true },
            selArea: { required: true },
            txtMyAddress: { required: true },
            txtMobilePhone: {
                required: function() { return $("#txtTelephone").val()==""; },
                IsMobilePhone: true
            },
            txtTelephone: {
                required: function() { return $("#txtMobilePhone").val()==""; },
                IsTelephone: true
            },
            txtMyZipcode: { IsZipcode: true }
        },
        messages: {
            txtConsigneeName: { required: "请填写收货人姓名" },
            selArea: { required: "请选择区/县" },
            txtMyAddress: { required: "请填写详情街道地址" },
            txtMobilePhone: {
                required: "",
                IsMobilePhone: "手机号码格式不正确,参考格式:13880566221"
            },
            txtTelephone: {
                required: "请至少填写手机或座机中的一项",
                IsTelephone: "座机号码格式不正确,参考格式:86682233"
            },
            txtMyZipcode: { IsZipcode: "邮编格式不正确" }
        }
    });
});

function DeleteMyAddress(addressid,thisobj) {
    if(confirm("确定删除该收货地址吗？")) {
        $.ajax({
            type: "post",
            url: "/ajaxservice/MyShippingAddresses.aspx",
            async: true,
            data: { ptype: "DeleteMyAddress",adid: addressid },
            success: function(msg) {
                if(msg=="-1"||parseInt(msg)>0) { $(thisobj).parent().parent().remove(); }
                else if(msg=="0") {//已经删除最后一条数据
                    $("#divMyShippingAddressesList").text("");
                }
            }
        });
    }
}