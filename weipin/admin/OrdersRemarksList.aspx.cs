using System;
using System.Web.UI.WebControls;
using weipin.Model;

namespace weipin.admin
{
    public partial class OrdersRemarksList : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtStartTime"] != null)
            {
                BindOrdersRemarksList(1, Request.Form["txtStartTime"].ToString(), Request.Form["txtEndTime"].ToString());
            }
            else if (Common.Commonality.JudgeNumber(Request.QueryString["p"], 5))
            {
                BindOrdersRemarksList(Convert.ToInt16(Request.QueryString["p"].ToString()), Request.QueryString["st"], Request.QueryString["et"]);
            }
            else
            {
                BindOrdersRemarksList(1, Request.QueryString["st"], Request.QueryString["et"]);
            }
        }
        /// <summary>
        /// 绑定快递员(分页)
        /// <param name="_nowpage">当前页</param>
        /// </summary>
        private void BindOrdersRemarksList(int _nowpage, string _starttime, string _endtime)
        {
            DateTime dtime = new DateTime();
            if (!DateTime.TryParse(_starttime, out dtime))
            {
                _starttime = "";
            }
            if (!DateTime.TryParse(_endtime, out dtime))
            {
                _endtime = "";
            }
            txtStartTime.Value = _starttime;
            txtEndTime.Value = _endtime;
            BLL.OrdersRemarks bc = new weipin.BLL.OrdersRemarks();
            int _perpage = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["ItemOfPage"].ToString());
            DataList<Model.OrdersRemarks> dmo = bc.SelectOrdersRemarksOfPaging(_nowpage, _perpage, _starttime, _endtime);
            if (dmo != null && dmo.Total > 0)
            {
                string _param = string.Empty;
                if (_starttime != "")
                {
                    _param += "&st=" + _starttime;
                }
                if (_endtime != "")
                {
                    _param += "&et=" + _endtime;
                }
                int _total = dmo.Total;
                int _maxpage = Common.Pagination.CountMaxPage(_total, _perpage);
                if (_nowpage <= _maxpage)
                {
                    rptOrdersRemarksList.DataSource = dmo.Rows;
                    rptOrdersRemarksList.DataBind();
                    divPaging.InnerHtml = Common.Pagination.PagingFirstLast(_total, _nowpage, _perpage, "OrdersRemarksList.aspx?p=", 11, _param);
                }
                else
                {
                    Response.Write("<script>location.href='OrdersRemarksList.aspx?p=" + _maxpage + _param + "';</script>");
                }
            }
            else
            {
                this.divPaging.Visible = false;
            }
        }
    }
}