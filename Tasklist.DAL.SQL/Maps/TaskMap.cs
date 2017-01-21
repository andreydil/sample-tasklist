using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tasklist.Domain.Entities;

namespace Tasklist.DAL.SQL.Maps
{
    internal class TaskMap : EntityTypeConfiguration<Task>
    {
        public TaskMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(t => t.Project).WithMany(p => p.Tasks);
            Property(t => t.Name).HasMaxLength(255);
        }
    }
}
