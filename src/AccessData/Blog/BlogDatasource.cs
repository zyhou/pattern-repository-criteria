using IAccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessData
{
    public class BlogDatasource
    {
        public BlogDatasource()
        {

        }

        public static BlogDatasource Instance()
        {
            return new BlogDatasource();
        }

        public T GetBlogLight<T>(int idBlog) where T : IBlogLight, new()
        {
            var qb = new BlogQueryBuilder() { IdBlog = idBlog };
            T res = BlogModelBuilder.GetBlogLight<T>(qb).FirstOrDefault();
            return res;
        }

    }
}
