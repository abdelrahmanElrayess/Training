namespace Training.Models
{
    public class TrelloColumn
    {
        // a protected constructor is used to deal with database
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public TrelloColumn()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { }

        public TrelloColumn(string title)
        {
            ColumnId = Guid.NewGuid();
            Title = title;
        }

        public Guid ColumnId { get; set; }
        public string Title { get; set; }
        public List<TrelloTask> Tasks { get; set; } = new List<TrelloTask>();
        public Guid BoardId { get; set; }
    }
}
