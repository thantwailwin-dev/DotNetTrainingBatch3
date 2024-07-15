using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetTrainingBatch3.BlazorWasmAppV2.Models
{
    [Table("Tbl_Blog")]
    public class BlogModel
    {
        [Key]
        public string BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }
    }
}
