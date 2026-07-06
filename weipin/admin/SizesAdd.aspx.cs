using System;

namespace weipin.admin
{
    public partial class SizesAdd : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtSizeName"] != null)
            {
                InsertSizes();
            }
        }
        /// <summary>
        /// 添加尺码
        /// </summary>
        private void InsertSizes()
        {
            Model.Sizes ms = new weipin.Model.Sizes();
            ms.SizeName = Request.Form["txtSizeName"].ToString().Replace("<", "＜").Replace("&", "＆");
            BLL.Sizes bs = new weipin.BLL.Sizes();
            if (bs.InsertSizes(ms))
            {
                bs.CreateSizesXML();
                Response.Write("<script>alert('添加成功！');location.href='SizesList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！');location.href='SizesList.aspx';</script>");
            }
        }
    }
}