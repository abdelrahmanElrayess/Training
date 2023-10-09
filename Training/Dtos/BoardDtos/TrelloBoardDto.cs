using Training.Models;

namespace Training.Dtos.BoardDtos
{
    public class TrelloBoardDto
    {

        public Guid BoardId { get; set; }
        public required string Title { get; set; }
        public List<TrelloColumn>? Columns { get; set; }
    }
}
