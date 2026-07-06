using System;
using System.Collections.Generic;
using System.Text;
using weipin.Common;
using System.Collections;
using System.Web;
using System.Xml;

namespace weipin
{
    public partial class OrderSuccess : Common.BasePage
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
                        divLoginMessage.InnerHtml = "<a href=\"#\" style=\"color:#ff6600;\">" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a>&nbsp;&nbsp;<a href=\"/Logout.aspx?logout=1\">[退出]</a>";
                    }
                    else { Response.Redirect("Login.aspx?returnurl=" + Request.Url.ToString()); }
                }
                else { Response.Redirect("Login.aspx?returnurl=" + Request.Url.ToString()); }
            }
            else { divLoginMessage.InnerHtml = "<a href=\"#\" style=\"color:#ff6600;\">" + (GetSessionOfLoginUser().NickName != "" ? GetSessionOfLoginUser().NickName : GetSessionOfLoginUser().LoginID) + "</a>&nbsp;&nbsp;<a href=\"/Logout.aspx?logout=1\">[退出]</a>"; }
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["hidMyAddress"] != null && Commonality.JudgeNumber(Request.Form["hidPaySendWay"], 3) && Request.Form["hidPayWay"] != null && Request.Form["txtRemarks"] != null && Request.Cookies["MyShoppingCart"] != null && Request.Cookies["MyShoppingCart"].Value != "")
            {
                string[] _myaddress = Request.Form["hidMyAddress"].ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                Model.Orders mo = new weipin.Model.Orders();
                if (_myaddress != null && _myaddress.Length == 6)
                {
                    mo.LoginID = GetSessionOfLoginUser().LoginID;
                    if (Commonality.JudgeNumber(_myaddress[0], 10)) { mo.AreaID = Convert.ToInt32(_myaddress[0]); hidAreaID.Value = mo.AreaID.ToString(); }
                    else { Response.Redirect("~/Error.aspx?msg=" + Server.UrlEncode("您的收货地址不正确")); }
                    mo.ConsigneeName = _myaddress[1];
                    mo.ShippingAddress = _myaddress[2];
                    mo.MobilePhone = _myaddress[3];
                    mo.Telephone = _myaddress[4];
                    mo.Zipcode = _myaddress[5];
                }
                else { Response.Redirect("~/Error.aspx?msg=" + Server.UrlEncode("您的收货地址不正确")); }
                byte _paysendway = Convert.ToByte(Request.Form["hidPaySendWay"].ToString());
                if (_paysendway == 1 || _paysendway == 2 || _paysendway == 3)
                {
                    mo.DeliveryPeriod = _paysendway;
                    hidDeliveryPeriod.Value = _paysendway.ToString();
                }
                else { Response.Redirect("~/Error.aspx?msg=" + Server.UrlEncode("您的配送时间不正确")); }
                if (Request.Form["hidPayWay"].ToString() == "1") { mo.PayWay = 1; mo.IsPay = true; } else if (Request.Form["hidPayWay"].ToString() == "2") { mo.PayWay = 2; mo.IsPay = false; } else { Response.Redirect("~/Error.aspx?msg=" + Server.UrlEncode("您的支付方式不正确")); }
                mo.Remarks = Request.Form["txtRemarks"].ToString();
                string _myshoppingcart = Server.UrlDecode(Request.Cookies["MyShoppingCart"].Value);
                string[] _arr = _myshoppingcart.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                string _condition = string.Empty;
                int _maxcount = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["ShoppingCartGoodsMaxCount"].ToString());
                if (_arr.Length > _maxcount)
                {
                    for (int i = 0; i < _maxcount; i++)
                    {
                        if (Commonality.JudgeNumber(_arr[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0], 10)) { _condition += "," + _arr[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0]; }
                    }
                }
                else
                {
                    for (int i = 0; i < _arr.Length; i++)
                    {
                        if (Commonality.JudgeNumber(_arr[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0], 10)) { _condition += "," + _arr[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0]; }
                    }
                }
                if (_condition != "")
                {
                    BLL.Goods bg = new weipin.BLL.Goods();
                    List<Model.Goods> lmg = bg.SelectGoodsShoppingCartByCondition(_condition.Substring(1));
                    if (lmg.Count > 0)
                    {
                        StringBuilder sbOrders = new StringBuilder();
                        sbOrders.Append("<table class=\"ordr_tab2\" width=\"100%\" border=\"0\" cellspacing=\"0\"><tr><td width=\"15%\" align=\"center\" class=\"ordrtab2_head\">商品编号</td>");
                        sbOrders.Append("<td width=\"55%\" align=\"center\" class=\"ordrtab2_head\">商品名称</td><td width=\"10%\" align=\"center\" class=\"ordrtab2_head\">微品价</td><td width=\"10%\" align=\"center\" class=\"ordrtab2_head\">抢购价</td>");
                        sbOrders.Append("<td width=\"10%\" align=\"center\" class=\"ordrtab2_head\">数量</td></tr>");
                        StringBuilder sbOrdersSQL = new StringBuilder();
                        Hashtable _inventoryshortage = new Hashtable();
                        double _discountprice = 0;//优惠总额
                        BLL.Users bu = new weipin.BLL.Users();
                        double _offsetprice = bu.SelectUsersOffsetPriceByLoginID(GetSessionOfLoginUser().LoginID).OffsetPrice;
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
                                            sbOrdersSQL.Append(" insert into Orders_Goods(OrderID,GoodsID,SizeID,GoodsCount,TransactionPrice) values({OrderID}," + lmgsingle[0].GoodsID + ",");
                                            if (_sid != 0) { sbOrdersSQL.Append(_sid); } else { sbOrdersSQL.Append("null"); }
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
                                                if (Request.Form["ckbUseOffsetPrice"] == null)
                                                {
                                                    sbOrders.Append(" class=\"prc\">￥" + lmgsingle[0].Price + "</td><td align=\"center\">-</td>");
                                                    _price = lmgsingle[0].Price;
                                                }
                                                else
                                                {
                                                    //使用优惠券
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
                                            }
                                            sbOrders.Append("<td align=\"center\" class=\"cnt\">" + _virtualinventory + "</td></tr>");
                                            sbOrdersSQL.Append("," + _virtualinventory + "," + _price + ")");
                                            if (!_inventoryshortage.ContainsValue(lmgsingle[0].GoodsID)) { _inventoryshortage.Add(lmgsingle[0].GoodsName, lmgsingle[0].GoodsID); }
                                        }
                                        else
                                        {
                                            sbOrders.Append("<tr><td align=\"center\">" + lmgsingle[0].GoodsID + "</td><td align=\"left\">" + lmgsingle[0].GoodsName);
                                            if (_sid != 0) { sbOrders.Append("<input type=\"hidden\" value=\"" + _sid + "\"/>"); }
                                            sbOrdersSQL.Append(" insert into Orders_Goods(OrderID,GoodsID,SizeID,GoodsCount,TransactionPrice) values({OrderID}," + lmgsingle[0].GoodsID + ",");
                                            if (_sid != 0) { sbOrdersSQL.Append(_sid); } else { sbOrdersSQL.Append("null"); }
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
                                                if (Request.Form["ckbUseOffsetPrice"] == null)
                                                {
                                                    sbOrders.Append(" class=\"prc\">￥" + lmgsingle[0].Price + "</td><td align=\"center\">-</td>");
                                                    _price = lmgsingle[0].Price;
                                                }
                                                else
                                                {
                                                    //使用优惠券
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
                                            }
                                            sbOrders.Append("<td align=\"center\" class=\"cnt\">" + _count + "</td></tr>");
                                            sbOrdersSQL.Append("," + _count + "," + _price + ")");
                                        }
                                    }
                                }
                            }
                        }
                        sbOrders.Append("</table><div class=\"clear\"></div>");
                        StringBuilder sbMessage = new StringBuilder();
                        if (sbOrdersSQL.ToString() != "")
                        {
                            if (_inventoryshortage.Count > 0)
                            {
                                sbMessage.Append("温馨提示：由于以下商品");
                                foreach (DictionaryEntry de in _inventoryshortage) { sbMessage.Append("<br/>[商品编号:" + de.Value + " 商品名称:" + de.Key + "]"); }
                                sbMessage.Append("<br/>库存不足，我们暂时为您提交了存在库存的商品(请见上方“本次商品订单”)，如无其它疑问请耐心等待，我们会尽快安排发货。");
                                sbMessage.Append("<br/>如需取消本次商品订单，请到<a href=\"/myhome/MyOrdersList.aspx\" style=\"color:#656565;\">我的订单</a>进行订单取消操作。");
                                divMessage.InnerHtml = sbMessage.ToString();
                                BLL.Orders bo = new weipin.BLL.Orders();
                                int _orderid = bo.InsertOrders(mo, sbOrdersSQL.ToString(), _discountprice);
                                if (_orderid > 0)
                                {
                                    spOrderID.InnerText = _orderid.ToString();
                                    hidOrderID.Value = _orderid.ToString();
                                    divOrders.InnerHtml = sbOrders.ToString();
                                    if (Request.Form["hidPayWay"].ToString() == "2") { divAlipay.Visible = true; }
                                }
                                else { Response.Redirect("~/Error.aspx?msg=" + Server.UrlEncode("添加订单失败,请稍后重试！")); }
                            }
                            else
                            {
                                BLL.Orders bo = new weipin.BLL.Orders();
                                int _orderid = bo.InsertOrders(mo, sbOrdersSQL.ToString(), _discountprice);
                                if (_orderid > 0)
                                {
                                    spOrderID.InnerText = _orderid.ToString();
                                    hidOrderID.Value = _orderid.ToString();
                                    divOrders.InnerHtml = sbOrders.ToString();
                                    if (Request.Form["hidPayWay"].ToString() == "2") { divAlipay.Visible = true; }
                                }
                                else { Response.Redirect("~/Error.aspx?msg=" + Server.UrlEncode("添加订单失败,请稍后重试！")); }
                            }
                        }
                        else
                        {
                            foreach (DictionaryEntry de in _inventoryshortage)
                            {
                                sbMessage.Append("<br/>[商品编号:" + de.Value + " 商品名称:" + de.Key + "]");
                            }
                            divMessage.InnerHtml = "抱歉!由于您挑选的商品" + sbMessage.ToString() + "<br/>库存不足，暂时无法购买。<a href=\"index.html\">点击选购其他商品>></a>";
                            pMessage.Style.Value = "display:none;";
                            pOrderMessage.Style.Value = "display:none;";
                            divSettleTitle.Style.Value = "display:none;";
                            divOrders.Style.Value = "display:none;";
                        }
                        HttpCookie _ckmyshoppingcart = new HttpCookie("MyShoppingCart", "");
                        _ckmyshoppingcart.Expires = DateTime.Now.AddDays(-Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings["MyShoppingCartCookieTimeout"].ToString()));
                        HttpContext.Current.Response.Cookies.Add(_ckmyshoppingcart);
                        hidDiscountPrice.Value = _discountprice.ToString();
                    }
                    else { Response.Redirect("~/Error.aspx?msg=" + Server.UrlEncode("找不到您购物车中的商品,请选购其他商品")); }
                }
                else { Response.Redirect("~/Error.aspx?msg=" + Server.UrlEncode("购物车商品验证失败,请重试")); }
            }
            else { Response.Redirect("~/Error.aspx?msg=" + Server.UrlEncode("购买失败,请重试")); }
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