using System.Data.Common;

namespace Training.Models
{
    public class TrelloBoard
    {
        // a protected constructor is used to deal with database
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public TrelloBoard()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { }

        public TrelloBoard(string title)
        {
            BoardId = Guid.NewGuid();
            Title = title;
        }

        public Guid BoardId { get; set; }
        public string Title { get; set; }
        public List<TrelloColumn> Columns { get; set; } = new List<TrelloColumn>();
    }
}
