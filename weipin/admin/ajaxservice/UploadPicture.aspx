<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPicture.aspx.cs"
    Inherits="weipin.admin.ajaxservice.UploadPicture" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传</title>
    <style type="text/css">
        .fileUploadBg { background: url(../img/uploadpic.gif) no-repeat scroll -2px -35px transparent; display: block; float: left; height: 25px; overflow: hidden; width: 175px; }
        .fileUploadBgGary { background: url(../img/uploadpic.gif) no-repeat scroll -2px -5px transparent; display: block; float: left; height: 25px; overflow: hidden; width: 175px; }
        .fileUploadDiv { height: 25px; overflow: hidden; position: absolute; width: 158px; }
        .fileInput { cursor: pointer; font-size: 80px; margin-left: -220px; margin-top: -5px; opacity: 0; filter: alpha(opacity:0); position: absolute; z-index: 100; }
    </style>
    <script src="../../js/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function uploadSelect1(el) { parent.AfterSelect(document.getElementById("file1").value,"1");$("#frmUpload").submit(); }
        function uploadSelect2(el) { parent.AfterSelect(document.getElementById("file2").value,"2");$("#frmUpload").submit(); }
        function uploadSelect3(el) { parent.AfterSelect(document.getElementById("file3").value,"3");$("#frmUpload").submit(); }
        function uploadSelect4(el) { parent.AfterSelect(document.getElementById("file4").value,"4");$("#frmUpload").submit(); }
        function uploadSelect5(el) { parent.AfterSelect(document.getElementById("file5").value,"5");$("#frmUpload").submit(); }
    </script>
</head>
<body>
    <form id="frmUpload" runat="server" method="post" enctype="multipart/form-data">
    <div id="divUploadBg1" class="fileUploadBg">
        <div class="fileUploadDiv">
            <input type="file" class="fileInput" id="file1" size="1" runat="server" onchange="uploadSelect1($(this));" /></div>
    </div>
    <div id="divUploadBg2" class="fileUploadBg">
        <div class="fileUploadDiv">
            <input type="file" class="fileInput" id="file2" size="1" runat="server" onchange="uploadSelect2($(this));" /></div>
    </div>
    <div id="divUploadBg3" class="fileUploadBg">
        <div class="fileUploadDiv">
            <input type="file" class="fileInput" id="file3" size="1" runat="server" onchange="uploadSelect3($(this));" /></div>
    </div>
    <div id="divUploadBg4" class="fileUploadBg">
        <div class="fileUploadDiv">
            <input type="file" class="fileInput" id="file4" size="1" runat="server" onchange="uploadSelect4($(this));" /></div>
    </div>
    <div id="divUploadBg5" class="fileUploadBg">
        <div class="fileUploadDiv">
            <input type="file" class="fileInput" id="file5" size="1" runat="server" onchange="uploadSelect5($(this));" /></div>
    </div>
    <input type="hidden" id="hidDisable" name="hidDisable" runat="server" />
    </form>
    <script language="javascript" type="text/javascript">
        var _obj=parent.document.getElementById("hidControlUpload");
        if(_obj!=null&&$("#hidDisable").val()=="") {
            var _arr=_obj.value.split("|");
            var _disable="";
            for(var i=0;i<_arr.length;i++) {
                $("#divUploadBg"+_arr[i]+" .fileUploadDiv").hide();
                $("#divUploadBg"+_arr[i]).attr("class","fileUploadBgGary");
                _disable+="|"+_arr[i];
            }
            $("#hidDisable").val(_disable);
        }
    </script>
</body>
</html>