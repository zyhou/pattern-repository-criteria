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

        private readonly Contexte _contexte;

        public BlogRepository(Contexte contexte)
        {
            _contexte = contexte;
        }

        public static BlogRepository Instance(Contexte contexte)
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
            blogEntity.Url = blog.UrlBlog;

            _contexte.SaveChanges();

            return blogEntity.IdBlog;
        }

        public void UpdateUrlBlog(int idBlog, string urlBlog)
        {
            Blog blogEntity = _contexte.Blogs.FirstOrDefault(b => b.IdBlog == idBlog);
            if (blogEntity == null) throw new ArgumentException("L'id de blog ne correspond à aucun blog existant.");

            blogEntity.Nom = urlBlog;

            _contexte.SaveChanges();
        }

        public void ClotureBlog(int idBlog)
        {
            Blog blogEntity = _contexte.Blogs.FirstOrDefault(b => b.IdBlog == idBlog);
            if (blogEntity == null) throw new ArgumentException("L'id de blog ne correspond à aucun blog existant.");

            blogEntity.IsClos = true;

            _contexte.SaveChanges();
        }
    }
}
