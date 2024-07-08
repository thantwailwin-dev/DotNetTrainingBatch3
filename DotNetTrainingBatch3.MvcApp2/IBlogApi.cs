using DotNetTrainingBatch3.MvcApp2.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.MvcApp2
{
    public interface IBlogApi
    {
        [Get("/api/EFCoreBlog")]
        Task<List<BlogModel>> GetBlogs();

        [Get("/api/EFCoreBlog/{pageNo}/{pageSize}")]
        Task<BlogResponseModel> GetBlogs(int pageNo,int pageSize);

        [Get("/api/EFCoreBlog/{id}")]
        Task<BlogModel> GetBlog(int id);

        [Post("/api/EFCoreBlog")]
        Task<string> CreateBlog(BlogModel blog);

        [Put("/api/EFCoreBlog/{id}")]
        Task<string> UpdateBlog(int id, BlogModel blog);

        [Delete("/api/EFCoreBlog/{id}")]
        Task<string> DeleteBlog(int id);

    }    
}
