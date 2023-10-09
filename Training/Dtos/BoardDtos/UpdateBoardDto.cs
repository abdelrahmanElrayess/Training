using Training.Models;

namespace Training.Dtos.BoardDtos
{
    public class UpdateBoardDto
    {
        public Guid BoardId { get;  }

        public string? Title { get; set; }
        public UpdateWrapper <List<TrelloColumn>>? Columns { get; set; }
    }
}
