using Training.Models;

namespace Training.Dtos.CoulmnDtos
{
    public class UpdateCoulmnDto
    {
        public Guid ColumnId { get; }
        public string? Title { get; set; }
    }
}
