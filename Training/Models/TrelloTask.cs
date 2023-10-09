namespace Training.Models
{
    public class TrelloTask
    {
        
        public TrelloTask()
        {

        }
        public TrelloTask (
            string title,
            string? description,
            DateTime? dueDate,
            HashSet<Guid>? assignedTo,
            TaskStatus status,
            TaskPriority priority
            )
        {

            TaskId = Guid.NewGuid();
            Title = title;
            Description = description;
            DueDate = dueDate;
            AssignedTo = assignedTo;
            Status = status;
            Priority = priority;
       
        }

        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public HashSet<Guid>? AssignedTo { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public Guid ColumnId { get; set; }


    }
}
