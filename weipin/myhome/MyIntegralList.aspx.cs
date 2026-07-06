using System;
using System.Web.UI.WebControls;
using weipin.Common;
using System.Configuration;
using weipin.Model;
namespace weipin.myhome
{
    public partial class MyIntegralList : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.Commonality.JudgeNumber(Request.Form["txtIntegral"], 10))
            {
                ExchangeOffsetPrice(Convert.ToInt32(Request.Form["txtIntegral"].ToString()));
            }
            else { BindMyIntegralList(Request.QueryString["p"]); }
        }
        /// <summary>
        /// 积分兑换抵价券
        /// </summary>
        /// <param name="integral">积分</param>
        private void ExchangeOffsetPrice(int integral)
        {
            if (integral % 100 != 0) { ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:请输入100的倍数<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"0\",\"\");</script>"); return; }
            BLL.Users bu = new weipin.BLL.Users();
            int _res = bu.UpdateUsersExchangeOffsetPrice(GetSessionOfLoginUser().LoginID, integral);
            if (_res >= 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:兑换成功<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"2000\",\"0\",\"\");$(\"#txtIntegral\").val(100);</script>");
                bIntegral.InnerText = _res.ToString();
            }
            else if (_res == -2) { ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:您输入的积分不能超出您的积分<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"0\",\"\");</script>"); }
            else { ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">tipsWindown(\"提示\",\"text:兑换失败<br/><a href='#' class='a_close' onclick='ClosePop();return false;'>确定</a>\",\"300\",\"60\",\"false\",\"\",\"0\",\"\");</script>"); }
        }
        /// <summary>
        /// 绑定我的积分列表
        /// </summary>
        /// <param name="nowpage">当前页</param>
        private void BindMyIntegralList(string nowpage)
        {
            string _param = string.Empty;
            if (!Commonality.JudgeNumber(nowpage, 5)) { nowpage = "1"; }
            BLL.Integral bi = new weipin.BLL.Integral();
            int _perpage = Convert.ToInt16(ConfigurationManager.AppSettings["MyIntegralListCount"].ToString());
            DataList<Model.Integral> dmi = bi.SelectMyGoodsIntegralByLoginIDOfPaging(GetSessionOfLoginUser().LoginID, Convert.ToInt16(nowpage), _perpage);
            if (dmi != null && dmi.Rows.Count > 0)
            {
                bIntegral.InnerText = dmi.IntegralTotle.ToString();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<table><tr><th width=\"25%\">积分</th><th width=\"25%\">积分来源(订单号)</th><th width=\"25%\">获取方式</th><th width=\"25%\">积分生效时间</th></tr>");
                for (int i = 0; i < dmi.Rows.Count; i++)
                {
                    sb.Append("<tr><td>" + dmi.Rows[i].IntegralNum + "</td><td>");
                    if (dmi.Rows[i].OrderID != null) { sb.Append(dmi.Rows[i].OrderID.ToString()); } else { sb.Append("-"); }
                    sb.Append("</td><td><input type=\"hidden\" name=\"hidSource\" value=\"" + dmi.Rows[i].SourseType.ToString() + "\"/></td><td>" + dmi.Rows[i].EffectiveTime.ToString() + "</td></tr>");
                }
                sb.Append("</table>");
                divIntegralList.InnerHtml = sb.ToString();
                divPaging.InnerHtml = Pagination.Paging(dmi.Total, Convert.ToInt16(nowpage), _perpage, "/myhome/MyIntegralList.aspx?p=", 11, _param);
            }
            else { bIntegral.InnerText = "0"; divIntegralList.InnerHtml = "您还没有获得积分的记录！"; }
        }
    }
}