using IAccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO
{
    public class CritereBlogModel : ICriteresBlog
    {
        public int? IdBlog { get; set; }

        public bool? IsClos { get; set; }
    }
}
