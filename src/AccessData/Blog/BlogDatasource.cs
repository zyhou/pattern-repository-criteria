using AccessData.Entity;
using IAccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessData
{
    public class BlogDatasource
    {
        private readonly Contexte _contexte;

        public BlogDatasource(Contexte contexte)
        {
            _contexte = contexte;
        }

        public static BlogDatasource Instance(Contexte contexte)
        {
            return new BlogDatasource(contexte);
        }

        public T GetBlogLight<T>(int idBlog) where T : IBlogLight, new()
        {
            var qb = new BlogQueryBuilder(_contexte) { IdBlog = idBlog };
            T res = BlogModelBuilder.GetBlogLight<T>(qb).FirstOrDefault();
            return res;
        }
        public List<T> GetListeBlogLight<T>(ICriteresBlog criteres) where T : IBlogLight, new()
        {
            var qb = new BlogQueryBuilder(_contexte);
            qb.FeedQuery(criteres);
            List<T> res = BlogModelBuilder.GetBlogLight<T>(qb).ToList();
            return res;
        }

        public int GetCountBlog()
        {
            var qb = new BlogQueryBuilder(_contexte);
            return qb.GetQuery().Count();
        }

        public string GetNomBlog(int idBlog)
        {
            var qb = new BlogQueryBuilder(_contexte) { IdBlog = idBlog };
            string res = qb.GetQuery().Select(b => b.Nom).FirstOrDefault();
            return res;
        }
    }
}
