using Training.Models;

namespace Training.Dtos.CoulmnDtos
{
    public class CreateCoulmnDto
    {
        public required string Title { get; set; }
        public List<TrelloTask>? Tasks { get; set; }
        public Guid BoardId { get; set; }
    }
}
