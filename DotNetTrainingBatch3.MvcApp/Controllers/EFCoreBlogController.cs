using DotNetTrainingBatch3.MvcApp.Db;
using DotNetTrainingBatch3.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.MvcApp.Controllers
{
    public class EFCoreBlogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public EFCoreBlogController(AppDbContext context)
        {
            _appDbContext = context;
        }

        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            List<BlogModel> lst = _appDbContext.Blogs.ToList();
            return View("BlogIndex",lst);
        }

        [ActionName("Edit")]
        public IActionResult BlogEdit(int id)
        {
            BlogModel item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id)!;
            return View("BlogEdit", item);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id,BlogModel blog)
        {
            BlogModel item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id)!;
            /*if(item is null)
            {
                return Redirect("/Blog");
            }*/
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            /*_appDbContext.Blogs.Update(item);*/
            _appDbContext.SaveChanges();

            return Redirect("/EFCoreBlog");
        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {            
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult BlogSave(BlogModel blog)
        {
            _appDbContext.Blogs.Add(blog);
            _appDbContext.SaveChanges();

            return Redirect("/EFCoreBlog");
        }

        [ActionName("Delete")]
        public IActionResult BlogDelete(int id)
        {
            var item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);

            _appDbContext.Blogs.Remove(item);
            _appDbContext.SaveChanges();

            return Redirect("/EFCoreBlog");
        }
    }
}
