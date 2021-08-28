using MSH.Entities.QnA;
using MSH.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSH.Web.Models.ViewModels
{
    public class QueryPaginationVM
    {
        public List<Query> Queries { get; set; }
        public Pagination Pagination { get; set; }
    }
}
