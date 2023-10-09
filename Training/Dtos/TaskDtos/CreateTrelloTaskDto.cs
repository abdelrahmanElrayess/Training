namespace Training.Dtos
{
    public class CreateTrelloTaskDto
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public HashSet<Guid>? AssignedTo { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public Guid ColumnId { get; set; }
    }
}
