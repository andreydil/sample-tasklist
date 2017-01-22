using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tasklist.Web.Models
{
    public class ProjectModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public List<TaskModel> Tasks { get; set; }
    }
}