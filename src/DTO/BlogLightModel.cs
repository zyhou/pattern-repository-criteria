using IAccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO
{
    public class BlogLightModel : IBlogLight
    {
        public int IdBlog { get; set; }
        public string NomBlog { get; set; }
    }
}
