using System;

namespace weipin.mailtemplate.info
{
    public partial class EmailStatistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _internetip = "";
            string _lanip = "";
            if (Request.ServerVariables["HTTP_VIA"] != null)
            {
                _internetip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                if (_internetip.IndexOf(",") != -1) { _internetip = _internetip.Substring(0, _internetip.IndexOf(",")); }
                _lanip = Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            else { _internetip = ""; _lanip = Request.ServerVariables["REMOTE_ADDR"].ToString(); }
            Model.EmailStatistics mes = new weipin.Model.EmailStatistics();
            mes.InternetIP = _internetip;
            mes.LanIP = _lanip;
            if (_internetip != "") { mes.UserIPArea = GetAddress(_internetip); }
            if (Request.QueryString["v"] != null) { mes.VersionNum = Request.QueryString["v"].ToString(); }
            BLL.EmailStatistics bes = new weipin.BLL.EmailStatistics();
            bes.UpdateEmailStatistics(mes);
        }
        /// <summary>
        /// 通过IP获取地区
        /// </summary>
        /// <param name="ip">IP</param>
        /// <returns></returns>
        private string GetAddress(string ip)
        {
            string _address = string.Empty;
            try
            {
                cn.com.webxml.www.IpAddressSearchWebService ipservice = new weipin.cn.com.webxml.www.IpAddressSearchWebService();
                string[] _ipaddress = ipservice.getCountryCityByIp(ip);
                if (_ipaddress != null) { _address = _ipaddress[1].ToString(); }
                return _address;
            }
            catch { return null; }
        }
    }
}