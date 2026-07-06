using System;
using System.Collections.Generic;
using System.Text;
using weipin.Common;
using System.Collections;
using System.Web;
using System.Xml;

namespace weipin
{
    public partial class OrderCheck : Common.BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            if (GetSessionOfLoginUser() == null)
            {
                if (GetCookieOfLoginUser() != null)
                {
                    BLL.Users bu = new BLL.Users();
                    if (bu.CheckUser(GetCookieOfLoginUser().Values["loginid"].ToString(), GetCookieOfLoginUser().Values["loginpsw"].ToString(), false) == "1")
                    {
                        divLoginMessage.InnerHtml = "<a href=\"/myhome/UserInfo.aspx\" style=\"color:#ff6600;\">" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a>&nbsp;&nbsp;<a href=\"/Logout.aspx?logout=1\">[退出]</a>";
                    }
                    else { Response.Redirect("Login.aspx?returnurl=" + Request.Url.ToString()); }
                }
                else { Response.Redirect("Login.aspx?returnurl=" + Request.Url.ToString()); }
            }
            else { divLoginMessage.InnerHtml = "<a href=\"/myhome/UserInfo.aspx\" style=\"color:#ff6600;\">" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a>&nbsp;&nbsp;<a href=\"/Logout.aspx?logout=1\">[退出]</a>"; }
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["MyShoppingCart"] != null && Request.Cookies["MyShoppingCart"].Value != "")
            {
                #region 我的地址信息
                BLL.MyShippingAddresses bmsa = new weipin.BLL.MyShippingAddresses();
                List<Model.MyShippingAddresses> lmmsa = bmsa.SelectMyShippingAddressesByLoginID(GetSessionOfLoginUser().LoginID);
                if (lmmsa.Count > 0)
                {
                    string _myaddressshow = string.Empty;
                    StringBuilder sbList = new StringBuilder();
                    sbList.Append("<table class=\"ordr_bg2td\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
                    for (int i = 0; i < lmmsa.Count; i++)
                    {
                        if (lmmsa[i].IsMain == true)
                        {
                            _myaddressshow = "<ul><li>" + lmmsa[i].ConsigneeName + "<input type=\"hidden\" id=\"hidMyAddressID\" value=\"" + lmmsa[i].MyAddressID.ToString() + "\"/><input type=\"hidden\" id=\"hidAreaID\" value=\"" + lmmsa[i].AreaID.ToString() + "\"/></li><li>" + lmmsa[i].MyAddress + "</li><li>" + lmmsa[i].MobilePhone + "</li><li>" + lmmsa[i].Telephone + "</li><li>" + lmmsa[i].MyZipcode + "</li></ul><div class=\"clear\"></div>";
                            hidMyAddress.Value = lmmsa[i].AreaID.ToString() + "|" + lmmsa[i].ConsigneeName + "|" + lmmsa[i].MyAddress + "|" + lmmsa[i].MobilePhone + "|" + lmmsa[i].Telephone + "|" + lmmsa[i].MyZipcode;
                        }
                        sbList.Append("<tr><td width=\"4%\" height=\"26\" align=\"center\"><input type=\"radio\" name=\"rdoMyAddress\"");
                        if (lmmsa[i].IsMain == true) { sbList.Append(" checked=\"checked\""); }
                        sbList.Append(" style=\"border:0;\"/><input type=\"hidden\" value=\"" + lmmsa[i].MyAddressID.ToString() + "\"/><input type=\"hidden\" value=\"" + lmmsa[i].AreaID.ToString() + "\"/></td><td width=\"8%\" align=\"left\">" + lmmsa[i].ConsigneeName + "</td><td width=\"50%\" align=\"left\">" + lmmsa[i].MyAddress + "</td>");
                        sbList.Append("<td width=\"13%\" align=\"center\">" + lmmsa[i].MobilePhone + "</td><td width=\"13%\" align=\"center\">" + lmmsa[i].Telephone + "</td><td width=\"2%\" align=\"center\">" + lmmsa[i].MyZipcode + "</td>");
                        sbList.Append("<td width=\"10%\" align=\"center\"><a href=\"#\" onclick=\"DeleteMyAddress('" + lmmsa[i].MyAddressID.ToString() + "',this);return false;\">删除</a></td></tr>");
                    }
                    sbList.Append("</table>");
                    divMyAddressShow.InnerHtml = _myaddressshow;
                    divMyAddressList.InnerHtml = sbList.ToString();
                    divMyAddressShow.Style.Value = "display:'';";
                    rdoAddAddress.Checked = false;
                    divMyAddressAdd.Style.Value = "display:none;";
                    tbMyAddressAdd.Style.Value = "display:none;";
                    aControl.InnerText = "[修改]";
                    aControl.Style.Value = "display:'';";
                }
                else
                {
                    divMyAddressShow.InnerHtml = "<input type=\"hidden\" id=\"hidMyAddressID\"/>";
                    divMyAddressShow.Style.Value = "display:none;";
                    rdoAddAddress.Checked = true;
                    divMyAddressAdd.Style.Value = "display:'';";
                    tbMyAddressAdd.Style.Value = "display:'';";
                    aControl.Style.Value = "display:none;";
                }
                #endregion

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
                if (_condition != "")
                {
                    BLL.Goods bg = new weipin.BLL.Goods();
                    List<Model.Goods> lmg = bg.SelectGoodsShoppingCartByCondition(_condition.Substring(1));
                    string _cookie = string.Empty;
                    if (lmg.Count > 0)
                    {
                        StringBuilder sbOrders = new StringBuilder();
                        sbOrders.Append("<table class=\"ordr_tab2\" width=\"100%\" border=\"0\" cellspacing=\"0\"><tr><td width=\"15%\" align=\"center\" class=\"ordrtab2_head\">商品编号</td>");
                        sbOrders.Append("<td width=\"55%\" align=\"center\" class=\"ordrtab2_head\">商品名称</td><td width=\"10%\" align=\"center\" class=\"ordrtab2_head\">微品价</td><td width=\"10%\" align=\"center\" class=\"ordrtab2_head\">抢购价</td>");
                        sbOrders.Append("<td width=\"10%\" align=\"center\" class=\"ordrtab2_head\">数量</td></tr>");
                        Hashtable _inventoryshortage = new Hashtable();
                        double _discountprice = 0;//优惠总额
                        BLL.Users bu = new weipin.BLL.Users();
                        double _offsetprice = bu.SelectUsersOffsetPriceByLoginID(GetSessionOfLoginUser().LoginID).OffsetPrice;
                        spMyOffsetPrice.InnerText = _offsetprice.ToString();
                        for (int j = 0; j < _arr.Length; j++)
                        {
                            if (Commonality.JudgeNumber(_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0], 10))
                            {
                                List<Model.Goods> lmgsingle = lmg.FindAll(delegate(Model.Goods mg) { return mg.GoodsID == Convert.ToInt32(_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0]); });
                                if (lmgsingle != null && lmgsingle.Count > 0)
                                {
                                    int _sid = 0;
                                    if (_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Length > 3 && Commonality.JudgeNumber(_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[3], 10)) { _sid = Convert.ToInt32(_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[3].ToString()); }
                                    if (lmgsingle[0].Inventory == null)
                                    {
                                        BLL.Sizes bss = new weipin.BLL.Sizes();
                                        int[] _arrSizeXML = bss.GetGoodsIvtSL(lmgsingle[0].GoodsID, _sid);
                                        lmgsingle[0].Inventory = _arrSizeXML[0];
                                        lmgsingle[0].SupplyLine = _arrSizeXML[1];
                                    }
                                    if (lmgsingle[0].Inventory <= lmgsingle[0].SupplyLine)
                                    {
                                        if (!_inventoryshortage.ContainsValue(lmgsingle[0].GoodsID)) { _inventoryshortage.Add(lmgsingle[0].GoodsName, lmgsingle[0].GoodsID); }
                                    }
                                    else
                                    {
                                        int _virtualinventory = Convert.ToInt32(lmgsingle[0].Inventory) - Convert.ToInt32(lmgsingle[0].SupplyLine);
                                        byte _count = 0;
                                        if (Commonality.JudgeNumber(_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1], 3))
                                        {
                                            _count = Convert.ToByte(_arr[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1]);
                                        }
                                        else { _count = 1; }
                                        if (_count > _virtualinventory)
                                        {
                                            sbOrders.Append("<tr><td align=\"center\">" + lmgsingle[0].GoodsID + "</td><td align=\"left\">" + lmgsingle[0].GoodsName);
                                            if (_sid != 0) { sbOrders.Append("<input type=\"hidden\" value=\"" + _sid + "\"/>"); }
                                            sbOrders.Append("</td><td align=\"center\"");
                                            double _price = 0;
                                            if (lmgsingle[0].DiscountPrice != 0)
                                            {
                                                //存在抢购价
                                                sbOrders.Append(" class=\"thr\">￥" + lmgsingle[0].Price + "</td><td align=\"center\" class=\"prc\">" + lmgsingle[0].DiscountPrice + "</td>");
                                                _price = lmgsingle[0].DiscountPrice;
                                            }
                                            else
                                            {
                                                //不存在抢购价
                                                sbOrders.Append(" class=\"prc\">￥" + lmgsingle[0].Price + "</td><td align=\"center\">-</td>");
                                                double _singlediscountprice = Math.Round(lmgsingle[0].Price - GetDiscount(Convert.ToByte(GetSessionOfLoginUser().VIPGrade)) * lmgsingle[0].Price, 1);
                                                if (_offsetprice != 0)
                                                {
                                                    if (_offsetprice >= _singlediscountprice * _virtualinventory)
                                                    {
                                                        //抵价券大于可优惠的价格
                                                        _price = Math.Round(lmgsingle[0].Price - _singlediscountprice, 1);
                                                        _discountprice += Math.Round(_singlediscountprice * _virtualinventory, 1);
                                                        _offsetprice = Math.Round(_offsetprice - _singlediscountprice * _virtualinventory, 1);
                                                    }
                                                    else
                                                    {
                                                        //抵价券小于可优惠的价格
                                                        _price = Math.Round(lmgsingle[0].Price - StructDouble((_offsetprice / _virtualinventory).ToString()), 1);
                                                        _discountprice += Math.Round(StructDouble((_offsetprice / _virtualinventory).ToString()) * _virtualinventory, 1);
                                                        _offsetprice = Math.Round(_offsetprice - StructDouble((_offsetprice / _virtualinventory).ToString()) * _virtualinventory, 1);
                                                    }
                                                }
                                                else { _price = lmgsingle[0].Price; }
                                            }
                                            sbOrders.Append("<td align=\"center\" class=\"cnt\">" + _virtualinventory + "</td></tr>");
                                            _cookie += "|" + lmgsingle[0].GoodsID.ToString() + "," + _virtualinventory + "," + _price;
                                            if (_sid != 0) { _cookie += "," + _sid.ToString(); } else { _cookie += ","; }
                                            if (!_inventoryshortage.ContainsValue(lmgsingle[0].GoodsID)) { _inventoryshortage.Add(lmgsingle[0].GoodsName, lmgsingle[0].GoodsID); }
                                        }
                                        else
                                        {
                                            sbOrders.Append("<tr><td align=\"center\">" + lmgsingle[0].GoodsID + "</td><td align=\"left\">" + lmgsingle[0].GoodsName);
                                            if (_sid != 0) { sbOrders.Append("<input type=\"hidden\" value=\"" + _sid + "\"/>"); }
                                            sbOrders.Append("</td><td align=\"center\"");
                                            double _price = 0;//成交单价
                                            if (lmgsingle[0].DiscountPrice != 0)
                                            {
                                                //存在抢购价
                                                sbOrders.Append(" class=\"thr\">￥" + lmgsingle[0].Price + "</td><td align=\"center\" class=\"prc\">" + lmgsingle[0].DiscountPrice + "</td>");
                                                _price = lmgsingle[0].DiscountPrice;
                                            }
                                            else
                                            {
                                                //不存在抢购价
                                                sbOrders.Append(" class=\"prc\">￥" + lmgsingle[0].Price + "</td><td align=\"center\">-</td>");
                                                double _singlediscountprice = Math.Round(lmgsingle[0].Price - GetDiscount(Convert.ToByte(GetSessionOfLoginUser().VIPGrade)) * lmgsingle[0].Price, 1);
                                                if (_offsetprice != 0)
                                                {
                                                    if (_offsetprice >= _singlediscountprice * _count)
                                                    {
                                                        //抵价券大于可优惠的价格
                                                        _price = Math.Round(lmgsingle[0].Price - _singlediscountprice, 1);
                                                        _discountprice += Math.Round(_singlediscountprice * _count, 1);
                                                        _offsetprice = Math.Round(_offsetprice - _singlediscountprice * _count, 1);
                                                    }
                                                    else
                                                    {
                                                        //抵价券小于可优惠的价格
                                                        _price = Math.Round(lmgsingle[0].Price - StructDouble((_offsetprice / _count).ToString()), 1);
                                                        _discountprice += Math.Round(StructDouble((_offsetprice / _count).ToString()) * _count, 1);
                                                        _offsetprice = Math.Round(_offsetprice - StructDouble((_offsetprice / _count).ToString()) * _count, 1);
                                                    }
                                                }
                                                else { _price = lmgsingle[0].Price; }
                                            }
                                            sbOrders.Append("<td align=\"center\" class=\"cnt\">" + _count + "</td></tr>");
                                            _cookie += "|" + lmgsingle[0].GoodsID.ToString() + "," + _count + "," + _price;
                                            if (_sid != 0) { _cookie += "," + _sid.ToString(); } else { _cookie += ","; }
                                        }
                                    }
                                }
                            }
                        }
                        sbOrders.Append("</table><div class=\"clear\"></div>");
                        StringBuilder sbMessage = new StringBuilder();
                        if (_cookie != "")
                        {
                            _cookie = _cookie.Substring(1);
                            if (_inventoryshortage.Count > 0)
                            {
                                sbMessage.Append("温馨提示：由于以下商品");
                                foreach (DictionaryEntry de in _inventoryshortage) { sbMessage.Append("<br/>[商品编号:" + de.Value + " 商品名称:" + de.Key + "]"); }
                                sbMessage.Append("<br/>库存不足，我们适当为您购物车中的商品数量进行了调整，“商品清单”中是我们目前能为您提供的最大商品数量，如无其它疑问请点击“提交”，我们会尽快安排发货。");
                                divMessage.InnerHtml = sbMessage.ToString();
                            }
                        }
                        else
                        {
                            foreach (DictionaryEntry de in _inventoryshortage) { sbMessage.Append("<br/>[商品编号:" + de.Value + " 商品名称:" + de.Key + "]"); }
                            divMessage.InnerHtml = "抱歉!由于您挑选的商品" + sbMessage.ToString() + "<br/>库存不足，暂时无法购买。<a href=\"index.html\">点击选购其他商品>></a>";
                            divSettleTitle.Style.Value = "display:none;";
                            divSettleMessage.Style.Value = "display:none;";
                            imgSubmit.Style.Value = "display:none;";
                        }
                        HttpCookie _ckmyshoppingcart = new HttpCookie("MyShoppingCart", _cookie);
                        _ckmyshoppingcart.Expires = DateTime.Now.AddDays(Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings["MyShoppingCartCookieTimeout"].ToString()));
                        HttpContext.Current.Response.AppendCookie(_ckmyshoppingcart);
                        divOrders.InnerHtml = sbOrders.ToString();
                        spDiscountPrice.InnerHtml = _discountprice.ToString() + "<input type=\"hidden\" value=\"" + _discountprice.ToString() + "\"/>";
                        spThisOrdersUse.InnerHtml = _discountprice.ToString();
                    }
                    else
                    {
                        HttpCookie _ckmyshoppingcart = new HttpCookie("MyShoppingCart", "");
                        _ckmyshoppingcart.Expires = DateTime.Now.AddDays(Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings["MyShoppingCartCookieTimeout"].ToString()));
                        HttpContext.Current.Response.AppendCookie(_ckmyshoppingcart);
                        Response.Redirect("index.html");
                    }
                }
                else
                {
                    HttpCookie _ckmyshoppingcart = new HttpCookie("MyShoppingCart", "");
                    _ckmyshoppingcart.Expires = DateTime.Now.AddDays(Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings["MyShoppingCartCookieTimeout"].ToString()));
                    HttpContext.Current.Response.AppendCookie(_ckmyshoppingcart);
                    Response.Redirect("index.html");
                }
            }
            else
            {
                Response.Redirect("index.html");
            }
        }
        /// <summary>
        /// 获取VIP等级对应的折扣
        /// </summary>
        /// <param name="vipgrade">VIP等级</param>
        /// <returns></returns>
        private double GetDiscount(byte vipgrade)
        {
            double _discount = 1;
            string _vipgradepath = Server.MapPath("~/xml/vipgrade.xml");
            if (System.IO.File.Exists(_vipgradepath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_vipgradepath);
                XmlNodeList nodelist = doc.DocumentElement.ChildNodes;
                if (nodelist.Count > 0)
                {
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        if (nodelist[i].Attributes["name"].Value == vipgrade.ToString()) { _discount = Convert.ToDouble(nodelist[i].Attributes["value"].Value); break; }
                    }
                }
            }
            return _discount;
        }
        /// <summary>
        /// 构造保留一位小数(只舍不入)
        /// </summary>
        /// <param name="num">要构造的数字</param>
        /// <returns></returns>
        private double StructDouble(string num)
        {
            int _index = num.IndexOf(".");
            if (_index != -1) { num = num.Substring(0, _index + 2); }
            return Convert.ToDouble(num);
        }
    }
}