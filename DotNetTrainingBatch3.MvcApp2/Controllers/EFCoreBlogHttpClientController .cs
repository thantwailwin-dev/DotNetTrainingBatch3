/*using DotNetTrainingBatch3.MvcApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetTrainingBatch3.MvcApp2.Controllers
{
    public class EFCoreBlogController : Controller
    {      

        private readonly HttpClient _httpClient;

        public EFCoreBlogController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)        
        {
            BlogResponseModel model = new BlogResponseModel();
            var response = await _httpClient.GetAsync($"API/EFCoreBlog/{pageNo}/{pageSize}");
            if(response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<BlogResponseModel>(jsonStr);

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
            HttpContent content = new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8, Application.Json);
            await _httpClient.PostAsync("API/EFCoreBlog",content);
            return Redirect("/EFCoreBlog");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> BlogEditAsync(int id)
        {
            var response = await _httpClient.GetAsync($"API/EFCoreBlog/{id}");
            if(!response.IsSuccessStatusCode )
            {
                return Redirect("/EFCoreBlog");
            }
            var jsonStr = await response.Content.ReadAsStringAsync();
            BlogModel model = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
            return View("BlogEdit",model);
        }

        
        [ActionName("Update")]
        public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8, Application.Json);
            await _httpClient.PutAsync($"API/EFCoreBlog/{id}", content);
            return Redirect("/EFCoreBlog");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> BlogDelete(int id)
        {
            await _httpClient.DeleteAsync($"API/EFCoreBlog/{id}");
            return Redirect("/EFCoreBlog");
        }
    }
}
*/