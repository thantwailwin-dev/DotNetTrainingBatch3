using DotNetTrainingBatch3.MvcApp.Db;
using DotNetTrainingBatch3.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.MvcApp.Controllers
{
	public class BlogPaginationController : Controller
    {
        [ActionName("Index")]
        public IActionResult BlogIndex(int pageNo = 1,int pageSize = 10)
		{
            AppDbContext _appDbContext = new AppDbContext();
            int rowCount = _appDbContext.Blogs.Count();
            int pageCount = rowCount / pageSize;

            if (rowCount % pageSize > 0)
                pageCount++;

            if (pageNo > pageCount)
            {
                return Redirect("/EFCoreBlog");
            }


            List<BlogModel> lst = _appDbContext.Blogs
                /*.OrderByDescending(x => x.BlogId)*/
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
            .ToList();


            BlogResponseModel model = new BlogResponseModel();
            model.Data = lst;
            model.PageNo = pageNo;
            model.PageSize = pageSize;
            model.PageCount = pageCount;
            return View("BlogIndex",model);
		}
	}
}
