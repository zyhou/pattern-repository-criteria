using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAccessData
{
    public interface IBlogLight
    {
        int IdBlog { get; set; }
        string NomBlog { set; get; }
        string UrlBlog { set; get; }
    }

    public interface IBlogFull : IBlogLight
    {
        List<IPosteLight> Postes { get; set; }
    }

    public interface ICriteresBlog
    {
        int? IdBlog { get; set; }
        bool? IsClos { get; set; }
    }
}
