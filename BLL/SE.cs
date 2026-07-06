using System.Collections.Generic;

using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.PanGu;
using PanGu;
using System;
using weipin.Model;

namespace weipin.BLL
{
    public class SE : System.Web.UI.Page
    {
        public SE() { }
        /// <summary>
        /// 分词
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="ktTokenizer">分词方法</param>
        /// <returns></returns>
        private static string GetKeyWordsSplitBySpace(string key, PanGuTokenizer ktTokenizer)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            ICollection<WordInfo> words = ktTokenizer.SegmentToWordInfos(key);
            foreach (WordInfo word in words)
            {
                if (word == null) { continue; }
                result.AppendFormat("{0}^{1}.0 ", word.Word, (int)Math.Pow(3, word.Rank));
            }
            return result.ToString().Trim();
        }
        /// <summary>
        /// 商品搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="nowpage">当前页数</param>
        /// <param name="perpage">每页条数</param>
        /// <param name="field">排序字段</param>
        /// <param name="sort">排序方式(true:降序;false:升序)</param>
        /// <returns></returns>
        public DataList<Model.Goods> GoodsSearch(string key, int nowpage, int perpage, string field, bool sort)
        {
            DataList<Model.Goods> dmg = new DataList<weipin.Model.Goods>();
            IndexSearcher mysea = null;
            try
            {
                string INDEX_STORE_PATH = Server.MapPath("~/file/index");
                //构建一个索引搜索器
                mysea = new IndexSearcher(INDEX_STORE_PATH);
                key = GetKeyWordsSplitBySpace(key, new PanGuTokenizer());
                MultiFieldQueryParser q = new MultiFieldQueryParser(new string[] { "GoodsName", "Keywords" }, new PanGuAnalyzer(true));
                //用QueryParser.Parse方法实例化一个查询
                if (!string.IsNullOrEmpty(key))
                {
                    Query query = q.Parse(key);
                    //分页计算，start为每页第一个索引，end是最后一个索引
                    int start = (nowpage - 1) * perpage;
                    int end = nowpage * perpage;
                    TopDocs tds = null;
                    if (field != "") { if (field == "DiscountPrice") { Sort st = new Sort(new SortField(field, SortField.FLOAT, sort)); tds = mysea.Search(query, null, end, st); } else { Sort st = new Sort(new SortField(field, SortField.STRING, sort)); tds = mysea.Search(query, null, end, st); } }
                    else { tds = mysea.Search(query, end); }
                    if (tds.totalHits != 0)
                    {
                        ScoreDoc[] sd = tds.scoreDocs;
                        if (end >= tds.totalHits) { end = tds.totalHits; }
                        dmg.Total = tds.totalHits;
                        for (int i = start; i < end; i++)
                        {
                            //高亮显示
                            PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter = new PanGu.HighLight.SimpleHTMLFormatter("<font color=\"red\">", "</font>");
                            PanGu.HighLight.Highlighter highlighter = new PanGu.HighLight.Highlighter(simpleHTMLFormatter, new Segment());
                            highlighter.FragmentSize = 100;
                            Document doc = mysea.Doc(sd[i].doc);
                            Model.Goods mg = new weipin.Model.Goods();
                            mg.GoodsID = Convert.ToInt32(doc.Get("GoodsID"));
                            mg.GoodsName = doc.Get("GoodsName");
                            mg.GoodsNameStyle = highlighter.GetBestFragment(key, Common.Commonality.CutString(doc.Get("GoodsName"), 28));
                            mg.MarketPrice = Convert.ToDouble(doc.Get("MarketPrice"));
                            mg.Price = Convert.ToDouble(doc.Get("Price"));
                            mg.DiscountPrice = Convert.ToDouble(doc.Get("DiscountPrice"));
                            mg.GoodsPicturePath = doc.Get("GoodsPicturePath");
                            dmg.Rows.Add(mg);
                        }
                    }
                }
            }
            catch { throw; }
            finally { mysea.Close(); }
            return dmg;
        }
        /// <summary>
        /// 创建所有商品的索引
        /// <param name="indexoptimize">是否进行索引优化</param>
        /// </summary>
        /// <returns></returns>
        public void CreateAllGoodsIndex(bool indexoptimize)
        {
            DAL.Goods dg = new weipin.DAL.Goods();
            List<Model.Goods> lmg = dg.SelectAllGoods();
            if (lmg != null && lmg.Count > 0)
            {
                string INDEX_STORE_PATH = Server.MapPath("~/file/index");
                IndexWriter writer = null;
                try
                {
                    writer = new IndexWriter(INDEX_STORE_PATH, new PanGuAnalyzer(), true);
                    writer.SetMergeFactor(301);
                    writer.SetMaxBufferedDocs(301);
                    for (int i = 0; i < lmg.Count; i++)
                    {
                        Document doc = new Document();
                        doc.Add(new Field("GoodsID", lmg[i].GoodsID.ToString(), Field.Store.YES, Field.Index.UN_TOKENIZED));
                        doc.Add(new Field("GoodsName", lmg[i].GoodsName.ToString(), Field.Store.YES, Field.Index.TOKENIZED));
                        doc.Add(new Field("Keywords", lmg[i].Keywords, Field.Store.NO, Field.Index.TOKENIZED));
                        doc.Add(new Field("MarketPrice", lmg[i].MarketPrice.ToString(), Field.Store.YES, Field.Index.NO));
                        doc.Add(new Field("Price", lmg[i].Price.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                        if (lmg[i].DiscountPrice != 0) { doc.Add(new Field("DiscountPrice", lmg[i].DiscountPrice.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED)); } else { doc.Add(new Field("DiscountPrice", lmg[i].Price.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED)); }
                        doc.Add(new Field("GoodsPicturePath", lmg[i].GoodsPicturePath.ToString(), Field.Store.YES, Field.Index.NO));
                        doc.Add(new Field("AddTime", lmg[i].AddTime.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                        writer.AddDocument(doc);
                    }
                    //索引优化
                    if (indexoptimize == true) { writer.Optimize(); }
                }
                catch { throw; }
                finally { writer.Close(); }
            }
        }
        /// <summary>
        /// 建立单个索引
        /// </summary>
        /// <param name="mg"></param>
        /// <returns></returns>
        public void CreateSingleIndex(Model.Goods mg)
        {
            string INDEX_STORE_PATH = Server.MapPath("~/file/index");
            IndexWriter writer = null;
            try
            {
                writer = new IndexWriter(INDEX_STORE_PATH, new PanGuAnalyzer(), false);
                writer.SetMergeFactor(301);
                writer.SetMaxBufferedDocs(301);
                Document doc = new Document();
                doc.Add(new Field("GoodsID", mg.GoodsID.ToString(), Field.Store.YES, Field.Index.UN_TOKENIZED));
                doc.Add(new Field("GoodsName", mg.GoodsName.ToString(), Field.Store.YES, Field.Index.TOKENIZED));
                doc.Add(new Field("Keywords", mg.Keywords, Field.Store.NO, Field.Index.TOKENIZED));
                doc.Add(new Field("MarketPrice", mg.MarketPrice.ToString(), Field.Store.YES, Field.Index.NO));
                doc.Add(new Field("Price", mg.Price.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                if (mg.DiscountPrice != 0) { doc.Add(new Field("DiscountPrice", mg.DiscountPrice.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED)); } else { doc.Add(new Field("DiscountPrice", mg.Price.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED)); }
                doc.Add(new Field("GoodsPicturePath", mg.GoodsPicturePath.ToString(), Field.Store.YES, Field.Index.NO));
                doc.Add(new Field("AddTime", mg.AddTime.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                writer.AddDocument(doc);
            }
            catch { throw; }
            finally { writer.Close(); }
        }
        /// <summary>
        /// 删除索引
        /// </summary>
        /// <param name="gid">GoodsID</param>
        /// <param name="indexoptimize">是否进行索引优化</param>
        /// <returns></returns>
        public void DeleteSingleIndex(int gid, bool indexoptimize)
        {
            string INDEX_STORE_PATH = Server.MapPath("~/file/index");
            IndexWriter writer = null;
            try
            {
                writer = new IndexWriter(INDEX_STORE_PATH, new PanGuAnalyzer(), false);
                writer.DeleteDocuments(new Term("GoodsID", gid.ToString()));
                //索引优化
                if (indexoptimize == true) { writer.Optimize(); }
            }
            catch { throw; }
            finally { writer.Close(); }
        }
        /// <summary>
        /// 更新索引
        /// </summary>
        /// <param name="mg"></param>
        /// <param name="indexoptimize">是否进行索引优化</param>
        /// <returns></returns>
        public void UpdateSingleIndex(Model.Goods mg, bool indexoptimize)
        {
            string INDEX_STORE_PATH = Server.MapPath("~/file/index");
            IndexWriter writer = null;
            try
            {
                writer = new IndexWriter(INDEX_STORE_PATH, new PanGuAnalyzer(), false);
                Document doc = new Document();
                doc.Add(new Field("GoodsID", mg.GoodsID.ToString(), Field.Store.YES, Field.Index.UN_TOKENIZED));
                doc.Add(new Field("GoodsName", mg.GoodsName.ToString(), Field.Store.YES, Field.Index.TOKENIZED));
                doc.Add(new Field("Keywords", mg.Keywords, Field.Store.NO, Field.Index.TOKENIZED));
                doc.Add(new Field("MarketPrice", mg.MarketPrice.ToString(), Field.Store.YES, Field.Index.NO));
                doc.Add(new Field("Price", mg.Price.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                if (mg.DiscountPrice != 0) { doc.Add(new Field("DiscountPrice", mg.DiscountPrice.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED)); } else { doc.Add(new Field("DiscountPrice", mg.Price.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED)); }
                doc.Add(new Field("GoodsPicturePath", mg.GoodsPicturePath.ToString(), Field.Store.YES, Field.Index.NO));
                doc.Add(new Field("AddTime", mg.AddTime.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                writer.UpdateDocument(new Term("GoodsID", mg.GoodsID.ToString()), doc);
                //索引优化
                if (indexoptimize == true) { writer.Optimize(); }
            }
            catch { throw; }
            finally { writer.Close(); }
        }
    }
}