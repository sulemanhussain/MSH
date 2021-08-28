using MSH.Entities.QnA;
using System.Collections.Generic;

namespace MSH.Entities.Repository
{
    public interface IQuery
    {
        List<Query> GetQueries();

        Query GetQuery(string guid);
    }
}