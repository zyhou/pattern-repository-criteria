using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessData
{
    public class BlogQueryBuilder
    {

        public int? IdBlog { get; set; }

        public IQueryable<BlogEntity> GetQuery()
        {
            return null;
        }
    }

    public class BlogEntity
    {
        public int Id { get; set; }
    }
}
