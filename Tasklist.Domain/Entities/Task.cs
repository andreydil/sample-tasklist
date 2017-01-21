namespace Tasklist.Domain.Entities
{
    public class Task
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }

        public virtual Project Project { get; set; }
    }
}
