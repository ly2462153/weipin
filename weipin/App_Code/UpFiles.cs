using System;
using weipin.Common;
using System.Web;
using System.IO;

/// <summary>
/// UpFiles 的摘要说明
/// </summary>
public class UpFiles
{
    private string _uploadPath = null;
    private bool _isDirectory = false;
    private bool _anewName = false;
    private int _fileSize = 1000;
    private string _fileType = "jpg,jpeg,gif";
    private int _width = 0;
    private int _height = 0;

    #region 属性
    /// <summary>
    /// 图片保存路径,默认为网站(UpFiles)目录
    /// </summary>
    public string UploadPath
    {
        get
        {
            return _uploadPath;
        }
        set
        {
            _uploadPath = value;
        }
    }
    /// <summary>
    /// 是否创建目录,默认为False,目录名称为:年+月+日
    /// </summary>
    public bool IsDirectory
    {
        get
        {
            return _isDirectory;
        }
        set
        {
            _isDirectory = value;
        }
    }
    /// <summary>
    /// 是否重命名文件,默认为False
    /// </summary>
    public bool AnewName
    {
        get
        {
            return _anewName;
        }
        set
        {
            _anewName = value;
        }
    }
    /// <summary>
    /// 上传图片的大小,默认为100KB
    /// </summary>
    public int FileSize
    {
        get
        {
            return _fileSize;
        }
        set
        {
            _fileSize = value;
        }
    }
    /// <summary>
    /// 上传文件的类型,默认为jpg和gif格式,多种文件格式请用逗号分隔
    /// </summary>
    public string FileType
    {
        get
        {
            return _fileType;
        }
        set
        {
            _fileType = value;
        }
    }
    /// <summary>
    /// 生成缩略图的宽度,默认为原图宽度
    /// </summary>
    public int Width
    {
        get
        {
            return _width;
        }
        set
        {
            _width = value;
        }
    }
    /// <summary>
    /// 生成缩略图的高度,默认为原图高度
    /// </summary>
    public int Height
    {
        get
        {
            return _height;
        }
        set
        {
            _height = value;
        }
    }
    #endregion
    public UpFiles()
    {
        IsDirectory = false;//是否创建目录
        AnewName = false;//是否重命名
        FileSize = 1000;
        FileType = "jpg,jpeg,gif";
        UploadPath = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath + "file/images/tempfolder/");//图片保存路径
        Width = 500;
        Height = 500;
    }
    /// <summary>
    /// 上传事件
    /// </summary>
    /// <param name="PostedFile">客户端上载的单独文件</param>
    /// <param name="_Path">源图路径</param>
    /// <returns>0:上传文件超过规定大小,1:上传文件类型错误</returns>
    public string FileSaveAs(System.Web.HttpPostedFile PostedFile)
    {
        //重命名名称
        string NewfileName = Guid.NewGuid().ToString().Replace("-", "");
        //获取上传文件的扩展名
        bool flag = false;
        string[] _ExtendName = FileType.Split(',');
        string sEx = System.IO.Path.GetExtension(PostedFile.FileName).Replace(".", "");
        foreach (string temp in _ExtendName)
        {
            if (temp == sEx.ToLower())
            {
                flag = true;
                break;
            }
        }
        if (!flag)
        {
            //文件格式不正确
            return "1";
        }
        //获取上传文件的大小
        long PostFileSize = PostedFile.ContentLength;
        if (PostFileSize >= FileSize * 1024)
        {
            //超过文件上传大小
            return "0";
        }
        Byte[] FileByteArray = new Byte[PostedFile.ContentLength];
        Stream StreamObject = PostedFile.InputStream;
        StreamObject.Read(FileByteArray, 0, PostedFile.ContentLength);
        System.Drawing.Image imageName = System.Drawing.Image.FromStream(StreamObject);
        //源图的宽度及高度
        int ImageWidth = imageName.Width;
        int ImageHeight = imageName.Height;
        if (imageName.Width != Width || imageName.Height != Height)
        {
            return "2";
        }
        try
        {
            if (AnewName)
            {
                PostedFile.SaveAs(UploadPath + NewfileName + "." + sEx);
                return NewfileName + "." + sEx;
            }
            else
            {
                PostedFile.SaveAs(UploadPath + PostedFile.FileName);
                return PostedFile.FileName;
            }
        }
        catch { return ""; }
    }
}