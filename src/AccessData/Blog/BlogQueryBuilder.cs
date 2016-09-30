using AccessData.Entity;
using IAccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessData
{
    public class BlogQueryBuilder
    {

        private readonly Contexte _contexte;

        public int? IdBlog { get; set; }
        public bool? IsClos { get; set; }

        public BlogQueryBuilder(Contexte contexte)
        {
            _contexte = contexte;
        }

        public static BlogQueryBuilder Instance(Contexte contexte)
        {
            return new BlogQueryBuilder(contexte);
        }

        internal void FeedQuery(ICriteresBlog criteres)
        {
            IdBlog = criteres.IdBlog;
            IsClos = criteres.IsClos;
        }

        public IQueryable<Blog> GetQuery()
        {
            IQueryable<Blog> req = _contexte.Blogs;

            if(IdBlog.HasValue)
            {
                req = req.Where(b => b.IdBlog == IdBlog.Value);
            }

            if (IsClos.HasValue)
            {
                req = req.Where(b => b.IsClos == IsClos.Value);
            }

            return req;
        }
  
    }
}
