using System;
using System.Collections.Generic;

namespace Tasklist.Domain.Entities
{
    public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
