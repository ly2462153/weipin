using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Xml;

namespace weipin.admin
{
    public partial class Cagegories : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtRootCategoryName"] != null)
            {
                InsertRootCagegories();
            }
            else if (Request.Form["hidCategoryID"] != null)
            {
                if (Request.Form["btnAddSubclass"].ToString() == "添加")
                {
                    InsertCagegories();
                }
                else
                {
                    UpdateCagegories();
                }
            }
            else
            {
                BindCagegories();
            }
        }
        /// <summary>
        /// 添加根分类
        /// </summary>
        private void InsertRootCagegories()
        {
            Model.Categories mc = new weipin.Model.Categories();
            mc.ParentID = 0;
            mc.CategoryName = Request.Form["txtRootCategoryName"].ToString().Replace("{weipin:", "").Replace("<", "＜").Replace("&", "＆");
            if (Request.Form["rdoRootIsHighlight"].ToString() == "rdoRootIsHighlightYes")
            {
                mc.IsHighlight = true;
            }
            else
            {
                mc.IsHighlight = false;
            }
            if (Request.Form["txtRootCategoryRemarks"] != null)
            {
                if (Request.Form["txtRootCategoryRemarks"].ToString() != "")
                {
                    mc.Remarks = Request.Form["txtRootCategoryRemarks"].ToString().Replace("{weipin:", "").Replace("<", "＜").Replace("&", "＆");
                }
            }
            BLL.Categories bc = new weipin.BLL.Categories();
            if (bc.InsertCategories(mc))
            {
                bc.CreateCategoriesXML();
                Response.Write("<script>alert('添加成功！');location=location;</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！');location=location;</script>");
            }
        }
        /// <summary>
        /// 添加分类
        /// </summary>
        private void InsertCagegories()
        {
            Model.Categories mc = new weipin.Model.Categories();
            mc.ParentID = Convert.ToInt32(Request.Form["hidCategoryID"].ToString());
            mc.CategoryName = Request.Form["txtCategoryName"].ToString().Replace("{weipin:", "").Replace("<", "＜").Replace("&", "＆");
            if (Request.Form["txtRemarks"] != null)
            {
                if (Request.Form["txtRemarks"].ToString() != "")
                {
                    mc.Remarks = Request.Form["txtRemarks"].ToString().Replace("{weipin:", "").Replace("<", "＜").Replace("&", "＆");
                }
            }
            if (Request.Form["rdoIsHighlight"].ToString() == "rdoIsHighlightYes")
            {
                mc.IsHighlight = true;
            }
            else
            {
                mc.IsHighlight = false;
            }
            BLL.Categories bc = new weipin.BLL.Categories();
            if (bc.InsertCategories(mc))
            {
                bc.CreateCategoriesXML();
                Response.Write("<script>alert('添加成功！');location=location;</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！');location=location;</script>");
            }
        }
        /// <summary>
        /// 修改分类
        /// </summary>
        private void UpdateCagegories()
        {
            Model.Categories mc = new weipin.Model.Categories();
            mc.CategoryID = Convert.ToInt32(Request.Form["hidCategoryID"].ToString());
            if (Request.Form["txtCategoryName"] != null)
            {
                mc.CategoryName = Request.Form["txtCategoryName"].ToString().Replace("{weipin:", "").Replace("<", "＜").Replace("&", "＆");
            }
            mc.UpdateTime = DateTime.Now;
            if (Request.Form["txtRemarks"].ToString() != "")
            {
                mc.Remarks = Request.Form["txtRemarks"].ToString().Replace("{weipin:", "").Replace("<", "＜").Replace("&", "＆");
            }
            if (Request.Form["rdoIsHighlight"].ToString() == "rdoIsHighlightYes")
            {
                mc.IsHighlight = true;
            }
            else
            {
                mc.IsHighlight = false;
            }
            BLL.Categories bc = new weipin.BLL.Categories();
            if (bc.UpdateCategories(mc))
            {
                bc.CreateCategoriesXML();
                Response.Write("<script>alert('更新成功！');location=location;</script>");
            }
            else
            {
                Response.Write("<script>alert('更新失败！');location=location;</script>");
            }
        }
        /// <summary>
        /// 绑定所有分类
        /// </summary>
        private void BindCagegories()
        {
            string _path = Server.MapPath("~/xml/categories.xml");
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
                        string _categoryid1 = nodelist[i].Attributes["value"].Value;
                        string _categoryname1 = nodelist[i].Attributes["name"].Value;
                        string _remarks1 = nodelist[i].Attributes["remarks"].Value;
                        string _ishighlight1 = nodelist[i].Attributes["ishighlight"].Value;
                        sb.Append("<li><span id=\"sp" + _categoryid1 + "\">" + _categoryname1 + "</span><div class=\"oprt\">");
                        sb.Append("<img src=\"img/add.jpg\" title=\"添加子分类\"/>&nbsp;<img src=\"img/edit.jpg\"  title=\"修改\"/>&nbsp;<img src=\"img/del16.jpg\" title=\"删除\"/>");
                        if (_remarks1 != null)
                        {
                            sb.Append("<input type=\"hidden\" id=\"hid" + _categoryid1 + "\" value=\"" + _remarks1 + "\"/>");
                        }
                        sb.Append("<input type=\"hidden\" id=\"hidIsHighlight" + _categoryid1 + "\" value=\"" + _ishighlight1 + "\"/>");
                        sb.Append("</div>");
                        #region 第二级
                        XmlNode _node = nodelist[i];
                        if (_node.ChildNodes.Count > 0)
                        {
                            sb.Append("<ul>");
                            for (int j = 0; j < _node.ChildNodes.Count; j++)
                            {
                                string _categoryid2 = _node.ChildNodes[j].Attributes["value"].Value;
                                string _categoryname2 = _node.ChildNodes[j].Attributes["name"].Value;
                                string _remarks2 = _node.ChildNodes[j].Attributes["remarks"].Value;
                                string _ishighlight2 = _node.ChildNodes[j].Attributes["ishighlight"].Value;
                                sb.Append("<li><span id=\"sp" + _categoryid2 + "\">" + _categoryname2 + "</span><div class=\"oprt\">");
                                sb.Append("<img src=\"img/add.jpg\" title=\"添加子分类\"/>&nbsp;");
                                sb.Append("<img src=\"img/edit.jpg\" title=\"修改\"/>&nbsp;<img src=\"img/del16.jpg\" title=\"删除\"/>");
                                if (_remarks2 != null)
                                {
                                    sb.Append("<input type=\"hidden\" id=\"hid" + _categoryid2 + "\" value=\"" + _remarks2 + "\"/>");
                                }
                                sb.Append("<input type=\"hidden\" id=\"hidIsHighlight" + _categoryid2 + "\" value=\"" + _ishighlight2 + "\"/>");
                                sb.Append("</div>");
                                #region 第三级
                                XmlNode _node2 = _node.ChildNodes[j];
                                if (_node2.ChildNodes.Count > 0)
                                {
                                    sb.Append("<ul>");
                                    for (int k = 0; k < _node2.ChildNodes.Count; k++)
                                    {
                                        string _categoryid3 = _node2.ChildNodes[k].Attributes["value"].Value;
                                        string _categoryname3 = _node2.ChildNodes[k].Attributes["name"].Value;
                                        string _remarks3 = _node2.ChildNodes[k].Attributes["remarks"].Value;
                                        string _ishighlight3 = _node2.ChildNodes[k].Attributes["ishighlight"].Value;
                                        sb.Append("<li><span id=\"sp" + _categoryid3 + "\">" + _categoryname3 + "</span><div class=\"oprt\">");
                                        sb.Append("<img src=\"img/editattribute.jpg\" title=\"编辑属性\"/>&nbsp;");
                                        sb.Append("<img src=\"img/edit.jpg\" title=\"修改\"/>&nbsp;<img src=\"img/del16.jpg\" title=\"删除\"/>");
                                        if (_remarks3 != null)
                                        {
                                            sb.Append("<input type=\"hidden\" id=\"hid" + _categoryid3 + "\" value=\"" + _remarks3 + "\"/>");
                                        }
                                        sb.Append("<input type=\"hidden\" id=\"hidIsHighlight" + _categoryid3 + "\" value=\"" + _ishighlight3 + "\"/>");
                                        sb.Append("</div>");
                                        sb.Append("</li>");
                                    }
                                    sb.Append("</ul>");
                                }
                                #endregion
                                sb.Append("</li>");
                            }
                            sb.Append("</ul>");
                        }
                        #endregion
                        sb.Append("</li>");
                    }
                    this.ulTree.InnerHtml = sb.ToString();
                }
            }
        }
    }
}