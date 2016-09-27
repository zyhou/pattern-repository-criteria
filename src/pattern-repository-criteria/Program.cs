using AccessData;
using DTO;
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
            var blog = BlogDatasource.Instance().GetBlogLight<BlogLightModel>(1);

            WriteLine(blog.IdBlog);
            ReadKey();
        }
    }
}
