using System;
using System.Collections.Generic;

namespace weipin.admin
{
    public partial class GoodsBatchUpdate : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGoodsIDMuster();
        }
        /// <summary>
        /// 查询商品集合
        /// </summary>
        private void BindGoodsIDMuster()
        {
            BLL.Goods bg = new weipin.BLL.Goods();
            List<Model.Goods> lmg = bg.SelectGoodsIDMuster();
            if (lmg != null && lmg.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < lmg.Count; i++) { sb.Append("|" + lmg[i].GoodsID); }
                spTotal.InnerText = lmg.Count.ToString();
                hidGoodsIDMuster.Value = sb.ToString().Substring(1);
            }
        }
    }
}