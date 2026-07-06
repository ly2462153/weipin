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
using System.Text;
using System.IO;
using System.Collections.Generic;
using weipin.Model;
using System;
using weipin.Common;

namespace weipin.BLL
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
            DAL.Goods dal = new DAL.Goods();
            return dal.SelectGoodsPartByID(id);
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id">GoodsID</param>
        /// <returns></returns>
        public Model.Goods SelectGoodsByID(int id)
        {
            DAL.Goods dal = new DAL.Goods();
            return dal.SelectGoodsByID(id);
        }
        /// <summary>
        /// 绑定商品库存补给线(分页)
        /// </summary>
        /// <param name="_nowpage">当前页</param>
        /// <param name="_perpage">每页条数</param>
        /// <returns></returns>
        public DataList<Model.Goods> SelectGoodsSupplyOfPaging(int _nowpage, int _perpage)
        {
            string[] _arr = Common.Pagination.CountStartEnd(_nowpage, _perpage);
            DAL.Goods dg = new weipin.DAL.Goods();
            return dg.SelectGoodsSupplyOfPaging(_arr[0].ToString(), _arr[1].ToString());
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
        public DataList<Model.Goods> SelectGoodsByConditionOfPaging(int nowpage, int perpage, string cid3, string pricecondition, string condition, string sort, string conditioncount)
        {
            string[] _arr = Common.Pagination.CountStartEnd(nowpage, perpage);
            DAL.Goods dg = new weipin.DAL.Goods();
            return dg.SelectGoodsByConditionOfPaging(_arr[0].ToString(), _arr[1].ToString(), cid3.ToString(), pricecondition, condition, sort, conditioncount);
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
        public DataList<Model.Goods> SelectGoodsByConditionOfPaging(int nowpage, int perpage, string cid2, string pricecondition, string sort)
        {
            string[] _arr = Common.Pagination.CountStartEnd(nowpage, perpage);
            DAL.Goods dg = new weipin.DAL.Goods();
            return dg.SelectGoodsByConditionOfPaging(_arr[0].ToString(), _arr[1].ToString(), cid2.ToString(), pricecondition, sort);
        }
        /// <summary>
        /// 查询商品ID集合
        /// </summary>
        /// <returns></returns>
        public List<Model.Goods> SelectGoodsIDMuster()
        {
            DAL.Goods dal = new DAL.Goods();
            return dal.SelectGoodsIDMuster();
        }
        /// <summary>
        /// 生成当前商品图片路径XML
        /// </summary>
        /// <param name="goodsid">商品ID</param>
        /// <param name="xmlpicpath">生成商品图片路径的XML</param>
        public void CreateGoodsPicturesXML(int goodsid, string xmlpicpath)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(xmlpicpath);
                xml.Save(HttpContext.Current.Server.MapPath("~/xml/goods/goodspaths/" + goodsid.ToString() + ".xml"));
            }
            catch { throw; }
        }
        /// <summary>
        /// 生成新品推荐商品
        /// </summary>
        /// <param name="xmlpicpath">生成新品推荐商品的XML</param>
        public void CreateGoodsSeasonRecommendXML(string xmlgoodsdata)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(xmlgoodsdata);
                xml.Save(HttpContext.Current.Server.MapPath("~/xml/goods/seasonrecommendgoods.xml"));
            }
            catch { throw; }
        }
        /// <summary>
        /// 查询同类商品/浏览过此商品的用户还购买过
        /// </summary>
        /// <param name="cid3">分类ID</param>
        /// <param name="gid">商品ID</param>
        /// <returns></returns>
        public string SelectGoodsSimilarBrowerBuyByCID(int cid3, int gid)
        {
            StringBuilder sb = new StringBuilder();
            DAL.Goods dg = new weipin.DAL.Goods();
            List<Model.Goods> lmg = dg.SelectGoodsSimilarBrowerBuyByCID(cid3, gid);
            if (lmg != null && lmg.Count > 0)
            {
                for (int i = 0; i < lmg.Count; i++)
                {
                    if (i == 5) { sb.Append("|"); }
                    string _path = lmg[i].GoodsPicturePath;
                    sb.Append("<div class=\"detail_side\"><div><a href=\"/page/" + Convert.ToInt32(lmg[i].GoodsID.ToString()) / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + lmg[i].GoodsName + "\"><img src=\"" + _path.Insert(_path.LastIndexOf("."), "_170x170") + "\"/></a></div><ul><li class=\"cp_wz\">");
                    sb.Append("<a href=\"/page/" + Convert.ToInt32(lmg[i].GoodsID.ToString()) / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" target=\"_blank\" title=\"" + lmg[i].GoodsName + "\">" + Commonality.CutString(lmg[i].GoodsName, 20) + "</a></li><li class=\"price_n2\">售价：￥");
                    if (lmg[i].DiscountPrice != 0) { sb.Append(lmg[i].DiscountPrice); }
                    else { sb.Append(lmg[i].Price); }
                    sb.Append("</li></ul></div>");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 查询购物车
        /// </summary>
        /// <param name="sql">构造查询购物车的GoodsID集合SQL拼接</param>
        /// <returns></returns>
        public List<Model.Goods> SelectGoodsShoppingCart(string sql)
        {
            DAL.Goods dg = new weipin.DAL.Goods();
            return dg.SelectGoodsShoppingCart(sql);
        }
        /// <summary>
        /// 查询购物车
        /// </summary>
        /// <param name="condition">构造的GoodsID集合拼接</param>
        /// <returns></returns>
        public List<Model.Goods> SelectGoodsShoppingCartByCondition(string condition)
        {
            DAL.Goods dg = new weipin.DAL.Goods();
            return dg.SelectGoodsShoppingCartByCondition(condition);
        }
        /// <summary>
        /// 绑定商品信息并判断评论权限
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="ogid">OrdersGoodsID</param>
        /// <returns></returns>
        public Model.Goods SelectGoodsAndJudgeCommentRightByOGID(string loginid, int ogid)
        {
            DAL.Goods dg = new weipin.DAL.Goods();
            return dg.SelectGoodsAndJudgeCommentRightByOGID(loginid, ogid);
        }
        /// <summary>
        /// 绑定商品信息并判断评论权限
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="gid">商品ID</param>
        /// <returns></returns>
        public Model.Goods SelectGoodsAndJudgeCommentRightByGoodsID(string loginid, int gid)
        {
            DAL.Goods dg = new weipin.DAL.Goods();
            return dg.SelectGoodsAndJudgeCommentRightByGoodsID(loginid, gid);
        }
        /// <summary>
        /// 绑定新品上架列表
        /// </summary>
        /// <param name="nowpage">当前页</param>
        /// <param name="perpage">每页条数</param>
        /// <returns></returns>
        public List<Model.Goods> SelectGoodsNewPaging(int nowpage, int perpage)
        {
            string[] _arr = Common.Pagination.CountStartEnd(nowpage, perpage);
            DAL.Goods dg = new weipin.DAL.Goods();
            return dg.SelectGoodsNewPaging(_arr[0].ToString(), _arr[1].ToString());
        }
        /// <summary>
        /// 绑定特惠抢购列表
        /// </summary>
        /// <param name="nowpage">当前页</param>
        /// <param name="perpage">每页条数</param>
        /// <returns></returns>
        public DataList<Model.Goods> SelectGoodsDiscountPaging(int nowpage, int perpage)
        {
            string[] _arr = Common.Pagination.CountStartEnd(nowpage, perpage);
            DAL.Goods dg = new weipin.DAL.Goods();
            return dg.SelectGoodsDiscountPaging(_arr[0].ToString(), _arr[1].ToString());
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
            DAL.Goods dal = new DAL.Goods();
            return dal.InsertGoods(mdl, sqlcategoriesgoods, sqlattributes);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteGoodsByID(int id)
        {
            DAL.Goods dal = new DAL.Goods();
            if (dal.DeleteGoodsByID(id) > 0) { return true; } else { return false; }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public bool UpdateGoods(Model.Goods mdl, string sqlcategoriesgoods, string sqlattributes)
        {
            DAL.Goods dal = new DAL.Goods();
            if (dal.UpdateGoods(mdl, sqlcategoriesgoods, sqlattributes) > 0) { return true; } else { return false; }
        }
        #region 生成同款不同图案颜色的商品XML
        /// <summary>
        /// 生成同款不同图案颜色的商品XML
        /// </summary>
        /// <param name="mg"></param>
        /// <param name="oldsimilarnumber">“同款式不同颜色属性”修改前的编号</param>
        public void CreateGoodsDifference(Model.Goods mg, string oldsimilarnumber)
        {
            if (oldsimilarnumber != "")
            {
                //删除XML中的当前商品节点
                XmlDocument xmlOld = new XmlDocument();
                string _goodsolddifference = HttpContext.Current.Server.MapPath("~/xml/goods/goodsdifference/" + oldsimilarnumber + ".xml");
                if (File.Exists(_goodsolddifference))
                {
                    XmlDocument docxmlOld = new XmlDocument();
                    docxmlOld.Load(_goodsolddifference);
                    XmlNodeList nodelist = docxmlOld.DocumentElement.ChildNodes;
                    if (nodelist.Count > 0)
                    {
                        string _xmlDifference = "<?xml version=\"1.0\" encoding=\"utf-8\"?><goods>";
                        for (int i = 0; i < nodelist.Count; i++)
                        {
                            if (nodelist[i].Attributes["id"].Value != mg.GoodsID.ToString()) { _xmlDifference += "<good id=\"" + nodelist[i].Attributes["id"].Value + "\" difwords=\"" + nodelist[i].Attributes["difwords"].Value + "\" path=\"" + nodelist[i].Attributes["path"].Value + "\"/>"; }
                        }
                        _xmlDifference += "</goods>";
                        try
                        {
                            if (_xmlDifference != "<?xml version=\"1.0\" encoding=\"utf-8\"?><goods></goods>")
                            {
                                xmlOld.LoadXml(_xmlDifference);
                                xmlOld.Save(HttpContext.Current.Server.MapPath("~/xml/goods/goodsdifference/" + oldsimilarnumber + ".xml"));
                            }
                            else { FileOperate.DeleteFile("~/xml/goods/goodsdifference/" + oldsimilarnumber + ".xml"); }
                        }
                        catch { throw; }
                    }
                }
            }
            if (mg.SimilarNumber > 0)
            {
                //添加XML中的当前商品节点
                XmlDocument xml = new XmlDocument();
                string _goodsdifference = HttpContext.Current.Server.MapPath("~/xml/goods/goodsdifference/" + mg.SimilarNumber + ".xml");
                if (File.Exists(_goodsdifference))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(_goodsdifference);
                    XmlNodeList nodelist = doc.DocumentElement.ChildNodes;
                    if (nodelist.Count > 0)
                    {
                        bool _result = false;
                        string _xmlDifference = "<?xml version=\"1.0\" encoding=\"utf-8\"?><goods>";
                        for (int i = 0; i < nodelist.Count; i++)
                        {
                            if (nodelist[i].Attributes["id"].Value == mg.GoodsID.ToString())
                            {
                                _xmlDifference += "<good id=\"" + mg.GoodsID.ToString() + "\" difwords=\"" + mg.DifferenceKeywords + "\" path=\"" + mg.GoodsPicturePath + "\"/>";
                                _result = true;
                            }
                            else { _xmlDifference += "<good id=\"" + nodelist[i].Attributes["id"].Value + "\" difwords=\"" + nodelist[i].Attributes["difwords"].Value + "\" path=\"" + nodelist[i].Attributes["path"].Value + "\"/>"; }
                        }
                        if (_result == false) { _xmlDifference += "<good id=\"" + mg.GoodsID.ToString() + "\" difwords=\"" + mg.DifferenceKeywords + "\" path=\"" + mg.GoodsPicturePath + "\"/>"; }
                        _xmlDifference += "</goods>";
                        try
                        {
                            xml.LoadXml(_xmlDifference);
                            xml.Save(HttpContext.Current.Server.MapPath("~/xml/goods/goodsdifference/" + mg.SimilarNumber.ToString() + ".xml"));
                        }
                        catch { throw; }
                    }
                }
                else
                {
                    //创建XML
                    string _xmlDifference = "<?xml version=\"1.0\" encoding=\"utf-8\"?><goods>";
                    _xmlDifference += "<good id=\"" + mg.GoodsID.ToString() + "\" difwords=\"" + mg.DifferenceKeywords + "\" path=\"" + mg.GoodsPicturePath + "\"/></goods>";
                    try
                    {
                        xml.LoadXml(_xmlDifference);
                        xml.Save(HttpContext.Current.Server.MapPath("~/xml/goods/goodsdifference/" + mg.SimilarNumber.ToString() + ".xml"));
                    }
                    catch { throw; }
                }
            }
        }
        #endregion
        #region 生成商品详情页
        /// <summary>
        /// 生成商品详情页
        /// </summary>
        /// <param name="goodsid">商品ID</param>
        /// <param name="oldsimilarnumber">“同款式不同颜色属性”修改前的编号</param>
        public void CreateGoodsShow(int goodsid, string oldsimilarnumber)
        {
            StringBuilder sbTemplate = new StringBuilder();
            sbTemplate.Append(File.ReadAllText(HttpContext.Current.Server.MapPath("~/templates/goodsshow.html"), Encoding.UTF8));
            DAL.Goods dg = new weipin.DAL.Goods();
            Model.Goods mg = dg.SelectGoodsDetailByID(goodsid);
            if (mg.GoodsID != 0)
            {
                if (mg.IsGrounding == false) { mg.SimilarNumber = 0; }
                CreateGoodsDifference(mg, oldsimilarnumber);
                sbTemplate.Replace("{weipin:goodsname}", mg.GoodsName.Replace(" ", "_"));
                BLL.Categories_Goods bcg = new Categories_Goods();
                List<Model.Categories_Goods> lmcg = bcg.SelectCategories_GoodsByGoodsID(goodsid);
                //此处获取xml/categories.xml，循环获取当前商品所在的等级名称，并将类别转换为名称替换“<a href="#">首页</a> > <a href="#">服装</a>”)
                string _allcategories = HttpContext.Current.Server.MapPath("~/xml/categories.xml");
                if (File.Exists(_allcategories))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(_allcategories);
                    XmlNodeList nodelist1 = doc.DocumentElement.ChildNodes;
                    if (nodelist1.Count > 0)
                    {
                        string _navigation = "<a href=\"/index.html\">首页</a> > ";
                        for (int i = 0; i < nodelist1.Count; i++)
                        {
                            if (nodelist1[i].Attributes["value"].Value == lmcg[0].CategoryID.ToString())
                            {
                                _navigation += "<a href=\"/page/categorygoods/categorygoods_" + nodelist1[i].Attributes["value"].Value + ".html\">" + nodelist1[i].Attributes["name"].Value + "</a> > ";
                                XmlNodeList nodelist2 = nodelist1[i].ChildNodes;
                                for (int j = 0; j < nodelist2.Count; j++)
                                {
                                    if (nodelist2[j].Attributes["value"].Value == lmcg[1].CategoryID.ToString())
                                    {
                                        _navigation += "<a href=\"/GoodsList.aspx?cid2=" + nodelist2[j].Attributes["value"].Value + "\">" + nodelist2[j].Attributes["name"].Value + "</a> > ";
                                        XmlNodeList nodelist3 = nodelist2[j].ChildNodes;
                                        for (int k = 0; k < nodelist3.Count; k++)
                                        {
                                            if (nodelist3[k].Attributes["value"].Value == lmcg[2].CategoryID.ToString())
                                            {
                                                _navigation += "<a href=\"/GoodsList.aspx?cid3=" + nodelist3[k].Attributes["value"].Value + "\">" + nodelist3[k].Attributes["name"].Value + "</a> > <span>商品详情</span>";
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        sbTemplate.Replace("{weipin:navigation}", _navigation);
                    }
                }
                else { sbTemplate.Replace("{weipin:navigation}", ""); }
                string _goodsdetail = "<li><h1 id=\"h1GoodsName\">" + mg.GoodsName + "</h1></li><li>商品编号：<span id=\"spGoodsID\">" + mg.GoodsID + "</span></li><li>市场价：<span class=\"price_o\">￥" + mg.MarketPrice + "</span></li>";
                if (mg.DiscountPrice != 0) { _goodsdetail += "<li>微品价：<span id=\"spPrice\" class=\"price_o\">￥" + mg.Price + "</span></li><li>抢购价：<span id=\"spDiscountPrice\" class=\"red22\">￥" + mg.DiscountPrice + "</span></li>"; }
                else { _goodsdetail += "<li>微品价：<span id=\"spPrice\" class=\"red22\">￥" + mg.Price + "</span></li>"; }
                _goodsdetail += "<input type=\"hidden\" id=\"hidDifference\" value=\"" + mg.SimilarNumber + "\"/><input type=\"hidden\" id=\"hidCategoryID3\" value=\"" + mg.CategoryID3.ToString() + "\"/>";
                sbTemplate.Replace("{weipin:goodsdetail}", _goodsdetail);
                string _inventoryremarks = "<li id=\"liInventory\" class=\"clear\">";
                if (mg.Inventory != null) { if (mg.Inventory <= mg.SupplyLine) { _inventoryremarks += "库存：<b style=\"color:#ff0000;\">暂时缺货</b>"; } else { _inventoryremarks += "库存：<b style=\"color:#5B9630;\">有货</b>"; } }
                _inventoryremarks += "</li>";
                if (mg.Remarks != "") { _inventoryremarks += "<li style=\"color:#ff0000;\">说明：<br/>" + mg.Remarks + "</li>"; }
                sbTemplate.Replace("{weipin:goodsinventoryremarks}", _inventoryremarks);
                sbTemplate.Replace("{weipin:warmprompt}", mg.WarmPrompt);
                string _paths = HttpContext.Current.Server.MapPath("~/xml/goods/goodspaths/" + goodsid + ".xml");
                if (File.Exists(_paths))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(_paths);
                    XmlNodeList nodelist = doc.DocumentElement.ChildNodes;
                    if (nodelist.Count > 0)
                    {
                        string _mainpicture = string.Empty;
                        string _allpictures = string.Empty;
                        string _allbigpictures = string.Empty;
                        for (int i = 0; i < nodelist.Count; i++)
                        {
                            if (i == 0)
                            {
                                _mainpicture = "<img src=\"" + nodelist[i].Attributes["value"].Value + "\" jqimg=\"" + nodelist[i].Attributes["value"].Value + "\" id=\"imgMainPic\" style=\"border:solid 1px #fff;\" width=\"300\" height=\"300\"/>";
                                _allbigpictures += "<img id=\"imgFirstPic\" src=\"" + nodelist[i].Attributes["value"].Value + "\" style=\"border:solid 1px #fff;\"/>";
                            }
                            else { _allbigpictures += "<br/><img src=\"" + nodelist[i].Attributes["value"].Value + "\" style=\"border:solid 1px #fff;\"/>"; }
                            _allpictures += "<div class=\"detai_s\"><img src=\"" + nodelist[i].Attributes["value"].Value + "\" width=\"53\" height=\"53\"/></div>";
                        }
                        sbTemplate.Replace("{weipin:mainpicture}", _mainpicture);
                        sbTemplate.Replace("{weipin:allpictures}", _allpictures);
                        sbTemplate.Replace("{weipin:allbigpictures}", _allbigpictures);
                    }
                }
                else
                {
                    sbTemplate.Replace("{weipin:mainpicture}", "");
                    sbTemplate.Replace("{weipin:allpictures}", "");
                    sbTemplate.Replace("{weipin:allbigpictures}", "");
                }
                if (mg.SimilarNumber > 0) { sbTemplate.Replace("{weipin:othercolor}", "<div class=\"choose\"><ul class=\"color_l\"><li style=\"line-height: 36px;\">其它花色：</li></ul><ul id=\"ulOtherColor\" class=\"color_r\"></ul><div class=\"clear\"></div></div>"); }
                else { sbTemplate.Replace("{weipin:othercolor}", ""); }
                string _goodssizes = HttpContext.Current.Server.MapPath("~/xml/goods/goodssizes/" + goodsid + ".xml");
                if (File.Exists(_goodssizes))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(_goodssizes);
                    XmlNodeList nodelist = doc.DocumentElement.ChildNodes;
                    if (nodelist.Count > 0)
                    {
                        string _sizes = "<div class=\"choose\"><ul id=\"ulSizes\"><li>选择尺码：</li>";
                        if (nodelist.Count == 1) { _sizes += "<li><span id=\"spSizes" + nodelist[0].Attributes["value"].Value + "\" class=\"chic\">" + nodelist[0].Attributes["name"].Value + "</span><input type=\"hidden\" value=\"" + (Convert.ToInt32(nodelist[0].Attributes["ivt"].Value) - Convert.ToInt32(nodelist[0].Attributes["sl"].Value)) + "\"/></li>"; }
                        else { for (int i = 0; i < nodelist.Count; i++) { _sizes += "<li><span id=\"spSizes" + nodelist[i].Attributes["value"].Value + "\" class=\"chic2\">" + nodelist[i].Attributes["name"].Value + "</span><input type=\"hidden\" value=\"" + (Convert.ToInt32(nodelist[i].Attributes["ivt"].Value) - Convert.ToInt32(nodelist[i].Attributes["sl"].Value)) + "\"/></li>"; } }
                        _sizes += "</ul><div class=\"clear\"></div></div>";
                        sbTemplate.Replace("{weipin:sizes}", _sizes);
                    }
                }
                else { sbTemplate.Replace("{weipin:sizes}", ""); }
                if (mg.Inventory != null && mg.Inventory <= mg.SupplyLine) { sbTemplate.Replace("{weipin:addshoppingcart}", ""); }
                else { sbTemplate.Replace("{weipin:addshoppingcart}", "<img src=\"/img/but_frgwc.gif\" id=\"imgAddShoppingCart\" width=\"150\" height=\"42\" style=\"cursor: pointer;\" />"); }
                string _categories = HttpContext.Current.Server.MapPath("~/xml/attributes/" + mg.CategoryID3 + ".xml");
                if (File.Exists(_categories))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(_categories);
                    XmlNodeList nodelist = doc.DocumentElement.ChildNodes;
                    if (nodelist.Count > 0)
                    {
                        string _goodsattributesvalues = HttpContext.Current.Server.MapPath("~/xml/goods/goodsattributesvalues/" + goodsid + ".xml");
                        if (!File.Exists(_goodsattributesvalues)) { sbTemplate.Replace("{weipin:attributesvalues}", ""); }
                        else
                        {
                            XmlDocument docAV = new XmlDocument();
                            docAV.Load(_goodsattributesvalues);
                            XmlNodeList nodelistAV = docAV.DocumentElement.ChildNodes;
                            if (nodelistAV.Count > 0)
                            {
                                string _attributesvalues = "<div class=\"det_bbox\"><ul>";
                                for (int i = 0; i < nodelist.Count; i++)
                                {
                                    string _attributeid = nodelist[i].Attributes["value"].Value;
                                    string _attributename = nodelist[i].Attributes["name"].Value;
                                    string _valueid = string.Empty;
                                    for (int j = 0; j < nodelistAV.Count; j++)
                                    {
                                        var _attribute = nodelistAV[j].Attributes["attributeid"].Value;
                                        if (_attributeid == _attribute)
                                        {
                                            _valueid = nodelistAV[j].Attributes["valueid"].Value;
                                            break;
                                        }
                                    }
                                    if (_valueid != "")
                                    {
                                        XmlNodeList nodelistValues = nodelist[i].ChildNodes;
                                        for (int k = 0; k < nodelistValues.Count; k++)
                                        {
                                            if (nodelistValues[k].Attributes["value"].Value == _valueid)
                                            {
                                                _attributesvalues += "<li>" + _attributename + "：" + nodelistValues[k].Attributes["name"].Value + "</li>";
                                                break;
                                            }
                                        }
                                    }
                                }
                                _attributesvalues += "</ul><div class=\"clear\"></div></div>";
                                sbTemplate.Replace("{weipin:attributesvalues}", _attributesvalues);
                            }
                            else { sbTemplate.Replace("{weipin:attributesvalues}", ""); }
                        }
                    }
                    else { sbTemplate.Replace("{weipin:attributesvalues}", ""); }
                }
                else { sbTemplate.Replace("{weipin:attributesvalues}", ""); }
                int _folder = goodsid / 1000;
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/page/" + _folder)))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/page/" + _folder));
                }
                File.WriteAllText(HttpContext.Current.Server.MapPath("~/page/" + _folder + "/goodsshow_" + goodsid + ".html"), sbTemplate.ToString());
            }
        }
        #endregion
        #region 生成一级分类专题
        /// <summary>
        /// 生成一级分类专题
        /// <param name="categoryid">一级分类ID</param>
        /// </summary>
        public void CreateCategoryGoods(int categoryid)
        {
            StringBuilder sbTemplate = new StringBuilder();
            sbTemplate.Append(File.ReadAllText(HttpContext.Current.Server.MapPath("~/templates/categorygoods.html"), Encoding.UTF8));
            string _path = HttpContext.Current.Server.MapPath("~/xml/categories.xml");
            if (File.Exists(_path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_path);
                XmlNodeList nodelist = doc.DocumentElement.ChildNodes;
                if (nodelist.Count > 0)
                {
                    StringBuilder sbSQL = new StringBuilder();
                    sbSQL.Append("select * from (select top 8 gds.GoodsID,GoodsName,MarketPrice,Price,DiscountPrice,GoodsPicturePath,null as CategoryID from Categories_Goods as cg join Goods as gds on cg.GoodsID=gds.GoodsID where cg.CategoryID=" + categoryid + " and IsNewRecommend=1 and IsGrounding=1 and IsDeleted=0 order by UpdateTime desc) tbNR");
                    string _titlename = string.Empty;
                    StringBuilder sbNav = new StringBuilder();
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        string _categoryid1 = nodelist[i].Attributes["value"].Value;
                        string _categoryname1 = nodelist[i].Attributes["name"].Value;
                        if (_categoryid1 == categoryid.ToString()) { sbNav.Append("<div class=\"menu_down\"><span class=\"menu_on01\"></span><a href=\"/page/categorygoods/categorygoods_" + _categoryid1 + ".html\" class=\"menu_on02\">" + _categoryname1 + "</a><span class=\"menu_on03\"></span></div>"); _titlename = _categoryname1; }
                        else { sbNav.Append("<div class=\"menu_down\"><span class=\"menu_down01\"></span><a href=\"/page/categorygoods/categorygoods_" + _categoryid1 + ".html\" class=\"menu_down02\">" + _categoryname1 + "</a><span class=\"menu_down03\"></span></div>"); }
                    }
                    sbTemplate.Replace("{weipin:titlename}", _titlename);
                    sbTemplate.Replace("{weipin:navigation}", sbNav.ToString());
                    StringBuilder sbCategories = new StringBuilder();
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        string _categoryid1 = nodelist[i].Attributes["value"].Value;
                        if (_categoryid1 == categoryid.ToString())
                        {
                            sbCategories.Append("<div style=\"float:left;\"><div class=\"secl_menubox1\" style=\"height:");
                            switch (categoryid)
                            {
                                case 3: sbCategories.Append("205"); break;
                                case 9: sbCategories.Append("495"); break;
                                case 17: sbCategories.Append("205"); break;
                                case 20: sbCategories.Append("205"); break;
                                case 63: sbCategories.Append("205"); break;
                                default: sbCategories.Append("495"); break;
                            }
                            sbCategories.Append("px;\">");
                            #region 第二级
                            XmlNode _node = nodelist[i];
                            if (_node.ChildNodes.Count > 0)
                            {
                                for (int j = 0; j < _node.ChildNodes.Count; j++)
                                {
                                    string _categoryid2 = _node.ChildNodes[j].Attributes["value"].Value;
                                    string _categoryname2 = _node.ChildNodes[j].Attributes["name"].Value;
                                    sbSQL.Append(" union all select * from (select top 8 gds.GoodsID,GoodsName,MarketPrice,Price,DiscountPrice,GoodsPicturePath,CategoryID from Categories_Goods as cg join Goods as gds on cg.GoodsID=gds.GoodsID where cg.CategoryID=" + _categoryid2 + " and IsCategorySecondPromotion=1 and IsGrounding=1 and IsDeleted=0 order by UpdateTime desc) tbCSP");
                                    sbCategories.Append("<div class=\"secl_menu\"><h1><a href=\"/GoodsList.aspx?cid2=" + _categoryid2 + "\">" + _categoryname2 + "</a></h1><ul>");
                                    #region 第三级
                                    XmlNode _node2 = _node.ChildNodes[j];
                                    if (_node2.ChildNodes.Count > 0)
                                    {
                                        for (int k = 0; k < _node2.ChildNodes.Count; k++)
                                        {
                                            //string _categoryid3 = _node2.ChildNodes[k].Attributes["value"].Value;待删除2012-6-28
                                            //string _categoryname3 = _node2.ChildNodes[k].Attributes["name"].Value;
                                            //string _ishighlight3 = _node2.ChildNodes[k].Attributes["ishighlight"].Value;
                                            sbCategories.Append("<li><a href=\"/GoodsList.aspx?cid3=" + _node2.ChildNodes[k].Attributes["value"].Value + "\"");
                                            if (_node2.ChildNodes[k].Attributes["ishighlight"].Value == "True") { sbCategories.Append(" class=\"c_bule\""); }
                                            sbCategories.Append(">" + _node2.ChildNodes[k].Attributes["name"].Value + "</a></li>");
                                        }
                                    }
                                    #endregion
                                    sbCategories.Append("</ul><div class=\"clear\"></div></div>");
                                }
                            }
                            #endregion
                            sbCategories.Append("</div>");
                            switch (categoryid)
                            {
                                case 3: sbCategories.Append("<div class=\"img_adm\"><a href=\"/GoodsList.aspx?cid3=29&sp=&ep=&atb=&st=2\" target=\"_blank\"><img src=\"/file/images/advertisement/category_adm" + categoryid.ToString() + ".jpg\" alt=\"微品网上商城\"/></a></div>"); break;
                                case 9: sbCategories.Append(""); break;
                                case 17: sbCategories.Append("<div class=\"img_adm\"><a href=\"/page/categorygoods/categorygoods_20.html\" target=\"_blank\"><img src=\"/file/images/advertisement/category_adm" + categoryid.ToString() + ".jpg\" alt=\"微品网上商城\"/></a></div>"); break;
                                case 20: sbCategories.Append("<div class=\"img_adm\"><a href=\"/GoodsList.aspx?cid3=97\" target=\"_blank\"><img src=\"/file/images/advertisement/category_adm" + categoryid.ToString() + ".jpg\" alt=\"微品网上商城\"/></a></div>"); break;
                                case 63: sbCategories.Append("<div class=\"img_adm\"><a href=\"/GoodsList.aspx?cid2=6\" target=\"_blank\"><img src=\"/file/images/advertisement/category_adm" + categoryid.ToString() + ".jpg\" alt=\"微品网上商城\"/></a></div>"); break;
                                default: sbCategories.Append(""); break;
                            }
                            sbCategories.Append("</div>");
                            break;
                        }
                    }
                    sbTemplate.Replace("{weipin:categories}", sbCategories.ToString());
                    DAL.Goods dg = new weipin.DAL.Goods();
                    List<Model.Goods> lmg = dg.SelectCategoryGoodsBySQL(sbSQL.ToString());
                    if (lmg != null && lmg.Count > 0)
                    {
                        StringBuilder sbNewRecommend = new StringBuilder();
                        for (int i = 0; i < lmg.Count; i++)
                        {
                            if (lmg[i].CategoryID2 == 0)
                            {
                                string _srpath = lmg[i].GoodsPicturePath;
                                sbNewRecommend.Append("<ul>");
                                if (lmg[i].DiscountPrice != 0) { sbNewRecommend.Append("<div class=\"zhek\">" + lmg[i].DiscountPrice.ToString() + "</div>"); }
                                sbNewRecommend.Append("<li><a href=\"/page/" + lmg[i].GoodsID / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" title=\"" + lmg[i].GoodsName + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_170x170") + "\"/></a></li>");
                                sbNewRecommend.Append("<li style=\"height:32px;\"><a href=\"/page/" + lmg[i].GoodsID / 1000 + "/goodsshow_" + lmg[i].GoodsID.ToString() + ".html\" title=\"" + lmg[i].GoodsName + "\" target=\"_blank\">" + Commonality.CutString(lmg[i].GoodsName, 24) + "</a></li><li>市场价：<span class=\"price_o\">" + lmg[i].MarketPrice.ToString() + "</span><span class=\"price_n\">微品价：￥" + lmg[i].Price.ToString() + "</span></li></ul>");
                            }
                            else { break; }
                        }
                        sbTemplate.Replace("{weipin:newrecommend}", sbNewRecommend.ToString());
                        for (int i = 0; i < nodelist.Count; i++)
                        {
                            string _categoryid1 = nodelist[i].Attributes["value"].Value;
                            if (_categoryid1 == categoryid.ToString())
                            {
                                #region 第二级
                                XmlNode _node = nodelist[i];
                                if (_node.ChildNodes.Count > 0)
                                {
                                    StringBuilder sbCategoryGoods = new StringBuilder();
                                    for (int j = 0; j < _node.ChildNodes.Count; j++)
                                    {
                                        string _categoryid2 = _node.ChildNodes[j].Attributes["value"].Value;
                                        string _categoryname2 = _node.ChildNodes[j].Attributes["name"].Value;
                                        sbCategoryGoods.Append("<div class=\"seccon_titbg\"><div class=\"sycon_tit01\"><a href=\"/GoodsList.aspx?cid2=" + _categoryid2 + "\">" + _categoryname2 + "</a></div><div class=\"sycon_tit02\">");
                                        #region 第三级
                                        XmlNode _node2 = _node.ChildNodes[j];
                                        if (_node2.ChildNodes.Count > 0)
                                        {
                                            for (int k = 0; k < _node2.ChildNodes.Count; k++)
                                            {
                                                //string _categoryid3 = _node2.ChildNodes[k].Attributes["value"].Value;待删除2012-6-28
                                                //string _categoryname3 = _node2.ChildNodes[k].Attributes["name"].Value;
                                                sbCategoryGoods.Append("<a href=\"/GoodsList.aspx?cid3=" + _node2.ChildNodes[k].Attributes["value"].Value + "\">" + _node2.ChildNodes[k].Attributes["name"].Value + "</a>");
                                            }
                                        }
                                        #endregion
                                        sbCategoryGoods.Append("</div><div class=\"sycon_tit03\"><a href=\"/GoodsList.aspx?cid2=" + _categoryid2 + "\">更多</a></div></div>");
                                        List<Model.Goods> lmgCategory = lmg.FindAll(delegate(Model.Goods mg) { return mg.CategoryID2 == Convert.ToInt32(_categoryid2); });
                                        sbCategoryGoods.Append("<div class=\"seccon_div\">");
                                        for (int l = 0; l < lmgCategory.Count; l++)
                                        {
                                            string _srpath = lmgCategory[l].GoodsPicturePath;
                                            sbCategoryGoods.Append("<div class=\"seccon_box\">");
                                            if (lmgCategory[l].DiscountPrice != 0) { sbCategoryGoods.Append("<div class=\"zhekou\">" + lmgCategory[l].DiscountPrice.ToString() + "</div>"); }
                                            sbCategoryGoods.Append("<ul><li><a href=\"/page/" + lmgCategory[l].GoodsID / 1000 + "/goodsshow_" + lmgCategory[l].GoodsID.ToString() + ".html\" title=\"" + lmgCategory[l].GoodsName + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_170x170") + "\"/></a></li>");
                                            sbCategoryGoods.Append("<li style=\"height:32px;\"><a href=\"/page/" + lmgCategory[l].GoodsID / 1000 + "/goodsshow_" + lmgCategory[l].GoodsID.ToString() + ".html\" title=\"" + lmgCategory[l].GoodsName + "\" target=\"_blank\">" + Commonality.CutString(lmgCategory[l].GoodsName, 26) + "</a></li><li>市场价：<span class=\"price_o\">" + lmgCategory[l].MarketPrice.ToString() + "</span><span class=\"price_n\">微品价：￥" + lmgCategory[l].Price.ToString() + "<span></li></ul></div>");
                                        }
                                        sbCategoryGoods.Append("<div class=\"clear\"></div></div>");
                                    }
                                    sbTemplate.Replace("{weipin:categorygoods}", sbCategoryGoods.ToString());
                                }
                                #endregion
                                break;
                            }
                        }
                    }
                    else { sbTemplate.Replace("{weipin:newrecommend}", ""); sbTemplate.Replace("{weipin:categorygoods}", ""); }
                }
                File.WriteAllText(HttpContext.Current.Server.MapPath("~/page/categorygoods/categorygoods_" + categoryid + ".html"), sbTemplate.ToString());
            }
        }
        #endregion
        #region 生成首页
        /// <summary>
        /// 生成首页
        /// </summary>
        public void CreateHomepage()
        {
            StringBuilder sbTemplate = new StringBuilder();
            sbTemplate.Append(File.ReadAllText(HttpContext.Current.Server.MapPath("~/templates/index.html"), Encoding.UTF8));
            BLL.Categories bc = new weipin.BLL.Categories();
            string _path = HttpContext.Current.Server.MapPath("~/xml/categories.xml");
            if (File.Exists(_path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_path);
                XmlNodeList nodelist = doc.DocumentElement.ChildNodes;
                if (nodelist.Count > 0)
                {
                    StringBuilder sbCategories = new StringBuilder();
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        string _categoryid1 = nodelist[i].Attributes["value"].Value;
                        string _categoryname1 = nodelist[i].Attributes["name"].Value;
                        sbCategories.Append("<div class=\"menul_tit\"><a href=\"/page/categorygoods/categorygoods_" + _categoryid1 + ".html\" target=\"_blank\">" + _categoryname1 + "</a></div><div class=\"menul_con\"><ul>");
                        string _categorytitle = string.Empty;
                        _categorytitle = "<div class=\"sycon_tit01\"><a href=\"/page/categorygoods/categorygoods_" + _categoryid1 + ".html\" target=\"_blank\">" + _categoryname1 + "</a></div><div class=\"sycon_tit02\">";
                        #region 第二级
                        XmlNode _node = nodelist[i];
                        if (_node.ChildNodes.Count > 0)
                        {
                            for (int j = 0; j < _node.ChildNodes.Count; j++)
                            {
                                string _categoryid2 = _node.ChildNodes[j].Attributes["value"].Value;
                                string _categoryname2 = _node.ChildNodes[j].Attributes["name"].Value;
                                sbCategories.Append("<li><span class=\"menul_bold\"><a href=\"GoodsList.aspx?cid2=" + _categoryid2 + "\">" + _categoryname2 + "</a></span><span class=\"menul_linkr\">");
                                #region 第三级
                                XmlNode _node2 = _node.ChildNodes[j];
                                if (_node2.ChildNodes.Count > 0)
                                {
                                    for (int k = 0; k < _node2.ChildNodes.Count; k++)
                                    {
                                        string _categoryid3 = _node2.ChildNodes[k].Attributes["value"].Value;
                                        string _categoryname3 = _node2.ChildNodes[k].Attributes["name"].Value;
                                        string _ishighlight3 = _node2.ChildNodes[k].Attributes["ishighlight"].Value;
                                        sbCategories.Append("<a href=\"GoodsList.aspx?cid3=" + _categoryid3 + "\"");
                                        if (_ishighlight3 == "True") { sbCategories.Append(" class=\"c_bule\""); }
                                        sbCategories.Append(">" + _categoryname3 + "</a>");
                                    }
                                }
                                #endregion
                                sbCategories.Append("</span></li>");
                                _categorytitle += "<a href=\"GoodsList.aspx?cid2=" + _categoryid2 + "\" target=\"_blank\">" + _categoryname2 + "</a>";
                            }
                        }
                        #endregion
                        sbCategories.Append("</ul><div class=\"clear\"></div></div>");
                        _categorytitle += "</div><div class=\"sycon_tit03\"><a href=\"/page/categorygoods/categorygoods_" + _categoryid1 + ".html\" target=\"_blank\">更多</a></div>";
                        sbTemplate.Replace("{weipin:categorytitle" + i + "}", _categorytitle.ToString());
                    }
                    sbTemplate.Replace("{weipin:categories}", sbCategories.ToString());
                }
            }
            DAL.Goods dg = new weipin.DAL.Goods();
            DataSet ds = dg.SelectHomepageGoods();
            #region 季节特荐
            DataTable dtSR = ds.Tables[0];
            StringBuilder sbSR = new StringBuilder();
            if (dtSR != null)
            {
                string _xmlSR = "<?xml version=\"1.0\" encoding=\"utf-8\"?><goods>";
                for (int i = 0; i < dtSR.Rows.Count; i++)
                {
                    string _srid = dtSR.Rows[i]["GoodsID"].ToString();
                    string _srname = dtSR.Rows[i]["GoodsName"].ToString();
                    string _srpath = dtSR.Rows[i]["GoodsPicturePath"].ToString();
                    string _disprice = dtSR.Rows[i]["DiscountPrice"].ToString();
                    string _price = dtSR.Rows[i]["Price"].ToString();
                    _xmlSR += "<good id=\"" + _srid + "\" name=\"" + _srname + "\" path=\"" + _srpath + "\" price=\"";
                    sbSR.Append("<div class=\"syr_cp\"><ul><li><a href=\"/page/" + Convert.ToInt32(_srid) / 1000 + "/goodsshow_" + _srid + ".html\" title=\"" + _srname + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_85x85") + "\"/></a></li>");
                    sbSR.Append("<li class=\"mingc1\"><a href=\"/page/" + Convert.ToInt32(_srid) / 1000 + "/goodsshow_" + _srid + ".html\" title=\"" + _srname + "\" target=\"_blank\">" + Commonality.CutString(_srname, 14) + "</a></li>");
                    sbSR.Append("<li><span class=\"price_n\">售价：￥");
                    if (_disprice != "")
                    {
                        sbSR.Append(_disprice);
                        _xmlSR += _disprice;
                    }
                    else
                    {
                        sbSR.Append(_price);
                        _xmlSR += _price;
                    }
                    _xmlSR += "\"/>";
                    sbSR.Append("</span></li></ul></div>");
                }
                _xmlSR += "</goods>";
                CreateGoodsSeasonRecommendXML(_xmlSR);
                sbTemplate.Replace("{weipin:seasonrecommend}", sbSR.ToString());
            }
            #endregion
            #region 特价促销
            DataTable dtBargain = ds.Tables[1];
            StringBuilder sbBargain = new StringBuilder();
            if (dtBargain != null)
            {
                for (int i = 0; i < dtBargain.Rows.Count; i++)
                {
                    string _srpath = dtBargain.Rows[i]["GoodsPicturePath"].ToString();
                    sbBargain.Append("<div class=\"syr_cp\"><ul><li><a href=\"/page/" + Convert.ToInt32(dtBargain.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtBargain.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtBargain.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_85x85") + "\"/></a></li>");
                    sbBargain.Append("<li class=\"mingc1\"><a href=\"/page/" + Convert.ToInt32(dtBargain.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtBargain.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtBargain.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\">" + Commonality.CutString(dtBargain.Rows[i]["GoodsName"].ToString(), 14) + "</a></li>");
                    sbBargain.Append("<li><span class=\"price_n\">售价：￥");
                    if (dtBargain.Rows[i]["DiscountPrice"].ToString() != "") { sbBargain.Append(dtBargain.Rows[i]["DiscountPrice"].ToString()); }
                    else { sbBargain.Append(dtBargain.Rows[i]["Price"].ToString()); }
                    sbBargain.Append("</span></li></ul></div>");
                }
                sbTemplate.Replace("{weipin:bargain}", sbBargain.ToString());
            }
            #endregion
            #region 潮流饰品分类
            DataTable dtOffice = ds.Tables[6];
            StringBuilder sbOffice = new StringBuilder();
            if (dtOffice != null)
            {
                for (int i = 0; i < dtOffice.Rows.Count; i++)
                {
                    string _srpath = dtOffice.Rows[i]["GoodsPicturePath"].ToString();
                    sbOffice.Append("<div class=\"sycon_cp\">");
                    if (dtOffice.Rows[i]["DiscountPrice"].ToString() != "") { sbOffice.Append("<div class=\"zhek\">" + dtOffice.Rows[i]["DiscountPrice"].ToString() + "</div>"); }
                    sbOffice.Append("<ul><li><a href=\"/page/" + Convert.ToInt32(dtOffice.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtOffice.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtOffice.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_170x170") + "\"/></a></li>");
                    sbOffice.Append("<li class=\"sy_cp\"><a href=\"/page/" + Convert.ToInt32(dtOffice.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtOffice.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtOffice.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\">" + Commonality.CutString(dtOffice.Rows[i]["GoodsName"].ToString(), 28) + "</a></li>");
                    sbOffice.Append("<li>市场价：￥<span class=\"price_o\">" + dtOffice.Rows[i]["MarketPrice"].ToString() + "</span><span class=\"price_n\">微品价：￥" + dtOffice.Rows[i]["Price"].ToString() + "</span></li></ul></div>");
                }
                sbTemplate.Replace("{weipin:categorypromotion1}", sbOffice.ToString());
            }
            #endregion
            #region 潮流饰品分类人气
            DataTable dtOfficePopularity = ds.Tables[7];
            StringBuilder sbOfficePopularity = new StringBuilder();
            if (dtOfficePopularity != null)
            {
                for (int i = 0; i < dtOfficePopularity.Rows.Count; i++)
                {
                    string _srpath = dtOfficePopularity.Rows[i]["GoodsPicturePath"].ToString();
                    sbOfficePopularity.Append("<div class=\"sycon_lmenu\"><a href=\"/page/" + Convert.ToInt32(dtOfficePopularity.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtOfficePopularity.Rows[i]["GoodsID"].ToString() + ".html\" class=\"ico" + (i + 1) + "\" title=\"" + dtOfficePopularity.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\">");
                    sbOfficePopularity.Append(Commonality.CutString(dtOfficePopularity.Rows[i]["GoodsName"].ToString(), 11) + "</a><div class=\"lmenu_con\"");
                    if (i != 0) { sbOfficePopularity.Append(" style=\"display:none;\""); }
                    sbOfficePopularity.Append("><a href=\"/page/" + Convert.ToInt32(dtOfficePopularity.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtOfficePopularity.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtOfficePopularity.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_60x60") + "\" style=\"float:left;\"/></a>");
                    sbOfficePopularity.Append("<ul style=\"width:90px;float:left;\"><li>市场价：<span class=\"price_o\">￥" + dtOfficePopularity.Rows[i]["MarketPrice"].ToString() + "</span></li><li><span class=\"price_n2\">售价：￥");
                    if (dtOfficePopularity.Rows[i]["DiscountPrice"].ToString() != "") { sbOfficePopularity.Append(dtOfficePopularity.Rows[i]["DiscountPrice"].ToString()); }
                    else { sbOfficePopularity.Append(dtOfficePopularity.Rows[i]["Price"].ToString()); }
                    sbOfficePopularity.Append("</span></li></ul><div class=\"clear\"></div></div></div>");
                }
                sbTemplate.Replace("{weipin:categorypromotionpopularity1}", sbOfficePopularity.ToString());
            }
            #endregion
            #region 服饰分类
            DataTable dtClothes = ds.Tables[2];
            StringBuilder sbClothes = new StringBuilder();
            if (dtClothes != null)
            {
                for (int i = 0; i < dtClothes.Rows.Count; i++)
                {
                    string _srpath = dtClothes.Rows[i]["GoodsPicturePath"].ToString();
                    sbClothes.Append("<div class=\"sycon_cp\">");
                    if (dtClothes.Rows[i]["DiscountPrice"].ToString() != "") { sbClothes.Append("<div class=\"zhek\">" + dtClothes.Rows[i]["DiscountPrice"].ToString() + "</div>"); }
                    sbClothes.Append("<ul><li><a href=\"/page/" + Convert.ToInt32(dtClothes.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtClothes.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtClothes.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_170x170") + "\"/></a></li>");
                    sbClothes.Append("<li class=\"sy_cp\"><a href=\"/page/" + Convert.ToInt32(dtClothes.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtClothes.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtClothes.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\">" + Commonality.CutString(dtClothes.Rows[i]["GoodsName"].ToString(), 28) + "</a></li>");
                    sbClothes.Append("<li>市场价：￥<span class=\"price_o\">" + dtClothes.Rows[i]["MarketPrice"].ToString() + "</span><span class=\"price_n\">微品价：￥" + dtClothes.Rows[i]["Price"].ToString() + "</span></li></ul></div>");
                }
                sbTemplate.Replace("{weipin:categorypromotion2}", sbClothes.ToString());
            }
            #endregion
            #region 服饰分类人气
            DataTable dtClothesPopularity = ds.Tables[3];
            StringBuilder sbClothesPopularity = new StringBuilder();
            if (dtClothesPopularity != null)
            {
                for (int i = 0; i < dtClothesPopularity.Rows.Count; i++)
                {
                    string _srpath = dtClothesPopularity.Rows[i]["GoodsPicturePath"].ToString();
                    sbClothesPopularity.Append("<div class=\"sycon_lmenu\"><a href=\"/page/" + Convert.ToInt32(dtClothesPopularity.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtClothesPopularity.Rows[i]["GoodsID"].ToString() + ".html\" class=\"ico" + (i + 1) + "\" title=\"" + dtClothesPopularity.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\">");
                    sbClothesPopularity.Append(Commonality.CutString(dtClothesPopularity.Rows[i]["GoodsName"].ToString(), 11) + "</a><div class=\"lmenu_con\"");
                    if (i != 0) { sbClothesPopularity.Append(" style=\"display:none;\""); }
                    sbClothesPopularity.Append("><a href=\"/page/" + Convert.ToInt32(dtClothesPopularity.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtClothesPopularity.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtClothesPopularity.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_60x60") + "\" style=\"float:left;\"/></a>");
                    sbClothesPopularity.Append("<ul style=\"width:90px;float:left;\"><li>市场价：<span class=\"price_o\">￥" + dtClothesPopularity.Rows[i]["MarketPrice"].ToString() + "</span></li><li><span class=\"price_n2\">售价：￥");
                    if (dtClothesPopularity.Rows[i]["DiscountPrice"].ToString() != "") { sbClothesPopularity.Append(dtClothesPopularity.Rows[i]["DiscountPrice"].ToString()); }
                    else { sbClothesPopularity.Append(dtClothesPopularity.Rows[i]["Price"].ToString()); }
                    sbClothesPopularity.Append("</span></li></ul><div class=\"clear\"></div></div></div>");
                }
                sbTemplate.Replace("{weipin:categorypromotionpopularity2}", sbClothesPopularity.ToString());
            }
            #endregion
            #region 家居分类
            DataTable dtFurnishing = ds.Tables[4];
            StringBuilder sbFurnishing = new StringBuilder();
            if (dtFurnishing != null)
            {
                for (int i = 0; i < dtFurnishing.Rows.Count; i++)
                {
                    string _srpath = dtFurnishing.Rows[i]["GoodsPicturePath"].ToString();
                    sbFurnishing.Append("<div class=\"sycon_cp\">");
                    if (dtFurnishing.Rows[i]["DiscountPrice"].ToString() != "") { sbFurnishing.Append("<div class=\"zhek\">" + dtFurnishing.Rows[i]["DiscountPrice"].ToString() + "</div>"); }
                    sbFurnishing.Append("<ul><li><a href=\"/page/" + Convert.ToInt32(dtFurnishing.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtFurnishing.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtFurnishing.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_170x170") + "\"/></a></li>");
                    sbFurnishing.Append("<li class=\"sy_cp\"><a href=\"/page/" + Convert.ToInt32(dtFurnishing.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtFurnishing.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtFurnishing.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\">" + Commonality.CutString(dtFurnishing.Rows[i]["GoodsName"].ToString(), 28) + "</a></li>");
                    sbFurnishing.Append("<li>市场价：￥<span class=\"price_o\">" + dtFurnishing.Rows[i]["MarketPrice"].ToString() + "</span><span class=\"price_n\">微品价：￥" + dtFurnishing.Rows[i]["Price"].ToString() + "</span></li></ul></div>");
                }
                sbTemplate.Replace("{weipin:categorypromotion3}", sbFurnishing.ToString());
            }
            #endregion
            #region 家居分类人气
            DataTable dtFurnishingPopularity = ds.Tables[5];
            StringBuilder sbFurnishingPopularity = new StringBuilder();
            if (dtFurnishingPopularity != null)
            {
                for (int i = 0; i < dtFurnishingPopularity.Rows.Count; i++)
                {
                    string _srpath = dtFurnishingPopularity.Rows[i]["GoodsPicturePath"].ToString();
                    sbFurnishingPopularity.Append("<div class=\"sycon_lmenu\"><a href=\"/page/" + Convert.ToInt32(dtFurnishingPopularity.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtFurnishingPopularity.Rows[i]["GoodsID"].ToString() + ".html\" class=\"ico" + (i + 1) + "\" title=\"" + dtFurnishingPopularity.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\">");
                    sbFurnishingPopularity.Append(Commonality.CutString(dtFurnishingPopularity.Rows[i]["GoodsName"].ToString(), 11) + "</a><div class=\"lmenu_con\"");
                    if (i != 0) { sbFurnishingPopularity.Append(" style=\"display:none;\""); }
                    sbFurnishingPopularity.Append("><a href=\"/page/" + Convert.ToInt32(dtFurnishingPopularity.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtFurnishingPopularity.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtFurnishingPopularity.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_60x60") + "\" style=\"float:left;\"/></a>");
                    sbFurnishingPopularity.Append("<ul style=\"width:90px;float:left;\"><li>市场价：<span class=\"price_o\">￥" + dtFurnishingPopularity.Rows[i]["MarketPrice"].ToString() + "</span></li><li><span class=\"price_n2\">售价：￥");
                    if (dtFurnishingPopularity.Rows[i]["DiscountPrice"].ToString() != "") { sbFurnishingPopularity.Append(dtFurnishingPopularity.Rows[i]["DiscountPrice"].ToString()); }
                    else { sbFurnishingPopularity.Append(dtFurnishingPopularity.Rows[i]["Price"].ToString()); }
                    sbFurnishingPopularity.Append("</span></li></ul><div class=\"clear\"></div></div></div>");
                }
                sbTemplate.Replace("{weipin:categorypromotionpopularity3}", sbFurnishingPopularity.ToString());
            }
            #endregion
            #region 汽车用品分类
            DataTable dtFood = ds.Tables[8];
            StringBuilder sbFood = new StringBuilder();
            if (dtFood != null)
            {
                for (int i = 0; i < dtFood.Rows.Count; i++)
                {
                    string _srpath = dtFood.Rows[i]["GoodsPicturePath"].ToString();
                    sbFood.Append("<div class=\"sycon_cp\">");
                    if (dtFood.Rows[i]["DiscountPrice"].ToString() != "") { sbFood.Append("<div class=\"zhek\">" + dtFood.Rows[i]["DiscountPrice"].ToString() + "</div>"); }
                    sbFood.Append("<ul><li><a href=\"/page/" + Convert.ToInt32(dtFood.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtFood.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtFood.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_170x170") + "\"/></a></li>");
                    sbFood.Append("<li class=\"sy_cp\"><a href=\"/page/" + Convert.ToInt32(dtFood.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtFood.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtFood.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\">" + Commonality.CutString(dtFood.Rows[i]["GoodsName"].ToString(), 28) + "</a></li>");
                    sbFood.Append("<li>市场价：￥<span class=\"price_o\">" + dtFood.Rows[i]["MarketPrice"].ToString() + "</span><span class=\"price_n\">微品价：￥" + dtFood.Rows[i]["Price"].ToString() + "</span></li></ul></div>");
                }
                sbTemplate.Replace("{weipin:categorypromotion4}", sbFood.ToString());
            }
            #endregion
            #region 汽车用品分类人气
            DataTable dtFoodPopularity = ds.Tables[9];
            StringBuilder sbFoodPopularity = new StringBuilder();
            if (dtFoodPopularity != null)
            {
                for (int i = 0; i < dtFoodPopularity.Rows.Count; i++)
                {
                    string _srpath = dtFoodPopularity.Rows[i]["GoodsPicturePath"].ToString();
                    sbFoodPopularity.Append("<div class=\"sycon_lmenu\"><a href=\"/page/" + Convert.ToInt32(dtFoodPopularity.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtFoodPopularity.Rows[i]["GoodsID"].ToString() + ".html\" class=\"ico" + (i + 1) + "\" title=\"" + dtFoodPopularity.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\">");
                    sbFoodPopularity.Append(Commonality.CutString(dtFoodPopularity.Rows[i]["GoodsName"].ToString(), 11) + "</a><div class=\"lmenu_con\"");
                    if (i != 0) { sbFoodPopularity.Append(" style=\"display:none;\""); }
                    sbFoodPopularity.Append("><a href=\"/page/" + Convert.ToInt32(dtFoodPopularity.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtFoodPopularity.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtFoodPopularity.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_60x60") + "\" style=\"float:left;\"/></a>");
                    sbFoodPopularity.Append("<ul style=\"width:90px;float:left;\"><li>市场价：<span class=\"price_o\">￥" + dtFoodPopularity.Rows[i]["MarketPrice"].ToString() + "</span></li><li><span class=\"price_n2\">售价：￥");
                    if (dtFoodPopularity.Rows[i]["DiscountPrice"].ToString() != "") { sbFoodPopularity.Append(dtFoodPopularity.Rows[i]["DiscountPrice"].ToString()); }
                    else { sbFoodPopularity.Append(dtFoodPopularity.Rows[i]["Price"].ToString()); }
                    sbFoodPopularity.Append("</span></li></ul><div class=\"clear\"></div></div></div>");
                }
                sbTemplate.Replace("{weipin:categorypromotionpopularity4}", sbFoodPopularity.ToString());
            }
            #endregion
            #region 生活日用分类
            DataTable dtLife = ds.Tables[10];
            StringBuilder sbLife = new StringBuilder();
            if (dtLife != null)
            {
                for (int i = 0; i < dtLife.Rows.Count; i++)
                {
                    string _srpath = dtLife.Rows[i]["GoodsPicturePath"].ToString();
                    sbLife.Append("<div class=\"sycon_cp\">");
                    if (dtLife.Rows[i]["DiscountPrice"].ToString() != "") { sbLife.Append("<div class=\"zhek\">" + dtLife.Rows[i]["DiscountPrice"].ToString() + "</div>"); }
                    sbLife.Append("<ul><li><a href=\"/page/" + Convert.ToInt32(dtLife.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtLife.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtLife.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_170x170") + "\"/></a></li>");
                    sbLife.Append("<li class=\"sy_cp\"><a href=\"/page/" + Convert.ToInt32(dtLife.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtLife.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtLife.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\">" + Commonality.CutString(dtLife.Rows[i]["GoodsName"].ToString(), 28) + "</a></li>");
                    sbLife.Append("<li>市场价：￥<span class=\"price_o\">" + dtLife.Rows[i]["MarketPrice"].ToString() + "</span><span class=\"price_n\">微品价：￥" + dtLife.Rows[i]["Price"].ToString() + "</span></li></ul></div>");
                }
                sbTemplate.Replace("{weipin:categorypromotion5}", sbLife.ToString());
            }
            #endregion
            #region 生活日用分类人气
            DataTable dtLifePopularity = ds.Tables[11];
            StringBuilder sbLifePopularity = new StringBuilder();
            if (dtLifePopularity != null)
            {
                for (int i = 0; i < dtLifePopularity.Rows.Count; i++)
                {
                    string _srpath = dtLifePopularity.Rows[i]["GoodsPicturePath"].ToString();
                    sbLifePopularity.Append("<div class=\"sycon_lmenu\"><a href=\"/page/" + Convert.ToInt32(dtLifePopularity.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtLifePopularity.Rows[i]["GoodsID"].ToString() + ".html\" class=\"ico" + (i + 1) + "\" title=\"" + dtLifePopularity.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\">");
                    sbLifePopularity.Append(Commonality.CutString(dtLifePopularity.Rows[i]["GoodsName"].ToString(), 11) + "</a><div class=\"lmenu_con\"");
                    if (i != 0) { sbLifePopularity.Append(" style=\"display:none;\""); }
                    sbLifePopularity.Append("><a href=\"/page/" + Convert.ToInt32(dtLifePopularity.Rows[i]["GoodsID"].ToString()) / 1000 + "/goodsshow_" + dtLifePopularity.Rows[i]["GoodsID"].ToString() + ".html\" title=\"" + dtLifePopularity.Rows[i]["GoodsName"].ToString() + "\" target=\"_blank\"><img src=\"" + _srpath.Insert(_srpath.LastIndexOf("."), "_60x60") + "\" style=\"float:left;\"/></a>");
                    sbLifePopularity.Append("<ul style=\"width:90px;float:left;\"><li>市场价：<span class=\"price_o\">￥" + dtLifePopularity.Rows[i]["MarketPrice"].ToString() + "</span></li><li><span class=\"price_n2\">售价：￥");
                    if (dtLifePopularity.Rows[i]["DiscountPrice"].ToString() != "") { sbLifePopularity.Append(dtLifePopularity.Rows[i]["DiscountPrice"].ToString()); }
                    else { sbLifePopularity.Append(dtLifePopularity.Rows[i]["Price"].ToString()); }
                    sbLifePopularity.Append("</span></li></ul><div class=\"clear\"></div></div></div>");
                }
                sbTemplate.Replace("{weipin:categorypromotionpopularity5}", sbLifePopularity.ToString());
            }
            #endregion
            File.WriteAllText(HttpContext.Current.Server.MapPath("~/index.html"), sbTemplate.ToString());
        }
        #endregion
    }
}