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
    public class Couriers
    {
        public Couriers()
        { }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool InsertCouriers(Model.Couriers mdl)
        {
            DAL.Couriers dal = new DAL.Couriers();
            if (dal.InsertCouriers(mdl) > 0)
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
        public bool DeleteCouriersByID(int id)
        {
            DAL.Couriers dal = new DAL.Couriers();
            if (dal.DeleteCouriersByID(id) > 0)
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
        public bool UpdateCouriers(Model.Couriers mdl)
        {
            DAL.Couriers dal = new DAL.Couriers();
            if (dal.UpdateCouriers(mdl) > 0)
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
        /// <param name="_cid"></param>
        /// <returns></returns>
        public bool LogoutCouriersByID(int _cid)
        {
            DAL.Couriers dc = new weipin.DAL.Couriers();
            if (dc.UpdateCouriersIsLeftByID(_cid) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Couriers SelectCouriersByID(int id)
        {
            DAL.Couriers dal = new DAL.Couriers();
            return dal.SelectCouriersByID(id);
        }
        /// <summary>
        /// 查询快递员列表
        /// </summary>
        /// <param name="_nowpage">当前页</param>
        /// <param name="_perpage">每页条数</param>
        /// <returns></returns>
        public DataSet SelectCouriersOfPaging(int _nowpage, int _perpage)
        {
            string[] _arr = Common.Pagination.CountStartEnd(_nowpage, _perpage);
            DAL.Couriers dc = new weipin.DAL.Couriers();
            return dc.SelectCouriersOfPaging(Convert.ToInt16(_arr[0]), Convert.ToInt16(_arr[1]));
        }
        /// <summary>
        /// 生成快递员XML
        /// </summary>
        public void CreateCouriersXML()
        {
            string _str = string.Empty;
            DAL.Couriers dc = new weipin.DAL.Couriers();
            List<Model.Couriers> lmc = dc.SelectAllCouriers();
            XmlDocument xml = new XmlDocument();
            _str += "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Couriers>";
            for (int i = 0; i < lmc.Count; i++)
            {
                _str += "<Courier><CourierID>" + lmc[i].CourierID.ToString() + "</CourierID><AreaID>" + lmc[i].AreaID.ToString() + "</AreaID><CourierName>" + lmc[i].CourierName.ToString() + "</CourierName></Courier>";
            }
            _str += "</Couriers>";
            try
            {
                xml.LoadXml(_str);
                xml.Save(HttpContext.Current.Server.MapPath("~/xml/couriers/couriers.xml"));
            }
            catch
            {
                throw;
            }
        }
    }
}