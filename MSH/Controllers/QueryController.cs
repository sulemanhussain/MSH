using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MSH.Entities.AppDBContext;
using MSH.Entities.QnA;
using MSH.Web.Models.ViewModels;
using MSH.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSH.Web.Controllers
{
    [Authorize]
    public class QueryController : Controller
    {
        private ApplicationDBContext _applicationDBContext;

        public QueryController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public IActionResult Index()
        {
            ViewBag.Category = _applicationDBContext.Category.Select(x => new SelectListItem { Text = x.Name.ToString(), Value = x.CategoryID.ToString() });
            var queries = _applicationDBContext.Query.ToList(); //queryService.GetQueries();
            Pagination pagination = new Pagination()
            {
                CurrentIndex = 1,
                TotalCount = queries.Count(),
                PageSize = 5
            };
            QueryPaginationVM queryPaginationVM = new QueryPaginationVM()
            {
                Queries = queries.Take(pagination.CurrentIndex * pagination.PageSize).Skip((pagination.CurrentIndex - 1) * pagination.PageSize).ToList(),
                Pagination = pagination
            };
            return View(queryPaginationVM);
        }

        [HttpPost]
        [Route("{controller}/{action}")]
        [Route("{controller}/{action}/{CurrentIndex?}")]
        public IActionResult Index(IFormCollection keyValues, int CurrentIndex = 1)
        {
            List<SelectListItem> category = _applicationDBContext.Category.Select(x => new SelectListItem { Text = x.Name.ToString(), Value = x.CategoryID.ToString() }).ToList();
            int CategoryId = Convert.ToInt32(keyValues["CategoryID"]);
            string Tags = keyValues["Tag"];
            string Question = keyValues["Question"];
            ModelState.Clear();
            var queries = _applicationDBContext.Query.ToList();

            category.ForEach(delegate (SelectListItem listItem)
            {
                listItem.Selected = listItem.Value == CategoryId.ToString() ? true : false;
            });

            ViewBag.Tags = Tags;
            ViewBag.Question = Question;
            ViewBag.Category = category;

            if (CategoryId > 0)
            {
                queries = queries.Where(x => x.CategoryID == CategoryId).ToList();
            }
            if (!string.IsNullOrEmpty(Tags.Trim()))
            {
                var tagsValues = new HashSet<string>(Tags.Split(',').Select(x => x.Trim().ToLower()));

                var quer = new List<Query>();
                foreach (var item in tagsValues)
                {
                    var data = queries.Where(x => x.Tag.Trim().ToLower().Contains(item.Trim().ToLower()));
                    if (!quer.Intersect(data).Any())
                    {
                        quer.AddRange(queries.Where(x => x.Tag.Trim().ToLower().Contains(item.Trim().ToLower())).ToList());
                    }
                }
                queries = quer.ToList();

                //queries = queries.Where(x => x.Tag.Trim().Split(',').Any(tag => tagsValues.Contains(tag))).ToList();
                //queries = queries.Where(x => x.Tag.Contains(tagsValues.Any(x=>x))).ToList();
            }
            if (!string.IsNullOrEmpty(Question.Trim()))
            {
                queries = queries.Where(x => x.Question.ToLower().Contains(Question.ToLower())).ToList();
            }

            CurrentIndex = Convert.ToInt32(keyValues["CurrentIndex"]) != 0 ? Convert.ToInt32(keyValues["CurrentIndex"]) : CurrentIndex;

            Pagination pagination = new Pagination();
            pagination.CurrentIndex = CurrentIndex;
            pagination.TotalCount = queries.Count();
            pagination.PageSize = 5;

            QueryPaginationVM queryPaginationVM = new QueryPaginationVM()
            {
                Queries = queries.Take(pagination.CurrentIndex * pagination.PageSize).Skip((pagination.CurrentIndex - 1) * pagination.PageSize).ToList(),
                Pagination = pagination
            };

            return View(queryPaginationVM);
        }

        [Route("{action}/{guid?}")]
        [HttpGet]
        public IActionResult AddQuery(string guid = "")
        {
            var query = new Query();
            if (!string.IsNullOrEmpty(guid))
            {
                query = _applicationDBContext.Query.Where(x => x.GUID.Equals(guid)).FirstOrDefault();
            }
            IEnumerable<SelectListItem> category = _applicationDBContext.Category.Select(x => new SelectListItem { Text = x.Name.ToString(), Value = x.CategoryID.ToString() });
            ViewBag.Category = category;
            return View(query);
        }

        public IEnumerable<SelectListItem> ChildCategory(int CategoryID)
        {
            var childCategory = _applicationDBContext.Category.Where(x => x.ParentCategoryID == CategoryID).Select(x => new SelectListItem { Text = x.Name.ToString(), Value = x.CategoryID.ToString() });
            return childCategory;
        }

        [HttpPost]
        [Route("{action}/{guid?}")]
        public IActionResult AddQuery(Query query)
        {
            if (ModelState.IsValid)
            {
                var entity = _applicationDBContext.Query.Where(x => x.GUID.Equals(query.GUID)).FirstOrDefault();
                //var user = HttpContext.User.Identity.Name;
                if (entity == null)
                {
                    query.GUID = Guid.NewGuid().ToString();
                    query.InsertBy = 1;
                    query.InsertDate = DateTime.Now;
                    _applicationDBContext.Attach(query).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    _applicationDBContext.Add(query);
                }
                else
                {
                    query.UpdateBy = 1;
                    query.UpdateDate = DateTime.Now;
                    //_applicationDBContext.Entry<Query>(query);
                    //_applicationDBContext.Update(query);
                    _applicationDBContext.Attach(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    _applicationDBContext.Attach(entity).CurrentValues.SetValues(query);
                }
                _applicationDBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            IEnumerable<SelectListItem> category = _applicationDBContext.Category.Select(x => new SelectListItem { Text = x.Name.ToString(), Value = x.CategoryID.ToString() });
            ViewBag.Category = category;
            return View();
        }

        [HttpGet]
        public IActionResult DeleteQuery(string guid)
        {
            var query = _applicationDBContext.Query.Where(x => x.GUID == guid).FirstOrDefault();
            if (query != null)
            {
                _applicationDBContext.Query.Remove(query);
                _applicationDBContext.SaveChanges();
            }
            return Json(Response.StatusCode.ToString());
        }
    }
}