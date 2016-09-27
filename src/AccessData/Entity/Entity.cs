using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessData.Entity
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./blog.db");
        }
    }
    public class Blog
    {
        [Key]
        public int IdBlog { get; set; }
        public string Url { get; set; }
        public string Nom { get; set; }

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
