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

namespace pattern_repository_criteria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<Contexte>(options => options.UseSqlite("Filename=./blog.db"));
            IServiceProvider services = serviceCollection.BuildServiceProvider();

            using (var context = services.GetService<Contexte>())
            {
                BlogRepository.Instance(context).AddUpdateBLogLight(new BlogLightModel() { NomBlog = "Blog perso" });
            }


            //BlogRepository.Instance().AddUpdateBLogLight(new BlogLightModel() { NomBlog = "Blog perso" });

            //var blog = BlogDatasource.Instance().GetBlogLight<BlogLightModel>(1);

            //WriteLine(blog.IdBlog);

            ReadKey();
        }
    }
}
