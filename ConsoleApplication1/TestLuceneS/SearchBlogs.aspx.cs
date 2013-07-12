using System;
using System.Collections.Generic;
using System.IO;

using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;


namespace TestLuceneS
{
    public partial class SearchBlogs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //创建索引事件  可以防止在用户点击查询事件前执行 去掉页面中的"创建索引"按钮
        protected void CreateView_Click(object sender, EventArgs e)
        {
            string indexPath = @"C:\luceneTest"; //索引文档保存位置
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());
            bool isUpdate = IndexReader.IndexExists(directory); //是否存在索引库文件夹以及索引库特征文件
            if (isUpdate)
            {
                //如果索引目录被锁定（比如索引过程中程序异常退出或另一进程在操作），则解锁
                if (IndexWriter.IsLocked(directory))
                {
                    IndexWriter.Unlock(directory);
                }
            }
            //创建索引库对象   new PanGuAnalyzer()指定使用盘古分词进行切词
            IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), !isUpdate, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED);
            BooksManager bookManager = new BooksManager();
            List<Books> bookList = bookManager.GetModelList("");
            foreach (var book in bookList)
            {
                Document document = new Document(); //new 一篇文档 对象
                //所有字段的值都将以字符串类型保存
                //Field.Store表示是否保存字段原值。指定Field.Store.YE的字段在检索时才能用document.Get取出来值  NOT_ANALYZED指定不按照分词后的结果保存
                document.Add(new Field("id", book.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                document.Add(new Field("title", book.Title, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
                //Field.Index. ANALYZED指定文章内容按照分词后结果保存  否则无法实现后续的模糊查找  WITH_POSITIONS_OFFSETS指示不仅保存分割后的词 还保存词之间的距离
                document.Add(new Field("content", book.ContentDescription, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
                writer.AddDocument(document); //文档写入索引库
            }
            writer.Close();
            directory.Close(); //不要忘了Close，否则索引结果搜不到
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string indexPath = @"C:\luceneTest";
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NoLockFactory());
            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader); //Index：索引
            //搜索条件
            PhraseQuery query = new PhraseQuery();
            //把用户输入的关键字进行分词
            foreach (string word in SplitContent.SplitWords(txtSerach.Text.ToLower()))
            {
                query.Add(new Term("content", word));
            }
            query.SetSlop(100); //指定关键词相隔最大距离
            //TopScoreDocCollector盛放查询结果的容器
            TopScoreDocCollector collector = TopScoreDocCollector.create(1000, true);   //1000表示最多结果条数
            searcher.Search(query, null, collector);//根据query查询条件进行查询，查询结果放入collector容器
            //TopDocs 指定0到GetTotalHits() 即所有查询结果中的文档
            ScoreDoc[] docs = collector.TopDocs(0, collector.GetTotalHits()).scoreDocs;
            //展示数据实体对象集合
            List<Books> bookResult = new List<Books>();
            for (int i = 0; i < docs.Length; i++)
            {
                //需要获得文档的详细内容的时候通过searcher.Doc来根据文档id来获得文档的详细内容对象Document
                int docId = docs[i].doc;//得到查询结果文档的id（Lucene内部分配的id）
                Document doc = searcher.Doc(docId);//找到文档id对应的文档详细信息
                Books book = new Books();
                book.Title = doc.Get("title");
                //book.ContentDescription = doc.Get("content");//未使用高亮
                //搜索关键字高亮显示
                book.ContentDescription = SplitContent.HightLight(txtSerach.Text, doc.Get("content"));
                book.Id = Convert.ToInt32(doc.Get("id"));
                bookResult.Add(book);
            }
            //设置Repeater1  绑定查询结果集合
            Repeater1.DataSource = bookResult;
            Repeater1.DataBind();
        }




    }
}