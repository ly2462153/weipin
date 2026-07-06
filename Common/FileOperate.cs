using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace weipin.Common
{
    public class FileOperate
    {
        public FileOperate()
        { }
        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="OriginalPath">源路径及文件名</param>
        /// <param name="TargetPath">目标路径</param>
        /// <param name="filename">文件名</param>
        public static bool FileMove(string OriginalPath, string TargetPath, string filename)
        {
            string path = HttpContext.Current.Server.MapPath(OriginalPath);
            FileInfo fi = new FileInfo(path);
            try
            {
                if (fi.Exists)
                {
                    string path2 = HttpContext.Current.Server.MapPath(TargetPath);
                    if (!Directory.Exists(path2))
                    {
                        Directory.CreateDirectory(path2);
                    }
                    fi.MoveTo(path2 + filename);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file">上传控件</param>
        /// <param name="sSavePath">保存路径(不含文件名)</param>
        /// <param name="sSaveFileName">文件名称(不含后缀名)</param>
        /// <returns>上传的文件名称(含后缀名)</returns>
        public static string UploadFile(HttpPostedFile file, string sSavePath, string sSaveFileName)
        {
            FileInfo fi = new FileInfo(file.FileName);
            try
            {
                string strExt = fi.Extension;
                string sPhyTargetPath = HttpContext.Current.Server.MapPath(sSavePath);
                if (!Directory.Exists(sPhyTargetPath))
                {
                    Directory.CreateDirectory(sPhyTargetPath);
                }
                file.SaveAs(sPhyTargetPath + "\\" + sSaveFileName + "" + strExt);
                return sSaveFileName + "" + strExt;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 写文件
        /// <param name="str">要写入文件的字符串</param>
        /// <param name="path">文件存储路径</param>
        /// </summary>
        public static void WriteFile(string str, string path)
        {
            FileStream fs = null;
            string _path = HttpContext.Current.Server.MapPath(path);
            try
            {
                fs = new FileStream(_path, FileMode.Create);
                byte[] _content = new System.Text.UTF8Encoding(true).GetBytes(str);
                fs.Write(_content, 0, _content.Length);
            }
            catch
            {
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        /// <summary>
        /// 删除文件
        /// <param name="sPath">文件路径</param>
        /// </summary>
        public static void DeleteFile(string sPath)
        {
            //删除单个文件
            string strPath = HttpContext.Current.Server.MapPath(sPath);
            FileInfo file = new FileInfo(strPath);
            if (file.Exists)
            {
                file.Delete();
            }
        }
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径</param>
        /// <param name="thumbnailPath">缩略图路径</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            Image originalImage = Image.FromFile(HttpContext.Current.Server.MapPath(originalImagePath));
            int towidth = width;
            int toheight = height;
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）
                    break;
                case "W"://指定宽，高按比例
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }
            //新建一个bmp图片
            Image bitmap = new Bitmap(towidth, toheight);
            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);
            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(HttpContext.Current.Server.MapPath(thumbnailPath), ImageFormat.Jpeg);
            }
            catch { throw; }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        /// <summary>
        /// 生成缩略图(并添加水印)
        /// </summary>
        /// <param name="originalImagePath">源图路径</param>
        /// <param name="thumbnailPath">缩略图路径</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>
        /// <param name="watermarkpath">水印图片路径</param>
        /// <param name="watermarkstatus">图片水印位置：0=不使用;1=左上;2=中上;3=右上;4=左中;9=右下</param>
        /// <param name="quality">附加图片质量：1是;0不是</param>
        /// <param name="watermarktransparency">水印的透明度：1--10,10为不透明</param>
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode, string watermarkpath, int watermarkstatus, int quality, int watermarktransparency)
        {
            Image originalImage = Image.FromFile(HttpContext.Current.Server.MapPath(originalImagePath));
            int towidth = width;
            int toheight = height;
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）
                    break;
                case "W"://指定宽，高按比例
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }
            //新建一个bmp图片
            Image bitmap = new Bitmap(towidth, toheight);
            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);
            try
            {
                //调用添加水印的方法，将缩微后的图片加水印后再上传
                AddImageSignPic(bitmap, HttpContext.Current.Server.MapPath(thumbnailPath), watermarkpath, watermarkstatus, quality, watermarktransparency);
            }
            catch { throw; }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        /// <summary>
        /// 生成缩略图(并添加水印)
        /// </summary>
        /// <param name="postedfile">上传控件对象</param>
        /// <param name="thumbnailPath">缩略图路径</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>
        /// <param name="watermarkpath">水印图片路径</param>
        /// <param name="watermarkstatus">图片水印位置：0=不使用;1=左上;2=中上;3=右上;4=左中;9=右下</param>
        /// <param name="quality">附加图片质量：1是;0不是</param>
        /// <param name="watermarktransparency">水印的透明度：1--10,10为不透明</param>
        public static void MakeThumbnail(System.Web.HttpPostedFile postedfile, string thumbnailPath, int width, int height, string mode, string watermarkpath, int watermarkstatus, int quality, int watermarktransparency)
        {
            Byte[] FileByteArray = new Byte[postedfile.ContentLength];
            Stream StreamObject = postedfile.InputStream;
            StreamObject.Read(FileByteArray, 0, postedfile.ContentLength);
            Image imageName = Image.FromStream(StreamObject);
            int towidth = width;
            int toheight = height;
            int x = 0;
            int y = 0;
            int ow = imageName.Width;
            int oh = imageName.Height;
            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）
                    break;
                case "W"://指定宽，高按比例
                    toheight = imageName.Height * width / imageName.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = imageName.Width * height / imageName.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）
                    if ((double)imageName.Width / (double)imageName.Height > (double)towidth / (double)toheight)
                    {
                        oh = imageName.Height;
                        ow = imageName.Height * towidth / toheight;
                        y = 0;
                        x = (imageName.Width - ow) / 2;
                    }
                    else
                    {
                        ow = imageName.Width;
                        oh = imageName.Width * height / towidth;
                        x = 0;
                        y = (imageName.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }
            //新建一个bmp图片
            Image bitmap = new Bitmap(towidth, toheight);
            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(imageName, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);
            try
            {
                //调用添加水印的方法，将缩微后的图片加水印后再上传
                AddImageSignPic(bitmap, HttpContext.Current.Server.MapPath(thumbnailPath), watermarkpath, watermarkstatus, quality, watermarktransparency);
            }
            catch { throw; }
            finally
            {
                imageName.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        /// <summary>
        /// 添加图片水印
        /// </summary>
        /// <param name="img">要添加水印的源图</param>
        /// <param name="filename">创建的新图片路径</param>
        /// <param name="watermarkFilename">水印图片的路径</param>
        /// <param name="watermarkStatus">图片水印位置：0=不使用;1=左上;2=中上;3=右上;4=左中;9=右下</param>
        /// <param name="quality">附加图片质量：1是;0不是</param>
        /// <param name="watermarkTransparency">水印的透明度：1--10,10为不透明</param>
        public static void AddImageSignPic(Image img, string filename, string watermarkFilename, int watermarkStatus, int quality, int watermarkTransparency)
        {
            Graphics g = Graphics.FromImage(img);
            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighQuality;
            Image watermark = new Bitmap(watermarkFilename);
            if (watermark.Height >= img.Height || watermark.Width >= img.Width) { return; }
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();
            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };
            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);
            float transparency = 0.5F;
            if (watermarkTransparency >= 1 && watermarkTransparency <= 10)
            {
                transparency = (watermarkTransparency / 10.0F);
            }
            float[][] colorMatrixElements = {
                                                new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  transparency, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                            };
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            int xpos = 0;
            int ypos = 0;
            switch (watermarkStatus)
            {
                case 1:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 2:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 3:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 4:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 5:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 6:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 7:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
                case 8:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
                case 9:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
            }
            g.DrawImage(watermark, new Rectangle(xpos, ypos, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);
            //g.DrawImage(watermark, new Rectangle(xpos, ypos, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel);
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo ici = null;
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType.IndexOf("jpeg") > -1)
                {
                    ici = codec;
                }
            }
            EncoderParameters encoderParams = new EncoderParameters();
            long[] qualityParam = new long[1];
            if (quality < 0 || quality > 100)
            {
                quality = 80;
            }
            qualityParam[0] = quality;
            EncoderParameter encoderParam = new EncoderParameter(Encoder.Quality, qualityParam);
            encoderParams.Param[0] = encoderParam;
            try
            {
                if (ici != null)
                {
                    img.Save(filename, ici, encoderParams);
                }
                else
                {
                    img.Save(filename);
                }
            }
            catch { throw; }
            finally
            {
                g.Dispose();
                img.Dispose();
                watermark.Dispose();
                imageAttributes.Dispose();
            }
        }
    }
}