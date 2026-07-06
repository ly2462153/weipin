/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-10
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using System.Collections.Generic;
using System.Xml;
using System.Web;
using System;

namespace weipin.BLL
{
    public class Areas
    {
        public Areas()
        { }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool InsertAreas(Model.Areas mdl)
        {
            DAL.Areas dal = new DAL.Areas();
            if (dal.InsertAreas(mdl) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteAreasByID(int id)
        {
            DAL.Areas dal = new DAL.Areas();
            if (dal.DeleteAreasByID(id) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool UpdateAreas(Model.Areas mdl)
        {
            DAL.Areas dal = new DAL.Areas();
            if (dal.UpdateAreas(mdl) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Model.Areas> SelectAllAreas()
        {
            DAL.Areas dal = new DAL.Areas();
            return dal.SelectAllAreas();
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Areas SelectAreasByID(int id)
        {
            DAL.Areas dal = new DAL.Areas();
            return dal.SelectAreasByID(id);
        }
        /// <summary>
        /// 生成区域XML
        /// </summary>
        public void CreateAreasXML()
        {
            string _str = string.Empty;
            DAL.Areas da = new weipin.DAL.Areas();
            List<Model.Areas> lma = da.SelectAllAreas();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?><areas>");
            List<Model.Areas> lmaprovince = lma.FindAll(delegate(Model.Areas ma) { return ma.ParentID == 0; });
            for (int i = 0; i < lmaprovince.Count; i++)
            {
                sb.Append("<pr ai=\"" + lmaprovince[i].AreaID.ToString() + "\" an=\"" + lmaprovince[i].AreaName.ToString() + "\">");
                List<Model.Areas> lmacity = lma.FindAll(delegate(Model.Areas ma) { return ma.ParentID == lmaprovince[i].AreaID; });
                for (int j = 0; j < lmacity.Count; j++)
                {
                    sb.Append("<ct ai=\"" + lmacity[j].AreaID.ToString() + "\" an=\"" + lmacity[j].AreaName.ToString() + "\">");
                    List<Model.Areas> lmaarea = lma.FindAll(delegate(Model.Areas ma) { return ma.ParentID == lmacity[j].AreaID; });
                    for (int k = 0; k < lmaarea.Count; k++)
                    {
                        sb.Append("<ar ai=\"" + lmaarea[k].AreaID.ToString() + "\" an=\"" + lmaarea[k].AreaName.ToString() + "\" fr=\"" + lmaarea[k].Freight.ToString() + "\"/>");
                    }
                    sb.Append("</ct>");
                }
                sb.Append("</pr>");
            }
            sb.Append("</areas>");
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(sb.ToString());
                xml.Save(HttpContext.Current.Server.MapPath("~/xml/areas/areas.xml"));
            }
            catch { throw; }
        }
    }
}