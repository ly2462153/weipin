/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-10
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Web;

namespace weipin.BLL
{
    public class Sizes
    {
        public Sizes()
        { }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool InsertSizes(Model.Sizes mdl)
        {
            DAL.Sizes dal = new DAL.Sizes();
            if (dal.InsertSizes(mdl) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteSizesByID(int id)
        {
            DAL.Sizes dal = new DAL.Sizes();
            if (dal.DeleteSizesByID(id) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool UpdateSizes(Model.Sizes mdl)
        {
            DAL.Sizes dal = new DAL.Sizes();
            if (dal.UpdateSizes(mdl) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Model.Sizes> SelectAllSizes()
        {
            DAL.Sizes dal = new DAL.Sizes();
            return dal.SelectAllSizes();
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Sizes SelectSizesByID(int id)
        {
            DAL.Sizes dal = new DAL.Sizes();
            return dal.SelectSizesByID(id);
        }
        /// <summary>
        /// 查询尺寸列表
        /// </summary>
        /// <param name="_nowpage">当前页</param>
        /// <param name="_perpage">每页条数</param>
        /// <returns></returns>
        public DataSet SelectSizesOfPaging(int _nowpage, int _perpage)
        {
            string[] _arr = Common.Pagination.CountStartEnd(_nowpage, _perpage);
            DAL.Sizes ds = new weipin.DAL.Sizes();
            return ds.SelectSizesOfPaging(Convert.ToInt16(_arr[0]), Convert.ToInt16(_arr[1]));
        }
        /// <summary>
        /// 生成尺码XML
        /// </summary>
        public void CreateSizesXML()
        {
            string _str = string.Empty;
            DAL.Sizes ds = new weipin.DAL.Sizes();
            List<Model.Sizes> lms = ds.SelectAllSizes();
            XmlDocument xml = new XmlDocument();
            _str += "<?xml version=\"1.0\" encoding=\"utf-8\" ?><sizes>";
            for (int i = 0; i < lms.Count; i++)
            {
                _str += "<size name=\"" + lms[i].SizeName + "\" value=\"" + lms[i].SizeID.ToString() + "\"/>";
            }
            _str += "</sizes>";
            try
            {
                xml.LoadXml(_str);
                xml.Save(HttpContext.Current.Server.MapPath("~/xml/sizes.xml"));
            }
            catch { throw; }
        }
        /// <summary>
        /// 生成当前商品的尺码XML
        /// <param name="goodsid">商品ID</param>
        /// <param name="_xmlsizes">生成尺码的XML</param>
        /// </summary>
        public void CreateSizesXML(int goodsid, string xmlsizes)
        {
            if (xmlsizes != "")
            {
                XmlDocument xml = new XmlDocument();
                try
                {
                    xml.LoadXml(xmlsizes);
                    xml.Save(HttpContext.Current.Server.MapPath("~/xml/goods/goodssizes/" + goodsid.ToString() + ".xml"));
                }
                catch { throw; }
            }
        }
        /// <summary>
        /// 获取商品当前尺码的库存和库存补给线
        /// </summary>
        /// <param name="gid">商品ID</param>
        /// <param name="sizeid">尺码ID</param>
        /// <returns></returns>
        public int[] GetGoodsIvtSL(int gid, int sizeid)
        {
            int[] _sizeivtsl = new int[2];
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/xml/goods/goodssizes/" + gid.ToString() + ".xml"));
            XmlNodeList nodelist = doc.GetElementsByTagName("size");
            if (nodelist.Count > 0)
            {
                string _str = string.Empty;
                for (int i = 0; i < nodelist.Count; i++)
                {
                    if (nodelist[i].Attributes["value"].Value == sizeid.ToString())
                    {
                        _sizeivtsl[0] = Convert.ToInt32(nodelist[i].Attributes["ivt"].Value);
                        _sizeivtsl[1] = Convert.ToInt32(nodelist[i].Attributes["sl"].Value);
                        break;
                    }
                }
            }
            return _sizeivtsl;
        }
    }
}