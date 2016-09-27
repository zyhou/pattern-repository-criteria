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
    }

    public interface IBlogFull : IBlogLight
    {
        List<IPosteLight> Postes { get; set; }
    }
}
