$(document).ready(function() {
$("#form1").validate({ rules: { txtSizeName: { required: true} },messages: { txtSizeName: { required: "请输入尺码名称！"}} });
});