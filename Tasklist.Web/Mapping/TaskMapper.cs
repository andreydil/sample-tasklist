using Tasklist.Domain.Entities;
using Tasklist.Web.Models;

namespace Tasklist.Web.Mapping
{
    public static class TaskMapper
    {
        public static TaskModel Map(Task task)
        {
            if (task == null)
            {
                return null;
            }
            return new TaskModel {
                Id = task.Id,
                Name = task.Name,
                IsDone = task.IsDone,
            };
        }
    }
}