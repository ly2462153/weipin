/**************************************************************************************************
 * 创建人 : 廖毅
 *
 * 创建时间 : 2011-11-10
 *
 * 描述: 
**************************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

using weipin.Common;
using System.Collections.Generic;
using weipin.Model;

namespace weipin.DAL
{
    public class Goods
    {
        public Goods() { }
        /// <summary>
        /// 查看商品名称/单价等部分信息
        /// </summary>
        /// <param name="id">GoodsID</param>
        /// <returns></returns>
        public Model.Goods SelectGoodsPartByID(int id)
        {
            try
            {
                Model.Goods mdl = new Model.Goods();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectPartByID", arr))
                {
                    while (sdr.Read())
                    {
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                        if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询商品详情
        /// </summary>
        /// <param name="id">GoodsID</param>
        /// <returns></returns>
        public Model.Goods SelectGoodsDetailByID(int id)
        {
            try
            {
                Model.Goods mdl = new Model.Goods();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectDetailByID", arr))
                {
                    while (sdr.Read())
                    {
                        mdl.CategoryID3 = Convert.ToInt32(sdr["CategoryID"].ToString());
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        if (sdr["SimilarNumber"].ToString() != "") { mdl.SimilarNumber = Convert.ToInt32(sdr["SimilarNumber"].ToString()); }
                        mdl.DifferenceKeywords = sdr["DifferenceKeywords"].ToString();
                        mdl.MarketPrice = Convert.ToDouble(sdr["MarketPrice"].ToString());
                        mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                        if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                        mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                        if (sdr["Inventory"].ToString() != "") { mdl.Inventory = Convert.ToInt32(sdr["Inventory"].ToString()); }
                        if (sdr["SupplyLine"].ToString() != "") { mdl.SupplyLine = Convert.ToInt32(sdr["SupplyLine"].ToString()); }
                        mdl.MerchantType = Convert.ToByte(sdr["MerchantType"].ToString());
                        mdl.Remarks = sdr["Remarks"].ToString();
                        mdl.WarmPrompt = sdr["WarmPrompt"].ToString();
                        mdl.IsGrounding = Convert.ToBoolean(sdr["IsGrounding"].ToString());
                        mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id">GoodsID</param>
        /// <returns></returns>
        public Model.Goods SelectGoodsByID(int id)
        {
            try
            {
                Model.Goods mdl = new Model.Goods();
                ArrayList arr = new ArrayList();
                arr.Add(id);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectByID", arr))
                {
                    while (sdr.Read())
                    {
                        mdl.CategoryID1 = Convert.ToInt32(sdr["CategoryID1"].ToString());
                        mdl.CategoryID3 = Convert.ToInt32(sdr["CategoryID3"].ToString());
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        mdl.Keywords = sdr["Keywords"].ToString();
                        if (sdr["SimilarNumber"].ToString() != "") { mdl.SimilarNumber = Convert.ToInt32(sdr["SimilarNumber"].ToString()); }
                        mdl.DifferenceKeywords = sdr["DifferenceKeywords"].ToString();
                        mdl.MarketPrice = Convert.ToDouble(sdr["MarketPrice"].ToString());
                        mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                        if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                        if (sdr["GoodsWeight"].ToString() != "") { mdl.GoodsWeight = Convert.ToDouble(sdr["GoodsWeight"].ToString()); }
                        mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                        if (sdr["Inventory"].ToString() != "") { mdl.Inventory = Convert.ToInt32(sdr["Inventory"].ToString()); }
                        if (sdr["SupplyLine"].ToString() != "") { mdl.SupplyLine = Convert.ToInt32(sdr["SupplyLine"].ToString()); }
                        mdl.MerchantType = Convert.ToByte(sdr["MerchantType"].ToString());
                        mdl.Remarks = sdr["Remarks"].ToString();
                        mdl.WarmPrompt = sdr["WarmPrompt"].ToString();
                        mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                        mdl.IsBargain = Convert.ToBoolean(sdr["IsBargain"].ToString());
                        mdl.IsCategoryPromotion = Convert.ToBoolean(sdr["IsCategoryPromotion"].ToString());
                        mdl.IsCategorySecondPromotion = Convert.ToBoolean(sdr["IsCategorySecondPromotion"].ToString());
                        mdl.IsNewRecommend = Convert.ToBoolean(sdr["IsNewRecommend"].ToString());
                        mdl.IsSeasonRecommend = Convert.ToBoolean(sdr["IsSeasonRecommend"].ToString());
                        mdl.IsGrounding = Convert.ToBoolean(sdr["IsGrounding"].ToString());
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 绑定商品库存补给线(分页)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataList<Model.Goods> SelectGoodsSupplyOfPaging(string start, string end)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(start);
                arr.Add(end);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectSupplyOfPaging", arr))
                {
                    DataList<Model.Goods> dmg = new DataList<weipin.Model.Goods>();
                    while (sdr.Read())
                    {
                        if (dmg.Total == 0) { dmg.Total = Convert.ToInt32(sdr["GoodsID"].ToString()); }
                        else
                        {
                            Model.Goods mdl = new weipin.Model.Goods();
                            mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                            mdl.GoodsName = sdr["GoodsName"].ToString();
                            mdl.MarketPrice = Convert.ToDouble(sdr["MarketPrice"].ToString());
                            mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                            if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                            if (sdr["GoodsWeight"].ToString() != "") { mdl.GoodsWeight = Convert.ToDouble(sdr["GoodsWeight"].ToString()); }
                            mdl.Inventory = Convert.ToInt32(sdr["Inventory"].ToString());
                            mdl.SupplyLine = Convert.ToInt32(sdr["SupplyLine"].ToString());
                            mdl.SalesVolume = Convert.ToInt32(sdr["SalesVolume"].ToString());
                            mdl.HitTime = Convert.ToInt32(sdr["HitTime"].ToString());
                            mdl.CollectTimes = Convert.ToInt32(sdr["CollectTimes"].ToString());
                            mdl.MerchantType = Convert.ToByte(sdr["MerchantType"].ToString());
                            mdl.IsBargain = Convert.ToBoolean(sdr["IsBargain"].ToString());
                            mdl.IsCategoryPromotion = Convert.ToBoolean(sdr["IsCategoryPromotion"].ToString());
                            mdl.IsSeasonRecommend = Convert.ToBoolean(sdr["IsSeasonRecommend"].ToString());
                            mdl.IsGrounding = Convert.ToBoolean(sdr["IsGrounding"].ToString());
                            dmg.Rows.Add(mdl);
                        }
                    }
                    return dmg;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询商品列表
        /// </summary>
        /// <param name="nowpage">当前页</param>
        /// <param name="perpage">每页条数</param>
        /// <param name="cid3">三级类别ID</param>
        /// <param name="pricecondition">价格条件拼接字符串</param>
        /// <param name="condition">条件拼接字符串</param>
        /// <param name="sort">排序拼接字符串</param>
        /// <param name="conditioncount">值拼接字符串的个数</param>
        /// <returns></returns>
        public DataList<Model.Goods> SelectGoodsByConditionOfPaging(string start, string end, string cid3, string pricecondition, string condition, string sort, string conditioncount)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(start);
                arr.Add(end);
                arr.Add(cid3);
                arr.Add(pricecondition);
                arr.Add(condition);
                arr.Add(sort);
                arr.Add(conditioncount);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectByCategoryID3ConditionOfPaging", arr))
                {
                    DataList<Model.Goods> dmg = new DataList<weipin.Model.Goods>();
                    while (sdr.Read())
                    {
                        if (dmg.Total == 0) { dmg.Total = Convert.ToInt32(sdr["GoodsID"].ToString()); }
                        else
                        {
                            Model.Goods mdl = new weipin.Model.Goods();
                            mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                            mdl.GoodsName = sdr["GoodsName"].ToString();
                            mdl.MarketPrice = Convert.ToDouble(sdr["MarketPrice"].ToString());
                            mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                            if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                            mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                            dmg.Rows.Add(mdl);
                        }
                    }
                    return dmg;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询商品列表
        /// </summary>
        /// <param name="nowpage">当前页</param>
        /// <param name="perpage">每页条数</param>
        /// <param name="cid2">二级类别ID</param>
        /// <param name="pricecondition">价格条件拼接字符串</param>
        /// <param name="sort">排序拼接字符串</param>
        /// <returns></returns>
        public DataList<Model.Goods> SelectGoodsByConditionOfPaging(string start, string end, string cid2, string pricecondition, string sort)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(start);
                arr.Add(end);
                arr.Add(cid2);
                arr.Add(pricecondition);
                arr.Add(sort);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectByCategoryID2ConditionOfPaging", arr))
                {
                    DataList<Model.Goods> dmg = new DataList<weipin.Model.Goods>();
                    while (sdr.Read())
                    {
                        if (dmg.Total == 0) { dmg.Total = Convert.ToInt32(sdr["GoodsID"].ToString()); }
                        else
                        {
                            Model.Goods mdl = new weipin.Model.Goods();
                            mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                            mdl.GoodsName = sdr["GoodsName"].ToString();
                            mdl.MarketPrice = Convert.ToDouble(sdr["MarketPrice"].ToString());
                            mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                            if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                            mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                            dmg.Rows.Add(mdl);
                        }
                    }
                    return dmg;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询同类商品/浏览过此商品的用户还购买过
        /// </summary>
        /// <param name="cid3">分类ID</param>
        /// <param name="gid">商品ID</param>
        /// <returns></returns>
        public List<Model.Goods> SelectGoodsSimilarBrowerBuyByCID(int cid3, int gid)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(cid3);
                arr.Add(gid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectSimilarBrowerBuyByCID", arr))
                {
                    List<Model.Goods> lmg = new List<weipin.Model.Goods>();
                    while (sdr.Read())
                    {
                        Model.Goods mdl = new weipin.Model.Goods();
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                        if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                        mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                        lmg.Add(mdl);
                    }
                    return lmg;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询购物车
        /// </summary>
        /// <param name="sql">构造查询购物车的GoodsID集合SQL拼接</param>
        /// <returns></returns>
        public List<Model.Goods> SelectGoodsShoppingCart(string sql)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(sql);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectShoppingCart", arr))
                {
                    List<Model.Goods> lmg = new List<weipin.Model.Goods>();
                    while (sdr.Read())
                    {
                        Model.Goods mdl = new weipin.Model.Goods();
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        mdl.MarketPrice = Convert.ToDouble(sdr["MarketPrice"].ToString());
                        mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                        if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                        mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                        lmg.Add(mdl);
                    }
                    return lmg;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询购物车
        /// </summary>
        /// <param name="condition">构造的GoodsID集合拼接</param>
        /// <returns></returns>
        public List<Model.Goods> SelectGoodsShoppingCartByCondition(string condition)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(condition);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectShoppingCartByCondition", arr))
                {
                    List<Model.Goods> lmg = new List<weipin.Model.Goods>();
                    while (sdr.Read())
                    {
                        Model.Goods mdl = new weipin.Model.Goods();
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                        if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                        if (sdr["Inventory"].ToString() != "") { mdl.Inventory = Convert.ToInt32(sdr["Inventory"].ToString()); }
                        if (sdr["SupplyLine"].ToString() != "") { mdl.SupplyLine = Convert.ToInt32(sdr["SupplyLine"].ToString()); }
                        lmg.Add(mdl);
                    }
                    return lmg;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 绑定商品信息并判断评论权限
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="ogid">OrdersGoodsID</param>
        /// <returns></returns>
        public Model.Goods SelectGoodsAndJudgeCommentRightByOGID(string loginid, int ogid)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                arr.Add(ogid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectAndJudgeCommentRightByOGID", arr))
                {
                    Model.Goods mdl = new weipin.Model.Goods();
                    while (sdr.Read())
                    {
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        if (sdr["SimilarNumber"].ToString() != "") { mdl.SimilarNumber = Convert.ToInt32(sdr["SimilarNumber"].ToString()); }
                        if (sdr["Price"].ToString() != "") { mdl.Price = Convert.ToDouble(sdr["Price"].ToString()); }
                        if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                        mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 绑定商品信息并判断评论权限
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="gid">商品ID</param>
        /// <returns></returns>
        public Model.Goods SelectGoodsAndJudgeCommentRightByGoodsID(string loginid, int gid)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(loginid);
                arr.Add(gid);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectAndJudgeCommentRightByGoodsID", arr))
                {
                    Model.Goods mdl = new weipin.Model.Goods();
                    while (sdr.Read())
                    {
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        if (sdr["SimilarNumber"].ToString() != "") { mdl.SimilarNumber = Convert.ToInt32(sdr["SimilarNumber"].ToString()); }
                        if (sdr["Price"].ToString() != "") { mdl.Price = Convert.ToDouble(sdr["Price"].ToString()); }
                        if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                        mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                        if (sdr["OrdersGoodsID"].ToString() != "") { mdl.OrdersGoodsID = Convert.ToInt32(sdr["OrdersGoodsID"].ToString()); }
                    }
                    return mdl;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 绑定新品上架列表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<Model.Goods> SelectGoodsNewPaging(string start, string end)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(start);
                arr.Add(end);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectNewPaging", arr))
                {
                    List<Model.Goods> lmg = new List<weipin.Model.Goods>();
                    while (sdr.Read())
                    {
                        Model.Goods mdl = new weipin.Model.Goods();
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        mdl.MarketPrice = Convert.ToDouble(sdr["MarketPrice"].ToString());
                        mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                        if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                        mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                        lmg.Add(mdl);
                    }
                    return lmg;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 绑定特惠抢购列表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataList<Model.Goods> SelectGoodsDiscountPaging(string start, string end)
        {
            try
            {
                ArrayList arr = new ArrayList();
                arr.Add(start);
                arr.Add(end);
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectDiscountPaging", arr))
                {
                    DataList<Model.Goods> dmg = new DataList<weipin.Model.Goods>();
                    while (sdr.Read())
                    {
                        if (dmg.Total == 0) { dmg.Total = Convert.ToInt32(sdr["GoodsID"].ToString()); }
                        else
                        {
                            Model.Goods mdl = new weipin.Model.Goods();
                            mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                            mdl.GoodsName = sdr["GoodsName"].ToString();
                            mdl.MarketPrice = Convert.ToDouble(sdr["MarketPrice"].ToString());
                            mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                            if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                            mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                            dmg.Rows.Add(mdl);
                        }
                    }
                    return dmg;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询分类商品页面数据
        /// </summary>
        /// <param name="sql">拼接的查询SQL</param>
        /// <returns></returns>
        public List<Model.Goods> SelectCategoryGoodsBySQL(string sql)
        {
            try
            {
                using (SqlDataReader sdr = SqlData.SelectDataReader(sql))
                {
                    List<Model.Goods> lmg = new List<weipin.Model.Goods>();
                    while (sdr.Read())
                    {
                        Model.Goods mdl = new weipin.Model.Goods();
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        mdl.MarketPrice = Convert.ToDouble(sdr["MarketPrice"].ToString());
                        mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                        if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                        mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                        if (sdr["CategoryID"].ToString() != "") { mdl.CategoryID2 = Convert.ToInt32(sdr["CategoryID"].ToString()); }
                        lmg.Add(mdl);
                    }
                    return lmg;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询首页商品
        /// </summary>
        /// <returns></returns>
        public DataSet SelectHomepageGoods()
        {
            return SqlData.SelectDataSet("Goods_SelectHomepage", null);
        }
        /// <summary>
        /// 查询商品ID集合
        /// </summary>
        /// <returns></returns>
        public List<Model.Goods> SelectGoodsIDMuster()
        {
            try
            {
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectIDMuster", null))
                {
                    List<Model.Goods> lmg = new List<weipin.Model.Goods>();
                    while (sdr.Read())
                    {
                        Model.Goods mdl = new weipin.Model.Goods();
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        lmg.Add(mdl);
                    }
                    return lmg;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询所有商品(用于创建SE索引)
        /// </summary>
        /// <returns></returns>
        public List<Model.Goods> SelectAllGoods()
        {
            try
            {
                using (SqlDataReader sdr = SqlData.SelectDataReader("Goods_SelectAllGoods", null))
                {
                    List<Model.Goods> lmg = new List<weipin.Model.Goods>();
                    while (sdr.Read())
                    {
                        Model.Goods mdl = new weipin.Model.Goods();
                        mdl.GoodsID = Convert.ToInt32(sdr["GoodsID"].ToString());
                        mdl.GoodsName = sdr["GoodsName"].ToString();
                        mdl.Keywords = sdr["Keywords"].ToString();
                        mdl.MarketPrice = Convert.ToDouble(sdr["MarketPrice"].ToString());
                        mdl.Price = Convert.ToDouble(sdr["Price"].ToString());
                        if (sdr["DiscountPrice"].ToString() != "") { mdl.DiscountPrice = Convert.ToDouble(sdr["DiscountPrice"].ToString()); }
                        mdl.GoodsPicturePath = sdr["GoodsPicturePath"].ToString();
                        mdl.AddTime = Convert.ToDateTime(sdr["AddTime"].ToString());
                        lmg.Add(mdl);
                    }
                    return lmg;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl"></param>
        /// <param name="sqlcategoriesgoods">构造添加Categories_Goods表SQL</param>
        /// <param name="sqlattributes">构造添加Goods_Attributes_Values表SQL</param>
        /// <returns></returns>
        public int InsertGoods(Model.Goods mdl, string sqlcategoriesgoods, string sqlattributes)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.GoodsName);
            arr.Add(mdl.Keywords);
            if (mdl.SimilarNumber >= 0) { arr.Add(mdl.SimilarNumber); } else { arr.Add(null); }
            if (mdl.DifferenceKeywords != "") { arr.Add(mdl.DifferenceKeywords); } else { arr.Add(null); }
            arr.Add(mdl.MarketPrice);
            arr.Add(mdl.Price);
            if (mdl.DiscountPrice != 0) { arr.Add(mdl.DiscountPrice); } else { arr.Add(null); }
            if (mdl.GoodsWeight != 0) { arr.Add(mdl.GoodsWeight); } else { arr.Add(null); }
            arr.Add(mdl.GoodsPicturePath);
            if (mdl.Inventory != 0) { arr.Add(mdl.Inventory); } else { arr.Add(null); }
            if (mdl.SupplyLine != 0) { arr.Add(mdl.SupplyLine); } else { arr.Add(null); }
            arr.Add(mdl.MerchantType);
            if (mdl.Remarks != "") { arr.Add(mdl.Remarks); } else { arr.Add(null); }
            arr.Add(mdl.IsBargain);
            arr.Add(mdl.IsCategoryPromotion);
            arr.Add(mdl.IsCategorySecondPromotion);
            arr.Add(mdl.IsNewRecommend);
            arr.Add(mdl.IsSeasonRecommend);
            arr.Add(mdl.IsGrounding);
            arr.Add(sqlcategoriesgoods);
            arr.Add(sqlattributes);
            if (mdl.WarmPrompt != "") { arr.Add(mdl.WarmPrompt); } else { arr.Add(null); }
            return SqlData.InsDelUpdDataReturnOneValue("Goods_Insert", arr);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteGoodsByID(int id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(id);
            return SqlData.InsDelUpdData("Goods_DeleteByID", arr);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <param name="sqlcategoriesgoods">构造添加Categories_Goods表SQL</param>
        /// <param name="sqlattributes">构造添加Goods_Attributes_Values表SQL</param>
        /// <returns></returns>
        /// <returns></returns>
        public int UpdateGoods(Model.Goods mdl, string sqlcategoriesgoods, string sqlattributes)
        {
            ArrayList arr = new ArrayList();
            arr.Add(mdl.GoodsID);
            arr.Add(mdl.GoodsName);
            arr.Add(mdl.Keywords);
            if (mdl.SimilarNumber >= 0) { arr.Add(mdl.SimilarNumber); } else { arr.Add(null); }
            if (mdl.DifferenceKeywords != "") { arr.Add(mdl.DifferenceKeywords); } else { arr.Add(null); }
            arr.Add(mdl.MarketPrice);
            arr.Add(mdl.Price);
            if (mdl.DiscountPrice != 0) { arr.Add(mdl.DiscountPrice); } else { arr.Add(null); }
            if (mdl.GoodsWeight != 0) { arr.Add(mdl.GoodsWeight); } else { arr.Add(null); }
            arr.Add(mdl.GoodsPicturePath);
            arr.Add(mdl.Inventory);
            arr.Add(mdl.SupplyLine);
            arr.Add(mdl.MerchantType);
            if (mdl.Remarks != "") { arr.Add(mdl.Remarks); } else { arr.Add(null); }
            arr.Add(mdl.IsBargain);
            arr.Add(mdl.IsCategoryPromotion);
            arr.Add(mdl.IsCategorySecondPromotion);
            arr.Add(mdl.IsNewRecommend);
            arr.Add(mdl.IsSeasonRecommend);
            arr.Add(mdl.IsGrounding);
            arr.Add(sqlcategoriesgoods);
            arr.Add(sqlattributes);
            if (mdl.WarmPrompt != "") { arr.Add(mdl.WarmPrompt); } else { arr.Add(null); }
            return SqlData.InsDelUpdData("Goods_Update", arr);
        }
    }
}