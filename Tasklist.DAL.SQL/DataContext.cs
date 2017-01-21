using System.Data.Entity;
using Tasklist.DAL.SQL.Maps;
using Tasklist.Domain.Entities;

namespace Tasklist.DAL.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
           : base("Name=DataContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new TaskMap());
        }
    }
}
