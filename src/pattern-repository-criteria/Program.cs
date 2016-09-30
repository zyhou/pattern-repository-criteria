using AccessData;
using AccessData.Entity;
using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace pattern_repository_criteria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<Contexte>(options => options.UseSqlite($"Filename={Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "blog.db")}"));
            IServiceProvider services = serviceCollection.BuildServiceProvider();

            var context = services.GetService<Contexte>();

            // Ajout d'un nouveau blog
            int idBlog = BlogRepository.Instance(context).AddUpdateBLogLight(new BlogLightModel() { NomBlog = "Blog perso", UrlBlog = "https://zyhou.github.io/blog/" });

            // Récupération du nombre de blog
            int nbrBlog = BlogDatasource.Instance(context).GetCountBlog();
            WriteLine($"Nombre de blog : {nbrBlog}");

            // Récupération du nom du blog
            string nom = BlogDatasource.Instance(context).GetNomBlog(idBlog);
            WriteLine($"Nom du blog : {nom}");

            // Mise à jour du blog
            BlogRepository.Instance(context).UpdateUrlBlog(idBlog, "Maxime Richard");

            // Affichage des infos du blog
            var blog = BlogDatasource.Instance(context).GetBlogLight<BlogLightModel>(idBlog);
            WriteLine($"{blog.NomBlog} {blog.UrlBlog}");

            // Ajout deuxieme blog
            idBlog = BlogRepository.Instance(context).AddUpdateBLogLight(new BlogLightModel() { NomBlog = "Blog perso - 2 ", UrlBlog = "https://zyhou.github.io/blog/" });

            // Clotûre du blog
            BlogRepository.Instance(context).ClotureBlog(idBlog);

            // Récupération du nombre de blog
            nbrBlog =  BlogDatasource.Instance(context).GetCountBlog();
            WriteLine($"Nombre de blog : {nbrBlog}");

            // Récupération de tout les blogs non clos
            var critere = new CritereBlogModel() { IsClos = false };
            var blogs = BlogDatasource.Instance(context).GetListeBlogLight<BlogLightModel>(critere);
            foreach(var b in blogs)
            {
                WriteLine($"{b.NomBlog} {b.UrlBlog}");
            }

            ReadKey();
        }
    }
}
