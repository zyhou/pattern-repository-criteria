using AccessData.Entity;
using IAccessData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessData
{
    public class BlogRepository
    {

        private readonly TContext _contexte;

        public BlogRepository(DbContext contexte)
        {
            _contexte = contexte;
        }

        public static BlogRepository Instance(TContext contexte)
        {
            return new BlogRepository(contexte);
        }

        public int AddUpdateBLogLight(IBlogLight blog)
        {
            if (blog == null) throw new ArgumentNullException("Le model ne peut pas être vide.");

            Blog blogEntity = null;

            if (blog.IdBlog == 0)
            {
                blogEntity = new Blog();
                _contexte.Blogs.Add(blogEntity);
            }
            else
            {
                blogEntity = _contexte.Blogs.FirstOrDefault(b => b.IdBlog == blog.IdBlog);
            }

            blogEntity.IdBlog = blog.IdBlog;
            blogEntity.Nom = blog.NomBlog;

            _contexte.SaveChanges();

            return blogEntity.IdBlog;
        }

    }
}
