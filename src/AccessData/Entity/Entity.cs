using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessData.Entity
{

    public class ContextetFactory : IDbContextFactory<Contexte>
    {

        public Contexte Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexte>();
            optionsBuilder.UseSqlite("Filename=./blog.db");

            return new Contexte(optionsBuilder.Options);
        }
    }

    public class Contexte : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public Contexte(DbContextOptions<Contexte> options) : base(options)
        {

        }
    }
    public class Blog
    {
        [Key]
        public int IdBlog { get; set; }
        public string Url { get; set; }
        public string Nom { get; set; }
        public bool IsClos { get; set; }

        public List<Post> Postes { get; set; }
    }

    public class Post
    {
        [Key]
        public int IdPoste { get; set; }
        public string Titre { get; set; }
        public string Content { get; set; }

        public int IdBlog { get; set; }
        public Blog Blog { get; set; }
    }
}
