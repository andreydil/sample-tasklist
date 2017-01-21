using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tasklist.Domain.Entities;

namespace Tasklist.DAL.SQL.Maps
{
    internal class ProjectMap: EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).HasMaxLength(255);
        }
    }
}
