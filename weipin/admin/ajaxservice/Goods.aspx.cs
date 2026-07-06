using System;

namespace weipin.admin.ajaxservice
{
    public partial class Goods : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string value = string.Empty;
                string strParam = Request.Form["ptype"];
                if (strParam != null)
                {
                    switch (strParam)
                    {
                        case "SelectGoodsPartByID":
                            value = SelectGoodsPartByID();
                            break;
                        case "DeleteGoodsByGoodsID":
                            value = DeleteGoodsByGoodsID();
                            break;
                        case "CreateGoodsShow":
                            value = CreateGoodsShow();
                            break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 查看商品名称/单价等部分信息
        /// </summary>
        /// <returns></returns>
        private string SelectGoodsPartByID()
        {
            string _res = string.Empty;
            int _gid = Convert.ToInt32(Request.Form["gid"].ToString());
            BLL.Goods bg = new weipin.BLL.Goods();
            Model.Goods mg = bg.SelectGoodsPartByID(_gid);
            if (mg.GoodsID != 0)
            {
                _res = "<xml><Goods>";
                _res += "<Good><GoodsID>" + mg.GoodsID.ToString() + "</GoodsID><GoodsName>" + mg.GoodsName + "</GoodsName>";
                if (mg.DiscountPrice != 0) { _res += "<Price>" + mg.DiscountPrice.ToString() + "</Price>"; }
                else { _res += "<Price>" + mg.Price.ToString() + "</Price>"; }
                _res += "</Good></Goods></xml>";
            }
            return _res;
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <returns></returns>
        private string DeleteGoodsByGoodsID()
        {
            string _res = string.Empty;
            int _gid = Convert.ToInt32(Request.Form["gid"].ToString());
            string _oldsn = Request.Form["oldsn"].ToString();
            int _categoryid1 = Convert.ToInt32(Request.Form["cid1"].ToString());
            BLL.Goods bg = new weipin.BLL.Goods();
            if (bg.DeleteGoodsByID(_gid))
            {
                //删除当前商品的详情页
                Common.FileOperate.DeleteFile("~/page/" + _gid / 1000 + "/goodsshow_" + _gid + ".html");
                //删除同款不同颜色的相应XML
                Model.Goods mg = new weipin.Model.Goods();
                mg.GoodsID = _gid;
                mg.SimilarNumber = 0;
                bg.CreateGoodsDifference(mg, _oldsn);
                bg.CreateHomepage();
                bg.CreateCategoryGoods(_categoryid1);
                BLL.SE bse = new weipin.BLL.SE();
                bse.DeleteSingleIndex(_gid, false);
                _res = "1";
            }
            else { _res = "0"; }
            return _res;
        }
        /// <summary>
        /// 生成商品详情页面
        /// </summary>
        /// <returns></returns>
        public string CreateGoodsShow()
        {
            int _gid = Convert.ToInt32(Request.Form["gid"].ToString());
            BLL.Goods bg = new weipin.BLL.Goods();
            try
            {
                bg.CreateGoodsShow(_gid, "");
                return "True";
            }
            catch { return _gid.ToString(); }
        }
    }
}