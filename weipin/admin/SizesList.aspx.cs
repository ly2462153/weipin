using System;
using System.Data;

namespace weipin.admin
{
    public partial class SizesList : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.Commonality.JudgeNumber(Request.QueryString["p"], 5))
            {
                BindSizes(Convert.ToInt16(Request.QueryString["p"].ToString()));
            }
            else
            {
                BindSizes(1);
            }
        }
        /// <summary>
        /// 绑定尺码(分页)
        /// <param name="_nowpage">当前页</param>
        /// </summary>
        private void BindSizes(int _nowpage)
        {
            BLL.Sizes bs = new weipin.BLL.Sizes();
            DataSet ds = new DataSet();
            int _perpage = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["ItemOfPage"].ToString());
            ds = bs.SelectSizesOfPaging(_nowpage, _perpage);
            if (ds != null && ds.Tables[0] != null && ds.Tables[1] != null)
            {
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    rptSizesList.DataSource = ds.Tables[0];
                    rptSizesList.DataBind();
                    int _total = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
                    int _maxpage = Common.Pagination.CountMaxPage(_total, _perpage);
                    if (_nowpage <= _maxpage)
                    {
                        if (ds.Tables[0] != null)
                        {
                            DataTable dt = ds.Tables[1];
                            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                            {
                                rptSizesList.DataSource = ds.Tables[0];
                                rptSizesList.DataBind();
                                divPaging.InnerHtml = Common.Pagination.PagingFirstLast(_total, _nowpage, _perpage, "SizesList.aspx?p=", 11, "");
                            }
                        }
                    }
                    else
                    {
                        Response.Write("<script>location.href='SizesList.aspx?p=" + _maxpage + "" + "';</script>");
                    }
                }
                else
                {
                    this.divPaging.Visible = false;
                }
            }
            else
            {
                this.divPaging.Visible = false;
            }
        }
    }
}