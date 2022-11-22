using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Dragonfly.Data.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace Dragonfly.Data
{
    public class MainContext : DbContext
    {
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=app_data.db");
    }
}