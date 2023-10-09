using MediatR;
using Training.Models;

namespace Training.MediatR.Queries.BoardQuery
{
    public record GetBoardQuery() : IRequest<IEnumerable<TrelloBoard>>;

}
