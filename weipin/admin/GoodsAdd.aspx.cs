using System;
using System.Web;
using System.Text;
using System.IO;
using weipin.Common;

namespace weipin.admin
{
    public partial class GoodsAdd : Common.BasePageAdmin
    {
        #region 登录判断
        protected override void OnLoad(EventArgs e)
        {
            //判断Cookie是否存在，存在->加载页面，不存在->跳转到登录页面
            HttpCookie hck = GetCookieOfLoginAdmin();
            Model.Admins ed = GetSessionOfLoginAdmin();
            if (hck != null || ed != null)
            {
                if (ed == null)
                {
                    BLL.Admins ba = new BLL.Admins();
                    string res = ba.CheckUser(hck.Values[0].ToString(), hck.Values[1].ToString(), false);
                    if (res != "1")
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
            }
            base.OnLoad(e);
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["selCategory3"] != null) { InsertGoods(); }
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        private void InsertGoods()
        {
            Model.Goods md = new weipin.Model.Goods();
            string _sqlcategoriesgoods = Request.Form["hidCategories"].ToString();
            string _sqlattributes = Request.Form["hidAttributes"].ToString();
            Model.Goods mg = new weipin.Model.Goods();
            mg.GoodsName = Request.Form["txtGoodsName"].ToString();
            mg.Keywords = Request.Form["txtKeywords"].ToString();
            if (Request.Form["selSimilarNumber"].ToString() == "") { mg.SimilarNumber = -1; mg.DifferenceKeywords = Request.Form["txtDifferenceKeywords"].ToString(); }
            else if (Request.Form["selSimilarNumber"].ToString() == "1") { mg.SimilarNumber = 0; mg.DifferenceKeywords = Request.Form["txtDifferenceKeywords"].ToString().Replace("<", "＜").Replace("&", "＆"); }
            else { mg.SimilarNumber = Convert.ToInt32(Request.Form["txtSimilarNumber"].ToString()); mg.DifferenceKeywords = Request.Form["txtDifferenceKeywords"].ToString().Replace("<", "＜").Replace("&", "＆"); }
            mg.MarketPrice = Convert.ToDouble(Request.Form["txtMarketPrice"].ToString());
            mg.Price = Convert.ToDouble(Request.Form["txtPrice"].ToString());
            if (Request.Form["txtDiscountPrice"].ToString() != "") { mg.DiscountPrice = Convert.ToDouble(Request.Form["txtDiscountPrice"].ToString()); }
            if (Request.Form["txtGoodsWeight"].ToString() != "") { mg.GoodsWeight = Convert.ToDouble(Request.Form["txtGoodsWeight"].ToString()); }
            string[] arrpath = Request.Form["hidPicPath"].ToString().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            string _targetfolderpath = "/file/images/" + DateTime.Now.ToString("yyyyMMdd") + "/";
            if (!Directory.Exists(Server.MapPath(_targetfolderpath))) { Directory.CreateDirectory(Server.MapPath(_targetfolderpath)); }
            string _xmlPicPath = "<?xml version=\"1.0\" encoding=\"utf-8\"?><paths>";
            for (int i = 0; i < arrpath.Length; i++)
            {
                string _filename = Guid.NewGuid().ToString().Replace("-", "");
                string _ext = arrpath[i].ToString().Substring(arrpath[i].ToString().LastIndexOf("."));
                if (i == 0)
                {
                    mg.GoodsPicturePath = _targetfolderpath + _filename + _ext;
                    FileOperate.MakeThumbnail(arrpath[i].ToString(), _targetfolderpath + _filename + "_60x60" + _ext, 60, 60, "W");
                    FileOperate.MakeThumbnail(arrpath[i].ToString(), _targetfolderpath + _filename + "_85x85" + _ext, 85, 85, "W");
                    FileOperate.MakeThumbnail(arrpath[i].ToString(), _targetfolderpath + _filename + "_170x170" + _ext, 170, 170, "W");
                }
                //FileOperate.FileMove(arrpath[i].ToString(), _targetfolderpath, _filename + _ext);
                FileOperate.MakeThumbnail(arrpath[i].ToString(), _targetfolderpath + _filename + _ext, 500, 500, "W", Server.MapPath("~/img/logowatermark.png"), 9, 100, 2);//加水印
                FileOperate.DeleteFile(arrpath[i].ToString());
                _xmlPicPath += "<path value=\"" + _targetfolderpath + _filename + _ext + "\"/>";
            }
            _xmlPicPath += "</paths>";
            if (Request.Form["hidSizesXML"].ToString() == "")
            {
                mg.Inventory = Convert.ToInt32(Request.Form["txtInventory"].ToString());
                mg.SupplyLine = Convert.ToInt32(Request.Form["txtSupplyLine"].ToString());
            }
            mg.MerchantType = Convert.ToByte(Request.Form["selMerchantType"].ToString());
            mg.Remarks = Request.Form["txtRemarks"].ToString().Replace("\r\n", "<br/>");
            mg.WarmPrompt = Request.Form["txtWarmPrompt"].ToString().Replace("\r\n", "<br/>");
            if (Request.Form["selIsBargain"].ToString() == "1") { mg.IsBargain = true; } else { mg.IsBargain = false; }
            if (Request.Form["selIsCategoryPromotion"].ToString() == "1") { mg.IsCategoryPromotion = true; } else { mg.IsCategoryPromotion = false; }
            if (Request.Form["selIsCategorySecondPromotion"].ToString() == "1") { mg.IsCategorySecondPromotion = true; } else { mg.IsCategorySecondPromotion = false; }
            if (Request.Form["selIsNewRecommend"].ToString() == "1") { mg.IsNewRecommend = true; } else { mg.IsNewRecommend = false; }
            if (Request.Form["selIsSeasonRecommend"].ToString() == "1") { mg.IsSeasonRecommend = true; } else { mg.IsSeasonRecommend = false; }
            if (Request.Form["selIsGrounding"].ToString() == "1") { mg.IsGrounding = true; } else { mg.IsGrounding = false; }
            BLL.Goods bg = new weipin.BLL.Goods();
            int _goodsid = bg.InsertGoods(mg, _sqlcategoriesgoods, _sqlattributes);
            if (_goodsid > 0)
            {
                BLL.Sizes bs = new weipin.BLL.Sizes();
                bs.CreateSizesXML(_goodsid, Request.Form["hidSizesXML"].ToString());
                bg.CreateGoodsPicturesXML(_goodsid, _xmlPicPath);
                BLL.Goods_Attributes_Values bgav = new weipin.BLL.Goods_Attributes_Values();
                bgav.CreateGoodsAttributesValuesXML(_goodsid, Request.Form["hidAttributesXML"].ToString());
                bg.CreateGoodsShow(_goodsid, "");
                bg.CreateHomepage();
                bg.CreateCategoryGoods(Convert.ToInt32(Request.Form["selCategory1"].ToString()));
                BLL.SE bse = new weipin.BLL.SE();
                mg.GoodsID = _goodsid;
                mg.AddTime = DateTime.Now;
                bse.CreateSingleIndex(mg);
                Response.Write("<script>alert('添加成功！');location.href='GoodsShow.aspx?gid=" + _goodsid + "';</script>");
            }
            else { Response.Write("<script>alert('添加失败！');location=location;</script>"); }
        }
    }
}