$(document).ready(function () {
    $.ajax({
        type: "get", url: "/xml/categories.xml", dataType: "xml", error: function () { alert("服务器响应超时，数据加载失败！"); },
        success: function (xml) {
            var _options = ""
            _options = "<option value=\"\">请选择</option>";
            $(xml).find("category1").each(function () { _options += "<option value=\"" + $(this).attr("value") + "\">" + $(this).attr("name") + "</option>"; });
            $("#selCategory1").html(_options);
        }
    });
    $("#selCategory1").change(function () {
        var _categoryid = $(this).val();
        if (_categoryid != "") {
            $.ajax({
                type: "get", url: "/xml/categories.xml", dataType: "xml", error: function () { alert("服务器响应超时，数据加载失败！"); },
                success: function (xml) {
                    var _options = ""
                    _options = "<option value=\"\">请选择</option>";
                    $(xml).find("category1").each(function () {
                        if (_categoryid == $(this).attr("value")) {
                            $(this).find("category2").each(function () {
                                _options += "<option value=\"" + $(this).attr("value") + "\">" + $(this).attr("name") + "</option>";
                            });
                        }
                    });
                    $("#selCategory2").html(_options);
                    $("#selCategory3").html("<option value=\"\">请选择</option>");
                    $("#divAttributes").text("");
                    $("#hidAttributes").val("");
                }
            });
        }
        else {
            $("#selCategory2").html("<option value=\"\">请选择</option>");
            $("#selCategory3").html("<option value=\"\">请选择</option>");
            $("#divAttributes").text("");
            $("#hidAttributes").val("");
        }
    });
    $("#selCategory2").change(function () {
        var _categoryid = $(this).val();
        if (_categoryid != "") {
            $.ajax({
                type: "get", url: "/xml/categories.xml", dataType: "xml", error: function () { alert("服务器响应超时，数据加载失败！"); },
                success: function (xml) {
                    var _options = ""
                    _options = "<option value=\"\">请选择</option>";
                    $(xml).find("category2").each(function () {
                        if (_categoryid == $(this).attr("value")) { $(this).find("category3").each(function () { _options += "<option value=\"" + $(this).attr("value") + "\">" + $(this).attr("name") + "</option>"; }); }
                    });
                    $("#selCategory3").html(_options);
                    $("#divAttributes").text("");
                    $("#hidAttributes").val("");
                }
            });
        }
        else {
            $("#selCategory3").html("<option value=\"\">请选择</option>");
            $("#divAttributes").text("");
            $("#hidAttributes").val("");
        }
    });
    $("#selCategory3").change(function () {
        var _categoryid = $(this).val();
        if (_categoryid != "") {
            var _sql = "insert into Categories_Goods(CategoryID,GoodsID) values(" + $("#selCategory1").val() + ",{GoodsID})"
            _sql += " insert into Categories_Goods(CategoryID,GoodsID) values(" + $("#selCategory2").val() + ",{GoodsID})";
            _sql += " insert into Categories_Goods(CategoryID,GoodsID) values(" + _categoryid + ",{GoodsID})";
            $.ajax({
                type: "get", url: "/xml/attributes/" + _categoryid + ".xml", dataType: "xml", error: function () { alert("服务器响应超时，数据加载失败！"); },
                success: function (xml) {
                    var _str = "<ul>";
                    $(xml).find("Attribute").each(function () {
                        _str += "<li>" + $(this).attr("name") + ":<input type=\"hidden\" id=\"hidAttributeID\" value=\"" + $(this).attr("value") + "\"/>";
                        _str += "<select onchange=\"ChooseAttribute();\"><option value=\"\">请选择</option>";
                        $(this).find("AttributeValues").each(function () { _str += "<option value=\"" + $(this).attr("value") + "\">" + $(this).attr("name") + "</option>"; });
                        _str += "</select></li>";
                    });
                    _str += "</ul>";
                    $("#divAttributes").html(_str);
                }
            });
            $("#hidCategories").val(_sql);
        }
        else {
            $("#divAttributes").text("");
            $("#hidAttributes").val("");
            $("#hidCategories").val("");
        }
    });
    //加载尺码
    $.ajax({
        type: "get", url: "/xml/sizes.xml", dataType: "xml", error: function () { alert("服务器响应超时，数据加载失败！"); },
        success: function (xml) {
            var _sizes = ""
            $(xml).find("size").each(function () { _sizes += "<li><input type=\"checkbox\" value=\"" + $(this).attr("value") + "\" onclick=\"ChooseSizes(this);\"/><span>" + $(this).attr("name") + "</span>&nbsp;&nbsp;库存:<input type=\"text\" maxlength=\"8\" class=\"input-text-03\"/>&nbsp;&nbsp;补给线:<input type=\"text\" maxlength=\"6\" class=\"input-text-03\"/></li>"; });
            $("#ulSizes").html(_sizes);
        }
    });
    $("#selSimilarNumber").change(function () {
        if ($(this).val() == "") {
            $("#txtSimilarNumber").css("display", "none");
            $("#txtSimilarNumber").val("");
            $("#spDifferenceKeywords").css("display", "none");
            $("#txtDifferenceKeywords").css("display", "none");
            $("#txtDifferenceKeywords").val("");
        }
        else if ($(this).val() == "1") {
            $("#txtSimilarNumber").css("display", "none");
            $("#txtSimilarNumber").val("");
            $("#spDifferenceKeywords").css("display", "");
            $("#txtDifferenceKeywords").css("display", "");
        }
        else {
            $("#txtSimilarNumber").css("display", "");
            $("#spDifferenceKeywords").css("display", "");
            $("#txtDifferenceKeywords").css("display", "");
        }
    });
    $("#txtRemarks").keyup(function () {
        var _txtRemarks = $("#txtRemarks").checkLength({ min: -1, max: 301 });
        if (!_txtRemarks) { $("#spMsg").text("您最多可以输入300个字！"); $(this).val($(this).val().substring(0, 300)); }
        else { $("#spMsg").text(""); }
    });
    $("#txtWarmPrompt").keyup(function () {
        var _txtWarmPrompt = $("#txtWarmPrompt").checkLength({ min: -1, max: 501 });
        if (!_txtWarmPrompt) { $("#spWarmPrompt").text("您最多可以输入500个字！"); $(this).val($(this).val().substring(0, 500)); }
        else { $("#spWarmPrompt").text(""); }
    });
    $("#btnSubmit").click(function () {
        if (_validate.form()) {
            var _txtRemarks = $("#txtRemarks").checkLength({ min: -1, max: 301 });
            if (!_txtRemarks) { $("#txtRemarks").val($("#txtRemarks").val().substring(0, 300)); }
            var _txtWarmPrompt = $("#txtWarmPrompt").checkLength({ min: -1, max: 501 });
            if (!_txtWarmPrompt) { $("#txtWarmPrompt").val($("#txtWarmPrompt").val().substring(0, 500)); }
            $(this).parent().text("数据提交中,请稍后……");
            $("#txtGoodsName").val($("#txtGoodsName").val().replace(/{weipin:/g, "").replace(/\|/g, "｜").replace(/\,/g, "，").replace(/</g, "＜").replace(/&/g, "＆"));
            $("#txtKeywords").val($("#txtKeywords").val().replace(/{weipin:/g, ""));
            $("#txtRemarks").val($("#txtRemarks").val().replace(/{weipin:/g, ""));
            $("#txtWarmPrompt").val($("#txtWarmPrompt").val().replace(/{weipin:/g, ""));
            $("#form1").submit();
        }
    });
    //自定义验证函数
    jQuery.validator.addMethod("IsNonnegativeInteger", function (value, element) { var tel = /^\d+$/; return this.optional(element) || (tel.test(value)); }, "");
    jQuery.validator.addMethod("IsPositiveInteger", function (value, element) { var tel = /^[0-9]*[1-9][0-9]*$/; return this.optional(element) || (tel.test(value)); }, "");
    jQuery.validator.addMethod("IsFloat", function (value, element) { var tel = /^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/; return this.optional(element) || (tel.test(value)); }, "");
    var _validate = $("#form1").validate({
        rules: {
            selCategory3: { required: true },
            txtGoodsName: { required: true },
            txtKeywords: { required: true },
            txtSimilarNumber: { required: function () { return $("#selSimilarNumber").val() == "0"; }, IsPositiveInteger: true },
            txtDifferenceKeywords: { required: function () { return $("#selSimilarNumber").val() != ""; } },
            txtMarketPrice: { required: true, IsPositiveInteger: true },
            txtPrice: { required: true, IsFloat: true },
            txtDiscountPrice: { IsFloat: true },
            txtGoodsWeight: { IsFloat: true },
            hidSizesXML: { required: function () { return VerifySize(); } },
            txtInventory: { required: function () { return $("#trInventory").css("display") != "none"; }, IsNonnegativeInteger: true },
            txtSupplyLine: { required: function () { return $("#trInventory").css("display") != "none"; }, IsNonnegativeInteger: true },
            selIsBargain: { required: true },
            selIsCategoryPromotion: { required: true },
            selIsCategorySecondPromotion: { required: true },
            selIsNewRecommend: { required: true },
            selIsSeasonRecommend: { required: true },
            hidPicPath: { required: true }
        },
        messages: {
            selCategory3: { required: "请选择分类" },
            txtGoodsName: { required: "请输入商品名称" },
            txtKeywords: { required: "请输入商品关键词" },
            txtSimilarNumber: { required: "请填写商品同类编号", IsPositiveInteger: "请填写正整数" },
            txtDifferenceKeywords: { required: "请填写商品区别关键词" },
            txtMarketPrice: { required: "请填写市场价", IsPositiveInteger: "请填写正整数" },
            txtPrice: { required: "请填写微品价", IsFloat: "请填写正数" },
            txtDiscountPrice: { IsFloat: "请填写正数" },
            txtGoodsWeight: { IsFloat: "请填写正数" },
            hidSizesXML: { required: "请将勾选商品的库存和补给线填写完整(规则:勾选尺寸后的库存和补给线必填且为正整数或0)" },
            txtInventory: { required: "请填写商品库存！", IsNonnegativeInteger: "请填写正整数或0" },
            txtSupplyLine: { required: "请填写商品补给线！", IsNonnegativeInteger: "请填写正整数或0" },
            selIsBargain: { required: "请选择是否为特价商品" },
            selIsCategoryPromotion: { required: "请选择是否为首页一级分类置顶促销商品" },
            selIsCategorySecondPromotion: { required: "请选择是否为专题二级分类置顶促销商品" },
            selIsNewRecommend: { required: "请选择是否为专题新品推荐商品" },
            selIsSeasonRecommend: { required: "请选择是否为新品推荐商品" },
            hidPicPath: { required: "请上传商品图片" }
        }
    });
});
function VerifySize() {
    if ($("#trInventory").css("display") == "none") {
        var _sizexml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><sizes>";
        $("#ulSizes li input:checked").each(function () {
            if (IsNonInt($(this).next().next().val()) && IsNonInt($(this).next().next().next().val())) { _sizexml += "<size name=\"" + $(this).next().text() + "\" value=\"" + $(this).val() + "\" ivt=\"" + $(this).next().next().val() + "\" sl=\"" + $(this).next().next().next().val() + "\"/>"; } else { _sizexml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><sizes>"; return false; }
        });
        _sizexml += "</sizes>";
        if (_sizexml != "<?xml version=\"1.0\" encoding=\"utf-8\"?><sizes></sizes>") { $("#hidSizesXML").val(_sizexml); } else { $("#hidSizesXML").val(""); }
    }
    return $("#trInventory").css("display") == "none";
}
//选择尺码
function ChooseSizes(obj) {
    var _res = 0;
    $("#ulSizes li input:checked").each(function () { _res = 1; return false; });
    if (_res != 0) { $("#trInventory").hide(); } else { $("#trInventory").show(); }
    if ($(obj).attr("checked") != "checked") { $(obj).next().next().val(""); $(obj).next().next().next().val(""); }
}
//选择属性和值
function ChooseAttribute() {
    var _attribute = "";
    var _xmlattribute = "<?xml version=\"1.0\" encoding=\"utf-8\"?><attributesvalues>";
    $("#divAttributes select").each(function () {
        if ($(this).val() != "") {
            _attribute += " insert into Goods_Attributes_Values(GoodsID,AttributeID,ValueID) values({GoodsID}," + $(this).prev().val() + "," + $(this).val() + ")";
            _xmlattribute += "<attributevalue attributeid=\"" + $(this).prev().val() + "\" valueid=\"" + $(this).val() + "\"/>";
        }
    });
    _xmlattribute += "</attributesvalues>";
    $("#hidAttributes").val(_attribute);
    if (_xmlattribute != "<?xml version=\"1.0\" encoding=\"utf-8\"?><attributesvalues></attributesvalues>") { $("#hidAttributesXML").val(_xmlattribute); } else { $("#hidAttributesXML").val(""); }
}
function IsNonInt(s) { var patrn = /^\d+$/; if (!patrn.exec(s)) { return false; } else { return true; } }