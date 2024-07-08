using DotNetTrainingBatch3.MvcApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetTrainingBatch3.MvcApp2.Controllers
{
    public class EFCoreBlogController : Controller
    {      

        private readonly IBlogApi _blogapi;

        public EFCoreBlogController(IBlogApi blogapi)
        {
            _blogapi = blogapi;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)           
        {
            var model = await _blogapi.GetBlogs(pageNo, pageSize);
            return View(model);
        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> BlogSaveAsync(BlogModel blog)
        {
            await _blogapi.CreateBlog(blog);
            return Redirect("/EFCoreBlog");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> BlogEditAsync(int id)
        {            
            var model = await _blogapi.GetBlog(id);
            return View("BlogEdit",model);
        }

        
        [ActionName("Update")]
        public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
        {
            await _blogapi.UpdateBlog(id,blog);
            
            return Redirect("/EFCoreBlog");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> BlogDelete(int id)
        {
            await _blogapi.DeleteBlog(id);

            return Redirect("/EFCoreBlog");
        }
    }
}
