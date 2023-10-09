namespace Training.Dtos
{
    public class TrelloTaskDto
    {
        public Guid TaskId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreationDate { get; set; } 
        public HashSet<Guid>? AssignedTo { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public Guid ColumnId { get; set; }

    }
}
