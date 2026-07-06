using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace weipin.admin
{
    public partial class GoodsCommentsList : Common.BasePageAdmin
    {
        int _commentstatus = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.Commonality.JudgeNumber(Request.QueryString["p"], 5) && Request.QueryString["cs"] != null)
            {
                if (Request.QueryString["cs"].ToString() == "1" || Request.QueryString["cs"].ToString() == "2" || Request.QueryString["cs"].ToString() == "3")
                {
                    BindGoodsComments(Convert.ToInt16(Request.QueryString["p"].ToString()), Convert.ToByte(Request.QueryString["cs"].ToString()));
                    selCommentStatus.SelectedIndex = selCommentStatus.Items.IndexOf(selCommentStatus.Items.FindByValue(Request.QueryString["cs"].ToString()));
                }
                else { BindGoodsComments(1, 1); }
            }
            else { BindGoodsComments(1, 1); }
        }
        /// <summary>
        /// 绑定商品评论(分页)
        /// <param name="_nowpage">当前页</param>
        /// <param name="_status">评价状态</param>
        /// </summary>
        private void BindGoodsComments(int _nowpage, byte _status)
        {
            BLL.GoodsComments bgc = new weipin.BLL.GoodsComments();
            DataSet ds = new DataSet();
            int _perpage = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["ItemOfPage"].ToString());
            ds = bgc.SelectGoodsCommentsOfPaging(_nowpage, _perpage, _status);
            if (ds != null && ds.Tables[0] != null && ds.Tables[1] != null)
            {
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    rptGoodsCommentsList.DataSource = ds.Tables[0];
                    rptGoodsCommentsList.DataBind();
                    int _total = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
                    string _param = "&cs=" + _status.ToString();
                    _commentstatus = _status;
                    int _maxpage = Common.Pagination.CountMaxPage(_total, _perpage);
                    if (_nowpage <= _maxpage)
                    {
                        if (ds.Tables[0] != null)
                        {
                            DataTable dt = ds.Tables[1];
                            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                            {
                                rptGoodsCommentsList.DataSource = ds.Tables[0];
                                rptGoodsCommentsList.DataBind();
                                divPaging.InnerHtml = Common.Pagination.PagingFirstLast(_total, _nowpage, _perpage, "GoodsCommentsList.aspx?p=", 11, _param);
                            }
                        }
                    }
                    else
                    {
                        Response.Write("<script>location.href='GoodsCommentsList.aspx?p=" + _maxpage + _param + "';</script>");
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

        protected void rptGoodsCommentsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (_commentstatus == 1)
                {
                    (e.Item.FindControl("tdStatus1") as HtmlTableCell).Visible = true;
                    (e.Item.FindControl("tdStatus2") as HtmlTableCell).Visible = false;
                    (e.Item.FindControl("tdStatus3") as HtmlTableCell).Visible = false;
                }
                else if (_commentstatus == 2)
                {
                    (e.Item.FindControl("tdStatus1") as HtmlTableCell).Visible = false;
                    (e.Item.FindControl("tdStatus2") as HtmlTableCell).Visible = true;
                    (e.Item.FindControl("tdStatus3") as HtmlTableCell).Visible = false;
                }
                else
                {
                    (e.Item.FindControl("tdStatus1") as HtmlTableCell).Visible = false;
                    (e.Item.FindControl("tdStatus2") as HtmlTableCell).Visible = false;
                    (e.Item.FindControl("tdStatus3") as HtmlTableCell).Visible = true;
                }
            }
        }
    }
}