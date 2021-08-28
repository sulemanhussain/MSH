using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSH.Web.Utility
{
    public class Pagination
    {
        public int CurrentIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get { return Convert.ToInt32(Math.Ceiling((double)TotalCount / PageSize)); } }
        public int TotalCount { get; set; } 
    }
}
