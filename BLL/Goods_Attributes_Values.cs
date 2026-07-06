/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-10
 *
 * 描述: 
**************************************************************************************************/
using System.Data;
using System.Xml;
using System.Web;

namespace weipin.BLL
{
    public class Goods_Attributes_Values
    {
        public Goods_Attributes_Values()
        { }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool InsertGoods_Attributes_Values(Model.Goods_Attributes_Values mdl)
        {
            DAL.Goods_Attributes_Values dal = new DAL.Goods_Attributes_Values();
            if (dal.InsertGoods_Attributes_Values(mdl) > 0)
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
        public bool DeleteGoods_Attributes_ValuesByID(int id)
        {
            DAL.Goods_Attributes_Values dal = new DAL.Goods_Attributes_Values();
            if (dal.DeleteGoods_Attributes_ValuesByID(id) > 0)
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
        public bool UpdateGoods_Attributes_Values(Model.Goods_Attributes_Values mdl)
        {
            DAL.Goods_Attributes_Values dal = new DAL.Goods_Attributes_Values();
            if (dal.UpdateGoods_Attributes_Values(mdl) > 0)
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
        public DataTable SelectAllGoods_Attributes_Values()
        {
            DAL.Goods_Attributes_Values dal = new DAL.Goods_Attributes_Values();
            return dal.SelectAllGoods_Attributes_Values();
        }

        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Goods_Attributes_Values SelectGoods_Attributes_ValuesByID(int id)
        {
            DAL.Goods_Attributes_Values dal = new DAL.Goods_Attributes_Values();
            return dal.SelectGoods_Attributes_ValuesByID(id);
        }
        /// <summary>
        /// 生成当前商品属性和值的XML
        /// </summary>
        /// <param name="goodsid">商品ID</param>
        /// <param name="xmlattributesvalues">生成商品属性和值的XML</param>
        public void CreateGoodsAttributesValuesXML(int goodsid, string xmlattributesvalues)
        {
            if (xmlattributesvalues != "")
            {
                XmlDocument xml = new XmlDocument();
                try
                {
                    xml.LoadXml(xmlattributesvalues);
                    xml.Save(HttpContext.Current.Server.MapPath("~/xml/goods/goodsattributesvalues/" + goodsid.ToString() + ".xml"));
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}