using IAccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessData
{
    public class BlogModelBuilder
    {
        public static T GetBlogLight<T>(BlogQueryBuilder qb) where T :  IBlogLight
        {
            var res = from b in qb.GetQuery()
                      select new { IdBlog = b.Id };
            return res.Cast<T>().FirstOrDefault();
        }

        public static List<T> GetListeBlogLight<T>(BlogQueryBuilder qb) where T : IBlogLight
        {
            var res = from b in qb.GetQuery()
                      select new { IdBlog = b.Id };
            return res.Cast<T>().ToList();
        }
    }
}
