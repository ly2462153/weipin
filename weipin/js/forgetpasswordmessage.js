$(document).ready(function() {
    $(".top_hidico").mouseover(function() { $(".top_hid").show(); });
    $(".top_hidico").parent().parent().mouseout(function() { $(".top_hid").hide(); });
    $(".top_hid").mouseover(function() { $(".top_hid").show(); });
    if($.cookie("MyShoppingCart")!=null) { $("#spCount").text($.cookie("MyShoppingCart").split("|").length); }
});