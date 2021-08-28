using MSH.Entities.AppDBContext;
using MSH.Entities.QnA;
using MSH.Entities.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MSH.Entities.Business
{
    public class QueryRepository : IQuery
    {
        private ApplicationDBContext _applicationDBContext;

        public QueryRepository()
        {
            _applicationDBContext = new ApplicationDBContext();
        }

        public QueryRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public List<Query> GetQueries()
        {
            return _applicationDBContext.Query.ToList();
        }

        public Query GetQuery(string guid)
        {
            return _applicationDBContext.Query.Where(x => x.GUID == guid).FirstOrDefault();
        }
    }
}