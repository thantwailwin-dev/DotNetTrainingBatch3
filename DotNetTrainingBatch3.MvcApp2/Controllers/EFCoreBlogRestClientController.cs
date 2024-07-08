/*using DotNetTrainingBatch3.MvcApp2.Models;
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

        private readonly RestClient _restClient;

        public EFCoreBlogController(RestClient restClient)
        {
            _restClient = restClient;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)           
        {
            BlogResponseModel model = new BlogResponseModel();
            RestRequest restRequest = new RestRequest($"API/EFCoreBlog/{pageNo}/{pageSize}", Method.Get);
            var response = await _restClient.ExecuteAsync(restRequest);
            if(response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;
                model = JsonConvert.DeserializeObject<BlogResponseModel>(jsonStr!)!;

            }            
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
            RestRequest restRequest = new RestRequest($"API/EFCoreBlog", Method.Post);
            restRequest.AddJsonBody(blog);
            _restClient.ExecuteAsync(restRequest);
            return Redirect("/EFCoreBlog");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> BlogEditAsync(int id)
        {            
            RestRequest restRequest = new RestRequest($"API/EFCoreBlog/{id}", Method.Get);
            var response = await _restClient.ExecuteAsync(restRequest);
            if (!response.IsSuccessStatusCode)
            {
                return Redirect("/EFCoreBlog");             

            }
            var jsonStr = response.Content;
            BlogModel model = JsonConvert.DeserializeObject<BlogModel>(jsonStr!)!;
            return View("BlogEdit",model);
        }

        
        [ActionName("Update")]
        public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
        {
            RestRequest restRequest = new RestRequest($"API/EFCoreBlog/{id}", Method.Put);
            restRequest.AddJsonBody(blog);
            _restClient.ExecuteAsync(restRequest);
            
            return Redirect("/EFCoreBlog");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> BlogDelete(int id)
        {
            RestRequest restRequest = new RestRequest($"API/EFCoreBlog/{id}", Method.Delete);            
            _restClient.ExecuteAsync(restRequest);

            return Redirect("/EFCoreBlog");
        }
    }
}
*/