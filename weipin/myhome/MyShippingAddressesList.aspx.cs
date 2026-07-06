using System;
using System.Web.UI.WebControls;
using weipin.Common;
using System.Configuration;
using weipin.Model;
using System.Collections.Generic;

namespace weipin.myhome
{
    public partial class MyShippingAddressesList : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindMyShippingAddressesList();
        }
        /// <summary>
        /// 绑定我的收货地址
        /// </summary>
        private void BindMyShippingAddressesList()
        {
            BLL.MyShippingAddresses bmsa = new weipin.BLL.MyShippingAddresses();
            List<Model.MyShippingAddresses> lmmsa = bmsa.SelectMyShippingAddressesByLoginID(GetSessionOfLoginUser().LoginID);
            if (lmmsa != null && lmmsa.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<table><tr><th width=\"10%\">收货人</th><th width=\"55%\">详细地址</th><th width=\"12%\">手机</th><th width=\"13%\">座机</th><th width=\"10%\">&nbsp;</th></tr>");
                for (int i = 0; i < lmmsa.Count; i++)
                {
                    sb.Append("<tr><td>" + lmmsa[i].ConsigneeName + "</td><td style=\"text-align:left;\">" + lmmsa[i].MyAddress + "");
                    if (lmmsa[i].MyZipcode != "") { sb.Append("," + lmmsa[i].MyZipcode + "</td>"); } else { sb.Append("</td>"); }
                    if (lmmsa[i].MobilePhone != "") { sb.Append("<td>" + lmmsa[i].MobilePhone + "</td>"); } else { sb.Append("<td></td>"); }
                    if (lmmsa[i].Telephone != "") { sb.Append("<td>" + lmmsa[i].Telephone + "</td>"); } else { sb.Append("<td></td>"); }
                    sb.Append("<td><a href=\"#\" onclick=\"DeleteMyAddress('" + lmmsa[i].MyAddressID + "',this);return false;\" style=\"float:none;\">删除</a></td></tr>");
                }
                sb.Append("</table>");
                divMyShippingAddressesList.InnerHtml = sb.ToString();
            }
            else { divMyShippingAddressesList.InnerHtml = "您还没有添加过收货地址！"; }
        }
    }
}