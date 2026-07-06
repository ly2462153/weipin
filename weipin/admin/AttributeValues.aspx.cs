using System;
using System.Text;
using System.Collections.Generic;
using System.Xml;

namespace weipin.admin
{
    public partial class AttributeValues : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtAttributeValueNameAdd"] != null)
            {
                InsertAttributeValues();
            }
            else if (Request.Form["hidAttributeValueID"] != null)
            {
                UpdateAttributeValues();
            }
            else if (Common.Commonality.JudgeNumber(Request.QueryString["aid"], 10) && Common.Commonality.JudgeNumber(Request.QueryString["cid"], 10))
            {
                BindAttributeValues(Convert.ToInt32(Request.QueryString["aid"].ToString()), Convert.ToInt32(Request.QueryString["cid"].ToString()));
            }
            else
            {
                Response.Redirect("Cagegories.aspx");
            }
        }
        /// <summary>
        /// 添加属性值
        /// </summary>
        private void InsertAttributeValues()
        {
            Model.AttributeValues mav = new weipin.Model.AttributeValues();
            mav.AttributeValueName = Request.Form["txtAttributeValueNameAdd"].ToString();
            mav.AttributeID = Convert.ToInt32(Request.Form["hidAttributeID"].ToString());
            BLL.AttributeValues bav = new weipin.BLL.AttributeValues();
            if (bav.InsertAttributeValues(mav))
            {
                BLL.Attributes ba = new weipin.BLL.Attributes();
                ba.CreateAttributesXML(Convert.ToInt32(Request.Form["hidCategoryID"].ToString()));
                Response.Write("<script>alert('添加成功！');location=location;</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！');location=location;</script>");
            }
        }
        /// <summary>
        /// 修改属性值
        /// </summary>
        private void UpdateAttributeValues()
        {
            Model.AttributeValues mav = new weipin.Model.AttributeValues();
            mav.AttributeValueID = Convert.ToInt32(Request.Form["hidAttributeValueID"].ToString());
            if (Request.Form["txtAttributeValueNameUpdate"] != null)
            {
                mav.AttributeValueName = Request.Form["txtAttributeValueNameUpdate"].ToString();
            }
            BLL.AttributeValues bav = new weipin.BLL.AttributeValues();
            if (bav.UpdateAttributeValues(mav))
            {
                BLL.Attributes ba = new weipin.BLL.Attributes();
                ba.CreateAttributesXML(Convert.ToInt32(Request.Form["hidCategoryID2"].ToString()));
                Response.Write("<script>alert('更新成功！');location=location;</script>");
            }
            else
            {
                Response.Write("<script>alert('更新失败！');location=location;</script>");
            }
        }
        /// <summary>
        /// 绑定属性值
        /// <param name="_aid">属性ID</param>
        /// <param name="_cid">CategoryID</param>
        /// </summary>
        private void BindAttributeValues(int _aid, int _cid)
        {
            hidAttributeID.Value = _aid.ToString();
            hidCategoryID.Value = _cid.ToString();
            hidCategoryID2.Value = _cid.ToString();
            string _path = Server.MapPath("~/xml/attributes/" + _cid + ".xml");
            if (System.IO.File.Exists(_path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Server.MapPath("~/xml/attributes/" + _cid + ".xml"));
                XmlNodeList nodelist = doc.DocumentElement.ChildNodes;
                if (nodelist.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        string _attributename = nodelist[i].Attributes["name"].Value;
                        string _attributeid = nodelist[i].Attributes["value"].Value;
                        if (_attributeid == _aid.ToString())
                        {
                            XmlNode _node = nodelist[i];
                            for (int j = 0; j < _node.ChildNodes.Count; j++)
                            {
                                string _attributevaluename = _node.ChildNodes[j].Attributes["name"].Value;
                                string _attributevalueid = _node.ChildNodes[j].Attributes["value"].Value;
                                sb.Append("<li><span id=\"sp" + _attributevalueid + "\">" + _attributevaluename + "</span><div class=\"oprt\">");
                                sb.Append("<img src=\"img/edit.jpg\"  title=\"修改\"/>&nbsp;<img src=\"img/del16.jpg\" title=\"删除\"/>");
                                sb.Append("</div></li>");
                            }
                            break;
                        }
                    }
                    this.ulTree.InnerHtml = sb.ToString();
                }
            }
        }
    }
}