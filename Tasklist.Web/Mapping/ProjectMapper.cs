using System.Collections.Generic;
using System.Linq;
using Tasklist.Domain.Entities;
using Tasklist.Web.Models;

namespace Tasklist.Web.Mapping
{
    public static class ProjectMapper
    {
        public static ProjectModel Map(Project project)
        {
            if (project == null)
            {
                return null;
            }
            return new ProjectModel
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                DueDate = project.DueDate,
                Tasks = project.Tasks?.Select(TaskMapper.Map).ToList() ?? new List<TaskModel>(),
            };
        }
    }
}