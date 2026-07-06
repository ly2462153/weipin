using System;
using System.Web;
using System.Text;
using System.IO;
using System.Collections;

namespace weipin.admin
{
    public partial class GoodsShow : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.Commonality.JudgeNumber(Request.Form["txtSearch"], 10))
            {
                BindGoods(Convert.ToInt32(Request.Form["txtSearch"].ToString()));
            }
            else if (Common.Commonality.JudgeNumber(Request.QueryString["gid"], 10))
            {
                BindGoods(Convert.ToInt32(Request.QueryString["gid"].ToString()));
            }
            else
            {
                divOperate.Visible = false;
                tbGoodsShow.Visible = false;
            }
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
                hidCategoryID1.Value = mg.CategoryID1.ToString();
                hidCategoryID3.Value = mg.CategoryID3.ToString();
                lblGoodsID.InnerText = mg.GoodsID.ToString();
                lblGoodsName.InnerText = mg.GoodsName;
                lblKeywords.InnerText = mg.Keywords;
                if (mg.SimilarNumber != 0 && mg.DifferenceKeywords != "")
                {
                    lblSimilarNumber.InnerText = mg.SimilarNumber.ToString();
                    lblDifferenceKeywords.InnerText = mg.DifferenceKeywords;
                }
                lblMarketPrice.InnerText = mg.MarketPrice.ToString();
                lblPrice.InnerText = mg.Price.ToString();
                if (mg.DiscountPrice != 0) { lblDiscountPrice.InnerText = mg.DiscountPrice.ToString(); }
                if (mg.GoodsWeight != 0) { lblGoodsWeight.InnerText = mg.GoodsWeight.ToString(); }
                if (mg.Inventory != null)
                {
                    lblInventory.InnerText = mg.Inventory.ToString();
                    lblSupplyLine.InnerText = mg.SupplyLine.ToString();
                }
                else { trInventory.Visible = false; }
                if (mg.MerchantType == 1) { lblMerchantType.InnerText = "自营"; } else { lblMerchantType.InnerText = "入驻商家"; }
                divRemarks.InnerHtml = mg.Remarks.ToString();
                divWarmPrompt.InnerHtml = mg.WarmPrompt.ToString();
                if (mg.IsBargain == true) { lblIsBargain.InnerText = "是"; } else { lblIsBargain.InnerText = "否"; }
                if (mg.IsCategoryPromotion == true) { lblIsCategoryPromotion.InnerText = "是"; } else { lblIsCategoryPromotion.InnerText = "否"; }
                if (mg.IsCategorySecondPromotion == true) { lblIsCategorySecondPromotion.InnerText = "是"; } else { lblIsCategorySecondPromotion.InnerText = "否"; }
                if (mg.IsNewRecommend == true) { lblIsNewRecommend.InnerText = "是"; } else { lblIsNewRecommend.InnerText = "否"; }
                if (mg.IsSeasonRecommend == true) { lblIsSeasonRecommend.InnerText = "是"; } else { lblIsSeasonRecommend.InnerText = "否"; }
                if (mg.IsGrounding == true) { lblIsGrounding.InnerText = "是"; } else { lblIsGrounding.InnerText = "否"; }
            }
            else
            {
                divOperate.Visible = false;
                tbGoodsShow.Visible = false;
            }
        }
    }
}