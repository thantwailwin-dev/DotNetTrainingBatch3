using DotNetTrainingBatch3.MvcApp.Db;
using DotNetTrainingBatch3.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BlogController()
        {
            _appDbContext = new AppDbContext();
        }

        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            List<BlogModel> lst = _appDbContext.Blogs.ToList();
            return View("BlogIndex",lst);
        }
    }
}
