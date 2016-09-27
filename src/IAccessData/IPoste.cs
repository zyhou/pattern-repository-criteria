using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAccessData
{
    public interface IPosteLight
    {
        int IdPoste { get; set; }
        string TitrePoste { set; get; }
        string Description { get; set; }
        DateTime Date { get; set; }
    }

    public interface IPosteFull : IPosteLight
    {
        string Contenue { get; set; }
    }
}
