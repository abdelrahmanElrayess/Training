using MediatR;
using Training.Models;

namespace Training.MediatR.Queries.CoulmnQuery
{
    public record GetCoulmnByIdQuery(Guid CoulmnId) : IRequest<TrelloColumn>
    {
    }
}
