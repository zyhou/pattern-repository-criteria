using AccessData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessData
{
    public class BlogQueryBuilder
    {
        private readonly BloggingContext blogContext;
        public int? IdBlog { get; set; }

        public BlogQueryBuilder()
        {
            blogContext = new BloggingContext();
        }

        public IQueryable<Blog> GetQuery()
        {
            return blogContext.Blogs;
        }
    }
}
