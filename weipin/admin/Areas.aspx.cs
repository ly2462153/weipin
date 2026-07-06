using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace weipin.admin
{
    public partial class Areas : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtRootAreaName"] != null) { InsertRootAreas(); }
            else if (Request.Form["hidAreaID"] != null)
            {
                if (Request.Form["btnAddSubclass"].ToString() == "添加") { InsertAreas(); } else { UpdateAreas(); }
            }
            else { BindAreas(); }
        }
        /// <summary>
        /// 添加根区域
        /// </summary>
        private void InsertRootAreas()
        {
            Model.Areas ma = new weipin.Model.Areas();
            ma.ParentID = 0;
            ma.AreaName = Request.Form["txtRootAreaName"].ToString().Replace("<", "＜").Replace("&", "＆");
            BLL.Areas ba = new weipin.BLL.Areas();
            if (ba.InsertAreas(ma)) { Response.Write("<script>alert('添加成功！');location=location;</script>"); }
            else { Response.Write("<script>alert('添加失败！');location=location;</script>"); }
        }
        /// <summary>
        /// 添加区域
        /// </summary>
        private void InsertAreas()
        {
            Model.Areas ma = new weipin.Model.Areas();
            ma.ParentID = Convert.ToInt32(Request.Form["hidAreaID"].ToString());
            ma.AreaName = Request.Form["txtAreaName"].ToString().Replace("<", "＜").Replace("&", "＆");
            if (Request.Form["txtFreight"] != null) { ma.Freight = Convert.ToInt16(Request.Form["txtFreight"].ToString()); }
            BLL.Areas ba = new weipin.BLL.Areas();
            if (ba.InsertAreas(ma))
            {
                ba.CreateAreasXML();
                Response.Write("<script>alert('添加成功！');location=location;</script>");
            }
            else { Response.Write("<script>alert('添加失败！');location=location;</script>"); }
        }
        /// <summary>
        /// 修改区域
        /// </summary>
        private void UpdateAreas()
        {
            Model.Areas ma = new weipin.Model.Areas();
            ma.AreaID = Convert.ToInt32(Request.Form["hidAreaID"].ToString());
            if (Request.Form["txtAreaName"] != null) { ma.AreaName = Request.Form["txtAreaName"].ToString().Replace("<", "＜").Replace("&", "＆"); }
            if (Request.Form["txtFreight"] != null) { ma.Freight = Convert.ToInt16(Request.Form["txtFreight"].ToString()); }
            BLL.Areas ba = new weipin.BLL.Areas();
            if (ba.UpdateAreas(ma))
            {
                ba.CreateAreasXML();
                Response.Write("<script>alert('更新成功！');location=location;</script>");
            }
            else { Response.Write("<script>alert('更新失败！');location=location;</script>"); }
        }
        /// <summary>
        /// 绑定所有区域
        /// </summary>
        private void BindAreas()
        {
            BLL.Areas ba = new weipin.BLL.Areas();
            List<Model.Areas> lma = new List<weipin.Model.Areas>();
            lma = ba.SelectAllAreas();
            if (lma != null && lma.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                List<Model.Areas> lma2 = lma.FindAll(delegate(Model.Areas ma) { return ma.ParentID == 0; });
                if (lma2.Count > 0)
                {
                    for (int i = 0; i < lma2.Count; i++)
                    {
                        sb.Append("<li><span id=\"sp" + lma2[i].AreaID.ToString() + "\">" + lma2[i].AreaName + "</span><div class=\"oprt\">");
                        sb.Append("<img src=\"img/add.jpg\" title=\"添加子区域\"/>&nbsp;<img src=\"img/edit.jpg\"  title=\"修改\"/>&nbsp;<img src=\"img/del16.jpg\" title=\"删除\"/>");
                        sb.Append("</div>");
                        BindSecondArea(sb, lma, Convert.ToInt32(lma2[i].AreaID.ToString()), Convert.ToInt32(lma2[i].ParentID.ToString()));
                        sb.Append("</li>");
                    }
                    this.ulTree.InnerHtml = sb.ToString();
                }
            }
        }
        /// <summary>
        /// 绑定第二级目录
        /// <param name="sb"></param>
        /// <param name="lmc"></param>
        /// <param name="iPTID">父级ID</param>
        /// <param name="iPTPTID">爷爷级ID</param>
        /// </summary>
        private void BindSecondArea(StringBuilder sb, List<Model.Areas> lma, int iPTID, int iPTPTID)
        {
            List<Model.Areas> lma2 = lma.FindAll(delegate(Model.Areas mc) { return mc.ParentID == iPTID; });
            if (lma2.Count > 0)
            {
                sb.Append("<ul>");
                for (int i = 0; i < lma2.Count; i++)
                {
                    sb.Append("<li><span id=\"sp" + lma2[i].AreaID.ToString() + "\">" + lma2[i].AreaName + "</span><div class=\"oprt\">");
                    if (iPTPTID == 0)
                    {
                        sb.Append("<img src=\"img/add.jpg\" title=\"添加子区域\"/><input type=\"hidden\" value=\"3\"/>&nbsp;");
                        sb.Append("<img src=\"img/edit.jpg\" title=\"修改\"/>&nbsp;");
                    }
                    else { sb.Append("<img src=\"img/edit.jpg\" title=\"修改\"/><input type=\"hidden\" value=\"3\"/><input type=\"hidden\" value=\"" + lma2[i].Freight + "\"/>&nbsp;"); }
                    sb.Append("<img src=\"img/del16.jpg\" title=\"删除\"/>");
                    sb.Append("</div>");
                    BindSecondArea(sb, lma, Convert.ToInt32(lma2[i].AreaID.ToString()), Convert.ToInt32(lma2[i].ParentID.ToString()));
                    sb.Append("</li>");
                }
                sb.Append("</ul>");
            }
        }
    }
}