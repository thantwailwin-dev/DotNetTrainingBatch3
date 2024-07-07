using DotNetTrainingBatch3.MvcApp.Models;
using DotNetTrainingBatch3.MvcApp.Services;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.MvcApp.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }*/

        public DbSet<BlogModel> Blogs { get; set; }
        public DbSet<PageStatisticsModel> PageStatistics { get; set; }
        public DbSet<RadarModel> Radars { get; set; }
    }
}
