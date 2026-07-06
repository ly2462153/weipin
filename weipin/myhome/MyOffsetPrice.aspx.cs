using System;
using System.Web.UI.WebControls;
using weipin.Common;
using System.Configuration;
using weipin.Model;
using System.Xml;
namespace weipin.myhome
{
    public partial class MyOffsetPrice : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindMyOffsetPrice();
        }
        /// <summary>
        /// 绑定我的抵价券
        /// </summary>
        private void BindMyOffsetPrice()
        {
            BLL.Users bu = new weipin.BLL.Users();
            Model.Users mu = bu.SelectUsersOffsetPriceByLoginID(GetSessionOfLoginUser().LoginID);
            bOffsetPrice.InnerText = mu.OffsetPrice.ToString();
            bVIPGrade.InnerText = mu.VIPGrade.ToString() + "星(" + (GetDiscount(mu.VIPGrade) * 10).ToString() + "折)";
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
    }
}