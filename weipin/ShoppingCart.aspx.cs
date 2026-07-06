using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using weipin.Common;

namespace weipin
{
    public partial class ShoppingCart : Common.BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            if (GetSessionOfLoginUser() == null)
            {
                if (GetCookieOfLoginUser() != null)
                {
                    BLL.Users bu = new BLL.Users();
                    if (bu.CheckUser(GetCookieOfLoginUser().Values["loginid"].ToString(), GetCookieOfLoginUser().Values["loginpsw"].ToString(), false) == "1") { divLoginMessage.InnerHtml = "<a href=\"/myhome/MyOrdersList.aspx\" style=\"color:#ff6600;\">" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a>&nbsp;&nbsp;<a href=\"/Logout.aspx?logout=1\">[退出]</a>"; }
                    else { divLoginMessage.InnerHtml = "<a href=\"/Login.aspx?returnurl=" + Request.Url.ToString() + "\">[登录]</a>&nbsp;&nbsp;<a href=\"/Register.aspx?returnurl=" + Request.Url.ToString() + "\">[注册]</a>"; }
                }
                else { divLoginMessage.InnerHtml = "<a href=\"/Login.aspx?returnurl=" + Request.Url.ToString() + "\">[登录]</a>&nbsp;&nbsp;<a href=\"/Register.aspx?returnurl=" + Request.Url.ToString() + "\">[注册]</a>"; }
            }
            else { divLoginMessage.InnerHtml = "<a href=\"/myhome/MyOrdersList.aspx\" style=\"color:#ff6600;\">" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a>&nbsp;&nbsp;<a href=\"/Logout.aspx?logout=1\">[退出]</a>"; }
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["MyShoppingCart"] != null && Request.Cookies["MyShoppingCart"].Value != "")
            {
                string _myshoppingcart = Server.UrlDecode(Request.Cookies["MyShoppingCart"].Value);
                string[] _arr = _myshoppingcart.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                string _condition = string.Empty;
                int _maxcount = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["ShoppingCartGoodsMaxCount"].ToString());
                if (_arr.Length > _maxcount)
                {
                    for (int i = 0; i < _maxcount; i++)
                    {
                        if (Commonality.JudgeNumber(_arr[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0], 10))
                        {
                            _condition += "," + _arr[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < _arr.Length; i++)
                    {
                        if (Commonality.JudgeNumber(_arr[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0], 10))
                        {
                            _condition += "," + _arr[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                        }
                    }
                }
                string _sql = string.Empty;
                if (_condition != "")
                {
                    _condition = _condition.Substring(1);
                    _sql = " union all select GoodsID,GoodsName,MarketPrice,Price,DiscountPrice,GoodsPicturePath from goods where goodsid in (" + _condition + ") and isdeleted=0 and IsGrounding=1";
                }
                BLL.Goods bg = new weipin.BLL.Goods();
                List<Model.Goods> lmg = bg.SelectGoodsShoppingCart(_sql);
                if (lmg != null && lmg.Count >= 6)
                {
                    StringBuilder sbOtherChoose = new StringBuilder();
                    for (int i = 0; i < 6; i++)
                    {
                        string _path = lmg[i].GoodsPicturePath;
                        sbOtherChoose.Append("<div class=\"ordr_list\"><ul><li><a href=\"/page/" + lmg[i].GoodsID / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + lmg[i].GoodsName + "\">");
                        sbOtherChoose.Append("<img class=\"ordr_listb\" src=\"" + _path.Insert(_path.LastIndexOf("."), "_170x170") + "\" alt=\"" + lmg[i].GoodsID.ToString() + "\"/></a></li><li style=\"text-align:left;padding-left:5px;height:50px;\">");
                        sbOtherChoose.Append("<a href=\"/page/" + lmg[i].GoodsID / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + lmg[i].GoodsName + "\">" + Commonality.CutString(lmg[i].GoodsName, 20) + "</a></li>");
                        sbOtherChoose.Append("<li class=\"gray\">市场价：￥" + lmg[i].MarketPrice.ToString() + "</li><li class=\"red\">售价：￥");
                        if (lmg[i].DiscountPrice != 0)
                        {
                            sbOtherChoose.Append("<span>" + lmg[i].DiscountPrice + "</span>");
                        }
                        else
                        {
                            sbOtherChoose.Append("<span>" + lmg[i].Price + "</span>");
                        }
                        sbOtherChoose.Append("</li><li><a href=\"/page/" + lmg[i].GoodsID / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" target=\"_blank\"><img src=\"img/but_djckxq.gif\" width=\"81\" height=\"21\" border=\"0\"/></a></li></ul></div>");
                    }
                    divOtherChoose.InnerHtml = sbOtherChoose.ToString() + "<div class=\"clear\"></div>";
                    StringBuilder sbShoppingCart = new StringBuilder();
                    string _cookie = string.Empty;
                    if (lmg.Count > 6)
                    {
                        sbShoppingCart.Append("<table class=\"ordr_tab1\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td width=\"10%\" class=\"ordr_tabhead\">商品</td><td width=\"18%\" class=\"ordr_tabhead\">编号</td><td width=\"20%\" class=\"ordr_tabhead\">名称</td><td width=\"12%\" class=\"ordr_tabhead\">单价</td><td width=\"12%\" class=\"ordr_tabhead\">数量</td><td width=\"12%\" class=\"ordr_tabhead\">删除</td></tr>");
                        for (int j = 0; j < _arr.Length; j++)
                        {
                            if (Commonality.JudgeNumber(_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0], 10))
                            {
                                List<Model.Goods> lmgsingle = lmg.FindAll(delegate(Model.Goods mg) { return mg.GoodsID == Convert.ToInt32(_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0]); });
                                if (lmgsingle != null && lmgsingle.Count > 0)
                                {
                                    int _sid = 0;
                                    string _path = lmgsingle[0].GoodsPicturePath;
                                    sbShoppingCart.Append("<tr><td><a href=\"/page/" + lmgsingle[0].GoodsID / 1000 + "/goodsshow_" + lmgsingle[0].GoodsID.ToString() + ".html\" target=\"_blank\"><img src=\"" + _path.Insert(_path.LastIndexOf("."), "_60x60") + "\"/></a></td>");
                                    if (_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Length > 3 && Commonality.JudgeNumber(_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[3], 10))
                                    {
                                        _sid = Convert.ToInt32(_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[3].ToString());
                                        sbShoppingCart.Append("<td id=\"td" + lmgsingle[0].GoodsID.ToString() + "_" + _sid + "\" class=\"goods_id\">" + lmgsingle[0].GoodsID.ToString() + "<input type=\"hidden\" value=\"" + _sid + "\"/>");
                                    }
                                    else
                                    {
                                        sbShoppingCart.Append("<td id=\"td" + lmgsingle[0].GoodsID.ToString() + "\" class=\"goods_id\">" + lmgsingle[0].GoodsID.ToString());
                                    }
                                    sbShoppingCart.Append("</td><td style=\"text-align:left;\"><a href=\"/page/" + lmgsingle[0].GoodsID / 1000 + "/goodsshow_" + lmgsingle[0].GoodsID.ToString() + ".html\" target=\"_blank\">" + lmgsingle[0].GoodsName + "</a></td><td><span class=\"red\">￥");
                                    double _price = 0;
                                    if (lmgsingle[0].DiscountPrice != 0)
                                    {
                                        sbShoppingCart.Append(lmgsingle[0].DiscountPrice);
                                        _price = lmgsingle[0].DiscountPrice;
                                    }
                                    else
                                    {
                                        sbShoppingCart.Append(lmgsingle[0].Price);
                                        _price = lmgsingle[0].Price;
                                    }
                                    sbShoppingCart.Append("</span></td><td><div class=\"choose\"><ul><li class=\"shop_jian\"><img src=\"img/jian.gif\"/></li><li><input type=\"text\" value=\"");
                                    byte _count = 0;
                                    if (Commonality.JudgeNumber(_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1], 3))
                                    {
                                        _count = Convert.ToByte(_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1]);
                                        sbShoppingCart.Append(_count);
                                    }
                                    else
                                    {
                                        _count = 1;
                                        sbShoppingCart.Append(1);
                                    }
                                    sbShoppingCart.Append("\" class=\"shop_count\" maxlength=\"2\"/></li><li class=\"shop_jia\"><img src=\"img/jia.gif\"/></li></ul><div class=\"clear\"></div></div></td><td><a href=\"#\" onclick=\"DeleteGoods(this,'" + lmgsingle[0].GoodsID.ToString() + "');return false;\">删除</a></td></tr>");
                                    _cookie += "|" + lmgsingle[0].GoodsID.ToString() + "," + _count + "," + _price;
                                    if (_sid != 0) { _cookie += "," + _sid.ToString(); } else { _cookie += ","; }
                                }
                            }
                        }
                        sbShoppingCart.Append("<tr id=\"tdAmount\"><td colspan=\"8\" style=\"text-align:right;\" class=\"f14\">产品数量总计：<span id=\"spTotal\"></span>件  产品金额总计：<span id=\"spAmount\" class=\"red\"></span></td></tr>");
                        sbShoppingCart.Append("<tr><td colspan=\"8\" align=\"right\" class=\"ordr_tabbut\"><div class=\"l\" style=\"margin-top:8px;\"><img align=\"absmiddle\" src=\"img/ico_c.gif\"/><a href=\"#\" onclick=\"ClearShopping();return false;\">清空购物车</a></div>");
                        sbShoppingCart.Append("<div class=\"but_jies\"><a href=\"#\" onclick=\"GoPay();return false;\"><img src=\"img/but_qjs.gif\" width=\"96\" height=\"34\" border=\"0\" /></a></div><div class=\"but_jies\"><a href=\"/index.html\"><img src=\"img/but_jxgw.gif\" width=\"96\" height=\"34\" border=\"0\"/></a></div></td></tr></table>");
                    }
                    else
                    {
                        sbShoppingCart.Append("<div style=\"font-size:14px;text-align:center;color:#808080;font-weight:bold;padding:30px;\">您的购物车中没有商品，请先进行<a href=\"index.html\" style=\"color:#cc0001;text-decoration:underline;\">选购>></a></div>");
                    }
                    if (_cookie != "") { _cookie = _cookie.Substring(1); }
                    HttpCookie _ckmyshoppingcart = new HttpCookie("MyShoppingCart", _cookie);
                    _ckmyshoppingcart.Expires = DateTime.Now.AddDays(Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings["MyShoppingCartCookieTimeout"].ToString()));
                    HttpContext.Current.Response.AppendCookie(_ckmyshoppingcart);
                    divShoppingCart.InnerHtml = sbShoppingCart.ToString();
                }
            }
            else
            {
                divShoppingCart.InnerHtml = "<div style=\"font-size:14px;text-align:center;color:#808080;font-weight:bold;padding:30px;\">您的购物车中没有商品，请先进行<a href=\"index.html\" style=\"color:#cc0001;text-decoration:underline;\">选购>></a></div>";
                BLL.Goods bg = new weipin.BLL.Goods();
                List<Model.Goods> lmg = bg.SelectGoodsShoppingCart("");
                if (lmg != null && lmg.Count > 0)
                {
                    StringBuilder sbOtherChoose = new StringBuilder();
                    for (int i = 0; i < lmg.Count; i++)
                    {
                        string _path = lmg[i].GoodsPicturePath;
                        sbOtherChoose.Append("<div class=\"ordr_list\"><ul><li><a href=\"/page/" + lmg[i].GoodsID / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + lmg[i].GoodsName + "\">");
                        sbOtherChoose.Append("<img class=\"ordr_listb\" src=\"" + _path.Insert(_path.LastIndexOf("."), "_170x170") + "\" alt=\"" + lmg[i].GoodsID.ToString() + "\"/></a></li><li style=\"text-align:left;padding-left:5px;height:50px;\">");
                        sbOtherChoose.Append("<a href=\"/page/" + lmg[i].GoodsID / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + lmg[i].GoodsName + "\">" + Commonality.CutString(lmg[i].GoodsName, 20) + "</a></li>");
                        sbOtherChoose.Append("<li class=\"gray\">市场价：￥" + lmg[i].MarketPrice.ToString() + "</li><li class=\"red\">售价：￥");
                        if (lmg[i].DiscountPrice != 0)
                        {
                            sbOtherChoose.Append("<span>" + lmg[i].DiscountPrice + "</span>");
                        }
                        else
                        {
                            sbOtherChoose.Append("<span>" + lmg[i].Price + "</span>");
                        }
                        sbOtherChoose.Append("</li><li><a href=\"/page/" + lmg[i].GoodsID / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" target=\"_blank\"><img src=\"img/but_djckxq.gif\" width=\"81\" height=\"21\" border=\"0\"/></a></li></ul></div>");
                    }
                    divOtherChoose.InnerHtml = sbOtherChoose.ToString() + "<div class=\"clear\"></div>";
                }
            }
        }
    }
}