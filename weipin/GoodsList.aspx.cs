using System;
using System.Web.UI.WebControls;
using weipin.Common;
using weipin.Model;
using System.Configuration;
using System.Xml;

namespace weipin
{
    public partial class GoodsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Commonality.JudgeNumber(Request.QueryString["cid2"], 10))
            {
                BindGoodsList(Request.QueryString["cid2"].ToString(), Request.QueryString["p"], Request.QueryString["sp"], Request.QueryString["ep"], Request.QueryString["st"]);
                BindTitle(Request.QueryString["cid2"].ToString(), 2);
            }
            else if (Commonality.JudgeNumber(Request.QueryString["cid3"], 10))
            {
                BindGoodsList(Request.QueryString["cid3"].ToString(), Request.QueryString["p"], Request.QueryString["sp"], Request.QueryString["ep"], Request.QueryString["atb"], Request.QueryString["st"]);
                BindTitle(Request.QueryString["cid3"].ToString(), 3);
            }
            else { divGoodsList.Visible = false; }
        }
        /// <summary>
        /// 绑定列表(二级类别)
        /// </summary>
        /// <param name="cid2">二级类别</param>
        /// <param name="nowpage">当前页</param>
        /// <param name="sp">开始价格</param>
        /// <param name="ep">结束价格</param>
        /// <param name="st">排序编号</param>
        private void BindGoodsList(string cid2, string nowpage, string sp, string ep, string st)
        {
            string _param = string.Empty;
            hidCategoryID2.Value = cid2.ToString();
            _param += "&cid2=" + cid2.ToString();
            string _sqlpricecondition = string.Empty;
            if (Commonality.JudgeFloat(sp, 6))
            {
                _sqlpricecondition += " and case when DiscountPrice is null then price else DiscountPrice end>=" + sp;
                _param += "&sp=" + sp;
                txtStartPrice.Value = sp;
            }
            if (Commonality.JudgeFloat(ep, 6))
            {
                _sqlpricecondition += " and case when DiscountPrice is null then price else DiscountPrice end<=" + ep;
                _param += "&ep=" + ep;
                txtEndPrice.Value = ep;
            }
            string _sqlsort = string.Empty;
            if (Commonality.JudgeNumber(st, 3))
            {
                switch (st)
                {
                    case "1": _sqlsort = " SalesVolume desc"; break;
                    case "2": _sqlsort = " AddTime desc"; break;
                    case "3": _sqlsort = " case when DiscountPrice is null then price else DiscountPrice end"; break;
                    case "4": _sqlsort = " case when DiscountPrice is null then price else DiscountPrice end desc"; break;
                }
                hidSort.Value = st;
            }
            else
            {
                _sqlsort = " SalesVolume desc";
                hidSort.Value = "1";
            }
            _param += "&st=" + hidSort.Value;
            if (!Commonality.JudgeNumber(nowpage, 5)) { nowpage = "1"; }
            BLL.Goods bg = new weipin.BLL.Goods();
            int _perpage = Convert.ToInt16(ConfigurationManager.AppSettings["GoodsListCount"].ToString());
            DataList<Model.Goods> dmg = bg.SelectGoodsByConditionOfPaging(Convert.ToInt16(nowpage), _perpage, cid2, _sqlpricecondition, _sqlsort);
            if (dmg != null && dmg.Rows.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < dmg.Rows.Count; i++)
                {
                    string _path = dmg.Rows[i].GoodsPicturePath;
                    sb.Append("<div class=\"sec_cplsit\">");
                    if (dmg.Rows[i].DiscountPrice != 0) { sb.Append("<div class=\"zhek\">" + dmg.Rows[i].DiscountPrice + "</div>"); }
                    sb.Append("<ul><li><a href=\"/page/" + dmg.Rows[i].GoodsID / 1000 + "/goodsshow_" + dmg.Rows[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + dmg.Rows[i].GoodsName + "\"><img src=\"" + _path.Insert(_path.LastIndexOf("."), "_170x170") + "\"/></a></li>");
                    sb.Append("<li class=\"cp_wz\"><a href=\"/page/" + dmg.Rows[i].GoodsID / 1000 + "/goodsshow_" + dmg.Rows[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + dmg.Rows[i].GoodsName + "\">" + Commonality.CutString(dmg.Rows[i].GoodsName, 28) + "</a></li>");
                    sb.Append("<li>市场价：￥<span class=\"price_o\">" + dmg.Rows[i].MarketPrice.ToString() + "</span><span class=\"price_n\">微品价：￥" + dmg.Rows[i].Price.ToString() + "</span></li></ul></div>");
                }
                sb.Append("<div class=\"clear\"></div>");
                divGoodsList.InnerHtml = sb.ToString();
                ulPage.InnerHtml = "<li class=\"pad\">共<span class=\"red\">" + dmg.Total + "</span>个商品</li><li class=\"pad\">" + nowpage + "/" + Pagination.CountMaxPage(dmg.Total, _perpage) + "</li>" + Pagination.PagingOnlyFirstLast(dmg.Total, Convert.ToInt16(nowpage), _perpage, "GoodsList.aspx?p=", 11, _param);
                divPaging.InnerHtml = Pagination.Paging(dmg.Total, Convert.ToInt16(nowpage), _perpage, "GoodsList.aspx?p=", 11, _param);
            }
            else { divGoodsList.InnerHtml = "抱歉，没有找到符合条件的商品"; }
        }
        /// <summary>
        /// 绑定列表(三级类别)
        /// </summary>
        /// <param name="cid3">三级类别</param>
        /// <param name="nowpage">当前页数</param>
        /// <param name="sp">开始价格</param>
        /// <param name="ep">结束价格</param>
        /// <param name="atb">选中的属性值拼接字符串</param>
        /// <param name="st">排序编号</param>
        private void BindGoodsList(string cid3, string nowpage, string sp, string ep, string atb, string st)
        {
            string _param = string.Empty;
            hidCategoryID3.Value = cid3.ToString();
            _param += "&cid3=" + cid3.ToString();
            string _sqlpricecondition = string.Empty;
            if (Commonality.JudgeFloat(sp, 6))
            {
                _sqlpricecondition += " and  case when DiscountPrice is null then price else DiscountPrice end>=" + sp;
                _param += "&sp=" + sp;
                txtStartPrice.Value = sp;
            }
            if (Commonality.JudgeFloat(ep, 6))
            {
                _sqlpricecondition += " and  case when DiscountPrice is null then price else DiscountPrice end<=" + ep;
                _param += "&ep=" + ep;
                txtEndPrice.Value = ep;
            }
            string _sqlcondition = string.Empty;
            int _conditioncount = 0;
            if (!string.IsNullOrEmpty(atb))
            {
                string[] _arr = atb.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //System.Configuration.ConfigurationManager.AppSettings["AttributeCount"].ToString()需要在添加属性时限定每个商品最多添加的属性个数
                if (_arr != null && _arr.Length < Convert.ToByte(ConfigurationManager.AppSettings["AttributeCount"].ToString()))
                {
                    atb = "";
                    for (int i = 0; i < _arr.Length; i++)
                    {
                        if (Commonality.JudgeNumber(_arr[i], 10))
                        {
                            atb += "-" + _arr[i];
                            if (_sqlcondition == "") { _sqlcondition += "ValueID=" + _arr[i]; }
                            else { _sqlcondition += " or ValueID=" + _arr[i]; }
                            _conditioncount++;
                        }
                    }
                    if (atb != "")
                    {
                        hidAttributes.Value = atb.Substring(1);
                        _param += "&atb=" + atb.Substring(1);
                    }
                }
            }
            string _sqlsort = string.Empty;
            if (Commonality.JudgeNumber(st, 3))
            {
                switch (st)
                {
                    case "1": _sqlsort = " SalesVolume desc"; break;
                    case "2": _sqlsort = " AddTime desc"; break;
                    case "3": _sqlsort = " case when DiscountPrice is null then price else DiscountPrice end"; break;
                    case "4": _sqlsort = " case when DiscountPrice is null then price else DiscountPrice end desc"; break;
                }
                hidSort.Value = st;
            }
            else
            {
                _sqlsort = " SalesVolume desc";
                hidSort.Value = "1";
            }
            _param += "&st=" + hidSort.Value;
            if (!Commonality.JudgeNumber(nowpage, 5)) { nowpage = "1"; }
            BLL.Goods bg = new weipin.BLL.Goods();
            int _perpage = Convert.ToInt16(ConfigurationManager.AppSettings["GoodsListCount"].ToString());
            DataList<Model.Goods> dmg = bg.SelectGoodsByConditionOfPaging(Convert.ToInt16(nowpage), _perpage, cid3, _sqlpricecondition, _sqlcondition, _sqlsort, _conditioncount.ToString());
            if (dmg != null && dmg.Rows.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < dmg.Rows.Count; i++)
                {
                    string _path = dmg.Rows[i].GoodsPicturePath;
                    sb.Append("<div class=\"sec_cplsit\">");
                    if (dmg.Rows[i].DiscountPrice != 0) { sb.Append("<div class=\"zhek\">" + dmg.Rows[i].DiscountPrice + "</div>"); }
                    sb.Append("<ul><li><a href=\"/page/" + dmg.Rows[i].GoodsID / 1000 + "/goodsshow_" + dmg.Rows[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + dmg.Rows[i].GoodsName + "\"><img src=\"" + _path.Insert(_path.LastIndexOf("."), "_170x170") + "\"/></a></li>");
                    sb.Append("<li class=\"cp_wz\"><a href=\"/page/" + dmg.Rows[i].GoodsID / 1000 + "/goodsshow_" + dmg.Rows[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + dmg.Rows[i].GoodsName + "\">" + Commonality.CutString(dmg.Rows[i].GoodsName, 28) + "</a></li>");
                    sb.Append("<li>市场价：￥<span class=\"price_o\">" + dmg.Rows[i].MarketPrice.ToString() + "</span><span class=\"price_n\">微品价：￥" + dmg.Rows[i].Price.ToString() + "</span></li></ul></div>");
                }
                sb.Append("<div class=\"clear\"></div>");
                divGoodsList.InnerHtml = sb.ToString();
                ulPage.InnerHtml = "<li class=\"pad\">共<span class=\"red\">" + dmg.Total + "</span>个商品</li><li class=\"pad\">" + nowpage + "/" + Pagination.CountMaxPage(dmg.Total, _perpage) + "</li>" + Pagination.PagingOnlyFirstLast(dmg.Total, Convert.ToInt16(nowpage), _perpage, "GoodsList.aspx?p=", 11, _param);
                divPaging.InnerHtml = Pagination.Paging(dmg.Total, Convert.ToInt16(nowpage), _perpage, "GoodsList.aspx?p=", 11, _param);
            }
            else { divGoodsList.InnerHtml = "抱歉，没有找到符合条件的商品"; }
        }
        /// <summary>
        /// 绑定页面title
        /// <param name="categoryid">类别ID</param>
        /// <param name="categorylevel">类别级别(2:二级类别;3:三级类别)</param>
        /// </summary>
        private void BindTitle(string categoryid, int categorylevel)
        {
            string _path = Server.MapPath("~/xml/categories.xml");
            if (System.IO.File.Exists(_path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_path);
                XmlNodeList nodelist;
                if (categorylevel == 2) { nodelist = doc.DocumentElement.SelectNodes("descendant::category2"); }
                else { nodelist = doc.DocumentElement.SelectNodes("descendant::category3"); }
                if (nodelist.Count > 0)
                {
                    string _titlename = string.Empty;
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        if (nodelist[i].Attributes["value"].Value == categoryid.ToString())
                        {
                            _titlename = nodelist[i].Attributes["name"].Value + "_" + nodelist[i].ParentNode.Attributes["name"].Value;
                            if (nodelist[i].ParentNode.ParentNode.Name != "categories") { _titlename += "_" + nodelist[i].ParentNode.ParentNode.Attributes["name"].Value; }
                            break;
                        }
                    }
                    ttName.InnerText = _titlename + "_微品网上商城_心动小商品_小商品网上商城_小礼品网上商城";
                }
            }
        }
    }
}