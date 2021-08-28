using MSH.Entities.Repository;

namespace MSH.Service
{
    public class QueryService
    {
        private IQuery _queryService = null;

        public QueryService(IQuery queryService)
        {
            _queryService = queryService;
        }

        public void DeleteQuery(Entities.QnA.Query query)
        {
            _queryService.GetQueries();
        }

        //public IEnumerable<Entities.QnA.Query> GetAllQueries()
        //{
        //    return _applicationDBContext.Query.ToList();
        //}

        //public Entities.QnA.Query GetQuery(string guid)
        //{
        //    return _applicationDBContext.Query.Where(x => x.GUID.Equals(guid)).FirstOrDefault();
        //}

        //public void SaveQuery(Entities.QnA.Query query)
        //{
        //    var entity = _applicationDBContext.Query.Where(x => x.GUID.Equals(query.GUID)).FirstOrDefault();

        //    if (entity == null)
        //    {
        //        query.GUID = Guid.NewGuid().ToString();
        //        query.InsertBy = 1;
        //        query.InsertDate = DateTime.Now;
        //        _applicationDBContext.Attach(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        //        _applicationDBContext.Attach(entity).CurrentValues.SetValues(query);
        //    }
        //    else
        //    {
        //        query.UpdateBy = 1;
        //        query.UpdateDate = DateTime.Now;
        //        _applicationDBContext.Attach(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        //        _applicationDBContext.Attach(entity).CurrentValues.SetValues(query);
        //    }
        //    _applicationDBContext.SaveChanges();
        //}
    }
}
