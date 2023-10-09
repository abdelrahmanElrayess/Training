using Training.Models;

namespace Training.Dtos.BoardDtos
{
    public class CreateBoardDto
    {
        public required string Title { get; set; }
        public List<TrelloColumn>? Columns { get; set; }
    }
}
