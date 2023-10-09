using MediatR;
using Training.Dtos.CoulmnDtos;
using Training.Models;

namespace Training.MediatR.Commands
{
    public record AddCoulmnCommand(CreateCoulmnDto Coulmn) : IRequest<TrelloColumn>;

    public record UpdateCoulmnCommand(UpdateCoulmnDto Coulmn) : IRequest<TrelloColumn>;

    public record DeleteCoulmnCommand(Guid CoulmnId) : IRequest<TrelloColumn>;
}
