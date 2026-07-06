using System;
using System.Data;
using weipin.Model;

namespace weipin.admin
{
    public partial class GoodsSupplyList : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.Commonality.JudgeNumber(Request.QueryString["p"], 5))
            {
                BindGoodsSupplyList(Convert.ToInt16(Request.QueryString["p"].ToString()));
            }
            else
            {
                BindGoodsSupplyList(1);
            }
        }
        /// <summary>
        /// 绑定商品库存补给线(分页)
        /// <param name="_nowpage">当前页</param>
        /// </summary>
        private void BindGoodsSupplyList(int _nowpage)
        {
            BLL.Goods bg = new weipin.BLL.Goods();
            int _perpage = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["ItemOfPage"].ToString());
            DataList<Model.Goods> dmg = bg.SelectGoodsSupplyOfPaging(_nowpage, _perpage);
            if (dmg != null && dmg.Total > 0)
            {
                string _param = string.Empty;
                int _total = dmg.Total;
                int _maxpage = Common.Pagination.CountMaxPage(_total, _perpage);
                if (_nowpage <= _maxpage)
                {
                    rptGoodsSupplyList.DataSource = dmg.Rows;
                    rptGoodsSupplyList.DataBind();
                    divPaging.InnerHtml = Common.Pagination.PagingFirstLast(_total, _nowpage, _perpage, "GoodsSupplyList.aspx?p=", 11, _param);
                }
                else
                {
                    Response.Write("<script>location.href='GoodsSupplyList.aspx?p=" + _maxpage + _param + "';</script>");
                }
            }
            else
            {
                this.divPaging.Visible = false;
            }
        }
    }
}