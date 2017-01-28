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
            return new TaskModel
            {
                Name = task.Name,
                IsDone = task.IsDone,
            };
        }

        public static Task Map(TaskModel task)
        {
            if (task == null)
            {
                return null;
            }
            return new Task
            {
                Name = task.Name,
                IsDone = task.IsDone,
            };
        }
    }
}