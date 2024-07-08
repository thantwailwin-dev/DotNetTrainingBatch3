using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.MvcApp2.Models
{
    [Table("Tbl_Blog")]
    public class BlogModel
    {
        [Key]
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }
    }

    public class BlogMessageResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    [Table("Tbl_PageStatistics")]
    public class PageStatisticsModel
    {
        [Key]
        public int PageStatistics { get; set; }
        public int SessionDuration { get; set; }
        public int PageViews { get; set; }
        public int TotalVisits { get; set; }
        public string CreatedDate { get; set; }

    }

    [Table("Tbl_RadarChart")]
    public class RadarModel
    {
        [Key]
        public int Id { get; set; }
        public string Month { get; set; }
        public int Series { get; set; }
    }

    public class ApexChartRadarResponseModel
    {      
        public List<int> Series { get; set; }
        public List<string> Lables { get; set; }
    }
}
