using System;
using System.Collections.Generic;
namespace weipin.admin
{
    public partial class CreateGoodsIndex : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        { }
        protected void btnCreateIndex_Click(object sender, EventArgs e)
        {
            CreateAllGoodsIndex();
        }
        /// <summary>
        /// 创建索引
        /// </summary>
        private void CreateAllGoodsIndex()
        {
            BLL.SE bs = new weipin.BLL.SE();
            bs.CreateAllGoodsIndex(ckbIndexOptimize.Checked);
            ClientScript.RegisterStartupScript(GetType(), "alert", "<script type=\"text/javascript\">alert('创建索引成功!');</script>");
        }
    }
}