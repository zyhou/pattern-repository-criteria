using IAccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessData
{
    public class BlogModelBuilder
    {
        public static IQueryable<T> GetBlogLight<T>(BlogQueryBuilder qb) where T : IBlogLight, new()
        {
            var res = from b in qb.GetQuery()
                      select new T { IdBlog = b.IdBlog };
            return res;
        }

    }
}
