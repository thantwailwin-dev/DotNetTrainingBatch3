using DotNetTrainingBatch3.MvcApp.Db;
using DotNetTrainingBatch3.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.MvcApp.Controllers
{
    public class EFCoreBlogAjaxController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public EFCoreBlogAjaxController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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
            BlogModel item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            return View("BlogEdit", item);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id,BlogModel blog)
        
        {
            BlogMessageResponseModel model = new BlogMessageResponseModel();
            BlogModel item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                /*model.IsSuccess = false;
                model.Message = "No Data Found";*/
                model = new BlogMessageResponseModel()
                {
                    IsSuccess = false,
                    Message = "No Data Found"
                };
                return Json(model);
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            
            int result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            model = new BlogMessageResponseModel()
            {
                IsSuccess = result > 0,
                Message = message
            };
            return Json(model);
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
            int result = _appDbContext.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            BlogMessageResponseModel model = new BlogMessageResponseModel() 
            { 
                IsSuccess = result > 0,
                Message = message
            };


            return Json(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult BlogDelete(BlogModel blog)
        {
            BlogMessageResponseModel model = new BlogMessageResponseModel();
            BlogModel item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == blog.BlogId);
            if (item is null)
            {
                /*model.IsSuccess = false;
                model.Message = "No Data Found";*/
                model = new BlogMessageResponseModel()
                {
                    IsSuccess = false,
                    Message = "No Data Found"
                };
                return Json(model);
            }

            _appDbContext.Blogs.Remove(item);
            int result = _appDbContext.SaveChanges();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            model = new BlogMessageResponseModel()
            {
                IsSuccess = result > 0,
                Message = message
            };


            return Json(model);
        }
    }
}
