using Training.Models;

namespace Training.Dtos.CoulmnDtos
{
    public class TrelloCoulmnDto
    {
        public Guid ColumnId { get; set; }
        public required string Title { get; set; }
        public List<TrelloTask>? Tasks { get; set; } 
        public Guid BoardId { get; set; }
    }
}
