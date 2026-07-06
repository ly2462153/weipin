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

namespace weipin.BLL
{
    public class Attributes
    {
        public Attributes()
        { }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool InsertAttributes(Model.Attributes mdl)
        {
            DAL.Attributes dal = new DAL.Attributes();
            if (dal.InsertAttributes(mdl) > 0)
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
        public bool DeleteAttributesByID(int id)
        {
            DAL.Attributes dal = new DAL.Attributes();
            if (dal.DeleteAttributesByID(id) > 0)
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
        public bool UpdateAttributes(Model.Attributes mdl)
        {
            DAL.Attributes dal = new DAL.Attributes();
            if (dal.UpdateAttributes(mdl) > 0)
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
        public DataTable SelectAllAttributes()
        {
            DAL.Attributes dal = new DAL.Attributes();
            return dal.SelectAllAttributes();
        }

        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Attributes SelectAttributesByID(int id)
        {
            DAL.Attributes dal = new DAL.Attributes();
            return dal.SelectAttributesByID(id);
        }
        /// <summary>
        /// 生成属性和属性值XML
        /// <param name="_cid">CategoryID</param>
        /// </summary>
        public void CreateAttributesXML(int _cid)
        {
            string _str = string.Empty;
            DAL.Attributes da = new weipin.DAL.Attributes();
            List<Model.Attributes> lma = da.SelectAttributesAndValuesByCategoryID(_cid);
            XmlDocument xml = new XmlDocument();
            _str += "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Attributes>";
            for (int i = 0; i < lma.Count; i++)
            {
                if (i == 0)
                {
                    _str += "<Attribute name=\"" + lma[i].AttributeName + "\" value=\"" + lma[i].AttributeID.ToString() + "\">";
                }
                else
                {
                    if (lma[i].AttributeID != lma[i - 1].AttributeID)
                    {
                        _str += "<Attribute name=\"" + lma[i].AttributeName + "\" value=\"" + lma[i].AttributeID.ToString() + "\">";
                    }
                }
                if (lma[i].AttributeValueID != 0)
                {
                    _str += "<AttributeValues name=\"" + lma[i].AttributeValueName + "\" value=\"" + lma[i].AttributeValueID.ToString() + "\"/>";
                }
                if (i == lma.Count - 1)
                {
                    _str += "</Attribute>";
                }
                else
                {
                    if (lma[i].AttributeID != lma[i + 1].AttributeID)
                    {
                        _str += "</Attribute>";
                    }
                }
            }
            _str += "</Attributes>";
            try
            {
                xml.LoadXml(_str);
                xml.Save(HttpContext.Current.Server.MapPath("~/xml/attributes/" + _cid + ".xml"));
            }
            catch
            {
                throw;
            }
        }
    }
}