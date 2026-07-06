using System;
using System.Collections.Generic;
using System.Xml;

namespace weipin.alipay
{
    /// <summary>
    /// 功能：纯担保交易接口接入页
    /// 版本：3.3
    /// 日期：2012-07-05
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// 
    /// /////////////////注意///////////////////////////////////////////////////////////////
    /// 如果您在接口集成过程中遇到问题，可以按照下面的途径来解决
    /// 1、商户服务中心（https://b.alipay.com/support/helperApply.htm?action=consultationApply），提交申请集成协助，我们会有专业的技术工程师主动联系您协助解决
    /// 2、商户帮助中心（http://help.alipay.com/support/232511-16307/0-16307.htm?sh=Y&info_type=9）
    /// 3、支付宝论坛（http://club.alipay.com/read-htm-tid-8681712.html）
    /// 
    /// 如果不想使用扩展功能请把扩展功能参数赋空值。
    /// </summary>
    public partial class _Default : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.Commonality.JudgeNumber(Request.QueryString["hidOrderID"], 10))
            {
                BLL.Orders bos = new weipin.BLL.Orders();
                Model.Orders mo = bos.SelectOrdersDetailByID(GetSessionOfLoginUser().LoginID, Convert.ToInt32(Request.QueryString["hidOrderID"].ToString()));
                string[] arr = GetAddressAndFeight(mo.OrderAmount, mo.AreaID);
                ////////////////////////////////////////////请求参数////////////////////////////////////////////

                //支付类型
                string payment_type = "1";
                //必填，不能修改
                //服务器异步通知页面路径
                string notify_url = "http://www.weipin365.com/alipay/notify_url.aspx";
                //需http://格式的完整路径，不能加?id=123这类自定义参数

                //页面跳转同步通知页面路径
                string return_url = "http://www.weipin365.com/alipay/return_url.aspx";
                //需http://格式的完整路径，不能加?id=123这类自定义参数，不能写成http://localhost/

                //卖家支付宝帐户
                string seller_email = "weipin365@yahoo.cn";
                //必填

                //商户订单号
                string out_trade_no = Request.QueryString["hidOrderID"].ToString();
                //商户网站订单系统中唯一订单号，必填

                //订单名称
                string subject = "订单号：" + Request.QueryString["hidOrderID"].ToString();
                //必填

                //付款金额
                string price = mo.OrderAmount.ToString();
                //必填

                //商品数量
                string quantity = "1";
                //必填，建议默认为1，不改变值，把一次交易看成是一次下订单而非购买一件商品
                //物流费用
                string logistics_fee = arr[1].ToString();
                //必填，即运费
                //物流类型
                string logistics_type = "EXPRESS";
                //必填，三个值可选：EXPRESS（快递）、POST（平邮）、EMS（EMS）
                //物流支付方式
                string logistics_payment = string.Empty;
                logistics_payment = "BUYER_PAY";
                //必填，两个值可选：SELLER_PAY（卖家承担运费）、BUYER_PAY（买家承担运费）
                //订单描述

                //string body = "";
                //商品展示地址
                //string show_url = "";
                //需以http://开头的完整路径，如：http://www.xxx.com/myorder.html

                //收货人姓名
                string receive_name = mo.ConsigneeName;
                //如：张三

                //收货人地址
                string receive_address = arr[0].ToString() + mo.ShippingAddress;
                //如：XX省XXX市XXX区XXX路XXX小区XXX栋XXX单元XXX号

                //收货人邮编
                //string receive_zip = "";
                //如：123456

                //收货人电话号码
                //string receive_phone = "";
                //如：0571-88158090

                //收货人手机号码
                //string receive_mobile = "";
                //如：13312341234

                ////////////////////////////////////////////////////////////////////////////////////////////////

                //把请求参数打包成数组
                SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
                sParaTemp.Add("_input_charset", Com.Alipay.Config.Input_charset.ToLower());
                sParaTemp.Add("key", Com.Alipay.Config.Key);
                sParaTemp.Add("logistics_fee", logistics_fee);
                sParaTemp.Add("logistics_payment", logistics_payment);
                sParaTemp.Add("logistics_type", logistics_type);
                sParaTemp.Add("notify_url", notify_url);
                sParaTemp.Add("out_trade_no", out_trade_no);
                sParaTemp.Add("partner", Com.Alipay.Config.Partner);
                sParaTemp.Add("payment_type", payment_type);
                sParaTemp.Add("price", price);
                sParaTemp.Add("quantity", quantity);
                sParaTemp.Add("receive_address", receive_address);
                sParaTemp.Add("receive_name", receive_name);
                sParaTemp.Add("return_url", return_url);
                sParaTemp.Add("seller_email", seller_email);
                sParaTemp.Add("service", "create_partner_trade_by_buyer");
                sParaTemp.Add("subject", subject);
                //sParaTemp.Add("body", body);
                //sParaTemp.Add("show_url", show_url);
                //sParaTemp.Add("receive_zip", receive_zip);
                //sParaTemp.Add("receive_phone", receive_phone);
                //sParaTemp.Add("receive_mobile", receive_mobile);
                sParaTemp.Add("sign_type", Com.Alipay.Config.Sign_type);
                sParaTemp.Add("sign", "_input_charset=" + Com.Alipay.Config.Input_charset.ToLower() + "&key=" + Com.Alipay.Config.Key + "&logistics_fee=" + logistics_fee + "&logistics_payment=" + logistics_payment + "&logistics_type=" + logistics_type + "&notify_url=" + notify_url + "&out_trade_no=" + out_trade_no + "&partner=" + Com.Alipay.Config.Partner + "&payment_type=" + payment_type + "&price=" + price + "&quantity=" + quantity + "&receive_address=" + receive_address + "&receive_name=" + receive_name + "&return_url=" + return_url + "&seller_email=" + seller_email + "&service=create_partner_trade_by_buyer" + "&subject=" + subject);

                //建立请求
                string sHtmlText = Com.Alipay.Submit.BuildRequest(sParaTemp, "get", "确认");
                Response.Write(sHtmlText);
            }
        }
        /// <summary>
        /// 获取地址和运费
        /// </summary>
        /// <param name="ordermoney">订单金额</param>
        /// <param name="_areaid">区域ID</param>
        /// <returns></returns>
        private string[] GetAddressAndFeight(double ordermoney, int _areaid)
        {
            string[] arr = new string[2];
            string _path = Server.MapPath("~/xml/areas/areas.xml");
            if (System.IO.File.Exists(_path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_path);
                XmlNodeList nodelist = doc.GetElementsByTagName("ar");
                if (nodelist.Count > 0)
                {
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        if (_areaid.ToString() == nodelist[i].Attributes["ai"].Value && Common.Commonality.JudgeNumber(nodelist[i].Attributes["ai"].Value, 5))
                        {
                            arr[0] = nodelist[i].ParentNode.ParentNode.Attributes["an"].Value + nodelist[i].ParentNode.Attributes["an"].Value + nodelist[i].Attributes["an"].Value;
                            if (((_areaid > 1 && _areaid < 30 || _areaid > 30 && _areaid < 216 || _areaid > 216 && _areaid < 325 || _areaid > 325 && _areaid < 528 || _areaid > 528 && _areaid < 667 || _areaid > 1142 && _areaid < 1272 || _areaid > 1272 && _areaid < 1377 || _areaid > 1377 && _areaid < 1513 || _areaid > 1513 && _areaid < 1615 || _areaid > 1615 && _areaid < 1737 || _areaid > 1737 && _areaid < 1910 || _areaid > 1910 && _areaid < 2096 || _areaid > 2096 && _areaid < 2219 || _areaid > 2219 && _areaid < 2357 || _areaid > 2357 && _areaid < 2545 || _areaid > 2545 && _areaid < 2670 || _areaid > 2670 && _areaid < 2705 || _areaid > 2705 && _areaid < 2805 || _areaid > 2805 && _areaid < 2957 || _areaid > 3038 && _areaid < 3160) && ordermoney >= 38) || ((_areaid > 667 && _areaid < 785 || _areaid > 785 && _areaid < 915 || _areaid > 915 && _areaid < 991 || _areaid > 991 && _areaid < 1142 || _areaid > 2957 && _areaid < 3038 || _areaid > 3160 && _areaid < 3263 || _areaid > 3263 && _areaid < 3316 || _areaid > 3316 && _areaid < 3346 || _areaid > 3346 && _areaid < 3463) && ordermoney >= 68)) { arr[1] = "0"; } else { arr[1] = nodelist[i].Attributes["fr"].Value; }
                            break;
                        }
                    }
                }
            }
            return arr;
        }
    }
}