using System;
using System.Data;
using System.Collections;

namespace weipin.admin
{
    public partial class SizesUpdate : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtSizeName"] != null)
            {
                UpdateSizes();
            }
            else if (Common.Commonality.JudgeNumber(Request.QueryString["sid"], 10))
            {
                BindSizes(Convert.ToInt32(Request.QueryString["sid"].ToString()));
            }
            else
            {
                Response.Redirect("SizesList.aspx");
            }
        }
        /// <summary>
        /// 绑定
        /// </summary>
        /// <param name="_sid">SizeID</param>
        public void BindSizes(int _sid)
        {
            BLL.Sizes bs = new weipin.BLL.Sizes();
            Model.Sizes ms = bs.SelectSizesByID(_sid);
            if (ms.SizeID != 0)
            {
                hidSizeID.Value = ms.SizeID.ToString();
                txtSizeName.Value = ms.SizeName;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void UpdateSizes()
        {
            Model.Sizes ms = new weipin.Model.Sizes();
            ms.SizeID = Convert.ToInt16(Request.Form["hidSizeID"].ToString());
            ms.SizeName = Request.Form["txtSizeName"].ToString().Replace("<", "＜").Replace("&", "＆");
            BLL.Sizes bs = new weipin.BLL.Sizes();
            if (bs.UpdateSizes(ms))
            {
                bs.CreateSizesXML();
                Response.Write("<script>alert('修改成功！');location.href='SizesList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！');location.href='SizesList.aspx';</script>");
            }
        }
    }
}