using MediatR;
using Training.Models;

namespace Training.MediatR.Queries.CoulmnQuery
{
    public record GetCoulmnQuery() : IRequest<IEnumerable<TrelloColumn>>;

}
