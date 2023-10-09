namespace Training.Dtos
{
    public class UpdateTrelloTaskDto
    {
        public Guid TaskId { get; }
        public string? Title { get; set; }
        public UpdateWrapper<string>? Description { get; set; }
        public DateTime UpdatedAt { get; set; }
        public UpdateWrapper<DateTime>? DueDate { get; set; }
        public  HashSet<Guid>? AssignedTo { get; set; }
        public TaskStatus? Status { get; set; }
        public TaskPriority? Priority { get; set; }
        public Guid? ColumnId { get; set; }
    }
}
