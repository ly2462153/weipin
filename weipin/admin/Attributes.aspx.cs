using System;
using System.Text;
using System.Collections.Generic;
using System.Xml;

namespace weipin.admin
{
    public partial class Attributes : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtAttributeNameAdd"] != null)
            {
                InsertAttributes();
            }
            else if (Request.Form["hidAttributeID"] != null)
            {
                UpdateAttributes();
            }
            else if (Common.Commonality.JudgeNumber(Request.QueryString["cid"], 10))
            {
                hidCategoryID.Value = Request.QueryString["cid"].ToString();
                hidCategoryID2.Value = Request.QueryString["cid"].ToString();
                BindAttributes(Convert.ToInt32(Request.QueryString["cid"].ToString()));
            }
            else
            {
                Response.Redirect("Cagegories.aspx");
            }
        }
        /// <summary>
        /// 添加属性
        /// </summary>
        private void InsertAttributes()
        {
            Model.Attributes ma = new weipin.Model.Attributes();
            ma.AttributeName = Request.Form["txtAttributeNameAdd"].ToString().Replace("<", "＜").Replace("&", "＆");
            ma.CategoryID = Convert.ToInt32(Request.Form["hidCategoryID"].ToString());
            BLL.Attributes ba = new weipin.BLL.Attributes();
            if (ba.InsertAttributes(ma))
            {
                ba.CreateAttributesXML(ma.CategoryID);
                Response.Write("<script>alert('添加成功！');location=location;</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！');location=location;</script>");
            }
        }
        /// <summary>
        /// 修改属性
        /// </summary>
        private void UpdateAttributes()
        {
            Model.Attributes ma = new weipin.Model.Attributes();
            ma.AttributeID = Convert.ToInt32(Request.Form["hidAttributeID"].ToString());
            if (Request.Form["txtAttributeNameUpdate"] != null)
            {
                ma.AttributeName = Request.Form["txtAttributeNameUpdate"].ToString().Replace("<", "＜").Replace("&", "＆");
            }
            BLL.Attributes ba = new weipin.BLL.Attributes();
            if (ba.UpdateAttributes(ma))
            {
                ba.CreateAttributesXML(Convert.ToInt32(Request.Form["hidCategoryID2"].ToString()));
                Response.Write("<script>alert('更新成功！');location=location;</script>");
            }
            else
            {
                Response.Write("<script>alert('更新失败！');location=location;</script>");
            }
        }
        /// <summary>
        /// 绑定属性
        /// <param name="_cid">分类ID</param>
        /// </summary>
        private void BindAttributes(int _cid)
        {
            string _path = Server.MapPath("~/xml/attributes/" + _cid + ".xml");
            if (System.IO.File.Exists(_path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_path);
                XmlNodeList nodelist = doc.DocumentElement.ChildNodes;
                if (nodelist.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        string _attributeid = nodelist[i].Attributes["value"].Value;
                        string _attributename = nodelist[i].Attributes["name"].Value;
                        sb.Append("<li><span id=\"sp" + _attributeid + "\">" + _attributename + "</span><div class=\"oprt\">");
                        sb.Append("<img src=\"img/editattribute.jpg\" title=\"编辑属性值\"/>&nbsp;<img src=\"img/edit.jpg\"  title=\"修改\"/>&nbsp;<img src=\"img/del16.jpg\" title=\"删除\"/>");
                        sb.Append("</div></li>");
                    }
                    this.ulTree.InnerHtml = sb.ToString();
                }
            }
        }
    }
}