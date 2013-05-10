using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestLuceneS
{
    public class BooksManager
    {
        public List<Books> GetModelList(string str)
        {
            List<Books> ret = new List<Books>();
            ret.Add(new Books { Id = 1, Title = "我们", ContentDescription = "也许" });
            ret.Add(new Books { Id = 2, Title = "我们2", ContentDescription = "也许2" });
            ret.Add(new Books { Id = 13, Title = "我们3", ContentDescription = "也许3" });
            ret.Add(new Books { Id = 14, Title = "我们4", ContentDescription = "也许4" });
            ret.Add(new Books { Id = 15, Title = "我们5", ContentDescription = "也许5" });
            ret.Add(new Books { Id = 16, Title = "我们6", ContentDescription = "也许6" });
            ret.Add(new Books { Id = 17, Title = "我们7", ContentDescription = "也许7" });

            return ret;
        }

    }
}