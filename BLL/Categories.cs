/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-10
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using System.Collections.Generic;
using System;
using System.Web;
using System.Web.Caching;
using System.Xml;
using System.Text;

namespace weipin.BLL
{
    public class Categories
    {
        public Categories()
        { }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool InsertCategories(Model.Categories mdl)
        {
            DAL.Categories dal = new DAL.Categories();
            if (dal.InsertCategories(mdl) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteCategoriesByID(int id)
        {
            DAL.Categories dal = new DAL.Categories();
            if (dal.DeleteCategoriesByID(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool UpdateCategories(Model.Categories mdl)
        {
            DAL.Categories dal = new DAL.Categories();
            if (dal.UpdateCategories(mdl) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Model.Categories> SelectAllCategories()
        {
            DAL.Categories dal = new DAL.Categories();
            return dal.SelectAllCategories();
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Categories SelectCategoriesByID(int id)
        {
            DAL.Categories dal = new DAL.Categories();
            return dal.SelectCategoriesByID(id);
        }
        /// <summary>
        /// 生成分类XML
        /// </summary>
        public void CreateCategoriesXML()
        {
            StringBuilder sb = new StringBuilder();
            DAL.Categories dc = new weipin.DAL.Categories();
            List<Model.Categories> lmc = dc.SelectAllCategories();
            List<Model.Categories> lmc1 = lmc.FindAll(delegate(Model.Categories ma) { return ma.ParentID == 0; });
            if (lmc1.Count > 0)
            {
                XmlDocument xml = new XmlDocument();
                sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?><categories>");
                for (int i = 0; i < lmc1.Count; i++)
                {
                    sb.Append("<category1 name=\"" + lmc1[i].CategoryName + "\" value=\"" + lmc1[i].CategoryID.ToString() + "\" ishighlight=\"" + lmc1[i].IsHighlight + "\" remarks=\"" + lmc1[i].Remarks + "\">");
                    List<Model.Categories> lmc2 = lmc.FindAll(delegate(Model.Categories ma) { return ma.ParentID == lmc1[i].CategoryID; });
                    for (int j = 0; j < lmc2.Count; j++)
                    {
                        sb.Append("<category2 name=\"" + lmc2[j].CategoryName + "\" value=\"" + lmc2[j].CategoryID.ToString() + "\" ishighlight=\"" + lmc2[j].IsHighlight + "\" remarks=\"" + lmc2[j].Remarks + "\">");
                        List<Model.Categories> lmc3 = lmc.FindAll(delegate(Model.Categories ma) { return ma.ParentID == lmc2[j].CategoryID; });
                        for (int k = 0; k < lmc3.Count; k++)
                        {
                            sb.Append("<category3 name=\"" + lmc3[k].CategoryName + "\" value=\"" + lmc3[k].CategoryID.ToString() + "\" ishighlight=\"" + lmc3[k].IsHighlight + "\" remarks=\"" + lmc3[k].Remarks + "\"/>");
                        }
                        sb.Append("</category2>");
                    }
                    sb.Append("</category1>");
                }
                sb.Append("</categories>");
                try
                {
                    xml.LoadXml(sb.ToString());
                    xml.Save(HttpContext.Current.Server.MapPath("~/xml/categories.xml"));
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}