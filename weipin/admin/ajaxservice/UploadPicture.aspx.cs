using System;
using System.Web;

namespace weipin.admin.ajaxservice
{
    public partial class UploadPicture : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) { UploadPic(); }
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        protected void UploadPic()
        {
            int _divShowPicID = 0;
            try
            {
                HttpPostedFile file = null;
                if (file1.PostedFile.ContentLength > 0)
                {
                    file = file1.PostedFile;
                    _divShowPicID = 1;
                }
                else if (file2.PostedFile.ContentLength > 0)
                {
                    file = file2.PostedFile;
                    _divShowPicID = 2;
                }
                else if (file3.PostedFile.ContentLength > 0)
                {
                    file = file3.PostedFile;
                    _divShowPicID = 3;
                }
                else if (file4.PostedFile.ContentLength > 0)
                {
                    file = file4.PostedFile;
                    _divShowPicID = 4;
                }
                else if (file5.PostedFile.ContentLength > 0)
                {
                    file = file5.PostedFile;
                    _divShowPicID = 5;
                }
                UpFiles upfile = new UpFiles();
                upfile.FileSize = 1000;
                upfile.AnewName = true;
                upfile.IsDirectory = true;
                string urlPath = upfile.FileSaveAs(file);
                if (urlPath == "0")
                {
                    Response.Write("<script type=\"text/javascript\">parent.UploadError('" + _divShowPicID + "','0');</script>");
                }
                else if (urlPath == "1")
                {
                    Response.Write("<script type=\"text/javascript\">parent.UploadError('" + _divShowPicID + "','1');</script>");
                }
                else if (urlPath == "2")
                {
                    Response.Write("<script type=\"text/javascript\">parent.UploadError('" + _divShowPicID + "','2');</script>");
                }
                else
                {
                    hidDisable.Value = Request.Form["hidDisable"].ToString() + "|" + _divShowPicID.ToString();
                    urlPath = urlPath.Replace("\\", "/");
                    urlPath = System.Web.HttpContext.Current.Request.ApplicationPath + "file/images/tempfolder/" + urlPath;
                    ClientScript.RegisterStartupScript(GetType(), "", "<script type=\"text/javascript\">parent.UploadSuccess('" + urlPath + "','" + _divShowPicID + "','1','" + hidDisable.Value.Substring(1) + "');</script>");
                }
            }
            catch { Response.Write("<script type=\"text/javascript\">parent.UploadError('" + _divShowPicID + "','');</script>"); }
        }
    }
}