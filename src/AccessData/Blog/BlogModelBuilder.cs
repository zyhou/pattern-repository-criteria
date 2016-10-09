using IAccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessData
{
    public class BlogModelBuilder
    {
        public static IQueryable<T> GetBlogLight<T>(BlogQueryBuilder qb) where T : IBlogLight, new()
        {
            var res = from b in qb.GetQuery()
                      select new T {
                          IdBlog = b.IdBlog,
                          NomBlog = b.Nom,
                          UrlBlog = b.Url};
            return res;
        }

        //  Public Shared Function GetBlogLight(Of T As { New, IBenefLight})(qb As BenefQueryBuilder) As ObjectQuery(Of T)
        //    Dim res As ObjectQuery(Of T) = From m In qb.GetQuery()
        //                                   Select New T With {
        //                                   .Id = m.BENEF_ID,
        //                                   .Name = m.BENEF_NOM,
        //                                   .LastName = m.BENEF_PRENOM}
        //    Return res
        //End Function

    }
}
