using System;
using System.Web;
using System.Text;
using System.IO;
using System.Collections;
using weipin.Common;

namespace weipin.admin
{
    public partial class GoodsUpdate : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["selCategory3"] != null) { UpdateGoods(); }
            else if (Commonality.JudgeNumber(Request.QueryString["gid"], 10)) { BindGoods(Convert.ToInt32(Request.QueryString["gid"].ToString())); }
        }
        /// <summary>
        /// 绑定商品
        /// </summary>
        /// <param name="goodsid">商品ID</param>
        private void BindGoods(int goodsid)
        {
            BLL.Goods bg = new weipin.BLL.Goods();
            Model.Goods mg = bg.SelectGoodsByID(goodsid);
            if (mg.GoodsID != 0)
            {
                hidCategoryID3.Value = mg.CategoryID3.ToString();
                hidGoodsID.Value = mg.GoodsID.ToString();
                txtGoodsName.Value = mg.GoodsName;
                txtKeywords.Value = mg.Keywords;
                if (mg.SimilarNumber != 0 && mg.DifferenceKeywords != "")
                {
                    selSimilarNumber.SelectedIndex = 2;
                    hidSimilarNumber.Value = mg.SimilarNumber.ToString();
                    txtSimilarNumber.Value = mg.SimilarNumber.ToString();
                    txtSimilarNumber.Style.Value = "width:30px;";
                    txtDifferenceKeywords.Value = mg.DifferenceKeywords;
                    spDifferenceKeywords.Style.Value = "";
                    txtDifferenceKeywords.Style.Value = "";
                }
                txtMarketPrice.Value = mg.MarketPrice.ToString();
                txtPrice.Value = mg.Price.ToString();
                if (mg.DiscountPrice != 0) { txtDiscountPrice.Value = mg.DiscountPrice.ToString(); }
                if (mg.GoodsWeight != 0) { txtGoodsWeight.Value = mg.GoodsWeight.ToString(); }
                hidGoodsPicturePath.Value = mg.GoodsPicturePath;
                if (mg.Inventory.ToString() != "") { lblInventory.InnerText = mg.Inventory.ToString(); } else { lblInventory.InnerText = "0"; }
                txtSupplyLine.Value = mg.SupplyLine.ToString();
                selMerchantType.SelectedIndex = selMerchantType.Items.IndexOf(selMerchantType.Items.FindByValue(mg.MerchantType.ToString()));
                txtRemarks.Value = mg.Remarks.ToString().Replace("<br/>", "\r\n");
                txtWarmPrompt.Value = mg.WarmPrompt.ToString().Replace("<br/>", "\r\n");
                hidAddTime.Value = mg.AddTime.ToString();
                if (mg.IsBargain == true) { selIsBargain.SelectedIndex = selIsBargain.Items.IndexOf(selIsBargain.Items.FindByValue("1")); }
                else { selIsBargain.SelectedIndex = selIsBargain.Items.IndexOf(selIsBargain.Items.FindByValue("0")); }
                if (mg.IsCategoryPromotion == true) { selIsCategoryPromotion.SelectedIndex = selIsCategoryPromotion.Items.IndexOf(selIsCategoryPromotion.Items.FindByValue("1")); }
                else { selIsCategoryPromotion.SelectedIndex = selIsCategoryPromotion.Items.IndexOf(selIsCategoryPromotion.Items.FindByValue("0")); }
                if (mg.IsCategorySecondPromotion == true) { selIsCategorySecondPromotion.SelectedIndex = selIsCategorySecondPromotion.Items.IndexOf(selIsCategorySecondPromotion.Items.FindByValue("1")); }
                else { selIsCategorySecondPromotion.SelectedIndex = selIsCategorySecondPromotion.Items.IndexOf(selIsCategorySecondPromotion.Items.FindByValue("0")); }
                if (mg.IsNewRecommend == true) { selIsNewRecommend.SelectedIndex = selIsNewRecommend.Items.IndexOf(selIsNewRecommend.Items.FindByValue("1")); }
                else { selIsNewRecommend.SelectedIndex = selIsNewRecommend.Items.IndexOf(selIsNewRecommend.Items.FindByValue("0")); }
                if (mg.IsSeasonRecommend == true) { selIsSeasonRecommend.SelectedIndex = selIsSeasonRecommend.Items.IndexOf(selIsSeasonRecommend.Items.FindByValue("1")); }
                else { selIsSeasonRecommend.SelectedIndex = selIsSeasonRecommend.Items.IndexOf(selIsSeasonRecommend.Items.FindByValue("0")); }
                if (mg.IsGrounding == true) { selIsGrounding.SelectedIndex = selIsGrounding.Items.IndexOf(selIsGrounding.Items.FindByValue("1")); }
                else { selIsGrounding.SelectedIndex = selIsGrounding.Items.IndexOf(selIsGrounding.Items.FindByValue("0")); }
            }
        }
        /// <summary>
        /// 修改商品
        /// </summary>
        private void UpdateGoods()
        {
            Model.Goods md = new weipin.Model.Goods();
            string _sqlcategoriesgoods = Request.Form["hidCategories"].ToString();
            string _sqlattributes = Request.Form["hidAttributes"].ToString();
            Model.Goods mg = new weipin.Model.Goods();
            mg.GoodsID = Convert.ToInt32(Request.Form["hidGoodsID"].ToString());
            mg.GoodsName = Request.Form["txtGoodsName"].ToString();
            mg.Keywords = Request.Form["txtKeywords"].ToString();
            if (Request.Form["selSimilarNumber"].ToString() == "") { mg.SimilarNumber = -1; mg.DifferenceKeywords = Request.Form["txtDifferenceKeywords"].ToString(); }
            else if (Request.Form["selSimilarNumber"].ToString() == "1") { mg.SimilarNumber = 0; mg.DifferenceKeywords = Request.Form["txtDifferenceKeywords"].ToString().Replace("<", "＜").Replace("&", "＆"); }
            else { mg.SimilarNumber = Convert.ToInt32(Request.Form["txtSimilarNumber"].ToString()); mg.DifferenceKeywords = Request.Form["txtDifferenceKeywords"].ToString().Replace("<", "＜").Replace("&", "＆"); }
            mg.MarketPrice = Convert.ToDouble(Request.Form["txtMarketPrice"].ToString());
            mg.Price = Convert.ToDouble(Request.Form["txtPrice"].ToString());
            if (Request.Form["txtDiscountPrice"].ToString() != "") { mg.DiscountPrice = Convert.ToDouble(Request.Form["txtDiscountPrice"].ToString()); }
            if (Request.Form["txtGoodsWeight"].ToString() != "") { mg.GoodsWeight = Convert.ToDouble(Request.Form["txtGoodsWeight"].ToString()); }
            if (Request.Form["hidSizesXML"].ToString() == "") { mg.Inventory = Convert.ToInt32(Request.Form["txtInventory"].ToString()); } else { mg.Inventory = null; }
            if (Request.Form["hidSizesXML"].ToString() == "") { mg.SupplyLine = Convert.ToInt32(Request.Form["txtSupplyLine"].ToString()); } else { mg.SupplyLine = null; }
            mg.MerchantType = Convert.ToByte(Request.Form["selMerchantType"].ToString());
            mg.Remarks = Request.Form["txtRemarks"].ToString().Replace("\r\n", "<br/>");
            mg.WarmPrompt = Request.Form["txtWarmPrompt"].ToString().Replace("\r\n", "<br/>");
            if (Request.Form["selIsBargain"].ToString() == "1") { mg.IsBargain = true; } else { mg.IsBargain = false; }
            if (Request.Form["selIsCategoryPromotion"].ToString() == "1") { mg.IsCategoryPromotion = true; } else { mg.IsCategoryPromotion = false; }
            if (Request.Form["selIsCategorySecondPromotion"].ToString() == "1") { mg.IsCategorySecondPromotion = true; } else { mg.IsCategorySecondPromotion = false; }
            if (Request.Form["selIsNewRecommend"].ToString() == "1") { mg.IsNewRecommend = true; } else { mg.IsNewRecommend = false; }
            if (Request.Form["selIsSeasonRecommend"].ToString() == "1") { mg.IsSeasonRecommend = true; } else { mg.IsSeasonRecommend = false; }
            if (Request.Form["selIsGrounding"].ToString() == "1") { mg.IsGrounding = true; } else { mg.IsGrounding = false; }
            string _xmlPicPath = "<?xml version=\"1.0\" encoding=\"utf-8\"?><paths>";
            string _oldpath = Request.Form["hidOldPicPath"].ToString();
            string _newpath = Request.Form["hidPicPath"].ToString();
            if (_oldpath != _newpath)
            {
                string[] _stroldpath = _oldpath.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                string[] _strpath = _newpath.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                if (_stroldpath != null && _strpath != null)
                {
                    ArrayList _arroldpath = ArrayList.Adapter(_stroldpath);
                    ArrayList _arrpath = ArrayList.Adapter(_strpath);
                    for (int i = 0; i < _arroldpath.Count; i++)
                    {
                        if (!_arrpath.Contains(_arroldpath[i].ToString()))
                        {
                            if (i == 0)
                            {
                                //主图：删除所有缩微图
                                FileOperate.DeleteFile(_arroldpath[i].ToString().Insert(_arroldpath[i].ToString().LastIndexOf("."), "_60x60"));
                                FileOperate.DeleteFile(_arroldpath[i].ToString().Insert(_arroldpath[i].ToString().LastIndexOf("."), "_85x85"));
                                FileOperate.DeleteFile(_arroldpath[i].ToString().Insert(_arroldpath[i].ToString().LastIndexOf("."), "_170x170"));
                            }
                            //删除原图
                            FileOperate.DeleteFile(_arroldpath[i].ToString());
                        }
                    }
                    for (int j = 0; j < _arrpath.Count; j++)
                    {
                        string _targetfolderpath = "/file/images/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                        if (!Directory.Exists(Server.MapPath(_targetfolderpath))) { Directory.CreateDirectory(Server.MapPath(_targetfolderpath)); }
                        string _filename = Guid.NewGuid().ToString().Replace("-", "");
                        string _ext = _arrpath[j].ToString().Substring(_arrpath[j].ToString().LastIndexOf("."));
                        if (mg.GoodsPicturePath == null) { mg.GoodsPicturePath = _targetfolderpath + _filename + _ext; }
                        if (!_arroldpath.Contains(_arrpath[j].ToString()))
                        {
                            //新添加，移动
                            if (j == 0)
                            {
                                //创建缩微图
                                FileOperate.MakeThumbnail(_arrpath[j].ToString(), _targetfolderpath + _filename + "_60x60" + _ext, 60, 60, "W");
                                FileOperate.MakeThumbnail(_arrpath[j].ToString(), _targetfolderpath + _filename + "_85x85" + _ext, 85, 85, "W");
                                FileOperate.MakeThumbnail(_arrpath[j].ToString(), _targetfolderpath + _filename + "_170x170" + _ext, 170, 170, "W");
                            }
                            //移动原图
                            //FileOperate.FileMove(_arrpath[j].ToString(), _targetfolderpath, _filename + _ext);
                            FileOperate.MakeThumbnail(_arrpath[j].ToString(), _targetfolderpath + _filename + _ext, 500, 500, "W", Server.MapPath("~/img/logowatermark.png"), 9, 100, 2);//加水印
                            FileOperate.DeleteFile(_arrpath[j].ToString());
                        }
                        else
                        {
                            //旧图，移动
                            if (j == 0)
                            {
                                //if (_arrpath[j].ToString() == _arroldpath[0].ToString())
                                //{
                                //移动原图及缩微图
                                FileOperate.FileMove(_arrpath[j].ToString(), _targetfolderpath, _filename + _ext);
                                FileOperate.FileMove(_arrpath[j].ToString().Insert(_arrpath[j].ToString().LastIndexOf("."), "_60x60"), _targetfolderpath, _filename + "_60x60" + _ext);
                                FileOperate.FileMove(_arrpath[j].ToString().Insert(_arrpath[j].ToString().LastIndexOf("."), "_85x85"), _targetfolderpath, _filename + "_85x85" + _ext);
                                FileOperate.FileMove(_arrpath[j].ToString().Insert(_arrpath[j].ToString().LastIndexOf("."), "_170x170"), _targetfolderpath, _filename + "_170x170" + _ext);
                                //}
                                //else
                                //{
                                //    /*此处主要处理之前修改图片上传的情况：在删除第1个位置的图片后，以第1个位置以后(2/3/4/5)的位置中的某个位置图片为首张图片(主图)时，会进入此处代码。
                                //    由于500*500的源图片已经有水印，以上描述的操作会导致其他小的缩微图也存在水印，故在2012-10-8已修改为禁止修改图片时第1个位置的图片为空的情况，所以此处代码可以删除。
                                //    为保险起见，现(2012-10-8)先将此处代码注释，待长时间测试后，再进行最终删除(包括此判断:if (_arrpath[j].ToString() == _arroldpath[0].ToString()){}else{})*/
                                //    //移动原图及创建缩微图
                                //    FileOperate.MakeThumbnail(_arrpath[j].ToString(), _targetfolderpath + _filename + "_60x60" + _ext, 60, 60, "W");
                                //    FileOperate.MakeThumbnail(_arrpath[j].ToString(), _targetfolderpath + _filename + "_85x85" + _ext, 85, 85, "W");
                                //    FileOperate.MakeThumbnail(_arrpath[j].ToString(), _targetfolderpath + _filename + "_170x170" + _ext, 170, 170, "W");
                                //    //FileOperate.FileMove(_arrpath[j].ToString(), _targetfolderpath, _filename + _ext);
                                //    FileOperate.MakeThumbnail(_arrpath[j].ToString(), _targetfolderpath + _filename + _ext, 500, 500, "W", Server.MapPath("~/img/logowatermark.png"), 9, 100, 2);//加水印
                                //    FileOperate.DeleteFile(_arrpath[j].ToString());
                                //}
                            }
                            else
                            {
                                //移动
                                FileOperate.FileMove(_arrpath[j].ToString(), _targetfolderpath, _filename + _ext);
                            }
                        }
                        _xmlPicPath += "<path value=\"" + _targetfolderpath + _filename + _ext + "\"/>";
                    }
                    _xmlPicPath += "</paths>";
                }
            }
            BLL.Goods bg = new weipin.BLL.Goods();
            if (bg.UpdateGoods(mg, _sqlcategoriesgoods, _sqlattributes))
            {
                BLL.Sizes bs = new weipin.BLL.Sizes();
                if (Request.Form["hidSizesXML"].ToString() != "") { bs.CreateSizesXML(mg.GoodsID, Request.Form["hidSizesXML"].ToString()); }
                else { FileOperate.DeleteFile("~/xml/goods/goodssizes/" + mg.GoodsID.ToString() + ".xml"); }
                BLL.Goods_Attributes_Values bgav = new weipin.BLL.Goods_Attributes_Values();
                if (Request.Form["hidIsEditAttributes"].ToString() == "1")
                {
                    if (Request.Form["hidAttributesXML"].ToString() != "") { bgav.CreateGoodsAttributesValuesXML(mg.GoodsID, Request.Form["hidAttributesXML"].ToString()); }
                    else { FileOperate.DeleteFile("~/xml/goods/goodsattributesvalues/" + mg.GoodsID.ToString() + ".xml"); }
                }
                if (_oldpath != _newpath) { bg.CreateGoodsPicturesXML(mg.GoodsID, _xmlPicPath); }
                bg.CreateGoodsShow(mg.GoodsID, Request.Form["hidSimilarNumber"].ToString());
                bg.CreateHomepage();
                bg.CreateCategoryGoods(Convert.ToInt32(Request.Form["selCategory1"].ToString()));
                BLL.SE bse = new weipin.BLL.SE();
                if (mg.GoodsPicturePath == null) { mg.GoodsPicturePath = Request.Form["hidGoodsPicturePath"].ToString(); }
                mg.AddTime = Convert.ToDateTime(Request.Form["hidAddTime"].ToString());
                bse.UpdateSingleIndex(mg, false);
                Response.Write("<script>alert('修改成功！');location.href='GoodsShow.aspx?gid=" + mg.GoodsID + "';</script>");
            }
            else { Response.Write("<script>alert('修改失败！');location=location;</script>"); }
        }
    }
}